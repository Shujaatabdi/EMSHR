using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Departments
    {
        public int ID { get; set; }
        
        public string BranchID { get; set; }
        [Required(ErrorMessage = "department name is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid department Name I.e no Special Charactors")]
        public string Name { get; set; }
        [Required(ErrorMessage = "department code is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9\s]*$", ErrorMessage = "insert Valid department Code I.e no Special Charactors")]
        public string Code { get; set; }
        
        public string ManagerID { get; set; }
       
    }
}
