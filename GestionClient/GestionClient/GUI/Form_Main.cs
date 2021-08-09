using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

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
        #endregion

        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                App.CreatePiecesFolder();

                // on récupère la langue actuelle + on effectue les changements si nécessaire
                if (Language.IsArabic)
                {
                    menuItem_arabic_Click(sender, e);
                }
                else
                {
                    menuItem_french_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }

            // connexion à la bdd + récupération des tables (je ne l'ai pas mis dans 
            // la close try{}catch(){} car cette fonction/méthode utilise déjà une)
            Database.FetchAllTables(statusLabel_main);
        }

        private void menuItem_quit_Click(object sender, EventArgs e)
        {
            if (QuickMessageBox.ShowQuestion(Language.GetString("MessageBox_Quitter")) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void menuItem_addCustomer_Click(object sender, EventArgs e)
        {
            if (!App.AddCustomerFormOpened)
            {
                Form_AddCustomer fen = new Form_AddCustomer();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                App.AddCustomerFormOpened = true;
            }
        }

        private void menuItem_about_Click(object sender, EventArgs e)
        {
            Form_About form_about = new Form_About();
            form_about.RightToLeft = Language.IsArabic ? RightToLeft.Yes : RightToLeft.No;
            form_about.Text = Language.GetString("A_propos_Sub_Menu");
            form_about.ShowDialog();
        }

        private void menuItem_connect_Click(object sender, EventArgs e)
        {
            Database.FetchAllTables(statusLabel_main);
        }

        private void menuItem_application_DropDownOpened(object sender, EventArgs e)
        {
            // si la connexion à la base de données est établie, on désactive l'item 'Connexion..' du menu 'Application', si nn on l'active
            if (!Database.ConnectedToDatabase)
                menuItem_connect.Enabled = true;
            else
                menuItem_connect.Enabled = false;
        }

        private void menuItem_addJob_Click(object sender, EventArgs e)
        {
            if (!App.AddJobFormOpened)
            {
                Form_AddJob fen = new Form_AddJob();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                App.AddJobFormOpened = true;
            }
        }

        private void menuItem_removeJob_Click(object sender, EventArgs e)
        {
            if (!App.RemoveJobFormOpened)
            {
                Form_RemoveJob fen = new Form_RemoveJob();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                App.RemoveJobFormOpened = true;
            }
        }

        private void menuItem_editJob_Click(object sender, EventArgs e)
        {
            if (!App.EditJobFormOpened)
            {
                Form_EditCustomer fen = new Form_EditCustomer();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                App.EditJobFormOpened = true;
            }
        }

        private void menuItem_customersList_Click(object sender, EventArgs e)
        {
            if (!App.CustomerListFormOpened)
            {
                Form_CustomersList fen = new Form_CustomersList();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                App.CustomerListFormOpened = true;
            }
        }

        private void menuItem_backup_Click(object sender, EventArgs e)
        {
            saveFileDialog_main.FileName = "Sauvegarde_" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_");

            if (saveFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Process proc = new Process();
                    // chemin du programme winrar.exe
                    proc.StartInfo.FileName = @"C:\Program Files\WinRAR\rar.exe"; // ou unrar.exe pour extraire
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.EnableRaisingEvents = true;

                    //PWD: Password if the file has any
                    //SRC: The path of your rar file. e.g: c:\temp\abc.rar
                    //DES: The path you want it to be extracted. e.g: d:\extracted
                    //ATTENTION: DESTINATION FOLDER MUST EXIST!

                    // lancement de l'extraction
                    //proc.StartInfo.Arguments = String.Format("x -p{0} {1} {2}", PWD, SRC, DES);
                    proc.StartInfo.Arguments = String.Format("a -r \"{0}\" \"{1}\"", saveFileDialog_main.FileName, App.FolderPath + "\\" + App.DatabaseFolderName);
                    proc.Start();

                    // attente de la fin de l'extraction
                    this.Cursor = Cursors.WaitCursor;
                    proc.WaitForExit();
                    this.Cursor = Cursors.Default;

                    if (File.Exists(saveFileDialog_main.FileName))
                    {
                        QuickMessageBox.ShowInformation(string.Format("{0}{1}",
                            Language.GetString("MessageBox_DB_Saved_To"), saveFileDialog_main.FileName));
                    }
                    else
                    {
                        throw new Exception(Language.GetString("MessageBox_Erreur"));
                    }
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
                if (menuItem_french.Checked == false)
                {
                    menuItem_french.Checked = true;
                    menuItem_arabic.Checked = false;
                    // changement de la langue au français
                    Language.CurrentCulture = CultureInfo.CreateSpecificCulture("fr");
                    // enregistrement de la langue actuelle
                    Language.SetCurrentLanguage("fr");
                    // messagesBox => état normal
                    Language.CurrentMessageBoxOptions = new MessageBoxOptions();
                    // QuickMessageBox buttons text => état normal
                    MessageBoxManager.Unregister();
                    // main form => état normal
                    this.RightToLeft = RightToLeft.No;
                    // modification du texte des controls
                    SwitchLanguage();
                    // on informe les fenêtres enfants
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
                if (menuItem_arabic.Checked == false)
                {
                    menuItem_french.Checked = false;
                    menuItem_arabic.Checked = true;
                    // changement de la langue à l'arabe
                    Language.CurrentCulture = CultureInfo.CreateSpecificCulture("ar");
                    // enregistrement de la langue actuelle
                    Language.SetCurrentLanguage("ar");
                    // messagesBox => RightToLeft
                    Language.CurrentMessageBoxOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                    // messagesBox buttons text
                    MessageBoxManager.Yes = Language.GetString("MessageBox_YES");
                    MessageBoxManager.No = Language.GetString("MessageBox_NO");
                    MessageBoxManager.Register();
                    // main form => RightToLeft
                    this.RightToLeft = RightToLeft.Yes;
                    // modification du texte des controls
                    SwitchLanguage();
                    // on informe les fenêtres enfants
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