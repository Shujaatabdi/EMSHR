using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class EmpBInfo
    {

        public int ID { get; set; }
        public int EmpID { get; set; }
        [Required(ErrorMessage = "Bank Name is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z -/.]*$", ErrorMessage = "insert Valid Bank Name I.e no Special Charactors")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9 #.-/]*$", ErrorMessage = "insert Valid Branch I.e no Special Charactors")]
        public string Branch { get; set; }
        [Required(ErrorMessage = "Account Number is required")]
        [RegularExpression(@"^[0-9 -/.]*$", ErrorMessage = "insert Valid Account Number I.e no Special Charactors")]
        public string AccountNo { get; set; }
        [Required(ErrorMessage = "Account Title is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid Account Title I.e no Special Charactors")]
        public string AccountTitle { get; set; }
    }
}
