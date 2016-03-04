using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Deductions
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Deduction Name is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid Deduction Name I.e no Special Charactors")]
        public string Name { get; set; }
    }
}
