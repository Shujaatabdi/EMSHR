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
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string LoadDepartment()
        {
            DepartmentBLL objDprtBal = new DepartmentBLL();
            return objDprtBal.GetAllDepartment();
        }

        [WebMethod(EnableSession = true)]
        public static string GetDepartmentByID(string data)
        {
            DepartmentBLL ObjDprtBal = new DepartmentBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjDprtBal.GetDepartmentByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetDepartmentForPaging(string data)
        {
            DepartmentBLL ObjDprtBal = new DepartmentBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjDprtBal.GetDepartmentForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string DepartmentAdd(string data)
        {
            DepartmentBLL ObjBranchBal = new DepartmentBLL();
           Departments B = (Departments)JsonConvert.DeserializeObject<Departments>(data);
           //return ObjShiftBal.ShiftAdd(C);
           //return ObjShiftBal.ShiftAdd(S);
           return ObjBranchBal.DepartmentAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditDepartment(string data)
        {
            DepartmentBLL ObjDprtBal = new DepartmentBLL();
            Departments ObjDprt = (Departments)JsonConvert.DeserializeObject<Departments>(data);
            return ObjDprtBal.EditDepartment(ObjDprt);
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteDepartment(string data)
        {
            DepartmentBLL ObjDprtBal = new DepartmentBLL();
            Departments C = (Departments)JsonConvert.DeserializeObject<Departments>(data);
            return ObjDprtBal.DeleteDepartment(C);
        }
    }
}