namespace GestionClient
{
    partial class ListeClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListeClients));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ListeClientGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FiltrerClientGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.NomLabel = new System.Windows.Forms.Label();
            this.NomTextBox = new System.Windows.Forms.TextBox();
            this.FiltrerTravailCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.TravailLabel = new System.Windows.Forms.Label();
            this.TravailCombo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.ImprimerBtn = new System.Windows.Forms.Button();
            this.ActualiserBtn = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            this.ListeClientGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.FiltrerClientGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ListeClientGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ListeClientGroupBox
            // 
            this.ListeClientGroupBox.Controls.Add(this.dataGridView1);
            this.ListeClientGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListeClientGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListeClientGroupBox.Location = new System.Drawing.Point(3, 155);
            this.ListeClientGroupBox.Name = "ListeClientGroupBox";
            this.ListeClientGroupBox.Size = new System.Drawing.Size(828, 349);
            this.ListeClientGroupBox.TabIndex = 1;
            this.ListeClientGroupBox.TabStop = false;
            this.ListeClientGroupBox.Text = "Liste des clients";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Size = new System.Drawing.Size(822, 326);
            this.dataGridView1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel2.Controls.Add(this.FiltrerClientGroupBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(828, 146);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // FiltrerClientGroupBox
            // 
            this.FiltrerClientGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.FiltrerClientGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltrerClientGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltrerClientGroupBox.Location = new System.Drawing.Point(3, 3);
            this.FiltrerClientGroupBox.Name = "FiltrerClientGroupBox";
            this.FiltrerClientGroupBox.Size = new System.Drawing.Size(639, 140);
            this.FiltrerClientGroupBox.TabIndex = 0;
            this.FiltrerClientGroupBox.TabStop = false;
            this.FiltrerClientGroupBox.Text = "Filtrer les clients";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.FiltrerTravailCheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(633, 117);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.NomLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.NomTextBox, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(342, 75);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // NomLabel
            // 
            this.NomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomLabel.AutoSize = true;
            this.NomLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomLabel.Location = new System.Drawing.Point(3, 29);
            this.NomLabel.Name = "NomLabel";
            this.NomLabel.Size = new System.Drawing.Size(96, 17);
            this.NomLabel.TabIndex = 0;
            this.NomLabel.Text = "Nom :";
            // 
            // NomTextBox
            // 
            this.NomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomTextBox.Location = new System.Drawing.Point(105, 25);
            this.NomTextBox.Name = "NomTextBox";
            this.NomTextBox.Size = new System.Drawing.Size(234, 25);
            this.NomTextBox.TabIndex = 1;
            this.NomTextBox.TextChanged += new System.EventHandler(this.NomTextBox_TextChanged);
            // 
            // FiltrerTravailCheckBox
            // 
            this.FiltrerTravailCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltrerTravailCheckBox.AutoSize = true;
            this.FiltrerTravailCheckBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiltrerTravailCheckBox.Location = new System.Drawing.Point(3, 88);
            this.FiltrerTravailCheckBox.Name = "FiltrerTravailCheckBox";
            this.FiltrerTravailCheckBox.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.FiltrerTravailCheckBox.Size = new System.Drawing.Size(342, 21);
            this.FiltrerTravailCheckBox.TabIndex = 1;
            this.FiltrerTravailCheckBox.Text = "Filtrer par travail aussi";
            this.FiltrerTravailCheckBox.UseVisualStyleBackColor = true;
            this.FiltrerTravailCheckBox.CheckedChanged += new System.EventHandler(this.FiltrerTravailCheckBox_CheckedChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.Controls.Add(this.TravailLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.TravailCombo, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(351, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(279, 75);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // TravailLabel
            // 
            this.TravailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TravailLabel.AutoSize = true;
            this.TravailLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravailLabel.Location = new System.Drawing.Point(3, 29);
            this.TravailLabel.Name = "TravailLabel";
            this.TravailLabel.Size = new System.Drawing.Size(77, 17);
            this.TravailLabel.TabIndex = 1;
            this.TravailLabel.Text = "Travail :";
            // 
            // TravailCombo
            // 
            this.TravailCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TravailCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TravailCombo.Enabled = false;
            this.TravailCombo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TravailCombo.FormattingEnabled = true;
            this.TravailCombo.Location = new System.Drawing.Point(86, 25);
            this.TravailCombo.Name = "TravailCombo";
            this.TravailCombo.Size = new System.Drawing.Size(190, 25);
            this.TravailCombo.TabIndex = 0;
            this.TravailCombo.SelectedIndexChanged += new System.EventHandler(this.TravailCombo_SelectedIndexChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.ImprimerBtn, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.ActualiserBtn, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(648, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(177, 140);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // ImprimerBtn
            // 
            this.ImprimerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImprimerBtn.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImprimerBtn.Image = global::GestionClient.Properties.Resources.print;
            this.ImprimerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImprimerBtn.Location = new System.Drawing.Point(3, 101);
            this.ImprimerBtn.Name = "ImprimerBtn";
            this.ImprimerBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ImprimerBtn.Size = new System.Drawing.Size(171, 36);
            this.ImprimerBtn.TabIndex = 1;
            this.ImprimerBtn.Text = "Imprimer";
            this.ImprimerBtn.UseVisualStyleBackColor = true;
            this.ImprimerBtn.Click += new System.EventHandler(this.ImprimerBtn_Click);
            // 
            // ActualiserBtn
            // 
            this.ActualiserBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActualiserBtn.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualiserBtn.Image = global::GestionClient.Properties.Resources.update;
            this.ActualiserBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ActualiserBtn.Location = new System.Drawing.Point(3, 59);
            this.ActualiserBtn.Name = "ActualiserBtn";
            this.ActualiserBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ActualiserBtn.Size = new System.Drawing.Size(171, 36);
            this.ActualiserBtn.TabIndex = 2;
            this.ActualiserBtn.Text = "Actualiser";
            this.ActualiserBtn.UseVisualStyleBackColor = true;
            this.ActualiserBtn.Click += new System.EventHandler(this.ActualiserBtn_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // ListeClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ListeClients";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liste des clients";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListeClients_FormClosed);
            this.Load += new System.EventHandler(this.ListeClients_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ListeClientGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.FiltrerClientGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox ListeClientGroupBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox FiltrerClientGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label NomLabel;
        private System.Windows.Forms.TextBox NomTextBox;
        private System.Windows.Forms.CheckBox FiltrerTravailCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label TravailLabel;
        private System.Windows.Forms.ComboBox TravailCombo;
        private System.Windows.Forms.Button ImprimerBtn;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button ActualiserBtn;
    }
}