using DAL;
using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class AllowanceBLL
    {
        public string LoadAllowance() 
        {
            AllowanceDAL ObjAll = new AllowanceDAL();
            return ObjAll.LoadAllowance();
        
        }
        public string AllowanceAdd(Allowances Data)
        {
            string Status = "";
            AllowanceDAL Objall = new AllowanceDAL();

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
                ObjConst = Objall.AllowanceAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string EditAllowance(Allowances Data)
        {
            //string Status = "";
            AllowanceDAL Objall = new AllowanceDAL();

            SystemResponce ObjConst = new SystemResponce();
            ValidationContext context = new ValidationContext(Data, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(Data, context, results, true);
            //if (!valid)
            //{
            //    foreach (ValidationResult vr in results)
            //    {
            //        //Response.Write(string.Format("Member Name :{0}", vr.MemberNames.First()));

            //        Status += string.Format("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
            //    }
            //    ObjConst.Msg = Status;
            //}
            //else
            //{
            //Submit the form in database
            ObjConst = Objall.EditAllowance(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }


        public string GetAllowanceForPaging(Paging Page)
        {
            AllowanceDAL Objall = new AllowanceDAL();
            return Objall.GetAllowanceForPaging(Page);
        }

        public string DeleteAllowance(Allowances Data)
        {
            AllowanceDAL Objall = new AllowanceDAL();

            SystemResponce ObjConst = Objall.DeleteAllowance(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetAllowanceByID(Paging page)
        {
            AllowanceDAL Objall = new AllowanceDAL();
            return Objall.GetAllowanceByID(page);
        }

    }
}
