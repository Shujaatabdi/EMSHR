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
        public int LeaveTypeID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //public string LeaveName { get; set; }
        //public string Name { get; set; }


    }
}
