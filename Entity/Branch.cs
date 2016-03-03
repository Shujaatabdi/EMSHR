using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Branch
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Ph1 { get; set; }
        public string Ph2 { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
    }
}
