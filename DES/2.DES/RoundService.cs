using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES
{
    public class RoundService
    {
        public int[] GetBinaryKey(string key)
        {
            var keyBytes = new int[64];
            var bytes = Encoding.ASCII.GetBytes(key);
            var keyBuilder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                keyBuilder.Append(Convert.ToString(bytes[i], 2).PadLeft(8, '0'));
            }
            key = keyBuilder.ToString();
            for (int i = 0; i < key.Length; i++)
            {
                keyBytes[i] = int.Parse(key[i].ToString());
            }
            
            return keyBytes;
        }

        public KeyValuePair<int[],int[]> Shift (int roundNr, int[] C, int[] D)
        {
            var i = roundNr;
            if (RoundUtils.RS[i - 1] == 1)
                return Shift1(i,C,D);
            else
               return Shift2(i,C,D);           
        }

        KeyValuePair<int[], int[]> Shift2(int i, int[] prevC, int[] prevD)
        {
            var C = new int[prevC.Length];
            var D = new int[prevD.Length];
            for (int j = 0; j < 26; j++)
            {
                C[j] = prevC[j + 2];
                D[j] = prevD[j + 2];
            }
            C[26] = prevC[0];
            D[26] = prevD[0];
            C[27] = prevC[1];
            D[27] = prevD[1];
            return new KeyValuePair<int[], int[]>(C, D);
        }

        KeyValuePair<int[], int[]> Shift1(int i, int[] prevC, int[] prevD)
        {
            var C = new int[prevC.Length];
            var D = new int[prevD.Length];
            for (int j = 0; j < 27; j++)
            {
                C[j] = prevC[j + 1];
                D[j] = prevD[j + 1];
            }
            C[27] = prevC[0];
            D[27] = prevD[0];
            return new KeyValuePair<int[], int[]>(C, D);
        }
    }
}
