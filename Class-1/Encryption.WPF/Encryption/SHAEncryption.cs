using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class SHAEncryption
    {
        public static int SHAGenerate(int index, string src, out string dest)
        {
            byte[]? hashBytes = null;

            // SHA1
            if (1 == index)
            {
                using (SHA1 shaHash = SHA1.Create())
                {
                    hashBytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(src));
                }
            }
            // SHA256
            else if (2 == index)
            {
                using (SHA256 shaHash = SHA256.Create())
                {
                    hashBytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(src));
                }
            }
            // SHA384
            else if (3 == index)
            {
                using (SHA384 shaHash = SHA384.Create())
                {
                    hashBytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(src));
                }
            }
            // SHA512
            else if (4 == index)
            {
                using (SHA512 shaHash = SHA512.Create())
                {
                    hashBytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(src));
                }
            }

            if (null != hashBytes)
                dest = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            else
                dest = String.Empty;

            return 0;
        }

        public static int SHACompare(int index, string src, string dest)
        {
            string temp = "";

            SHAGenerate(index, src, out temp);

            return temp.CompareTo(dest);
        }
    }
}
