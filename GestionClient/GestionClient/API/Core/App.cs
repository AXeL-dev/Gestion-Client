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
        public static readonly string AssetsFolderPath = Path.Combine(DatabaseFolderName, "Pieces");
        #endregion

        #region Search-Tracking-Properties
        public static int SearchResultIndex;
        #endregion

        /// <summary>
        /// Créer le dossier qui contiendra toutes les pieces de nos clients s'il n'exsite pas.
        /// </summary>
        public static void CreateAssetsFolder()
        {
            string path = Path.Combine(App.FolderPath, App.AssetsFolderPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
