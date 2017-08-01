using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

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
                if (ClassGlobal.isConnectedToDb) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (ClassGlobal.ds.Tables["Client"].Rows.Count == 0)
                        throw new Exception(ClassGlobal.resManager.GetString("MessageBox_Aucun_Client", ClassGlobal.cul));

                    // remplissage de la combobox 'TravailCombo'
                    TravailCombo.DataSource = ClassGlobal.ds.Tables["Travail"];
                    TravailCombo.DisplayMember = "description";
                    TravailCombo.ValueMember = "id";

                    // on récupère la dataTable ClientTravailPaiement
                    ClassGlobal.getClientTravailPaiement();

                    // on crée un DataView pour pouvoir filtrer
                    dv = new DataView(ClassGlobal.ds.Tables["ClientTravailPaiement"]);

                    // font/police de la dataGridView
                    dataGridView1.Font = new Font("Times New Roman", 11.0F, FontStyle.Italic);

                    // remplissage de la dataGridView
                    dataGridView1.DataSource = dv;
                    setDataGridViewFormat();

                    // on remplace les valeurs null par '-'
                    dataGridView1.DefaultCellStyle.NullValue = "-";

                    // on change la langue si l'arabe est séléctionné
                    if (ClassGlobal.getDefaultLanguage() == "ar")
                        switchLanguage();
                }
                else
                {
                    throw new Exception(ClassGlobal.resManager.GetString("MessageBox_Connexion_Non_Etablie", ClassGlobal.cul));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. FormClosed du formulaire
        private void ListeClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClassGlobal.isListeClientsOpened = false;
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
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
            }
        }

        // event. PrintPage de 'printDocument1'
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintDataGridView.printDataGridViewPage(e, dataGridView1, ClassGlobal.resManager.GetString("Liste_Client_Win_Name", ClassGlobal.cul));
        }

        // event. Click sur le boutton 'ActualiserBtn'
        private void ActualiserBtn_Click(object sender, EventArgs e)
        {
            ClassGlobal.getClientTravailPaiement();
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
                MessageBox.Show(ex.Message, ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, ClassGlobal.msgBoxOptions);
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
            dataGridView1.Columns["nom"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Nom", ClassGlobal.cul);
            dataGridView1.Columns["sexe"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Sexe", ClassGlobal.cul);
            dataGridView1.Columns["travail"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Travail", ClassGlobal.cul);
            dataGridView1.Columns["age"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Age", ClassGlobal.cul);
            dataGridView1.Columns["date de naissance"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Date_Naissance", ClassGlobal.cul);
            dataGridView1.Columns["numéro tél"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Numero_Tel", ClassGlobal.cul);
            dataGridView1.Columns["email"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Email", ClassGlobal.cul);
            dataGridView1.Columns["montant payé"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Montant_Payé", ClassGlobal.cul);
            dataGridView1.Columns["ajouté le"].HeaderText = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Ajouté_Le", ClassGlobal.cul);

            // ajout de 'ans' dans toutes les lignes de la colonne 'age'
            NumberFormatInfo formatAge = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatAge.CurrencySymbol = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Age_Devise", ClassGlobal.cul);
            formatAge.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["age"].DefaultCellStyle.FormatProvider = formatAge;
            dataGridView1.Columns["age"].DefaultCellStyle.Format = "c";

            // ajout de la devise dans toutes les lignes de la colonne 'montant payé'
            NumberFormatInfo formatMontant = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            formatMontant.CurrencySymbol = ClassGlobal.resManager.GetString("Liste_Client_DataGridView_Column_Montant_Payé_Devise", ClassGlobal.cul);
            formatMontant.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.FormatProvider = formatMontant;
            dataGridView1.Columns["montant payé"].DefaultCellStyle.Format = "c";
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = ClassGlobal.resManager.GetString("Liste_Client_Win_Name", ClassGlobal.cul);
            // Labels et GroupBoxs
            FiltrerClientGroupBox.Text = ClassGlobal.resManager.GetString("Liste_Client_Filtrer_GroupBox", ClassGlobal.cul);
            NomLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Nom_Label", ClassGlobal.cul);
            TravailLabel.Text = ClassGlobal.resManager.GetString("Ajouter_Client_Travail_Label", ClassGlobal.cul);
            FiltrerTravailCheckBox.Text = ClassGlobal.resManager.GetString("Liste_Client_Filtrer_CheckBox", ClassGlobal.cul);
            ListeClientGroupBox.Text = ClassGlobal.resManager.GetString("Liste_Client_Liste_GroupBox", ClassGlobal.cul);
            // Buttons
            ActualiserBtn.Text = ClassGlobal.resManager.GetString("Liste_Client_Actualiser_Button", ClassGlobal.cul);
            ImprimerBtn.Text = ClassGlobal.resManager.GetString("Liste_Client_Imprimer_Button", ClassGlobal.cul);
            // format de la DataGridView
            setDataGridViewFormat();
        }
    }
}
