using MDG.Core;
using RtfPipe.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Parser
{
    public partial class SI_V2 : Form
    {
        internal bool OverwriteFile = false;

        internal SubmissionDetails SubmissionDetails;

        internal SI_V2()
        {
            InitializeComponent();
        }

        public SI_V2(SubmissionDetails Details)
        {
            InitializeComponent();
            LblDate.Text = $"Date: {DateTime.Now:MM/dd/yy}";
            foreach (string jobNumber in Details.JobNumbers)
            {
                LbJobNumbers.Items.Add(jobNumber);
            }
            foreach (string file in Details.Files)
            {
                int index = LbFiles.Items.Add(Path.GetFileName(file));
            }
            TxtFieldCrew.Text = Details.Sender;
            TxtPurpose.Text = Details.Purpose;
            TxtAddress.Text = Details.Address;
            SubmissionDetails = Details;
        }

        private void OnLbJobNumberDblClk(object sender, MouseEventArgs e)
        {
            var jobItem = LbJobNumbers.SelectedItem;
            if (jobItem != null)
            {
                ChangeJobNumber change = new ChangeJobNumber(LbJobNumbers.GetItemText(jobItem));
                if (change.ShowDialog() == DialogResult.OK)
                {
                    int index = LbJobNumbers.SelectedIndex;
                    LbJobNumbers.Items.RemoveAt(index);
                    LbJobNumbers.Items.Insert(index, change.JobNumber);
                }
                change.Dispose();
            }
            else
            {
                ChangeJobNumber change = new ChangeJobNumber();
                if (change.ShowDialog() == DialogResult.OK)
                {
                    LbJobNumbers.Items.Add(change.JobNumber);
                }
                change.Dispose();
            }
        }

        private void OnLbJobNumberClk(object s, EventArgs e)
        {
            if (LbJobNumbers.SelectedItem == null)
            {
                CmdDelete.Visible = false;
            }
            else
            {
                CmdDelete.Visible = true;
            }
        }

        private void DeleteIndex(object sender, EventArgs e)
        {
            if (LbJobNumbers.SelectedItem == null)
            {
                CmdDelete.Visible = false;
                return;
            }
            LbJobNumbers.Items.RemoveAt(LbJobNumbers.SelectedIndex);
            CmdDelete.Visible = false;
        }


        private void ProcessJob(SubmissionDetails Details)
        {
            bool ApplyToAllFiles = false;
            int OverwriteAllFiles = -1; //0 = skip; 1 = overwrite; 2 = append
            //Run through for each job.
            foreach (string jobNumber in Details.JobNumbers)
            {
                string directoryBase = JobNumber.GetPath(jobNumber);
                string fieldDataFolder = directoryBase + "\\Field Data\\";
                string imageFolder = fieldDataFolder + "\\Images\\";

                string SenderInitials = GetInitials(Details.Sender);
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string formattedPurpose = textInfo.ToTitleCase(Details.Purpose);

                for (int i = 0; i < Details.Files.Count; i++)
                {
                    bool iterationDone = false;
                    while (!iterationDone)
                    {
                        string sourceFile = Details.Files[i];
                        string fileFormat = $"{jobNumber} {formattedPurpose} {SenderInitials} {DateTime.Now:MM-dd-yy}{Path.GetExtension(sourceFile)}";
                        fileFormat = ValidatePathString(fileFormat);
                        switch (Path.GetExtension(sourceFile))
                        {
                            case ".jpg":
                            case ".jpeg":
                            case ".png":
                            case ".tiff":
                                {
                                    if (!Directory.Exists(imageFolder))
                                    {
                                        if (!Directory.Exists(fieldDataFolder))
                                        {
                                            Directory.CreateDirectory(fieldDataFolder);
                                        }
                                        Directory.CreateDirectory(imageFolder);
                                    }
                                    string targetFile = imageFolder + fileFormat;
                                    if (File.Exists(targetFile) && OverwriteAllFiles == -1)
                                    {
                                        FileExists exists = new FileExists(targetFile);
                                        var ret = exists.ShowDialog();
                                        if (ret == DialogResult.Cancel)
                                        {
                                            MessageBox.Show("Operation cancelled. Please try again.");
                                            return;
                                        }
                                        if (exists.ConflictResult == FileConflictResult.Overwrite)
                                        {
                                            OverwriteAllFiles = 1;
                                            if (exists.ApplyToAllFiles)
                                            {
                                                ApplyToAllFiles = true;
                                            }
                                        }
                                        else if (exists.ConflictResult == FileConflictResult.Append)
                                        {
                                            OverwriteAllFiles = 2;
                                            if (exists.ApplyToAllFiles)
                                            {
                                                ApplyToAllFiles = true;
                                            }
                                        }
                                        else
                                        {
                                            OverwriteAllFiles = 0;
                                            if (exists.ApplyToAllFiles)
                                            {
                                                ApplyToAllFiles = true;
                                            }
                                        }
                                    }
                                    else if (File.Exists(targetFile) && OverwriteAllFiles == 1)
                                    {
                                        File.Copy(sourceFile, targetFile, true);
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    else if (File.Exists(targetFile) && OverwriteAllFiles == 2)
                                    {
                                        int fileCopyCount = 1;
                                        bool FileCreated = false;
                                        while (!FileCreated)
                                        {
                                            string targetFormatUpdated = Path.GetFileNameWithoutExtension(targetFile) + $" ({fileCopyCount})";
                                            string targetFileRevised = imageFolder + targetFormatUpdated + Path.GetExtension(targetFile);
                                            if (!File.Exists(targetFileRevised))
                                            {
                                                File.Copy(sourceFile, targetFileRevised);
                                                FileCreated = true;
                                            }
                                            else
                                            {
                                                fileCopyCount++;
                                            }
                                        }
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    else if (File.Exists(targetFile) && OverwriteAllFiles == 0)
                                    {
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    else
                                    {
                                        File.Copy(sourceFile, targetFile, true);
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (!Directory.Exists(fieldDataFolder))
                                    {
                                        Directory.CreateDirectory(fieldDataFolder);
                                    }
                                    string targetFile = fieldDataFolder + fileFormat;
                                    if (File.Exists(targetFile) && OverwriteAllFiles == -1)
                                    {
                                        FileExists exists = new FileExists(targetFile);
                                        var ret = exists.ShowDialog();
                                        if (ret == DialogResult.Cancel)
                                        {
                                            MessageBox.Show("Operation cancelled. Please try again.");
                                            return;
                                        }
                                        if (exists.ConflictResult == FileConflictResult.Overwrite)
                                        {
                                            OverwriteAllFiles = 1;
                                            if (exists.ApplyToAllFiles)
                                            {
                                                ApplyToAllFiles = true;
                                            }
                                        }
                                        else if (exists.ConflictResult == FileConflictResult.Append)
                                        {
                                            OverwriteAllFiles = 2;
                                            if (exists.ApplyToAllFiles)
                                            {
                                                ApplyToAllFiles = true;
                                            }
                                        }
                                        else
                                        {
                                            OverwriteAllFiles = 0;
                                            if (exists.ApplyToAllFiles)
                                            {
                                                ApplyToAllFiles = true;
                                            }
                                        }
                                    }
                                    else if (File.Exists(targetFile) && OverwriteAllFiles == 1)
                                    {
                                        File.Copy(sourceFile, targetFile, true);
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    else if (File.Exists(targetFile) && OverwriteAllFiles == 2)
                                    {
                                        int fileCopyCount = 1;
                                        bool FileCreated = false;
                                        while (!FileCreated)
                                        {
                                            string targetFormatUpdated = Path.GetFileNameWithoutExtension(targetFile) + $" ({fileCopyCount})";
                                            string targetFileRevised = fieldDataFolder + targetFormatUpdated + Path.GetExtension(targetFile);
                                            if (!File.Exists(targetFileRevised))
                                            {
                                                File.Copy(sourceFile, targetFileRevised);
                                                FileCreated = true;
                                            }
                                            else
                                            {
                                                fileCopyCount++;
                                            }
                                        }
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    else if (File.Exists(targetFile) && OverwriteAllFiles == 0)
                                    {
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    else
                                    {
                                        File.Copy(sourceFile, targetFile, true);
                                        iterationDone = true;
                                        if (!ApplyToAllFiles)
                                        {
                                            ApplyToAllFiles = false;
                                            OverwriteAllFiles = -1;
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
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

            string nFileName = Path.Combine(fileName + extent);

            return nFileName;
        }

        private void OnAcceptFiles(object sender, EventArgs e)
        {
            SubmissionDetails.JobNumbers.Clear();
            for (int i = 0; i < LbJobNumbers.Items.Count; i++)
            {
                SubmissionDetails.JobNumbers.Add(LbJobNumbers.GetItemText(LbJobNumbers.Items[i]));
            }
            SubmissionDetails.Address = TxtAddress.Text;
            SubmissionDetails.Purpose = TxtPurpose.Text;
            SubmissionDetails.Sender = TxtFieldCrew.Text;
            ProcessJob(SubmissionDetails);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
