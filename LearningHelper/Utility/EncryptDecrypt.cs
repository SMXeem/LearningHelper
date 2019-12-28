using System;
using System.Text;

namespace LearningHelper.Utility
{
    public class EncryptDecrypt
    {
        public string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(plainText);
            //return as base64 string
            return Convert.ToBase64String(data);
        }
        public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(cipher);
            return Encoding.Unicode.GetString(data);
        }
    }
}