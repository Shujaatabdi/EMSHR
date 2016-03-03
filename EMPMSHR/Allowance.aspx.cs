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
    public partial class Allowance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]

        public static string LoadAllowance()
        {
            AllowanceBLL ObjAll = new AllowanceBLL();
            return ObjAll.LoadAllowance();
        }
        [WebMethod(EnableSession = true)]
        public static string GetAllowanceByID(string data)
        {
            AllowanceBLL ObjallBal = new AllowanceBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjallBal.GetAllowanceByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetAllowanceForPaging(string data)
        {
            AllowanceBLL ObjallBal = new AllowanceBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjallBal.GetAllowanceForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string AllowanceAdd(string data)
        {
            AllowanceBLL ObjallBal = new AllowanceBLL();
            Allowances B = (Allowances)JsonConvert.DeserializeObject<Allowances>(data);
            //return ObjShiftBal.ShiftAdd(C);
            //return ObjShiftBal.ShiftAdd(S);
            return ObjallBal.AllowanceAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditAllowance(string data)
        {
            AllowanceBLL ObjallBal = new AllowanceBLL();
            Allowances Objall = (Allowances)JsonConvert.DeserializeObject<Allowances>(data);
            return ObjallBal.EditAllowance(Objall);
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteAllowance(string data)
        {
            AllowanceBLL ObjallBal = new AllowanceBLL();
            Allowances C = (Allowances)JsonConvert.DeserializeObject<Allowances>(data);
            return ObjallBal.DeleteAllowance(C);
        }
    }

}