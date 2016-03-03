using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public class BLLBranch
    {
        public string GetAllBranch(Paging page)
        {
            DALBranch ObjDalBranch = new DALBranch();
            return ObjDalBranch.GetAllBranchPaging(page);
        }
        public string SaveBranch(Branch Data)
        {
            
            string Status = "";
            DALBranch ObjDalBranch = new DALBranch();

            SystemResponce ObjConst = new SystemResponce();
            ValidationContext context = new ValidationContext(Data, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(Data, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult vr in results)
                {
                    Status += string.Format("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
                }
                ObjConst.Msg = Status;
            }
            else
            {
                ObjConst = ObjDalBranch.AddBranch(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);

        }

        public string GetBramchForEdit(Paging Page)
        {
            DALBranch ObjDalBranch = new DALBranch();
            return ObjDalBranch.GetBranchForEdit(Page);
        }

        public string EditSave(Branch Data)
        {
            string Status = "";
            DALBranch ObjDalBranch = new DALBranch();

            SystemResponce ObjConst = new SystemResponce();
            ValidationContext context = new ValidationContext(Data, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(Data, context, results, true);
            if (!valid)
            {
                foreach (ValidationResult vr in results)
                {
                    Status += string.Format("   ::  {0}{1}", vr.ErrorMessage, Environment.NewLine);
                }
                ObjConst.Msg = Status;
            }
            else
            {
                ObjConst = ObjDalBranch.EditSaveBranch(Data);
            }
            return JsonConvert.SerializeObject(ObjConst);
        }
    }
}
