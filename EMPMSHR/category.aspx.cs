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
    public partial class category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string LoadCateg()
        {
            CateBLL ObjCateBal = new CateBLL();
            return ObjCateBal.GetAllCategorys();
        }

        [WebMethod(EnableSession = true)]
        public static string GetCateByID(string data)
        {
            CateBLL ObjCateBal = new CateBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjCateBal.GetCateByID(p);
        }

        [WebMethod(EnableSession = true)]
        public static string GetCateForEdit(string data)
        {
            CateBLL ObjCateBal = new CateBLL();
            Paging p = (Paging)JsonConvert.DeserializeObject<Paging>(data);
            return ObjCateBal.GetCateForEdit(p);
        }

        [WebMethod(EnableSession = true)]
        public static string CateAdd(string data)
        {
            CateBLL ObjCateBal = new CateBLL();
            Categorys S = (Categorys)JsonConvert.DeserializeObject<Categorys>(data);
            //return ObjShiftBal.ShiftAdd(C);
            //return ObjShiftBal.ShiftAdd(S);
            return ObjCateBal.CateAdd(S);
        }

        [WebMethod(EnableSession = true)]
        public static string EditSave(string data)
        {
            CateBLL ObjCateBal = new CateBLL();
            Categorys Objcateg = (Categorys)JsonConvert.DeserializeObject<Categorys>(data);
            return ObjCateBal.Edit(Objcateg);
        }

        [WebMethod(EnableSession = true)]
        public static string Delete(string data)
        {
            CateBLL ObjCateBal = new CateBLL();
            Categorys C = (Categorys)JsonConvert.DeserializeObject<Categorys>(data);
            return ObjCateBal.Delete(C);
        }
    }
}