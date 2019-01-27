using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumBlumSchub
{
    public class BlumSeed
    {
        public long Value { get; private set; }
        public BlumSeed(BlumNumber blum)
        {
            var seed = RandomSeed(blum);
            while (seed % blum.p == 0 || seed % blum.q == 0)
                seed = RandomSeed(blum);

            Value = seed;
        }
        private long RandomSeed(BlumNumber blum)
        {
            Random randomGenerator = new Random();
            return 1 + randomGenerator.Next() % (blum.n - 1);
        }
    }
}
