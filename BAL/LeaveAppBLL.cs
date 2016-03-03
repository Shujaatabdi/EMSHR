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
   public class LeaveAppBLL
    {
        public string DDLLvType()
        {
            LeaveAppDAL objLvAppdal = new LeaveAppDAL();
            return objLvAppdal.DDLLvType();
        }
       
        public string LvAppAdd(LeaveApp Data)
        {
            string Status = "";
            LeaveAppDAL objLvAppdal = new LeaveAppDAL();

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
                ObjConst = objLvAppdal.LvAppAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetLvAppByID(Paging page)
        {
            LeaveAppDAL ObjLvAppDal = new LeaveAppDAL();
            return ObjLvAppDal.GetLvAppByID(page);
        }

        public string GetAllLvApp()
        {
            LeaveAppDAL ObjLvAppDal = new LeaveAppDAL();
            return ObjLvAppDal.GetAllLvApp();
        }

        public string GetLvAppForEdit(Paging page)
        {
            LeaveAppDAL ObjLvAppDal = new LeaveAppDAL();
            return ObjLvAppDal.GetLvAppForEdit(page);
        }

        public string Delete(LeaveApp Data)
        {
            LeaveAppDAL objLvAppdal = new LeaveAppDAL();

            SystemResponce ObjConst = objLvAppdal.Delete(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }
    }
}
