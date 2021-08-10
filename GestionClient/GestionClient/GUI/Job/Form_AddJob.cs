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
                    QuickMessageBox.ShowWarning(Language.GetString("MessageBox_Description_Obligatoire"));
                    DescriptionTextBox.Focus();
                }
                // si nn si travail en double
                else if (checkDoubleTravailDescription(DescriptionTextBox.Text))
                {
                    QuickMessageBox.ShowWarning(Language.GetString("MessageBox_Description_Double"));
                    DescriptionTextBox.SelectAll(); // on séléctionne la description au cas l'utilisateur veut bien la supprimer
                    DescriptionTextBox.Focus();
                }
                else // si nn, c'est bon
                {
                    // ajout du travail
                    Database.MainDataSet.Tables["Travail"].Rows.Add(null, DescriptionTextBox.Text);
                    Database.ApplyChanges(Database.TravailDataAdapter, "Travail");
                    if (showConfirmationMsg)
                        QuickMessageBox.ShowInformation(Language.GetString("MessageBox_Travail_Ajouté"));
                    // mise à jour de la dataTable Travail (pour avoir les bon ids)
                    Database.FetchTravailTable();
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. Load du formulaire
        private void AjouterTravail_Load(object sender, EventArgs e)
        {
            if (!Database.ConnectedToDatabase) // si on n'est pas connecté à la base de données
            {
                QuickMessageBox.ShowWarning(Language.GetString("MessageBox_Connexion_Non_Etablie"));
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
            else
            {
                // on change la langue si l'arabe est séléctionné
                if (Language.IsRightToLeft)
                    switchLanguage();
            }
        }

        // event. FormClosed du formulaire
        private void AjouterTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.AddJobFormOpened = false;
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
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // méthodes
        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleTravailDescription(string description)
        {
            for (int i = 0; i < Database.MainDataSet.Tables["Travail"].Rows.Count; i++)
            {
                if (Database.MainDataSet.Tables["Travail"].Rows[i]["description"].ToString().ToUpper() == description.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = Language.GetString("Ajouter_Travail_Win_Name");
            // GroupBox 'Travail'
            groupBox1.Text = Language.GetString("Ajouter_Travail_1st_GroupBox");
            // Label 'Description'
            label1.Text = Language.GetString("Ajouter_Travail_1st_Label");
            // Button 'Ajouter'
            AjouterBtn.Text = Language.GetString("Ajouter_Travail_Ajouter_Button");
        }
    }
}
