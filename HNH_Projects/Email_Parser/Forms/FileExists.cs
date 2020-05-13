using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Parser
{
    public enum FileConflictResult
    {
        Overwrite,
        Append,
        Skip
    }

    public partial class FileExists : Form
    {
        public FileConflictResult ConflictResult { get; set; }

        public bool ApplyToAllFiles { get; set; }

        public FileExists()
        {
            InitializeComponent();
        }

        public FileExists(string Filename)
        {
            InitializeComponent();
            TxtMessage.Text = $"The following file already exists. How do you want to proceed?\n" +
                $"\n" +
                $"File: {Path.GetFileName(Filename)}\n" +
                $"Folder: {Path.GetDirectoryName(Filename)}?";

            this.ConflictResult = FileConflictResult.Skip;
            ApplyToAllFiles = false;
        }

        private void OverwriteFile(object s, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ApplyToAllFiles = true;
            }
            else
            {
                ApplyToAllFiles = false;
            }
            this.ConflictResult = FileConflictResult.Overwrite;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void AppendFile(object s, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ApplyToAllFiles = true;
            }
            else
            {
                ApplyToAllFiles = false;
            }
            this.ConflictResult = FileConflictResult.Append;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void SkipFile(object s, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ApplyToAllFiles = true;
            }
            else
            {
                ApplyToAllFiles = false;
            }
            this.ConflictResult = FileConflictResult.Skip;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
