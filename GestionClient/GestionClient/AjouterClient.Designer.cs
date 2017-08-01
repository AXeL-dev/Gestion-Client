namespace GestionClient
{
    partial class AjouterClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjouterClient));
            this.PhotoGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AjouterModifierPhotoBtn = new System.Windows.Forms.Button();
            this.ClientGroupBox = new System.Windows.Forms.GroupBox();
            this.NouveauTravailBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TravailCombo = new System.Windows.Forms.ComboBox();
            this.TravailLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.DateNaissMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DateNaissanceLabel = new System.Windows.Forms.Label();
            this.NumTelMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.NumeroTelLabel = new System.Windows.Forms.Label();
            this.HommeFemmeCombo = new System.Windows.Forms.ComboBox();
            this.SexeLabel = new System.Windows.Forms.Label();
            this.NomTextBox = new System.Windows.Forms.TextBox();
            this.NomLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.AjouterClientBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.PhotoGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ClientGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PhotoGroupBox
            // 
            this.PhotoGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.PhotoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhotoGroupBox.Location = new System.Drawing.Point(476, 5);
            this.PhotoGroupBox.Margin = new System.Windows.Forms.Padding(5, 5, 5, 20);
            this.PhotoGroupBox.Name = "PhotoGroupBox";
            this.PhotoGroupBox.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.PhotoGroupBox.Size = new System.Drawing.Size(245, 294);
            this.PhotoGroupBox.TabIndex = 1;
            this.PhotoGroupBox.TabStop = false;
            this.PhotoGroupBox.Text = "Photo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AjouterModifierPhotoBtn, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(241, 267);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(10, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AjouterModifierPhotoBtn
            // 
            this.AjouterModifierPhotoBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AjouterModifierPhotoBtn.Image = global::GestionClient.Properties.Resources.picture_photo;
            this.AjouterModifierPhotoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AjouterModifierPhotoBtn.Location = new System.Drawing.Point(10, 231);
            this.AjouterModifierPhotoBtn.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.AjouterModifierPhotoBtn.Name = "AjouterModifierPhotoBtn";
            this.AjouterModifierPhotoBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.AjouterModifierPhotoBtn.Size = new System.Drawing.Size(221, 31);
            this.AjouterModifierPhotoBtn.TabIndex = 1;
            this.AjouterModifierPhotoBtn.Text = "Ajouter/Modifier";
            this.AjouterModifierPhotoBtn.UseVisualStyleBackColor = true;
            this.AjouterModifierPhotoBtn.Click += new System.EventHandler(this.AjouterModifierPhotoBtn_Click);
            // 
            // ClientGroupBox
            // 
            this.ClientGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.ClientGroupBox.Location = new System.Drawing.Point(16, 16);
            this.ClientGroupBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ClientGroupBox.Name = "ClientGroupBox";
            this.ClientGroupBox.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.ClientGroupBox.Size = new System.Drawing.Size(730, 346);
            this.ClientGroupBox.TabIndex = 2;
            this.ClientGroupBox.TabStop = false;
            this.ClientGroupBox.Text = "Client";
            // 
            // NouveauTravailBtn
            // 
            this.NouveauTravailBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NouveauTravailBtn.Image = ((System.Drawing.Image)(resources.GetObject("NouveauTravailBtn.Image")));
            this.NouveauTravailBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NouveauTravailBtn.Location = new System.Drawing.Point(192, 5);
            this.NouveauTravailBtn.Name = "NouveauTravailBtn";
            this.NouveauTravailBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.NouveauTravailBtn.Size = new System.Drawing.Size(96, 30);
            this.NouveauTravailBtn.TabIndex = 17;
            this.NouveauTravailBtn.Text = "Nouveau";
            this.NouveauTravailBtn.UseVisualStyleBackColor = true;
            this.NouveauTravailBtn.Click += new System.EventHandler(this.NouveauTravailBtn_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(144, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "*";
            // 
            // TravailCombo
            // 
            this.TravailCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TravailCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TravailCombo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravailCombo.FormattingEnabled = true;
            this.TravailCombo.Items.AddRange(new object[] {
            "Homme",
            "Femme"});
            this.TravailCombo.Location = new System.Drawing.Point(2, 7);
            this.TravailCombo.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.TravailCombo.Name = "TravailCombo";
            this.TravailCombo.Size = new System.Drawing.Size(185, 25);
            this.TravailCombo.TabIndex = 7;
            // 
            // TravailLabel
            // 
            this.TravailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TravailLabel.AutoSize = true;
            this.TravailLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravailLabel.Location = new System.Drawing.Point(7, 121);
            this.TravailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TravailLabel.Name = "TravailLabel";
            this.TravailLabel.Size = new System.Drawing.Size(132, 17);
            this.TravailLabel.TabIndex = 14;
            this.TravailLabel.Text = "Travail :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(144, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(144, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "*";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(165, 255);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(293, 25);
            this.EmailTextBox.TabIndex = 15;
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(7, 259);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(132, 17);
            this.EmailLabel.TabIndex = 10;
            this.EmailLabel.Text = "Email :";
            // 
            // DateNaissMaskedTextBox
            // 
            this.DateNaissMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DateNaissMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateNaissMaskedTextBox.Location = new System.Drawing.Point(165, 163);
            this.DateNaissMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.DateNaissMaskedTextBox.Mask = "00/00/0000";
            this.DateNaissMaskedTextBox.Name = "DateNaissMaskedTextBox";
            this.DateNaissMaskedTextBox.Size = new System.Drawing.Size(293, 25);
            this.DateNaissMaskedTextBox.TabIndex = 9;
            this.DateNaissMaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // DateNaissanceLabel
            // 
            this.DateNaissanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DateNaissanceLabel.AutoSize = true;
            this.DateNaissanceLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateNaissanceLabel.Location = new System.Drawing.Point(7, 167);
            this.DateNaissanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateNaissanceLabel.Name = "DateNaissanceLabel";
            this.DateNaissanceLabel.Size = new System.Drawing.Size(132, 17);
            this.DateNaissanceLabel.TabIndex = 8;
            this.DateNaissanceLabel.Text = "Date de naissance :";
            // 
            // NumTelMaskedTextBox
            // 
            this.NumTelMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumTelMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumTelMaskedTextBox.Location = new System.Drawing.Point(165, 209);
            this.NumTelMaskedTextBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.NumTelMaskedTextBox.Mask = "\\06 00 00 00 00";
            this.NumTelMaskedTextBox.Name = "NumTelMaskedTextBox";
            this.NumTelMaskedTextBox.Size = new System.Drawing.Size(293, 25);
            this.NumTelMaskedTextBox.TabIndex = 11;
            // 
            // NumeroTelLabel
            // 
            this.NumeroTelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumeroTelLabel.AutoSize = true;
            this.NumeroTelLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroTelLabel.Location = new System.Drawing.Point(7, 213);
            this.NumeroTelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NumeroTelLabel.Name = "NumeroTelLabel";
            this.NumeroTelLabel.Size = new System.Drawing.Size(132, 17);
            this.NumeroTelLabel.TabIndex = 6;
            this.NumeroTelLabel.Text = "Numéro tél. :";
            // 
            // HommeFemmeCombo
            // 
            this.HommeFemmeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HommeFemmeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HommeFemmeCombo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HommeFemmeCombo.FormattingEnabled = true;
            this.HommeFemmeCombo.Items.AddRange(new object[] {
            "Homme",
            "Femme"});
            this.HommeFemmeCombo.Location = new System.Drawing.Point(165, 71);
            this.HommeFemmeCombo.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.HommeFemmeCombo.Name = "HommeFemmeCombo";
            this.HommeFemmeCombo.Size = new System.Drawing.Size(293, 25);
            this.HommeFemmeCombo.TabIndex = 5;
            this.HommeFemmeCombo.SelectedIndexChanged += new System.EventHandler(this.HommeFemmeCombo_SelectedIndexChanged);
            // 
            // SexeLabel
            // 
            this.SexeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SexeLabel.AutoSize = true;
            this.SexeLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SexeLabel.Location = new System.Drawing.Point(7, 75);
            this.SexeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SexeLabel.Name = "SexeLabel";
            this.SexeLabel.Size = new System.Drawing.Size(132, 17);
            this.SexeLabel.TabIndex = 4;
            this.SexeLabel.Text = "♂ | ♀ :";
            // 
            // NomTextBox
            // 
            this.NomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomTextBox.Location = new System.Drawing.Point(165, 25);
            this.NomTextBox.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.NomTextBox.Name = "NomTextBox";
            this.NomTextBox.Size = new System.Drawing.Size(293, 25);
            this.NomTextBox.TabIndex = 3;
            // 
            // NomLabel
            // 
            this.NomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomLabel.AutoSize = true;
            this.NomLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomLabel.Location = new System.Drawing.Point(7, 29);
            this.NomLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NomLabel.Name = "NomLabel";
            this.NomLabel.Size = new System.Drawing.Size(132, 17);
            this.NomLabel.TabIndex = 2;
            this.NomLabel.Text = "Nom :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            this.openFileDialog1.Title = "Choix d\'une photo";
            // 
            // AjouterClientBtn
            // 
            this.AjouterClientBtn.Image = global::GestionClient.Properties.Resources.person_add;
            this.AjouterClientBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AjouterClientBtn.Location = new System.Drawing.Point(302, 377);
            this.AjouterClientBtn.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.AjouterClientBtn.Name = "AjouterClientBtn";
            this.AjouterClientBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.AjouterClientBtn.Size = new System.Drawing.Size(158, 44);
            this.AjouterClientBtn.TabIndex = 3;
            this.AjouterClientBtn.Text = "Ajouter";
            this.AjouterClientBtn.UseVisualStyleBackColor = true;
            this.AjouterClientBtn.Click += new System.EventHandler(this.AjouterClientBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.PhotoGroupBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(726, 319);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Controls.Add(this.NomLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.EmailTextBox, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.EmailLabel, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.NumTelMaskedTextBox, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.DateNaissMaskedTextBox, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.NumeroTelLabel, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.NomTextBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.DateNaissanceLabel, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.SexeLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TravailLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.HommeFemmeCombo, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(465, 313);
            this.tableLayoutPanel3.TabIndex = 18;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.Controls.Add(this.TravailCombo, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.NouveauTravailBtn, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(166, 110);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(291, 40);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // AjouterClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 435);
            this.Controls.Add(this.AjouterClientBtn);
            this.Controls.Add(this.ClientGroupBox);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AjouterClient";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AjouterClient_FormClosed);
            this.Load += new System.EventHandler(this.AjouterClient_Load);
            this.PhotoGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ClientGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox PhotoGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button AjouterModifierPhotoBtn;
        private System.Windows.Forms.GroupBox ClientGroupBox;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.MaskedTextBox DateNaissMaskedTextBox;
        private System.Windows.Forms.Label DateNaissanceLabel;
        private System.Windows.Forms.MaskedTextBox NumTelMaskedTextBox;
        private System.Windows.Forms.Label NumeroTelLabel;
        private System.Windows.Forms.ComboBox HommeFemmeCombo;
        private System.Windows.Forms.Label SexeLabel;
        private System.Windows.Forms.TextBox NomTextBox;
        private System.Windows.Forms.Label NomLabel;
        private System.Windows.Forms.Button AjouterClientBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox TravailCombo;
        private System.Windows.Forms.Label TravailLabel;
        private System.Windows.Forms.Button NouveauTravailBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}