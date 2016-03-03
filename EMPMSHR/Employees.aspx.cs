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
namespace EMPMSHR
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession=true)]
        public static string GetAllEmpPaging(string data)
        {
            BLLEmployee ObjBalEmp = new BLLEmployee();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjBalEmp.GetAllEmpPaging(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetEmpByID(string data)
        {
            BLLEmployee ObjCateBal = new BLLEmployee();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjCateBal.GetEmpByID(p);
        }

        //[WebMethod(EnableSession = true)]
        //public static string ADD(string data)
        //{
        //    BLLEmployee ObjBalEmp = new BLLEmployee();
        //    Employee objEmp = (Employee)JsonConvert.DeserializeObject<Employee>(data);
        //    return ObjBalEmp.AddNew(objEmp);
        //}

        [WebMethod(EnableSession = true)]
        public static string AddNew(string data)
        {
            BLLEmployee objBal = new BLLEmployee();
            Employee emp = (Employee)JsonConvert.DeserializeObject<Employee>(data);
            return objBal.AddEmp(emp);
        }

        [WebMethod(EnableSession = true)]
        public static string SaveForEdit(string data)
        {
            BLLEmployee objBal = new BLLEmployee();
            Employee emp = (Employee)JsonConvert.DeserializeObject<Employee>(data);
            return objBal.SaveForEdit(emp);
        }
    }
}