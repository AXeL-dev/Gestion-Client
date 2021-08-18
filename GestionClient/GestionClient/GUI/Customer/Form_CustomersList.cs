using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_CustomersList : Form
    {
        private DataView _customersDataView;

        public Form_CustomersList()
        {
            InitializeComponent();
            dataGridView_customers.Font = new Font("Times New Roman", 11.0F, FontStyle.Italic);
            dataGridView_customers.DefaultCellStyle.NullValue = "-";
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            // Form
            this.Text = LocalizedStrings.Liste_Client_Win_Name;

            // Group Boxes
            groupBox_filterCustomers.Text = LocalizedStrings.Liste_Client_Filtrer_GroupBox;
            groupBox_customersList.Text = LocalizedStrings.Liste_Client_Liste_GroupBox;

            // Labels
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            label_job.Text = LocalizedStrings.Ajouter_Client_Travail_Label;

            // Buttons
            button_refresh.Text = LocalizedStrings.Liste_Client_Actualiser_Button;
            button_print.Text = LocalizedStrings.Liste_Client_Imprimer_Button;

            // Check Box
            checkBox_filterByJob.Text = LocalizedStrings.Liste_Client_Filtrer_CheckBox;

            // Data Grid View
            if (dataGridView_customers.Columns.Count > 0)
            {
                dataGridView_customers.Columns["FullName"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Nom;
                dataGridView_customers.Columns["Gender"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Sexe;
                dataGridView_customers.Columns["Job"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Travail;
                dataGridView_customers.Columns["Age"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Age;
                dataGridView_customers.Columns["Birth Date"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Date_Naissance;
                dataGridView_customers.Columns["Phone Number"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Numero_Tel;
                dataGridView_customers.Columns["Email"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Email;
                dataGridView_customers.Columns["Paid Amount"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Montant_Payé;
                dataGridView_customers.Columns["Added At"].HeaderText = LocalizedStrings.Liste_Client_DataGridView_Column_Ajouté_Le;
                DataGridViewColumnFormat.Number(dataGridView_customers, "Age",
                    LocalizedStrings.Liste_Client_DataGridView_Column_Age_Devise);
                DataGridViewColumnFormat.Number(dataGridView_customers, "Amount",
                   LocalizedStrings.Liste_Client_DataGridView_Column_Montant_Payé_Devise);
            }
        }

        private void ApplyFilter()
        {
            _customersDataView.RowFilter = string.Format("FullName LIKE '{0}%'", textBox_name.Text);
            if (checkBox_filterByJob.Checked)
            {
                _customersDataView.RowFilter += string.Format(" AND Job = '{0}'", comboBox_job.Text);
            }
        }
        #endregion

        private void Form_CustomersList_Load(object sender, EventArgs e)
        {
            try
            {
                if (Database.IsFetched)
                {
                    if (Database.Customers.IsEmpty)
                    {
                        throw new Exception(LocalizedStrings.MessageBox_Aucun_Client);
                    }

                    comboBox_job.DataSource = Database.Jobs.Table;
                    comboBox_job.DisplayMember = "Description";
                    comboBox_job.ValueMember = "ID";

                    _customersDataView = new DataView(Database.CustomersJobsPayments.Table);
                    dataGridView_customers.DataSource = _customersDataView;
                    UpdateLocalization();
                }
                else
                {
                    throw new Exception(LocalizedStrings.MessageBox_Connexion_Non_Etablie);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void Form_CustomersList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= (s, args) => this.UpdateLocalization();
        }

        private void comboBox_job_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_filterByJob.Checked)
            {
                ApplyFilter();
            }
        }

        private void checkBox_filterByJob_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_job.Enabled = checkBox_filterByJob.Checked;
            ApplyFilter();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            Database.CustomersJobsPayments.FetchTable();
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (printDialog_main.ShowDialog() == DialogResult.OK)
                {
                    printDocument_main.Print();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void printDocument_main_PrintPage(object sender, PrintPageEventArgs e)
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
    }
}
