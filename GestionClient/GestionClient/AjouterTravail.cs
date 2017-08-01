using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class AjouterTravail : Form
    {
        // attributs
        private bool showConfirmationMsg = true;

        // constr.
        public AjouterTravail()
        {
            InitializeComponent();
        }

        // constr. surchargé
        public AjouterTravail(bool showConfirmationMsg)
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
                    MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Description_Obligatoire", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    DescriptionTextBox.Focus();
                }
                // si nn si travail en double
                else if (checkDoubleTravailDescription(DescriptionTextBox.Text))
                {
                    MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Description_Double", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    DescriptionTextBox.SelectAll(); // on séléctionne la description au cas l'utilisateur veut bien la supprimer
                    DescriptionTextBox.Focus();
                }
                else // si nn, c'est bon
                {
                    // ajout du travail
                    ClassGlobal.ds.Tables["Travail"].Rows.Add(null, DescriptionTextBox.Text);
                    ClassGlobal.appliquerChangement(ClassGlobal.daTravail, "Travail");
                    if (showConfirmationMsg)
                        MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Travail_Ajouté", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                    // mise à jour de la dataTable Travail (pour avoir les bon ids)
                    ClassGlobal.getTravail();
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
            }
        }

        // event. Load du formulaire
        private void AjouterTravail_Load(object sender, EventArgs e)
        {
            if (!ClassGlobal.isConnectedToDb) // si on n'est pas connecté à la base de données
            {
                MessageBox.Show(ClassGlobal.resManager.GetString("MessageBox_Connexion_Non_Etablie", ClassGlobal.cul), ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
            else
            {
                // on change la langue si l'arabe est séléctionné
                if (ClassGlobal.getDefaultLanguage() == "ar")
                    switchLanguage();
            }
        }

        // event. FormClosed du formulaire
        private void AjouterTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassGlobal.isAjouterTravailOpened = false;
            if (showConfirmationMsg) // si l'appel a été fait par la fenêtre mère et non une autre fenêtre comme AjouterClient
            {
                main parent = (main)this.MdiParent;
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
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
            }
        }

        // méthodes
        // checkDoubleClientName(...) : vérifie si le nom du client entré existe déjà (return true) ou pas (return false)
        private bool checkDoubleTravailDescription(string description)
        {
            for (int i = 0; i < ClassGlobal.ds.Tables["Travail"].Rows.Count; i++)
            {
                if (ClassGlobal.ds.Tables["Travail"].Rows[i]["description"].ToString().ToUpper() == description.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = ClassGlobal.resManager.GetString("Ajouter_Travail_Win_Name", ClassGlobal.cul);
            // GroupBox 'Travail'
            groupBox1.Text = ClassGlobal.resManager.GetString("Ajouter_Travail_1st_GroupBox", ClassGlobal.cul);
            // Label 'Description'
            label1.Text = ClassGlobal.resManager.GetString("Ajouter_Travail_1st_Label", ClassGlobal.cul);
            // Button 'Ajouter'
            AjouterBtn.Text = ClassGlobal.resManager.GetString("Ajouter_Travail_Ajouter_Button", ClassGlobal.cul);
        }
    }
}
