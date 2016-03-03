using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Collections;
using System.Configuration;
using Newtonsoft.Json;


namespace DAL
{
    public class DALEmployee
    {
        DBFactory dbFact = null;
        DataProviderType dbType;
        private static string connString = "";

        public SystemResponce ADD(Employee ObjEmp)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();

            ht.Add("@DeptID", ObjEmp.DeptID);
            ht.Add("@DesignationID", ObjEmp.DesignationID);
            ht.Add("@ShiftID", ObjEmp.ShiftID);
            ht.Add("@CategoryID", ObjEmp.CategoryID);
            ht.Add("@FirstName", ObjEmp.FirstName);
            ht.Add("@LastName", ObjEmp.LastName);
            ht.Add("@Code", ObjEmp.Code);
            ht.Add("@FatherName", ObjEmp.FatherName);
            ht.Add("@Gender", ObjEmp.Gender);
            ht.Add("@Picture", ObjEmp.Picture);
            ht.Add("@CNIC", ObjEmp.CNIC);
            ht.Add("@TAXHST", ObjEmp.TaxHst);
            ht.Add("@PolicyID", ObjEmp.PolicyID);
            ht.Add("@Salary", ObjEmp.Salary);

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                int res = (int)dbCon.ExecuteScalarParameterized("SpEmployeeAddNew", CommandType.StoredProcedure, ht);
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

        public SystemResponce Edit(Employee ObjEmp)
        {
            SystemResponce result = new SystemResponce();
            Hashtable ht = new Hashtable();
            ht.Add("@ID", ObjEmp.ID);
            ht.Add("@DeptID", ObjEmp.DeptID);
            ht.Add("@DesignationID", ObjEmp.DesignationID);
            ht.Add("@ShiftID", ObjEmp.ShiftID);
            ht.Add("@CategoryID", ObjEmp.CategoryID);
            ht.Add("@FirstName", ObjEmp.FirstName);
            ht.Add("@LastName", ObjEmp.LastName);
            ht.Add("@Code", ObjEmp.Code);
            ht.Add("@FatherName", ObjEmp.FatherName);
            ht.Add("@Gender", ObjEmp.Gender);
            ht.Add("@Picture", ObjEmp.Picture);
            ht.Add("@CNIC", ObjEmp.CNIC);
            ht.Add("@TAXHST", ObjEmp.TaxHst);
            ht.Add("@PolicyID", ObjEmp.PolicyID);
            ht.Add("@Salary", ObjEmp.Salary);

            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                int res = (int)dbCon.ExecuteScalarParameterized("SpEmployeeEdit", CommandType.StoredProcedure, ht);
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

        public string GetAllEmployeePaging(Paging Page)
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
                DataSet ds = dbCon.ExecuteFetchCommandParameterized("SpEmployeeGetAllPaging", CommandType.StoredProcedure, ht);
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
                result = Converter(ds.Tables[0]) + "@@" + Converter(ds.Tables[1]);

            }
            else
            {
                result = String.Format("<Response><Code>{0}</Code><Message>{1}</Message></Response>", Constants.FAILURE, Constants.MessageDBConnectivityFailure);
                //throw new ArgumentException(dbCon.GetLastError);
            }

            return result;
        }

        public string GetEmployeeByID(Paging Page)
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
                DataSet ds = dbCon.ExecuteFetchCommandParameterized("SpEmployeeByID", CommandType.StoredProcedure, ht);
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

        public string Converter(DataTable table)
        {

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
    }
}
