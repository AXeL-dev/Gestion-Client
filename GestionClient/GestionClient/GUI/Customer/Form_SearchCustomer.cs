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
                MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Nom_Obligatoire", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                NomTextBox.Focus();
            }
            else
            {
                // on parcourt la dataTable Client
                for (int i = 0; i < API.MainDataSet.Tables["Client"].Rows.Count; i++)
                {
                    // si nom du client trouvé
                    if (API.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString().ToUpper().StartsWith(NomTextBox.Text.ToUpper())) // ToUpper() pour gérer la casse
                    {
                        API.SearchResultIndex = i;
                        this.Close(); // fermeture de la fenêtre
                        return; // on sort de la fonction
                    }
                }

                // si nn
                MessageBox.Show(API.LanguagesResourceManager.GetString("MessageBox_Client_Non_trouvé", API.CurrentCulture), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // event. Load du formulaire
        private void RechercherNomClient_Load(object sender, EventArgs e)
        {
            // on change la langue si l'arabe est séléctionné
            if (API.GetCurrentLanguage() == "ar")
                switchLanguage();
        }

        // méthodes
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.LanguagesResourceManager.GetString("Rechercher_Client_Win_Name", API.CurrentCulture);
            // Labels et GroupBoxs
            ClientGroupBox.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Client_GroupBox", API.CurrentCulture);
            NomLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Nom_Label", API.CurrentCulture);
            // Buttons
            RechercherBtn.Text = API.LanguagesResourceManager.GetString("Rechercher_Client_Rechercher_Button", API.CurrentCulture);
        }
    }
}
