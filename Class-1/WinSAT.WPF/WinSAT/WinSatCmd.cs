using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinSAT
{
    public class WinSatCmd
    {
        private static int DataParse(string filepath, out string datas)
        {
            datas = "";

            if (File.Exists(filepath))
            {
                foreach (string line in File.ReadLines(filepath))
                {
                    if (0 < line.IndexOf("Run"))
                        continue;

                    datas += line + '\n';
                }
            }

            return 0;
        }

        private static int WinsatCmd(string command)
        {
            try
            {
                Process process = new Process();

                process.StartInfo.FileName = "cmd";
                process.StartInfo.Arguments = command;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                return -1;
            }

            return 0;
        }

        public static int PerfTest(out string datas)
        {
            string filepath = System.Environment.CurrentDirectory + "\\score.tmp";
            string command = "/c winsat formal >> " + filepath;

            datas = "";

            if (File.Exists(filepath))
                File.Delete(filepath);

            if (WinsatCmd(command) > -1)
                DataParse(filepath, out datas);

            return 0;
        }
    }
}
