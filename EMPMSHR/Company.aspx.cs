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

namespace EMPMSHR
{
    public partial class AddCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string LoadCompany()
        {
            BLLCompany ObjComp = new BLLCompany();
            return ObjComp.GetAllCompany();
        }

        [WebMethod(EnableSession = true)]
        public static string GetCompByID(string data)
        {
            BLLCompany ObjComp = new BLLCompany();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);  
            return ObjComp.GetCompanyByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetCompForEdit(string data)
        {
            BLLCompany ObjComp = new BLLCompany();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjComp.GetCompanyForEdit(p);
        }

        [WebMethod(EnableSession=true)]
        public static string Add(string data)
        {
            BLLCompany ObjCompBal = new BLLCompany();
            Company C = (Company)JsonConvert.DeserializeObject<Company>(data);
            return ObjCompBal.Add(C);
        }

        [WebMethod(EnableSession = true)]
        public static string EditSave(string data)
        {
            BLLCompany ObjCompBal = new BLLCompany();
            Company ObjCompany = (Company)JsonConvert.DeserializeObject<Company>(data);
            return ObjCompBal.Edit(ObjCompany);
        }

        [WebMethod(EnableSession = true)]
        public static string Delete(string data)
        {
            BLLCompany ObjCompBal = new BLLCompany();
            Company C = (Company)JsonConvert.DeserializeObject<Company>(data);
            return ObjCompBal.Delete(C);
        }


    }
}