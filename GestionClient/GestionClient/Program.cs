/*
* 
* Projet : Gestion Client / إدارة العملاء/العمال/الزبناء...
* 
* Version : 1.0
* 
* Date/Période de création : From : 28/10/2015, To : 05/11/2015
*
* Auteur : AXeL
* 
* A savoir :
*            - La suppression se fait en cascade, ex : si je supprime un travail à qui j'ai assigné des clients, ces clients seront alors aussi supprimés (pour ceux qui se demanderont pq, la réponse est simple, car la table Client contient l'id du travail, plus simplement, effacer un travail => effacer l'id du travail => effacer le client).
*
*/
using System;
using System.Windows.Forms;

namespace GestionClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
        }
    }
}
