using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    //It's a cipher determined by a specific key.
    //It's used to ecnrypt or decrypt a message.
    public class Cipher
    {
        public char[] Alphabet;
        public Dictionary<Char, Char> Encipher;
        public int Key;
        public Dictionary<Char, Char> Decipher;
        private void CreateAlphabet()
        {
            Alphabet = new char[27];
            char letter = 'A';
            for (int index = 0; index <= 25; index++)
            {
                Alphabet[index] = letter;
                letter++;
            }
        }
        private void CreateDecipher()
        {
            Decipher = new Dictionary<Char, Char>();
            for (int index = 0;index<=25; index++)
            {
                char value = Alphabet[index];
                char key;
                if(index-Key >= 0)
                 key = (char)(value - Key);
                else
                    key = (char)(value - Key + 26);

                Decipher.Add(value, key);
            }            
        }
        private void CreateEncipher()
        {
            Encipher = new Dictionary<Char, Char>();
            for (int index = 0; index <= 25; index++)
            {
                char value = Alphabet[index];
                char key;
                if (index + Key <= 25)
                    key = (char)(value + Key);
                else
                    key = (char)(value + Key - 26);

                Encipher.Add(value, key);
            }
        }

        public Cipher(int key)
        {
            CreateAlphabet();
            Key = key;
            CreateDecipher();
            CreateEncipher();
        }
       
    }
}
