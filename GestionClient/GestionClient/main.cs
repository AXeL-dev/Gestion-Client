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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

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
            if (MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Quitter", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, ClassGlobal.msgBoxOptions) == DialogResult.Yes)
                this.Close();
        }

        // event. Click on 'Ajouter' in 'Client' of MenuStrip1
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClassGlobal.isAjouterClientOpened)
            {
                AjouterClient fen = new AjouterClient();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                ClassGlobal.isAjouterClientOpened = true;
            }
        }

        // event. Click on 'A propos' in '?' of MenuStrip1
        private void àProposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fen = new About();
            fen.RightToLeft = ClassGlobal.getDefaultLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
            fen.Text = ClassGlobal.resManager.GetString("A_propos_Sub_Menu", ClassGlobal.cul);
            fen.ShowDialog();
        }

        // event. Load du formulaire
        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                // on crée le dossier qui contiendra toutes les pieces de nos clients s'il n'exsite pas
                if (!Directory.Exists(ClassGlobal.AppPath + "\\" + ClassGlobal.PiecesSaveFolder))
                    Directory.CreateDirectory(ClassGlobal.AppPath + "\\" + ClassGlobal.PiecesSaveFolder);

                // on récupère la langue actuelle + on effectue les changements si nécessaire
                if (ClassGlobal.getDefaultLanguage() == "ar")
                    arabeToolStripMenuItem_Click(sender, e);
                else
                    françaisToolStripMenuItem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
            }

            // connexion à la bdd + récupération des tables (je ne l'ai pas mis dans la close try{}catch(){} car cette fonction/méthode utilise déjà une)
            ClassGlobal.getAllTables(InfosToolStripStatusLabel);
        }

        // event. Click on 'Connexion à la base de données' in 'Application' of MenuStrip1
        private void connexionÀLaBaseDeDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassGlobal.getAllTables(InfosToolStripStatusLabel);
        }

        // event. DropDownOpened on 'Application' of MenuStrip1
        private void applicationToolStripMenuItem2_DropDownOpened(object sender, EventArgs e)
        {
            // si la connexion à la base de données est établie, on désactive l'item 'Connexion..' du menu 'Application', si nn on l'active
            if (!ClassGlobal.isConnectedToDb)
                connexionÀLaBaseDeDonnéesToolStripMenuItem.Enabled = true;
            else
                connexionÀLaBaseDeDonnéesToolStripMenuItem.Enabled = false;
        }

        // event. Click on 'Ajouter' in 'Travail' of MenuStrip1
        private void ajouterToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (!ClassGlobal.isAjouterTravailOpened)
            {
                AjouterTravail fen = new AjouterTravail();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                ClassGlobal.isAjouterTravailOpened = true;
            }
        }

        // event. Click on 'Supprimer' in 'Travail' of MenuStrip1
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClassGlobal.isSupprimerTravailOpened)
            {
                SupprimerTravail fen = new SupprimerTravail();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                ClassGlobal.isSupprimerTravailOpened = true;
            }
        }

        // event. Click on 'Modifier' in 'Client' of MenuStrip1
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClassGlobal.isModifierTavailOpened)
            {
                ModifierClient fen = new ModifierClient();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                ClassGlobal.isModifierTavailOpened = true;
            }
        }

        // event. Click on 'Liste' in 'Client' of MenuStrip1
        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ClassGlobal.isListeClientsOpened)
            {
                ListeClients fen = new ListeClients();
                fen.MdiParent = this;
                this.LanguageChanged += fen.LanguageChangedHandler;
                fen.Show();
                ClassGlobal.isListeClientsOpened = true;
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
                    proc.StartInfo.Arguments = String.Format("a -r \"{0}\" \"{1}\"", saveFileDialog1.FileName, ClassGlobal.AppPath + "\\" + ClassGlobal.AppDbFolder);
                    proc.Start();

                    // attente de la fin de l'extraction
                    this.Cursor = Cursors.WaitCursor;
                    proc.WaitForExit();
                    this.Cursor = Cursors.Default;

                    if (File.Exists(saveFileDialog1.FileName))
                        MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_DB_Saved_To", ClassGlobal.cul) + saveFileDialog1.FileName, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    else
                        throw new Exception(ClassGlobal.resManager.GetString("MessageBox_Erreur", ClassGlobal.cul));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
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
                    ClassGlobal.cul = CultureInfo.CreateSpecificCulture("fr");
                    // enregistrement de la langue actuelle
                    ClassGlobal.setDefaultLanguage("fr");
                    // messagesBox => état normal
                    ClassGlobal.msgBoxOptions = new MessageBoxOptions();
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
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
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
                    ClassGlobal.cul = CultureInfo.CreateSpecificCulture("ar");
                    // enregistrement de la langue actuelle
                    ClassGlobal.setDefaultLanguage("ar");
                    // messagesBox => RightToLeft
                    ClassGlobal.msgBoxOptions = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
                    // messagesBox buttons text
                    MessageBoxManager.Yes = ClassGlobal.resManager.GetString("MessageBox_YES", ClassGlobal.cul);
                    MessageBoxManager.No = ClassGlobal.resManager.GetString("MessageBox_NO", ClassGlobal.cul);
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
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
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
            ClassGlobal.AppName = ClassGlobal.resManager.GetString("App_Name", ClassGlobal.cul);
            // Window Name
            this.Text = ClassGlobal.AppName;
            // Menu Items
            applicationToolStripMenuItem2.Text = ClassGlobal.resManager.GetString("Application_Menu", ClassGlobal.cul);
            clientToolStripMenuItem2.Text = ClassGlobal.resManager.GetString("Client_Menu", ClassGlobal.cul);
            travailToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Travail_Menu", ClassGlobal.cul);
            toolStripMenuItem3.Text = ClassGlobal.resManager.GetString("Question_Menu", ClassGlobal.cul);
            // > Application
            connexionÀLaBaseDeDonnéesToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Connexion_DB_Sub_Menu", ClassGlobal.cul);
            sauvegarderLaBaseDeDonnéesToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Sauvegarder_DB_Sub_Menu", ClassGlobal.cul);
            langueToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Langue_Sub_Menu", ClassGlobal.cul);
            françaisToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Français_Sub_Menu", ClassGlobal.cul);
            arabeToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Arabe_Sub_Menu", ClassGlobal.cul);
            quitterToolStripMenuItem4.Text = ClassGlobal.resManager.GetString("Quitter_Menu", ClassGlobal.cul);
            // > Client
            ajouterToolStripMenuItem3.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Sub_Menu", ClassGlobal.cul);
            modifierToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Modifier_Supprimer_Client_Sub_Menu", ClassGlobal.cul);
            listeToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Liste_Client_Sub_Menu", ClassGlobal.cul);
            // > Travail
            ajouterToolStripMenuItem4.Text = ClassGlobal.resManager.GetString("Ajouter_Travail_Sub_Menu", ClassGlobal.cul);
            supprimerToolStripMenuItem.Text = ClassGlobal.resManager.GetString("Supprimer_Travail_Sub_Menu", ClassGlobal.cul);
            // > ?
            àProposToolStripMenuItem1.Text = ClassGlobal.resManager.GetString("A_propos_Sub_Menu", ClassGlobal.cul);
            // InfosToolStripStatusLabel
            if (ClassGlobal.isConnectedToDb)
                InfosToolStripStatusLabel.Text = ClassGlobal.resManager.GetString("Connexion_To_DB_Success", ClassGlobal.cul);
            else
                InfosToolStripStatusLabel.Text = ClassGlobal.resManager.GetString("Connexion_To_DB_Error", ClassGlobal.cul);
            // saveFileDialog1
            saveFileDialog1.Title = ClassGlobal.resManager.GetString("saveFileDialog_Title", ClassGlobal.cul);
        }
    }
}
