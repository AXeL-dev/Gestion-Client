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
            if (MessageBox.Show(API.resManager.GetString("MessageBox_Quitter", API.cul), API.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, API.msgBoxOptions) == DialogResult.Yes)
                this.Close();
        }

        // event. Click on 'Ajouter' in 'Client' of MenuStrip1
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.isAjouterClientOpened)
            {
                AjouterClient fen = new AjouterClient();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.isAjouterClientOpened = true;
            }
        }

        // event. Click on 'A propos' in '?' of MenuStrip1
        private void àProposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fen = new About();
            fen.RightToLeft = API.getDefaultLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
            fen.Text = API.resManager.GetString("A_propos_Sub_Menu", API.cul);
            fen.ShowDialog();
        }

        // event. Load du formulaire
        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                // on crée le dossier qui contiendra toutes les pieces de nos clients s'il n'exsite pas
                if (!Directory.Exists(API.AppPath + "\\" + API.PiecesSaveFolder))
                    Directory.CreateDirectory(API.AppPath + "\\" + API.PiecesSaveFolder);

                // on récupère la langue actuelle + on effectue les changements si nécessaire
                if (API.getDefaultLanguage() == "ar")
                    arabeToolStripMenuItem_Click(sender, e);
                else
                    françaisToolStripMenuItem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
            }

            // connexion à la bdd + récupération des tables (je ne l'ai pas mis dans la close try{}catch(){} car cette fonction/méthode utilise déjà une)
            API.getAllTables(InfosToolStripStatusLabel);
        }

        // event. Click on 'Connexion à la base de données' in 'Application' of MenuStrip1
        private void connexionÀLaBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            API.getAllTables(InfosToolStripStatusLabel);
        }

        // event. DropDownOpened on 'Application' of MenuStrip1
        private void applicationToolStripMenuItem2_DropDownOpened(object sender, EventArgs e)
        {
            // si la connexion à la base de données est établie, on désactive l'item 'Connexion..' du menu 'Application', si nn on l'active
            if (!API.isConnectedToDb)
                connexionÀLaBaseDeDonnéesToolStripMenuItem.Enabled = true;
            else
                connexionÀLaBaseDeDonnéesToolStripMenuItem.Enabled = false;
        }

        // event. Click on 'Ajouter' in 'Travail' of MenuStrip1
        private void ajouterToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!API.isAjouterTravailOpened)
            {
                AjouterTravail fen = new AjouterTravail();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.isAjouterTravailOpened = true;
            }
        }

        // event. Click on 'Supprimer' in 'Travail' of MenuStrip1
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.isSupprimerTravailOpened)
            {
                SupprimerTravail fen = new SupprimerTravail();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.isSupprimerTravailOpened = true;
            }
        }

        // event. Click on 'Modifier' in 'Client' of MenuStrip1
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.isModifierTavailOpened)
            {
                ModifierClient fen = new ModifierClient();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.isModifierTavailOpened = true;
            }
        }

        // event. Click on 'Liste' in 'Client' of MenuStrip1
        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!API.isListeClientsOpened)
            {
                ListeClients fen = new ListeClients();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                API.isListeClientsOpened = true;
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
                    proc.StartInfo.Arguments = String.Format("a -r \"{0}\" \"{1}\"", saveFileDialog1.FileName, API.AppPath + "\\" + API.AppDbFolder);
                    proc.Start();

                    // attente de la fin de l'extraction
                    this.Cursor = Cursors.WaitCursor;
                    proc.WaitForExit();
                    this.Cursor = Cursors.Default;

                    if (File.Exists(saveFileDialog1.FileName))
                        MessageBox.Show(API.resManager.GetString("MessageBox_DB_Saved_To", API.cul) + saveFileDialog1.FileName, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
                    else
                        throw new Exception(API.resManager.GetString("MessageBox_Erreur", API.cul));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
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
                    API.cul = CultureInfo.CreateSpecificCulture("fr");
                    // enregistrement de la langue actuelle
                    API.setDefaultLanguage("fr");
                    // messagesBox => état normal
                    API.msgBoxOptions = new MessageBoxOptions();
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
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
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
                    API.cul = CultureInfo.CreateSpecificCulture("ar");
                    // enregistrement de la langue actuelle
                    API.setDefaultLanguage("ar");
                    // messagesBox => RightToLeft
                    API.msgBoxOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                    // messagesBox buttons text
                    MessageBoxManager.Yes = API.resManager.GetString("MessageBox_YES", API.cul);
                    MessageBoxManager.No = API.resManager.GetString("MessageBox_NO", API.cul);
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
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
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
            API.AppName = API.resManager.GetString("App_Name", API.cul);
            // Window Name
            this.Text = API.AppName;
            // Menu Items
            applicationToolStripMenuItem2.Text = API.resManager.GetString("Application_Menu", API.cul);
            clientToolStripMenuItem2.Text = API.resManager.GetString("Client_Menu", API.cul);
            travailToolStripMenuItem.Text = API.resManager.GetString("Travail_Menu", API.cul);
            toolStripMenuItem3.Text = API.resManager.GetString("Question_Menu", API.cul);
            // > Application
            connexionÀLaBaseDeDonnéesToolStripMenuItem.Text = API.resManager.GetString("Connexion_DB_Sub_Menu", API.cul);
            sauvegarderLaBaseDeDonnéesToolStripMenuItem.Text = API.resManager.GetString("Sauvegarder_DB_Sub_Menu", API.cul);
            langueToolStripMenuItem.Text = API.resManager.GetString("Langue_Sub_Menu", API.cul);
            françaisToolStripMenuItem.Text = API.resManager.GetString("Français_Sub_Menu", API.cul);
            arabeToolStripMenuItem.Text = API.resManager.GetString("Arabe_Sub_Menu", API.cul);
            quitterToolStripMenuItem4.Text = API.resManager.GetString("Quitter_Menu", API.cul);
            // > Client
            ajouterToolStripMenuItem3.Text = API.resManager.GetString("Ajouter_Client_Sub_Menu", API.cul);
            modifierToolStripMenuItem.Text = API.resManager.GetString("Modifier_Supprimer_Client_Sub_Menu", API.cul);
            listeToolStripMenuItem.Text = API.resManager.GetString("Liste_Client_Sub_Menu", API.cul);
            // > Travail
            ajouterToolStripMenuItem4.Text = API.resManager.GetString("Ajouter_Travail_Sub_Menu", API.cul);
            supprimerToolStripMenuItem.Text = API.resManager.GetString("Supprimer_Travail_Sub_Menu", API.cul);
            // > ?
            àProposToolStripMenuItem1.Text = API.resManager.GetString("A_propos_Sub_Menu", API.cul);
            // InfosToolStripStatusLabel
            if (API.isConnectedToDb)
                InfosToolStripStatusLabel.Text = API.resManager.GetString("Connexion_To_DB_Success", API.cul);
            else
                InfosToolStripStatusLabel.Text = API.resManager.GetString("Connexion_To_DB_Error", API.cul);
            // saveFileDialog1
            saveFileDialog1.Title = API.resManager.GetString("saveFileDialog_Title", API.cul);
        }
    }
}
