using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Entity;
using DAL;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BAL
{
    public class CateBLL
    {
        public string FillCboCat()
        {
            CateDAL objDalCategory = new CateDAL();
            return objDalCategory.FillCboCat();
        }
        public string Edit(Categorys Data)
        {
            string Status = "";
            CateDAL ObjCate = new CateDAL();

            SystemResponce ObjConst = new SystemResponce();
            ValidationContext context = new ValidationContext(Data, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(Data, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult vr in results)
                {
                    //Response.Write(string.Format("Member Name :{0}", vr.MemberNames.First()));

                    Status += string.Format("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
                }
                ObjConst.Msg = Status;
            }
            else
            {
                //Submit the form in database
                ObjConst = ObjCate.EditCate(Data);

            }



            return JsonConvert.SerializeObject(ObjConst);
        }

        //public string GetAllCompany()
        //{
        //    throw new NotImplementedException();
        //}

        public string Delete(Categorys Data)
        {
            CateDAL ObjCate = new CateDAL();

            SystemResponce ObjConst = ObjCate.Delete(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetAllCategorys()
        {
            CateDAL ObjCate = new CateDAL();
            return ObjCate.GetAllCates();
        }

        public string GetCateByID(Paging page)
        {
            CateDAL ObjCate = new CateDAL();
            return ObjCate.GetCateByID(page);
        }

        public string GetCateForEdit(Paging Page)
        {
            CateDAL ObjCate = new CateDAL();
            return ObjCate.GetCateForEdit(Page);
        }

        public string CateAdd(Categorys Data)
        {
            string Status = "";
            CateDAL ObjCate = new CateDAL();

            SystemResponce ObjConst = new SystemResponce();
            ValidationContext context = new ValidationContext(Data, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(Data, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult vr in results)
                {
                    //Response.Write(string.Format("Member Name :{0}", vr.MemberNames.First()));

                    Status += string.Format("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
                }
                ObjConst.Msg = Status;
            }
            else
            {
                ObjConst = ObjCate.CateAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }
    }
    
}
