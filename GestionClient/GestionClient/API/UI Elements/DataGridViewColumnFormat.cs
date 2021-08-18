using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace GestionClient
{
    static class DataGridViewColumnFormat
    {
        /// <summary>
        /// Applies a format on numbers in a column of a DataGridView control object.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="columnName"></param>
        /// <param name="currencySymbol"></param>
        public static void Number(DataGridView dataGridView, string columnName, string currencySymbol)
        {
            NumberFormatInfo numberFormat = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            numberFormat.CurrencySymbol = currencySymbol;
            numberFormat.CurrencyDecimalDigits = 0;
            dataGridView.Columns[columnName].DefaultCellStyle.FormatProvider = numberFormat;
            dataGridView.Columns[columnName].DefaultCellStyle.Format = "c";
        }
    }
}
