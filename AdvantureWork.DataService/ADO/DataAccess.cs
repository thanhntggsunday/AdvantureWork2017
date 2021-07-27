using AdvantureWork.Common.Constant;
using AdvantureWork.Common.Helper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdvantureWork.DataService.ADO
{
    public class DataAccess : BaseClass
    {
        private string _connectionString;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private List<SqlCommand> _sQlCmds = new List<SqlCommand>();

        /// <summary>
        /// Constructor
        /// </summary>
        public DataAccess()
        {
            _connectionString = SystemConstants.ConnectionString;
            _connection = new SqlConnection();
            _connection.ConnectionString = _connectionString;
            _connection.Open();
        }

        /// <summary>
        /// Execute Data Reader
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = _connection;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader;
        }

        /// <summary>
        /// Execute Non Query
        /// </summary>
        /// <param name="sqlCommand"></param>
        public void ExecuteNonQuery(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = _connection;
            if (_transaction != null)
                sqlCommand.Transaction = _transaction;

            sqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Execute Non Query
        /// </summary>
        /// <param name="sqlCommand"></param>
        public object ExecuteScalar(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = _connection;
            if (_transaction != null)
                sqlCommand.Transaction = _transaction;

            return sqlCommand.ExecuteScalar();
        }

        public DataTable LoadDataTable(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = _connection;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            var dt = new DataTable();

            dt.Load(sqlDataReader);
            sqlDataReader.Close();

            return dt;
        }

        public DataSet GetSchema(string table)
        {
            // Returns a DataSet with only schema information (Use with updateTable for adding new rows)
            SqlDataAdapter sqlAdapt;
            DataSet myDs = new DataSet();
            sqlAdapt = new SqlDataAdapter("select * from " + table + " where 1=0", _connection);
            sqlAdapt.FillSchema(myDs, SchemaType.Source, table);
            return myDs;
        }

        /// <summary>
        /// Begin Transaction
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Commit Transaction
        /// </summary>
        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        /// <summary>
        /// Rollback Transaction
        /// </summary>
        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public new void Dispose()
        {
            CloseConnection();
            base.Dispose();
        }

        private void CloseConnection()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _connection.Close();
            _connection.Dispose();
            foreach (SqlCommand item in _sQlCmds)
            {
                if (item != null)
                    item.Dispose();
            }

            _sQlCmds.Clear();
        }
    }
}