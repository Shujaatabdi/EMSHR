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
  public  class EmpAddressBLL
    {
        public string LoadEmployeeAddress()
        {
            EmpAddressDAL ObjAll = new EmpAddressDAL();
            return ObjAll.LoadEmployeeAddress();

        }
        public string EmployeeAddressAdd(EmpAddress Data)
        {
            string Status = "";
            EmpAddressDAL Objall = new EmpAddressDAL();

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
                ObjConst = Objall.EmployeeAddressAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string EditEmployeeAddress(EmpAddress Data)
        {
            //string Status = "";
            EmpAddressDAL Objall = new EmpAddressDAL();

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
            ObjConst = Objall.EditEmployeeAddress(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }


        public string GetEmployeeAddressForPaging(Paging Page)
        {
            EmpAddressDAL Objall = new EmpAddressDAL();
            return Objall.GetEmployeeAddressForPaging(Page);
        }

        public string DeleteEmployeeAddress(EmpAddress Data)
        {
            EmpAddressDAL Objall = new EmpAddressDAL();

            SystemResponce ObjConst = Objall.DeleteEmployeeAddress(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetEmployeeAddressByID(Paging page)
        {
            EmpAddressDAL Objall = new EmpAddressDAL();
            return Objall.GetEmployeeAddressByID(page);
        }


    }
}
