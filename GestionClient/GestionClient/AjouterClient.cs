using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GestionClient
{
    public partial class AjouterClient : Form
    {
        // attributs
        private bool isImageChoosed = false;

        // constr.
        public AjouterClient()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void AjouterClient_Load(object sender, EventArgs e)
        {
            if (ClassGlobal.isConnectedToDb) // si on est déjà connecté à la base de données
            {
                // séléction d'Homme dans la combobox
                HommeFemmeCombo.SelectedIndex = 0;
                // remplissage de la combobox 'TravailCombo'
                TravailCombo.DataSource = ClassGlobal.ds.Tables["Travail"];
                TravailCombo.DisplayMember = "description";
                TravailCombo.ValueMember = "id";

                // on change la langue si l'arabe est séléctionné
                if (ClassGlobal.getDefaultLanguage() == "ar")
                    switchLanguage();
            }
            else
            {
                MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Connexion_Non_Etablie", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. SelectedIndexChanged de la combobox 'HommeFemmeCombo'
        private void HommeFemmeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isImageChoosed) // si l'utilisateur n'a pas encore choisi une image
            {
                if (HommeFemmeCombo.SelectedIndex == 0) // si Homme séléctionné
                    pictureBox1.Image = GestionClient.Properties.Resources.homme;
                else // si nn, Femme alors
                    pictureBox1.Image = GestionClient.Properties.Resources.femme;
            }
        }

        // event. FormClosed du formulaire
        private void AjouterClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassGlobal.isAjouterClientOpened = false;
            main parent = (main) this.MdiParent;
            parent.LanguageChanged -= this.LanguageChangedHandler;
        }

        // event. Click du boutton 'AjouterModifierPhotoBtn'
        private void AjouterModifierPhotoBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                isImageChoosed = true;
            }
        }

        // event. Click du boutton 'AjouterClientBtn'
        private void AjouterClientBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si le nom est vide
                if (NomTextBox.Text.Length == 0)
                {
                    MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Nom_Obligatoire", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    NomTextBox.Focus();
                }
                // si nn si nom en double
                else if (checkDoubleClientName(NomTextBox.Text))
                {
                    MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Nom_Double", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    //NomTextBox.Text = ""; // on vide le textbox du nom
                    NomTextBox.SelectAll(); // on séléctionne le nom au cas l'utilisateur veut bien le supprimer
                    NomTextBox.Focus();
                }
                // si nn si aucun travail existant
                else if (TravailCombo.Items.Count == 0)
                {
                    NouveauTravailBtn_Click(sender, e);
                }
                // si nn, c'est bon
                else
                {
                    // ajout du client
                    string dateNaissance = null;
                    if (DateNaissMaskedTextBox.MaskCompleted)
                        dateNaissance = DateNaissMaskedTextBox.Text;
                    ClassGlobal.ds.Tables["Client"].Rows.Add(null, NomTextBox.Text, HommeFemmeCombo.Text, TravailCombo.SelectedValue, dateNaissance, NumTelMaskedTextBox.Text.Replace(" ", string.Empty), EmailTextBox.Text, DateTime.Now.ToString());
                    ClassGlobal.appliquerChangement(ClassGlobal.daClient, "Client");
                    // mise à jour de la dataTable Client (pour avoir les bon ids)
                    ClassGlobal.getClient();
                    // on récupère l'id du client
                    int clientId = getClientIdByName(NomTextBox.Text);
                    // on récupère le chemin ou on va pouvoir stocker l'image
                    string imageFolderName = ClassGlobal.PiecesSaveFolder + "\\" + clientId + "_";// +NomTextBox.Text;
                    // on crée le dossier qui contienra les pieces du client (dont l'image) s'il n'exsite pas
                    if (!Directory.Exists(ClassGlobal.AppPath + "\\" + imageFolderName))
                        Directory.CreateDirectory(ClassGlobal.AppPath + "\\" + imageFolderName);
                    // ajout de la photo (si choisi)
                    if (isImageChoosed)
                    {
                        // on récupère le nom de l'image
                        string imageFileName =  pictureBox1.ImageLocation.Remove(0, pictureBox1.ImageLocation.LastIndexOf('\\') + 1);
                        // on copie l'image dans le répertoire de notre base de données
                        string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_") + "_" + imageFileName;
                        File.Copy(pictureBox1.ImageLocation, ClassGlobal.AppPath + "\\" + destinationFileName, true);
                        // on ajoute la photo en tant que Piece ('Photo')
                        ClassGlobal.ds.Tables["Pieces"].Rows.Add(null, clientId, destinationFileName, "Photo");
                        ClassGlobal.appliquerChangement(ClassGlobal.daPieces, "Pieces");
                        // mise à jour de la dataTable Pieces (pour avoir les bon ids, afin de pouvoir modifier la photo après)
                        ClassGlobal.getPieces();
                    }
                    MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Client_Ajouté", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
            }
        }

        // event. Click du boutton 'NouveauTravailBtn'
        private void NouveauTravailBtn_Click(object sender, EventArgs e)
        {
            // on ouvre l'interface de création de travail
            if (!ClassGlobal.isAjouterTravailOpened)
            {
                // on sauvegarde le nombre d'item actuel dans la 'TravailCombo'
                int travailItemsNbr = TravailCombo.Items.Count;
                // on ouvre la fenêtre d'ajout de travail
                ClassGlobal.isAjouterTravailOpened = true;
                Form fen = new AjouterTravail(false);
                fen.RightToLeft = ClassGlobal.getDefaultLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
                fen.ShowDialog();
                // après fermeture
                if (TravailCombo.Items.Count > travailItemsNbr) // si un travail a été ajouté, on le séléctionne
                    TravailCombo.SelectedIndex = TravailCombo.Items.Count - 1;
            }
        }

        // event. LanguageChanged du formulaire (enfant)
        public void LanguageChangedHandler(object sender, EventArgs e)
        {
            try
            {
                switchLanguage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
            }
        }

        // méthodes
        // getClientIdByName(...) : récupère l'id du client en recherchant son nom
        private int getClientIdByName(string clientName)
        {
            // on parcourt la dataTable Client
            for (int i = 0; i < ClassGlobal.ds.Tables["Client"].Rows.Count; i++)
            {
                if (ClassGlobal.ds.Tables["Client"].Rows[i]["nom"].ToString() == clientName)
                    return Convert.ToInt32(ClassGlobal.ds.Tables["Client"].Rows[i]["id"]);
            }

            // si on ne le trouve pas on retourne un -1
            return -1;
        }

        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleClientName(string name)
        {
            for (int i = 0; i < ClassGlobal.ds.Tables["Client"].Rows.Count; i++)
            {
                if (ClassGlobal.ds.Tables["Client"].Rows[i]["nom"].ToString().ToUpper() == name.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Win_Name", ClassGlobal.cul);
            // Labels et GroupBoxs
            ClientGroupBox.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Client_GroupBox", ClassGlobal.cul);
            NomLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Nom_Label", ClassGlobal.cul);
            SexeLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Sexe_Label", ClassGlobal.cul);
            TravailLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Travail_Label", ClassGlobal.cul);
            DateNaissanceLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Date_Naissance_Label", ClassGlobal.cul);
            NumeroTelLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Numero_Tel_Label", ClassGlobal.cul);
            EmailLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Email_Label", ClassGlobal.cul);
            PhotoGroupBox.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Photo_GroupBox", ClassGlobal.cul);
            // combobox
            HommeFemmeCombo.Items[0] = ClassGlobal.resManager.GetString("Sexe_Homme", ClassGlobal.cul);
            HommeFemmeCombo.Items[1] = ClassGlobal.resManager.GetString("Sexe_Femme", ClassGlobal.cul);
            // Buttons
            NouveauTravailBtn.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Nouveau_Travail_Button", ClassGlobal.cul);
            AjouterModifierPhotoBtn.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Ajouter_Modifier_Photo_Button", ClassGlobal.cul);
            AjouterClientBtn.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Ajouter_Button", ClassGlobal.cul);
            // openFileDialog1
            openFileDialog1.Title = ClassGlobal.resManager.GetString("openFileDialog_Title", ClassGlobal.cul);
        }
    }
}
