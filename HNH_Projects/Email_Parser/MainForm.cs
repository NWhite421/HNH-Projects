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
using MsgReader;
using MsgReader.Outlook;

namespace Email_Parser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MDG.Options.JobNumber.BaseDirectory = "Z:\\";
        }

        private void DragDropEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void HandleEmailParse(MemoryStream filestream)
        {
            OutlookStorage.Message message = new OutlookStorage.Message(filestream);
            var parts = ParseMessage(message.BodyText);
            SubmitInfo info = new SubmitInfo(parts[0], message.From, parts[1], parts[2], message.Attachments);
            var result = info.ShowDialog();

            if (result == DialogResult.OK)
            {
                string initials = "";
                foreach (string part in message.From.Split(' '))
                {
                    initials += part[0];
                }
                JobNumber.TryParse(parts[0], out string formated, JobNumber.JobNumberFormats.ShortHyphan);
                string pFormated = parts[1].Replace("\\", "-")
                    .Replace("\\", "-")
                    .Replace("/", "-")
                    .Replace("\"", "-")
                    .Replace("*", "-")
                    .Replace("<", "-")
                    .Replace(">", "-")
                    .Replace("|", "-")
                    .Replace(":", "-");
                string filenameTemp = $"{formated} {pFormated} {initials} {DateTime.Now:MM-dd-yy}";

                MDG.Options.JobNumber.BaseDirectory = "Z:\\";
                string dirPath = JobNumber.GetPath(parts[0]) + "\\Field Data\\";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                int fileCount = 0;

                foreach (OutlookStorage.Attachment attachment in message.Attachments)
                {
                    string extent = Path.GetExtension(attachment.Filename);
                    File.WriteAllBytes(dirPath + filenameTemp + extent, attachment.Data);
                    fileCount++;
                }

                var succ = MessageBox.Show($"Files created successfully\nFile Name: {filenameTemp}\nFiles created: {fileCount}\n\nWould you like to open the location now?",
                    "Success", MessageBoxButtons.YesNo);
                if (succ == DialogResult.Yes)
                {
                    Process.Start(dirPath);
                }
            }
        }


        private void HandleEmailFileParse(string sender, string body, DateTime date, List<object> attachments )
        {
            var parts = ParseMessage(body);
            SubmitInfo info = new SubmitInfo(parts[0], sender, parts[1], parts[2], attachments);
            var result = info.ShowDialog();

            if (result == DialogResult.OK)
            {
                string initials = "";
                foreach (string part in sender.Split(' '))
                {
                    initials += part[0];
                }
                JobNumber.TryParse(parts[0], out string formated, JobNumber.JobNumberFormats.ShortHyphan);
                string pFormated = parts[1].Replace("\\", "-")
                    .Replace("\\", "-")
                    .Replace("/", "-")
                    .Replace("\"", "-")
                    .Replace("*", "-")
                    .Replace("<", "-")
                    .Replace(">", "-")
                    .Replace("|", "-")
                    .Replace(":", "-");
                string filenameTemp = $"{formated} {pFormated} {initials} {DateTime.Now:MM-dd-yy}";

                MDG.Options.JobNumber.BaseDirectory = "Z:\\";
                string dirPath = JobNumber.GetPath(parts[0]) + "\\Field Data\\";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                int fileCount = 0;

                foreach (Storage.Attachment attachment in attachments)
                {
                    string extent = Path.GetExtension(attachment.FileName);
                    File.WriteAllBytes(dirPath + filenameTemp + extent, attachment.Data);
                    fileCount++;
                }

                var succ = MessageBox.Show($"Files created successfully\nFile Name: {filenameTemp}\nFiles created: {fileCount}\n\nWould you like to open the location now?",
                    "Success", MessageBoxButtons.YesNo);
                if (succ == DialogResult.Yes)
                {
                    Process.Start(dirPath);
                }
            }
        }

        private List<string> ParseMessage(string source)
        {
            List<string> outp = new List<string> { };

            bool isJobNumber = false;
            bool isPurpose = false;
            bool isNotes = false;

            string notes = "";

            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException(source, "Source was provided as an empty string.");
            foreach (string line in source.Replace('\t','\0').Split(Environment.NewLine.ToCharArray()))
            {
                Log.ToDebug($"Content: \"{line}\"");
                if (string.IsNullOrEmpty(line))
                {

                }
                else if (line.ToLower() == "!!job number")
                {
                    isJobNumber = true;
                }
                else if (isJobNumber)
                {
                    outp.Add(line);
                    isJobNumber = false;
                }
                else if (line.ToLower() == "!!purpose")
                {
                    isPurpose = true;
                }
                else if (isPurpose)
                {
                    outp.Add(line);
                    isPurpose = false;
                }
                else if (line.ToLower() == "!!notes")
                {
                    isNotes = true;
                }
                else if (line.ToLower() == "!!end")
                {
                    outp.Add(notes);
                    isNotes = false;
                }
                else if (isNotes)
                {
                    Log.ToDebug("--adding line to note section.");
                    notes += line + Environment.NewLine;
                }
            }

            return outp;
        }

        private void DragDropSubmit(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Log.ToDebug("Outlook message file from outlook!");
                //wrap standard IDataObject in OutlookDataObject
                var dataObject = new OutlookDataObject(e.Data);

                //get the names and data streams of the files dropped
                string[] filenames = (string[])dataObject.GetData("FileGroupDescriptor");
                MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");

                for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                {
                    //use the fileindex to get the name and data stream
                    MemoryStream filestream = filestreams[fileIndex];
                    HandleEmailParse(filestream);
                }
            }
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                int fileCount = 0;
                foreach (var file in files)
                {
                    string fExtent = Path.GetExtension(file);
                    switch (fExtent)
                    {
                        case ".msg":
                            {
                                using (var msg = new MsgReader.Outlook.Storage.Message(file))
                                {
                                    var from = msg.Sender.DisplayName;
                                    var sentOn = msg.SentOn.Value;
                                    var htmlBody = msg.BodyText;
                                    var attachments = msg.Attachments;
                                    HandleEmailFileParse(from, htmlBody, sentOn, attachments);
                                }

                                break;
                            }
                        case ".jpg":
                        case ".png":
                        case ".gif":
                        case ".tiff":
                            {
                                Log.ToDebug("image file");
                                fileCount++;
                                break;
                            }
                        case ".txt":
                        case ".dwg":
                        case ".shx":
                            {
                                Log.ToDebug("field data file");
                                fileCount++;
                                break;
                            }
                        default:
                            {
                                Log.ToDebug($"unknown file type: {fExtent}");
                                fileCount++;
                                break;
                            }
                    }
                }
            }
            
        }
    }
}
