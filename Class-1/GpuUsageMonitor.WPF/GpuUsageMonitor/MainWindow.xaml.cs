using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GpuUsageMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**
         * In the Performance Monitor built into Windows,
         * we can see instance objects for the GPU Engine,
         * 
         * such as:
         * pid_12196_luid_0x00000000_0x00011373_phys_0_eng_0_engtype_3D
         * pid_12196_luid_0x00000000_0x00011373_phys_0_eng_3_engtype_VideoDecode
         * pid_12196_luid_0x00000000_0x00011373_phys_0_eng_6_engtype_Copy
         * pid_12196_luid_0x00000000_0x00011373_phys_0_eng_3_engtype_VideoEecode
         * 
         * We just need to filter the objects we want by keyword and calculate the sum of their values,
         * This is the data for one of the metrics of the GPU.
         */
        /**
         * engtype_3D
         * engtype_Copy
         * engtype_VideoDecode
         * engtype_VideoEecode
         * engtype_VideoProcessing
         * engtype_Compute_0
         * engtype_LegacyOverlay
         * ... ...
         */
        private static string ENGTYPE_3D = "engtype_3D";

        public MainWindow()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                float usage = 0;
                var category = new PerformanceCounterCategory("GPU Engine");

refreshInstance:
                var counterNames = category.GetInstanceNames();

                var gpuCounters = counterNames
                    .Where(counterName => counterName.Contains(ENGTYPE_3D))
                    .SelectMany(counterName => category.GetCounters(counterName))
                    .Where(counter => counter.CounterName.Equals("Utilization Percentage"))
                    .ToList();

                try
                {
                    if (gpuCounters != null)
                    {
                        while (true)
                        {
                            usage = gpuCounters.Sum(x => x.NextValue());

                            tbl_usage.Dispatcher.Invoke(() =>
                            {
                                tbl_usage.Content = usage.ToString();
                            });

                            Thread.Sleep(1000);
                        }
                    }
                }
                catch (System.InvalidOperationException)
                {
                    Thread.Sleep(1000);
                    goto refreshInstance;
                }
            });
        }
    }
}
