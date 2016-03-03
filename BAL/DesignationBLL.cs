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
  public  class DesignationBLL
    {
      public string GetAllDesignation()
      {
          DesignationDAL ObjDsgDal = new DesignationDAL();
          return ObjDsgDal.GetAllDesignation();
      }
        public string DesignationAdd(Designations Data)
        {
            string Status = "";
            DesignationDAL ObjDsg = new DesignationDAL();

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
                ObjConst = ObjDsg.DesignationAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string EditDesignation(Designations Data)
        {
           // string Status = "";
            DesignationDAL ObjDsg = new DesignationDAL();

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
            ObjConst = ObjDsg.EditDesignation(Data);

            //}



            return JsonConvert.SerializeObject(ObjConst);
        }


        public string GetDesignationForPaging(Paging Page)
        {
            DesignationDAL ObjDsg = new DesignationDAL();
            return ObjDsg.GetDesignationForPaging(Page);
        }

        public string DeleteDesignation(Designations Data)
        {
            DesignationDAL ObjDsg = new DesignationDAL();

            SystemResponce ObjConst = ObjDsg.DeleteDesignation(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }

        public string GetDesignationByID(Paging page)
        {
            DesignationDAL ObjDsg = new DesignationDAL();
            return ObjDsg.GetDesignationByID(page);
        }
    }
}
