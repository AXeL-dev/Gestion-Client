using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class RechercherNomClient : Form
    {
        // constr.
        public RechercherNomClient()
        {
            InitializeComponent();
        }

        // event. Click sur le boutton 'Rechercher'
        private void RechercherBtn_Click(object sender, EventArgs e)
        {
            // si le nom est vide
            if (NomTextBox.Text.Length == 0)
            {
                MessageBox.Show(API.resManager.GetString("MessageBox_Nom_Obligatoire", API.cul), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
                NomTextBox.Focus();
            }
            else
            {
                // on parcourt la dataTable Client
                for (int i = 0; i < API.ds.Tables["Client"].Rows.Count; i++)
                {
                    // si nom du client trouvé
                    if (API.ds.Tables["Client"].Rows[i]["nom"].ToString().ToUpper().StartsWith(NomTextBox.Text.ToUpper())) // ToUpper() pour gérer la casse
                    {
                        API.searchFoundedPosition = i;
                        this.Close(); // fermeture de la fenêtre
                        return; // on sort de la fonction
                    }
                }

                // si nn
                MessageBox.Show(API.resManager.GetString("MessageBox_Client_Non_trouvé", API.cul), API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
            }
        }

        // event. Load du formulaire
        private void RechercherNomClient_Load(object sender, EventArgs e)
        {
            // on change la langue si l'arabe est séléctionné
            if (API.getDefaultLanguage() == "ar")
                switchLanguage();
        }

        // méthodes
        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.resManager.GetString("Rechercher_Client_Win_Name", API.cul);
            // Labels et GroupBoxs
            ClientGroupBox.Text = API.resManager.GetString("Ajouter_Client_Client_GroupBox", API.cul);
            NomLabel.Text = API.resManager.GetString("Ajouter_Client_Nom_Label", API.cul);
            // Buttons
            RechercherBtn.Text = API.resManager.GetString("Rechercher_Client_Rechercher_Button", API.cul);
        }
    }
}
