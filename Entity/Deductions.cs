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
        [Required(ErrorMessage = "insert Name")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid BranchID I.e no Special Charactors")]
        public string Name { get; set; }
    }
}
