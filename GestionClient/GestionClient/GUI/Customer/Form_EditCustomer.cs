using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_EditCustomer : Form
    {
        private int _position = 0;
        private int _currentCustomerID;
        private List<PictureBox> _assetsPictureBoxes = new List<PictureBox>();
        private DataView _dataView;

        public Form_EditCustomer()
        {
            InitializeComponent();
            Language.Changed += this.LanguageChangedHandler;
        }

        // event. FormClosed du formulaire
        private void ListeClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= this.LanguageChangedHandler;
        }

        // event. Load du formulaire
        private void ListeClients_Load(object sender, EventArgs e)
        {
            try
            {
                if (Database.IsFetched) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (Database.Customers.Table.Rows.Count == 0)
                        throw new Exception(LocalizedStrings.MessageBox_Aucun_Client);

                    // remplissage de la combobox 'TravailCombo'
                    comboBox_job.DataSource = Database.Jobs.Table;
                    comboBox_job.DisplayMember = "Description";
                    comboBox_job.ValueMember = "ID";

                    // initialisation du DataView
                    _dataView = new DataView(Database.Payments.Table);
                    // affichage du DataView dans la DataGridView
                    dataGridView_payements.DataSource = _dataView;
                    dataGridView_payements.Columns["ID"].Visible = dataGridView_payements.Columns["CustomerID"].Visible = false;
                    setDataGridviewFormat();
                    // ajout des bouttons supprimer dans la dataGridView des paiements
                    DeleteButtonColumn supprimerPaiementBtnColumn = new DeleteButtonColumn();
                    dataGridView_payements.Columns.Add(supprimerPaiementBtnColumn);

                    // image initiale de la pictureBox1 (La photo)
                    pictureBox_photo.InitialImage = GestionClient.Properties.Resources.load;

                    // on affiche le premier client
                    move();

                    // on séléctionne le boutton 'Suivant'
                    button_next.Select();

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

        // event. Click on boutton 'Suivant'
        private void SuivantBtn_Click(object sender, EventArgs e)
        {
            // on avance
            _position++;
            if (_position > Database.Customers.Table.Rows.Count - 1)
                _position = Database.Customers.Table.Rows.Count - 1;
            // on affiche le client
            move();
        }

        // event. Click on boutton 'Précédent'
        private void PrécédentBtn_Click(object sender, EventArgs e)
        {
            // on retourne au précédent
            _position--;
            if (_position < 0)
                _position = 0;
            // on affiche le client
            move();
        }

        // event. Click on boutton 'Modifier'
        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si le nom est vide
                if (textBox_name.Text.Length == 0)
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_Obligatoire);
                    textBox_name.Focus();
                }
                // si nn si nom en double
                else if (checkDoubleClientNameNotCurrent(textBox_name.Text, _position))
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Nom_D_un_Autre_Client);
                    //NomTextBox.Text = ""; // on vide le textbox du nom
                    textBox_name.SelectAll(); // on séléctionne le nom au cas l'utilisateur veut bien le supprimer
                    textBox_name.Focus();
                }
                else // si nn, c'est bon
                {
                    // on parcourt la dataTable Client
                    for (int i = 0; i < Database.Customers.Table.Rows.Count; i++)
                    {
                        // si clé primaire trouvée
                        if (Convert.ToInt32(Database.Customers.Table.Rows[i]["ID"]) == _currentCustomerID)
                        {
                            // modification
                            Database.Customers.Table.Rows[_position]["FullName"] = textBox_name.Text;
                            Database.Customers.Table.Rows[_position]["JobID"] = comboBox_job.SelectedValue;
                            if (maskedTextBox_birthDate.MaskCompleted)
                                Database.Customers.Table.Rows[_position]["BirthDate"] = maskedTextBox_birthDate.Text;
                            Database.Customers.Table.Rows[_position]["Phone"] = maskedTextBox_phoneNumber.Text.Replace(" ", string.Empty);
                            Database.Customers.Table.Rows[_position]["Email"] = textBox_email.Text;
                            Database.Customers.ApplyChanges();
                            QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Client_Modifié);
                            break; // on sort de la boucle
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. Click on boutton 'Supprimer'
        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (QuickMessageBox.ShowQuestion(LocalizedStrings.MessageBox_Confirmer_Suppression_Client) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Client
                    for (int i = 0; i < Database.Customers.Table.Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (Convert.ToInt32(Database.Customers.Table.Rows[i]["ID"]) == _currentCustomerID)
                        {
                            // suppression du client
                            Database.Customers.Table.Rows[i].Delete();
                            Database.Customers.ApplyChanges();
                            // suppression du dossier du client (!@ avec tout son contenu)
                            string clientFolderName = Assets.RootFolderPath + "\\" + _currentCustomerID + "_" + textBox_name.Text;
                            if (Directory.Exists(clientFolderName))
                                Directory.Delete(clientFolderName, true);
                            // si on peu faire un retour en arrière
                            if (Database.Customers.Table.Rows.Count > 0)
                            {
                                // on revient en arrière (simulation d'un click sur 'Précédent')
                                PrécédentBtn_Click(sender, e);
                                QuickMessageBox.ShowInformation(LocalizedStrings.MessageBox_Client_Supprimé);
                            }
                            else
                            {
                                QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Client_Supprimé_Plus_Fermeture);
                                this.Close();
                            }
                            break; // on sort de la boucle for
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. Click on boutton 'Rechercher'
        private void RechercherBtn_Click(object sender, EventArgs e)
        {
            // on affecte la position actuelle à 'searchFoundedPosition' de la ClassGlobal
            App.SearchResultIndex = _position;
            // on affiche la fenêtre de recherche
            Form fen = new Form_SearchCustomer();
            fen.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;
            fen.ShowDialog();
            // on affiche le client trouvé, si trouvé biensur
            if (App.SearchResultIndex != _position)
            {
                _position = App.SearchResultIndex;
                move();
            }
        }

        // event. Click sur la 'PictureBox1'
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showImage((PictureBox)sender);
        }

        // event. Click sur le boutton 'EnregistrerPaiementBtn'
        private void EnregistrerPaiementBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si le montant est vide
                if (maskedTextBox_amount.Text.Length == 0)
                {
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Montant_Obligatoire);
                    maskedTextBox_amount.Focus();
                }
                else // si nn, c'est bon
                {
                    // ajout du paiement
                    Database.Payments.Table.Rows.Add(null, Database.Customers.Table.Rows[_position]["ID"], maskedTextBox_amount.Text, dateTimePicker_payementDate.Value);
                    Database.Payments.ApplyChanges();
                    //QuickMessageBox.Show("Paiement enregistré !", ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // mise à jour de la dataTable Paiement (pour avoir les bon ids, afin de pouvoir supprimer un paiement)
                    Database.Payments.FetchTable();
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. pictureBoxsSingle_Click (utilisé pour les pieces pictureboxs)
        private void pictureBoxsSingle_Click(object sender, EventArgs e)
        {
            // on rend à l'état normal toutes les picturesboxs des pieces
            foreach (PictureBox pictureBox in _assetsPictureBoxes)
            {
                pictureBox.BackColor = SystemColors.Control;
                pictureBox.Padding = new Padding(0);
            }

            // on séléctionne/met une bordure bleu sur la pictureBoxs/la piece sur laquelle on vien de clicker
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = SystemColors.Highlight;
            pb.Padding = new Padding(3);
        }

        // event. Click sur le boutton 'SupprimerPiece'
        private void SupprimerPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // s'il n'y a aucune pièce
                if (_assetsPictureBoxes.Count == 0)
                    throw new Exception(LocalizedStrings.MessageBox_Aucune_Piece);
                else // si nn
                {
                    // on parcourt toutes les pieces
                    for (int i = 0; i < _assetsPictureBoxes.Count; i++)
                    {
                        // si on trouve qu'une piece est séléctionnée
                        if (_assetsPictureBoxes[i].BackColor == SystemColors.Highlight && _assetsPictureBoxes[i].Padding.All == 3)
                        {
                            if (QuickMessageBox.ShowQuestion(LocalizedStrings.MessageBox_Confirmer_Suppression_Piece) == DialogResult.Yes)
                            {
                                // on parcourt la dataTable 'Pieces'
                                for (int p = 0; p < Database.Assets.Table.Rows.Count; p++)
                                {
                                    // si on trouve que la clé primaire (id) == tag de l'image ou on a sauvegardé l'id nous aussi
                                    if (Database.Assets.Table.Rows[p]["ID"].ToString() == _assetsPictureBoxes[i].Tag.ToString())
                                    {
                                        // suppression de l'image
                                        File.Delete(_assetsPictureBoxes[i].ImageLocation);
                                        // suppression de la piece de la table 'Pieces'
                                        Database.Assets.Table.Rows[p].Delete();
                                        Database.Assets.ApplyChanges();
                                        // raffraichissement des pieces
                                        showPieces(_currentCustomerID);
                                        break; // on sort de la 2ème boucle
                                    }
                                }
                            }

                            // on sort de la fonction
                            return;
                        }
                    }

                    // si nn, aucune piece n'est séléctionnée
                    QuickMessageBox.ShowWarning(LocalizedStrings.MessageBox_Selectionner_Piece);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. Click sur le boutton 'AjouterPieceBtn'
        private void AjouterPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog_main.ShowDialog() == DialogResult.OK)
                {
                    // ajout de la pièce
                    addPieceAs(openFileDialog_main.FileName, "Autre");
                    // raffraichissement des pieces
                    showPieces(_currentCustomerID);
                }
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // event. CellContentClick de la Paiement dataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            // si click sur un des bouttons supprimerPaiement
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                try
                {
                    if (QuickMessageBox.ShowQuestion(LocalizedStrings.MessageBox_Confirmer_Suppression_Paiement) == DialogResult.Yes)
                    {
                        // on récupère l'id du paiement séléctionné
                        int paiementId = Convert.ToInt32(dataGridView_payements.Rows[e.RowIndex].Cells["ID"].Value);

                        // on boucle sur la dataTable Paiement
                        for (int i = 0; i < Database.Payments.Table.Rows.Count; i++)
                        {
                            // si clé primaire trouvé
                            if (Convert.ToInt32(Database.Payments.Table.Rows[i]["ID"]) == paiementId)
                            {
                                // suppression du paiement
                                Database.Payments.Table.Rows[i].Delete();
                                Database.Payments.ApplyChanges();
                                break; // on sort de la boucle for
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    QuickMessageBox.ShowError(exception.Message);
                }
            }
        }

        // event. Click sur le boutton 'ModifierPhotoBtn'
        private void ModifierPhotoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog_main.ShowDialog() == DialogResult.OK)
                {
                    // si le client n'a pas de Photo
                    if (pictureBox_photo.ImageLocation == null)
                    {
                        // ajout de la pièce en tant que Photo
                        addPieceAs(openFileDialog_main.FileName, "Photo");
                        // on défini le Tag de la dernière image ajoutée, Dans notre cas (le client n'a pas de photo) le Tag est obligatoire, ou on aura une erreur lors de la modification
                        pictureBox_photo.Tag = Database.Assets.Table.Rows.Count - 1; // rappelez-vous le Tag sert à nous simplifier la modification de la Photo
                    }
                    // si nn, le client a déjà une photo, on la modifie
                    else
                    {
                        updatePiece(openFileDialog_main.FileName, Convert.ToInt32(pictureBox_photo.Tag));
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

        //============================================================================================================
        //                                                Méthodes
        //============================================================================================================

        // move() : gère les déplacements des clients
        private void move()
        {
            _currentCustomerID = Convert.ToInt32(Database.Customers.Table.Rows[_position]["ID"]);
            setImage(_currentCustomerID);
            textBox_name.Text = Database.Customers.Table.Rows[_position]["FullName"].ToString();
            comboBox_job.SelectedValue = Database.Customers.Table.Rows[_position]["JobID"];
            maskedTextBox_birthDate.Text = Database.Customers.Table.Rows[_position]["BirthDate"].ToString();
            maskedTextBox_phoneNumber.Text = Database.Customers.Table.Rows[_position]["Phone"].ToString();
            textBox_email.Text = Database.Customers.Table.Rows[_position]["Email"].ToString();
            showPaiement(_currentCustomerID);
            showPieces(_currentCustomerID);
        }

        // setImage() : affiche l'image du client
        private void setImage(int clientId)
        {
            // on parcourt la dataTable 'Pieces'
            for (int i = 0; i < Database.Assets.Table.Rows.Count; i++)
            {
                // si on trouve que le client à une photo
                if (Convert.ToInt32(Database.Assets.Table.Rows[i]["CustomerID"]) == clientId && Database.Assets.Table.Rows[i]["AssetType"].ToString() == "Photo")
                {

                    pictureBox_photo.Image = Assets.Get(clientId, "Photo");
                    pictureBox_photo.Tag = i; // on utilisera le Tag pour simplifier la modification de la Photo
                    return;
                }
            }

            // si nn
            string sexe = Database.Customers.Table.Rows[_position]["Gender"].ToString();

            if (sexe == "Homme" || sexe == "ذكر") // si c'est un 'Homme'
                pictureBox_photo.Image = GestionClient.Properties.Resources.man;
            else // si nn, une 'Femme' alors
                pictureBox_photo.Image = GestionClient.Properties.Resources.woman;

            pictureBox_photo.ImageLocation = null; // à ne pas oublier
        }

        // showImage() : affiche l'image avec le programme de visionnement par défaut
        private void showImage(PictureBox pb)
        {
            try
            {
                if (pb.ImageLocation != null)
                    Process.Start(pb.ImageLocation);
                else
                    throw new Exception(LocalizedStrings.MessageBox_Client_Sans_Photo);
            }
            catch (Exception exception)
            {
                QuickMessageBox.ShowError(exception.Message);
            }
        }

        // showPaiement() : affiche les paiements du client
        private void showPaiement(int clientId)
        {
            // filtrage
            _dataView.RowFilter = "CustomerID = " + clientId;
        }

        // setDataGridviewFormat() : applique les changements de format nécéssaires à la DataGridView
        private void setDataGridviewFormat()
        {
            // montant
            dataGridView_payements.Columns["Amount"].HeaderText = LocalizedStrings.Modifier_Client_DataGridView_Montant_Column;
            dataGridView_payements.Columns["Amount"].Width = 200;
            NumberFormatInfo format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = LocalizedStrings.Modifier_Client_DataGridView_Montant_Column_Devise; ;
            format.CurrencyDecimalDigits = 0;
            dataGridView_payements.Columns["Amount"].DefaultCellStyle.FormatProvider = format;
            dataGridView_payements.Columns["Amount"].DefaultCellStyle.Format = "c";
            // date paiement
            dataGridView_payements.Columns["PaymentDate"].HeaderText = LocalizedStrings.Modifier_Client_DataGridView_Date_Paiement_Column;
            dataGridView_payements.Columns["PaymentDate"].Width = 200;
        }

        // showPieces() : affiche les pieces du client
        private void showPieces(int clientId)
        {
            // filtrage
            //DataView dv = new DataView(ClassGlobal.ds.Tables["Assets"]);
            //dv.RowFilter = "CustomerID = " + clientId + "AND AssetType = 'Autre'";
            DataRow[] drs = Database.Assets.Table.Select("CustomerID = " + clientId + "AND AssetType = 'Autre'");

            // on vide le TableLayoutPanel
            tableLayoutPanel_assets.Controls.Clear();
            tableLayoutPanel_assets.ColumnStyles.Clear();
            tableLayoutPanel_assets.ColumnCount = 1;

            // on vide la liste des images/pictureboxs
            _assetsPictureBoxes.Clear();

            if (drs.Length > 0)
            {
                // on divise/tranche le TableLayoutPanel en partie égale selon le nombre d'image trouvé
                float pieceSize = (float)100 / drs.Length;
                tableLayoutPanel_assets.ColumnCount = drs.Length;

                // affichage
                for (int i = 0; i < drs.Length; i++)
                {
                    // création de l'image/la picturebox
                    PictureBox pb = new PictureBox();
                    pb.Tag = drs[i]["ID"].ToString(); // on sauvegarde l'id de la pièce, pour nous simplifier la suppression
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Cursor = Cursors.Hand;
                    pb.Dock = DockStyle.Fill;
                    pb.InitialImage = GestionClient.Properties.Resources.load;
                    //pb.ErrorImage = GestionClient.Properties.Resources._false;
                    pb.ImageLocation = drs[i]["FileName"].ToString();
                    pb.DoubleClick += pictureBox1_Click;
                    pb.Click += pictureBoxsSingle_Click;
                    // ajout à la liste des images/pictureboxs
                    _assetsPictureBoxes.Add(pb);
                    // ajout au TableLayoutPanel
                    tableLayoutPanel_assets.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pieceSize));
                    tableLayoutPanel_assets.Controls.Add(_assetsPictureBoxes[i], i, 0);
                }
            }
        }

        // checkDoubleClientNameNotCurrent(...) : vérifie si le nom du client entré existe déjà + ne prend pas en compte le client en cours (dont on change le nom)
        private bool checkDoubleClientNameNotCurrent(string name, int currentClientPosition)
        {
            for (int i = 0; i < Database.Customers.Table.Rows.Count; i++)
            {
                if (i != currentClientPosition && Database.Customers.Table.Rows[i]["FullName"].ToString().ToUpper() == name.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // addPieceAs(...) : ajoute la pièce spécifiée selon le type spécifié
        private void addPieceAs(string emplacementPiece, string typePiece)
        {
            // on récupère le chemin ou on va pouvoir stocker l'image
            string imageFolderName = Assets.RootFolderPath + "\\" + _currentCustomerID + "_";// +NomTextBox.Text;
            // on récupère le nom de l'image
            string imageFileName = emplacementPiece.Remove(0, emplacementPiece.LastIndexOf('\\') + 1);
            // on copie l'image dans le répertoire de notre base de données
            string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + "_" + imageFileName;
            File.Copy(emplacementPiece, destinationFileName, true);
            // on ajoute la photo en tant que Piece
            Database.Assets.Table.Rows.Add(null, _currentCustomerID, destinationFileName, typePiece);
            Database.Assets.ApplyChanges();
            // mise à jour de la dataTable 'Pieces' (pour avoir les bon ids des pièces)
            Database.Assets.FetchTable();
        }

        // updatePiece(...) : met à jour une pièce, en la copyant dans la bdd et en changeant son emplacement + suppression de l'ancienne
        private void updatePiece(string nouveauEmplacement, int pieceIndex)
        {
            // on récupère le chemin ou on va pouvoir stocker l'image
            string imageFolderName = Assets.RootFolderPath + "\\" + _currentCustomerID + "_" + textBox_name.Text;
            // on récupère le nom de l'image
            string imageFileName = nouveauEmplacement.Remove(0, nouveauEmplacement.LastIndexOf('\\') + 1);
            // on copie l'image dans le répertoire de notre base de données
            string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + "_" + imageFileName;
            File.Copy(nouveauEmplacement, destinationFileName, true);
            // suppression de l'ancienne image de notre base de données
            string oldImage = Database.Assets.Table.Rows[pieceIndex]["FileName"].ToString();
            if (File.Exists(oldImage))
                File.Delete(oldImage);
            // on modifie l'emplacement de la pièce et on applique les changements à la Table Pieces
            Database.Assets.Table.Rows[pieceIndex]["FileName"] = destinationFileName;
            Database.Assets.ApplyChanges();
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = LocalizedStrings.Modifier_Client_Win_Name;
            // Labels et GroupBoxs
            groupBox_customer.Text = LocalizedStrings.Ajouter_Client_Client_GroupBox;
            label_name.Text = LocalizedStrings.Ajouter_Client_Nom_Label;
            label_job.Text = LocalizedStrings.Ajouter_Client_Travail_Label;
            label_birthDate.Text = LocalizedStrings.Ajouter_Client_Date_Naissance_Label;
            label_phoneNumber.Text = LocalizedStrings.Ajouter_Client_Numero_Tel_Label;
            label_email.Text = LocalizedStrings.Ajouter_Client_Email_Label;
            groupBox_photo.Text = LocalizedStrings.Ajouter_Client_Photo_GroupBox;
            groupBox_payement.Text = LocalizedStrings.Modifier_Client_Paiement_GroupBox;
            groupBox_newPayement.Text = LocalizedStrings.Modifier_Client_Nouveau_Paiement_GroupBox;
            label_amount.Text = LocalizedStrings.Modifier_Client_Montant_Label;
            label_payementDate.Text = LocalizedStrings.Modifier_Client_Date_Paiement_Label;
            groupBox_assets.Text = LocalizedStrings.Modifier_Client_Pieces_GroupBox;
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
            // openFileDialog1
            openFileDialog_main.Title = LocalizedStrings.openFileDialog_Title;
            // on raffraichie le format de la liste des paiements (pour changer la langue de la liste aussi)
            setDataGridviewFormat();
        }
    }
}
