using System;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_RemoveJob : Form
    {
        // constr.
        public Form_RemoveJob()
        {
            InitializeComponent();
            Language.Changed += this.LanguageChangedHandler;
        }

        // event. Load du formulaire
        private void Form_RemoveJob_Load(object sender, EventArgs e)
        {
            if (Database.ConnectedToDatabase) // si on est connecté à la base de données
            {
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

        // event. FormClosed du formulaire
        private void SupprimerTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= this.LanguageChangedHandler;
        }

        // event. Click sur le boutton 'SupprimerBtn'
        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si jamais la combobox est vide
                if (comboBox_job.Items.Count == 0)
                    throw new Exception(LocalizedStrings.MessageBox_Rien_A_Supprimer);
                else if (QuickMessageBox.ShowQuestion(LocalizedStrings.MessageBox_Confirmer_Suppression_Travail) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Travail
                    for (int i = 0; i < Database.Jobs.Table.Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (Database.Jobs.Table.Rows[i]["id"].ToString() == comboBox_job.SelectedValue.ToString())
                        {
                            // suppression
                            Database.Jobs.Table.Rows[i].Delete();
                            Database.Jobs.ApplyChanges();
                            QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Travail_Supprimé);
                            // mise à jour de la dataTable Client (pour supprimer les clients en relation avec ce travail)
                            Database.Customers.FetchTable();
                            break; // on sort de la boucle for
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
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
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = LocalizedStrings.Supprimer_Travail_Win_Name;
            // Label 'Travail'
            label_job.Text = LocalizedStrings.Supprimer_Travail_1st_Label;
            // Label '(*)...'
            label_warning.Text = LocalizedStrings.Supprimer_Travail_2nd_Label;
            // Button 'Supprimer'
            button_remove.Text = LocalizedStrings.Supprimer_Travail_Supprimer_Button;
        }
    }
}
