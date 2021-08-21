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
            var customerRow = Database.Customers.GetFirstRowWhere("ID = {0}", customerID);
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
        /// Removes an asset from database and from the assets folder.
        /// </summary>
        /// <param name="assetID">ID of the asset in database.</param>
        public static void Remove(int assetID)
        {
            DataRow assetRow = Database.Assets.GetFirstRowWhere("ID = {0}", assetID);
            File.Delete(GetFilePath(assetRow));
            assetRow.Delete();
            Database.Assets.ApplyChanges();
        }

        /// <summary>
        /// Removes an asset from database and from the assets folder.
        /// </summary>
        /// <param name="imageAsset">ImageAsset object.</param>
        public static void Remove(ImageAsset imageAsset)
        {
            Remove(imageAsset.ID);
        }

        /// <summary>
        /// Removes all assets associated with the specified customer.
        /// </summary>
        /// <param name="customerRow">Customer DataRow.</param>
        public static void RemoveAll(DataRow customerRow)
        {
            string subfolderPath = Path.Combine(RootFolderPath, GetSubfolderName(customerRow));
            if (Directory.Exists(subfolderPath))
            {
                Directory.Delete(subfolderPath, true);
            }
        }

        /// <summary>
        /// Gets the file path of an asset using an asset DataRow.
        /// </summary>
        /// <param name="assetRow">Asset DataRow.</param>
        /// <returns>Asset file path.</returns>
        public static string GetFilePath(DataRow assetRow)
        {
            int customerID = Convert.ToInt32(assetRow["customerID"]);
            var customerRow = Database.Customers.GetFirstRowWhere("ID = {0}", customerID);
            string filePath = Path.Combine(GetSubfolderName(customerRow), assetRow["FileName"].ToString());
            return Path.Combine(RootFolderPath, filePath);
        }

        /// <summary>
        /// Gets an array of containing all the assets associated
        /// with the specified customer and having the specified 
        /// type (Photo or Other).
        /// </summary>
        /// <param name="customerID">ID of the associated customer.</param>
        /// <param name="assetType">Type of the asset (Photo or Other).</param>
        /// <returns>Asset Image object.</returns>
        public static ImageAsset[] Get(int customerID, string assetType = "Other")
        {
            var customerRow = Database.Customers.GetFirstRowWhere("ID = {0}", customerID);
            if (customerRow != null)
            {
                var assetsRows = Database.Assets
                    .GetRowsWhere("CustomerID = {0} AND AssetType = '{1}'", customerID, assetType);
                if (assetsRows.Length > 0)
                {
                    var assets = new ImageAsset[assetsRows.Length];
                    for (int i = 0; i < assetsRows.Length; i++)
                    {
                        string filePath = Path.Combine(
                            GetSubfolderName(customerRow),
                            assetsRows[i]["FileName"].ToString());
                        filePath = Path.Combine(RootFolderPath, filePath);
                        assets[i] = new ImageAsset
                        (
                            id: Convert.ToInt32(assetsRows[i]["ID"]),
                            customerID: Convert.ToInt32(assetsRows[i]["CustomerID"]),
                            filePath: filePath,
                            type: assetsRows[i]["AssetType"].ToString(),
                            image: Image.FromFile(filePath)
                        );
                        assets[i].Image.Tag = assets[i].ID;
                    }
                    return assets;
                }
            }
            return new ImageAsset[0];
        }

        /// <summary>
        /// Gets a ImageAsset object containing the asset associated
        /// with the specified customer and having the specified type (Photo or Other).
        /// </summary>
        /// <param name="customerID">ID of the associated customer.</param>
        /// <param name="assetType">Type of the asset (Photo or Other).</param>
        /// <returns>Asset Image object.</returns>
        public static ImageAsset GetFirst(int customerID, string assetType = "Other")
        {
            ImageAsset[] assets = Get(customerID, assetType);
            return assets.Length > 0 ? assets[0] : null;
        }
    }

    class ImageAsset
    {
        /// <summary>
        /// Generated unique ID of the asset object.
        /// </summary>
        public Guid GUID { get; private set; }

        /// <summary>
        /// ID of the asset in database.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// CustomerID of the asset in database.
        /// </summary>
        public int CustomerID { get; private set; }

        /// <summary>
        /// FilePath of the asset (Built form FileName in database).
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// AssetType of the asset in database.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Image object containing the asset.
        /// </summary>
        public Image Image { get; private set; }

        public ImageAsset(int id, int customerID, string filePath, string type, Image image)
        {
            this.GUID = Guid.NewGuid();
            this.ID = id;
            this.CustomerID = customerID;
            this.FilePath = FilePath;
            this.Type = type;
            this.Image = image;
        }
    }
}
