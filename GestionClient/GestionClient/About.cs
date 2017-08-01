using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
            AppNameGroupBox.Text = ClassGlobal.AppName;

            // On affiche les informations de l'app.
            AppInfosTextBox.Text = ClassGlobal.resManager.GetString("About_Version", ClassGlobal.cul) + "\r\n\r\n" +
                                   ClassGlobal.resManager.GetString("About_Dev", ClassGlobal.cul) + "\r\n\r\n" +
                                   ClassGlobal.resManager.GetString("About_DotNet_Version", ClassGlobal.cul) + "\r\n\r\n" +
                                   ClassGlobal.resManager.GetString("About_Compatibilité", ClassGlobal.cul) + "\r\n\r\n" +
                                   ClassGlobal.resManager.GetString("About_Copyright", ClassGlobal.cul) + "\r\n\r\n" +
                                   ClassGlobal.resManager.GetString("About_End", ClassGlobal.cul);

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
