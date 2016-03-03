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

namespace BLL
{
    public class BLLCompany
    {
        public string GetAllCompany()
        {
            DALCompany ObjComp = new DALCompany();
            return ObjComp.GetAllCompany();
        }

        public string GetCompanyByID(Paging Page)
        {
                      
            DALCompany ObjComp = new DALCompany();
            return ObjComp.GetCompanybyID(Page);
        }

        public string GetCompanyForEdit(Paging Page)
        {

            DALCompany ObjComp = new DALCompany();
            return ObjComp.GetCompanyForEdit(Page);
        }

        public string Add(Company Data)
        {
            string Status = "";
            DALCompany ObjDalComp = new DALCompany();
            
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
                ObjConst = ObjDalComp.AddCompany(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string Edit(Company Data)
        {
            string Status = "";
            DALCompany ObjDalComp = new DALCompany();
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
                ObjConst = ObjDalComp.EditCompany(Data);

            }

            

            return JsonConvert.SerializeObject(ObjConst);
        }

        public string Delete(Company Data)
        {
            DALCompany ObjDalComp = new DALCompany();

            SystemResponce ObjConst = ObjDalComp.Delete(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

    }
}
