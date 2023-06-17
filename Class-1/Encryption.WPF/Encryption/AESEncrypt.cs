/**
 * DES Encryption/Decryption example.
 * Ref: [https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-6.0]
 * 
 * License - MIT.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Encryption
{
    public class AESEncrypt
    {
        public static int Generate(string src, byte[] Key, byte[] IV, out string dest)
        {
            dest = String.Empty;

            if ((null == src) || (0 >= src.Length))
                return -1;

            if ((null == Key) || (0 >= Key.Length))
                return -1;

            if ((null == IV) || (0 >= IV.Length))
                return -1;

            using (Aes AESalg = Aes.Create())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using(CryptoStream cStream = new CryptoStream(
                        mStream,
                        AESalg.CreateEncryptor(Key, IV),
                        CryptoStreamMode.Write)
                    )
                    {
                        using (StreamWriter sw = new StreamWriter(cStream))
                        {
                            sw.Write(src);
                        }

                        dest = BitConverter.ToString(mStream.ToArray());
                    }
                }
            }

            return 0;
        }

        public static int Parse(string src, byte[] Key, byte[] IV, out string dest)
        {
            dest = String.Empty;

            if ((null == src) || (0 >= src.Length))
                return -1;

            if ((null == Key) || (0 >= Key.Length))
                return -1;

            if ((null == IV) || (0 >= IV.Length))
                return -1;

            string[] strArray = src.Split("-");

            byte[] Data = new byte[strArray.Length];

            for (int i = 0; i < strArray.Length; i++)
            {
                Data[i] = Convert.ToByte(strArray[i], 16);
            }

            using (Aes AESalg = Aes.Create())
            {
                using (MemoryStream mStream = new MemoryStream(Data))
                {
                    using (CryptoStream cStream = new CryptoStream(
                        mStream,
                        AESalg.CreateDecryptor(Key, IV),
                        CryptoStreamMode.Read)
                    )
                    {
                        using (StreamReader sr = new StreamReader(cStream))
                        {
                            dest = sr.ReadToEnd();
                        }
                    }
                }
            }

            return 0;
        }

        public static int Compare(string src, byte[] Key, byte[] IV, string dest)
        {
            string temp = String.Empty;

            Generate(src, Key, IV, out temp);

            return temp.CompareTo(dest);
        }
    }
}
