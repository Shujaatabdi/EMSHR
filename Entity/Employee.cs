using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int DeptID { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public int DesignationID { get; set; }

        [Required(ErrorMessage = "Shift is required")]
        public int ShiftID { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Policy is required")]
        public int PolicyID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Last Name should be minimum 3 and maximum 99 characters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Code should be minimum 3 and maximum 6 characters")]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Father Name is required")]
        [DataType(DataType.Text)]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        public string Picture { get; set; }

        [Required(ErrorMessage = "CNIC is required")]
        [RegularExpression(@"\b\d{5}[-.]?\d{7}[-.]?\d{1}\b",ErrorMessage="Invalid CNIC Format 'xxxxx-xxxxxxx-x'")]
        public string CNIC { get; set; }

        [Required(ErrorMessage = "Tax Or Hst is required")]
        [DataType(DataType.Text)]
        public string TaxHst { get; set; }

        public decimal? Salary { get; set; }
    }
}
