using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace GestionClient
{
    static class Language
    {
        private const string _languageResourceFileName = "GestionClient.Languages.Res";
        private static ResourceManager _languagesResourceManager = new ResourceManager(_languageResourceFileName, typeof(Form_Main).Assembly);
        private static CultureInfo _currentCulture = CultureInfo.CreateSpecificCulture("fr");
        
        public static MessageBoxOptions CurrentMessageBoxOptions = new MessageBoxOptions();

        public static bool IsArabic
        {
            get
            {
                return (GetCurrentLanguage() == "ar");
            }
        }

        #region Private-Methods
        /// <summary>
        /// Set values indicating whether the text is displayed right to left.
        /// </summary>
        private static void SetMessageBoxesReadingDirection()
        {
            if (_currentCulture.TextInfo.IsRightToLeft)
            {
                Language.CurrentMessageBoxOptions = MessageBoxOptions.RightAlign
                    | MessageBoxOptions.RtlReading;
                MessageBoxManager.Yes = Language.GetString("MessageBox_YES");
                MessageBoxManager.No = Language.GetString("MessageBox_NO");
                MessageBoxManager.Register();

            }
            else
            {
                Language.CurrentMessageBoxOptions = new MessageBoxOptions();
                MessageBoxManager.Unregister();
            }
        }
        #endregion

        /// <summary>
        /// Retourne la langue actuelle.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentLanguage()
        {
            Database.FetchLangueTable();
            return Database.MainDataSet.Tables["Langue"].Rows[0]["abrv"].ToString();
        }

        /// <summary>
        /// Change et enregistre la langue actuelle dans la base de données.
        /// </summary>
        /// <param name="language"></param>
        public static void SetCurrentLanguage(string language)
        {
            _currentCulture = CultureInfo.CreateSpecificCulture(language);
            SetMessageBoxesReadingDirection();
            Database.MainDataSet.Tables["Langue"].Rows[0]["abrv"] = language;
            Database.ApplyChanges(Database.LangueDataAdapter, "Langue");
        }

        /// <summary>
        /// Obtient la valeur de la ressource System.String localisée pour la culture actuelle.
        /// </summary>
        /// <param name="name">Nom de la ressource à obtenir.</param>
        /// <returns>
        /// Valeur de la ressource localisée pour la culture spécifiée. 
        /// Si aucune correspondance n'est possible, null est retournée.
        /// </returns>
        public static string GetString(string name)
        {
            return _languagesResourceManager.GetString(name, _currentCulture);
        }
    }
}
