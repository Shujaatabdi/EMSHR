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
    public partial class Policy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]

        public static string LoadPolicy()
        {
            PolicyBLL ObjPol = new PolicyBLL();
            return ObjPol.LoadPolicy();
        }
        [WebMethod(EnableSession = true)]
        public static string GetPolicyByID(string data)
        {
            PolicyBLL ObjPol = new PolicyBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjPol.GetPolicyByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetPolicyForPaging(string data)
        {
            PolicyBLL ObjPol = new PolicyBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjPol.GetPolicyForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string PolicyAdd(string data)
        {
            PolicyBLL ObjPol = new PolicyBLL();
            Policies B = (Policies)JsonConvert.DeserializeObject<Policies>(data);
            //return ObjShiftBal.ShiftAdd(C);
            //return ObjShiftBal.ShiftAdd(S);
            return ObjPol.PolicyAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditPolicy(string data)
        {
            PolicyBLL ObjPol = new PolicyBLL();
            Policies Objall = (Policies)JsonConvert.DeserializeObject<Policies>(data);
            return ObjPol.EditPolicy(Objall);
        }

        [WebMethod(EnableSession = true)]
        public static string DeletePolicy(string data)
        {
            PolicyBLL ObjPol = new PolicyBLL();
            Policies C = (Policies)JsonConvert.DeserializeObject<Policies>(data);
            return ObjPol.DeletePolicy(C);
        }
    }
}