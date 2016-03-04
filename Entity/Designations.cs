using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Designations
    {
        public int ID { get; set; }
      
        public string BranchID { get; set; }
        [Required(ErrorMessage = "Designation Name is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid Designation Name I.e no Special Charactors")]
        public string Name { get; set; }
    }
}
