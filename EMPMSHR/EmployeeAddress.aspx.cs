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
    public partial class EmployeeAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]

        public static string LoadEmployeeAddress()
        {
            EmpAddressBLL ObjEmpAdd = new EmpAddressBLL();
            return ObjEmpAdd.LoadEmployeeAddress();
        }
        [WebMethod(EnableSession = true)]
        public static string GetEmployeeAddressByID(string data)
        {
            EmpAddressBLL ObjEmpAdd = new EmpAddressBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjEmpAdd.GetEmployeeAddressByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetEmployeeAddressForPaging(string data)
        {
            EmpAddressBLL ObjEmpAdd = new EmpAddressBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjEmpAdd.GetEmployeeAddressForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string EmployeeAddressAdd(string data)
        {
            EmpAddressBLL ObjEmpAdd = new EmpAddressBLL();
            EmpAddress B = (EmpAddress)JsonConvert.DeserializeObject<EmpAddress>(data);
            //return ObjShiftBal.ShiftAdd(C);
            //return ObjShiftBal.ShiftAdd(S);
            return ObjEmpAdd.EmployeeAddressAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditEmployeeAddress(string data)
        {
            EmpAddressBLL ObjEmpAdd = new EmpAddressBLL();
            EmpAddress O = (EmpAddress)JsonConvert.DeserializeObject<EmpAddress>(data);
            return ObjEmpAdd.EditEmployeeAddress(O);
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteEmployeeAddress(string data)
        {
            EmpAddressBLL ObjEmpAdd = new EmpAddressBLL();
            EmpAddress C = (EmpAddress)JsonConvert.DeserializeObject<EmpAddress>(data);
            return ObjEmpAdd.DeleteEmployeeAddress(C);
        }
    }
}