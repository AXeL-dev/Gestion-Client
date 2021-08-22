using System;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
            Language.Changed += (s, args) => this.UpdateLocalization();
        }

        #region Common-Methods
        private void UpdateLocalization()
        {
            this.RightToLeft = Language.IsRightToLeft ? RightToLeft.Yes : RightToLeft.No;

            this.Text = LocalizedStrings.A_propos_Sub_Menu;

            textBox_infos.Clear();

            textBox_infos.AppendText(LocalizedStrings.About_Version);
            textBox_infos.AppendText(Environment.NewLine);
            textBox_infos.AppendText(Environment.NewLine);

            textBox_infos.AppendText(LocalizedStrings.About_Dev);
            textBox_infos.AppendText(Environment.NewLine);
            textBox_infos.AppendText(Environment.NewLine);

            textBox_infos.AppendText(LocalizedStrings.About_DotNet_Version);
            textBox_infos.AppendText(Environment.NewLine);
            textBox_infos.AppendText(Environment.NewLine);

            textBox_infos.AppendText(LocalizedStrings.About_Compatibilité);
            textBox_infos.AppendText(Environment.NewLine);
            textBox_infos.AppendText(Environment.NewLine);

            textBox_infos.AppendText(LocalizedStrings.About_Copyright);
            textBox_infos.AppendText(Environment.NewLine);
            textBox_infos.AppendText(Environment.NewLine);

            textBox_infos.AppendText(LocalizedStrings.About_End);
        }
        #endregion

        private void Form_About_Load(object sender, EventArgs e)
        {
            groupBox_name.Text = App.Name;
            UpdateLocalization();
            textBox_infos.Select(0, 0);
        }

        private void Form_About_FormClosed(object sender, FormClosedEventArgs e)
        {
            Language.Changed -= (s, args) => this.UpdateLocalization();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
