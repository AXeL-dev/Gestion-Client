/*
* 
* Projet : Gestion Client / إدارة العملاء/العمال/الزبناء...
* 
* Version : 1.0
* 
* Date/Période de création : From : 28/10/2015, To : 05/11/2015
*
* Auteur : AXeL
* 
* A savoir :
*            - La suppression se fait en cascade, ex : si je supprime un travail à qui j'ai assigné des clients, ces clients seront alors aussi supprimés (pour ceux qui se demanderont pq, la réponse est simple, car la table Client contient l'id du travail, plus simplement, effacer un travail => effacer l'id du travail => effacer le client).
*
*/


using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class main : Form
    {
        // attributs
        public event EventHandler LanguageChanged;

        // constr.
        public main()
        {
            InitializeComponent();
        }

        // event. Click on 'Quitter' in 'Application' of MenuStrip1
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Quitter", API.CurrentCulture), API.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, API.CurrentMessageBoxOptions) == DialogResult.Yes)
                this.Close();
        }

        // event. Click on 'Ajouter' in 'Client' of MenuStrip1
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.AjouterClientFormOpened)
            {
                AjouterClient fen = new AjouterClient();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.AjouterClientFormOpened = true;
            }
        }

        // event. Click on 'A propos' in '?' of MenuStrip1
        private void àProposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fen = new About();
            fen.RightToLeft = API.GetCurrentLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
            fen.Text = API.LanguagesResourceManager.GetString("A_propos_Sub_Menu", API.CurrentCulture);
            fen.ShowDialog();
        }

        // event. Load du formulaire
        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                // on crée le dossier qui contiendra toutes les pieces de nos clients s'il n'exsite pas
                if (!Directory.Exists(API.AppFolderPath + "\\" + API.AppPiecesFolder))
                    Directory.CreateDirectory(API.AppFolderPath + "\\" + API.AppPiecesFolder);

                // on récupère la langue actuelle + on effectue les changements si nécessaire
                if (API.GetCurrentLanguage() == "ar")
                    arabeToolStripMenuItem_Click(sender, e);
                else
                    françaisToolStripMenuItem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }

            // connexion à la bdd + récupération des tables (je ne l'ai pas mis dans la close try{}catch(){} car cette fonction/méthode utilise déjà une)
            API.FetchAllTables(InfosToolStripStatusLabel);
        }

        // event. Click on 'Connexion à la base de données' in 'Application' of MenuStrip1
        private void connexionÀLaBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            API.FetchAllTables(InfosToolStripStatusLabel);
        }

        // event. DropDownOpened on 'Application' of MenuStrip1
        private void applicationToolStripMenuItem2_DropDownOpened(object sender, EventArgs e)
        {
            // si la connexion à la base de données est établie, on désactive l'item 'Connexion..' du menu 'Application', si nn on l'active
            if (!API.ConnectedToDatabase)
                connexionÀLaBaseDeDonnéesToolStripMenuItem.Enabled = true;
            else
                connexionÀLaBaseDeDonnéesToolStripMenuItem.Enabled = false;
        }

        // event. Click on 'Ajouter' in 'Travail' of MenuStrip1
        private void ajouterToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!API.AjouterTravailFormOpened)
            {
                AjouterTravail fen = new AjouterTravail();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.AjouterTravailFormOpened = true;
            }
        }

        // event. Click on 'Supprimer' in 'Travail' of MenuStrip1
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.SupprimerTravailFormOpened)
            {
                SupprimerTravail fen = new SupprimerTravail();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.SupprimerTravailFormOpened = true;
            }
        }

        // event. Click on 'Modifier' in 'Client' of MenuStrip1
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.ModifierTavailFormOpened)
            {
                ModifierClient fen = new ModifierClient();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.ModifierTavailFormOpened = true;
            }
        }

        // event. Click on 'Liste' in 'Client' of MenuStrip1
        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.ListeClientsFormOpened)
            {
                ListeClients fen = new ListeClients();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.ListeClientsFormOpened = true;
            }
        }

        // event. Click on 'Créer une sauvegarde de la base de données' in 'Application' of MenuStrip1
        private void sauvegarderLaBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Sauvegarde_" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_");

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
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
                    proc.StartInfo.Arguments = String.Format("a -r \"{0}\" \"{1}\"", saveFileDialog1.FileName, API.AppFolderPath + "\\" + API.AppDatabaseFolder);
                    proc.Start();

                    // attente de la fin de l'extraction
                    this.Cursor = Cursors.WaitCursor;
                    proc.WaitForExit();
                    this.Cursor = Cursors.Default;

                    if (File.Exists(saveFileDialog1.FileName))
                        MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_DB_Saved_To", API.CurrentCulture) + saveFileDialog1.FileName, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    else
                        throw new Exception(API.LanguagesResourceManager.GetString("MessageBox_Erreur", API.CurrentCulture));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                }
            }
        }

        // event. Click sur le boutton 'françaisToolStripMenuItem'
        private void françaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (françaisToolStripMenuItem.Checked == false)
                {
                    françaisToolStripMenuItem.Checked = true;
                    arabeToolStripMenuItem.Checked = false;
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
                    switchLanguage();
                    // on informe les fenêtres enfants
                    this.OnLanguageChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // event. Click sur le boutton 'arabeToolStripMenuItem'
        private void arabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (arabeToolStripMenuItem.Checked == false)
                {
                    françaisToolStripMenuItem.Checked = false;
                    arabeToolStripMenuItem.Checked = true;
                    // changement de la langue à l'arabe
                    API.CurrentCulture = CultureInfo.CreateSpecificCulture("ar");
                    // enregistrement de la langue actuelle
                    API.SetCurrentLanguage("ar");
                    // messagesBox => RightToLeft
                    API.CurrentMessageBoxOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                    // messagesBox buttons text
                    MessageBoxManager.Yes = API.LanguagesResourceManager.GetString("MessageBox_YES", API.CurrentCulture);
                    MessageBoxManager.No = API.LanguagesResourceManager.GetString("MessageBox_NO", API.CurrentCulture);
                    MessageBoxManager.Register();
                    // main form => RightToLeft
                    this.RightToLeft = RightToLeft.Yes;
                    // modification du texte des controls
                    switchLanguage();
                    // on informe les fenêtres enfants
                    this.OnLanguageChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // event. OnLanguageChanged du formulaire parent
        public void OnLanguageChanged(object sender, EventArgs e)
        {
            if (LanguageChanged != null) // i.e. there are some subscribers, s'il y'a des enfants souscris à l'evennement de la fen. parent
            {
                LanguageChanged(sender, e); // notify all subscribers, on les informent que l'even. à été déclenché ;))
            }
        }

        // Méthodes
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // App Name
            API.AppName = API.LanguagesResourceManager.GetString("App_Name", API.CurrentCulture);
            // Window Name
            this.Text = API.AppName;
            // Menu Items
            applicationToolStripMenuItem2.Text = API.LanguagesResourceManager.GetString("Application_Menu", API.CurrentCulture);
            clientToolStripMenuItem2.Text = API.LanguagesResourceManager.GetString("Client_Menu", API.CurrentCulture);
            travailToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Travail_Menu", API.CurrentCulture);
            toolStripMenuItem3.Text = API.LanguagesResourceManager.GetString("Question_Menu", API.CurrentCulture);
            // > Application
            connexionÀLaBaseDeDonnéesToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Connexion_DB_Sub_Menu", API.CurrentCulture);
            sauvegarderLaBaseDeDonnéesToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Sauvegarder_DB_Sub_Menu", API.CurrentCulture);
            langueToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Langue_Sub_Menu", API.CurrentCulture);
            françaisToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Français_Sub_Menu", API.CurrentCulture);
            arabeToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Arabe_Sub_Menu", API.CurrentCulture);
            quitterToolStripMenuItem4.Text = API.LanguagesResourceManager.GetString("Quitter_Menu", API.CurrentCulture);
            // > Client
            ajouterToolStripMenuItem3.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Sub_Menu", API.CurrentCulture);
            modifierToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Modifier_Supprimer_Client_Sub_Menu", API.CurrentCulture);
            listeToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Liste_Client_Sub_Menu", API.CurrentCulture);
            // > Travail
            ajouterToolStripMenuItem4.Text = API.LanguagesResourceManager.GetString("Ajouter_Travail_Sub_Menu", API.CurrentCulture);
            supprimerToolStripMenuItem.Text = API.LanguagesResourceManager.GetString("Supprimer_Travail_Sub_Menu", API.CurrentCulture);
            // > ?
            àProposToolStripMenuItem1.Text = API.LanguagesResourceManager.GetString("A_propos_Sub_Menu", API.CurrentCulture);
            // InfosToolStripStatusLabel
            if (API.ConnectedToDatabase)
                InfosToolStripStatusLabel.Text = API.LanguagesResourceManager.GetString("Connexion_To_DB_Success", API.CurrentCulture);
            else
                InfosToolStripStatusLabel.Text = API.LanguagesResourceManager.GetString("Connexion_To_DB_Error", API.CurrentCulture);
            // saveFileDialog1
            saveFileDialog1.Title = API.LanguagesResourceManager.GetString("saveFileDialog_Title", API.CurrentCulture);
        }
    }
}
