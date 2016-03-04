﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Allowances
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Allowance Name is required")]
        public string Name { get; set; }
    }
}
