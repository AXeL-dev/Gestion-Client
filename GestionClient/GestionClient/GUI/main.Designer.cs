namespace GestionClient
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitterToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.travailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.àProposToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.InfosToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem2,
            this.clientToolStripMenuItem2,
            this.travailToolStripMenuItem,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem2
            // 
            this.applicationToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem,
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem,
            this.langueToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitterToolStripMenuItem4});
            this.applicationToolStripMenuItem2.Name = "applicationToolStripMenuItem2";
            this.applicationToolStripMenuItem2.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem2.Text = "&Application";
            this.applicationToolStripMenuItem2.DropDownOpened += new System.EventHandler(this.applicationToolStripMenuItem2_DropDownOpened);
            // 
            // connexionÀLaBaseDeDonnéesToolStripMenuItem
            // 
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem.Image = global::GestionClient.Properties.Resources._true;
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem.Name = "connexionÀLaBaseDeDonnéesToolStripMenuItem";
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem.Text = "Connexion à la base de données";
            this.connexionÀLaBaseDeDonnéesToolStripMenuItem.Click += new System.EventHandler(this.connexionÀLaBaseDeDonnéesToolStripMenuItem_Click);
            // 
            // sauvegarderLaBaseDeDonnéesToolStripMenuItem
            // 
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem.Image = global::GestionClient.Properties.Resources.save;
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem.Name = "sauvegarderLaBaseDeDonnéesToolStripMenuItem";
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem.Text = "Créer une sauvegarde de la base de données";
            this.sauvegarderLaBaseDeDonnéesToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderLaBaseDeDonnéesToolStripMenuItem_Click);
            // 
            // langueToolStripMenuItem
            // 
            this.langueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.françaisToolStripMenuItem,
            this.arabeToolStripMenuItem});
            this.langueToolStripMenuItem.Image = global::GestionClient.Properties.Resources.language;
            this.langueToolStripMenuItem.Name = "langueToolStripMenuItem";
            this.langueToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.langueToolStripMenuItem.Text = "Langue";
            // 
            // françaisToolStripMenuItem
            // 
            this.françaisToolStripMenuItem.Checked = true;
            this.françaisToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.françaisToolStripMenuItem.Name = "françaisToolStripMenuItem";
            this.françaisToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.françaisToolStripMenuItem.Text = "Français";
            this.françaisToolStripMenuItem.Click += new System.EventHandler(this.françaisToolStripMenuItem_Click);
            // 
            // arabeToolStripMenuItem
            // 
            this.arabeToolStripMenuItem.Name = "arabeToolStripMenuItem";
            this.arabeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.arabeToolStripMenuItem.Text = "Arabe";
            this.arabeToolStripMenuItem.Click += new System.EventHandler(this.arabeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(304, 6);
            // 
            // quitterToolStripMenuItem4
            // 
            this.quitterToolStripMenuItem4.Image = global::GestionClient.Properties.Resources.exit;
            this.quitterToolStripMenuItem4.Name = "quitterToolStripMenuItem4";
            this.quitterToolStripMenuItem4.Size = new System.Drawing.Size(307, 22);
            this.quitterToolStripMenuItem4.Text = "Quitter";
            this.quitterToolStripMenuItem4.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem2
            // 
            this.clientToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem3,
            this.modifierToolStripMenuItem,
            this.listeToolStripMenuItem});
            this.clientToolStripMenuItem2.Name = "clientToolStripMenuItem2";
            this.clientToolStripMenuItem2.Size = new System.Drawing.Size(50, 20);
            this.clientToolStripMenuItem2.Text = "&Client";
            // 
            // ajouterToolStripMenuItem3
            // 
            this.ajouterToolStripMenuItem3.Image = global::GestionClient.Properties.Resources.person_add;
            this.ajouterToolStripMenuItem3.Name = "ajouterToolStripMenuItem3";
            this.ajouterToolStripMenuItem3.Size = new System.Drawing.Size(179, 22);
            this.ajouterToolStripMenuItem3.Text = "Ajouter";
            this.ajouterToolStripMenuItem3.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Image = global::GestionClient.Properties.Resources.edit;
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.modifierToolStripMenuItem.Text = "Modifier/Supprimer";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // listeToolStripMenuItem
            // 
            this.listeToolStripMenuItem.Image = global::GestionClient.Properties.Resources.document_file;
            this.listeToolStripMenuItem.Name = "listeToolStripMenuItem";
            this.listeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.listeToolStripMenuItem.Text = "Liste";
            this.listeToolStripMenuItem.Click += new System.EventHandler(this.listeToolStripMenuItem_Click);
            // 
            // travailToolStripMenuItem
            // 
            this.travailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem4,
            this.supprimerToolStripMenuItem});
            this.travailToolStripMenuItem.Name = "travailToolStripMenuItem";
            this.travailToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.travailToolStripMenuItem.Text = "&Travail";
            // 
            // ajouterToolStripMenuItem4
            // 
            this.ajouterToolStripMenuItem4.Image = global::GestionClient.Properties.Resources.tag;
            this.ajouterToolStripMenuItem4.Name = "ajouterToolStripMenuItem4";
            this.ajouterToolStripMenuItem4.Size = new System.Drawing.Size(129, 22);
            this.ajouterToolStripMenuItem4.Text = "Ajouter";
            this.ajouterToolStripMenuItem4.Click += new System.EventHandler(this.ajouterToolStripMenuItem4_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Image = global::GestionClient.Properties.Resources.close_delete;
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.àProposToolStripMenuItem1});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem3.Text = "?";
            // 
            // àProposToolStripMenuItem1
            // 
            this.àProposToolStripMenuItem1.Image = global::GestionClient.Properties.Resources.information;
            this.àProposToolStripMenuItem1.Name = "àProposToolStripMenuItem1";
            this.àProposToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.àProposToolStripMenuItem1.Text = "À propos";
            this.àProposToolStripMenuItem1.Click += new System.EventHandler(this.àProposToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfosToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(969, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // InfosToolStripStatusLabel
            // 
            this.InfosToolStripStatusLabel.Name = "InfosToolStripStatusLabel";
            this.InfosToolStripStatusLabel.Size = new System.Drawing.Size(141, 17);
            this.InfosToolStripStatusLabel.Text = "InfosToolStripStatusLabel";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "zip";
            this.saveFileDialog1.Filter = "Zip Files|*.zip|Rar Files|*.rar";
            this.saveFileDialog1.Title = "Choix de l\'emplacement de sauvegarde";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 544);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Client";
            this.Load += new System.EventHandler(this.main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem listeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem àProposToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel InfosToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem connexionÀLaBaseDeDonnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem travailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderLaBaseDeDonnéesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem langueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem françaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arabeToolStripMenuItem;
    }
}

