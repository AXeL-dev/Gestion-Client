namespace GestionClient
{
    partial class Form_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.groupBox_name = new System.Windows.Forms.GroupBox();
            this.textBox_infos = new System.Windows.Forms.TextBox();
            this.button_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.groupBox_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(131, 28);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(96, 96);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // groupBox_name
            // 
            this.groupBox_name.Controls.Add(this.textBox_infos);
            this.groupBox_name.Controls.Add(this.pictureBox_logo);
            this.groupBox_name.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox_name.Location = new System.Drawing.Point(12, 12);
            this.groupBox_name.Name = "groupBox_name";
            this.groupBox_name.Size = new System.Drawing.Size(350, 268);
            this.groupBox_name.TabIndex = 1;
            this.groupBox_name.TabStop = false;
            this.groupBox_name.Text = "AppName";
            // 
            // textBox_infos
            // 
            this.textBox_infos.BackColor = System.Drawing.Color.White;
            this.textBox_infos.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_infos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_infos.Location = new System.Drawing.Point(15, 141);
            this.textBox_infos.Multiline = true;
            this.textBox_infos.Name = "textBox_infos";
            this.textBox_infos.ReadOnly = true;
            this.textBox_infos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_infos.Size = new System.Drawing.Size(320, 112);
            this.textBox_infos.TabIndex = 1;
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ok.Location = new System.Drawing.Point(143, 292);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(96, 28);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "Ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 332);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.groupBox_name.ResumeLayout(false);
            this.groupBox_name.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.GroupBox groupBox_name;
        private System.Windows.Forms.TextBox textBox_infos;
        private System.Windows.Forms.Button button_ok;
    }
}