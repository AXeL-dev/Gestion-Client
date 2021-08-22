using System;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_RemoveJob : Form
    {
        public Form_RemoveJob()
        {
            InitializeComponent();
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            this.Text = LocalizedStrings.Supprimer_Travail_Win_Name;
            label_job.Text = LocalizedStrings.Supprimer_Travail_1st_Label;
            label_warning.Text = LocalizedStrings.Supprimer_Travail_2nd_Label;
            button_remove.Text = LocalizedStrings.Supprimer_Travail_Supprimer_Button;
        }
        #endregion

        private void Form_RemoveJob_Load(object sender, EventArgs e)
        {
            if (Database.IsFetched)
            {
                UpdateLocalization();
                comboBox_job.DataSource = Database.Jobs.Table;
                comboBox_job.DisplayMember = "Description";
                comboBox_job.ValueMember = "ID";
            }
            else
            {
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Connexion_Non_Etablie);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void Form_RemoveJob_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= (s, args) => this.UpdateLocalization();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_job.Items.Count == 0)
                {
                    throw new Exception(LocalizedStrings.MessageBox_Rien_A_Supprimer);
                }
                else if (QuickMessageBox.ShowQuestion(LocalizedStrings.MessageBox_Confirmer_Suppression_Travail) == DialogResult.Yes)
                {
                    string jobID = comboBox_job.SelectedValue.ToString();
                    var jobRow = Database.Jobs.GetFirstRowWhere("ID = {0}", jobID);
                    if (jobRow != null)
                    {
                        jobRow.Delete();
                        Database.Jobs.ApplyChanges();
                        QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Travail_Supprimé);
                        Database.Customers.FetchTable();
                    }
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }
    }
}
