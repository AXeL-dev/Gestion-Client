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

        #region Common
        private void SwitchLanguage()
        {
            API.AppName = API.GetString("App_Name");
            // Window Name
            this.Text = API.AppName;
            // Menu Items
            menuItem_application.Text = API.GetString("Application_Menu");
            menuItem_customer.Text = API.GetString("Client_Menu");
            menuItem_job.Text = API.GetString("Travail_Menu");
            menuItem_help.Text = API.GetString("Question_Menu");
            // > Application
            menuItem_connect.Text = API.GetString("Connexion_DB_Sub_Menu");
            menuItem_backup.Text = API.GetString("Sauvegarder_DB_Sub_Menu");
            menuItem_language.Text = API.GetString("Langue_Sub_Menu");
            menuItem_french.Text = API.GetString("Français_Sub_Menu");
            menuItem_arabic.Text = API.GetString("Arabe_Sub_Menu");
            menuItem_quit.Text = API.GetString("Quitter_Menu");
            // > Client
            menuItem_addCustomer.Text = API.GetString("Ajouter_Client_Sub_Menu");
            menuItem_editCustomer.Text = API.GetString("Modifier_Supprimer_Client_Sub_Menu");
            menuItem_customersList.Text = API.GetString("Liste_Client_Sub_Menu");
            // > Travail
            menuItem_addJob.Text = API.GetString("Ajouter_Travail_Sub_Menu");
            menuItem_removeJob.Text = API.GetString("Supprimer_Travail_Sub_Menu");
            // > ?
            menuItem_about.Text = API.GetString("A_propos_Sub_Menu");
            // InfosToolStripStatusLabel
            if (API.ConnectedToDatabase)
                statusLabel_main.Text = API.GetString("Connexion_To_DB_Success");
            else
                statusLabel_main.Text = API.GetString("Connexion_To_DB_Error");
            // saveFileDialog1
            saveFileDialog_main.Title = API.GetString("saveFileDialog_Title");
        }
        #endregion

        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                // on crée le dossier qui contiendra toutes les pieces de nos clients s'il n'exsite pas
                if (!Directory.Exists(API.AppFolderPath + "\\" + API.AppPiecesFolder))
                    Directory.CreateDirectory(API.AppFolderPath + "\\" + API.AppPiecesFolder);

                // on récupère la langue actuelle + on effectue les changements si nécessaire
                if (API.GetCurrentLanguage() == "ar")
                    menuItem_arabic_Click(sender, e);
                else
                    menuItem_french_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }

            // connexion à la bdd + récupération des tables (je ne l'ai pas mis dans la close try{}catch(){} car cette fonction/méthode utilise déjà une)
            API.FetchAllTables(statusLabel_main);
        }

        private void menuItem_quit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(API.GetString("MessageBox_Quitter"), API.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, API.CurrentMessageBoxOptions) == DialogResult.Yes)
                this.Close();
        }

        private void menuItem_addCustomer_Click(object sender, EventArgs e)
        {
            if (!API.AddCustomerFormOpened)
            {
                Form_AddCustomer fen = new Form_AddCustomer();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.AddCustomerFormOpened = true;
            }
        }

        private void menuItem_about_Click(object sender, EventArgs e)
        {
            Form fen = new Form_About();
            fen.RightToLeft = API.GetCurrentLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
            fen.Text = API.GetString("A_propos_Sub_Menu");
            fen.ShowDialog();
        }

        private void menuItem_connect_Click(object sender, EventArgs e)
        {
            API.FetchAllTables(statusLabel_main);
        }

        private void menuItem_application_DropDownOpened(object sender, EventArgs e)
        {
            // si la connexion à la base de données est établie, on désactive l'item 'Connexion..' du menu 'Application', si nn on l'active
            if (!API.ConnectedToDatabase)
                menuItem_connect.Enabled = true;
            else
                menuItem_connect.Enabled = false;
        }

        private void menuItem_addJob_Click(object sender, EventArgs e)
        {
            if (!API.AddJobFormOpened)
            {
                Form_AddJob fen = new Form_AddJob();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.AddJobFormOpened = true;
            }
        }

        private void menuItem_removeJob_Click(object sender, EventArgs e)
        {
            if (!API.RemoveJobFormOpened)
            {
                Form_RemoveJob fen = new Form_RemoveJob();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.RemoveJobFormOpened = true;
            }
        }

        private void menuItem_editJob_Click(object sender, EventArgs e)
        {
            if (!API.EditJobFormOpened)
            {
                Form_EditCustomer fen = new Form_EditCustomer();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.EditJobFormOpened = true;
            }
        }

        private void menuItem_customersList_Click(object sender, EventArgs e)
        {
            if (!API.CustomerListFormOpened)
            {
                Form_CustomersList fen = new Form_CustomersList();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.CustomerListFormOpened = true;
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
                    proc.StartInfo.Arguments = String.Format("a -r \"{0}\" \"{1}\"", saveFileDialog_main.FileName, API.AppFolderPath + "\\" + API.AppDatabaseFolder);
                    proc.Start();

                    // attente de la fin de l'extraction
                    this.Cursor = Cursors.WaitCursor;
                    proc.WaitForExit();
                    this.Cursor = Cursors.Default;

                    if (File.Exists(saveFileDialog_main.FileName))
                        MessageBox.Show(API.GetString("MessageBox_DB_Saved_To") + saveFileDialog_main.FileName, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    else
                        throw new Exception(API.GetString("MessageBox_Erreur"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
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
                    API.CurrentCulture = CultureInfo.CreateSpecificCulture("fr");
                    // enregistrement de la langue actuelle
                    API.SetCurrentLanguage("fr");
                    // messagesBox => état normal
                    API.CurrentMessageBoxOptions = new MessageBoxOptions();
                    // messageBox buttons text => état normal
                    MessageBoxManager.Unregister();
                    // main form => état normal
                    this.RightToLeft = RightToLeft.No;
                    // modification du texte des controls
                    SwitchLanguage();
                    // on informe les fenêtres enfants
                    this.OnLanguageChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
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
                    API.CurrentCulture = CultureInfo.CreateSpecificCulture("ar");
                    // enregistrement de la langue actuelle
                    API.SetCurrentLanguage("ar");
                    // messagesBox => RightToLeft
                    API.CurrentMessageBoxOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                    // messagesBox buttons text
                    MessageBoxManager.Yes = API.GetString("MessageBox_YES");
                    MessageBoxManager.No = API.GetString("MessageBox_NO");
                    MessageBoxManager.Register();
                    // main form => RightToLeft
                    this.RightToLeft = RightToLeft.Yes;
                    // modification du texte des controls
                    SwitchLanguage();
                    // on informe les fenêtres enfants
                    this.OnLanguageChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
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