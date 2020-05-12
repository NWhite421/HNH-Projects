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
    public enum ConflictResult
    {
        KeepFileNumber,
        KeepRecordNumber,
        OverwriteNumber,
        Reject
    }

    public partial class Conflict : Form
    {
        public ConflictResult ConflictResult { get; set; }

        public string KeptNumber { get; set; }

        public bool OverwriteList { get; set; }

        internal string recordNumber;
        internal string fileNumber;

        public Conflict(string fileNumber, string recordNumber)
        {
            InitializeComponent();
            string message = $"A conflict has been detected between the job numbers.\n\n" +
                $"File Job Number: {fileNumber}\n" +
                $"Record Job Number: {recordNumber}\n\n" +
                $"How do you wish to resolve this issue?";
            label1.Text = message;
            this.ConflictResult = ConflictResult.Reject;
            OverwriteList = false;
            this.recordNumber = recordNumber;
            this.fileNumber = fileNumber;
        }

        private void KeepRecordNumber(object sender, EventArgs e)
        {
            KeptNumber = recordNumber;
            ConflictResult = ConflictResult.KeepRecordNumber;
            this.Close();
        }

        private void KeepFileNumber(object sender, EventArgs e)
        {
            KeptNumber = fileNumber;
            ConflictResult = ConflictResult.KeepFileNumber;
            this.Close();
        }

        private void OverwriteNumber(object sender, EventArgs e)
        {
            if (MDG.Core.JobNumber.TryParse(TxtJobNumberOW.Text, out string formattedNumber, MDG.Core.JobNumber.JobNumberFormats.ShortHyphan))
            {
                KeptNumber = formattedNumber;
                ConflictResult = ConflictResult.OverwriteNumber;
                this.Close();
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void RejectAllTheShit(object s, EventArgs e)
        {
            this.Close();
        }
    }
}
