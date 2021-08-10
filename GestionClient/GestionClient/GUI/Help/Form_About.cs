using System;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    public partial class Form_About : Form
    {
        // constr.
        public Form_About()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void About_Load(object sender, EventArgs e)
        {
            // On affiche le nom de l'application
            AppNameGroupBox.Text = App.Name;

            // On affiche les informations de l'app.
            AppInfosTextBox.Text = LocalizedStrings.About_Version + "\r\n\r\n" +
                                   LocalizedStrings.About_Dev + "\r\n\r\n" +
                                   LocalizedStrings.About_DotNet_Version + "\r\n\r\n" +
                                   LocalizedStrings.About_Compatibilité + "\r\n\r\n" +
                                   LocalizedStrings.About_Copyright + "\r\n\r\n" +
                                   LocalizedStrings.About_End;

            // On bouge le curseur de séléction au début (0), car on obtient un texte completement séléctionné au départ
            AppInfosTextBox.Select(0, 0);
        }

        // event. Click du boutton 'OkBtn'
        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
