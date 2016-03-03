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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession=true)]
        public static string LoadData()
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
    }
}