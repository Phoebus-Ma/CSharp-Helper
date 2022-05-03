using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    /**
     * MD5 only support encryption data.
     */
    public class MD5Encrypt
    {
        public static int MD5Generate(string src, out string dest)
        {
            using (var md5Hash = MD5.Create())
            {
                var hashBytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(src));

                dest = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }

            return 0;
        }

        public static int MD5Compare(string src, string dest)
        {
            string temp = "";

            MD5Generate(src, out temp);

            return temp.CompareTo(dest);
        }
    }
}
