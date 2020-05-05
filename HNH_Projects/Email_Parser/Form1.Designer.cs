namespace Email_Parser
{
    partial class Form1
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
            this.lblDrop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtJobNumber = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtPurpose = new System.Windows.Forms.TextBox();
            this.TxtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmdConfirm = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.TxtSender = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LblFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDrop
            // 
            this.lblDrop.AllowDrop = true;
            this.lblDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrop.Location = new System.Drawing.Point(16, 14);
            this.lblDrop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDrop.Name = "lblDrop";
            this.lblDrop.Size = new System.Drawing.Size(277, 211);
            this.lblDrop.TabIndex = 0;
            this.lblDrop.Text = "Drag and drop a message from Outloook or a .msg file to automatically parse the d" +
    "ata.\r\n\r\nDrag any other file to manually enter the information.";
            this.lblDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropSubmit);
            this.lblDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragDropEnter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Job Number:";
            // 
            // TxtJobNumber
            // 
            this.TxtJobNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtJobNumber.Location = new System.Drawing.Point(111, 228);
            this.TxtJobNumber.Mask = "00-00-000";
            this.TxtJobNumber.Name = "TxtJobNumber";
            this.TxtJobNumber.Size = new System.Drawing.Size(182, 27);
            this.TxtJobNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purpose:";
            // 
            // TxtPurpose
            // 
            this.TxtPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPurpose.Location = new System.Drawing.Point(111, 261);
            this.TxtPurpose.Name = "TxtPurpose";
            this.TxtPurpose.Size = new System.Drawing.Size(182, 27);
            this.TxtPurpose.TabIndex = 4;
            // 
            // TxtNotes
            // 
            this.TxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNotes.Location = new System.Drawing.Point(111, 294);
            this.TxtNotes.Name = "TxtNotes";
            this.TxtNotes.Size = new System.Drawing.Size(182, 27);
            this.TxtNotes.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notes:";
            // 
            // CmdConfirm
            // 
            this.CmdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdConfirm.Location = new System.Drawing.Point(218, 416);
            this.CmdConfirm.Name = "CmdConfirm";
            this.CmdConfirm.Size = new System.Drawing.Size(75, 32);
            this.CmdConfirm.TabIndex = 7;
            this.CmdConfirm.Text = "Confirm";
            this.CmdConfirm.UseVisualStyleBackColor = true;
            this.CmdConfirm.Click += new System.EventHandler(this.AcceptInformation);
            // 
            // CmdCancel
            // 
            this.CmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmdCancel.Location = new System.Drawing.Point(12, 416);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 32);
            this.CmdCancel.TabIndex = 8;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblConfirm
            // 
            this.lblConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirm.Location = new System.Drawing.Point(12, 393);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(281, 20);
            this.lblConfirm.TabIndex = 9;
            this.lblConfirm.Text = "Is the above information correct?";
            this.lblConfirm.Visible = false;
            // 
            // TxtSender
            // 
            this.TxtSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSender.Location = new System.Drawing.Point(111, 327);
            this.TxtSender.Name = "TxtSender";
            this.TxtSender.Size = new System.Drawing.Size(182, 27);
            this.TxtSender.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Submitted:";
            // 
            // LblFile
            // 
            this.LblFile.AutoSize = true;
            this.LblFile.Location = new System.Drawing.Point(107, 357);
            this.LblFile.Name = "LblFile";
            this.LblFile.Size = new System.Drawing.Size(53, 20);
            this.LblFile.TabIndex = 12;
            this.LblFile.Text = "Files: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 460);
            this.Controls.Add(this.LblFile);
            this.Controls.Add(this.TxtSender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdConfirm);
            this.Controls.Add(this.TxtNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPurpose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtJobNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDrop);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(325, 375);
            this.Name = "Form1";
            this.Text = "Parse an E-Mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox TxtJobNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtPurpose;
        private System.Windows.Forms.TextBox TxtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CmdConfirm;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox TxtSender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblFile;
    }
}

