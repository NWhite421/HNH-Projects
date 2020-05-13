namespace Email_Parser
{
    partial class FileExists
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
            this.CmdOverwrite = new System.Windows.Forms.Button();
            this.CmdAppend = new System.Windows.Forms.Button();
            this.CmdSkip = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TxtMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmdOverwrite
            // 
            this.CmdOverwrite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdOverwrite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CmdOverwrite.Location = new System.Drawing.Point(12, 198);
            this.CmdOverwrite.Name = "CmdOverwrite";
            this.CmdOverwrite.Size = new System.Drawing.Size(314, 59);
            this.CmdOverwrite.TabIndex = 1;
            this.CmdOverwrite.Text = "OVERWRITE FILE";
            this.CmdOverwrite.UseVisualStyleBackColor = true;
            this.CmdOverwrite.Click += new System.EventHandler(this.OverwriteFile);
            // 
            // CmdAppend
            // 
            this.CmdAppend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAppend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CmdAppend.Location = new System.Drawing.Point(12, 263);
            this.CmdAppend.Name = "CmdAppend";
            this.CmdAppend.Size = new System.Drawing.Size(314, 59);
            this.CmdAppend.TabIndex = 2;
            this.CmdAppend.Text = "APPEND FILE";
            this.CmdAppend.UseVisualStyleBackColor = true;
            this.CmdAppend.Click += new System.EventHandler(this.AppendFile);
            // 
            // CmdSkip
            // 
            this.CmdSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdSkip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.CmdSkip.Location = new System.Drawing.Point(12, 328);
            this.CmdSkip.Name = "CmdSkip";
            this.CmdSkip.Size = new System.Drawing.Size(314, 59);
            this.CmdSkip.TabIndex = 3;
            this.CmdSkip.Text = "SKIP FILE";
            this.CmdSkip.UseVisualStyleBackColor = true;
            this.CmdSkip.Click += new System.EventHandler(this.SkipFile);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 393);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 25);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Apply to all files.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(12, 9);
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(314, 186);
            this.TxtMessage.TabIndex = 5;
            this.TxtMessage.Text = "label1";
            // 
            // FileExists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 429);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CmdSkip);
            this.Controls.Add(this.CmdAppend);
            this.Controls.Add(this.CmdOverwrite);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileExists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Already Exists";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CmdOverwrite;
        private System.Windows.Forms.Button CmdAppend;
        private System.Windows.Forms.Button CmdSkip;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label TxtMessage;
    }
}