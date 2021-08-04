namespace GestionClient
{
    partial class RechercherNomClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RechercherNomClient));
            this.ClientGroupBox = new System.Windows.Forms.GroupBox();
            this.NomTextBox = new System.Windows.Forms.TextBox();
            this.NomLabel = new System.Windows.Forms.Label();
            this.RechercherBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClientGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientGroupBox
            // 
            this.ClientGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ClientGroupBox.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientGroupBox.Location = new System.Drawing.Point(13, 13);
            this.ClientGroupBox.Name = "ClientGroupBox";
            this.ClientGroupBox.Size = new System.Drawing.Size(372, 115);
            this.ClientGroupBox.TabIndex = 0;
            this.ClientGroupBox.TabStop = false;
            this.ClientGroupBox.Text = "Client";
            // 
            // NomTextBox
            // 
            this.NomTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomTextBox.Location = new System.Drawing.Point(82, 33);
            this.NomTextBox.Name = "NomTextBox";
            this.NomTextBox.Size = new System.Drawing.Size(271, 25);
            this.NomTextBox.TabIndex = 1;
            // 
            // NomLabel
            // 
            this.NomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NomLabel.AutoSize = true;
            this.NomLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomLabel.Location = new System.Drawing.Point(13, 37);
            this.NomLabel.Name = "NomLabel";
            this.NomLabel.Size = new System.Drawing.Size(63, 17);
            this.NomLabel.TabIndex = 0;
            this.NomLabel.Text = "Nom :";
            // 
            // RechercherBtn
            // 
            this.RechercherBtn.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RechercherBtn.Image = global::GestionClient.Properties.Resources.search;
            this.RechercherBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RechercherBtn.Location = new System.Drawing.Point(122, 147);
            this.RechercherBtn.Name = "RechercherBtn";
            this.RechercherBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.RechercherBtn.Size = new System.Drawing.Size(158, 44);
            this.RechercherBtn.TabIndex = 5;
            this.RechercherBtn.Text = "Rechercher";
            this.RechercherBtn.UseVisualStyleBackColor = true;
            this.RechercherBtn.Click += new System.EventHandler(this.RechercherBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.NomTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NomLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 92);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // RechercherNomClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 212);
            this.Controls.Add(this.RechercherBtn);
            this.Controls.Add(this.ClientGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RechercherNomClient";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rechercher un client";
            this.Load += new System.EventHandler(this.RechercherNomClient_Load);
            this.ClientGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ClientGroupBox;
        private System.Windows.Forms.TextBox NomTextBox;
        private System.Windows.Forms.Label NomLabel;
        private System.Windows.Forms.Button RechercherBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}