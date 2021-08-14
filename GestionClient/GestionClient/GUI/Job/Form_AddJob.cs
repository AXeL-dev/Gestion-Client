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
            Language.Changed += (s, e) => UpdateLocalization();
        }

        private void UpdateLocalization()
        {
            this.Text = LocalizedStrings.Ajouter_Travail_Win_Name;
            groupBox_job.Text = LocalizedStrings.Ajouter_Travail_1st_GroupBox;
            label_description.Text = LocalizedStrings.Ajouter_Travail_1st_Label;
            button_add.Text = LocalizedStrings.Ajouter_Travail_Ajouter_Button;
        }

        /// <summary>
        /// Checks if a job already exists.
        /// </summary>
        /// <param name="Description"></param>
        /// <returns>True if job exists.</returns>
        private bool GetJobExists(string description)
        {
            for (int i = 0; i < Database.Jobs.Table.Rows.Count; i++)
            {
                if (Database.Jobs.Table.Rows[i]["Description"].ToString().ToUpper() == description.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }
            return false;
        }

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

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_description.Text))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Description_Obligatoire);
                    textBox_description.Focus();
                }
                else if (GetJobExists(textBox_description.Text))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Description_Double);
                    textBox_description.SelectAll();
                    textBox_description.Focus();
                }
                else // si nn, c'est bon
                {
                    // ajout du travail
                    Database.Jobs.Table.Rows.Add(null, textBox_description.Text);
                    Database.Jobs.ApplyChanges();
                    if (_showConfirmationMessage)
                        QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Travail_Ajouté);
                    // mise à jour de la dataTable Travail (pour avoir les bon ids)
                    Database.Jobs.FetchTable();
                    // fermeture de la fenêtre
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }


        // event. FormClosed du formulaire
        private void AjouterTravail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_showConfirmationMessage) // si l'appel a été fait par la fenêtre mère et non une autre fenêtre comme AjouterClient
            {
                Language.Changed -= (s, args) => UpdateLocalization();
            }
        }
    }
}
