using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Policy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GraceTime { get; set; }
        public int MaxOverTime { get; set; }
        public int PerHourAmount { get; set; }

    }
}
