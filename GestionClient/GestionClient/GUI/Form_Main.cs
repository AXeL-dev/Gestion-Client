using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GestionClient.Localization;
using GestionClient.Properties;

namespace GestionClient
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            Language.Changed += (s, args) => SwitchLanguage();
        }

        #region Common-Methods
        private void SwitchLanguage()
        {
            // Reading Direction
            this.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;

            // Form Title
            this.Text = App.Name = LocalizedStrings.App_Name;

            // Main Menu Items
            menuItem_application.Text = LocalizedStrings.Application_Menu;
            menuItem_customer.Text = LocalizedStrings.Client_Menu;
            menuItem_job.Text = LocalizedStrings.Travail_Menu;
            menuItem_help.Text = LocalizedStrings.Question_Menu;

            // Application Menu Items
            menuItem_connect.Text = LocalizedStrings.Connexion_DB_Sub_Menu;
            menuItem_backup.Text = LocalizedStrings.Sauvegarder_DB_Sub_Menu;
            menuItem_language.Text = LocalizedStrings.Langue_Sub_Menu;
            menuItem_quit.Text = LocalizedStrings.Quitter_Menu;

            // Customer Menu Items
            menuItem_addCustomer.Text = LocalizedStrings.Ajouter_Client_Sub_Menu;
            menuItem_editCustomer.Text = LocalizedStrings.Modifier_Supprimer_Client_Sub_Menu;
            menuItem_customersList.Text = LocalizedStrings.Liste_Client_Sub_Menu;

            // Job Menu Items
            menuItem_addJob.Text = LocalizedStrings.Ajouter_Travail_Sub_Menu;
            menuItem_removeJob.Text = LocalizedStrings.Supprimer_Travail_Sub_Menu;

            // Help Menu Items
            menuItem_about.Text = LocalizedStrings.A_propos_Sub_Menu;

            // Connection Status
            statusLabel_main.Text = Database.ConnectedToDatabase
                ? LocalizedStrings.Connexion_To_DB_Success
                : LocalizedStrings.Connexion_To_DB_Error;

            // Save File Dialog Title
            saveFileDialog_main.Title = LocalizedStrings.saveFileDialog_Title;
        }

        public void FillLanguageMenuItem()
        {
            menuItem_language.DropDownItems.Clear();
            foreach (KeyValuePair<string, string> languageEntry in Language.GetAvailableLanguages())
            {
                ToolStripItem newMenuItem = menuItem_language.DropDownItems.Add(languageEntry.Value);
                newMenuItem.Tag = languageEntry.Key;
                newMenuItem.Click += new EventHandler(menuItem_languageEntry_Click);
                if (languageEntry.Key == Language.GetCurrentLanguage())
                {
                    menuItem_languageEntry_Click(newMenuItem, EventArgs.Empty);
                }
            }
        }

        public void ConnectToDatabase()
        {
            try
            {
                Database.FetchAllTables();
                statusLabel_main.Text = LocalizedStrings.Connexion_To_DB_Success;
                statusLabel_main.ForeColor = Color.Green;
                statusLabel_main.Image = Resources._true;
            }
            catch (Exception exception)
            {
                statusLabel_main.Text = LocalizedStrings.Connexion_To_DB_Error;
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
                App.CreateAssetsFolder();
                FillLanguageMenuItem();
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }

            ConnectToDatabase();
        }

        #region Menu-Events-Handlers
        #region Menu/Application
        private void menuItem_application_DropDownOpened(object sender, EventArgs e)
        {
            menuItem_connect.Enabled = Database.ConnectedToDatabase ? false : true;
        }

        private void menuItem_connect_Click(object sender, EventArgs e)
        {
            ConnectToDatabase();
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
                        throw new FileNotFoundException(LocalizedStrings.MessageBox_Erreur);
                    }

                    QuickMessageBox.ShowInformation(string.Format("{0}{1}",
                            LocalizedStrings.MessageBox_DB_Saved_To, saveFileDialog_main.FileName));
                }
                catch (Exception exception)
                {
                    QuickMessageBox.ShowError(exception.Message);
                }
            }
        }

        /// <summary>
        /// Click event handler called for every generated language sub-item.
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
            }
        }

        private void menuItem_quit_Click(object sender, EventArgs e)
        {
            if (QuickMessageBox.ShowQuestion(LocalizedStrings.MessageBox_Quitter)
                == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region Menu/Customer
        private void menuItem_addCustomer_Click(object sender, EventArgs e)
        {
            if (!App.AddCustomerFormOpened)
            {
                Form_AddCustomer form_addCustomer = new Form_AddCustomer();
                form_addCustomer.MdiParent = this;
                Language.Changed += form_addCustomer.LanguageChangedHandler;
                form_addCustomer.Show();
                App.AddCustomerFormOpened = true;
            }
        }

        private void menuItem_editCustomer_Click(object sender, EventArgs e)
        {
            if (!App.EditCustomerFormOpened)
            {
                Form_EditCustomer form_editCustomer = new Form_EditCustomer();
                form_editCustomer.MdiParent = this;
                Language.Changed += form_editCustomer.LanguageChangedHandler;
                form_editCustomer.Show();
                App.EditCustomerFormOpened = true;
            }
        }

        private void menuItem_customersList_Click(object sender, EventArgs e)
        {
            if (!App.CustomerListFormOpened)
            {
                Form_CustomersList form_customersList = new Form_CustomersList();
                form_customersList.MdiParent = this;
                Language.Changed += form_customersList.LanguageChangedHandler;
                form_customersList.Show();
                App.CustomerListFormOpened = true;
            }
        }
        #endregion

        #region Menu/Job
        private void menuItem_addJob_Click(object sender, EventArgs e)
        {
            if (!App.AddJobFormOpened)
            {
                Form_AddJob form_addJob = new Form_AddJob();
                form_addJob.MdiParent = this;
                Language.Changed += form_addJob.LanguageChangedHandler;
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
                Language.Changed += form_removeJob.LanguageChangedHandler;
                form_removeJob.Show();
                App.RemoveJobFormOpened = true;
            }
        }
        #endregion

        #region Menu/Help
        private void menuItem_about_Click(object sender, EventArgs e)
        {
            Form_About form_about = new Form_About();
            form_about.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            form_about.Text = LocalizedStrings.A_propos_Sub_Menu;
            form_about.ShowDialog();
        }
        #endregion
        #endregion
    }
}