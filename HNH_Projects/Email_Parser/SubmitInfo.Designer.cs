namespace Email_Parser
{
    partial class SubmitInfo
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
            this.TxtJobNumber = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSubmitPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.TxtPurpose = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LbFiles = new System.Windows.Forms.ListBox();
            this.CmdConfirm = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtJobNumber
            // 
            this.TxtJobNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtJobNumber.Enabled = false;
            this.TxtJobNumber.Location = new System.Drawing.Point(163, 12);
            this.TxtJobNumber.Mask = "00-00-000";
            this.TxtJobNumber.Name = "TxtJobNumber";
            this.TxtJobNumber.Size = new System.Drawing.Size(103, 29);
            this.TxtJobNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Target Job Number:";
            // 
            // TxtSubmitPerson
            // 
            this.TxtSubmitPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSubmitPerson.Enabled = false;
            this.TxtSubmitPerson.Location = new System.Drawing.Point(163, 47);
            this.TxtSubmitPerson.Name = "TxtSubmitPerson";
            this.TxtSubmitPerson.Size = new System.Drawing.Size(309, 29);
            this.TxtSubmitPerson.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Submitted By:";
            // 
            // LblDate
            // 
            this.LblDate.Location = new System.Drawing.Point(272, 15);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(200, 21);
            this.LblDate.TabIndex = 4;
            this.LblDate.Text = "XX/XX/XXXX";
            this.LblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtPurpose
            // 
            this.TxtPurpose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPurpose.Enabled = false;
            this.TxtPurpose.Location = new System.Drawing.Point(163, 82);
            this.TxtPurpose.Name = "TxtPurpose";
            this.TxtPurpose.Size = new System.Drawing.Size(309, 29);
            this.TxtPurpose.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Purpose:";
            // 
            // TxtNotes
            // 
            this.TxtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNotes.Enabled = false;
            this.TxtNotes.Location = new System.Drawing.Point(12, 142);
            this.TxtNotes.Multiline = true;
            this.TxtNotes.Name = "TxtNotes";
            this.TxtNotes.Size = new System.Drawing.Size(460, 72);
            this.TxtNotes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Notes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Attachments:";
            // 
            // LbFiles
            // 
            this.LbFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbFiles.Enabled = false;
            this.LbFiles.FormattingEnabled = true;
            this.LbFiles.ItemHeight = 21;
            this.LbFiles.Location = new System.Drawing.Point(12, 241);
            this.LbFiles.Name = "LbFiles";
            this.LbFiles.Size = new System.Drawing.Size(460, 149);
            this.LbFiles.TabIndex = 10;
            // 
            // CmdConfirm
            // 
            this.CmdConfirm.Location = new System.Drawing.Point(372, 416);
            this.CmdConfirm.Name = "CmdConfirm";
            this.CmdConfirm.Size = new System.Drawing.Size(100, 33);
            this.CmdConfirm.TabIndex = 11;
            this.CmdConfirm.Text = "Confirm";
            this.CmdConfirm.UseVisualStyleBackColor = true;
            this.CmdConfirm.Click += new System.EventHandler(this.ConfirmSettings);
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(12, 416);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(100, 33);
            this.CmdCancel.TabIndex = 12;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CancelImport);
            // 
            // SubmitInfo
            // 
            this.AcceptButton = this.CmdConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdConfirm);
            this.Controls.Add(this.LbFiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPurpose);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtSubmitPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtJobNumber);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubmitInfo";
            this.Text = "Submission Confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox TxtJobNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSubmitPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TextBox TxtPurpose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox LbFiles;
        private System.Windows.Forms.Button CmdConfirm;
        private System.Windows.Forms.Button CmdCancel;
    }
}