using System;
using System.Collections.Generic;
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

namespace UserLineChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool isExit = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserLineChart_StartClick(object sender, RoutedEventArgs e)
        {
            int Value = 0;
            Random random = new Random();
            Point drawPoint = new Point();

            isExit = false;

            m_linechartShow.ClearPoint();

            Task.Run(() =>
            {
                while (!isExit)
                {
                    Value = random.Next(0, 100);

                    drawPoint = new Point(0, Value);

                    m_linechartShow.Dispatcher.Invoke(() =>
                    {
                        m_linechartShow.AddPonit(1, drawPoint, m_linechartShow.Width);
                    });

                    Thread.Sleep(1000);
                }
            });
        }

        private void UserLineChart_StopClick(object sender, RoutedEventArgs e)
        {
            isExit = true;
        }
    }
}
