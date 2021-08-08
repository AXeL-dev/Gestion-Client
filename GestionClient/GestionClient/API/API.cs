using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace GestionClient
{
    static partial class API
    {
        #region App-Infos-Properties
        public static String AppName = "Gestion Client";
        public static String AppFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Application.StartupPath;
        public const String AppDatabaseFolder = "data";
        public const String AppPiecesFolder = AppDatabaseFolder + "\\Pieces";
        #endregion

        #region Forms-Tracking-Properties
        public static bool AddCustomerFormOpened = false;
        public static bool AddJobFormOpened = false;
        public static bool RemoveJobFormOpened = false;
        public static bool EditJobFormOpened = false;
        public static bool CustomerListFormOpened = false;
        #endregion

        #region Database-Access-Properties
        public static bool ConnectedToDatabase = false;
        public static OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppFolderPath + "\\data\\gestionClient.mdb;User Id=admin;Password=;");
        public static OleDbDataAdapter ClientDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter PiecesDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter PaiementDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter TravailDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter ClientTravailPaiementDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter LangueDataAdapter = new OleDbDataAdapter("", Connection);
        public static DataSet MainDataSet = new DataSet();
        #endregion

        #region Language-Setup-Properties
        public static ResourceManager LanguagesResourceManager = new ResourceManager("GestionClient.Languages.Res", typeof(Form_Main).Assembly);
        public static CultureInfo CurrentCulture = CultureInfo.CreateSpecificCulture("fr"); // langue française par défaut
        public static MessageBoxOptions CurrentMessageBoxOptions = new MessageBoxOptions();
        #endregion

        #region Search-Tracking-Properties
        public static int SearchResultIndex;
        #endregion
    }
}
