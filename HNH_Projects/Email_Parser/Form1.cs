using MDG.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iwantedue.Windows.Forms;
using iwantedue;
using System.IO;
using System.Diagnostics;
using Microsoft.SqlServer.Server;

namespace Email_Parser
{
    public partial class Form1 : Form
    {
        OutlookDataObject dataObject { get; set; }

        bool IsConfirmed { get; set; }

        public Form1()
        {
            InitializeComponent();
            MDG.Options.JobNumber.BaseDirectory = "Z:\\";
        }

        private void DragDropEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void DragDropSubmit(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Log.ToDebug("Outlook message file from outlook!");
                //wrap standard IDataObject in OutlookDataObject
                dataObject = new OutlookDataObject(e.Data);

                //get the names and data streams of the files dropped
                string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");
                MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");

                for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                {
                    //use the fileindex to get the name and data stream
                    string filename = filenames[fileIndex];
                    MemoryStream filestream = filestreams[fileIndex];

                    OutlookStorage.Message message = new OutlookStorage.Message(filestream);
                    HandleEmail(message);
                    lblConfirm.Text = "Is the above information correct?";
                    lblConfirm.Visible = true;
                    IsConfirmed = true;
                    message.Dispose();
                }
            }
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var file in files)
                {
                    string fExtent = System.IO.Path.GetExtension(file);
                    switch (fExtent)
                    {
                        case ".msg":
                            {
                                Log.ToDebug("Outlook message file");
                                break;
                            }
                        case ".jpg":
                        case ".png":
                        case ".gif":
                        case ".tiff":
                            {
                                Log.ToDebug("image file");
                                break;
                            }
                        case ".txt":
                        case ".dwg":
                        case ".shx":
                            {
                                Log.ToDebug("field data file");
                                break;
                            }
                        case null:
                            {

                                Log.ToDebug("Outlook message file from outlook?");
                                break;
                            }
                        default:
                            {
                                Log.ToDebug($"unknown file type: {fExtent}");
                                break;
                            }
                    }
                }
            }
            
        }

        private void HandleEmail(OutlookStorage.Message message)
        {
            TxtSender.Text = message.From;
            bool isJobNumber = false;
            bool isPurpose = false;
            bool isNotes = false;

            int files = message.Attachments.Count;
            LblFile.Text = "Files: " + files;

            foreach (string line in message.BodyText.Split(Environment.NewLine.ToCharArray()))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    Debug.WriteLine(line);
                    if (line.ToLower() == "!!job number")
                    {
                        isJobNumber = true;
                    }
                    else if (isJobNumber)
                    {
                        JobNumber.TryParse(line, out string formated, JobNumber.JobNumberFormats.ShortHyphan);
                        TxtJobNumber.Text = formated;
                        isJobNumber = false;
                    }
                    else if (line.ToLower() == "!!purpose")
                    {
                        isPurpose = true;
                    }
                    else if (isPurpose)
                    {
                        TxtPurpose.Text = line;
                        isPurpose = false;
                    }
                    else if (line.ToLower() == "!!notes")
                    {
                        isNotes = true;
                    }
                    else if (isNotes)
                    {
                        TxtNotes.Text = line + Environment.NewLine;
                    }
                }
            }
            message.Dispose();
        }

        private void AcceptInformation(object sender, EventArgs e)
        {
            if (!IsConfirmed)
            {
                lblConfirm.Text = "Please confirm the information is correct.";
                lblConfirm.Visible = true;
                return;
            }

            MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");
            MemoryStream filestream = filestreams[0];
            OutlookStorage.Message message = new OutlookStorage.Message(filestream);
            if (JobNumber.TryParse(TxtJobNumber.Text, out string reformatted, JobNumber.JobNumberFormats.ShortHyphan))
            {
                string initials = "";
                foreach (string namepart in TxtSender.Text.Split(' '))
                {
                    initials += namepart[0];
                }
                string formatpurpose = TxtPurpose.Text.Replace(@"\", "_").Replace("/", "_").Replace(":", "_").Replace("*", "_").Replace("?", "_").Replace("\"", "_").Replace("<", "_").Replace(">", "_").Replace("|", "_");
                string formatname = $"{reformatted} {TxtPurpose.Text.Replace(@"\","-")} {initials} {DateTime.Now.ToString("MM-dd-yy")}";
                foreach (OutlookStorage.Attachment file in message.Attachments)
                {
                    string extent = Path.GetExtension(file.Filename);
                    string name = formatname + extent;
                    string path = JobNumber.GetPath(reformatted);
                    path += @"\Field Data\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path += name;
                    File.WriteAllBytes(path, file.Data);
                }
            }
            message.Dispose();
        }
    }
}
