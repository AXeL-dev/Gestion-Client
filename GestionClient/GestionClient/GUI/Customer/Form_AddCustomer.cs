using System;
using System.IO;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_AddCustomer : Form
    {
        private Form_AddJob _form_addJob;
        private bool _photoLoaded = false;

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
                comboBox_gender.SelectedIndex = 0;
                // remplissage de la combobox 'TravailCombo'
                comboBox_job.DataSource = Database.Jobs.Table;
                comboBox_job.DisplayMember = "description";
                comboBox_job.ValueMember = "id";

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
            if (!_photoLoaded) // si l'utilisateur n'a pas encore choisi une image
            {
                if (comboBox_gender.SelectedIndex == 0) // si Homme séléctionné
                    pictureBox_photo.Image = GestionClient.Properties.Resources.homme;
                else // si nn, Femme alors
                    pictureBox_photo.Image = GestionClient.Properties.Resources.femme;
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
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                pictureBox_photo.ImageLocation = openFileDialog_main.FileName;
                _photoLoaded = true;
            }
        }

        // event. Click du boutton 'AjouterClientBtn'
        private void AjouterClientBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si le nom est vide
                if (textBox_name.Text.Length == 0)
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                    textBox_name.Focus();
                }
                // si nn si nom en double
                else if (checkDoubleClientName(textBox_name.Text))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Double);
                    //NomTextBox.Text = ""; // on vide le textbox du nom
                    textBox_name.SelectAll(); // on séléctionne le nom au cas l'utilisateur veut bien le supprimer
                    textBox_name.Focus();
                }
                // si nn si aucun travail existant
                else if (comboBox_job.Items.Count == 0)
                {
                    NouveauTravailBtn_Click(sender, e);
                }
                // si nn, c'est bon
                else
                {
                    // ajout du client
                    string dateNaissance = null;
                    if (maskedTextBox_birthDate.MaskCompleted)
                        dateNaissance = maskedTextBox_birthDate.Text;
                    Database.Customers.Table.Rows.Add(null, textBox_name.Text, comboBox_gender.Text, comboBox_job.SelectedValue, dateNaissance, maskedTextBox_phoneNumber.Text.Replace(" ", string.Empty), textBox_email.Text, DateTime.Now.ToString());
                    Database.Customers.ApplyChanges();
                    // mise à jour de la dataTable Client (pour avoir les bon ids)
                    Database.Customers.FetchTable();
                    // on récupère l'id du client
                    int clientId = getClientIdByName(textBox_name.Text);
                    // on récupère le chemin ou on va pouvoir stocker l'image
                    string imageFolderName = App.AssetsFolderPath + "\\" + clientId + "_";// +NomTextBox.Text;
                    // on crée le dossier qui contienra les pieces du client (dont l'image) s'il n'exsite pas
                    if (!Directory.Exists(App.FolderPath + "\\" + imageFolderName))
                        Directory.CreateDirectory(App.FolderPath + "\\" + imageFolderName);
                    // ajout de la photo (si choisi)
                    if (_photoLoaded)
                    {
                        // on récupère le nom de l'image
                        string imageFileName = pictureBox_photo.ImageLocation.Remove(0, pictureBox_photo.ImageLocation.LastIndexOf('\\') + 1);
                        // on copie l'image dans le répertoire de notre base de données
                        string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + "_" + imageFileName;
                        File.Copy(pictureBox_photo.ImageLocation, App.FolderPath + "\\" + destinationFileName, true);
                        // on ajoute la photo en tant que Piece ('Photo')
                        Database.Assets.Table.Rows.Add(null, clientId, destinationFileName, "Photo");
                        Database.Assets.ApplyChanges();
                        // mise à jour de la dataTable Pieces (pour avoir les bon ids, afin de pouvoir modifier la photo après)
                        Database.Assets.FetchTable();
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
                int travailItemsNbr = comboBox_job.Items.Count;
                // on ouvre la fenêtre d'ajout de travail
                _form_addJob = new Form_AddJob(false);
                _form_addJob.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
                _form_addJob.ShowDialog();
                // après fermeture
                if (comboBox_job.Items.Count > travailItemsNbr) // si un travail a été ajouté, on le séléctionne
                    comboBox_job.SelectedIndex = comboBox_job.Items.Count - 1;
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
            for (int i = 0; i < Database.Customers.Table.Rows.Count; i++)
            {
                if (Database.Customers.Table.Rows[i]["nom"].ToString() == clientName)
                    return Convert.ToInt32(Database.Customers.Table.Rows[i]["id"]);
            }

            // si on ne le trouve pas on retourne un -1
            return -1;
        }

        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleClientName(string name)
        {
            for (int i = 0; i < Database.Customers.Table.Rows.Count; i++)
            {
                if (Database.Customers.Table.Rows[i]["nom"].ToString().ToUpper() == name.ToUpper()) // ToUpper() pour gérer la casse
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
            groupBox_customer.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            label_gender.Text = LocalizedStrings.Ajouter_Client_Sexe_Label;
            label_job.Text = LocalizedStrings.Ajouter_Client_Travail_Label;
            label_birthDate.Text = LocalizedStrings.Ajouter_Client_Date_Naissance_Label;
            label_phoneNumber.Text = LocalizedStrings.Ajouter_Client_Numero_Tel_Label;
            label_email.Text = LocalizedStrings.Ajouter_Client_Email_Label;
            PhotoGroupBox.Text = LocalizedStrings.Ajouter_Client_Photo_GroupBox;
            // combobox
            comboBox_gender.Items[0] = LocalizedStrings.Sexe_Homme;
            comboBox_gender.Items[1] = LocalizedStrings.Sexe_Femme;
            // Buttons
            button_newJob.Text = LocalizedStrings.Ajouter_Client_Nouveau_Travail_Button;
            button_selectPhoto.Text = LocalizedStrings.Ajouter_Client_Ajouter_Modifier_Photo_Button;
            button_add.Text = LocalizedStrings.Ajouter_Client_Ajouter_Button;
            // openFileDialog1
            openFileDialog_main.Title = LocalizedStrings.openFileDialog_Title;
        }
    }
}
