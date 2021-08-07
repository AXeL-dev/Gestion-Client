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
                if (API.ConnectedToDatabase) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (API.MainDataSet.Tables["Client"].Rows.Count == 0)
                        throw new Exception(API.LanguagesResourceManager.GetString("MessageBox_Aucun_Client", API.CurrentCulture));

                    // remplissage de la combobox 'TravailCombo'
                    TravailCombo.DataSource = API.MainDataSet.Tables["Travail"];
                    TravailCombo.DisplayMember = "description";
                    TravailCombo.ValueMember = "id";

                    // on récupère la dataTable ClientTravailPaiement
                    API.FetchClientTravailPaiementTable();

                    // on crée un DataView pour pouvoir filtrer
                    dv = new DataView(API.MainDataSet.Tables["ClientTravailPaiement"]);

                    // font/police de la dataGridView
                    dataGridView1.Font = new Font("Times New Roman", 11.0F, FontStyle.Italic);

                    // remplissage de la dataGridView
                    dataGridView1.DataSource = dv;
                    setDataGridViewFormat();

                    // on remplace les valeurs null par '-'
                    dataGridView1.DefaultCellStyle.NullValue = "-";

                    // on change la langue si l'arabe est séléctionné
                    if (API.GetCurrentLanguage() == "ar")
                        switchLanguage();
                }
                else
                {
                    throw new Exception(API.LanguagesResourceManager.GetString("MessageBox_Connexion_Non_Etablie", API.CurrentCulture));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. FormClosed du formulaire
        private void ListeClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            API.ListeClientsFormOpened = false;
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
                MessageBox.Show(ex.Message, API.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
            }
        }

        // event. PrintPage de 'printDocument1'
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridView.printDataGridViewPage(e, dataGridView1, API.LanguagesResourceManager.GetString("Liste_Client_Win_Name", API.CurrentCulture));
        }

        // event. Click sur le boutton 'ActualiserBtn'
        private void ActualiserBtn_Click(object sender, EventArgs e)
        {
            API.FetchClientTravailPaiementTable();
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
            dataGridView1.Columns["nom"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Nom", API.CurrentCulture);
            dataGridView1.Columns["sexe"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Sexe", API.CurrentCulture);
            dataGridView1.Columns["travail"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Travail", API.CurrentCulture);
            dataGridView1.Columns["age"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Age", API.CurrentCulture);
            dataGridView1.Columns["date de naissance"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Date_Naissance", API.CurrentCulture);
            dataGridView1.Columns["numéro tél"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Numero_Tel", API.CurrentCulture);
            dataGridView1.Columns["email"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Email", API.CurrentCulture);
            dataGridView1.Columns["montant payé"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Montant_Payé", API.CurrentCulture);
            dataGridView1.Columns["ajouté le"].HeaderText = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Ajouté_Le", API.CurrentCulture);

            // ajout de 'ans' dans toutes les lignes de la colonne 'age'
            NumberFormatInfo formatAge = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatAge.CurrencySymbol = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Age_Devise", API.CurrentCulture);
            formatAge.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["age"].DefaultCellStyle.FormatProvider = formatAge;
            dataGridView1.Columns["age"].DefaultCellStyle.Format = "c";

            // ajout de la devise dans toutes les lignes de la colonne 'montant payé'
            NumberFormatInfo formatMontant = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatMontant.CurrencySymbol = API.LanguagesResourceManager.GetString("Liste_Client_DataGridView_Column_Montant_Payé_Devise", API.CurrentCulture);
            formatMontant.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.FormatProvider = formatMontant;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.Format = "c";
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.LanguagesResourceManager.GetString("Liste_Client_Win_Name", API.CurrentCulture);
            // Labels et GroupBoxs
            FiltrerClientGroupBox.Text = API.LanguagesResourceManager.GetString("Liste_Client_Filtrer_GroupBox", API.CurrentCulture);
            NomLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Nom_Label", API.CurrentCulture);
            TravailLabel.Text = API.LanguagesResourceManager.GetString("Ajouter_Client_Travail_Label", API.CurrentCulture);
            FiltrerTravailCheckBox.Text = API.LanguagesResourceManager.GetString("Liste_Client_Filtrer_CheckBox", API.CurrentCulture);
            ListeClientGroupBox.Text = API.LanguagesResourceManager.GetString("Liste_Client_Liste_GroupBox", API.CurrentCulture);
            // Buttons
            ActualiserBtn.Text = API.LanguagesResourceManager.GetString("Liste_Client_Actualiser_Button", API.CurrentCulture);
            ImprimerBtn.Text = API.LanguagesResourceManager.GetString("Liste_Client_Imprimer_Button", API.CurrentCulture);
            // format de la DataGridView
            setDataGridViewFormat();
        }
    }
}
