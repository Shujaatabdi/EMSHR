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
  public  class LeaveTypeBLL
    {


      public string GetLvTyForEdit(Paging Page)
      {
          LeaveTypeDAL ObjLTDal = new LeaveTypeDAL();
          return ObjLTDal.GetLvTyForEdit(Page);
      }

      public string GetLvTyByID(Paging page)
      {
          LeaveTypeDAL objLTdeBLL = new LeaveTypeDAL();
          return objLTdeBLL.GetLvTyByID(page);
      }

      public string GetAllLeaveType()
      {
          LeaveTypeDAL ObjLTDal = new LeaveTypeDAL();
          return ObjLTDal.GetAllLeaveType();
      }

      public string LeavesAdd(LeaveType Data)
      {
          string Status = "";
          LeaveTypeDAL ObjLTDal = new LeaveTypeDAL();

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
              ObjConst = ObjLTDal.LeaveAdd(Data);
          }
          return JsonConvert.SerializeObject(ObjConst);
      }

      public string Delete(LeaveType Data)
      {
          LeaveTypeDAL objLTdeBLL = new LeaveTypeDAL();

          SystemResponce ObjConst = objLTdeBLL.Delete(Data);
          return JsonConvert.SerializeObject(ObjConst);
      }

      public string Edit(LeaveType Data)
      {
          string Status = "";
          LeaveTypeDAL objLTdeBLL = new LeaveTypeDAL();

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
              ObjConst = objLTdeBLL.EditLeaveType(Data);

          }



          return JsonConvert.SerializeObject(ObjConst);
      }



 
    }
}
