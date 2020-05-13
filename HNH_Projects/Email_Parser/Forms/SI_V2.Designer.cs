namespace Email_Parser
{
    partial class SI_V2
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
            this.LblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LbJobNumbers = new System.Windows.Forms.ListBox();
            this.LbFiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFieldCrew = new System.Windows.Forms.TextBox();
            this.TxtPurpose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmdAccept = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdDelete = new System.Windows.Forms.Button();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(226, 9);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(115, 21);
            this.LblDate.TabIndex = 0;
            this.LblDate.Text = "Date: XX/XX/XX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Job Number(s):";
            // 
            // LbJobNumbers
            // 
            this.LbJobNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbJobNumbers.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.LbJobNumbers.FormattingEnabled = true;
            this.LbJobNumbers.ItemHeight = 25;
            this.LbJobNumbers.Location = new System.Drawing.Point(12, 41);
            this.LbJobNumbers.Name = "LbJobNumbers";
            this.LbJobNumbers.Size = new System.Drawing.Size(329, 102);
            this.LbJobNumbers.TabIndex = 4;
            this.LbJobNumbers.Click += new System.EventHandler(this.OnLbJobNumberClk);
            this.LbJobNumbers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnLbJobNumberDblClk);
            // 
            // LbFiles
            // 
            this.LbFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbFiles.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.LbFiles.FormattingEnabled = true;
            this.LbFiles.ItemHeight = 25;
            this.LbFiles.Location = new System.Drawing.Point(12, 181);
            this.LbFiles.Name = "LbFiles";
            this.LbFiles.Size = new System.Drawing.Size(329, 102);
            this.LbFiles.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Files:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Submitted By:";
            // 
            // TxtFieldCrew
            // 
            this.TxtFieldCrew.Location = new System.Drawing.Point(121, 289);
            this.TxtFieldCrew.Name = "TxtFieldCrew";
            this.TxtFieldCrew.Size = new System.Drawing.Size(220, 29);
            this.TxtFieldCrew.TabIndex = 8;
            // 
            // TxtPurpose
            // 
            this.TxtPurpose.Location = new System.Drawing.Point(121, 324);
            this.TxtPurpose.Name = "TxtPurpose";
            this.TxtPurpose.Size = new System.Drawing.Size(220, 29);
            this.TxtPurpose.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Purpose:";
            // 
            // CmdAccept
            // 
            this.CmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAccept.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAccept.Location = new System.Drawing.Point(12, 403);
            this.CmdAccept.Name = "CmdAccept";
            this.CmdAccept.Size = new System.Drawing.Size(329, 64);
            this.CmdAccept.TabIndex = 11;
            this.CmdAccept.Text = "ACCEPT FILES";
            this.CmdAccept.UseVisualStyleBackColor = true;
            this.CmdAccept.Click += new System.EventHandler(this.OnAcceptFiles);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancel.Location = new System.Drawing.Point(12, 473);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(329, 64);
            this.CmdCancel.TabIndex = 12;
            this.CmdCancel.Text = "CANCEL";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // CmdDelete
            // 
            this.CmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdDelete.Location = new System.Drawing.Point(266, 149);
            this.CmdDelete.Name = "CmdDelete";
            this.CmdDelete.Size = new System.Drawing.Size(75, 29);
            this.CmdDelete.TabIndex = 13;
            this.CmdDelete.Text = "Delete";
            this.CmdDelete.UseVisualStyleBackColor = true;
            this.CmdDelete.Visible = false;
            this.CmdDelete.Click += new System.EventHandler(this.DeleteIndex);
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(121, 359);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(220, 29);
            this.TxtAddress.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Address:";
            // 
            // SI_V2
            // 
            this.AcceptButton = this.CmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdCancel;
            this.ClientSize = new System.Drawing.Size(353, 549);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmdDelete);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdAccept);
            this.Controls.Add(this.TxtPurpose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtFieldCrew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LbFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LbJobNumbers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblDate);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SI_V2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SI_V2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LbJobNumbers;
        private System.Windows.Forms.ListBox LbFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFieldCrew;
        private System.Windows.Forms.TextBox TxtPurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CmdAccept;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdDelete;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.Label label5;
    }
}