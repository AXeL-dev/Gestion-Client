using System;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_SearchCustomer : Form
    {
        public int SearchResultIndex { get; private set; }

        public Form_SearchCustomer()
        {
            InitializeComponent();
            this.SearchResultIndex = -1;
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            this.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            this.Text = LocalizedStrings.Rechercher_Client_Win_Name;
            groupBox_customer.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            button_search.Text = LocalizedStrings.Rechercher_Client_Rechercher_Button;
        }
        #endregion

        private void Form_SearchCustomer_Load(object sender, EventArgs e)
        {
            UpdateLocalization();
        }

        private void Form_SearchCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= (s, args) => this.UpdateLocalization();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_name.Text.Trim()))
            {
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                textBox_name.Focus();
            }
            else
            {
                int customerRowIndex = Database.Customers.GetRowIndexWhere("FullName LIKE '{0}%'", textBox_name.Text.Trim());
                if (customerRowIndex != -1)
                {
                    this.SearchResultIndex = customerRowIndex;
                    this.Close();
                    return;
                }
                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Client_Non_trouvé);
            }
        }
    }
}
