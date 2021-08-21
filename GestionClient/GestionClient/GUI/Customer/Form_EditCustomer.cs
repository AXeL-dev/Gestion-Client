using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using GestionClient.Localization;
using GestionClient.Properties;

namespace GestionClient
{
    public partial class Form_EditCustomer : Form
    {
        private DataTableNavigator _customersNavigator;
        private int _currentCustomerID;
        private DataView _paymentsDataView;

        public Form_EditCustomer()
        {
            InitializeComponent();
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            // Form
            this.Text = LocalizedStrings.Modifier_Client_Win_Name;

            // Group Boxes
            groupBox_customer.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            groupBox_photo.Text = LocalizedStrings.Ajouter_Client_Photo_GroupBox;
            groupBox_payement.Text = LocalizedStrings.Modifier_Client_Paiement_GroupBox;
            groupBox_newPayement.Text = LocalizedStrings.Modifier_Client_Nouveau_Paiement_GroupBox;
            groupBox_assets.Text = LocalizedStrings.Modifier_Client_Pieces_GroupBox;

            // Labels
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            label_job.Text = LocalizedStrings.Ajouter_Client_Travail_Label;
            label_birthDate.Text = LocalizedStrings.Ajouter_Client_Date_Naissance_Label;
            label_phoneNumber.Text = LocalizedStrings.Ajouter_Client_Numero_Tel_Label;
            label_email.Text = LocalizedStrings.Ajouter_Client_Email_Label;
            label_amount.Text = LocalizedStrings.Modifier_Client_Montant_Label;
            label_payementDate.Text = LocalizedStrings.Modifier_Client_Date_Paiement_Label;

            // Tool Tip
            toolTip_main.SetToolTip(button_removeAsset, LocalizedStrings.Modifier_Client_Supprimer_Piece_ToolTip);
            toolTip_main.SetToolTip(button_addAsset, LocalizedStrings.Modifier_Client_Ajouter_Piece_ToolTip);

            // Buttons
            button_next.Text = LocalizedStrings.Modifier_Client_Suivant_Button;
            button_previous.Text = LocalizedStrings.Modifier_Client_Précédent_Button;
            button_update.Text = LocalizedStrings.Modifier_Client_Modifier_Button;
            button_remove.Text = LocalizedStrings.Modifier_Client_Supprimer_Button;
            button_search.Text = LocalizedStrings.Modifier_Client_Rechercher_Button;
            button_changePhoto.Text = LocalizedStrings.Modifier_Client_Modifier_Button;
            button_savePayement.Text = LocalizedStrings.Modifier_Client_Enregistrer_Paiement_Button;

            // Data Grid View
            if (dataGridView_payements.Columns.Count > 0)
            {
                dataGridView_payements.Columns["Amount"].HeaderText = LocalizedStrings.Modifier_Client_DataGridView_Montant_Column;
                dataGridView_payements.Columns["PaymentDate"].HeaderText = LocalizedStrings.Modifier_Client_DataGridView_Date_Paiement_Column;
                DataGridViewColumnFormat.Number(dataGridView_payements, "Amount",
                    LocalizedStrings.Modifier_Client_DataGridView_Montant_Column_Devise);
            }

            // Open File Dialog
            openFileDialog_main.Title = LocalizedStrings.openFileDialog_Title;
        }

        private void DisplayCurrentCustomer()
        {
            _currentCustomerID = Convert.ToInt32(_customersNavigator.Current["ID"]);
            textBox_name.Text = _customersNavigator.Current["FullName"].ToString();
            comboBox_job.SelectedValue = _customersNavigator.Current["JobID"];
            maskedTextBox_birthDate.Text = _customersNavigator.Current["BirthDate"].ToString();
            maskedTextBox_phoneNumber.Text = _customersNavigator.Current["Phone"].ToString();
            textBox_email.Text = _customersNavigator.Current["Email"].ToString();
            _paymentsDataView.RowFilter = string.Format("CustomerID = {0}", _currentCustomerID);
            DisplayCurrentCustomerPhoto();
            DisplayAssets();
        }

        private void DisplayCurrentCustomerPhoto()
        {
            ImageAsset imageAsset = Assets.GetFirst(_currentCustomerID, "Photo");
            if (imageAsset != null)
            {
                pictureBox_photo.Image = imageAsset.Image;
                pictureBox_photo.Tag = imageAsset.FilePath;
            }
            else
            {
                string gender = _customersNavigator.Current["Gender"].ToString();
                pictureBox_photo.InitialImage = gender == "m" ? Resources.man : Resources.woman;
            }
        }

        private void DisplayAssets()
        {
            ImageAsset[] assets = Assets.Get(_currentCustomerID, "Other");
            picturesTableLayoutPanel_assets.Clear();
            picturesTableLayoutPanel_assets.AddImageAssetsRange(assets);
        }

        private void UpdateAsset(string newPath, int assetIndex)
        {
            // on récupère le chemin ou on va pouvoir stocker l'image
            string assetFolderPath = Assets.RootFolderPath
                + "\\" + _currentCustomerID + "_" + textBox_name.Text;
            // on récupère le nom de l'image
            string assetFileName = newPath.Remove(0, newPath.LastIndexOf('\\') + 1);
            // on copie l'image dans le répertoire de notre base de données
            string destinationFileName = assetFolderPath
                + "\\" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + "_" + assetFileName;
            File.Copy(newPath, destinationFileName, true);
            // suppression de l'ancienne image de notre base de données
            string oldImage = Database.Assets.Table.Rows[assetIndex]["FileName"].ToString();
            if (File.Exists(oldImage))
                File.Delete(oldImage);
            // on modifie l'emplacement de la pièce et on applique les changements à la Table Pieces
            Database.Assets.Table.Rows[assetIndex]["FileName"] = destinationFileName;
            Database.Assets.ApplyChanges();
        }
        #endregion

        private void Form_EditCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= (s, args) => this.UpdateLocalization();
        }

        private void Form_EditCustomer_Load(object sender, EventArgs e)
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

                    _customersNavigator = new DataTableNavigator(Database.Customers.Table);
                    _paymentsDataView = new DataView(Database.Payments.Table);
                    dataGridView_payements.DataSource = _paymentsDataView;
                    dataGridView_payements.Columns["ID"].Visible = false;
                    dataGridView_payements.Columns["CustomerID"].Visible = false;
                    dataGridView_payements.Columns["Amount"].Width = 200;
                    dataGridView_payements.Columns["PaymentDate"].Width = 200;
                    dataGridView_payements.Columns.Add(new DeleteButtonColumn());

                    pictureBox_photo.InitialImage = Resources.load;
                    button_next.Select();
                    DisplayCurrentCustomer();
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

        private void button_next_Click(object sender, EventArgs e)
        {
            _customersNavigator.MoveNext();
            DisplayCurrentCustomer();
        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            _customersNavigator.MoveNext();
            DisplayCurrentCustomer();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_name.Text.Trim()))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                    textBox_name.Focus();
                }
                else if (Database.Customers.HasRowsWhere("FullName = '{0}'", textBox_name.Text.Trim())
                    && !_customersNavigator.HasCurrent("FullName", textBox_name.Text.Trim()))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_D_un_Autre_Client);
                    textBox_name.SelectAll();
                    textBox_name.Focus();
                }
                else
                {
                    _customersNavigator.Current["FullName"] = textBox_name.Text.Trim();
                    _customersNavigator.Current["JobID"] = comboBox_job.SelectedValue;
                    if (maskedTextBox_birthDate.MaskCompleted)
                        _customersNavigator.Current["BirthDate"] = maskedTextBox_birthDate.Text;
                    _customersNavigator.Current["Phone"] = maskedTextBox_phoneNumber.Text.Replace(" ", string.Empty);
                    _customersNavigator.Current["Email"] = textBox_email.Text;
                    Database.Customers.ApplyChanges();
                    QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Client_Modifié);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            try
            {
                if (QuickMessageBox.ShowQuestion(
                    LocalizedStrings.MessageBox_Confirmer_Suppression_Client) == DialogResult.Yes)
                {
                    _customersNavigator.Current.Delete();
                    Database.Customers.ApplyChanges();
                    Assets.RemoveAll(_customersNavigator.Current);
                    if (Database.Customers.IsEmpty)
                    {
                        QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Client_Supprimé_Plus_Fermeture);
                        this.Close();
                    }
                    else
                    {
                        button_previous.PerformClick();
                        QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Client_Supprimé);
                    }
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            Form_SearchCustomer form_searchCustomer = new Form_SearchCustomer();
            form_searchCustomer.ShowDialog();
            if (form_searchCustomer.SearchResultIndex != _customersNavigator.Position)
            {
                _customersNavigator.Position = form_searchCustomer.SearchResultIndex;
                DisplayCurrentCustomer();
            }
        }

        private void pictureBox_photo_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox_photo.Image != null)
                {
                    Process.Start(pictureBox_photo.Tag as string);
                }
                else
                {
                    throw new Exception(LocalizedStrings.MessageBox_Client_Sans_Photo);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void button_savePayement_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(maskedTextBox_amount.Text))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Montant_Obligatoire);
                    maskedTextBox_amount.Focus();
                }
                else
                {
                    Database.Payments.Table.Rows.Add(null, _customersNavigator.Current["ID"],
                        maskedTextBox_amount.Text, dateTimePicker_payementDate.Value);
                    Database.Payments.ApplyChanges();
                    Database.Payments.FetchTable();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void button_removeAsset_Click(object sender, EventArgs e)
        {
            try
            {
                if (picturesTableLayoutPanel_assets.IsEmpty)
                {
                    throw new Exception(LocalizedStrings.MessageBox_Aucune_Piece);
                }
                else
                {
                    if (picturesTableLayoutPanel_assets.SelectedImageAsset != null)
                    {
                        if (QuickMessageBox.ShowQuestion(
                            LocalizedStrings.MessageBox_Confirmer_Suppression_Piece) == DialogResult.Yes)
                        {
                            picturesTableLayoutPanel_assets.RemoveSelectedImageAsset();
                            Assets.Remove(picturesTableLayoutPanel_assets.SelectedImageAsset);
                            DisplayAssets();
                        }
                    }
                    else
                    {
                        QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Selectionner_Piece);
                    }
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void button_addAsset_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog_main.ShowDialog() == DialogResult.OK)
                {
                    Assets.Add(openFileDialog_main.FileName, _currentCustomerID, "Other");
                    DisplayAssets();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        private void dataGridView_payements_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_payements.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                try
                {
                    if (QuickMessageBox.ShowQuestion(
                        LocalizedStrings.MessageBox_Confirmer_Suppression_Paiement)
                        == DialogResult.Yes)
                    {
                        int paymentID = Convert.ToInt32(dataGridView_payements.Rows[e.RowIndex].Cells["ID"].Value);
                        var paymentRow = Database.Payments.GetFirstRowWhere("ID = {0}", paymentID);
                        if (paymentRow != null)
                        {
                            paymentRow.Delete();
                            Database.Payments.ApplyChanges();
                        }
                    }
                }
                catch (Exception exception)
                {
                    QuickMessageBox.ShowError(exception.Message);
                }
            }
        }

        private void button_changePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog_main.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox_photo.ImageLocation == null)
                    {
                        Assets.Add(openFileDialog_main.FileName, _currentCustomerID, "Photo");
                    }
                    else
                    {
                        UpdateAsset(openFileDialog_main.FileName, Convert.ToInt32(pictureBox_photo.Tag));
                    }

                    // on affiche la nouvelle Photo
                    pictureBox_photo.ImageLocation = Database.Assets.Table.Rows[Convert.ToInt32(pictureBox_photo.Tag)]["FileName"].ToString();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }
    }
}
