using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Branch
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Company is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9]*$", ErrorMessage = "Company I.e no Special Charactors")]
        public int CompanyID { get; set; }
        [Required(ErrorMessage = "Branch Code is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9]*$", ErrorMessage = "Branch Code I.e no Special Charactors")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z\s][a-zA-Z0-9 .-/]*$", ErrorMessage = "Address I.e no Special Charactors")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number 1 is required")]
        [RegularExpression(@"^[0-9 -/]*$", ErrorMessage = "Phone Number 1 I.e no Special Charactors")]
        public string Ph1 { get; set; }
        [Required(ErrorMessage = "Phone Number 2 is required")]
        [RegularExpression(@"^[0-9 -/]*$", ErrorMessage = "Phone Number 2 I.e no Special Charactors")]
        public string Ph2 { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "WebSite is required")]
        public string WebSite { get; set; }
        [Required(ErrorMessage = "PostalCode is required")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        public string Status { get; set; }
    }
}
