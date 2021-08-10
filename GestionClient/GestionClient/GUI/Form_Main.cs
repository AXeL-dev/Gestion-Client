using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using GestionClient.Properties;
using System.Collections.Generic;

namespace GestionClient
{
    public partial class Form_Main : Form
    {
        public event EventHandler LanguageChanged;

        public Form_Main()
        {
            InitializeComponent();
        }

        #region Common-Methods
        private void SwitchLanguage()
        {
            // Form Title
            this.Text = App.Name = Language.GetString("App_Name");

            // Main Menu Items
            menuItem_application.Text = Language.GetString("Application_Menu");
            menuItem_customer.Text = Language.GetString("Client_Menu");
            menuItem_job.Text = Language.GetString("Travail_Menu");
            menuItem_help.Text = Language.GetString("Question_Menu");

            // Application Menu Items
            menuItem_connect.Text = Language.GetString("Connexion_DB_Sub_Menu");
            menuItem_backup.Text = Language.GetString("Sauvegarder_DB_Sub_Menu");
            menuItem_language.Text = Language.GetString("Langue_Sub_Menu");
            menuItem_french.Text = Language.GetString("Français_Sub_Menu");
            menuItem_arabic.Text = Language.GetString("Arabe_Sub_Menu");
            menuItem_quit.Text = Language.GetString("Quitter_Menu");

            // Customer Menu Items
            menuItem_addCustomer.Text = Language.GetString("Ajouter_Client_Sub_Menu");
            menuItem_editCustomer.Text = Language.GetString("Modifier_Supprimer_Client_Sub_Menu");
            menuItem_customersList.Text = Language.GetString("Liste_Client_Sub_Menu");

            // Job Menu Items
            menuItem_addJob.Text = Language.GetString("Ajouter_Travail_Sub_Menu");
            menuItem_removeJob.Text = Language.GetString("Supprimer_Travail_Sub_Menu");

            // Help Menu Items
            menuItem_about.Text = Language.GetString("A_propos_Sub_Menu");

            // Connection Status
            statusLabel_main.Text = Database.ConnectedToDatabase
                ? Language.GetString("Connexion_To_DB_Success")
                : Language.GetString("Connexion_To_DB_Error");

            // Save File Dialog Title
            saveFileDialog_main.Title = Language.GetString("saveFileDialog_Title");
        }

        public void ConnectToDatabase()
        {
            try
            {
                Database.FetchAllTables();
                statusLabel_main.Text = Language.GetString("Connexion_To_DB_Success");
                statusLabel_main.ForeColor = Color.Green;
                statusLabel_main.Image = Resources._true;
            }
            catch (Exception exception)
            {
                statusLabel_main.Text = Language.GetString("Connexion_To_DB_Error");
                statusLabel_main.ToolTipText = exception.Message;
                statusLabel_main.ForeColor = Color.Red;
                statusLabel_main.Image = Resources._false;
            }
        }
        #endregion

        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                App.CreatePiecesFolder();

                menuItem_language.DropDownItems.Clear();
                foreach (KeyValuePair<string, string> languageEntry in Language.GetAvailableLanguages())
                {
                    ToolStripItem menuItem = menuItem_language.DropDownItems.Add(languageEntry.Value);
                    menuItem.Tag = languageEntry.Key;
                    menuItem.Click += new EventHandler(menuItem_languageEntry_Click);
                    if (languageEntry.Key == Language.GetCurrentLanguage())
                    {
                        menuItem_languageEntry_Click(menuItem, EventArgs.Empty);
                    }
                }

                //if (Language.IsRightToLeft)
                //{
                //    menuItem_arabic_Click(sender, e);
                //}
                //else
                //{
                //    menuItem_french_Click(sender, e);
                //}
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }

            ConnectToDatabase();
        }

        /// <summary>
        /// General handler for every generated language sub-menu-item of the language menu-item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_languageEntry_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            string language = menuItem.Tag as string;
            if (!menuItem.Checked)
            {
                foreach (ToolStripMenuItem item in menuItem_language.DropDownItems)
                {
                    item.Checked = false;
                }
                menuItem.Checked = true;
                Language.SetCurrentLanguage(language);
                this.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
                SwitchLanguage();
                this.OnLanguageChanged(sender, e);
            }
        }

        private void menuItem_quit_Click(object sender, EventArgs e)
        {
            if (QuickMessageBox.ShowQuestion(Language.GetString("MessageBox_Quitter"))
                == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void menuItem_addCustomer_Click(object sender, EventArgs e)
        {
            if (!App.AddCustomerFormOpened)
            {
                Form_AddCustomer form_addCustomer = new Form_AddCustomer();
                form_addCustomer.MdiParent = this;
                this.LanguageChanged += form_addCustomer.LanguageChangedHandler;
                form_addCustomer.Show();
                App.AddCustomerFormOpened = true;
            }
        }

        private void menuItem_about_Click(object sender, EventArgs e)
        {
            Form_About form_about = new Form_About();
            form_about.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            form_about.Text = Language.GetString("A_propos_Sub_Menu");
            form_about.ShowDialog();
        }

        private void menuItem_connect_Click(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }

        private void menuItem_application_DropDownOpened(object sender, EventArgs e)
        {
            menuItem_connect.Enabled = Database.ConnectedToDatabase ? false : true;
        }

        private void menuItem_addJob_Click(object sender, EventArgs e)
        {
            if (!App.AddJobFormOpened)
            {
                Form_AddJob form_addJob = new Form_AddJob();
                form_addJob.MdiParent = this;
                this.LanguageChanged += form_addJob.LanguageChangedHandler;
                form_addJob.Show();
                App.AddJobFormOpened = true;
            }
        }

        private void menuItem_removeJob_Click(object sender, EventArgs e)
        {
            if (!App.RemoveJobFormOpened)
            {
                Form_RemoveJob form_removeJob = new Form_RemoveJob();
                form_removeJob.MdiParent = this;
                this.LanguageChanged += form_removeJob.LanguageChangedHandler;
                form_removeJob.Show();
                App.RemoveJobFormOpened = true;
            }
        }

        private void menuItem_editJob_Click(object sender, EventArgs e)
        {
            if (!App.EditJobFormOpened)
            {
                Form_EditCustomer form_editCustomer = new Form_EditCustomer();
                form_editCustomer.MdiParent = this;
                this.LanguageChanged += form_editCustomer.LanguageChangedHandler;
                form_editCustomer.Show();
                App.EditJobFormOpened = true;
            }
        }

        private void menuItem_customersList_Click(object sender, EventArgs e)
        {
            if (!App.CustomerListFormOpened)
            {
                Form_CustomersList form_customersList = new Form_CustomersList();
                form_customersList.MdiParent = this;
                this.LanguageChanged += form_customersList.LanguageChangedHandler;
                form_customersList.Show();
                App.CustomerListFormOpened = true;
            }
        }

        private void menuItem_backup_Click(object sender, EventArgs e)
        {
            saveFileDialog_main.FileName = string.Format("Backup_{0}",
                DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"));

            if (saveFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (WinRar winrar = new WinRar())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        winrar.Compress(saveFileDialog_main.FileName, App.DatabaseFolderName);
                        this.Cursor = Cursors.Default;
                    }

                    if (!File.Exists(saveFileDialog_main.FileName))
                    {
                        throw new FileNotFoundException(Language.GetString("MessageBox_Erreur"));
                    }

                    QuickMessageBox.ShowInformation(string.Format("{0}{1}",
                            Language.GetString("MessageBox_DB_Saved_To"), saveFileDialog_main.FileName));
                }
                catch (Exception exception)
                {
                    QuickMessageBox.ShowError(exception.Message);
                }
            }
        }

        private void menuItem_french_Click(object sender, EventArgs e)
        {
            try
            {
                if (!menuItem_french.Checked)
                {
                    menuItem_french.Checked = true;
                    menuItem_arabic.Checked = false;
                    Language.SetCurrentLanguage("fr");
                    this.RightToLeft = RightToLeft.No;
                    SwitchLanguage();
                    this.OnLanguageChanged(sender, e);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void menuItem_arabic_Click(object sender, EventArgs e)
        {
            try
            {
                if (!menuItem_arabic.Checked)
                {
                    menuItem_french.Checked = false;
                    menuItem_arabic.Checked = true;
                    Language.SetCurrentLanguage("ar");
                    this.RightToLeft = RightToLeft.Yes;
                    SwitchLanguage();
                    this.OnLanguageChanged(sender, e);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            if (LanguageChanged != null) // i.e. there are some subscribers, s'il y'a des enfants souscris à l'evennement de la fen. parent
            {
                LanguageChanged(sender, e); // notify all subscribers, on les informent que l'even. à été déclenché ;))
            }
        }
    }
}