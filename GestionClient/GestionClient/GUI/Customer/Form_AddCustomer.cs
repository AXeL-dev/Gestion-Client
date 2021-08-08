using System;
using System.IO;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class Form_AddCustomer : Form
    {
        // attributs
        private bool isImageChoosed = false;

        // constr.
        public Form_AddCustomer()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void AjouterClient_Load(object sender, EventArgs e)
        {
            if (API.ConnectedToDatabase) // si on est déjà connecté à la base de données
            {
                // séléction d'Homme dans la combobox
                HommeFemmeCombo.SelectedIndex = 0;
                // remplissage de la combobox 'TravailCombo'
                TravailCombo.DataSource = API.MainDataSet.Tables["Travail"];
                TravailCombo.DisplayMember = "description";
                TravailCombo.ValueMember = "id";

                // on change la langue si l'arabe est séléctionné
                if (API.GetCurrentLanguage() == "ar")
                    switchLanguage();
            }
            else
            {
                MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Connexion_Non_Etablie", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
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
            API.AddCustomerFormOpened = false;
            Form_Main parent = (Form_Main) this.MdiParent;
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
                    MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Nom_Obligatoire", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    NomTextBox.Focus();
                }
                // si nn si nom en double
                else if (checkDoubleClientName(NomTextBox.Text))
                {
                    MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Nom_Double", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
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
                    API.MainDataSet.Tables["Client"].Rows.Add(null, NomTextBox.Text, HommeFemmeCombo.Text, TravailCombo.SelectedValue, dateNaissance, NumTelMaskedTextBox.Text.Replace(" ", string.Empty), EmailTextBox.Text, DateTime.Now.ToString());
                    API.ApplyChanges(API.ClientDataAdapter, "Client");
                    // mise à jour de la dataTable Client (pour avoir les bon ids)
                    API.FetchClientTable();
                    // on récupère l'id du client
                    int clientId = getClientIdByName(NomTextBox.Text);
                    // on récupère le chemin ou on va pouvoir stocker l'image
                    string imageFolderName = API.AppPiecesFolder + "\\" + clientId + "_";// +NomTextBox.Text;
                    // on crée le dossier qui contienra les pieces du client (dont l'image) s'il n'exsite pas
                    if (!Directory.Exists(API.AppFolderPath + "\\" + imageFolderName))
                        Directory.CreateDirectory(API.AppFolderPath + "\\" + imageFolderName);
                    // ajout de la photo (si choisi)
                    if (isImageChoosed)
                    {
                        // on récupère le nom de l'image
                        string imageFileName =  pictureBox1.ImageLocation.Remove(0, pictureBox1.ImageLocation.LastIndexOf('\\') + 1);
                        // on copie l'image dans le répertoire de notre base de données
                        string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_") + "_" + imageFileName;
                        File.Copy(pictureBox1.ImageLocation, API.AppFolderPath + "\\" + destinationFileName, true);
                        // on ajoute la photo en tant que Piece ('Photo')
                        API.MainDataSet.Tables["Pieces"].Rows.Add(null, clientId, destinationFileName, "Photo");
                        API.ApplyChanges(API.PiecesDataAdapter, "Pieces");
                        // mise à jour de la dataTable Pieces (pour avoir les bon ids, afin de pouvoir modifier la photo après)
                        API.FetchPiecesTable();
                    }
                    MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Client_Ajouté", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // event. Click du boutton 'NouveauTravailBtn'
        private void NouveauTravailBtn_Click(object sender, EventArgs e)
        {
            // on ouvre l'interface de création de travail
            if (!API.AddJobFormOpened)
            {
                // on sauvegarde le nombre d'item actuel dans la 'TravailCombo'
                int travailItemsNbr = TravailCombo.Items.Count;
                // on ouvre la fenêtre d'ajout de travail
                API.AddJobFormOpened = true;
                Form fen = new Form_AddJob(false);
                fen.RightToLeft = API.GetCurrentLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
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
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // méthodes
        // getClientIdByName(...) : récupère l'id du client en recherchant son nom
        private int getClientIdByName(string clientName)
        {
            // on parcourt la dataTable Client
            for (int i = 0; i < API.MainDataSet.Tables["Client"].Rows.Count; i++)
            {
                if (API.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString() == clientName)
                    return Convert.ToInt32(API.MainDataSet.Tables["Client"].Rows[i]["id"]);
            }

            // si on ne le trouve pas on retourne un -1
            return -1;
        }

        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleClientName(string name)
        {
            for (int i = 0; i < API.MainDataSet.Tables["Client"].Rows.Count; i++)
            {
                if (API.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString().ToUpper() == name.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Win_Name", API.CurrentCulture);
            // Labels et GroupBoxs
            ClientGroupBox.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Client_GroupBox", API.CurrentCulture);
            NomLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Nom_Label", API.CurrentCulture);
            SexeLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Sexe_Label", API.CurrentCulture);
            TravailLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Travail_Label", API.CurrentCulture);
            DateNaissanceLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Date_Naissance_Label", API.CurrentCulture);
            NumeroTelLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Numero_Tel_Label", API.CurrentCulture);
            EmailLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Email_Label", API.CurrentCulture);
            PhotoGroupBox.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Photo_GroupBox", API.CurrentCulture);
            // combobox
            HommeFemmeCombo.Items[0] = API.LanguagesResourceManager.GetString("Sexe_Homme", API.CurrentCulture);
            HommeFemmeCombo.Items[1] = API.LanguagesResourceManager.GetString("Sexe_Femme", API.CurrentCulture);
            // Buttons
            NouveauTravailBtn.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Nouveau_Travail_Button", API.CurrentCulture);
            AjouterModifierPhotoBtn.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Ajouter_Modifier_Photo_Button", API.CurrentCulture);
            AjouterClientBtn.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Ajouter_Button", API.CurrentCulture);
            // openFileDialog1
            openFileDialog1.Title = API.LanguagesResourceManager.GetString("openFileDialog_Title", API.CurrentCulture);
        }
    }
}
