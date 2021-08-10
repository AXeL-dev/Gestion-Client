namespace GestionClient
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.menuItem_application = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_connect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_language = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_customer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_addCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_editCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_customersList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_job = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_addJob = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_removeJob = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_about = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip_main = new System.Windows.Forms.StatusStrip();
            this.statusLabel_main = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog_main = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip_main.SuspendLayout();
            this.statusStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_application,
            this.menuItem_customer,
            this.menuItem_job,
            this.menuItem_help});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Size = new System.Drawing.Size(969, 24);
            this.menuStrip_main.TabIndex = 1;
            // 
            // menuItem_application
            // 
            this.menuItem_application.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_connect,
            this.menuItem_backup,
            this.menuItem_language,
            this.toolStripSeparator1,
            this.menuItem_quit});
            this.menuItem_application.Name = "menuItem_application";
            this.menuItem_application.Size = new System.Drawing.Size(80, 20);
            this.menuItem_application.Text = "&Application";
            this.menuItem_application.DropDownOpened += new System.EventHandler(this.menuItem_application_DropDownOpened);
            // 
            // menuItem_connect
            // 
            this.menuItem_connect.Image = global::GestionClient.Properties.Resources._true;
            this.menuItem_connect.Name = "menuItem_connect";
            this.menuItem_connect.Size = new System.Drawing.Size(218, 22);
            this.menuItem_connect.Text = "Connection to database";
            this.menuItem_connect.Click += new System.EventHandler(this.menuItem_connect_Click);
            // 
            // menuItem_backup
            // 
            this.menuItem_backup.Image = global::GestionClient.Properties.Resources.save;
            this.menuItem_backup.Name = "menuItem_backup";
            this.menuItem_backup.Size = new System.Drawing.Size(218, 22);
            this.menuItem_backup.Text = "Create a database backup...";
            this.menuItem_backup.Click += new System.EventHandler(this.menuItem_backup_Click);
            // 
            // menuItem_language
            // 
            this.menuItem_language.Image = global::GestionClient.Properties.Resources.language;
            this.menuItem_language.Name = "menuItem_language";
            this.menuItem_language.Size = new System.Drawing.Size(218, 22);
            this.menuItem_language.Text = "Language";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // menuItem_quit
            // 
            this.menuItem_quit.Image = global::GestionClient.Properties.Resources.exit;
            this.menuItem_quit.Name = "menuItem_quit";
            this.menuItem_quit.Size = new System.Drawing.Size(218, 22);
            this.menuItem_quit.Text = "Quit";
            this.menuItem_quit.Click += new System.EventHandler(this.menuItem_quit_Click);
            // 
            // menuItem_customer
            // 
            this.menuItem_customer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_addCustomer,
            this.menuItem_editCustomer,
            this.menuItem_customersList});
            this.menuItem_customer.Name = "menuItem_customer";
            this.menuItem_customer.Size = new System.Drawing.Size(71, 20);
            this.menuItem_customer.Text = "&Customer";
            // 
            // menuItem_addCustomer
            // 
            this.menuItem_addCustomer.Image = global::GestionClient.Properties.Resources.person_add;
            this.menuItem_addCustomer.Name = "menuItem_addCustomer";
            this.menuItem_addCustomer.Size = new System.Drawing.Size(151, 22);
            this.menuItem_addCustomer.Text = "Add...";
            this.menuItem_addCustomer.Click += new System.EventHandler(this.menuItem_addCustomer_Click);
            // 
            // menuItem_editCustomer
            // 
            this.menuItem_editCustomer.Image = global::GestionClient.Properties.Resources.edit;
            this.menuItem_editCustomer.Name = "menuItem_editCustomer";
            this.menuItem_editCustomer.Size = new System.Drawing.Size(151, 22);
            this.menuItem_editCustomer.Text = "Edit/Remove...";
            this.menuItem_editCustomer.Click += new System.EventHandler(this.menuItem_editCustomer_Click);
            // 
            // menuItem_customersList
            // 
            this.menuItem_customersList.Image = global::GestionClient.Properties.Resources.document_file;
            this.menuItem_customersList.Name = "menuItem_customersList";
            this.menuItem_customersList.Size = new System.Drawing.Size(151, 22);
            this.menuItem_customersList.Text = "List";
            this.menuItem_customersList.Click += new System.EventHandler(this.menuItem_customersList_Click);
            // 
            // menuItem_job
            // 
            this.menuItem_job.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_addJob,
            this.menuItem_removeJob});
            this.menuItem_job.Name = "menuItem_job";
            this.menuItem_job.Size = new System.Drawing.Size(37, 20);
            this.menuItem_job.Text = "&Job";
            // 
            // menuItem_addJob
            // 
            this.menuItem_addJob.Image = global::GestionClient.Properties.Resources.tag;
            this.menuItem_addJob.Name = "menuItem_addJob";
            this.menuItem_addJob.Size = new System.Drawing.Size(126, 22);
            this.menuItem_addJob.Text = "Add...";
            this.menuItem_addJob.Click += new System.EventHandler(this.menuItem_addJob_Click);
            // 
            // menuItem_removeJob
            // 
            this.menuItem_removeJob.Image = global::GestionClient.Properties.Resources.close_delete;
            this.menuItem_removeJob.Name = "menuItem_removeJob";
            this.menuItem_removeJob.Size = new System.Drawing.Size(126, 22);
            this.menuItem_removeJob.Text = "Remove...";
            this.menuItem_removeJob.Click += new System.EventHandler(this.menuItem_removeJob_Click);
            // 
            // menuItem_help
            // 
            this.menuItem_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_about});
            this.menuItem_help.Name = "menuItem_help";
            this.menuItem_help.Size = new System.Drawing.Size(24, 20);
            this.menuItem_help.Text = "?";
            // 
            // menuItem_about
            // 
            this.menuItem_about.Image = global::GestionClient.Properties.Resources.information;
            this.menuItem_about.Name = "menuItem_about";
            this.menuItem_about.Size = new System.Drawing.Size(107, 22);
            this.menuItem_about.Text = "About";
            this.menuItem_about.Click += new System.EventHandler(this.menuItem_about_Click);
            // 
            // statusStrip_main
            // 
            this.statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_main});
            this.statusStrip_main.Location = new System.Drawing.Point(0, 522);
            this.statusStrip_main.Name = "statusStrip_main";
            this.statusStrip_main.ShowItemToolTips = true;
            this.statusStrip_main.Size = new System.Drawing.Size(969, 22);
            this.statusStrip_main.TabIndex = 3;
            this.statusStrip_main.Text = "statusStrip1";
            // 
            // statusLabel_main
            // 
            this.statusLabel_main.Name = "statusLabel_main";
            this.statusLabel_main.Size = new System.Drawing.Size(53, 17);
            this.statusLabel_main.Text = "{ Status }";
            // 
            // saveFileDialog_main
            // 
            this.saveFileDialog_main.DefaultExt = "zip";
            this.saveFileDialog_main.Filter = "Zip Files|*.zip|Rar Files|*.rar";
            this.saveFileDialog_main.Title = "Choix de l\'emplacement de sauvegarde";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 544);
            this.Controls.Add(this.statusStrip_main);
            this.Controls.Add(this.menuStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "Form_Main";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Management";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.statusStrip_main.ResumeLayout(false);
            this.statusStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem menuItem_application;
        private System.Windows.Forms.ToolStripMenuItem menuItem_quit;
        private System.Windows.Forms.ToolStripMenuItem menuItem_customer;
        private System.Windows.Forms.ToolStripMenuItem menuItem_addCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuItem_customersList;
        private System.Windows.Forms.ToolStripMenuItem menuItem_help;
        private System.Windows.Forms.ToolStripMenuItem menuItem_about;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_main;
        private System.Windows.Forms.ToolStripMenuItem menuItem_connect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_job;
        private System.Windows.Forms.ToolStripMenuItem menuItem_addJob;
        private System.Windows.Forms.ToolStripMenuItem menuItem_removeJob;
        private System.Windows.Forms.ToolStripMenuItem menuItem_editCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuItem_backup;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_main;
        private System.Windows.Forms.ToolStripMenuItem menuItem_language;
    }
}

