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
   public class DeductionBLL
    {
       public string GetAllDeduction()
       {
           DeductionDAL Objallddc = new DeductionDAL();
           return Objallddc.GetAllDeduction();
       }
        public string DeductionAdd(Deductions Data)
        {
            string Status = "";
            DeductionDAL Objall = new DeductionDAL();

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
                ObjConst = Objall.DeductionAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string EditDeduction(Deductions Data)
        {
            //string Status = "";
            DeductionDAL Objall = new DeductionDAL();

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
            ObjConst = Objall.EditDeduction(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }


        public string GetDeductionForPaging(Paging Page)
        {
            DeductionDAL Objall = new DeductionDAL();
            return Objall.GetDeductionForPaging(Page);
        }

        public string DeleteDeduction(Deductions Data)
        {
            DeductionDAL Objall = new DeductionDAL();

            SystemResponce ObjConst = Objall.DeleteDeduction(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetDeductionByID(Paging page)
        {
            DeductionDAL Objall = new DeductionDAL();
            return Objall.GetDeductionByID(page);
        }

    }
}
