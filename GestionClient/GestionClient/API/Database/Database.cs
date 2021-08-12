using System.Data;
using System.Data.OleDb;
using GestionClient.Properties;

namespace GestionClient
{
    static class Database
    {
        public static readonly TableAccessor Customers;
        public static readonly TableAccessor Assets;
        public static readonly TableAccessor Payments;
        public static readonly TableAccessor Jobs;
        public static readonly TableAccessor CustomersJobsPayments;
        public static readonly TableAccessor Language;
        public static bool ConnectedToDatabase { get; set; }

        static Database()
        {
            Customers = new TableAccessor("Customers");
            Customers.Table.DefaultView.Sort = "nom";
            Assets = new TableAccessor("Assets");
            Payments = new TableAccessor("Payment");
            Jobs = new TableAccessor("Jobs");
            CustomersJobsPayments = new TableAccessor(@"
                SELECT nom, sexe, description AS [travail], 
                DateDiff('yyyy', date_naissance, Date()) AS [age], 
                date_naissance AS [date de naissance], numero_telephone AS [numéro tél], email, 
                SUM(montant) AS [montant payé], date_ajout AS [ajouté le] 
                FROM ((Client INNER JOIN Travail ON Travail.id = Client.id_travail)
                LEFT OUTER JOIN Paiement ON Paiement.id_client = Client.id) 
                GROUP BY nom, sexe, description, date_naissance, numero_telephone, email, date_ajout",
                "CustomersJobsPayments", query: true);
            Language = new TableAccessor("Language");
            ConnectedToDatabase = true;
        }
    }
}
