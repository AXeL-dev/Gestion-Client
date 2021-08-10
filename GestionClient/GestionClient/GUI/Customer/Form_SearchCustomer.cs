using System;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class Form_SearchCustomer : Form
    {
        // constr.
        public Form_SearchCustomer()
        {
            InitializeComponent();
        }

        // event. Click sur le boutton 'Rechercher'
        private void RechercherBtn_Click(object sender, EventArgs e)
        {
            // si le nom est vide
            if (NomTextBox.Text.Length == 0)
            {
                QuickMessageBox.ShowWarning(Language.GetString("MessageBox_Nom_Obligatoire"));
                NomTextBox.Focus();
            }
            else
            {
                // on parcourt la dataTable Client
                for (int i = 0; i < Database.MainDataSet.Tables["Client"].Rows.Count; i++)
                {
                    // si nom du client trouvé
                    if (Database.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString().ToUpper().StartsWith(NomTextBox.Text.ToUpper())) // ToUpper() pour gérer la casse
                    {
                        App.SearchResultIndex = i;
                        this.Close(); // fermeture de la fenêtre
                        return; // on sort de la fonction
                    }
                }

                // si nn
                QuickMessageBox.ShowWarning(Language.GetString("MessageBox_Client_Non_trouvé"));
            }
        }

        // event. Load du formulaire
        private void RechercherNomClient_Load(object sender, EventArgs e)
        {
            // on change la langue si l'arabe est séléctionné
            if (Language.IsRightToLeft)
                switchLanguage();
        }

        // méthodes
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = Language.GetString("Rechercher_Client_Win_Name");
            // Labels et GroupBoxs
            ClientGroupBox.Text = Language.GetString("Ajouter_Client_Client_GroupBox");
            NomLabel.Text = Language.GetString("Ajouter_Client_Nom_Label");
            // Buttons
            RechercherBtn.Text = Language.GetString("Rechercher_Client_Rechercher_Button");
        }
    }
}
