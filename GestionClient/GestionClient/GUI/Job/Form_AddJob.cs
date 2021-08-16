using System;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_AddJob : Form
    {
        private bool _showConfirmationMessage;

        public Form_AddJob(bool showConfirmationMessage = true)
        {
            InitializeComponent();
            _showConfirmationMessage = showConfirmationMessage;
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            this.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            this.Text = LocalizedStrings.Ajouter_Travail_Win_Name;
            groupBox_job.Text = LocalizedStrings.Ajouter_Travail_1st_GroupBox;
            label_description.Text = LocalizedStrings.Ajouter_Travail_1st_Label;
            button_add.Text = LocalizedStrings.Ajouter_Travail_Ajouter_Button;
        }
        #endregion

        private void Form_AddJob_Load(object sender, EventArgs e)
        {
            if (Database.IsFetched)
            {
                UpdateLocalization();
            }
            else
            {
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Connexion_Non_Etablie);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void Form_AddJob_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_showConfirmationMessage)
            {
                Language.Changed -= (s, args) => this.UpdateLocalization();
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_description.Text.Trim()))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Description_Obligatoire);
                    textBox_description.Focus();
                }
                else if (Database.Jobs.HasRowsWhere("Description = '{0}'", textBox_description.Text.Trim()))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Description_Double);
                    textBox_description.SelectAll();
                    textBox_description.Focus();
                }
                else
                {
                    Database.Jobs.Table.Rows.Add(null, textBox_description.Text);
                    Database.Jobs.ApplyChanges();
                    if (_showConfirmationMessage)
                    {
                        QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Travail_Ajouté);
                    }
                    Database.Jobs.FetchTable();
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }
    }
}
