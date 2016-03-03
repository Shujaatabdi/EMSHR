using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace BLL
{
    public class BLLEmployee
    {
        public string GetAllEmpPaging(Paging Page)
        {
            DALEmployee ObjDalEmp = new DALEmployee();
            return ObjDalEmp.GetAllEmployeePaging(Page);
        }

        public string SaveForEdit(Employee Data)
        {
            string Status = "";
            DALEmployee ObjDalEmp = new DALEmployee();

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
                ObjConst.Msg = Status.Replace("::", "<br>");
            }
            else
            {
                ObjConst = ObjDalEmp.Edit(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string AddEmp(Employee Data)
        {
            string Status = "";
            DALEmployee ObjDalEmp = new DALEmployee();

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
                ObjConst.Msg = Status.Replace("::","<br>");
            }
            else
            {
                ObjConst = ObjDalEmp.ADD(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetEmpByID(Paging P)
        {
            DALEmployee ObjDal= new DALEmployee();
            return ObjDal.GetEmployeeByID(P);
        }


    }
}
