using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MDG.Core;
using System.IO;
using iwantedue;
using MsgReader;
using MsgReader.Outlook;

namespace Email_Parser
{
    public partial class SubmitInfo : Form
    {
        public SubmissionDetails SubmissionDetails { get; set; }

        internal bool AllowEdit { get; set; }

        internal SubmitInfo()
        {
            InitializeComponent();
        }

        public SubmitInfo(string jobNumber, string submitter, string purpose, string notes, List<OutlookStorage.Attachment> attachments)
        {
            InitializeComponent();
            if (JobNumber.TryParse(jobNumber, out string formatNumber, JobNumber.JobNumberFormats.ShortHyphan))
            {
                TxtJobNumber.Text = formatNumber;
                TxtSubmitPerson.Text = submitter;
                TxtPurpose.Text = purpose;
                TxtNotes.Text = notes;
                foreach (OutlookStorage.Attachment file in attachments)
                {
                    string entry = $"[{Path.GetExtension(file.Filename).Remove(0,1).ToLower()}]: {Path.GetFileNameWithoutExtension(file.Filename)}";
                    LbFiles.Items.Add(entry);
                }
                LblDate.Text = "Received: " + DateTime.Now.ToString("MM/dd/yyyy");
                AllowEdit = false;
            }
            else
            {
                Log.AddError("Job number provided was not valid.");
            }
        }

        public SubmitInfo(string jobNumber, string submitter, string purpose, string notes, List<object> attachments)
        {
            InitializeComponent();
            if (JobNumber.TryParse(jobNumber, out string formatNumber, JobNumber.JobNumberFormats.ShortHyphan))
            {
                TxtJobNumber.Text = formatNumber;
                TxtSubmitPerson.Text = submitter;
                TxtPurpose.Text = purpose;
                TxtNotes.Text = notes;
                foreach (object fileS in attachments)
                {
                    var file = (Storage.Attachment)fileS;
                    string entry = $"[{Path.GetExtension(file.FileName).Remove(0, 1).ToLower()}]: {Path.GetFileNameWithoutExtension(file.FileName)}";
                    LbFiles.Items.Add(entry);
                }
                LblDate.Text = "Received: " + DateTime.Now.ToString("MM/dd/yyyy");
                AllowEdit = false;
            }
            else
            {
                Log.AddError("Job number provided was not valid.");
            }
        }

        public SubmitInfo(List<string> attachments)
        {
            InitializeComponent();
            foreach (string file in attachments)
            {
                string entry = $"[{Path.GetExtension(file).Remove(0, 1).ToLower()}]: {Path.GetFileNameWithoutExtension(file)}";
                LbFiles.Items.Add(entry);
            }
            LblDate.Text = "Received: " + DateTime.Now.ToString("MM/dd/yyyy");

            AllowEdit = true;
            TxtJobNumber.Enabled = true;
            TxtSubmitPerson.Enabled = true;
            TxtPurpose.Enabled = true;
            TxtNotes.Enabled = true;
        }

        private void ConfirmSettings(object sender, EventArgs e)
        {
            if (AllowEdit)
            {
                SubmissionDetails = new SubmissionDetails
                {
                    JobNumber = new List<string> { TxtJobNumber.Text },
                    Sender = TxtSubmitPerson.Text,
                    Purpose = TxtPurpose.Text,
                    Notes = TxtNotes.Text
                };
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelImport(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
