using System;
using System.IO;
using System.Windows.Forms;
using GestionClient.Localization;
using GestionClient.Properties;

namespace GestionClient
{
    public partial class Form_AddCustomer : Form
    {
        private Form_AddJob _form_addJob;
        private bool _photoLoaded = false;

        public Form_AddCustomer()
        {
            InitializeComponent();
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            // Form
            this.Text = LocalizedStrings.Ajouter_Client_Win_Name;

            // Group Boxes
            groupBox_customer.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            groupBox_photo.Text = LocalizedStrings.Ajouter_Client_Photo_GroupBox;

            // Labels
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            label_gender.Text = LocalizedStrings.Ajouter_Client_Sexe_Label;
            label_job.Text = LocalizedStrings.Ajouter_Client_Travail_Label;
            label_birthDate.Text = LocalizedStrings.Ajouter_Client_Date_Naissance_Label;
            label_phoneNumber.Text = LocalizedStrings.Ajouter_Client_Numero_Tel_Label;
            label_email.Text = LocalizedStrings.Ajouter_Client_Email_Label;

            // Lists
            comboBox_gender.Items[0] = LocalizedStrings.Sexe_Homme;
            comboBox_gender.Items[1] = LocalizedStrings.Sexe_Femme;

            // Buttons
            button_newJob.Text = LocalizedStrings.Ajouter_Client_Nouveau_Travail_Button;
            button_selectPhoto.Text = LocalizedStrings.Ajouter_Client_Ajouter_Modifier_Photo_Button;
            button_add.Text = LocalizedStrings.Ajouter_Client_Ajouter_Button;

            // Open File Dialog
            openFileDialog_main.Title = LocalizedStrings.openFileDialog_Title;
        }
        #endregion

        private void Form_AddCustomer_Load(object sender, EventArgs e)
        {
            if (Database.IsFetched)
            {
                comboBox_gender.SelectedIndex = 0;
                comboBox_job.DataSource = Database.Jobs.Table;
                comboBox_job.DisplayMember = "Description";
                comboBox_job.ValueMember = "ID";
                UpdateLocalization();
            }
            else
            {
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Connexion_Non_Etablie);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void AjouterClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= (s, args) => this.UpdateLocalization();
        }

        private void comboBox_gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_photoLoaded)
            {
                if (comboBox_gender.SelectedIndex == 0)
                {
                    pictureBox_photo.Image = Resources.man;
                }
                else
                {
                    pictureBox_photo.Image = Resources.woman;
                }
            }
        }

        private void button_selectPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog_main.ShowDialog() == DialogResult.OK)
            {
                pictureBox_photo.ImageLocation = openFileDialog_main.FileName;
                _photoLoaded = true;
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_name.Text.Trim()))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                    textBox_name.Focus();
                }
                else if (Database.Customers.HasRowsWhere("FullName = '{0}'", textBox_name.Text.Trim()))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Double);
                    textBox_name.SelectAll();
                    textBox_name.Focus();
                }
                else if (comboBox_job.Items.Count == 0)
                {
                    button_newJob.PerformClick();
                }
                else
                {
                    string birthDate = string.Empty;
                    if (maskedTextBox_birthDate.MaskCompleted)
                    {
                        birthDate = maskedTextBox_birthDate.Text;
                    }
                    Database.Customers.Table.Rows.Add(
                        null, textBox_name.Text.Trim(), comboBox_gender.Text,
                        comboBox_job.SelectedValue, birthDate,
                        maskedTextBox_phoneNumber.Text.Replace(" ", string.Empty),
                        textBox_email.Text, DateTime.Now.ToString());
                    Database.Customers.ApplyChanges();
                    Database.Customers.FetchTable();

                    if (_photoLoaded)
                    {
                        var customerRow = Database.Customers.GetFirstRowWhere("FullName = '{0}'", textBox_name.Text.Trim());
                        string customerAssetsSubfolder = Assets.CreateSubfolder(customerRow);
                        string photoFilePath = Assets.CreateFile(pictureBox_photo.ImageLocation, customerAssetsSubfolder);
                        int customerID = Convert.ToInt32(customerRow["ID"]);
                        Database.Assets.Table.Rows.Add(null, customerID, photoFilePath, "Photo");
                        Database.Assets.ApplyChanges();
                        Database.Assets.FetchTable();
                    }

                    QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Client_Ajouté);
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void button_newJob_Click(object sender, EventArgs e)
        {
            int jobsCount = comboBox_job.Items.Count;
            if (_form_addJob == null || _form_addJob.IsDisposed)
            {
                _form_addJob = new Form_AddJob(false);
            }
            _form_addJob.ShowDialog();
            if (comboBox_job.Items.Count > jobsCount)
            {
                comboBox_job.SelectedIndex = comboBox_job.Items.Count - 1;
            }
        }
    }
}
