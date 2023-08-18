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

using OpenHardwareMonitor.Hardware;

namespace SimpleHardwareMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Computer computerHardware = null;

        public MainWindow()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                float Usage = -1;
                float Watts = -1;

                computerHardware = new Computer();

                // computerHardware.MainboardEnabled = true;
                computerHardware.CPUEnabled = true;
                computerHardware.Open();

                while (true)
                {
                    showMonitor(out Usage, out Watts);

                    lbl_monitor.Dispatcher.Invoke(() =>
                    {
                        lbl_monitor.Content = "Usage: " + Usage + " %\n" + "Watts: " + Watts + " (W)";
                    });

                    Thread.Sleep(1000);
                }
            });
        }

        public static int showMonitor(out float Usage, out float Watts)
        {
            Usage = -1;
            Watts = -1;

            foreach (var hardware in computerHardware.Hardware)
            {
                hardware.Update();

                if (HardwareType.CPU == hardware.HardwareType)
                {
                    foreach (var hardwareSensor in hardware.Sensors)
                    {
                        /**
                         * SensorType.Load
                         * SensorType.Power
                         * SensorType.Clock
                         * SensorType.Temperature
                         * SensorType.Fan
                         */
                        switch (hardwareSensor.SensorType)
                        {
                            case SensorType.Load:
                                if ("CPU Total" == hardwareSensor.Name)
                                {
                                    Usage = (float)Math.Round((float)hardwareSensor.Value, 2);
                                }

                                break;

                            case SensorType.Power:
                                if ("CPU Package" == hardwareSensor.Name)
                                {
                                    Watts = (float)Math.Round((float)hardwareSensor.Value, 2);
                                }

                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
