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
    public partial class Designation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string LoadDesignation()
        {
            DesignationBLL objDsgBal = new DesignationBLL();
            return objDsgBal.GetAllDesignation();
        }

        [WebMethod(EnableSession = true)]
        public static string GetDesignationByID(string data)
        {
            DesignationBLL ObjDsgBal = new DesignationBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjDsgBal.GetDesignationByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetDesignationForPaging(string data)
        {
            DesignationBLL ObjDsgBal = new DesignationBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjDsgBal.GetDesignationForPaging(p);
        }


        [WebMethod(EnableSession = true)]
        public static string DesignationAdd(string data)
        {
            DesignationBLL ObjdsgBal = new DesignationBLL();
            Designations B = (Designations)JsonConvert.DeserializeObject<Designations>(data);
            //return ObjShiftBal.ShiftAdd(C);
            //return ObjShiftBal.ShiftAdd(S);
            return ObjdsgBal.DesignationAdd(B);
        }

        [WebMethod(EnableSession = true)]
        public static string EditDesignation(string data)
        {
            DesignationBLL ObjDsgBal = new DesignationBLL();
            Designations ObjDprt = (Designations)JsonConvert.DeserializeObject<Designations>(data);
            return ObjDsgBal.EditDesignation(ObjDprt);
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteDesignation(string data)
        {
            DesignationBLL ObjDsgBal = new DesignationBLL();
            Designations C = (Designations)JsonConvert.DeserializeObject<Designations>(data);
            return ObjDsgBal.DeleteDesignation(C);
        }
    }
}