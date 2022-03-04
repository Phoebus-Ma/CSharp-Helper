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
    /// Interaction logic for ScreenTestPage.xaml
    /// </summary>
    public partial class ScreenTestPage : Page
    {
        private int colorIndex = 0;

        public ScreenTestPage()
        {
            InitializeComponent();
        }

        private void ScreenColor_PageInit(object sender, EventArgs e)
        {
            this.KeyDown += KeyDownEvent_CloseWindow;
        }

        private void KeyDownEvent_CloseWindow(object sender, KeyEventArgs e)
        {
            Window window = Window.GetWindow(this);

            window.Close();
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            btn_color.Background = ScreenColors.GetBrushColor(colorIndex);

            colorIndex++;
        }
    }
}
