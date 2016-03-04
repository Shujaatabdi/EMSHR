using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class LeaveApp
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
          [Required(ErrorMessage = "Leave Name is required")]
        public int LeaveTypeID { get; set; }
          [Required(ErrorMessage = "Mention DateFrom is required")]
        public DateTime DateFrom { get; set; }
          [Required(ErrorMessage = "Mention DateTo is required")]
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //public string LeaveName { get; set; }
        //public string Name { get; set; }


    }
}
