/**
 * DES Encryption/Decryption example.
 * Ref: [https://docStream.microsoft.com/en-us/dotnet/api/system.security.cryptography.des.create?view=net-6.0]
 * 
 * License - MIT.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class DESEncrypt
    {
        public static int Generate(string src, byte[] Key, byte[] IV, out string dest)
        {
            dest = "";

            try
            {
                DES DESalg = DES.Create();

                MemoryStream mStream = new MemoryStream();

                CryptoStream cStream = new CryptoStream(
                    mStream,
                    DESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write
                );

                byte[] encryptData = new ASCIIEncoding().GetBytes(src);

                cStream.Write(encryptData, 0, encryptData.Length);
                cStream.FlushFinalBlock();

                dest = BitConverter.ToString(mStream.ToArray());

                cStream.Close();
                mStream.Close();
            }
            catch (CryptographicException ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return 0;
        }

        public static int Parse(string src, byte[] Key, byte[] IV, out string dest)
        {
            int status = 0;
            dest = "";

            try
            {
                string[] strArray = src.Split("-");

                byte[] Data = new byte[strArray.Length];

                for (int i = 0; i < strArray.Length; i++)
                {
                    Data[i] = Convert.ToByte(strArray[i], 16);
                }

                DES DESalg = DES.Create();

                MemoryStream mStream = new MemoryStream(Data);

                CryptoStream cStream = new CryptoStream(
                    mStream,
                    DESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read
                );

                byte[] decryptData = new byte[src.Length];

                cStream.Read(decryptData, 0, decryptData.Length);

                dest = new ASCIIEncoding().GetString(decryptData);
            }
            catch (CryptographicException ex)
            {
                status = -1;
                Trace.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                status = -2;
                Trace.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                status = -3;
                Trace.WriteLine(ex.Message);
            }

            return status;
        }

        public static int Compare(string src, byte[] Key, byte[] IV, string dest)
        {
            string temp = "";

            Generate(src, Key, IV, out temp);

            return temp.CompareTo(dest);
        }
    }
}
