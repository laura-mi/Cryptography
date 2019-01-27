using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumBlumSchub
{
    public class Generator
    {
        private BlumNumber blumNumber;
        private long seed;
        private long currentSeed;
        public Generator(long p, long q)
        {
            blumNumber = new BlumNumber(p, q);
            seed = currentSeed = new BlumSeed(blumNumber).Value;
        }
        public Generator(long p, long q, long seed)
        {
            blumNumber = new BlumNumber(p, q);
            this.seed = currentSeed = seed;
        }
        private long NextSeed()
        {
            var x = currentSeed;
            currentSeed = (x * x) % blumNumber.n;
            return x;
        }       
        public long NextValue()
        {
            var bytes = new StringBuilder();
            for (int i = 0; i < 64; i++)
            {
                var value = NextSeed();
                var byteValue = value%2;
                bytes.Append(byteValue);
            }
            var bytesNumber = Convert.ToInt64(bytes.ToString(), 2);
            return bytesNumber;
        }
      
    }
}
