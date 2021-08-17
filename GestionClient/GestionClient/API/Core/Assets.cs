using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;

namespace GestionClient
{
    static class Assets
    {
        public const string RootFolderPath = @"Data\Assets";

        #region Private-Methods
        /// <summary>
        /// Uses columns from a Customer DataRow object to generate 
        /// the name of the assets subfolder destined to contain all 
        /// assets associated with the given customer.
        /// </summary>
        /// <param name="customerRow">Customer DataRow.</param>
        /// <returns>Customer assets subfolder name.</returns>
        private static string GetSubfolderName(DataRow customerRow)
        {
            return string.Format("{0}_{1}", customerRow["ID"], customerRow["FullName"]);
        }

        /// <summary>
        /// Generates a new unique file name from a given file path. 
        /// The generated name is destined to be given to the file  when 
        /// saved in the assets folder to avoid any potential duplicate names.
        /// </summary>
        /// <param name="filePath">Source file path.</param>
        /// <returns>Generated new unique file name.</returns>
        private static string GenerateFileName(string filePath)
        {
            string dateTimeString = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
            string sourceFileName = Path.GetFileName(filePath);
            return string.Format("{0}_{1}", dateTimeString, sourceFileName);
        }
        #endregion

        /// <summary>
        /// Creates the assets root folder If it does not exist.
        /// The folder will contain all customers assets.
        /// </summary>
        public static void CreateRootFolder()
        {
            if (!Directory.Exists(RootFolderPath))
            {
                Directory.CreateDirectory(RootFolderPath);
            }
        }

        /// <summary>
        /// Creates a new asset by copying the specified file in a subfolder of the 
        /// root assets folder associated with the specified customer and adds a new
        /// row for the created asset in the Assets table in database.
        /// </summary>
        /// <param name="sourceFilePath">Path of the file to copy.</param>
        /// <param name="customerRow">DataRow object of the associated customer.</param>
        /// <param name="assetType">Type of the asset (Photo or Other).</param>
        public static void Add(string sourceFilePath, DataRow customerRow, string assetType = "Other")
        {
            string subfolderPath = Path.Combine(RootFolderPath, GetSubfolderName(customerRow));
            string destinationFileName = GenerateFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(subfolderPath, destinationFileName);
            File.Copy(sourceFilePath, destinationFilePath, true);
            Database.Assets.Table.Rows.Add(null, customerRow["ID"], destinationFileName, assetType);
            Database.Assets.ApplyChanges();
            Database.Assets.FetchTable();
        }

        /// <summary>
        /// Creates a new asset by copying the specified file in a subfolder of the 
        /// root assets folder associated with the specified customer and adds a new
        /// row for the created asset in the Assets table in database.
        /// </summary>
        /// <param name="sourceFilePath">Path of the file to copy.</param>
        /// <param name="customerID">ID of the associated customer.</param>
        /// <param name="assetType">Type of the asset (Photo or Other).</param>
        public static void Add(string sourceFilePath, int customerID, string assetType = "Other")
        {
            var customerRow = Database.Customers.GetFirstRowWhere("ID = '{0}'", customerID);
            Add(sourceFilePath, customerRow, assetType);
        }

        /// <summary>
        /// Creates a new asset by copying the specified file in a subfolder of the 
        /// root assets folder associated with the specified customer and adds a new
        /// row for the created asset in the Assets table in database.
        /// </summary>
        /// <param name="sourceFilePath">Path of the file to copy.</param>
        /// <param name="customerFullName">FullName of the associated customer.</param>
        /// <param name="assetType">Type of the asset (Photo or Other).</param>
        public static void Add(string sourceFilePath, string customerFullName, string assetType = "Other")
        {
            var customerRow = Database.Customers.GetFirstRowWhere("FullName = '{0}'", customerFullName);
            Add(sourceFilePath, customerRow, assetType);
        }

        /// <summary>
        /// Gets an Image object containing the asset associated
        /// with the specified customer and having the specified 
        /// type (Photo or Other).
        /// </summary>
        /// <param name="customerID">ID of the associated customer.</param>
        /// <param name="assetType">Type of the asset (Photo or Other).</param>
        /// <returns>Asset Image object.</returns>
        public static Image Get(int customerID, string assetType = "Other")
        {
            var customerRow = Database.Customers.GetFirstRowWhere("ID = '{0}'", customerID);
            var assetRow = Database.Assets
                .GetFirstRowWhere("CustomerID = '{0}' AND AssetType = '{1}'", customerID, assetType);
            string filePath = Path.Combine(
                GetSubfolderName(customerRow),
                assetRow["FileName"].ToString());
            filePath = Path.Combine(RootFolderPath, filePath);
            return Image.FromFile(filePath);
        }
    }
}
