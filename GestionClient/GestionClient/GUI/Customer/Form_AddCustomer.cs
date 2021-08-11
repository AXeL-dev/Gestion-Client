using System;
using System.IO;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_AddCustomer : Form
    {
        // attributs
        private Form_AddJob _form_addJob;
        private bool isImageChoosed = false;

        // constr.
        public Form_AddCustomer()
        {
            InitializeComponent();
            Language.Changed += this.LanguageChangedHandler;
        }

        // event. Load du formulaire
        private void AjouterClient_Load(object sender, EventArgs e)
        {
            if (Database.ConnectedToDatabase) // si on est déjà connecté à la base de données
            {
                // séléction d'Homme dans la combobox
                HommeFemmeCombo.SelectedIndex = 0;
                // remplissage de la combobox 'TravailCombo'
                TravailCombo.DataSource = Database.MainDataSet.Tables["Travail"];
                TravailCombo.DisplayMember = "description";
                TravailCombo.ValueMember = "id";

                // on change la langue si l'arabe est séléctionné
                if (Language.IsRightToLeft)
                    switchLanguage();
            }
            else
            {
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Connexion_Non_Etablie);
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
            Language.Changed -= this.LanguageChangedHandler;
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
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                    NomTextBox.Focus();
                }
                // si nn si nom en double
                else if (checkDoubleClientName(NomTextBox.Text))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Double);
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
                    Database.MainDataSet.Tables["Client"].Rows.Add(null, NomTextBox.Text, HommeFemmeCombo.Text, TravailCombo.SelectedValue, dateNaissance, NumTelMaskedTextBox.Text.Replace(" ", string.Empty), EmailTextBox.Text, DateTime.Now.ToString());
                    Database.ApplyChanges(Database.ClientDataAdapter, "Client");
                    // mise à jour de la dataTable Client (pour avoir les bon ids)
                    Database.FetchClientTable();
                    // on récupère l'id du client
                    int clientId = getClientIdByName(NomTextBox.Text);
                    // on récupère le chemin ou on va pouvoir stocker l'image
                    string imageFolderName = App.AssetsFolderPath + "\\" + clientId + "_";// +NomTextBox.Text;
                    // on crée le dossier qui contienra les pieces du client (dont l'image) s'il n'exsite pas
                    if (!Directory.Exists(App.FolderPath + "\\" + imageFolderName))
                        Directory.CreateDirectory(App.FolderPath + "\\" + imageFolderName);
                    // ajout de la photo (si choisi)
                    if (isImageChoosed)
                    {
                        // on récupère le nom de l'image
                        string imageFileName = pictureBox1.ImageLocation.Remove(0, pictureBox1.ImageLocation.LastIndexOf('\\') + 1);
                        // on copie l'image dans le répertoire de notre base de données
                        string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + "_" + imageFileName;
                        File.Copy(pictureBox1.ImageLocation, App.FolderPath + "\\" + destinationFileName, true);
                        // on ajoute la photo en tant que Piece ('Photo')
                        Database.MainDataSet.Tables["Pieces"].Rows.Add(null, clientId, destinationFileName, "Photo");
                        Database.ApplyChanges(Database.PiecesDataAdapter, "Pieces");
                        // mise à jour de la dataTable Pieces (pour avoir les bon ids, afin de pouvoir modifier la photo après)
                        Database.FetchPiecesTable();
                    }
                    QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Client_Ajouté);
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. Click du boutton 'NouveauTravailBtn'
        private void NouveauTravailBtn_Click(object sender, EventArgs e)
        {
            // on ouvre l'interface de création de travail
            if (_form_addJob == null || _form_addJob.IsDisposed)
            {
                // on sauvegarde le nombre d'item actuel dans la 'TravailCombo'
                int travailItemsNbr = TravailCombo.Items.Count;
                // on ouvre la fenêtre d'ajout de travail
                _form_addJob = new Form_AddJob(false);
                _form_addJob.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
                _form_addJob.ShowDialog();
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
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // méthodes
        // getClientIdByName(...) : récupère l'id du client en recherchant son nom
        private int getClientIdByName(string clientName)
        {
            // on parcourt la dataTable Client
            for (int i = 0; i < Database.MainDataSet.Tables["Client"].Rows.Count; i++)
            {
                if (Database.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString() == clientName)
                    return Convert.ToInt32(Database.MainDataSet.Tables["Client"].Rows[i]["id"]);
            }

            // si on ne le trouve pas on retourne un -1
            return -1;
        }

        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleClientName(string name)
        {
            for (int i = 0; i < Database.MainDataSet.Tables["Client"].Rows.Count; i++)
            {
                if (Database.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString().ToUpper() == name.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = LocalizedStrings.Ajouter_Client_Win_Name;
            // Labels et GroupBoxs
            ClientGroupBox.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            NomLabel.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            SexeLabel.Text = LocalizedStrings.Ajouter_Client_Sexe_Label;
            TravailLabel.Text = LocalizedStrings.Ajouter_Client_Travail_Label;
            DateNaissanceLabel.Text = LocalizedStrings.Ajouter_Client_Date_Naissance_Label;
            NumeroTelLabel.Text = LocalizedStrings.Ajouter_Client_Numero_Tel_Label;
            EmailLabel.Text = LocalizedStrings.Ajouter_Client_Email_Label;
            PhotoGroupBox.Text = LocalizedStrings.Ajouter_Client_Photo_GroupBox;
            // combobox
            HommeFemmeCombo.Items[0] = LocalizedStrings.Sexe_Homme;
            HommeFemmeCombo.Items[1] = LocalizedStrings.Sexe_Femme;
            // Buttons
            NouveauTravailBtn.Text = LocalizedStrings.Ajouter_Client_Nouveau_Travail_Button;
            AjouterModifierPhotoBtn.Text = LocalizedStrings.Ajouter_Client_Ajouter_Modifier_Photo_Button;
            AjouterClientBtn.Text = LocalizedStrings.Ajouter_Client_Ajouter_Button;
            // openFileDialog1
            openFileDialog1.Title = LocalizedStrings.openFileDialog_Title;
        }
    }
}
