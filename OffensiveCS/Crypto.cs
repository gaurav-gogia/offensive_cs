using System;
using System.IO;
using System.Security.Cryptography;

namespace OffensiveCS
{
    class Crypto
    {
        public static string Encode(string txt, byte[] key, byte[] iv)
        {
            byte[] cipher;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(txt);
                        }

                        cipher = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(cipher);
        }

        public static string Decode(string cipher, byte[] key, byte[] iv)
        {
            byte[] cipdata = Convert.FromBase64String(cipher);
            string data;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(cipdata))
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
                using (StreamReader streamReader = new StreamReader(cryptoStream))
                    data = streamReader.ReadToEnd();
            }

            return data;
        }
    }
}
