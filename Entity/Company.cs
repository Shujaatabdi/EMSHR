using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Company
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Address should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string Address { get; set; }
    }
}
