using System;
using System.Windows.Forms;
using GestionClient.Localization;

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
            if (textBox_name.Text.Length == 0)
            {
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                textBox_name.Focus();
            }
            else
            {
                // on parcourt la dataTable Client
                for (int i = 0; i < Database.MainDataSet.Tables["Client"].Rows.Count; i++)
                {
                    // si nom du client trouvé
                    if (Database.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString().ToUpper().StartsWith(textBox_name.Text.ToUpper())) // ToUpper() pour gérer la casse
                    {
                        App.SearchResultIndex = i;
                        this.Close(); // fermeture de la fenêtre
                        return; // on sort de la fonction
                    }
                }

                // si nn
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Client_Non_trouvé);
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
            this.Text = LocalizedStrings.Rechercher_Client_Win_Name;
            // Labels et GroupBoxs
            groupBox_customer.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            // Buttons
            button_search.Text = LocalizedStrings.Rechercher_Client_Rechercher_Button;
        }
    }
}
