using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Categorys
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "insert Category name")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9]*$", ErrorMessage = "insert Valid Category Name I.e no Special Charactors")]
        public string CateName { get; set; }

    }
}
