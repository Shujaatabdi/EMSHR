using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public static class GeneralDb
    {
        //string Constr = "Data source=172.16.100.6; Initial Catalog=MBESS; User ID=mbe; Password=Pa$$w0rd786110";
        //private string Constr = ConfigurationManager.ConnectionStrings["Mbessconstr"].ConnectionString;
        //string Constr = @"Data source=66.11.73.212\sqlexpress; Initial Catalog=MBESS; User ID=sa; Password=sa";
        private static string _Constr = "Data source=MBE-PC; Initial Catalog=ATM_base; User ID=sa; Password=sa123";
        private static SqlCommand Cmd;

        //private static string _Constr;

        private static SqlConnection con;

        public static SqlConnection GetCon()
        {
            try
            {
                SqlConnection con = new SqlConnection(_Constr);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static void AddDefaultParam(SqlCommand cmd)
        {
            SqlParameter param1 = new SqlParameter();
            param1.Direction = ParameterDirection.InputOutput;
            param1.ParameterName = "@strMsgCode";
            param1.Value = "";
            param1.DbType = DbType.String;
            param1.Size = 100;
            cmd.Parameters.Add(param1);
            param1 = new SqlParameter();
            param1.Direction = ParameterDirection.InputOutput;
            param1.ParameterName = "@intProcStatus";
            param1.DbType = DbType.Int32;
            param1.Value = 0;
            cmd.Parameters.Add(param1);
        }

        public static bool ExecuteSP(string spName, Hashtable parameters, ref string msgCode)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (object obj in parameters.Keys)
            {
                cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj].ToString());
            }

            GeneralDb.AddDefaultParam(cmd);
            cmd.CommandText = spName;
            GeneralDb.con.Open();
            cmd.ExecuteNonQuery();
            GeneralDb.con.Close();
            int intStatus = Convert.ToInt32(cmd.Parameters["@intProcStatus"].Value);
            if (intStatus == 0)
            {
                return false;
            }
            return true;
        }
        public static int DoLogin(string spName, Hashtable parameters)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (object obj in parameters.Keys)
            {
                cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj].ToString());
            }
            SqlParameter param1 = new SqlParameter();
            param1 = new SqlParameter();
            param1.Direction = ParameterDirection.InputOutput;
            param1.ParameterName = "@intProcStatus";
            param1.DbType = DbType.Int32;
            param1.Value = 0;
            cmd.Parameters.Add(param1);

            cmd.CommandText = spName;
            GeneralDb.con.Open();
            cmd.ExecuteNonQuery();
            GeneralDb.con.Close();
            int intStatus = Convert.ToInt32(cmd.Parameters["@intProcStatus"].Value);

            return intStatus;
        }

        public static void ExecuteSP(string spName, Hashtable parameters, ref string msgCode, ref int intStatus)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (object obj in parameters.Keys)
            {
                cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj].ToString());
            }

            GeneralDb.AddDefaultParam(cmd);
            cmd.CommandText = spName;
            GeneralDb.con.Open();
            cmd.ExecuteNonQuery();
            GeneralDb.con.Close();
            intStatus = Convert.ToInt32(cmd.Parameters["@intProcStatus"].Value);
            msgCode = cmd.Parameters["@strMsgCode"].Value.ToString();

        }

        public static DataSet GetDataSet(string spName, Hashtable parameters, ref string msgCode, ref int intStatus)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (object obj in parameters.Keys)
            {
                //if (obj.ToString().Length > 3 && obj.ToString().Substring(0, 3) == "img")
                //{
                //    cmd.Parameters.AddWithValue(
                //}
                cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj]);
            }
            GeneralDb.AddDefaultParam(cmd);
            cmd.CommandText = spName;
            DataSet ds = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds);
            intStatus = Convert.ToInt32(cmd.Parameters["@intProcStatus"].Value);
            msgCode = Convert.ToString(cmd.Parameters["@strMsgCode"].Value);
            return ds;
        }
        public static DataSet GetDataSet(string spName, Hashtable parameters)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (object obj in parameters.Keys)
            {
                //if (obj.ToString().Length > 3 && obj.ToString().Substring(0, 3) == "img")
                //{
                //    cmd.Parameters.AddWithValue(
                //}
                cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj]);
            }
            // GeneralDB.AddDefaultParam(cmd);
            cmd.CommandText = spName;
            DataSet ds = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(ds);
            //intStatus = Convert.ToInt32(cmd.Parameters["@intProcStatus"].Value);
            //msgCode = Convert.ToString(cmd.Parameters["@strMsgCode"].Value);
            return ds;
        }
        public static SqlConnection GetSqlreader(string spName)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;
            SqlDataReader rdr = cmd.ExecuteReader();
            return con;

            //foreach (object obj in parameters.Keys)
            //{
            //    //if (obj.ToString().Length > 3 && obj.ToString().Substring(0, 3) == "img")
            //    //{
            //    //    cmd.Parameters.AddWithValue(
            //    //}
            //    cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj]);
            //}
            // GeneralDB.AddDefaultParam(cmd);
        }
        public static SqlDataReader GetSqlreader(string spName,Hashtable parameters)
        {
            GeneralDb.con = new SqlConnection(GeneralDb._Constr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GeneralDb.con;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (object obj in parameters.Keys)
            {
                //if (obj.ToString().Length > 3 && obj.ToString().Substring(0, 3) == "img")
                //{
                //    cmd.Parameters.AddWithValue(
                //}
                cmd.Parameters.AddWithValue(obj.ToString(), parameters[obj]);
            }
            // GeneralDB.AddDefaultParam(cmd);
            cmd.CommandText = spName;
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        public static string ExecuteQry(string Qry)
        {
            SqlConnection con = GetCon();
            Cmd = new SqlCommand(Qry + "; SELECT SCOPE_IDENTITY();", con);

            string result = Cmd.ExecuteScalar().ToString();
            con.Close();
            con.Dispose();
            return result;

        }

        public static DataTable GetTblAgainst_Qry(string Qry)
        {
            SqlConnection con = GetCon();
            Cmd = new SqlCommand(Qry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(dt);
            con.Close();
            con.Dispose();
            return dt;
        }

        public static DataSet GetDataSetAgainst_Qry(string Qry)
        {
            SqlConnection con = GetCon();
            Cmd = new SqlCommand(Qry, con);
            DataSet ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(ds);
            con.Close();
            con.Dispose();
            return ds;
        }

        //public void FillCbo(string Qry, HtmlSelect Cbo)
        //{
        //    DataTable dt = GetTblAgainst_Qry(Qry);
        //    Cbo.DataSource = dt;
        //    Cbo.DataTextField = dt.Columns[1].ColumnName;
        //    Cbo.DataValueField = dt.Columns[0].ColumnName;
        //    Cbo.DataBind();
        //}
    }
}
