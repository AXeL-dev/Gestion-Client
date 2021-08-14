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
        //private readonly OleDbCommand _command;
        private readonly OleDbDataAdapter _adapter;
        //private readonly OleDbCommandBuilder _commandBuilder;

        public readonly DataTable Table;

        static TableAccessor()
        {
            s_connection = new OleDbConnection(Settings.Default.ConnectionString);
        }

        #region Private-Methods
        private OleDbCommand CreateSelectCommand(string tableNameOrSelectQuery, bool useTableName)
        {
            string commandText = useTableName
                ? string.Format("SELECT * FROM {0}", tableNameOrSelectQuery)
                : tableNameOrSelectQuery;
            return new OleDbCommand(commandText, s_connection);
        }

        private OleDbDataAdapter CreateDataAdapter(OleDbCommand selectCommand)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectCommand);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adapter);
            return adapter;
        }
        #endregion

        /// <summary>
        /// Creates a new instance of TableAccessor.
        /// </summary>
        /// <param name="tableNameOrSelectQuery">
        /// Name of the table to retrieve from database or a custom select SQL query.
        /// If the argument is a query, the argument for the query parameter must be true.
        /// </param>
        /// <param name="dataTableName">Name for the underlying DataTable object.</param>
        /// <param name="useTableName">
        /// If true, the tableNameOrQuery parameter will be interpreted as table name.
        /// Default: true
        /// </param>
        /// <param name="fetch">
        /// If true, call the FetchTable method after instantiation logic.
        /// </param>
        public TableAccessor(string tableNameOrSelectQuery, string dataTableName = null,
            bool useTableName = true, bool fetch = true)
        {
            _adapter = CreateDataAdapter(CreateSelectCommand(tableNameOrSelectQuery, useTableName));
            dataTableName = (string.IsNullOrEmpty(dataTableName) && useTableName)
                ? tableNameOrSelectQuery : dataTableName;
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
