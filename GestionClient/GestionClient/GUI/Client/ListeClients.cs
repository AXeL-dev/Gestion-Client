using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class ListeClients : Form
    {
        // attributs
        private DataView dv;

        // constr.
        public ListeClients()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void ListeClients_Load(object sender, EventArgs e)
        {
            try
            {
                if (API.isConnectedToDb) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (API.ds.Tables["Client"].Rows.Count == 0)
                        throw new Exception(API.resManager.GetString("MessageBox_Aucun_Client", API.cul));

                    // remplissage de la combobox 'TravailCombo'
                    TravailCombo.DataSource = API.ds.Tables["Travail"];
                    TravailCombo.DisplayMember = "description";
                    TravailCombo.ValueMember = "id";

                    // on récupère la dataTable ClientTravailPaiement
                    API.getClientTravailPaiement();

                    // on crée un DataView pour pouvoir filtrer
                    dv = new DataView(API.ds.Tables["ClientTravailPaiement"]);

                    // font/police de la dataGridView
                    dataGridView1.Font = new Font("Times New Roman", 11.0F, FontStyle.Italic);

                    // remplissage de la dataGridView
                    dataGridView1.DataSource = dv;
                    setDataGridViewFormat();

                    // on remplace les valeurs null par '-'
                    dataGridView1.DefaultCellStyle.NullValue = "-";

                    // on change la langue si l'arabe est séléctionné
                    if (API.getDefaultLanguage() == "ar")
                        switchLanguage();
                }
                else
                {
                    throw new Exception(API.resManager.GetString("MessageBox_Connexion_Non_Etablie", API.cul));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. FormClosed du formulaire
        private void ListeClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            API.isListeClientsOpened = false;
            main parent = (main)this.MdiParent;
            parent.LanguageChanged -= this.LanguageChangedHandler;
        }

        // event. SelectedIndexChanged de la combobox 'TravailCombo'
        private void TravailCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FiltrerTravailCheckBox.Checked)
                doFilter();
        }

        // event. CheckedChanged de la checkbox 'FiltrerTravailCheckBox'
        private void FiltrerTravailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TravailCombo.Enabled = FiltrerTravailCheckBox.Checked;
            doFilter();
        }

        // event. TextChanged de la textbox 'NomTextBox'
        private void NomTextBox_TextChanged(object sender, EventArgs e)
        {
            doFilter();
        }

        // event. Click sur le boutton 'Imprimer'
        private void ImprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Création de la boîte de dialogue d'impression
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;
                //printDialog.UseEXDialog = true;
                // affichage
                if (printDialog.ShowDialog() == DialogResult.OK) // Si l'utilisateur confirme l'impression
                {
                    printDocument1.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.msgBoxOptions);
            }
        }

        // event. PrintPage de 'printDocument1'
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridView.printDataGridViewPage(e, dataGridView1, API.resManager.GetString("Liste_Client_Win_Name", API.cul));
        }

        // event. Click sur le boutton 'ActualiserBtn'
        private void ActualiserBtn_Click(object sender, EventArgs e)
        {
            API.getClientTravailPaiement();
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

        // Méthodes
        // doFilter() : filtre les clients
        private void doFilter()
        {
            if (!FiltrerTravailCheckBox.Checked)
                dv.RowFilter = "nom LIKE '" + NomTextBox.Text + "%'";
            else
                dv.RowFilter = "nom LIKE '" + NomTextBox.Text + "%' AND travail = '" + TravailCombo.Text + "'";
        }

        // setDataGridviewFormat() : applique les changements de format nécéssaires à la DataGridView
        private void setDataGridViewFormat()
        {
            // Headers Text
            dataGridView1.Columns["nom"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Nom", API.cul);
            dataGridView1.Columns["sexe"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Sexe", API.cul);
            dataGridView1.Columns["travail"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Travail", API.cul);
            dataGridView1.Columns["age"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Age", API.cul);
            dataGridView1.Columns["date de naissance"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Date_Naissance", API.cul);
            dataGridView1.Columns["numéro tél"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Numero_Tel", API.cul);
            dataGridView1.Columns["email"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Email", API.cul);
            dataGridView1.Columns["montant payé"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Montant_Payé", API.cul);
            dataGridView1.Columns["ajouté le"].HeaderText = API.resManager.GetString("Liste_Client_DataGridView_Column_Ajouté_Le", API.cul);

            // ajout de 'ans' dans toutes les lignes de la colonne 'age'
            NumberFormatInfo formatAge = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatAge.CurrencySymbol = API.resManager.GetString("Liste_Client_DataGridView_Column_Age_Devise", API.cul);
            formatAge.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["age"].DefaultCellStyle.FormatProvider = formatAge;
            dataGridView1.Columns["age"].DefaultCellStyle.Format = "c";

            // ajout de la devise dans toutes les lignes de la colonne 'montant payé'
            NumberFormatInfo formatMontant = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatMontant.CurrencySymbol = API.resManager.GetString("Liste_Client_DataGridView_Column_Montant_Payé_Devise", API.cul);
            formatMontant.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.FormatProvider = formatMontant;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.Format = "c";
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.resManager.GetString("Liste_Client_Win_Name", API.cul);
            // Labels et GroupBoxs
            FiltrerClientGroupBox.Text = API.resManager.GetString("Liste_Client_Filtrer_GroupBox", API.cul);
            NomLabel.Text = API.resManager.GetString("Ajouter_Client_Nom_Label", API.cul);
            TravailLabel.Text = API.resManager.GetString("Ajouter_Client_Travail_Label", API.cul);
            FiltrerTravailCheckBox.Text = API.resManager.GetString("Liste_Client_Filtrer_CheckBox", API.cul);
            ListeClientGroupBox.Text = API.resManager.GetString("Liste_Client_Liste_GroupBox", API.cul);
            // Buttons
            ActualiserBtn.Text = API.resManager.GetString("Liste_Client_Actualiser_Button", API.cul);
            ImprimerBtn.Text = API.resManager.GetString("Liste_Client_Imprimer_Button", API.cul);
            // format de la DataGridView
            setDataGridViewFormat();
        }
    }
}
