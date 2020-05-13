namespace Email_Parser
{
    partial class ChangeJobNumber
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.CmdAccept = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the new job number:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Location = new System.Drawing.Point(12, 33);
            this.maskedTextBox1.Mask = "00-00-000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(241, 29);
            this.maskedTextBox1.TabIndex = 1;
            // 
            // CmdAccept
            // 
            this.CmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdAccept.Location = new System.Drawing.Point(153, 68);
            this.CmdAccept.Name = "CmdAccept";
            this.CmdAccept.Size = new System.Drawing.Size(100, 40);
            this.CmdAccept.TabIndex = 2;
            this.CmdAccept.Text = "Accept";
            this.CmdAccept.UseVisualStyleBackColor = true;
            this.CmdAccept.Click += new System.EventHandler(this.OnAccept);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdCancel.Location = new System.Drawing.Point(12, 68);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(100, 40);
            this.CmdCancel.TabIndex = 3;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // ChangeJobNumber
            // 
            this.AcceptButton = this.CmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.CmdCancel;
            this.ClientSize = new System.Drawing.Size(267, 122);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdAccept);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChangeJobNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeJobNumber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button CmdAccept;
        private System.Windows.Forms.Button CmdCancel;
    }
}