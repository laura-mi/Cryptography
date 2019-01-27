using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    public class Round
    {
        /// <summary>
        /// The number of the round object
        /// </summary>
        int RoundNumber { get; set; }
                
        int[] inputKey { get; set; }

        //Left and right matrix components
        public int[] C = new int[28];
        public int[] D = new int[28];

        //The output key
        public int[] OutputKey { get; set; }

        public Round(int[] key)
        {
            inputKey = key;
            RoundNumber = 0;
            RoundGenerator();
        }

        public Round(int round, Round previousRound)
        {
            RoundNumber = round;
            RoundGenerator(previousRound);
        }

        private void RoundGenerator(Round previousRound = null)
        {
            if (previousRound == null)
            {
                if (RoundNumber != 0)
                    throw new NullReferenceException("The previous round can't be null if round is first!");
                RoundInitialSides();
            }
            else
                RoundSides(previousRound);

            GenerateRoundKey();
        }      

        private void RoundInitialSides()
        {
            var permutations = RoundUtils.PC1;            
            {
                for (int i = 0; i < 28; i++)
                {
                    C[i] = inputKey[permutations[i] - 1];
                    D[i] = inputKey[permutations[28 + i] - 1];
                }
            }
        }

        private void RoundSides(Round previousRound) {
            var service = new RoundService();
            var result = service.Shift(RoundNumber, previousRound.C, previousRound.D);
            C = result.Key;
            D = result.Value;                
        }
        

        private void GenerateRoundKey()
        {
            var n = RoundNumber;
            var permutations = RoundUtils.PC2;
            int[] key = new int[48];
            int[] CD = new int[56];

            for (int i = 0; i < 28; i++)
            {
                CD[i] = C[i];
                CD[i + 28] = D[i];
            }

            for (int i = 0; i < key.Length; i++)
            {
                key[i] = CD[permutations[i] - 1];
            }
            
            OutputKey = key;

        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < OutputKey.Length; i++)
                builder.Append(OutputKey[i]);
            return builder.ToString();
        }

    }
}
