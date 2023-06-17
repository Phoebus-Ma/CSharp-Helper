/**
 * Ref: [https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-compress-and-extract-files]
 * 
 * License - MIT.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Compress.GZIP
{
    public class GZipCompress
    {
        public static int Compress(string filename)
        {
            if (!File.Exists(filename))
                return -1;

            FileInfo fileToCompress = new FileInfo(filename);

            if (".gz" == fileToCompress.Extension)
                return 0;

            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                        CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }

            return 0;
        }

        public static int Decompress(string filename)
        {
            if (!File.Exists(filename))
                return -1;

            FileInfo fileToDecompress = new FileInfo(filename);

            if (".gz" != fileToDecompress.Extension)
                return -1;

            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }

            return 0;
        }
    }
}
