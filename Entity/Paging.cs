using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ss
    {
        public string Pname { get; set; }
        public string Pval { get; set; }
    }
    public class Paging
    {

        public string PageNo { get; set; }
        public string RecordPerPage { get; set; }
        public string SortBy { get; set; }
        public string SortAs { get; set; }
        public string SearchBy { get; set; }
        public string SearchVal { get; set; }
        public ss[]  Extra { get; set; }

    }
}
