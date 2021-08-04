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
            if (API.isConnectedToDb) // si on est connecté à la base de données
            {
                // remplissage de la combobox 'TravailCombo'
                TravailCombo.DataSource = API.ds.Tables["Travail"];
                TravailCombo.DisplayMember = "description";
                TravailCombo.ValueMember = "id";

                // on change la langue si l'arabe est séléctionné
                if (API.getDefaultLanguage() == "ar")
                    switchLanguage();
            }
            else
            {
                MessageBox.Show(API.resManager.GetString("MessageBox_Connexion_Non_Etablie", API.cul), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. FormClosed du formulaire
        private void SupprimerTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            API.isSupprimerTravailOpened = false;
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
                    throw new Exception(API.resManager.GetString("MessageBox_Rien_A_Supprimer", API.cul));
                else if (MessageBox.Show(API.resManager.GetString("MessageBox_Confirmer_Suppression_Travail", API.cul), API.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, API.msgBoxOptions) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Travail
                    for (int i = 0; i < API.ds.Tables["Travail"].Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (API.ds.Tables["Travail"].Rows[i]["id"].ToString() == TravailCombo.SelectedValue.ToString())
                        {
                            // suppression
                            API.ds.Tables["Travail"].Rows[i].Delete();
                            API.appliquerChangement(API.daTravail, "Travail");
                            MessageBox.Show(API.resManager.GetString("MessageBox_Travail_Supprimé", API.cul), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
                            // mise à jour de la dataTable Client (pour supprimer les clients en relation avec ce travail)
                            API.getClient();
                            break; // on sort de la boucle for
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
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
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
            }
        }

        // méthodes
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.resManager.GetString("Supprimer_Travail_Win_Name", API.cul);
            // Label 'Travail'
            label1.Text = API.resManager.GetString("Supprimer_Travail_1st_Label", API.cul);
            // Label '(*)...'
            label2.Text = API.resManager.GetString("Supprimer_Travail_2nd_Label", API.cul);
            // Button 'Supprimer'
            SupprimerBtn.Text = API.resManager.GetString("Supprimer_Travail_Supprimer_Button", API.cul);
        }
    }
}
