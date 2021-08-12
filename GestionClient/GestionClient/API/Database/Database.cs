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
            Customers.Table.DefaultView.Sort = "FullName";
            Assets = new TableAccessor("Assets");
            Payments = new TableAccessor("Payments");
            Jobs = new TableAccessor("Jobs");
            CustomersJobsPayments = new TableAccessor(@"
                SELECT Name, Gender, Description AS [Job], 
                DateDiff('yyyy', BirthDate, Date()) AS [Age], 
                BirthDate AS [Birth Date], Phone AS [Phone Number], Email, 
                SUM(Amount) AS [Paid Amount], CreateDate AS [Added At] 
                FROM ((Customers INNER JOIN Jobs ON Jobs.id = Customers.JobID)
                LEFT OUTER JOIN Payments ON Payments.CustomerID = Customer.ID) 
                GROUP BY Name, Gender, Description, BirthDate, Phone, Email, CreateDate",
                "CustomersJobsPayments", query: true);
            Language = new TableAccessor("Language");
            ConnectedToDatabase = true;
        }
    }
}
