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
    public class DepartmentBLL
    {


        //public string GetDepartmentByID(Departments Data)
        //{
        //    DepartmentDAL ObjDprt = new DepartmentDAL();
        //    return ObjDprt.GetDepartmentByID(Data);
        //}
        public string GetAllDepartment()
        {
            DepartmentDAL ObjDprtDal = new DepartmentDAL();
            return ObjDprtDal.GetAllDepartment();
        }
        public string DepartmentAdd(Departments Data)
        {
            string Status = "";
            DepartmentDAL ObjDprtDal = new DepartmentDAL();

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
                ObjConst = ObjDprtDal.DepartmentAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string EditDepartment(Departments Data)
        {
            //string Status = "";
            DepartmentDAL ObjDprtDal = new DepartmentDAL();

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
                ObjConst = ObjDprtDal.EditDepartment(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }

            
        public string GetDepartmentForPaging(Paging Page)
        {
            DepartmentDAL ObjDprtDal = new DepartmentDAL();
            return ObjDprtDal.GetDepartmentForPaging(Page);
        }

           public string DeleteDepartment(Departments Data)
        {
            DepartmentDAL ObjDprtDAL = new DepartmentDAL();

            SystemResponce ObjConst = ObjDprtDAL.DeleteDepartment(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetDepartmentByID(Paging page)
        {
            DepartmentDAL ObjDprt = new DepartmentDAL();
            return ObjDprt.GetDepartmentByID(page);
        }
    }
}
