using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using BAL;

namespace EMPMSHR
{
    public partial class EmpLeaveApps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static string LoadLeaveApp()
        {
            LeaveAppBLL objLvApp = new LeaveAppBLL();
            return objLvApp.GetAllLvApp();
        }


        [WebMethod(EnableSession = true)]
        public static string DDLLvType()
        {
            LeaveAppBLL objLvApp = new LeaveAppBLL();
           return objLvApp.DDLLvType();
            
        }
        //LvAppAdd
        [WebMethod(EnableSession = true)]
        public static string LvAppAdd(string data)
        {
            LeaveAppBLL objLvApp = new LeaveAppBLL();
            LeaveApp S = (LeaveApp)JsonConvert.DeserializeObject<LeaveApp>(data);
            return objLvApp.LvAppAdd(S);

        }
        [WebMethod(EnableSession = true)]
        public static string GetLvAppByID(string data)
        {
            LeaveAppBLL objLvAppBal = new LeaveAppBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return objLvAppBal.GetLvAppByID(p);

        }
        [WebMethod(EnableSession = true)]
        public static string GetLvAppForEdit(string data)
        {
            LeaveAppBLL objLvAppBal = new LeaveAppBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return objLvAppBal.GetLvAppForEdit(p);

        }
        [WebMethod(EnableSession = true)]
        public static string Delete(string data)
        {
            LeaveAppBLL objLvAppBal = new LeaveAppBLL();
            LeaveApp C = (LeaveApp)JsonConvert.DeserializeObject<LeaveApp>(data);
            return objLvAppBal.Delete(C);
        }
        
    }
}