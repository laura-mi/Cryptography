using System;
using System.Collections.Generic;
using System.Text;

namespace Caesar_Cipher
{
    //Represents a plain message you intend to ecrypt
    public class PlainMessage
    {
        public string EncryptedMessage { get; set; }
        public string DecryptedMessage { get; set; }
        private Cipher ciper;
        public PlainMessage(string message, int key)
        {
            DecryptedMessage = message;
            ciper = new Cipher(key);
            EncryptedMessage = "Message has not been encryped yet";
            EncryptMessage();
        }

        private void EncryptMessage()
        {
            var message = DecryptedMessage.ToCharArray();
            StringBuilder new_message = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                var value = message[i];
                var new_value = value;
                if (value >= 'A' && value <= 'Z')
                    new_value = ciper.Encipher[value];
                new_message.Append(new_value);
            }

            EncryptedMessage = new_message.ToString();

        }
    }
}
