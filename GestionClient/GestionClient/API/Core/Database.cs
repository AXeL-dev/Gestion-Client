using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace GestionClient
{
    static class Database
    {
        #region Database-Access-Properties
        public static bool ConnectedToDatabase = false;
        public static OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + App.FolderPath + "\\data\\gestionClient.mdb;User Id=admin;Password=;");
        public static OleDbDataAdapter ClientDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter PiecesDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter PaiementDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter TravailDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter ClientTravailPaiementDataAdapter = new OleDbDataAdapter("", Connection);
        public static OleDbDataAdapter LangueDataAdapter = new OleDbDataAdapter("", Connection);
        public static DataSet MainDataSet = new DataSet();
        #endregion

        #region Database-Update-Methods
        /// <summary>
        /// Applique les changements à la table spécifiée.
        /// </summary>
        /// <param name="dataAdapter"></param>
        /// <param name="tableName"></param>
        public static void ApplyChanges(OleDbDataAdapter dataAdapter, string tableName)
        {
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
            dataAdapter.Update(MainDataSet.Tables[tableName]);
        }
        #endregion

        #region Database-Table-Fetching-Methods
        /// <summary>
        /// Récupère toutes les tables.
        /// </summary>
        /// <param name="infosToolStripStatusLabel"></param>
        public static void FetchAllTables()
        {
            FetchClientTable();
            FetchPiecesTable();
            FetchPaiementTable();
            FetchTravailTable();
            ConnectedToDatabase = true;
        }

        /// <summary>
        /// Récupère la table Client.
        /// </summary>
        public static void FetchClientTable()
        {
            ClientDataAdapter.SelectCommand.CommandText = "SELECT * FROM Client ORDER BY nom";
            if (MainDataSet.Tables.Contains("Client")) // si une ancienne dataTable existe on l'efface
                MainDataSet.Tables["Client"].Clear();
            ClientDataAdapter.Fill(MainDataSet, "Client");
        }

        /// <summary>
        /// Récupère la table Pieces.
        /// </summary>
        public static void FetchPiecesTable()
        {
            PiecesDataAdapter.SelectCommand.CommandText = "SELECT * FROM Pieces";
            if (MainDataSet.Tables.Contains("Pieces")) // si une ancienne dataTable existe on l'efface
                MainDataSet.Tables["Pieces"].Clear();
            PiecesDataAdapter.Fill(MainDataSet, "Pieces");
        }

        /// <summary>
        /// Récupère la table Paiement.
        /// </summary>
        public static void FetchPaiementTable()
        {
            PaiementDataAdapter.SelectCommand.CommandText = "SELECT * FROM Paiement";
            if (MainDataSet.Tables.Contains("Paiement")) // si une ancienne dataTable existe on l'efface
                MainDataSet.Tables["Paiement"].Clear();
            PaiementDataAdapter.Fill(MainDataSet, "Paiement");
        }

        /// <summary>
        /// Récupère la table Travail.
        /// </summary>
        public static void FetchTravailTable()
        {
            TravailDataAdapter.SelectCommand.CommandText = "SELECT * FROM Travail";
            if (MainDataSet.Tables.Contains("Travail")) // si une ancienne dataTable existe on l'efface
                MainDataSet.Tables["Travail"].Clear();
            TravailDataAdapter.Fill(MainDataSet, "Travail");
        }

        /// <summary>
        /// Récupère la table Langue.
        /// </summary>
        public static void FetchLangueTable()
        {
            LangueDataAdapter.SelectCommand.CommandText = "SELECT * FROM Langue";
            if (MainDataSet.Tables.Contains("Langue")) // si on a pas encore récupéré la Table 'Langue'
                MainDataSet.Tables["Langue"].Clear();
            LangueDataAdapter.Fill(MainDataSet, "Langue");
        }

        /// <summary>
        /// Joigne les tables Client, Travail, et Paiement dans une seul DataTable.
        /// </summary>
        public static void FetchClientTravailPaiementTable()
        {
            ClientTravailPaiementDataAdapter.SelectCommand.CommandText = "SELECT nom, sexe, description AS [travail], DateDiff('yyyy', date_naissance, Date()) AS [age], date_naissance AS [date de naissance], numero_telephone AS [numéro tél], email, SUM(montant) AS [montant payé], date_ajout AS [ajouté le] FROM ((Client " +
                                                                "INNER JOIN Travail ON Travail.id = Client.id_travail) " +
                                                                "LEFT OUTER JOIN Paiement ON Paiement.id_client = Client.id) " +
                                                                "GROUP BY nom, sexe, description, date_naissance, numero_telephone, email, date_ajout";
            if (MainDataSet.Tables.Contains("ClientTravailPaiement")) // si une ancienne dataTable existe on l'efface
                MainDataSet.Tables["ClientTravailPaiement"].Clear();
            ClientTravailPaiementDataAdapter.Fill(MainDataSet, "ClientTravailPaiement");
        }
        #endregion
    }
}
