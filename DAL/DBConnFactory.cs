using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public enum DataProviderType
    {       
        Oracle,
        SqlServer,
        OleDb
    }

    public abstract class DBFactoryBaseClass
    {
        public abstract DBConnection GetDataAccessLayer();
        public abstract DBConnection GetDataAccessLayer(DataProviderType dataProviderType);

    }

    public class DBFactory : DBFactoryBaseClass
    {
        private string connectionString = "";
        private DataProviderType dbType;

        public string ConnectionString
        {
            get { return connectionString; }
        }
        public DataProviderType DatabaseType
        {
            get { return dbType; }
        }
        public DBFactory(DataProviderType dataProviderType, string connString)
        {
            dbType = dataProviderType;
            connectionString = connString;
        }
        public override DBConnection GetDataAccessLayer(DataProviderType dataProviderType)
        {
            switch (dataProviderType)
            {   
                case DataProviderType.Oracle:
                    return new OracleDataBase();
                case DataProviderType.SqlServer:
                    return new SqlDataBase();
                case DataProviderType.OleDb:
                    return new OleDbDataBase();
                default:
                    throw new ArgumentException("Invalid DAL provider type.");
            }
        }
        public override DBConnection GetDataAccessLayer()
        {
            switch (dbType)
            {
                case DataProviderType.Oracle:
                    return new OracleDataBase();
                case DataProviderType.SqlServer:
                    return new SqlDataBase();
                case DataProviderType.OleDb:
                    return new OleDbDataBase();
                default:
                    throw new ArgumentException("Invalid DAL provider type.");
            }
        }
    }
}
