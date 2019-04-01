namespace MessagePublisher.Client.Forms
{
    partial class NotificationForm
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
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkConfirmation = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(519, 114);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(115, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Ok";
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(86, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(548, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // checkConfirmation
            // 
            this.checkConfirmation.AutoSize = true;
            this.checkConfirmation.Location = new System.Drawing.Point(86, 118);
            this.checkConfirmation.Name = "checkConfirmation";
            this.checkConfirmation.Size = new System.Drawing.Size(84, 17);
            this.checkConfirmation.TabIndex = 2;
            this.checkConfirmation.Text = "Confirmation";
            this.checkConfirmation.UseVisualStyleBackColor = true;
            this.checkConfirmation.CheckedChanged += new System.EventHandler(this.checkConfirmation_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 96);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 149);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkConfirmation);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnConfirm);
            this.Name = "NotificationForm";
            this.Text = "NotificationForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkConfirmation;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}