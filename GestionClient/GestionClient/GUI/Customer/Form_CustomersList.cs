using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using GestionClient.Localization;

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
            Language.Changed += this.LanguageChangedHandler;
        }

        // event. Load du formulaire
        private void ListeClients_Load(object sender, EventArgs e)
        {
            try
            {
                if (Database.ConnectedToDatabase) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (Database.Customers.Table.Rows.Count == 0)
                        throw new Exception(LocalizedStrings.MessageBox_Aucun_Client);

                    // remplissage de la combobox 'TravailCombo'
                    comboBox_job.DataSource = Database.Jobs.Table;
                    comboBox_job.DisplayMember = "Description";
                    comboBox_job.ValueMember = "ID";

                    // on récupère la dataTable ClientTravailPaiement
                    Database.CustomersJobsPayments.FetchTable();

                    // on crée un DataView pour pouvoir filtrer
                    dv = new DataView(Database.CustomersJobsPayments.Table);

                    // font/police de la dataGridView
                    dataGridView_customers.Font = new Font("Times New Roman", 11.0F, FontStyle.Italic);

                    // remplissage de la dataGridView
                    dataGridView_customers.DataSource = dv;
                    setDataGridViewFormat();

                    // on remplace les valeurs null par '-'
                    dataGridView_customers.DefaultCellStyle.NullValue = "-";

                    // on change la langue si l'arabe est séléctionné
                    if (Language.IsRightToLeft)
                        switchLanguage();
                }
                else
                {
                    throw new Exception(LocalizedStrings.MessageBox_Connexion_Non_Etablie);
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
            Language.Changed -= this.LanguageChangedHandler;
        }

        // event. SelectedIndexChanged de la combobox 'TravailCombo'
        private void TravailCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_filterByJob.Checked)
                doFilter();
        }

        // event. CheckedChanged de la checkbox 'FiltrerTravailCheckBox'
        private void FiltrerTravailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_job.Enabled = checkBox_filterByJob.Checked;
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
                printDialog.Document = printDocument_main;
                //printDialog.UseEXDialog = true;
                // affichage
                if (printDialog.ShowDialog() == DialogResult.OK) // Si l'utilisateur confirme l'impression
                {
                    printDocument_main.Print();
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
                DataGridViewPrinter.Print(dataGridView_customers, e, LocalizedStrings.Liste_Client_Win_Name);
            }
            catch (Exception exc)
            {
                QuickMessageBox.ShowError(exc.Message);
            }
        }

        // event. Click sur le boutton 'ActualiserBtn'
        private void ActualiserBtn_Click(object sender, EventArgs e)
        {
            Database.CustomersJobsPayments.FetchTable();
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
            if (!checkBox_filterByJob.Checked)
                dv.RowFilter = "nom LIKE '" + textBox_name.Text + "%'";
            else
                dv.RowFilter = "nom LIKE '" + textBox_name.Text + "%' AND travail = '" + comboBox_job.Text + "'";
        }

        // setDataGridviewFormat() : applique les changements de format nécéssaires à la DataGridView
        private void setDataGridViewFormat()
        {
            // Headers Text
            dataGridView_customers.Columns["FullName"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Nom;
            dataGridView_customers.Columns["Gender"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Sexe;
            dataGridView_customers.Columns["Jobs"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Travail;
            dataGridView_customers.Columns["age"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Age;
            dataGridView_customers.Columns["date de naissance"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Date_Naissance;
            dataGridView_customers.Columns["numéro tél"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Numero_Tel;
            dataGridView_customers.Columns["Email"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Email;
            dataGridView_customers.Columns["montant payé"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Montant_Payé;
            dataGridView_customers.Columns["ajouté le"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Ajouté_Le;

            // ajout de 'ans' dans toutes les lignes de la colonne 'age'
            NumberFormatInfo formatAge = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatAge.CurrencySymbol = LocalizedStrings.Liste_Client_DataGridView_Column_Age_Devise;
            formatAge.CurrencyDecimalDigits = 0;
            dataGridView_customers.Columns["age"].DefaultCellStyle.FormatProvider = formatAge;
            dataGridView_customers.Columns["age"].DefaultCellStyle.Format = "c";

            // ajout de la devise dans toutes les lignes de la colonne 'montant payé'
            NumberFormatInfo formatMontant = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatMontant.CurrencySymbol = LocalizedStrings.Liste_Client_DataGridView_Column_Montant_Payé_Devise;
            formatMontant.CurrencyDecimalDigits = 0;
            dataGridView_customers.Columns["montant payé"].DefaultCellStyle.FormatProvider = formatMontant;
            dataGridView_customers.Columns["montant payé"].DefaultCellStyle.Format = "c";
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = LocalizedStrings.Liste_Client_Win_Name;
            // Labels et GroupBoxs
            groupBox_filterCustomers.Text = LocalizedStrings.Liste_Client_Filtrer_GroupBox;
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            label_job.Text = LocalizedStrings.Ajouter_Client_Travail_Label;
            checkBox_filterByJob.Text = LocalizedStrings.Liste_Client_Filtrer_CheckBox;
            groupBox_customersList.Text = LocalizedStrings.Liste_Client_Liste_GroupBox;
            // Buttons
            button_refresh.Text = LocalizedStrings.Liste_Client_Actualiser_Button;
            button_print.Text = LocalizedStrings.Liste_Client_Imprimer_Button;
            // format de la DataGridView
            setDataGridViewFormat();
        }
    }
}
