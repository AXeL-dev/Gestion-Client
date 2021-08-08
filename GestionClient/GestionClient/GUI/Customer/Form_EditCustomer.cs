using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class Form_EditCustomer : Form
    {
        // attributs
        private int position = 0;
        private int currentClientId;
        private List<PictureBox> piecesPbList = new List<PictureBox>();
        private DataView dv;

        // constr.
        public Form_EditCustomer()
        {
            InitializeComponent();
        }

        //============================================================================================================
        //                                                Events.
        //============================================================================================================

        // event. FormClosed du formulaire
        private void ListeClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            API.EditJobFormOpened = false;
            Form_Main parent = (Form_Main)this.MdiParent;
            parent.LanguageChanged -= this.LanguageChangedHandler;
        }

        // event. Load du formulaire
        private void ListeClients_Load(object sender, EventArgs e)
        {
            try
            {
                if (API.ConnectedToDatabase) // si on est déjà connecté à la base de données
                {
                    // si la dataTable Client est vide
                    if (API.MainDataSet.Tables["Client"].Rows.Count == 0)
                        throw new Exception(API.GetString("MessageBox_Aucun_Client"));

                    // remplissage de la combobox 'TravailCombo'
                    TravailCombo.DataSource = API.MainDataSet.Tables["Travail"];
                    TravailCombo.DisplayMember = "description";
                    TravailCombo.ValueMember = "id";

                    // initialisation du DataView
                    dv = new DataView(API.MainDataSet.Tables["Paiement"]);
                    // affichage du DataView dans la DataGridView
                    dataGridView1.DataSource = dv;
                    dataGridView1.Columns["id"].Visible = dataGridView1.Columns["id_client"].Visible = false;
                    setDataGridviewFormat();
                    // ajout des bouttons supprimer dans la dataGridView des paiements
                    DeleteButtonColumn supprimerPaiementBtnColumn = new DeleteButtonColumn();
                    dataGridView1.Columns.Add(supprimerPaiementBtnColumn);

                    // image initiale de la pictureBox1 (La photo)
                    pictureBox1.InitialImage = GestionClient.Properties.Resources.load;

                    // on affiche le premier client
                    move();

                    // on séléctionne le boutton 'Suivant'
                    SuivantBtn.Select();

                    // on change la langue si l'arabe est séléctionné
                    if (API.GetCurrentLanguage() == "ar")
                        switchLanguage();
                }
                else
                {
                    throw new Exception(API.GetString("MessageBox_Connexion_Non_Etablie"));
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
                this.BeginInvoke(new MethodInvoker(this.Close)); // on empêche l'ouverture de la fenêtre
            }
        }

        // event. Click on boutton 'Suivant'
        private void SuivantBtn_Click(object sender, EventArgs e)
        {
            // on avance
            position++;
            if (position > API.MainDataSet.Tables["Client"].Rows.Count - 1)
                position = API.MainDataSet.Tables["Client"].Rows.Count - 1;
            // on affiche le client
            move();
        }

        // event. Click on boutton 'Précédent'
        private void PrécédentBtn_Click(object sender, EventArgs e)
        {
            // on retourne au précédent
            position--;
            if (position < 0)
                position = 0;
            // on affiche le client
            move();
        }

        // event. Click on boutton 'Modifier'
        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // si le nom est vide
                if (NomTextBox.Text.Length == 0)
                {
                    QuickMessageBox.ShowWarning(API.GetString("MessageBox_Nom_Obligatoire"));
                    NomTextBox.Focus();
                }
                // si nn si nom en double
                else if (checkDoubleClientNameNotCurrent(NomTextBox.Text, position))
                {
                    QuickMessageBox.ShowWarning(API.GetString("MessageBox_Nom_D_un_Autre_Client"));
                    //NomTextBox.Text = ""; // on vide le textbox du nom
                    NomTextBox.SelectAll(); // on séléctionne le nom au cas l'utilisateur veut bien le supprimer
                    NomTextBox.Focus();
                }
                else // si nn, c'est bon
                {
                    // on parcourt la dataTable Client
                    for (int i = 0; i < API.MainDataSet.Tables["Client"].Rows.Count; i++)
                    {
                        // si clé primaire trouvée
                        if (Convert.ToInt32(API.MainDataSet.Tables["Client"].Rows[i]["id"]) == currentClientId)
                        {
                            // modification
                            API.MainDataSet.Tables["Client"].Rows[position]["nom"] = NomTextBox.Text;
                            API.MainDataSet.Tables["Client"].Rows[position]["id_travail"] = TravailCombo.SelectedValue;
                            if (DateNaissMaskedTextBox.MaskCompleted)
                                API.MainDataSet.Tables["Client"].Rows[position]["date_naissance"] = DateNaissMaskedTextBox.Text;
                            API.MainDataSet.Tables["Client"].Rows[position]["numero_telephone"] = NumTelMaskedTextBox.Text.Replace(" ", string.Empty);
                            API.MainDataSet.Tables["Client"].Rows[position]["email"] = EmailTextBox.Text;
                            API.ApplyChanges(API.ClientDataAdapter, "Client");
                            QuickMessageBox.ShowInformation(API.GetString("MessageBox_Client_Modifié"));
                            break; // on sort de la boucle
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
            }
        }

        // event. Click on boutton 'Supprimer'
        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (QuickMessageBox.ShowQuestion(API.GetString("MessageBox_Confirmer_Suppression_Client")) == DialogResult.Yes)
                {
                    // on boucle sur la dataTable Client
                    for (int i = 0; i < API.MainDataSet.Tables["Client"].Rows.Count; i++)
                    {
                        // si clé primaire trouvé
                        if (Convert.ToInt32(API.MainDataSet.Tables["Client"].Rows[i]["id"]) == currentClientId)
                        {
                            // suppression du client
                            API.MainDataSet.Tables["Client"].Rows[i].Delete();
                            API.ApplyChanges(API.ClientDataAdapter, "Client");
                            // suppression du dossier du client (!@ avec tout son contenu)
                            string clientFolderName = API.AppPiecesFolder + "\\" + currentClientId + "_";
                            if (Directory.Exists(clientFolderName))
                                Directory.Delete(clientFolderName, true);
                            // si on peu faire un retour en arrière
                            if (API.MainDataSet.Tables["Client"].Rows.Count > 0)
                            {
                                // on revient en arrière (simulation d'un click sur 'Précédent')
                                PrécédentBtn_Click(sender, e);
                                QuickMessageBox.ShowInformation(API.GetString("MessageBox_Client_Supprimé"));
                            }
                            else
                            {
                                QuickMessageBox.ShowWarning(API.GetString("MessageBox_Client_Supprimé_Plus_Fermeture"));
                                this.Close();
                            }
                            break; // on sort de la boucle for
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
            }
        }

        // event. Click on boutton 'Rechercher'
        private void RechercherBtn_Click(object sender, EventArgs e)
        {
            // on affecte la position actuelle à 'searchFoundedPosition' de la ClassGlobal
            API.SearchResultIndex = position;
            // on affiche la fenêtre de recherche
            Form fen = new Form_SearchCustomer();
            fen.RightToLeft = API.GetCurrentLanguage() == "ar" ? RightToLeft.Yes : RightToLeft.No;
            fen.ShowDialog();
            // on affiche le client trouvé, si trouvé biensur
            if (API.SearchResultIndex != position)
            {
                position = API.SearchResultIndex;
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
                if (MontantMaskedTextBox.Text.Length == 0)
                {
                    QuickMessageBox.ShowWarning(API.GetString("MessageBox_Montant_Obligatoire"));
                    MontantMaskedTextBox.Focus();
                }
                else // si nn, c'est bon
                {
                    // ajout du paiement
                    API.MainDataSet.Tables["Paiement"].Rows.Add(null, API.MainDataSet.Tables["Client"].Rows[position]["id"], MontantMaskedTextBox.Text, DatePaiementDateTimePicker.Value);
                    API.ApplyChanges(API.PaiementDataAdapter, "Paiement");
                    //QuickMessageBox.Show("Paiement enregistré !", ClassGlobal.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // mise à jour de la dataTable Paiement (pour avoir les bon ids, afin de pouvoir supprimer un paiement)
                    API.FetchPaiementTable();
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
            }
        }

        // event. pictureBoxsSingle_Click (utilisé pour les pieces pictureboxs)
        private void pictureBoxsSingle_Click(object sender, EventArgs e)
        {
            // on rend à l'état normal toutes les picturesboxs des pieces
            foreach (PictureBox curPb in piecesPbList)
            {
                curPb.BackColor = SystemColors.Control;
                curPb.Padding = new Padding(0);
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
                if (piecesPbList.Count == 0)
                    throw new Exception(API.GetString("MessageBox_Aucune_Piece"));
                else // si nn
                {
                    // on parcourt toutes les pieces
                    for (int i = 0; i < piecesPbList.Count; i++)
                    {
                        // si on trouve qu'une piece est séléctionnée
                        if (piecesPbList[i].BackColor == SystemColors.Highlight && piecesPbList[i].Padding.All == 3)
                        {
                            if (QuickMessageBox.ShowQuestion(API.GetString("MessageBox_Confirmer_Suppression_Piece")) == DialogResult.Yes)
                            {
                                // on parcourt la dataTable 'Pieces'
                                for (int p = 0; p < API.MainDataSet.Tables["Pieces"].Rows.Count; p++)
                                {
                                    // si on trouve que la clé primaire (id) == tag de l'image ou on a sauvegardé l'id nous aussi
                                    if (API.MainDataSet.Tables["Pieces"].Rows[p]["id"].ToString() == piecesPbList[i].Tag.ToString())
                                    {
                                        // suppression de l'image
                                        File.Delete(piecesPbList[i].ImageLocation);
                                        // suppression de la piece de la table 'Pieces'
                                        API.MainDataSet.Tables["Pieces"].Rows[p].Delete();
                                        API.ApplyChanges(API.PiecesDataAdapter, "Pieces");
                                        // raffraichissement des pieces
                                        showPieces(currentClientId);
                                        break; // on sort de la 2ème boucle
                                    }
                                }
                            }

                            // on sort de la fonction
                            return;
                        }
                    }

                    // si nn, aucune piece n'est séléctionnée
                    QuickMessageBox.ShowWarning(API.GetString("MessageBox_Selectionner_Piece"));
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
            }
        }

        // event. Click sur le boutton 'AjouterPieceBtn'
        private void AjouterPieceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // ajout de la pièce
                    addPieceAs(openFileDialog1.FileName, "Autre");
                    // raffraichissement des pieces
                    showPieces(currentClientId);
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
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
                    if (QuickMessageBox.ShowQuestion(API.GetString("MessageBox_Confirmer_Suppression_Paiement")) == DialogResult.Yes)
                    {
                        // on récupère l'id du paiement séléctionné
                        int paiementId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                        // on boucle sur la dataTable Paiement
                        for (int i = 0; i < API.MainDataSet.Tables["Paiement"].Rows.Count; i++)
                        {
                            // si clé primaire trouvé
                            if (Convert.ToInt32(API.MainDataSet.Tables["Paiement"].Rows[i]["id"]) == paiementId)
                            {
                                // suppression du paiement
                                API.MainDataSet.Tables["Paiement"].Rows[i].Delete();
                                API.ApplyChanges(API.PaiementDataAdapter, "Paiement");
                                break; // on sort de la boucle for
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    QuickMessageBox.ShowError(ex.Message);
                }
            }
        }

        // event. Click sur le boutton 'ModifierPhotoBtn'
        private void ModifierPhotoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // si le client n'a pas de Photo
                    if (pictureBox1.ImageLocation == null)
                    {
                        // ajout de la pièce en tant que Photo
                        addPieceAs(openFileDialog1.FileName, "Photo");
                        // on défini le Tag de la dernière image ajoutée, Dans notre cas (le client n'a pas de photo) le Tag est obligatoire, ou on aura une erreur lors de la modification
                        pictureBox1.Tag = API.MainDataSet.Tables["Pieces"].Rows.Count - 1; // rappelez-vous le Tag sert à nous simplifier la modification de la Photo
                    }
                    // si nn, le client a déjà une photo, on la modifie
                    else
                    {
                        updatePiece(openFileDialog1.FileName, Convert.ToInt32(pictureBox1.Tag));
                    }

                    // on affiche la nouvelle Photo
                    pictureBox1.ImageLocation = API.AppFolderPath + "\\" + API.MainDataSet.Tables["Pieces"].Rows[Convert.ToInt32(pictureBox1.Tag)]["emplacement"].ToString();
                }
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
            }
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
                QuickMessageBox.ShowError(ex.Message);
            }
        }

        //============================================================================================================
        //                                                Méthodes
        //============================================================================================================

        // move() : gère les déplacements des clients
        private void move()
        {
            currentClientId = Convert.ToInt32(API.MainDataSet.Tables["Client"].Rows[position]["id"]);
            setImage(currentClientId);
            NomTextBox.Text = API.MainDataSet.Tables["Client"].Rows[position]["nom"].ToString();
            TravailCombo.SelectedValue = API.MainDataSet.Tables["Client"].Rows[position]["id_travail"];
            DateNaissMaskedTextBox.Text = API.MainDataSet.Tables["Client"].Rows[position]["date_naissance"].ToString();
            NumTelMaskedTextBox.Text = API.MainDataSet.Tables["Client"].Rows[position]["numero_telephone"].ToString();
            EmailTextBox.Text = API.MainDataSet.Tables["Client"].Rows[position]["email"].ToString();
            showPaiement(currentClientId);
            showPieces(currentClientId);
        }

        // setImage() : affiche l'image du client
        private void setImage(int clientId)
        {
            // on parcourt la dataTable 'Pieces'
            for (int i = 0; i < API.MainDataSet.Tables["Pieces"].Rows.Count; i++)
            {
                // si on trouve que le client à une photo
                if (Convert.ToInt32(API.MainDataSet.Tables["Pieces"].Rows[i]["id_client"]) == clientId && API.MainDataSet.Tables["Pieces"].Rows[i]["type_piece"].ToString() == "Photo")
                {
                    pictureBox1.ImageLocation = API.AppFolderPath + "\\" + API.MainDataSet.Tables["Pieces"].Rows[i]["emplacement"].ToString();
                    pictureBox1.Tag = i; // on utilisera le Tag pour simplifier la modification de la Photo
                    return;
                }
            }

            // si nn
            string sexe = API.MainDataSet.Tables["Client"].Rows[position]["sexe"].ToString();

            if (sexe == "Homme" || sexe == "ذكر") // si c'est un 'Homme'
                pictureBox1.Image = GestionClient.Properties.Resources.homme;
            else // si nn, une 'Femme' alors
                pictureBox1.Image = GestionClient.Properties.Resources.femme;

            pictureBox1.ImageLocation = null; // à ne pas oublier
        }

        // showImage() : affiche l'image avec le programme de visionnement par défaut
        private void showImage(PictureBox pb)
        {
            try
            {
                if (pb.ImageLocation != null)
                    Process.Start(pb.ImageLocation);
                else
                    throw new Exception(API.GetString("MessageBox_Client_Sans_Photo"));
            }
            catch (Exception ex)
            {
                QuickMessageBox.ShowError(ex.Message);
            }
        }

        // showPaiement() : affiche les paiements du client
        private void showPaiement(int clientId)
        {
            // filtrage
            dv.RowFilter = "id_client = " + clientId;
        }

        // setDataGridviewFormat() : applique les changements de format nécéssaires à la DataGridView
        private void setDataGridviewFormat()
        {
            // montant
            dataGridView1.Columns["montant"].HeaderText = API.GetString("Modifier_Client_DataGridView_Montant_Column");
            dataGridView1.Columns["montant"].Width = 200;
            NumberFormatInfo format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = API.GetString("Modifier_Client_DataGridView_Montant_Column_Devise"); ;
            format.CurrencyDecimalDigits = 0;
            dataGridView1.Columns["montant"].DefaultCellStyle.FormatProvider = format;
            dataGridView1.Columns["montant"].DefaultCellStyle.Format = "c";
            // date paiement
            dataGridView1.Columns["date_paiement"].HeaderText = API.GetString("Modifier_Client_DataGridView_Date_Paiement_Column");
            dataGridView1.Columns["date_paiement"].Width = 200;
        }

        // showPieces() : affiche les pieces du client
        private void showPieces(int clientId)
        {
            // filtrage
            //DataView dv = new DataView(ClassGlobal.ds.Tables["Pieces"]);
            //dv.RowFilter = "id_client = " + clientId + "AND type_piece = 'Autre'";
            DataRow[] drs = API.MainDataSet.Tables["Pieces"].Select("id_client = " + clientId + "AND type_piece = 'Autre'");

            // on vide le TableLayoutPanel
            PiecesTableLayoutPanel.Controls.Clear();
            PiecesTableLayoutPanel.ColumnStyles.Clear();
            PiecesTableLayoutPanel.ColumnCount = 1;

            // on vide la liste des images/pictureboxs
            piecesPbList.Clear();

            if (drs.Length > 0)
            {
                // on divise/tranche le TableLayoutPanel en partie égale selon le nombre d'image trouvé
                float pieceSize = (float)100 / drs.Length;
                PiecesTableLayoutPanel.ColumnCount = drs.Length;

                // affichage
                for (int i = 0; i < drs.Length; i++)
                {
                    // création de l'image/la picturebox
                    PictureBox pb = new PictureBox();
                    pb.Tag = drs[i]["id"].ToString(); // on sauvegarde l'id de la pièce, pour nous simplifier la suppression
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Cursor = Cursors.Hand;
                    pb.Dock = DockStyle.Fill;
                    pb.InitialImage = GestionClient.Properties.Resources.load;
                    //pb.ErrorImage = GestionClient.Properties.Resources._false;
                    pb.ImageLocation = API.AppFolderPath + "\\" + drs[i]["emplacement"].ToString();
                    pb.DoubleClick += pictureBox1_Click;
                    pb.Click += pictureBoxsSingle_Click;
                    // ajout à la liste des images/pictureboxs
                    piecesPbList.Add(pb);
                    // ajout au TableLayoutPanel
                    PiecesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, pieceSize));
                    PiecesTableLayoutPanel.Controls.Add(piecesPbList[i], i, 0);
                }
            }
        }

        // checkDoubleClientNameNotCurrent(...) : vérifie si le nom du client entré existe déjà + ne prend pas en compte le client en cours (dont on change le nom)
        private bool checkDoubleClientNameNotCurrent(string name, int currentClientPosition)
        {
            for (int i = 0; i < API.MainDataSet.Tables["Client"].Rows.Count; i++)
            {
                if (i != currentClientPosition && API.MainDataSet.Tables["Client"].Rows[i]["nom"].ToString().ToUpper() == name.ToUpper()) // ToUpper() pour gérer la casse
                    return true;
            }

            return false;
        }

        // addPieceAs(...) : ajoute la pièce spécifiée selon le type spécifié
        private void addPieceAs(string emplacementPiece, string typePiece)
        {
            // on récupère le chemin ou on va pouvoir stocker l'image
            string imageFolderName = API.AppPiecesFolder + "\\" + currentClientId + "_";// +NomTextBox.Text;
            // on récupère le nom de l'image
            string imageFileName = emplacementPiece.Remove(0, emplacementPiece.LastIndexOf('\\') + 1);
            // on copie l'image dans le répertoire de notre base de données
            string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_") + "_" + imageFileName;
            File.Copy(emplacementPiece, API.AppFolderPath + "\\" + destinationFileName, true);
            // on ajoute la photo en tant que Piece
            API.MainDataSet.Tables["Pieces"].Rows.Add(null, currentClientId, destinationFileName, typePiece);
            API.ApplyChanges(API.PiecesDataAdapter, "Pieces");
            // mise à jour de la dataTable 'Pieces' (pour avoir les bon ids des pièces)
            API.FetchPiecesTable();
        }

        // updatePiece(...) : met à jour une pièce, en la copyant dans la bdd et en changeant son emplacement + suppression de l'ancienne
        private void updatePiece(string nouveauEmplacement, int pieceIndex)
        {
            // on récupère le chemin ou on va pouvoir stocker l'image
            string imageFolderName = API.AppPiecesFolder + "\\" + currentClientId + "_";// +NomTextBox.Text;
            // on récupère le nom de l'image
            string imageFileName = nouveauEmplacement.Remove(0, nouveauEmplacement.LastIndexOf('\\') + 1);
            // on copie l'image dans le répertoire de notre base de données
            string destinationFileName = imageFolderName + "\\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-").Replace(" ", "_") + "_" + imageFileName;
            File.Copy(nouveauEmplacement, API.AppFolderPath + "\\" + destinationFileName, true);
            // suppression de l'ancienne image de notre base de données
            string oldImage = API.AppFolderPath + "\\" + API.MainDataSet.Tables["Pieces"].Rows[pieceIndex]["emplacement"].ToString();
            if (File.Exists(oldImage))
                File.Delete(oldImage);
            // on modifie l'emplacement de la pièce et on applique les changements à la Table Pieces
            API.MainDataSet.Tables["Pieces"].Rows[pieceIndex]["emplacement"] = destinationFileName;
            API.ApplyChanges(API.PiecesDataAdapter, "Pieces");
        }

        // switchLanguage() : charge la traduction des propriétés Text, ... des controls
        private void switchLanguage()
        {
            // Window Name
            this.Text = API.GetString("Modifier_Client_Win_Name");
            // Labels et GroupBoxs
            ClientGroupBox.Text = API.GetString("Ajouter_Client_Client_GroupBox");
            NomLabel.Text = API.GetString("Ajouter_Client_Nom_Label");
            TravailLabel.Text = API.GetString("Ajouter_Client_Travail_Label");
            DateNaissanceLabel.Text = API.GetString("Ajouter_Client_Date_Naissance_Label");
            NumeroTelLabel.Text = API.GetString("Ajouter_Client_Numero_Tel_Label");
            EmailLabel.Text = API.GetString("Ajouter_Client_Email_Label");
            PhotoGroupBox.Text = API.GetString("Ajouter_Client_Photo_GroupBox");
            PaiementGroupBox.Text = API.GetString("Modifier_Client_Paiement_GroupBox");
            NouveauPaiementGroupBox.Text = API.GetString("Modifier_Client_Nouveau_Paiement_GroupBox");
            MontantLabel.Text = API.GetString("Modifier_Client_Montant_Label");
            DatePaiementLabel.Text = API.GetString("Modifier_Client_Date_Paiement_Label");
            PiecesGroupBox.Text = API.GetString("Modifier_Client_Pieces_GroupBox");
            toolTip1.SetToolTip(SupprimerPieceBtn, API.GetString("Modifier_Client_Supprimer_Piece_ToolTip"));
            toolTip1.SetToolTip(AjouterPieceBtn, API.GetString("Modifier_Client_Ajouter_Piece_ToolTip"));
            // Buttons
            SuivantBtn.Text = API.GetString("Modifier_Client_Suivant_Button");
            PrécédentBtn.Text = API.GetString("Modifier_Client_Précédent_Button");
            ModifierBtn.Text = API.GetString("Modifier_Client_Modifier_Button");
            SupprimerBtn.Text = API.GetString("Modifier_Client_Supprimer_Button");
            RechercherBtn.Text = API.GetString("Modifier_Client_Rechercher_Button");
            ModifierPhotoBtn.Text = API.GetString("Modifier_Client_Modifier_Button");
            EnregistrerPaiementBtn.Text = API.GetString("Modifier_Client_Enregistrer_Paiement_Button");
            // openFileDialog1
            openFileDialog1.Title = API.GetString("openFileDialog_Title");
            // on raffraichie le format de la liste des paiements (pour changer la langue de la liste aussi)
            setDataGridviewFormat();
        }
    }
}
