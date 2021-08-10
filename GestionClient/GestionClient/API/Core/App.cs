using System.IO;
using System.Reflection;

namespace GestionClient
{
    static class App
    {
        #region Application-Infos-Properties
        public static string Name = "Gestion Client";
        public static readonly string FolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Application.StartupPath;
        public static readonly string DatabaseFolderName = "data";
        public static readonly string PiecesFolderPath = Path.Combine(DatabaseFolderName, "Pieces");
        #endregion

        #region Forms-Tracking-Properties
        public static bool AddCustomerFormOpened = false;
        public static bool AddJobFormOpened = false;
        public static bool RemoveJobFormOpened = false;
        public static bool EditJobFormOpened = false;
        public static bool CustomerListFormOpened = false;
        #endregion

        #region Search-Tracking-Properties
        public static int SearchResultIndex;
        #endregion

        /// <summary>
        /// Créer le dossier qui contiendra toutes les pieces de nos clients s'il n'exsite pas.
        /// </summary>
        public static void CreatePiecesFolder()
        {
            string path = Path.Combine(App.FolderPath, App.PiecesFolderPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
