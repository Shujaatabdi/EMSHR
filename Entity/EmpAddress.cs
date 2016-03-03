using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class EmpAddress
    {

        public int ID { get; set; }
        
        public string EmployeeID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9 .-/]*$", ErrorMessage = "insert Valid BranchID I.e no Special Charactors")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number 1 is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "insert Valid Phone 1 I.e no Special Charactors")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string Phone1 { get; set; }
        [Required(ErrorMessage = "Phone Number 2 is required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "insert Valid Phone 2 I.e no Special Charactors")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string Phone2 { get; set; }
        public string Status { get; set; }
    }
}
