using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace DisplayColors
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

        private void WindowLoad(object sender, RoutedEventArgs e)
        {
            InitColorsPanel();
        }

        private static int CreateLabel(Color color, out Label label)
        {
            label = new Label();

            label.Height        = 30;
            label.Width         = 100;
            label.Background    = new SolidColorBrush(color);

            return 0;
        }

        private int InitColorsPanel()
        {
            int i = 0;
            Label label = new Label();

            Type type = typeof(Colors);
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo pInfo in propertyInfos)
            {
                Color color = (Color)ColorConverter.ConvertFromString(pInfo.Name);

                CreateLabel(color, out label);

                label.Content = pInfo.Name;

                this.m_colorPanel.Children.Add(label);

                i++;
            }

            Label lblnum = new Label
            {
                Height = 30,
                Width = 100,
                Content = i
            };

            this.m_colorPanel.Children.Add(lblnum);

            return 0;
        }
    }
}
