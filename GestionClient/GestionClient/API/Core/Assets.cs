using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace GestionClient
{
    static class Assets
    {
        public const string FolderPath = @"Data\Assets";

        /// <summary>
        /// Creates the folder (If it does not exist) that will contain all customers assets.
        /// </summary>
        public static void CreateFolder()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }

        /// <summary>
        /// Creates a sub-folder (If it does not exist) in the 
        /// assets folder that will contain assets for a customer.
        /// </summary>
        /// <param name="subfolderName">Subfolder Name.</param>
        public static string CreateSubfolder(string subfolderName)
        {
            string path = Path.Combine(FolderPath, subfolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return subfolderName;
        }

        /// <summary>
        /// Creates a sub-folder (If it does not exist) in the 
        /// assets folder that will contain assets for a customer
        /// using a Customer DataRow to generate the folder name.
        /// </summary>
        /// <param name="customerRow">Customer Row</param>
        /// <returns>Created folder name.</returns>
        public static string CreateSubfolder(DataRow customerRow)
        {
            string id = customerRow.Table.Columns.Contains("ID")
                ? customerRow["ID"].ToString() : string.Empty;
            string fullName = customerRow.Table.Columns.Contains("FullName")
                ? customerRow["FullName"].ToString() : string.Empty;
            string folderName = string.Format("{0}_{1}", id, fullName).Trim();
            return CreateSubfolder(folderName);
        }

        /// <summary>
        /// Copies a given file in the specified folder.
        /// </summary>
        /// <param name="sourceFilePath">File to copy.</param>
        /// <param name="destinationFolderPath">Folder where to copy the file.</param>
        /// <returns></returns>
        public static string CreateFile(string sourceFilePath, string destinationFolderPath)
        {
            string dateTimeString = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
            string sourceFileName = Path.GetFileName(sourceFilePath);
            string destinationFileName = string.Format("{0}_{1}", dateTimeString, sourceFileName);
            string destinationFilePath = Path.Combine(destinationFolderPath, destinationFileName);
            File.Copy(sourceFilePath, destinationFilePath, true);
            return destinationFilePath;
        }
    }
}
