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

namespace MultiLanguage
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

        private void Btn_GetTimeClick(object sender, RoutedEventArgs e)
        {
            m_tbtime.Text = System.DateTime.Now.ToString();
        }

        private void Menu_SwitchLanguage(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;

            if (mi.Name.Equals("m_langchinese"))
            {
                App.Culture = "Chinese";
            }
            else if (mi.Name.Equals("m_langrussian"))
            {
                App.Culture = "Russian";
            }
            else if (mi.Name.Equals("m_langfrench"))
            {
                App.Culture = "French";
            }
            else if (mi.Name.Equals("m_langspanish"))
            {
                App.Culture = "Spanish";
            }
            else if (mi.Name.Equals("m_langarabic"))
            {
                App.Culture = "Arabic";
            }
            else
            {
                App.Culture = "";
            }

            //update culture
            App.UpdateCulture();
        }
    }
}
