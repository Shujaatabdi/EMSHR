using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using System.Data;
using Newtonsoft.Json;
using Entity;

namespace DAL
{
    public class ShiftDAL
    {
        DBFactory dbFact = null;
        DataProviderType dbType;
        private static string connString = "";

        public SystemResponce ShiftAdd(Shift objShift)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();
            
            ht.Add("@Name", objShift.ShiftName);
            ht.Add("@Code", objShift.ShiftCode);
            ht.Add("@TimeIn", objShift.TimeIn);
            ht.Add("@TimeOut", objShift.TimeOut);

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                int res = Convert.ToInt32(dbCon.ExecuteScalarParameterized("SpShiftAdd", CommandType.StoredProcedure, ht));
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

        //public SystemResponce EditCompany(Shift Objshift)
        //{
        //    SystemResponce result = new SystemResponce();
        //    Hashtable ht = new Hashtable();

        //    ht.Add("@Name", Objshift.ShiftName);
        //    ht.Add("@Code", Objshift.ShiftCode);
        //    ht.Add("@TimeIn", Objshift.TimeIn);
        //    ht.Add("@TimeOut", Objshift.TimeOut);

        //    dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
        //    connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        //    dbFact = new DBFactory(dbType, connString);

        //    DBConnection dbCon = dbFact.GetDataAccessLayer();
        //    if (dbCon.OpenConnection(dbFact.ConnectionString))
        //    {
        //        int res = (int)dbCon.ExecuteScalarParameterized("SpShiftEdit", CommandType.StoredProcedure, ht);
        //        if (res == -1)
        //        {
        //            result.ErrorCode = Constants.AlreadExists;
        //            result.Msg = Constants.MessageAlreadExists;
        //        }
        //        else
        //        {
        //            result.ErrorCode = Constants.SUCCESS;
        //            result.Msg = Constants.MessageSuccessUpate;
        //        }
        //    }
        //    else
        //    {
        //        result.ErrorCode = Constants.FAILURE;
        //        result.Msg = Constants.MessageDBConnectivityFailure;
        //    }

        //    return result;
        //}

        public SystemResponce Delete(Shift objshft)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();

            ht.Add("@shiftID", objshft.ID);


            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                int res = (int)dbCon.ExecuteScalarParameterized("SpShiftDelete", CommandType.StoredProcedure, ht);
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

        public SystemResponce EditShift(Shift Objshift)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();
            ht.Add("@ID", Objshift.ID);
            ht.Add("@Name", Objshift.ShiftName);
            ht.Add("@Code", Objshift.ShiftCode);
            ht.Add("@TimeIn", Objshift.TimeIn);
            //ht.Add("@TimeOut", Objshift.TimeOut);
            ht.Add("@TimeOut", Objshift.TimeOut);//@Holiday
            ht.Add("@Holiday", Objshift.Holiday);
            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                //(int)dbCon.ExecuteScalarParameterized("SpShiftEdit", CommandType.StoredProcedure, ht);
                int res = (int)dbCon.ExecuteScalarParameterized("SpShiftEdit", CommandType.StoredProcedure, ht);
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

        public string GetShftByID(Paging page)
        {
         
            string result = "";
            Hashtable ht = new Hashtable();
            ht.Add("@PageNumber",page.PageNo);
            ht.Add("@RecordPP", page.RecordPerPage);
            ht.Add("@SortBy", page.SortBy);
            ht.Add("@SortAs", page.SortAs);
            ht.Add("@SearchBy", page.SearchBy);
            ht.Add("@SearchVal", page.SearchVal);
            if (page.Extra != null)
            {
                //foreach (var item in Page.Extra.Keys)
                //{
                //    ht.Add(item.ToString(), Page.Extra[item].ToString());
                //}
                for (int i = 0; i < page.Extra.Length; i++)
                {
                    ht.Add(page.Extra[i].Pname, page.Extra[i].Pval);
                }
            }

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                DataSet ds = dbCon.ExecuteFetchCommandParameterized("SpShiftGetAllPaging", CommandType.StoredProcedure, ht);
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
               // result = Converter(ds.Tables[0]);
                result =  Converter(ds.Tables[0]) + "@@" + Converter(ds.Tables[1]);

            }
            else
            {
                result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, Constants.MessageDBConnectivityFailure);
                //throw new ArgumentException(dbCon.GetLastError);
            }

            return result;
        }

        public string GetShiftForEdit(Paging Page)
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
                DataSet ds = dbCon.ExecuteFetchCommandParameterized("SpShiftByID", CommandType.StoredProcedure, ht);
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
                result = Converter(ds.Tables[0]) + "@@" + Converter(ds.Tables[1]);
                //result = Converter(ds.Tables[1]);
                //result += Converter(ds.Tables[1]); 
                    

            }
            else
            {
                result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, Constants.MessageDBConnectivityFailure);
                //throw new ArgumentException(dbCon.GetLastError);
            }

            return result;
        }

        private string Converter(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        public string GetAllShifts()
        {
            string result = "";
            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                DataSet ds = dbCon.ExecuteFetchCommand("SpShiftGetAll", CommandType.StoredProcedure);
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

        public SystemResponce getHolidays(Shift Objshift)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();
            ht.Add("@ID", Objshift.ID);
           // ht.Add("@Name", Objshift.ShiftName);
           // ht.Add("@Code", Objshift.ShiftCode);
            //ht.Add("@TimeIn", Objshift.TimeIn);
            //ht.Add("@TimeOut", Objshift.TimeOut);
           // ht.Add("@TimeOut", Objshift.TimeOut);//@Holiday
            //ht.Add("@Holiday", Objshift.Holiday);
            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                //(int)dbCon.ExecuteScalarParameterized("SpShiftEdit", CommandType.StoredProcedure, ht);
                int res = (int)dbCon.ExecuteScalarParameterized("getHolidaysbyID", CommandType.StoredProcedure, ht);
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

