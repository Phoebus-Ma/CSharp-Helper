using System.Management;
using System.Threading.Tasks;
using System.Windows;

namespace HardwareInformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                string infoString   = "";
                string dispString   = "";

                string cpuKeyClass  = "Win32_Processor";
                string cpuKeyWord   = "Name,NumberOfCores,NumberOfLogicalProcessors,MaxClockSpeed";

                string memKeyClass  = "Win32_PhysicalMemory";
                string memKeyWord   = "BankLabel,ConfiguredClockSpeed,Capacity";

                string gpuKeyClass  = "Win32_VideoController";
                string gpuKeyWord   = "DeviceID,Name,AdapterRAM";

                string diskKeyClass = "Win32_DiskDrive";
                string diskKeyWord  = "Index,Model,Size";

                GetHardwareInfo(cpuKeyClass, cpuKeyWord, out infoString);
                dispString += "----CPU:-----\n"    + infoString + "\n";
                GetHardwareInfo(memKeyClass, memKeyWord, out infoString);
                dispString += "----Memory:----\n" + infoString + "\n";
                GetHardwareInfo(gpuKeyClass, gpuKeyWord, out infoString);
                dispString += "----GPU:----\n"    + infoString + "\n";
                GetHardwareInfo(diskKeyClass, diskKeyWord, out infoString);
                dispString += "----Disk:----\n"   + infoString;

                lbl_info.Dispatcher.Invoke(() =>
                {
                    lbl_info.Content = dispString;
                });
            });
        }

        public static int GetHardwareInfo(string keyClass, string keyWord, out string infoString)
        {
            infoString = "";
            string keyString = "SELECT " + keyWord + " FROM " + keyClass;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(keyString);

            string[] keys = keyWord.Split(new char[] { ',' });
            foreach (ManagementObject info in searcher.Get())
            {
                foreach (string key in keys)
                {
                    infoString += key + ":\t" + info[key].ToString() + "\n";
                }
            }

            return 0;
        }
    }
}
