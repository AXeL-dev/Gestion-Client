namespace GestionClient
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AppNameGroupBox = new System.Windows.Forms.GroupBox();
            this.AppInfosTextBox = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.AppNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(131, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AppNameGroupBox
            // 
            this.AppNameGroupBox.Controls.Add(this.AppInfosTextBox);
            this.AppNameGroupBox.Controls.Add(this.pictureBox1);
            this.AppNameGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppNameGroupBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AppNameGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AppNameGroupBox.Name = "AppNameGroupBox";
            this.AppNameGroupBox.Size = new System.Drawing.Size(350, 268);
            this.AppNameGroupBox.TabIndex = 1;
            this.AppNameGroupBox.TabStop = false;
            this.AppNameGroupBox.Text = "AppName";
            // 
            // AppInfosTextBox
            // 
            this.AppInfosTextBox.BackColor = System.Drawing.Color.White;
            this.AppInfosTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppInfosTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.AppInfosTextBox.Location = new System.Drawing.Point(15, 141);
            this.AppInfosTextBox.Multiline = true;
            this.AppInfosTextBox.Name = "AppInfosTextBox";
            this.AppInfosTextBox.ReadOnly = true;
            this.AppInfosTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AppInfosTextBox.Size = new System.Drawing.Size(320, 112);
            this.AppInfosTextBox.TabIndex = 1;
            // 
            // OkBtn
            // 
            this.OkBtn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.Location = new System.Drawing.Point(143, 292);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(96, 28);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 332);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.AppNameGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "À propos";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.AppNameGroupBox.ResumeLayout(false);
            this.AppNameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox AppNameGroupBox;
        private System.Windows.Forms.TextBox AppInfosTextBox;
        private System.Windows.Forms.Button OkBtn;
    }
}