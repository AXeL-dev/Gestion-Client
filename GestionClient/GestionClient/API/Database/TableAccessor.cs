using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using GestionClient.Properties;

namespace GestionClient
{
    /// <summary>
    /// Allows access to a table in database.
    /// </summary>
    class TableAccessor
    {
        private static readonly OleDbConnection s_connection;
        private OleDbDataAdapter _adapter;

        public DataTable Table { get; set; }

        static TableAccessor()
        {
            s_connection = new OleDbConnection(Settings.Default.ConnectionString);
        }

        /// <summary>
        /// Creates a new instance of TableAccessor.
        /// </summary>
        /// <param name="tableNameOrQuery">
        /// Name of the table to retrieve from database or a custom select SQL query.
        /// If the argument is a query, the argument for the query parameter must be true.
        /// </param>
        /// <param name="dataTableName">Name for the underlying DataTable object.</param>
        /// <param name="query">
        /// If true, the tableNameOrQuery parameter will be interpreted as a query not a table name.
        /// Default: false
        /// </param>
        /// <param name="fetch">
        /// If true, call the FetchTable method after instantiation logic.
        /// </param>
        public TableAccessor(string tableNameOrQuery, string dataTableName = null,
            bool query = false, bool fetch = true)
        {
            OleDbCommand command = new OleDbCommand(tableNameOrQuery, s_connection);
            command.CommandType = query ? CommandType.Text : CommandType.TableDirect;
            _adapter = new OleDbDataAdapter(command);
            new OleDbCommandBuilder(_adapter).Dispose();
            if (!query && string.IsNullOrEmpty(dataTableName))
            {
                dataTableName = tableNameOrQuery;
            }
            Table = new DataTable(dataTableName);
            if (fetch)
            {
                FetchTable();
            }
        }

        /// <summary>
        /// Fill the underlying DataTable from database.
        /// </summary>
        public void FetchTable()
        {
            Table.Clear();
            _adapter.Fill(Table);
        }

        /// <summary>
        /// Apply changes in the underlying DataTable to database.
        /// </summary>
        public void ApplyChanges()
        {
            _adapter.Update(Table);
        }
    }
}
