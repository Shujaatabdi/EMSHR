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
    public partial class LeaveTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static string LoadLeaveType()
        {
            LeaveTypeBLL objLTbll = new LeaveTypeBLL();
            return objLTbll.GetAllLeaveType();
        }
        
        [WebMethod(EnableSession = true)]
         public static string LeavesAdd(string data)
        {
            LeaveTypeBLL objLTbll = new LeaveTypeBLL();
            //Shift S = (Shift)JsonConvert.DeserializeObject<Shift>(data);
            LeaveType S = (LeaveType)JsonConvert.DeserializeObject<LeaveType>(data);
            return objLTbll.LeavesAdd(S) ;  
        }
        
        [WebMethod(EnableSession = true)]
         public static string GetLvTyForEdit(string data)
               {
                   LeaveTypeBLL objLTbll = new LeaveTypeBLL();
                   Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
                   return objLTbll.GetLvTyForEdit(p);
                   
               }
        
        [WebMethod(EnableSession = true)]
         public static string Delete(string data)
         {
             LeaveTypeBLL objLTdeBLL = new LeaveTypeBLL();
             LeaveType C = (LeaveType)JsonConvert.DeserializeObject<LeaveType>(data);
             return objLTdeBLL.Delete(C);
         }

        [WebMethod(EnableSession = true)]
        public static string EditSave(string data)
        {
            LeaveTypeBLL objLTesBLL = new LeaveTypeBLL();
            LeaveType ObjLType = (LeaveType)JsonConvert.DeserializeObject<LeaveType>(data);
            return objLTesBLL.Edit(ObjLType);
        }

         [WebMethod(EnableSession = true)]
        public static string GetLvTyByID(string data)
        {
            LeaveTypeBLL objLTesBLL = new LeaveTypeBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return objLTesBLL.GetLvTyByID(p);
        }
    }
}