using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Parser
{
    public partial class SI_V2 : Form
    {
        public SI_V2()
        {
            InitializeComponent();
        }

        public SI_V2(List<string> JobNumbers, List<string> Files, string Submitter, string Purpose)
        {
            InitializeComponent();
            LblDate.Text = $"Date: {DateTime.Now:MM/dd/yy}";
            foreach (string jobNumber in JobNumbers)
            {
                LbJobNumbers.Items.Add(jobNumber);
            }
            foreach (string file in Files)
            {
                LbFiles.Items.Add(file);
            }
            TxtFieldCrew.Text = Submitter;
            TxtPurpose.Text = Purpose;
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
    }
}
