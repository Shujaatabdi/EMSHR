using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Shift
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "insert shift name")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9_@\s]*$", ErrorMessage = "insert Valid Shift Name I.e no Special Charactors")]
        public string ShiftName { get; set; }
        [Required(ErrorMessage = "insert shift code")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9\s]*$", ErrorMessage = "insert Valid Shift Code I.e no Special Charactors")]
        public string ShiftCode { get; set; }
        [Display(Name = "Release Date")] 
       [Required(ErrorMessage = "insert shift TimeIn")]
       [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string TimeIn { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "insert shift TimeOut")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string TimeOut { get; set; }

        //[Display(Name = "Release Holiday")]
       // [Required(ErrorMessage = "insert shift holiday")]
        public string Holiday { get; set; }
    }
}
