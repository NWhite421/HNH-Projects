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
    public partial class ChangeJobNumber : Form
    {
        public string JobNumber { get { return maskedTextBox1.Text; } }

        public ChangeJobNumber()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        public ChangeJobNumber(string Original)
        {
            InitializeComponent();
            maskedTextBox1.Text = Original;
            this.DialogResult = DialogResult.Cancel;
        }

        private void OnAccept(object s, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnCancel(object s, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
