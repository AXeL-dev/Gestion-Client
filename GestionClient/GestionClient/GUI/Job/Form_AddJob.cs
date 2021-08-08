using System;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class Form_AddJob : Form
    {
        // attributs
        private bool showConfirmationMsg = true;

        // constr.
        public Form_AddJob()
        {
            InitializeComponent();
        }

        // constr. surchargé
        public Form_AddJob(bool showConfirmationMsg)
        {
            InitializeComponent();
            this.showConfirmationMsg = showConfirmationMsg;
        }

        // event. Click sur le boutton 'AjouterBtn'
        private void AjouterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si la description est vide
                if (DescriptionTextBox.Text.Length == 0)
                {
                    MessageBox.Show(API.GetString("MessageBox_Description_Obligatoire"), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    DescriptionTextBox.Focus();
                }
                // si nn si travail en double
                else if (checkDoubleTravailDescription(DescriptionTextBox.Text))
                {
                    MessageBox.Show(API.GetString("MessageBox_Description_Double"), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    DescriptionTextBox.SelectAll(); // on séléctionne la description au cas l'utilisateur veut bien la supprimer
                    DescriptionTextBox.Focus();
                }
                else // si nn, c'est bon
                {
                    // ajout du travail
                    API.MainDataSet.Tables["Travail"].Rows.Add(null, DescriptionTextBox.Text);
                    API.ApplyChanges(API.TravailDataAdapter, "Travail");
                    if (showConfirmationMsg)
                        MessageBox.Show(API.GetString("MessageBox_Travail_Ajouté"), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                    // mise à jour de la dataTable Travail (pour avoir les bon ids)
                    API.FetchTravailTable();
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // event. Load du formulaire
        private void AjouterTravail_Load(object sender, EventArgs e)
        {
            if (!API.ConnectedToDatabase) // si on n'est pas connecté à la base de données
            {
                MessageBox.Show(API.GetString("MessageBox_Connexion_Non_Etablie"), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
            else
            {
                // on change la langue si l'arabe est séléctionné
                if (API.GetCurrentLanguage() == "ar")
                    switchLanguage();
            }
        }

        // event. FormClosed du formulaire
        private void AjouterTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            API.AddJobFormOpened = false;
            if (showConfirmationMsg) // si l'appel a été fait par la fenêtre mère et non une autre fenêtre comme AjouterClient
            {
                Form_Main parent = (Form_Main)this.MdiParent;
                parent.LanguageChanged -= this.LanguageChangedHandler;
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
        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleTravailDescription(string description)
        {
            for (int i = 0; i < API.MainDataSet.Tables["Travail"].Rows.Count; i++)
            {
                if (API.MainDataSet.Tables["Travail"].Rows[i]["description"].ToString().ToUpper() == description.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.GetString("Ajouter_Travail_Win_Name");
            // GroupBox 'Travail'
            groupBox1.Text = API.GetString("Ajouter_Travail_1st_GroupBox");
            // Label 'Description'
            label1.Text = API.GetString("Ajouter_Travail_1st_Label");
            // Button 'Ajouter'
            AjouterBtn.Text = API.GetString("Ajouter_Travail_Ajouter_Button");
        }
    }
}
