using BAL;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMPMSHR
{
    public partial class EmpBankInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod (EnableSession=true)]
        public static string LoadEmpBankInfo() 
        {
            EmpBankInfoBLL ObjdctionBal = new EmpBankInfoBLL();
            return ObjdctionBal.LoadEmpBankInfo();
        }
        [WebMethod(EnableSession = true)]
        public static string GetEmpBAnkInfoByID(string data)
        {
            EmpBankInfoBLL ObjdctionBal = new EmpBankInfoBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjdctionBal.GetEmpBAnkInfoByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetEmpBAnkInfoForPaging(string data)
        {
            EmpBankInfoBLL ObjdctionBal = new EmpBankInfoBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjdctionBal.GetEmpBAnkInfoForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string EmpBAnkInfoAdd(string data)
        {
            EmpBankInfoBLL ObjdctionBal = new EmpBankInfoBLL();
            EmpBInfo B = (EmpBInfo)JsonConvert.DeserializeObject<EmpBInfo>(data);
          
            return ObjdctionBal.EmpBAnkInfoAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditEmpBAnkInfo(string data)
        {
            EmpBankInfoBLL ObjdctionBal = new EmpBankInfoBLL();
            EmpBInfo Objall = (EmpBInfo)JsonConvert.DeserializeObject<EmpBInfo>(data);
            return ObjdctionBal.EditEmpBAnkInfo(Objall);
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteEmpBAnkInfo(string data)
        {
            EmpBankInfoBLL ObjdctionBal = new EmpBankInfoBLL();
            EmpBInfo C = (EmpBInfo)JsonConvert.DeserializeObject<EmpBInfo>(data);
            return ObjdctionBal.DeleteEmpBAnkInfo(C);
        }
    }
}