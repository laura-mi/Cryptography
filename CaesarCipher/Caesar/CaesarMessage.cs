using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    //Represents a message wich has been encrypted
    public class CaesarMessage
    {
        public string EncryptedMessage { get; set; }
        public string DecryptedMessage { get; set; }
        private Cipher ciper;
        public CaesarMessage(string message, int key)
        {
            EncryptedMessage = message;
            ciper = new Cipher(key);
            DecryptedMessage = "Message has not been decryped yet";
            DecryptMessage();
        }

        private void DecryptMessage()
        {
            var message = EncryptedMessage.ToCharArray();
            StringBuilder new_message = new StringBuilder();
            for (int i=0;i<message.Length;i++)
            {
                var value = message[i];
                var new_value = value;
                if (value >= 'A' && value <='Z')                   
                 new_value = ciper.Decipher[value];
                new_message.Append(new_value);
            }

            DecryptedMessage = new_message.ToString();
            
        }
    }
}
