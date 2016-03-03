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
    public partial class Shifts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string LoadShift()
        {
            ShiftBLL ObjShiftBal = new ShiftBLL();
            return ObjShiftBal.GetAllShifts();
        }
        [WebMethod(EnableSession = true)]
        public static string getHolidays(string data)
        {
            ShiftBLL ObjShiftBal = new ShiftBLL();
            Shift ObjShft = (Shift)JsonConvert.DeserializeObject<Shift>(data);
            return ObjShiftBal.getHolidays(ObjShft);

        }
        [WebMethod(EnableSession = true)]
        public static string GetShftByID(string data)
        {
            ShiftBLL ObjShiftBal = new ShiftBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjShiftBal.GetShftByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetShftForEdit(string data)
        {
            ShiftBLL ObjShiftBal = new ShiftBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjShiftBal.GetShiftForEdit(p);
        }
        
        [WebMethod(EnableSession = true)]
        public static string ShiftAdd(string data)
        {
           ShiftBLL ObjShiftBal = new ShiftBLL();
           Shift S = (Shift)JsonConvert.DeserializeObject<Shift>(data);
           //return ObjShiftBal.ShiftAdd(C);
           //return ObjShiftBal.ShiftAdd(S);
           return ObjShiftBal.ShiftAdd(S);
        }

        [WebMethod(EnableSession = true)]
        public static string EditSave(string data)
        {
            ShiftBLL ObjShiftBal = new ShiftBLL();
            Shift ObjShft = (Shift)JsonConvert.DeserializeObject<Shift>(data);
            return ObjShiftBal.Edit(ObjShft);
        }

        [WebMethod(EnableSession = true)]
        public static string Delete(string data)
        {
            ShiftBLL ObjShiftBal = new ShiftBLL();
            Shift C = (Shift)JsonConvert.DeserializeObject<Shift>(data);
            return ObjShiftBal.Delete(C);
        }
    }
}