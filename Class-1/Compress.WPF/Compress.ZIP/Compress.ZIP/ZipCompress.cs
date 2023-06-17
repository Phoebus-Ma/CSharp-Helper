using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Compress.ZIP
{
    public class ZipCompress
    {
        public static int CompressDirectory(string srcPath, string dstPath)
        {
            if (Directory.Exists(srcPath))
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(srcPath);

                    if (!Directory.Exists(dstPath))
                        Directory.CreateDirectory(dstPath);

                    dstPath = dstPath + "\\" + directoryInfo.Name + ".zip";

                    ZipFile.CreateFromDirectory(srcPath, dstPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                return -1;
            }

            return 0;
        }

        public static int DecompressFile(string srcFile, string dstPath)
        {
            if (File.Exists(srcFile))
            {
                if (".zip" == Path.GetExtension(srcFile))
                {
                    try
                    {
                        dstPath = dstPath + "\\" + Path.GetFileNameWithoutExtension(srcFile);

                        if (!Directory.Exists(dstPath))
                            Directory.CreateDirectory(dstPath);

                        ZipFile.ExtractToDirectory(srcFile, dstPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }

            return 0;
        }
    }
}
