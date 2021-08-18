namespace GestionClient
{
    partial class Form_AddCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddCustomer));
            this.groupBox_photo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_photo = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_photo = new System.Windows.Forms.PictureBox();
            this.button_selectPhoto = new System.Windows.Forms.Button();
            this.groupBox_customer = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label_name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_phoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_birthDate = new System.Windows.Forms.MaskedTextBox();
            this.label_phoneNumber = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_birthDate = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.label_job = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_job = new System.Windows.Forms.ComboBox();
            this.button_newJob = new System.Windows.Forms.Button();
            this.openFileDialog_main = new System.Windows.Forms.OpenFileDialog();
            this.button_add = new System.Windows.Forms.Button();
            this.groupBox_photo.SuspendLayout();
            this.tableLayoutPanel_photo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).BeginInit();
            this.groupBox_customer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_photo
            // 
            this.groupBox_photo.Controls.Add(this.tableLayoutPanel_photo);
            this.groupBox_photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_photo.Location = new System.Drawing.Point(476, 5);
            this.groupBox_photo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 20);
            this.groupBox_photo.Name = "groupBox_photo";
            this.groupBox_photo.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.groupBox_photo.Size = new System.Drawing.Size(245, 294);
            this.groupBox_photo.TabIndex = 1;
            this.groupBox_photo.TabStop = false;
            this.groupBox_photo.Text = "Photo";
            // 
            // tableLayoutPanel_photo
            // 
            this.tableLayoutPanel_photo.ColumnCount = 1;
            this.tableLayoutPanel_photo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_photo.Controls.Add(this.pictureBox_photo, 0, 0);
            this.tableLayoutPanel_photo.Controls.Add(this.button_selectPhoto, 0, 1);
            this.tableLayoutPanel_photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_photo.Location = new System.Drawing.Point(2, 22);
            this.tableLayoutPanel_photo.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.tableLayoutPanel_photo.Name = "tableLayoutPanel_photo";
            this.tableLayoutPanel_photo.RowCount = 2;
            this.tableLayoutPanel_photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel_photo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel_photo.Size = new System.Drawing.Size(241, 267);
            this.tableLayoutPanel_photo.TabIndex = 0;
            // 
            // pictureBox_photo
            // 
            this.pictureBox_photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_photo.Location = new System.Drawing.Point(10, 5);
            this.pictureBox_photo.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pictureBox_photo.Name = "pictureBox_photo";
            this.pictureBox_photo.Size = new System.Drawing.Size(221, 216);
            this.pictureBox_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_photo.TabIndex = 0;
            this.pictureBox_photo.TabStop = false;
            // 
            // button_selectPhoto
            // 
            this.button_selectPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_selectPhoto.Image = global::GestionClient.Properties.Resources.picture_photo;
            this.button_selectPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_selectPhoto.Location = new System.Drawing.Point(10, 231);
            this.button_selectPhoto.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.button_selectPhoto.Name = "button_selectPhoto";
            this.button_selectPhoto.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_selectPhoto.Size = new System.Drawing.Size(221, 31);
            this.button_selectPhoto.TabIndex = 1;
            this.button_selectPhoto.Text = "Add/Change";
            this.button_selectPhoto.UseVisualStyleBackColor = true;
            this.button_selectPhoto.Click += new System.EventHandler(this.button_selectPhoto_Click);
            // 
            // groupBox_customer
            // 
            this.groupBox_customer.Controls.Add(this.tableLayoutPanel2);
            this.groupBox_customer.Location = new System.Drawing.Point(16, 16);
            this.groupBox_customer.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.groupBox_customer.Name = "groupBox_customer";
            this.groupBox_customer.Padding = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.groupBox_customer.Size = new System.Drawing.Size(730, 346);
            this.groupBox_customer.TabIndex = 2;
            this.groupBox_customer.TabStop = false;
            this.groupBox_customer.Text = "Customers";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_photo, 1, 0);
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
            this.tableLayoutPanel3.Controls.Add(this.label_name, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_email, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.label_email, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label8, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.maskedTextBox_phoneNumber, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.maskedTextBox_birthDate, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.label_phoneNumber, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.textBox_name, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label_birthDate, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label_gender, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label_job, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_gender, 2, 2);
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
            // label_name
            // 
            this.label_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(7, 29);
            this.label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(132, 17);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "Name :";
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
            // textBox_email
            // 
            this.textBox_email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_email.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_email.Location = new System.Drawing.Point(165, 255);
            this.textBox_email.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(293, 25);
            this.textBox_email.TabIndex = 15;
            // 
            // label_email
            // 
            this.label_email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_email.AutoSize = true;
            this.label_email.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_email.Location = new System.Drawing.Point(7, 259);
            this.label_email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(132, 17);
            this.label_email.TabIndex = 10;
            this.label_email.Text = "Email :";
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
            // maskedTextBox_phoneNumber
            // 
            this.maskedTextBox_phoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_phoneNumber.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_phoneNumber.Location = new System.Drawing.Point(165, 209);
            this.maskedTextBox_phoneNumber.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.maskedTextBox_phoneNumber.Mask = "\\06 00 00 00 00";
            this.maskedTextBox_phoneNumber.Name = "maskedTextBox_phoneNumber";
            this.maskedTextBox_phoneNumber.Size = new System.Drawing.Size(293, 25);
            this.maskedTextBox_phoneNumber.TabIndex = 11;
            // 
            // maskedTextBox_birthDate
            // 
            this.maskedTextBox_birthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_birthDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBox_birthDate.Location = new System.Drawing.Point(165, 163);
            this.maskedTextBox_birthDate.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.maskedTextBox_birthDate.Mask = "00/00/0000";
            this.maskedTextBox_birthDate.Name = "maskedTextBox_birthDate";
            this.maskedTextBox_birthDate.Size = new System.Drawing.Size(293, 25);
            this.maskedTextBox_birthDate.TabIndex = 9;
            this.maskedTextBox_birthDate.ValidatingType = typeof(System.DateTime);
            // 
            // label_phoneNumber
            // 
            this.label_phoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_phoneNumber.AutoSize = true;
            this.label_phoneNumber.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_phoneNumber.Location = new System.Drawing.Point(7, 213);
            this.label_phoneNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_phoneNumber.Name = "label_phoneNumber";
            this.label_phoneNumber.Size = new System.Drawing.Size(132, 17);
            this.label_phoneNumber.TabIndex = 6;
            this.label_phoneNumber.Text = "Phone number :";
            // 
            // textBox_name
            // 
            this.textBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(165, 25);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(293, 25);
            this.textBox_name.TabIndex = 3;
            // 
            // label_birthDate
            // 
            this.label_birthDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_birthDate.AutoSize = true;
            this.label_birthDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_birthDate.Location = new System.Drawing.Point(7, 167);
            this.label_birthDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_birthDate.Name = "label_birthDate";
            this.label_birthDate.Size = new System.Drawing.Size(132, 17);
            this.label_birthDate.TabIndex = 8;
            this.label_birthDate.Text = "Birth date :";
            // 
            // label_gender
            // 
            this.label_gender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_gender.AutoSize = true;
            this.label_gender.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gender.Location = new System.Drawing.Point(7, 75);
            this.label_gender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(132, 17);
            this.label_gender.TabIndex = 4;
            this.label_gender.Text = "♂ | ♀ :";
            // 
            // label_job
            // 
            this.label_job.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_job.AutoSize = true;
            this.label_job.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_job.Location = new System.Drawing.Point(7, 121);
            this.label_job.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_job.Name = "label_job";
            this.label_job.Size = new System.Drawing.Size(132, 17);
            this.label_job.TabIndex = 14;
            this.label_job.Text = "Job :";
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
            // comboBox_gender
            // 
            this.comboBox_gender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gender.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Items.AddRange(new object[] {
            "Man",
            "Woman"});
            this.comboBox_gender.Location = new System.Drawing.Point(165, 71);
            this.comboBox_gender.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.comboBox_gender.Name = "comboBox_gender";
            this.comboBox_gender.Size = new System.Drawing.Size(293, 25);
            this.comboBox_gender.TabIndex = 5;
            this.comboBox_gender.SelectedIndexChanged += new System.EventHandler(this.comboBox_gender_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.Controls.Add(this.comboBox_job, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_newJob, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(166, 110);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(291, 40);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // comboBox_job
            // 
            this.comboBox_job.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_job.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_job.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_job.FormattingEnabled = true;
            this.comboBox_job.Items.AddRange(new object[] {
            "Homme",
            "Femme"});
            this.comboBox_job.Location = new System.Drawing.Point(2, 7);
            this.comboBox_job.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.comboBox_job.Name = "comboBox_job";
            this.comboBox_job.Size = new System.Drawing.Size(185, 25);
            this.comboBox_job.TabIndex = 7;
            // 
            // button_newJob
            // 
            this.button_newJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button_newJob.Image = ((System.Drawing.Image)(resources.GetObject("button_newJob.Image")));
            this.button_newJob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_newJob.Location = new System.Drawing.Point(192, 5);
            this.button_newJob.Name = "button_newJob";
            this.button_newJob.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_newJob.Size = new System.Drawing.Size(96, 30);
            this.button_newJob.TabIndex = 17;
            this.button_newJob.Text = "New";
            this.button_newJob.UseVisualStyleBackColor = true;
            this.button_newJob.Click += new System.EventHandler(this.button_newJob_Click);
            // 
            // openFileDialog_main
            // 
            this.openFileDialog_main.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            this.openFileDialog_main.Title = "Choose a photo";
            // 
            // button_add
            // 
            this.button_add.Image = global::GestionClient.Properties.Resources.person_add;
            this.button_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_add.Location = new System.Drawing.Point(302, 377);
            this.button_add.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.button_add.Name = "button_add";
            this.button_add.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_add.Size = new System.Drawing.Size(158, 44);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // Form_AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 435);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.groupBox_customer);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_AddCustomer";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a customer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_AddCustomer_FormClosed);
            this.Load += new System.EventHandler(this.Form_AddCustomer_Load);
            this.groupBox_photo.ResumeLayout(false);
            this.tableLayoutPanel_photo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).EndInit();
            this.groupBox_customer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_photo;
        private System.Windows.Forms.GroupBox groupBox_photo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_photo;
        private System.Windows.Forms.Button button_selectPhoto;
        private System.Windows.Forms.GroupBox groupBox_customer;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_birthDate;
        private System.Windows.Forms.Label label_birthDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_phoneNumber;
        private System.Windows.Forms.Label label_phoneNumber;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog_main;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_job;
        private System.Windows.Forms.Label label_job;
        private System.Windows.Forms.Button button_newJob;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}