using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Entity;
using BLL;
using Newtonsoft.Json;

namespace EMPMSHR
{
    public partial class Branch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string LoadBranch(string data)
        {
            BLLBranch ObjBLL = new BLLBranch();
            Paging page = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjBLL.GetAllBranch(page);
        }

        [WebMethod(EnableSession = true)]
        public static string Add(string data)
        {
            BLLBranch ObjBalBranch = new BLLBranch();
            //Branch ObjBranch = (Branch)JsonConvert.DeserializeObject<Branch>(data);
            Entity.Branch ObjBranch = (Entity.Branch)JsonConvert.DeserializeObject<Entity.Branch>(data);
            return ObjBalBranch.SaveBranch(ObjBranch);
        }

        [WebMethod(EnableSession = true)]
        public static string LoadBranchForEdit(string data)
        {
            BLLBranch ObjBalBalBranch = new BLLBranch();
            Paging Page= (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjBalBalBranch.GetBramchForEdit(Page);
        }


        [WebMethod(EnableSession = true)]
        public static string EditSave(string data)
        {
            BLLBranch ObjBalBranch = new BLLBranch();
            //Branch ObjBranch = (Branch)JsonConvert.DeserializeObject<Branch>(data);
            Entity.Branch ObjBranch = (Entity.Branch)JsonConvert.DeserializeObject<Entity.Branch>(data);
            return ObjBalBranch.EditSave(ObjBranch);
        }
    }
}