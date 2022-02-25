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

namespace CheckListView
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
            CheckListViewDataInit.ListDataInit();

            m_checklist.ItemsSource = CheckListViewDataInit.checkLists;
        }

        private void CheckList_RefreshClick(object sender, RoutedEventArgs e)
        {
            string status = "";

            foreach (var item in CheckListViewDataInit.checkLists)
            {
                if (true == item.colorChkd)
                {
                    status += item.colorName + "\n";
                }
            }

            m_checkstatus.Text = status;
        }
    }
}
