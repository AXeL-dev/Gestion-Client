﻿using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using GestionClient.Localization;

namespace GestionClient
{
    static class Language
    {
        public static MessageBoxOptions CurrentMessageBoxOptions = new MessageBoxOptions();

        public static bool IsRightToLeft
        {
            get
            {
                return LocalizedStrings.Culture.TextInfo.IsRightToLeft;
            }
        }

        #region Private-Methods
        /// <summary>
        /// Set values indicating whether the text is displayed right to left.
        /// </summary>
        private static void LocalizeMessageBoxes()
        {
            if (LocalizedStrings.Culture.TextInfo.IsRightToLeft)
            {
                Language.CurrentMessageBoxOptions = MessageBoxOptions.RightAlign
                    | MessageBoxOptions.RtlReading;
                MessageBoxManager.Yes = LocalizedStrings.MessageBox_YES;
                MessageBoxManager.No = LocalizedStrings.MessageBox_NO;
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
            CultureInfo defaultCulture = CultureInfo.GetCultureInfo("en");
            languages.Add(defaultCulture.TwoLetterISOLanguageName,
                defaultCulture.TextInfo.ToTitleCase(defaultCulture.NativeName));
            foreach (CultureInfo culture in allCultures)
            {
                if (!culture.Equals(CultureInfo.InvariantCulture) &&
                    LocalizedStrings.ResourceManager.GetResourceSet(culture, true, false) != null)
                {
                    languages.Add(culture.TwoLetterISOLanguageName,
                        culture.TextInfo.ToTitleCase(culture.NativeName));
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
            Localization.LocalizedStrings.Culture = CultureInfo.CreateSpecificCulture(language);
            LocalizeMessageBoxes();
            Database.MainDataSet.Tables["Langue"].Rows[0]["abrv"] = language;
            Database.ApplyChanges(Database.LangueDataAdapter, "Langue");
        }
    }
}
