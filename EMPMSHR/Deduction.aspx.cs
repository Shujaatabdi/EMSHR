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
    public partial class Deduction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static string LoadDeduction()
        {
            DeductionBLL ObjdctionBal = new DeductionBLL();
            return ObjdctionBal.GetAllDeduction();
        }

        [WebMethod(EnableSession = true)]
        public static string GetDeductionByID(string data)
        {
            DeductionBLL ObjdctionBal = new DeductionBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjdctionBal.GetDeductionByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetDeductionForPaging(string data)
        {
            DeductionBLL ObjdctionBal = new DeductionBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjdctionBal.GetDeductionForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string DeductionAdd(string data)
        {
            DeductionBLL ObjdctionBal = new DeductionBLL();
            Deductions B = (Deductions)JsonConvert.DeserializeObject<Deductions>(data);
            //return ObjShiftBal.ShiftAdd(C);
            //return ObjShiftBal.ShiftAdd(S);
            return ObjdctionBal.DeductionAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditDeduction(string data)
        {
            DeductionBLL ObjdctionBal = new DeductionBLL();
            Deductions Objall = (Deductions)JsonConvert.DeserializeObject<Deductions>(data);
            return ObjdctionBal.EditDeduction(Objall);
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteDeduction(string data)
        {
            DeductionBLL ObjdctionBal = new DeductionBLL();
            Deductions C = (Deductions)JsonConvert.DeserializeObject<Deductions>(data);
            return ObjdctionBal.DeleteDeduction(C);
        }
    
    
    
    }
}