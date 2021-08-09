using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class Form_CustomersList : Form
    {
        // attributs
        private DataView dv;

        // constr.
        public Form_CustomersList()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void ListeClients_Load(object sender, EventArgs e)
        {
            try
            {
                if (Database.ConnectedToDatabase) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (Database.MainDataSet.Tables["Client"].Rows.Count == 0)
                        throw new Exception(Language.GetString("MessageBox_Aucun_Client"));

                    // remplissage de la combobox 'TravailCombo'
                    TravailCombo.DataSource = Database.MainDataSet.Tables["Travail"];
                    TravailCombo.DisplayMember = "description";
                    TravailCombo.ValueMember = "id";

                    // on récupère la dataTable ClientTravailPaiement
                    Database.FetchClientTravailPaiementTable();

                    // on crée un DataView pour pouvoir filtrer
                    dv = new DataView(Database.MainDataSet.Tables["ClientTravailPaiement"]);

                    // font/police de la dataGridView
                    dataGridView1.Font = new Font("Times New Roman", 11.0F, FontStyle.Italic);

                    // remplissage de la dataGridView
                    dataGridView1.DataSource = dv;
                    setDataGridViewFormat();

                    // on remplace les valeurs null par '-'
                    dataGridView1.DefaultCellStyle.NullValue = "-";

                    // on change la langue si l'arabe est séléctionné
                    if (Language.IsArabic)
                        switchLanguage();
                }
                else
                {
                    throw new Exception(Language.GetString("MessageBox_Connexion_Non_Etablie"));
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. FormClosed du formulaire
        private void ListeClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.CustomerListFormOpened = false;
            Form_Main parent = (Form_Main)this.MdiParent;
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
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. PrintPage de 'printDocument1'
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                DataGridViewPrinter.Print(dataGridView1, e, Language.GetString("Liste_Client_Win_Name"));
            }
            catch (Exception exc)
            {
                QuickMessageBox.ShowError(exc.Message);
            }
        }

        // event. Click sur le boutton 'ActualiserBtn'
        private void ActualiserBtn_Click(object sender, EventArgs e)
        {
            Database.FetchClientTravailPaiementTable();
        }

        // event. LanguageChanged du formulaire (enfant)
        public void LanguageChangedHandler(object sender, EventArgs e)
        {
            try
            {
                switchLanguage();
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
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
            dataGridView1.Columns["nom"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Nom");
            dataGridView1.Columns["sexe"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Sexe");
            dataGridView1.Columns["travail"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Travail");
            dataGridView1.Columns["age"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Age");
            dataGridView1.Columns["date de naissance"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Date_Naissance");
            dataGridView1.Columns["numéro tél"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Numero_Tel");
            dataGridView1.Columns["email"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Email");
            dataGridView1.Columns["montant payé"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Montant_Payé");
            dataGridView1.Columns["ajouté le"].HeaderText = Language.GetString("Liste_Client_DataGridView_Column_Ajouté_Le");

            // ajout de 'ans' dans toutes les lignes de la colonne 'age'
            NumberFormatInfo formatAge = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatAge.CurrencySymbol = Language.GetString("Liste_Client_DataGridView_Column_Age_Devise");
            formatAge.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["age"].DefaultCellStyle.FormatProvider = formatAge;
            dataGridView1.Columns["age"].DefaultCellStyle.Format = "c";

            // ajout de la devise dans toutes les lignes de la colonne 'montant payé'
            NumberFormatInfo formatMontant = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatMontant.CurrencySymbol = Language.GetString("Liste_Client_DataGridView_Column_Montant_Payé_Devise");
            formatMontant.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.FormatProvider = formatMontant;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.Format = "c";
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = Language.GetString("Liste_Client_Win_Name");
            // Labels et GroupBoxs
            FiltrerClientGroupBox.Text = Language.GetString("Liste_Client_Filtrer_GroupBox");
            NomLabel.Text = Language.GetString("Ajouter_Client_Nom_Label");
            TravailLabel.Text = Language.GetString("Ajouter_Client_Travail_Label");
            FiltrerTravailCheckBox.Text = Language.GetString("Liste_Client_Filtrer_CheckBox");
            ListeClientGroupBox.Text = Language.GetString("Liste_Client_Liste_GroupBox");
            // Buttons
            ActualiserBtn.Text = Language.GetString("Liste_Client_Actualiser_Button");
            ImprimerBtn.Text = Language.GetString("Liste_Client_Imprimer_Button");
            // format de la DataGridView
            setDataGridViewFormat();
        }
    }
}
