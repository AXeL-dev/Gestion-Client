using System;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class SupprimerTravail : Form
    {
        // constr.
        public SupprimerTravail()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void SupprimerTravail_Load(object sender, EventArgs e)
        {
            if (API.ConnectedToDatabase) // si on est connecté à la base de données
            {
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

        // event. FormClosed du formulaire
        private void SupprimerTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            API.SupprimerTravailFormOpened = false;
            main parent = (main)this.MdiParent;
            parent.LanguageChanged -= this.LanguageChangedHandler;
        }

        // event. Click sur le boutton 'SupprimerBtn'
        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si jamais la combobox est vide
                if (TravailCombo.Items.Count == 0)
                    throw new Exception(API.LanguagesResourceManager.GetString("MessageBox_Rien_A_Supprimer", API.CurrentCulture));
                else if (MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Confirmer_Suppression_Travail", API.CurrentCulture), API.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, API.CurrentMessageBoxOptions) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Travail
                    for (int i = 0; i < API.MainDataSet.Tables["Travail"].Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (API.MainDataSet.Tables["Travail"].Rows[i]["id"].ToString() == TravailCombo.SelectedValue.ToString())
                        {
                            // suppression
                            API.MainDataSet.Tables["Travail"].Rows[i].Delete();
                            API.ApplyChanges(API.TravailDataAdapter, "Travail");
                            MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Travail_Supprimé", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                            // mise à jour de la dataTable Client (pour supprimer les clients en relation avec ce travail)
                            API.FetchClientTable();
                            break; // on sort de la boucle for
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
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
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.LanguagesResourceManager.GetString("Supprimer_Travail_Win_Name", API.CurrentCulture);
            // Label 'Travail'
            label1.Text = API.LanguagesResourceManager.GetString("Supprimer_Travail_1st_Label", API.CurrentCulture);
            // Label '(*)...'
            label2.Text = API.LanguagesResourceManager.GetString("Supprimer_Travail_2nd_Label", API.CurrentCulture);
            // Button 'Supprimer'
            SupprimerBtn.Text = API.LanguagesResourceManager.GetString("Supprimer_Travail_Supprimer_Button", API.CurrentCulture);
        }
    }
}
