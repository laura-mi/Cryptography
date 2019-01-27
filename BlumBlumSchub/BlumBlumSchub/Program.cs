using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumBlumSchub
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Console.WriteLine("Please insert p and q.");

              Console.Write("p = ");
              p = Int64.Parse(Console.ReadLine());

              Console.Write("q = ");
              q = Int64.Parse(Console.ReadLine());*/

            GenerateSequence(5);          
            Console.ReadLine();
        }

        public static void GenerateSequence(int total)
        {
            long p, q;            
            p = 1999;
            q = 23;
            GenerateSequence(p, q, total);
        }
        public static void GenerateSequence(long p, long q, int total)
        {
            var generator = new Generator(p, q);
            for (int i = 0; i < total; i++)
                Console.WriteLine(generator.NextValue());
        }
    }
}
