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

namespace ScreenTester
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

        private void AutoChangeColor_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ManualChangeColor_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow naviwindow = new NavigationWindow();

            /* Set window source. */
            naviwindow.Source = new Uri("ScreenTestPage.xaml", UriKind.RelativeOrAbsolute);

            /* Set window fullscreen. */
            naviwindow.WindowState  = WindowState.Normal;
            naviwindow.WindowStyle  = WindowStyle.None;
            naviwindow.ResizeMode   = ResizeMode.NoResize;
            naviwindow.Topmost      = true;
            naviwindow.Left         = 0.0;
            naviwindow.Top          = 0.0;
            naviwindow.Width        = SystemParameters.PrimaryScreenWidth;
            naviwindow.Height       = SystemParameters.PrimaryScreenHeight;

            naviwindow.Show();
        }
    }
}
