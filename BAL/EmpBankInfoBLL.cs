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
  public  class EmpBankInfoBLL
    {
      public string LoadEmpBankInfo()
      {
          EmpBankInfoDAL objEMP = new EmpBankInfoDAL();
          return objEMP.LoadEmpBankInfo();
      }
      public string EmpBAnkInfoAdd(EmpBInfo Data)
        {
            string Status = "";
            EmpBankInfoDAL Objall = new EmpBankInfoDAL();

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
                ObjConst = Objall.EmpBankInfoAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

      public string EditEmpBAnkInfo(EmpBInfo Data)
        {
            //string Status = "";
            EmpBankInfoDAL Objall = new EmpBankInfoDAL();

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
            ObjConst = Objall.EditEmpBankInfo(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }


        public string GetEmpBAnkInfoForPaging(Paging Page)
        {
            EmpBankInfoDAL Objall = new EmpBankInfoDAL();
            return Objall.GetEmpBankInfoForPaging(Page);
        }

        public string DeleteEmpBAnkInfo(EmpBInfo Data)
        {
            EmpBankInfoDAL Objall = new EmpBankInfoDAL();

            SystemResponce ObjConst = Objall.DeleteEmpBankInfo(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetEmpBAnkInfoByID(Paging page)
        {
            EmpBankInfoDAL Objall = new EmpBankInfoDAL();
            return Objall.GetEmpBankInfoByID(page);
        }

    }
}
