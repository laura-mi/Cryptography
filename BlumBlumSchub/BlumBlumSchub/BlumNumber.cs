using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumBlumSchub
{
    public class BlumNumber
    {
        public long n { get; set; }
        public long p { get; set; }
        public long q { get; set; }
        public BlumNumber(long p, long q)
        {
            if (p % 4 != 3 || q % 4 != 3)
                throw new Exception("Wrong numbers. The inputs must respect the rule x%3 == 4 !");

            this.p = p;
            this.q = q;
            this.n = p * q;
        }
    }
}
