using System;
using System.IO;
using System.Reflection;

namespace GestionClient
{
    static class App
    {
        #region Application-Infos-Properties
        public static String Name = "Gestion Client";
        public static String FolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Application.StartupPath;
        public const String DatabaseFolderName = "data";
        public const String PiecesFolderPath = DatabaseFolderName + "\\Pieces";
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
    }
}
