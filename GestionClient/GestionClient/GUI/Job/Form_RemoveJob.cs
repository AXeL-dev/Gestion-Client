using System;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class Form_RemoveJob : Form
    {
        // constr.
        public Form_RemoveJob()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void Form_RemoveJob_Load(object sender, EventArgs e)
        {
            if (Database.ConnectedToDatabase) // si on est connecté à la base de données
            {
                // remplissage de la combobox 'TravailCombo'
                TravailCombo.DataSource = Database.MainDataSet.Tables["Travail"];
                TravailCombo.DisplayMember = "description";
                TravailCombo.ValueMember = "id";

                // on change la langue si l'arabe est séléctionné
                if (Language.GetCurrentLanguage() == "ar")
                    switchLanguage();
            }
            else
            {
                QuickMessageBox.ShowWarning(Language.GetString("MessageBox_Connexion_Non_Etablie"));
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. FormClosed du formulaire
        private void SupprimerTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.RemoveJobFormOpened = false;
            Form_Main parent = (Form_Main)this.MdiParent;
            parent.LanguageChanged -= this.LanguageChangedHandler;
        }

        // event. Click sur le boutton 'SupprimerBtn'
        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si jamais la combobox est vide
                if (TravailCombo.Items.Count == 0)
                    throw new Exception(Language.GetString("MessageBox_Rien_A_Supprimer"));
                else if (QuickMessageBox.ShowQuestion(Language.GetString("MessageBox_Confirmer_Suppression_Travail")) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Travail
                    for (int i = 0; i < Database.MainDataSet.Tables["Travail"].Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (Database.MainDataSet.Tables["Travail"].Rows[i]["id"].ToString() == TravailCombo.SelectedValue.ToString())
                        {
                            // suppression
                            Database.MainDataSet.Tables["Travail"].Rows[i].Delete();
                            Database.ApplyChanges(Database.TravailDataAdapter, "Travail");
                            QuickMessageBox.ShowInformation(Language.GetString("MessageBox_Travail_Supprimé"));
                            // mise à jour de la dataTable Client (pour supprimer les clients en relation avec ce travail)
                            Database.FetchClientTable();
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
            this.Text = Language.GetString("Supprimer_Travail_Win_Name");
            // Label 'Travail'
            label1.Text = Language.GetString("Supprimer_Travail_1st_Label");
            // Label '(*)...'
            label2.Text = Language.GetString("Supprimer_Travail_2nd_Label");
            // Button 'Supprimer'
            SupprimerBtn.Text = Language.GetString("Supprimer_Travail_Supprimer_Button");
        }
    }
}
