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
    public class ShiftBLL
    {


        public string GetShftByID(Paging page)
        {
            ShiftDAL ObjShift = new ShiftDAL();
            return ObjShift.GetShftByID(page);
        }

        public string GetShiftForEdit(Paging Page)
        {
            ShiftDAL ObjShiftDal = new ShiftDAL();
            return ObjShiftDal.GetShiftForEdit(Page);
        }

        public string ShiftAdd(Shift Data)
        {
            string Status = "";
            ShiftDAL ObjShiftDal = new ShiftDAL();

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
                ObjConst = ObjShiftDal.ShiftAdd(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }
        
        public string Edit(Shift Data)
        {
            string Status = "";
            ShiftDAL ObjShiftDal = new ShiftDAL();

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
                ObjConst = ObjShiftDal.EditShift(Data);

            }



            return JsonConvert.SerializeObject(ObjConst);
        }

        //public string GetAllCompany()
        //{
        //    throw new NotImplementedException();
        //}



        public string GetAllShifts()
        {
            ShiftDAL ObjShiftDal = new ShiftDAL();
            return ObjShiftDal.GetAllShifts();
        }

        public string Delete(Shift Data)
        {
            ShiftDAL ObjDalShift = new ShiftDAL();

            SystemResponce ObjConst = ObjDalShift.Delete(Data);
            return JsonConvert.SerializeObject(ObjConst);
        }
        public string getHolidays(Shift Data)
        {
            string Status = "";
            ShiftDAL ObjShiftDal = new ShiftDAL();

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
                ObjConst = ObjShiftDal.getHolidays(Data);

            }



            return JsonConvert.SerializeObject(ObjConst);
        }
    }
}
