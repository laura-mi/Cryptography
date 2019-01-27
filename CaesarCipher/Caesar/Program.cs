using System;

namespace Caesar_Cipher
{
    class Program
    {
        static void EncryptAMessage(string message)
        {
            Console.WriteLine("Encrypting message...");
            for (int k = 0; k <= 25; k++)
            {
                Console.WriteLine("k = {0}", k);
                var pMessage = new PlainMessage(message, k);
                var encrypt = pMessage.EncryptedMessage;
                Console.WriteLine("Message = {0}", encrypt);
            }
        }
        static void DecryptAMessage(string message)
        {
            Console.WriteLine("Decrypting message...");
            for (int k = 0; k <= 25; k++)
            {
                Console.WriteLine("k = {0}", k);
                var cMessage = new CaesarMessage(message, k);
                var decrypt = cMessage.DecryptedMessage;
                Console.WriteLine("Message = {0}", decrypt);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce string: ");
            var message = Console.ReadLine();
            message = message.ToUpper();
            //Pick what you want to do : encrypt / decrypt
            EncryptAMessage(message);
           // DecryptAMessage(message);
            Console.Read();
        }
    }
}
