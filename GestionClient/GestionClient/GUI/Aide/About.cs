using System;
using System.Windows.Forms;

namespace GestionClient
{
    public partial class About : Form
    {
        // constr.
        public About()
        {
            InitializeComponent();
        }

        // event. Load du formulaire
        private void About_Load(object sender, EventArgs e)
        {
            // On affiche le nom de l'application
            AppNameGroupBox.Text = API.AppName;

            // On affiche les informations de l'app.
            AppInfosTextBox.Text = API.resManager.GetString("About_Version", API.cul) + "\r\n\r\n" +
                                   API.resManager.GetString("About_Dev", API.cul) + "\r\n\r\n" +
                                   API.resManager.GetString("About_DotNet_Version", API.cul) + "\r\n\r\n" +
                                   API.resManager.GetString("About_Compatibilité", API.cul) + "\r\n\r\n" +
                                   API.resManager.GetString("About_Copyright", API.cul) + "\r\n\r\n" +
                                   API.resManager.GetString("About_End", API.cul);

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
