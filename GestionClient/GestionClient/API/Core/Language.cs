using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace GestionClient
{
    static class Language
    {
        public static ResourceManager LanguagesResourceManager = new ResourceManager("GestionClient.Languages.Res", typeof(Form_Main).Assembly);
        public static CultureInfo CurrentCulture = CultureInfo.CreateSpecificCulture("fr");
        public static MessageBoxOptions CurrentMessageBoxOptions = new MessageBoxOptions();

        public static bool IsArabic
        {
            get
            {
                return (GetCurrentLanguage() == "ar");
            }
        }

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
        /// Enregistre la langue actuelle dans la base de données.
        /// </summary>
        /// <param name="language"></param>
        public static void SetCurrentLanguage(string language)
        {
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
            return LanguagesResourceManager.GetString(name, CurrentCulture);
        }
    }
}
