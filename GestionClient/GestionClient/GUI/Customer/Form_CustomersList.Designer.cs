namespace GestionClient
{
    partial class Form_CustomersList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CustomersList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_customersList = new System.Windows.Forms.GroupBox();
            this.dataGridView_customers = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_filterCustomers = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label_name = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.checkBox_filterByJob = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label_job = new System.Windows.Forms.Label();
            this.comboBox_job = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button_print = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.printDocument_main = new System.Drawing.Printing.PrintDocument();
            this.printDialog_main = new System.Windows.Forms.PrintDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox_customersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_customers)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox_filterCustomers.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.groupBox_customersList, 0, 1);
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
            // groupBox_customersList
            // 
            this.groupBox_customersList.Controls.Add(this.dataGridView_customers);
            this.groupBox_customersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_customersList.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_customersList.Location = new System.Drawing.Point(3, 155);
            this.groupBox_customersList.Name = "groupBox_customersList";
            this.groupBox_customersList.Size = new System.Drawing.Size(828, 349);
            this.groupBox_customersList.TabIndex = 1;
            this.groupBox_customersList.TabStop = false;
            this.groupBox_customersList.Text = "Customers list";
            // 
            // dataGridView_customers
            // 
            this.dataGridView_customers.AllowUserToAddRows = false;
            this.dataGridView_customers.AllowUserToDeleteRows = false;
            this.dataGridView_customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_customers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_customers.Location = new System.Drawing.Point(3, 20);
            this.dataGridView_customers.Name = "dataGridView_customers";
            this.dataGridView_customers.ReadOnly = true;
            this.dataGridView_customers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_customers.Size = new System.Drawing.Size(822, 326);
            this.dataGridView_customers.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_filterCustomers, 0, 0);
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
            // groupBox_filterCustomers
            // 
            this.groupBox_filterCustomers.Controls.Add(this.tableLayoutPanel3);
            this.groupBox_filterCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_filterCustomers.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_filterCustomers.Location = new System.Drawing.Point(3, 3);
            this.groupBox_filterCustomers.Name = "groupBox_filterCustomers";
            this.groupBox_filterCustomers.Size = new System.Drawing.Size(639, 140);
            this.groupBox_filterCustomers.TabIndex = 0;
            this.groupBox_filterCustomers.TabStop = false;
            this.groupBox_filterCustomers.Text = "Filter customers";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBox_filterByJob, 0, 1);
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
            this.tableLayoutPanel4.Controls.Add(this.label_name, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_name, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(342, 75);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label_name
            // 
            this.label_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(3, 29);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(96, 17);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Name :";
            // 
            // textBox_name
            // 
            this.textBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(105, 25);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(234, 25);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // checkBox_filterByJob
            // 
            this.checkBox_filterByJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_filterByJob.AutoSize = true;
            this.checkBox_filterByJob.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_filterByJob.Location = new System.Drawing.Point(3, 88);
            this.checkBox_filterByJob.Name = "checkBox_filterByJob";
            this.checkBox_filterByJob.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.checkBox_filterByJob.Size = new System.Drawing.Size(342, 21);
            this.checkBox_filterByJob.TabIndex = 1;
            this.checkBox_filterByJob.Text = "Filter by job too";
            this.checkBox_filterByJob.UseVisualStyleBackColor = true;
            this.checkBox_filterByJob.CheckedChanged += new System.EventHandler(this.checkBox_filterByJob_CheckedChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.Controls.Add(this.label_job, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboBox_job, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(351, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(279, 75);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // label_job
            // 
            this.label_job.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_job.AutoSize = true;
            this.label_job.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_job.Location = new System.Drawing.Point(3, 29);
            this.label_job.Name = "label_job";
            this.label_job.Size = new System.Drawing.Size(77, 17);
            this.label_job.TabIndex = 1;
            this.label_job.Text = "Job :";
            // 
            // comboBox_job
            // 
            this.comboBox_job.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_job.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_job.Enabled = false;
            this.comboBox_job.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_job.FormattingEnabled = true;
            this.comboBox_job.Location = new System.Drawing.Point(86, 25);
            this.comboBox_job.Name = "comboBox_job";
            this.comboBox_job.Size = new System.Drawing.Size(190, 25);
            this.comboBox_job.TabIndex = 0;
            this.comboBox_job.SelectedIndexChanged += new System.EventHandler(this.comboBox_job_SelectedIndexChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.button_print, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.button_refresh, 0, 1);
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
            // button_print
            // 
            this.button_print.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_print.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_print.Image = global::GestionClient.Properties.Resources.print;
            this.button_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_print.Location = new System.Drawing.Point(3, 101);
            this.button_print.Name = "button_print";
            this.button_print.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_print.Size = new System.Drawing.Size(171, 36);
            this.button_print.TabIndex = 1;
            this.button_print.Text = "Print";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_refresh.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Image = global::GestionClient.Properties.Resources.update;
            this.button_refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_refresh.Location = new System.Drawing.Point(3, 59);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.button_refresh.Size = new System.Drawing.Size(171, 36);
            this.button_refresh.TabIndex = 2;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // printDocument_main
            // 
            this.printDocument_main.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_main_PrintPage);
            // 
            // printDialog_main
            // 
            this.printDialog_main.Document = this.printDocument_main;
            this.printDialog_main.UseEXDialog = true;
            // 
            // Form_CustomersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form_CustomersList";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers list";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_CustomersList_FormClosed);
            this.Load += new System.EventHandler(this.Form_CustomersList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox_customersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_customers)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox_filterCustomers.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox_customersList;
        private System.Windows.Forms.DataGridView dataGridView_customers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox_filterCustomers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.CheckBox checkBox_filterByJob;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label_job;
        private System.Windows.Forms.ComboBox comboBox_job;
        private System.Windows.Forms.Button button_print;
        private System.Drawing.Printing.PrintDocument printDocument_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.PrintDialog printDialog_main;
    }
}