using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing; // for Class => Color
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms; // for Class => ToolStripStatusLabel

namespace GestionClient
{
    class API
    {
        // attributs
        public static String AppName = "Gestion Client";
        public static String AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //Application.StartupPath;
        public static String AppDbFolder = "data";
        public static String PiecesSaveFolder = AppDbFolder + "\\Pieces";
        public static bool isAjouterClientOpened = false, isAjouterTravailOpened = false, isSupprimerTravailOpened = false, isModifierTavailOpened = false, isListeClientsOpened = false;
        public static bool isConnectedToDb = false;
        public static OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppPath + "\\data\\gestionClient.mdb;User Id=admin;Password=;");
        public static DataSet ds = new DataSet();
        public static OleDbDataAdapter daClient = new OleDbDataAdapter("", cn);
        public static OleDbDataAdapter daPieces = new OleDbDataAdapter("", cn);
        public static OleDbDataAdapter daPaiement = new OleDbDataAdapter("", cn);
        public static OleDbDataAdapter daTravail = new OleDbDataAdapter("", cn);
        public static OleDbDataAdapter daClientTravailPaiement = new OleDbDataAdapter("", cn);
        public static OleDbDataAdapter daLangue = new OleDbDataAdapter("", cn);
        public static int searchFoundedPosition;
        public static ResourceManager resManager = new ResourceManager("GestionClient.Languages.Res", typeof(main).Assembly);
        public static CultureInfo cul = CultureInfo.CreateSpecificCulture("fr"); // langue française par défaut
        public static MessageBoxOptions msgBoxOptions = new MessageBoxOptions();

        // méthodes
        // getClient() : récupère la table Client
        public static void getClient()
        {
            daClient.SelectCommand.CommandText = "SELECT * FROM Client ORDER BY nom";
            if (ds.Tables.Contains("Client")) // si une ancienne dataTable existe on l'efface
                ds.Tables["Client"].Clear();
            daClient.Fill(ds, "Client");
        }

        // getPieces() : récupère la table Pieces
        public static void getPieces()
        {
            daPieces.SelectCommand.CommandText = "SELECT * FROM Pieces";
            if (ds.Tables.Contains("Pieces")) // si une ancienne dataTable existe on l'efface
                ds.Tables["Pieces"].Clear();
            daPieces.Fill(ds, "Pieces");
        }

        // getPaiement() : récupère la table Paiement
        public static void getPaiement()
        {
            daPaiement.SelectCommand.CommandText = "SELECT * FROM Paiement";
            if (ds.Tables.Contains("Paiement")) // si une ancienne dataTable existe on l'efface
                ds.Tables["Paiement"].Clear();
            daPaiement.Fill(ds, "Paiement");
        }

        // getTravail() : récupère la table Travail
        public static void getTravail()
        {
            daTravail.SelectCommand.CommandText = "SELECT * FROM Travail";
            if (ds.Tables.Contains("Travail")) // si une ancienne dataTable existe on l'efface
                ds.Tables["Travail"].Clear();
            daTravail.Fill(ds, "Travail");
        }

        // getAllTables() : récupère toutes les tables
        public static void getAllTables(ToolStripStatusLabel InfosToolStripStatusLabel)
        {
            try
            {
                // on récupère toutes les tables
                getClient();
                getPieces();
                getPaiement();
                getTravail();

                // on affiche un message de succès
                InfosToolStripStatusLabel.Text = API.resManager.GetString("Connexion_To_DB_Success", API.cul); //"Connexion à la base de données établie.";
                InfosToolStripStatusLabel.ForeColor = Color.Green;
                InfosToolStripStatusLabel.Image = GestionClient.Properties.Resources._true;

                isConnectedToDb = true;
            }
            catch (Exception ex)
            {
                // en cas d'erreur, on affiche le message d'erreur
                InfosToolStripStatusLabel.Text = API.resManager.GetString("Connexion_To_DB_Error", API.cul); //"Erreur de connexion à la base de données !"; // "Erreur : " + ex.Message;
                InfosToolStripStatusLabel.ToolTipText = ex.Message;
                InfosToolStripStatusLabel.ForeColor = Color.Red;
                InfosToolStripStatusLabel.Image = GestionClient.Properties.Resources._false;

                isConnectedToDb = false;
            }
        }

        // getClientTravailPaiement() : join les tables 'Client', 'Travail' et 'Paiement' dans une seul dataTable
        public static void getClientTravailPaiement()
        {
            daClientTravailPaiement.SelectCommand.CommandText = "SELECT nom, sexe, description AS [travail], DateDiff('yyyy', date_naissance, Date()) AS [age], date_naissance AS [date de naissance], numero_telephone AS [numéro tél], email, SUM(montant) AS [montant payé], date_ajout AS [ajouté le] FROM ((Client " +
                                                                "INNER JOIN Travail ON Travail.id = Client.id_travail) " +
                                                                "LEFT OUTER JOIN Paiement ON Paiement.id_client = Client.id) " +
                                                                "GROUP BY nom, sexe, description, date_naissance, numero_telephone, email, date_ajout";
            if (ds.Tables.Contains("ClientTravailPaiement")) // si une ancienne dataTable existe on l'efface
                ds.Tables["ClientTravailPaiement"].Clear();
            daClientTravailPaiement.Fill(ds, "ClientTravailPaiement");
        }

        // appliquerChangement() : applique les changements/update(s) à la table spécifiée
        public static void appliquerChangement(OleDbDataAdapter da, string nomTable)
        {
            OleDbCommandBuilder cmb = new OleDbCommandBuilder(da);
            da.Update(ds.Tables[nomTable]);
        }

        // getDefaultLanguage() : retourne la langue courante/actuelle
        public static string getDefaultLanguage()
        {
            if (!ds.Tables.Contains("Langue")) // si on a pas encore récupéré la Table 'Langue'
            {
                daLangue.SelectCommand.CommandText = "SELECT * FROM Langue";
                daLangue.Fill(ds, "Langue");
            }

            return ds.Tables["Langue"].Rows[0]["abrv"].ToString();
        }

        // setDefaultLanguage() : enregistre la langue courante/actuelle dans la base de données
        public static void setDefaultLanguage(string langue)
        {
            ds.Tables["Langue"].Rows[0]["abrv"] = langue;
            appliquerChangement(daLangue, "Langue");
        }
    }
}
