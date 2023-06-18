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

namespace CPUUsageRecorder
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
                float usage = 0;
                var cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

                if (cpuCounter != null)
                {
                    while (true)
                    {
                        usage = cpuCounter.NextValue();

                        tbl_usage.Dispatcher.Invoke(() =>
                        {
                            tbl_usage.Content = usage.ToString();
                        });

                        Thread.Sleep(1000);
                    }
                }
            });
        }
    }
}
