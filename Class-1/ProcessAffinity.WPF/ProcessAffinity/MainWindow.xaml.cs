using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ProcessAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetProcMask_StartClick(object sender, RoutedEventArgs e)
        {
            string status = "";

            if (tbox_pid.Text.Length > 0)
            {
                IntPtr procHandle = IntPtr.Zero;
                int procId = int.Parse(tbox_pid.Text.ToString());

                /* Open Process. */
                ProcessMask.OpenProcess(procId, out procHandle);

                /* Process CPU affinity mask. */
                if (tbox_affinity.Text.Length > 0)
                {
                    UIntPtr CpuMask = new UIntPtr(ulong.Parse(tbox_affinity.Text.ToString()));

                    if (ProcessMask.SetProcessAffinityMask(procHandle, CpuMask))
                    {
                        status += "Affinity OK, ";
                    }
                    else
                    {
                        status += "Affinity Failed, ";
                    }
                }

                /* Process priority. */
                var prioSelect = cbox_priority.SelectedIndex;

                if (prioSelect > 0)
                {
                    if (ProcessMask.SetPriorityClass(procHandle, prioSelect))
                    {
                        status += "Priority OK";
                    }
                    else
                    {
                        status += "Priority Failed";
                    }
                }
            }
            else
            {
                status = "Error in PID.";
            }

            lbl_status.Content = status;
        }
    }
}
