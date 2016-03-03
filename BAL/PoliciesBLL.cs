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
    public class PolicyBLL
    {

        public string LoadPolicy()
        {
            PolicyDAL ObjAll = new PolicyDAL();
            return ObjAll.LoadPolicy();

        }
        public string PolicyAdd(Policies Data)
        {
            string Status = "";
            PolicyDAL Objall = new PolicyDAL();

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
                ObjConst = Objall.PolicyAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string EditPolicy(Policies Data)
        {
            //string Status = "";
            PolicyDAL Objall = new PolicyDAL();

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
            ObjConst = Objall.EditPolicy(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }


        public string GetPolicyForPaging(Paging Page)
        {
            PolicyDAL Objall = new PolicyDAL();
            return Objall.GetPolicyForPaging(Page);
        }

        public string DeletePolicy(Policies Data)
        {
            PolicyDAL Objall = new PolicyDAL();

            SystemResponce ObjConst = Objall.DeletePolicy(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetPolicyByID(Paging page)
        {
            PolicyDAL Objall = new PolicyDAL();
            return Objall.GetPolicyByID(page);
        }

    }
}
