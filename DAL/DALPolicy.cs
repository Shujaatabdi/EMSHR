using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class DALPolicy
    {
        DBFactory dbFact = null;
        DataProviderType dbType;
        private static string connString = "";
        public string GetAllPolicy()
        {
            string result = "";
            dbType = (DataProviderType)Enum.Parse(typeof(DataProviderType), ConfigurationManager.AppSettings["DatabaseType"].ToString());
            connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            dbFact = new DBFactory(dbType, connString);

            DBConnection dbCon = dbFact.GetDataAccessLayer();
            if (dbCon.OpenConnection(dbFact.ConnectionString))
            {
                DataSet ds = dbCon.ExecuteFetchCommand("SpCompanyGetAll", CommandType.StoredProcedure);
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
