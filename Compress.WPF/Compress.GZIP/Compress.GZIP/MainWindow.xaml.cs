using Microsoft.Win32;
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

namespace Compress.GZIP
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

        private void SelectSourceFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog srcFile = new OpenFileDialog();

            srcFile.Filter = "All file|*.*";

            if (true == srcFile.ShowDialog())
            {
                m_tbsource.Text = srcFile.FileName;
            }
        }

        private void StartCompress_Click(object sender, RoutedEventArgs e)
        {
            if (m_tbsource.Text.Length < 0)
            {
                MessageBox.Show("Source path can not empty.");
                return;
            }

            if (true == m_rbgzip.IsChecked)
            {
                GZipCompress.Compress(m_tbsource.Text);
            }
            else if (true == m_rbungzip.IsChecked)
            {
                GZipCompress.Decompress(m_tbsource.Text);
            }
        }
    }
}
