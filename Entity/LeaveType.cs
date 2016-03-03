﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LeaveType
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "insert LeaveTypeAdd name")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9\s]*$", ErrorMessage = "insert Valid LeaveType Name I.e no Special Charactors")]
        public string LeaveTyName { get; set; }
        [Required(ErrorMessage = "insert LeaveTypeAdd code")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9\s]*$", ErrorMessage = "insert Valid LeaveType Code I.e no Special Charactors")]
        public string LeaveTyCode { get; set; }
    }
}
