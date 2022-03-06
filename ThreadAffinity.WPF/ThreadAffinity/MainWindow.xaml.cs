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

namespace ThreadAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process? objProcess = null;

        private List<ThreadPriorityLevel> priorityLevels = new()
        {
            ThreadPriorityLevel.Idle,
            ThreadPriorityLevel.Lowest,
            ThreadPriorityLevel.BelowNormal,
            ThreadPriorityLevel.Normal,
            ThreadPriorityLevel.AboveNormal,
            ThreadPriorityLevel.Highest,
            ThreadPriorityLevel.TimeCritical
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetThrdMask_StartClick(object sender, RoutedEventArgs e)
        {
            string status = "";

            if ((0 < cbox_tid.Text.Length) && ("Null" != cbox_tid.Text))
            {
                if (null != objProcess)
                {
                    int tid = Convert.ToInt32(cbox_tid.Text);
                    int count = objProcess.Threads.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (tid == objProcess.Threads[i].Id)
                        {
                            /* Affinity. */
                            if (tbox_affinity.Text.Length > 0)
                            {
                                int affi = Convert.ToInt32(tbox_affinity.Text);

                                objProcess.Threads[i].ProcessorAffinity = (IntPtr)affi;

                                status += "Affinity OK.";
                            }

                            /* Priority. */
                            if (cbox_priority.Text.Length > 0)
                            {
                                int index = cbox_priority.SelectedIndex;

                                if (index > 0)
                                {
                                    objProcess.Threads[i].PriorityLevel = priorityLevels[index - 1];

                                    status += " Priority OK.";
                                }
                            }

                            break;
                        }
                    }
                }
                else
                {
                    status = "Error in PID.";
                }
            }
            else
            {
                status = "Error in TID.";
            }

            lbl_status.Content = status;
        }

        private void RefreshTID_StartClick(object sender, RoutedEventArgs e)
        {
            string status = "";

            if (0 < tbox_pid.Text.Length)
            {
                int pid = Convert.ToInt32(tbox_pid.Text);

                objProcess = Process.GetProcessById(pid);

                if (objProcess != null)
                {
                    int count = objProcess.Threads.Count;

                    cbox_tid.Items.Clear();

                    for (int i = 0; i < count; i++)
                    {
                        ComboBoxItem boxItem = new ComboBoxItem();

                        boxItem.Content = objProcess.Threads[i].Id;

                        if (0 == i)
                            boxItem.IsSelected = true;
                        
                        cbox_tid.Items.Add(boxItem);
                    }

                    status = "Found Thread.";
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
