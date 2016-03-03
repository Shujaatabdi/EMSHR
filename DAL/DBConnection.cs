using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Threading;
using System.Data.Common;

namespace DAL
{
    public abstract class DBConnection
    {
        private string connectionString;
        private IDbConnection connection;
        private IDbCommand command;
        private IDbTransaction transaction;
        private IDataReader reader;
        private IDataAdapter adapter;
        private string lastError;
        private int connectionNum = -1;

        public int ConnectionNumber
        {
            get { return connectionNum; }
            set { connectionNum = value; }
        }
        public string ConnectionString
        {
            get
            {
                if (connectionString == string.Empty || connectionString.Length == 0)
                    throw new ArgumentException("Invalid database connection string.");

                return connectionString;
            }
            set
            { connectionString = value; }
        }
        public string GetLastError
        {
            get
            {
                if (String.IsNullOrEmpty( lastError) || lastError.Length == 0)
                    return "";
                else
                    return lastError;
            }
            set { lastError = value; }
        }
        public ConnectionState ConnectionState
        {
            get { return connection.State  ; }
        }
        protected DBConnection() { }
        public abstract IDbConnection GetDataProviderConnection();
        public abstract IDbCommand GetDataProviderCommand();
        public abstract IDbDataAdapter GetDataProviderDataAdapter();
        public abstract IDbDataAdapter GetDataProviderDataAdapter(IDbCommand cmdObject);
        public abstract IDbDataAdapter GetDataProviderDataAdapter(string commandText, IDbConnection connObject);

        #region Database Transaction

        public bool OpenConnection()
        {
            bool returnValue = false;
            try
            {
                connection = GetDataProviderConnection(); // instantiate a connection object
                connection.ConnectionString = this.connectionString;
                connection.Open(); // open connection
                returnValue = true;
                //lastError = ((System.Reflection.MemberInfo)(connection.GetType())).Name + " Opened Successfully";
            }
            catch (Exception ex)
            {
                connection.Close();
                lastError = "Unable to Open ("+ex.Message + ")" + ((System.Reflection.MemberInfo)(connection.GetType())).Name;
            }
            return returnValue;
        }     
        public bool OpenConnection(string connectionString)
        {
            bool returnValue = false;
            try
            {
                connection = GetDataProviderConnection(); // instantiate a connection object
                connection.ConnectionString = connectionString;
                connection.Open(); // open connection
                returnValue = true;
                //lastError = ((System.Reflection.MemberInfo)(connection.GetType())).Name + " Opened Successfully";
            }
            catch (Exception ex)
            {
                connection.Close();
                lastError = "Unable to Open (" + ex.Message + ")" + ((System.Reflection.MemberInfo)(connection.GetType())).Name;
            }
            return returnValue;
        }     
        public bool CloseConnection()
        {
            bool returnValue = false;
            try
            {
                connection.Close();
                returnValue = true;
                //lastError = ((System.Reflection.MemberInfo)(connection.GetType())).Name + " Closed Successfully";
            }
            catch
            {
                connection.Close();
                lastError = "Unable to Close " + ((System.Reflection.MemberInfo)(connection.GetType())).Name;
            }
            return returnValue;
        }
        public int ExecuteNonQuery(string commandText, CommandType type)
        {
            int returnValue = 0;

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;
                        returnValue = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }
            return returnValue;
        }
        public int ExecuteNonQueryParameterized(string commandText, CommandType type, object[] paramName, object[] paramValues)
        {
            int returnValue = 0;
            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        int paramCount = paramName.Length;
                        for (int i = 0; i < paramCount; i++)
                        {
                            var p = command.CreateParameter();
                            p.ParameterName = (string)paramName[i];
                            p.Value = paramValues[i] ?? DBNull.Value;
                            command.Parameters.Add(p);
                        }

                        returnValue = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return returnValue;
        }
        public int ExecuteNonQueryParameterized(string commandText, CommandType type, Hashtable param)
        {
            int returnValue = 0;
            lastError = "";

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        foreach (var item in param.Keys)
                        {
                            var p = command.CreateParameter();
                            p.Direction = ParameterDirection.Input;
                            p.ParameterName = item.ToString();
                            p.Value = param[item] ?? DBNull.Value;
                            command.Parameters.Add(p);
                        }

                        returnValue = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return returnValue;
        }
        public Object ExecuteScalar(string commandText, CommandType type)
        {
            Object obj = null;

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;
                        obj = command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }
            return obj;
        }
        public Object ExecuteScalarParameterized(string commandText, CommandType type, Hashtable param)
        {
            Object obj = null;

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;
                        foreach (var item in param.Keys)
                        {
                            var p = command.CreateParameter();
                            p.Direction = ParameterDirection.Input;
                            p.ParameterName = item.ToString();
                            p.Value = param[item].ToString();
                            command.Parameters.Add(p);
                        }

                        obj = command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return obj;
        }
        public Object ExecuteScalarParameterized(string commandText, CommandType type, object[] paramName, object[] paramValues)
        {
            Object obj = null;

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        int paramCount = paramName.Length;
                        for (int i = 0; i < paramCount; i++)
                        {
                            var p = command.CreateParameter();
                            p.ParameterName = (string)paramName[i];
                            p.Value = paramValues[i] ?? DBNull.Value;
                            command.Parameters.Add(p);
                        }

                        obj = command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return obj;
        }
        public IDataReader ExecuteReader(string commandText, CommandType type)
        {
            IDataReader result = null;
             try
             {
                 using (connection)
                 {
                     using (command = GetDataProviderCommand())
                     {
                         command.Connection = connection;
                         command.CommandType = type;
                         command.CommandText = commandText;
                         result = command.ExecuteReader();
                         result.Read();
                     }
                 }
             }
             catch (Exception ex)
             {
                 lastError = ex.Message;
             }
            return result;
        }
        public IDataReader ExecuteReaderParameterized(string commandText, CommandType type, object[] paramName, object[] paramValues)
        {
            IDataReader result = null;
            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        int paramCount = paramName.Length;
                        for (int i = 0; i < paramCount; i++)
                        {
                            var p = command.CreateParameter();
                            p.ParameterName = (string)paramName[i];
                            p.Value = paramValues[i] ?? DBNull.Value;
                            command.Parameters.Add(p);
                        }

                        result = command.ExecuteReader();
                        result.Read();
                    }
                }
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }
            return result;
        }
        public DataSet ExecuteFetchCommand(string commandText, CommandType commandType)
        {
            DataSet result = new DataSet();

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = commandType;
                        command.CommandText = commandText;
                        adapter = GetDataProviderDataAdapter(command);
                        adapter.Fill(result);
                    }
                }                 
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return result;
        }
        public DataSet ExecuteFetchCommandParameterized(string commandText, CommandType type, object[] paramName, object[] paramValues)
        {
            DataSet result = new DataSet();

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        int paramCount = paramName.Length;
                        for (int i = 0; i < paramCount; i++)
                        {
                            var p = command.CreateParameter();
                            p.ParameterName = (string)paramName[i];
                            p.Value = paramValues[i] ?? DBNull.Value;
                            command.Parameters.Add(p);
                        }

                        adapter = GetDataProviderDataAdapter(command);
                        adapter.Fill(result);
                    }
                }                
                adapter = null;
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return result;
        }
        public DataSet ExecuteFetchCommandParameterized(string commandText, CommandType type, Hashtable param)
        {
            DataSet result = new DataSet();

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        foreach (var item in param.Keys)
                        {
                            var p = command.CreateParameter();
                            p.Direction = ParameterDirection.Input;
                            p.ParameterName = item.ToString();
                            p.Value = param[item].ToString();
                            command.Parameters.Add(p);
                        }

                        adapter = GetDataProviderDataAdapter(command);
                        adapter.Fill(result);
                    }
                }
                adapter = null;
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return result;
        }
        public DataSet ExecuteFetchCommandParameterized(string commandText, CommandType type, Hashtable inputParams, Hashtable outputParams)
        {
            DataSet result = new DataSet();

            try
            {
                using (connection)
                {
                    using (command = GetDataProviderCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = type;
                        command.CommandText = commandText;

                        //input parameters
                        foreach (var item in inputParams.Keys)
                        {
                            var p = command.CreateParameter();
                            p.Direction = ParameterDirection.Input;
                            p.ParameterName = item.ToString();
                            p.Value = inputParams[item].ToString();
                            command.Parameters.Add(p);
                        }

                        // output parameters
                        foreach (var item in outputParams.Keys)
                        {
                            var p = command.CreateParameter();
                            p.Direction = ParameterDirection.Output;
                            p.ParameterName = item.ToString();
                            p.Value = outputParams[item].ToString();
                            command.Parameters.Add(p);
                        }

                        adapter = GetDataProviderDataAdapter(command);
                        adapter.Fill(result);
                    }
                }
                adapter = null;
            }
            catch (Exception ex)
            {
                lastError = ex.Message;
            }

            return result;
        }

    
        public class DataResponce
        {
            public DataSet DataSet { get; set; }
            public SqlParameterCollection SqlParameterCollection { get; set; }


        }
        #endregion
    }

    public class OleDbDataBase : DBConnection
    {
        // Provide class constructors
        public OleDbDataBase() { }
        public OleDbDataBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        // DBBaseClass Members
        public override IDbConnection GetDataProviderConnection()
        {
            return new OleDbConnection();
        }
        public override IDbCommand GetDataProviderCommand()
        {
            return new OleDbCommand();
        }
        public override IDbDataAdapter GetDataProviderDataAdapter()
        {
            return new OleDbDataAdapter();
        }
        public override IDbDataAdapter GetDataProviderDataAdapter(IDbCommand cmdObject)
        {
            return new OleDbDataAdapter((OleDbCommand)cmdObject);
        }
        public override IDbDataAdapter GetDataProviderDataAdapter(string commandText, IDbConnection connObject)
        {
            return new OleDbDataAdapter(commandText, (OleDbConnection)connObject);
        }
    }

    public class SqlDataBase : DBConnection
    {
        // Provide class constructors
        public SqlDataBase() { }
        public SqlDataBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        // DBBaseClass Members
        public override IDbConnection GetDataProviderConnection()
        {
            return new SqlConnection();
        }
        public override IDbCommand GetDataProviderCommand()
        {
            return new SqlCommand();
        }
        public override IDbDataAdapter GetDataProviderDataAdapter()
        {
            return new SqlDataAdapter();
        }
        public override IDbDataAdapter GetDataProviderDataAdapter(IDbCommand cmdObject)
        {
            return new SqlDataAdapter((SqlCommand)cmdObject);
        }
        public override IDbDataAdapter GetDataProviderDataAdapter(string commandText, IDbConnection connObject)
        {
            return new SqlDataAdapter(commandText, (SqlConnection)connObject);
        }
    }

    public class OracleDataBase : DBConnection
    {
        // Provide class constructors
        public OracleDataBase() { }
        public OracleDataBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        // DALBaseClass Members
        public override IDbConnection GetDataProviderConnection()
        {
            return new OracleConnection();
        }
        public override IDbCommand GetDataProviderCommand()
        {
            return new OracleCommand();
        }
        public override IDbDataAdapter GetDataProviderDataAdapter()
        {
            return new OracleDataAdapter();
        }

        public override IDbDataAdapter GetDataProviderDataAdapter(IDbCommand cmdObject)
        {
            return new OracleDataAdapter((OracleCommand)cmdObject);
        }
        public override IDbDataAdapter GetDataProviderDataAdapter(string commandText, IDbConnection connObject)
        {
            return new OracleDataAdapter(commandText, (OracleConnection)connObject);
        }

    }
}
