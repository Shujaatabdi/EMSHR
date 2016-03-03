using Entity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AllowanceDAL
    {

        DBFactory dbFact = null;
        DataProviderType dbType;
        private static string connString = "";

        public string LoadAllowance()
        {
            string result = "";
            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                DataSet ds = dbCon.ExecuteFetchCommand("SpAllowanceGetAll", CommandType.StoredProcedure);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    // success
                //    result = "<xml>" + String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>{2}", Constants.SUCCESS, "", ds.GetXml()) + "</xml>";
                //}
                //else
                //{
                //    if (String.IsNullOrEmpty(dbCon.GetLastError))
                //        result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>{2}", Constants.EMPTY, Constants.MessageEmpty, ds.GetXml());
                //    else
                //        result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, dbCon.GetLastError);

                //}
                result = Converter(ds.Tables[0]);
            }
            else
            {
                result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, Constants.MessageDBConnectivityFailure);
                //throw new ArgumentException(dbCon.GetLastError);
            }

            return result;
        }
        public SystemResponce AllowanceAdd(Allowances objall)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();

            ht.Add("@Name", objall.Name);
            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                int res = Convert.ToInt32(dbCon.ExecuteScalarParameterized("[dbo].[SpAllowanceAddNew]", CommandType.StoredProcedure, ht));
                if (res == -1)
                {
                    result.ErrorCode = Constants.AlreadExists;
                    result.Msg = Constants.MessageAlreadExists;
                }
                else
                {
                    result.ErrorCode = Constants.SUCCESS;
                    result.Msg = Constants.MessageSuccessSave;
                }
            }
            else
            {
                result.ErrorCode = Constants.FAILURE;
                result.Msg = Constants.MessageDBConnectivityFailure;
            }

            return result;
        }

        public string GetAllowanceForPaging(Paging Page)
        {
            string result = "";
            Hashtable ht = new Hashtable();
            ht.Add("@PageNumber", Page.PageNo);
            ht.Add("@RecordPP", Page.RecordPerPage);
            ht.Add("@SortBy", Page.SortBy);
            ht.Add("@SortAs", Page.SortAs);
            ht.Add("@SearchBy", Page.SearchBy);
            ht.Add("@SearchVal", Page.SearchVal);
            if (Page.Extra != null)
            {
                //foreach (var item in Page.Extra.Keys)
                //{
                //    ht.Add(item.ToString(), Page.Extra[item].ToString());
                //}
                for (int i = 0; i < Page.Extra.Length; i++)
                {
                    ht.Add(Page.Extra[i].Pname, Page.Extra[i].Pval);
                }
            }

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                DataSet ds = dbCon.ExecuteFetchCommandParameterized("SpAllowanceGetAllPaging", CommandType.StoredProcedure, ht);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // success
                    result = "<xml>" + String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>{2}", Constants.SUCCESS, "", ds.GetXml()) + "</xml>";
                }
                else
                {
                    if (String.IsNullOrEmpty(dbCon.GetLastError))
                        result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>{2}", Constants.EMPTY, Constants.MessageEmpty, ds.GetXml());
                    else
                        result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, dbCon.GetLastError);

                }
                result = Converter(ds.Tables[0])+ "@@" + Converter(ds.Tables[1]);


            }
            else
            {
                result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, Constants.MessageDBConnectivityFailure);
                throw new ArgumentException(dbCon.GetLastError);
            }

            return result;
        }

        private string Converter(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        public SystemResponce DeleteAllowance(Allowances objall)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();

            ht.Add("@AllowanceID", objall.ID);


            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                int res = (int)dbCon.ExecuteScalarParameterized("SpAllowanceDelete", CommandType.StoredProcedure, ht);
                if (res == -1)
                {
                    result.ErrorCode = Constants.AlreadExists;
                    result.Msg = Constants.MessageAlreadExists;
                }
                else
                {
                    result.ErrorCode = Constants.SUCCESS;
                    result.Msg = Constants.MessageSuccessDelete;
                }
            }
            else
            {
                result.ErrorCode = Constants.FAILURE;
                result.Msg = Constants.MessageDBConnectivityFailure;
            }

            return result;
        }

     
        public string GetAllowanceByID(Paging Page)
        {
            string result = "";
            Hashtable ht = new Hashtable();
            //ht.Add("@PageNumber", Page.PageNo);
            //ht.Add("@RecordPP", Page.RecordPerPage);
            //ht.Add("@SortBy", Page.SortBy);
            //ht.Add("@SortAs", Page.SortAs);
            //ht.Add("@SearchBy", Page.SearchBy);
            //ht.Add("@SearchVal", Page.SearchVal);
            if (Page.Extra != null)
            {
                //foreach (var item in Page.Extra.Keys)
                //{
                //    ht.Add(item.ToString(), Page.Extra[item].ToString());
                //}
                for (int i = 0; i < Page.Extra.Length; i++)
                {
                    ht.Add(Page.Extra[i].Pname, Page.Extra[i].Pval);
                }
            }

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                DataSet ds = dbCon.ExecuteFetchCommandParameterized("SpAllowanceByID", CommandType.StoredProcedure, ht);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    // success
                //    result = "<xml>" + String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>{2}", Constants.SUCCESS, "", ds.GetXml()) + "</xml>";
                //}
                //else
                //{
                //    if (String.IsNullOrEmpty(dbCon.GetLastError))
                //        result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>{2}", Constants.EMPTY, Constants.MessageEmpty, ds.GetXml());
                //    else
                //        result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, dbCon.GetLastError);

                //}
                result = Converter(ds.Tables[0]);


            }
            else
            {
                result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, Constants.MessageDBConnectivityFailure);
                //throw new ArgumentException(dbCon.GetLastError);
            }

            return result;
        }




        public SystemResponce EditAllowance(Allowances objddct)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();
            ht.Add("@ID", objddct.ID);
            ht.Add("@Name", objddct.Name);

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                //(int)dbCon.ExecuteScalarParameterized("SpShiftEdit", CommandType.StoredProcedure, ht);
                int res = (int)dbCon.ExecuteScalarParameterized("SpAllowanceEdit", CommandType.StoredProcedure, ht);
                if (res == -1)
                {
                    result.ErrorCode = Constants.AlreadExists;
                    result.Msg = Constants.MessageAlreadExists;
                }
                else
                {
                    result.ErrorCode = Constants.SUCCESS;
                    result.Msg = Constants.MessageSuccessUpate;
                }
            }
            else
            {
                result.ErrorCode = Constants.FAILURE;
                result.Msg = Constants.MessageDBConnectivityFailure;
            }

            return result;
        }
    }
}
