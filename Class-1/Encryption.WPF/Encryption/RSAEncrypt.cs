/**
 * DES Encryption/Decryption example.
 * Ref: [https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsacryptoserviceprovider?view=net-6.0]
 * 
 * License - MIT.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class RSAEncrypt
    {
        public static int Generate(string src, RSAParameters RSAKeyInfo, bool DoOAEPPadding, out string dest)
        {
            dest = String.Empty;

            try
            {
                byte[] enData;
                byte[] rawData = Encoding.UTF8.GetBytes(src);

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);

                    enData = RSA.Encrypt(rawData, DoOAEPPadding);
                }

                dest = BitConverter.ToString(enData);
            }
            catch (CryptographicException ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return 0;
        }

        public static int Parse(string src, RSAParameters RSAKeyInfo, bool DoOAEPPadding, out string dest)
        {
            dest = String.Empty;

            try
            {
                byte[] deData;

                string[] strArray = src.Split("-");

                byte[] encryptData = new byte[strArray.Length];

                for (int i = 0; i < strArray.Length; i++)
                {
                    encryptData[i] = Convert.ToByte(strArray[i], 16);
                }

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);

                    deData = RSA.Decrypt(encryptData, DoOAEPPadding);
                }

                dest = new ASCIIEncoding().GetString(deData);
            }
            catch (CryptographicException ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return 0;
        }

        public static int Compare(string src, RSAParameters RSAKeyInfo, bool DoOAEPPadding, string dest)
        {
            string temp = String.Empty;

            Parse(src, RSAKeyInfo, DoOAEPPadding, out temp);

            return temp.CompareTo(dest);
        }
    }
}
