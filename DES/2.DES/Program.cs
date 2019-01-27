using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    class Program
    {
        static Dictionary<int, Round> RoundSet = new Dictionary<int, Round>();
        static void Main(string[] args)
        {
            var service = new RoundService();
            string initialKey = Console.ReadLine();

            var binaryKey = service.GetBinaryKey(initialKey);

            //Round 0
            var round_0 = new Round(binaryKey);
            RoundSet.Add(0, round_0);

            //Compute the rest of the rounds
            for(int i = 1;i<=16;i++)
            {
                var round = new Round(i,RoundSet[i-1]);
                RoundSet.Add(i, round);
            }

            //Check the result in round 10
            Console.WriteLine(RoundSet[10]);
            Console.ReadLine();
        }
    }
}
