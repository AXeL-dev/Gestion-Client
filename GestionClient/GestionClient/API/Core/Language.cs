using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GestionClient
{
    static class Language
    {
        private const string _languageResourceFileName = "GestionClient.Languages.Main";
        private static ResourceManager _languagesResourceManager = new ResourceManager(_languageResourceFileName, typeof(Form_Main).Assembly);
        private static CultureInfo _currentCulture = CultureInfo.CreateSpecificCulture("fr");

        public static MessageBoxOptions CurrentMessageBoxOptions = new MessageBoxOptions();

        public static bool IsRightToLeft
        {
            get
            {
                return _currentCulture.TextInfo.IsRightToLeft;
            }
        }

        #region Private-Methods
        /// <summary>
        /// Set values indicating whether the text is displayed right to left.
        /// </summary>
        private static void LocalizeMessageBoxes()
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
        /// Get all languages with available resources files.
        /// </summary>
        /// <returns>
        /// Dictionary key-value pairs where 
        /// the key is language two-letter name (example: ar) 
        /// and value is language display name (example: Arabic)
        /// </returns>
        public static Dictionary<string, string> GetAvailableLanguages()
        {
            Dictionary<string, string> languages = new Dictionary<string, string>();
            CultureInfo[] allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in allCultures)
            {
                if (!culture.Equals(CultureInfo.InvariantCulture) &&
                        _languagesResourceManager.GetResourceSet(culture, true, false) != null)
                {
                    languages.Add(culture.TwoLetterISOLanguageName, culture.DisplayName);
                }
            }
            return languages;
        }

        /// <summary>
        /// Get current language saved in database. 
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
            LocalizeMessageBoxes();
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
