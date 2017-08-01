using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            if (ClassGlobal.isConnectedToDb) // si on est connecté à la base de données
            {
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

        // event. FormClosed du formulaire
        private void SupprimerTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassGlobal.isSupprimerTravailOpened = false;
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
                    throw new Exception(ClassGlobal.resManager.GetString("MessageBox_Rien_A_Supprimer", ClassGlobal.cul));
                else if (MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Confirmer_Suppression_Travail", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, ClassGlobal.msgBoxOptions) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Travail
                    for (int i = 0; i < ClassGlobal.ds.Tables["Travail"].Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (ClassGlobal.ds.Tables["Travail"].Rows[i]["id"].ToString() == TravailCombo.SelectedValue.ToString())
                        {
                            // suppression
                            ClassGlobal.ds.Tables["Travail"].Rows[i].Delete();
                            ClassGlobal.appliquerChangement(ClassGlobal.daTravail, "Travail");
                            MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Travail_Supprimé", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                            // mise à jour de la dataTable Client (pour supprimer les clients en relation avec ce travail)
                            ClassGlobal.getClient();
                            break; // on sort de la boucle for
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
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
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = ClassGlobal.resManager.GetString("Supprimer_Travail_Win_Name", ClassGlobal.cul);
            // Label 'Travail'
            label1.Text = ClassGlobal.resManager.GetString("Supprimer_Travail_1st_Label", ClassGlobal.cul);
            // Label '(*)...'
            label2.Text = ClassGlobal.resManager.GetString("Supprimer_Travail_2nd_Label", ClassGlobal.cul);
            // Button 'Supprimer'
            SupprimerBtn.Text = ClassGlobal.resManager.GetString("Supprimer_Travail_Supprimer_Button", ClassGlobal.cul);
        }
    }
}
