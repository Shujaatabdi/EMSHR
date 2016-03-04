using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public  class Policies
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Policies Name is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid BranchID I.e no Special Charactors")]
        public string Name { get; set; }

        public string GraceTime { get; set; }
        public string MaxOverTime { get; set; }
        public string PerHourOverTime { get; set; }
    }

  
}
