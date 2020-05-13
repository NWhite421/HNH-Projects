namespace Email_Parser
{
    partial class Conflict
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TxtJobNumberOW = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cbOverwriteList = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 155);
            this.label1.TabIndex = 0;
            this.label1.Text = "A conflict has been detected between the job numbers.\r\n\r\nFile Job Number: XX-XX-X" +
    "XX\r\nRecord Job Number: XX-XX-XXX\r\n\r\nHow do you wish to resolve this issue?";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(12, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(331, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Keep the File Job Number";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.KeepFileNumber);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(12, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(331, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Keep the Record Job Number";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.KeepRecordNumber);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(12, 307);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(331, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Overwrite the entered job number";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OverwriteNumber);
            // 
            // TxtJobNumberOW
            // 
            this.TxtJobNumberOW.Location = new System.Drawing.Point(12, 358);
            this.TxtJobNumberOW.Mask = "00-00-000";
            this.TxtJobNumberOW.Name = "TxtJobNumberOW";
            this.TxtJobNumberOW.Size = new System.Drawing.Size(90, 29);
            this.TxtJobNumberOW.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(108, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please enter a valid job number\r\n";
            this.label2.Visible = false;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(12, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(331, 45);
            this.button4.TabIndex = 6;
            this.button4.Text = "Reject";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.RejectAllTheShit);
            // 
            // cbOverwriteList
            // 
            this.cbOverwriteList.AutoSize = true;
            this.cbOverwriteList.Checked = true;
            this.cbOverwriteList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOverwriteList.Location = new System.Drawing.Point(12, 167);
            this.cbOverwriteList.Name = "cbOverwriteList";
            this.cbOverwriteList.Size = new System.Drawing.Size(292, 25);
            this.cbOverwriteList.TabIndex = 7;
            this.cbOverwriteList.Text = "Overwrite year and month for all jobs.";
            this.cbOverwriteList.UseVisualStyleBackColor = true;
            // 
            // Conflict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 455);
            this.Controls.Add(this.cbOverwriteList);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtJobNumberOW);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Conflict";
            this.Text = "Conflict Detected";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MaskedTextBox TxtJobNumberOW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox cbOverwriteList;
    }
}