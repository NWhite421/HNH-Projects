﻿using MDG.Core;
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
using System.Xml;

namespace Email_Parser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (!Directory.Exists("C:\\temp"))
            {
                Directory.CreateDirectory("C:\\temp");
            }
            MDG.Options.JobNumber.BaseDirectory = "Z:\\";
        }

        #region FILE HANDLERS

        //COMPLETE
        private void HandleOutlookItem(MemoryStream filestream)
        {
            OutlookStorage.Message message = new OutlookStorage.Message(filestream);
            string fileName = $"temp_msg_{DateTime.Now:MM-dd-yy hh-mm-ss tt}.msg";
            message.Save(@"c:\temp\" + fileName);
            message.Dispose();
            HandleEmailFile(@"c:\temp\" + fileName);
            File.Delete(@"c:\temp\" + fileName);
        }

        //COMPLETE
        private void HandleEmailFile(string file)
        {
            using (var message = new Storage.Message(file))
            {
                var attachFolder = Directory.CreateDirectory($@"c:\temp\temp_msg_attachments_{DateTime.Now:MM-dd-yy hh-mm-ss tt}").FullName;
                List<string> files = new List<string> { };
                foreach (Storage.Attachment attachment in message.Attachments)
                {
                    File.WriteAllBytes(attachFolder + "\\" + attachment.FileName, attachment.Data);
                    files.Add(attachFolder + "\\" + attachment.FileName);
                }

                SubmissionDetails details = ParseMessage(message.BodyText);
                details.Sender = message.Sender.DisplayName;
                int[] handed = HandleFiles(details, files);
                Directory.Delete(attachFolder, true);
                if (handed[0] + handed[1] == 0)
                {
                    MessageBox.Show("Something went wrong. Please try again.");
                    return;
                }
#if DEBUG

#else
                message.Save($@"Z:\Archive\Field Data E-Mails\{details.JobNumber[0]} {GetInitials(details.Sender)} {DateTime.Now:MM-dd-yy HH-mm-ss}.msg");
                File.AppendAllLines($@"Z:\Archive\Field Data E-Mails Record Search.csv",
                    new List<string> { $@"{details.JobNumber[0]}, {details.Address}, {details.Purpose}, {GetInitials(details.Sender)}, {DateTime.Now:MM-dd-yy HH-mm-ss}, Z:\Archive\{details.JobNumber[0]} {GetInitials(details.Sender)} {DateTime.Now:MM-dd-yy HH-mm-ss}.msg" });
#endif
                var result = MessageBox.Show(
                    $"The e-mail has been parsed successfully! See below for the information.\n" +
                    $"Address: {details.Address}\n" +
                    $"Message Date: {message.ReceivedOn.Value}\n" +
                    $"Sender: {message.Sender.DisplayName} ({message.Sender.Email})\n" +
                    $"Purpose: {details.Purpose}\n" +
                    $"Total Files: {message.Attachments.Count}\n" +
                    $"    Images: {handed[1]}\n" +
                    $"    Other Files: {handed[0]}\n\n" +
                    $"Would you like to open the field data now?",
                    "Parsing Successful",
                    MessageBoxButtons.YesNo
                    );
                message.Dispose();
                if (result == DialogResult.Yes)
                {
                    Process.Start(JobNumber.GetPath(details.JobNumber[0]) + "\\Field Data\\");
                }
            }
        }

        #endregion

        #region INTERNAL FUNCTIONS

        private int[] HandleFiles(SubmissionDetails details, List<string> files)
        {
            var handledFiles = new int[] { 0, 0 };
            var isMultipleFiles = false;
            var overwriteYearMonth = false;
            var isValidJob = false;
            var overwriteExisingfiles = 0;
            var currItieration = 0;
            if (details.JobNumber.Count > 1)
            {
                isMultipleFiles = true;
            }
            foreach (string jobNo in details.JobNumber)
            {
                string jobNumber = jobNo;
                var jobPath = JobNumber.GetPath(jobNumber);
                handledFiles = new int[] { 0, 0 };

                if (string.IsNullOrEmpty(jobPath)) return handledFiles;

                //Grab the first file and check for its job number.
                string pathT = files[0];
                string fPath = Path.GetFileNameWithoutExtension(pathT).Split(' ')[0];

                if (JobNumber.TryParse(fPath) && jobNo != fPath && !overwriteYearMonth && (!isMultipleFiles || isMultipleFiles && currItieration == 0))
                {
                    Conflict conflict = new Conflict(fPath, jobNo);
                    conflict.ShowDialog();
                    switch (conflict.ConflictResult)
                    {
                        case ConflictResult.KeepFileNumber:
                        case ConflictResult.KeepRecordNumber:
                        case ConflictResult.OverwriteNumber:
                            {
                                if (conflict.OverwriteList)
                                {
                                    overwriteYearMonth = true;
                                }
                                jobNumber = conflict.KeptNumber;
                                break;
                            }
                        case ConflictResult.Reject:
                            {
                                MessageBox.Show("The conflict was rejected. Aborting operation.");
                                return new int[] { 0, 0 };
                            }
                    }
                }

                string filename = $"{jobNumber} {details.Purpose} {GetInitials(details.Sender)} {DateTime.Now:MM-dd-yy}";
                if (!Directory.Exists(jobPath + "\\Field Data\\"))
                {
                    jobPath = Directory.CreateDirectory(jobPath + "\\Field Data\\").FullName;
                }
                else
                {
                    jobPath += "\\Field Data\\";
                }
                foreach (string path in files)
                {
                    string fext = Path.GetExtension(path);

                    switch (fext.ToLower())
                    {
                        case ".jpeg":
                        case ".jpg":
                        case ".png":
                        case ".gif":
                        case ".tiff":
                            {
                                if (!Directory.Exists(jobPath + "\\Images\\"))
                                {
                                    Directory.CreateDirectory(jobPath + "\\Images\\");
                                }
                                string fillpath = ValidatePathString(Path.Combine(jobPath + "\\Images\\", filename + fext));
                                if (File.Exists(fillpath) && overwriteExisingfiles == 0)
                                {
                                    var result = MessageBox.Show(
                                        $"The following file already exists. Do you want to overwrite it?\n\n" +
                                        $"{fillpath}\n" +
                                        $"\nPress \"YES\" to overwrite\n" +
                                        $"Press \"NO\" to append file name\n" +
                                        $"Press \nCANCEL\n to cancel.",
                                        "Overwrite file",
                                        MessageBoxButtons.YesNoCancel
                                        );
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                File.Copy(path, fillpath);
                                                handledFiles[1]++;
                                                overwriteExisingfiles = 1;
                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                int fileTry = 1;
                                                bool failedattempt = true;
                                                while (failedattempt)
                                                {
                                                    string filenameExtra = filename + $" - ({fileTry})";
                                                    fillpath = ValidatePathString(Path.Combine(jobPath + "\\Images\\", filename + fext));
                                                    if (File.Exists(fillpath))
                                                    {
                                                        fileTry++;
                                                    }
                                                    else
                                                    {
                                                        File.Copy(path, fillpath);
                                                        handledFiles[1]++;
                                                        failedattempt = false;
                                                    }
                                                }
                                                overwriteExisingfiles = 2;
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                } 
                                else if (overwriteExisingfiles == 1)
                                {
                                    File.Copy(path, fillpath);
                                    handledFiles[1]++;
                                    break;
                                }
                                else
                                {
                                    int fileTry = 1;
                                    bool failedattempt = true;
                                    while (failedattempt)
                                    {
                                        string filenameExtra = filename + $" - ({fileTry})";
                                        fillpath = ValidatePathString(Path.Combine(jobPath + "\\Images\\", filename + fext));
                                        if (File.Exists(fillpath))
                                        {
                                            fileTry++;
                                        }
                                        else
                                        {
                                            File.Copy(path, fillpath);
                                            handledFiles[1]++;
                                            failedattempt = false;
                                        }
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                string fillpath = ValidatePathString(Path.Combine(jobPath, filename + fext));
                                if (File.Exists(fillpath) && overwriteExisingfiles == 0)
                                {
                                    var result = MessageBox.Show(
                                        $"The following file already exists. Do you want to overwrite it?\n\n" +
                                        $"{fillpath}\n" +
                                        $"\nPress \"YES\" to overwrite\n" +
                                        $"Press \"NO\" to append file name\n" +
                                        $"Press \"CANCEL\" to cancel.",
                                        "Overwrite file",
                                        MessageBoxButtons.YesNoCancel
                                        );
                                    switch (result)
                                    {
                                        case DialogResult.Yes:
                                            {
                                                File.Copy(path, fillpath, true);
                                                handledFiles[0]++;
                                                overwriteExisingfiles = 1;
                                                break;
                                            }
                                        case DialogResult.No:
                                            {
                                                int fileTry = 1;
                                                bool failedattempt = true;
                                                while (failedattempt)
                                                {
                                                    string filenameExtra = filename + $" ({fileTry})";
                                                    fillpath = ValidatePathString(Path.Combine(jobPath, filenameExtra + fext));
                                                    if (File.Exists(fillpath))
                                                    {
                                                        fileTry++;
                                                    }
                                                    else
                                                    {
                                                        File.Copy(path, fillpath);
                                                        handledFiles[0]++;
                                                        failedattempt = false;
                                                    }
                                                }
                                                overwriteExisingfiles = 2;
                                                break;
                                            }
                                        case DialogResult.Cancel:
                                            {
                                                break;
                                            }
                                    }
                                }
                                else if (File.Exists(fillpath) && overwriteExisingfiles == 1)
                                {
                                    File.Copy(path, fillpath, true);
                                    handledFiles[0]++;
                                    break;
                                }
                                else if (File.Exists(fillpath) && overwriteExisingfiles == 2)
                                {
                                    int fileTry = 1;
                                    bool failedattempt = true;
                                    while (failedattempt)
                                    {
                                        string filenameExtra = filename + $" ({fileTry})";
                                        fillpath = ValidatePathString(Path.Combine(jobPath, filenameExtra + fext));
                                        if (File.Exists(fillpath))
                                        {
                                            fileTry++;
                                        }
                                        else
                                        {
                                            File.Copy(path, fillpath);
                                            handledFiles[0]++;
                                            failedattempt = false;
                                        }
                                    }
                                    break;
                                }
                                else if (!File.Exists(fillpath))
                                {
                                    File.Copy(path, fillpath);
                                    handledFiles[0]++;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                                break;
                            }
                    }
                }

                string logEntry = $@"Sent by: {details.Sender}" + Environment.NewLine +
                    $@"Processed By: {Environment.MachineName}\{Environment.UserName}" + Environment.NewLine +
                    $@"Date: {DateTime.Now:MM-dd-yy HH-mm-ss}" + Environment.NewLine +
                    $@"Purpose: {details.Purpose}" + Environment.NewLine +
                    $@"Occurances: {details.JobNumber.Count}" + Environment.NewLine +
                    $@"Address: {details.Address}" + Environment.NewLine +
                    $@"Notes:" + Environment.NewLine + $"{details.Notes}";
                if (!Directory.Exists(jobPath + "\\Logs\\"))
                {
                    jobPath = Directory.CreateDirectory(jobPath + "\\Logs\\").FullName;
                }
                else
                {
                    jobPath += "\\Logs\\";
                }
                File.WriteAllText(jobPath + filename + ".log", logEntry);
                currItieration++;
            }
            return handledFiles;
        }

        private string GetInitials(string name)
        {
            string[] parts = name.Split(' ');
            string initials = "";
            foreach (string part in parts)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    initials += part[0];
                }
            }
            return initials;
        }

        private string ValidatePathString(string source)
        {
            string parent = Directory.GetParent(source).FullName;
            string fileName = Path.GetFileNameWithoutExtension(source);
            string extent = Path.GetExtension(source);

            fileName = fileName.Replace("\\", "-")
                    .Replace("\\", "-")
                    .Replace("/", "-")
                    .Replace("\"", "-")
                    .Replace("*", "-")
                    .Replace("<", "-")
                    .Replace(">", "-")
                    .Replace("|", "-")
                    .Replace(":", "-");

            string nFileName = Path.Combine(parent, fileName + extent);

            return nFileName;
        }

        private SubmissionDetails ParseMessage(string bodyText)
        {
            SubmissionDetails details = new SubmissionDetails();

            bool isJobNumber = false;
            bool isPurpose = false;
            bool isNotes = false;
            bool isAddress = false;

            string notes = "";

            if (string.IsNullOrEmpty(bodyText)) throw new ArgumentNullException(bodyText, "Source was provided as an empty string.");
            foreach (string line in bodyText.Replace('\t','\0').Split(Environment.NewLine.ToCharArray()))
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
                    string[] numbers = line.Split(' ');
                    int number = 0;
                    details.JobNumber = new List<string> { };

                    foreach (string iNumber in numbers)
                    {
                        if (number == 0)
                        {
                            details.JobNumber.Add(iNumber);
                            number = 1;
                        }
                        else
                        {
                            string[] parts = details.JobNumber[0].Split('-');
                            details.JobNumber.Add($"{parts[0]}-{parts[1]}-{iNumber}");
                        }
                    }
                    isJobNumber = false;
                }
                else if (line.ToLower() == "!!address")
                {
                    isAddress = true;
                }
                else if (isAddress)
                {
                    details.Address = line;
                    isAddress = false;
                }
                else if (line.ToLower() == "!!purpose")
                {
                    if (isAddress && string.IsNullOrEmpty(details.Address))
                    {
                        isAddress = false;
                        details.Address = "NoAddress";
                    }
                    isPurpose = true;
                }
                else if (isPurpose)
                {
                    details.Purpose = line;
                    isPurpose = false;
                }
                else if (line.ToLower() == "!!notes")
                {
                    if (isAddress && string.IsNullOrEmpty(details.Address))
                    {
                        isAddress = false;
                        details.Address = "NoAddress";
                    }
                    isNotes = true;
                }
                else if (line.ToLower() == "!!end")
                {
                    if (isAddress && string.IsNullOrEmpty(details.Address))
                    {
                        isAddress = false;
                        details.Address = "NoAddress";
                    }
                    details.Notes = notes;
                    isNotes = false;
                }
                else if (isNotes)
                {
                    Log.ToDebug("--adding line to note section.");
                    notes += line + Environment.NewLine;
                }
            }
            if (string.IsNullOrEmpty(details.Address))
            {
                details.Address = "NoAddress";
            }

            return details;
        }
        #endregion

        #region EVENT HANDLERS
        private void DragDropEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void DragDropSubmit(object sender, DragEventArgs e)
        {
            //If the thing being dragged is an outlook message item. (not the .msg file)
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
                    HandleOutlookItem(filestream);
                }
            }
            else
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1)
                {
                    string path = files[0];
                    string fExtent = Path.GetExtension(path);
                    //It is a msg file.
                    if (fExtent == ".msg")
                    {
                        HandleEmailFile(path);
                    } 
                    //It isn't a msg file.
                    else
                    {
                        SubmitInfo info = new SubmitInfo(new List<string> { path });
                        if (info.ShowDialog() == DialogResult.OK)
                        {
                            var handed = HandleFiles(info.SubmissionDetails, new List<string> { path });
                            var result = MessageBox.Show(
                            $"The file has been parsed successfully! See below for the information.\n" +
                            $"Submission Date: {DateTime.Now:MM-dd-yy HH-mm-ss}\n" +
                            $"Sender: {info.SubmissionDetails.Sender}\n" +
                            $"Purpose: {info.SubmissionDetails.Purpose}\n" +
                            $"Total Files: 1\n" +
                            $"    Images: {handed[1]}\n" +
                            $"    Other Files: {handed[0]}\n\n" +
                            $"Would you like to open the field data now?",
                            "Parsing Successful",
                            MessageBoxButtons.YesNo
                            );
                            if (result == DialogResult.Yes)
                            {
                                Process.Start(JobNumber.GetPath(info.SubmissionDetails.JobNumber[0]) + "\\Field Data\\");
                            }
                        }
                    }
                }
                else
                {
                    SubmitInfo info = new SubmitInfo(files.ToList());
                    if (info.ShowDialog() == DialogResult.OK)
                    {
                        var handed = HandleFiles(info.SubmissionDetails, files.ToList());
                        var result = MessageBox.Show(
                        $"The file has been parsed successfully! See below for the information.\n" +
                        $"Submission Date: {DateTime.Now:MM-dd-yy HH-mm-ss}\n" +
                        $"Sender: {info.SubmissionDetails.Sender}\n" +
                        $"Purpose: {info.SubmissionDetails.Purpose}\n" +
                        $"Total Files: {files.ToList().Count}\n" +
                        $"    Images: {handed[1]}\n" +
                        $"    Other Files: {handed[0]}\n\n" +
                        $"Would you like to open the field data now?",
                        "Parsing Successful",
                        MessageBoxButtons.YesNo
                        );
                        if (result == DialogResult.Yes)
                        {
                            Process.Start(JobNumber.GetPath(info.SubmissionDetails.JobNumber[0]) + "\\Field Data\\");
                        }
                    }
                }
            }
            
        }

        #endregion
    }
}
