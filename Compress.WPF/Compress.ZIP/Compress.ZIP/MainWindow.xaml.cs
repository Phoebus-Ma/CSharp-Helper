using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Compress.ZIP
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

        private void SelectSourceFolder_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Directory|*.this.directory";
            saveFileDialog.FileName = "select";


            saveFileDialog.ShowDialog();

            string path = saveFileDialog.FileName;

            path = path.Replace("\\select.this.directory", "");
            path = path.Replace(".this.directory", "");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            m_tbsource.Text = path;
        }

        private void SelectSourceFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog srcFile = new OpenFileDialog();

            srcFile.Filter = "All files|*.*";

            if (true == srcFile.ShowDialog())
            {
                m_tbsource.Text = srcFile.FileName;
            }
        }

        private void SelectDestFoler_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Directory|*.this.directory";
            saveFileDialog.FileName = "select";


            saveFileDialog.ShowDialog();

            string path = saveFileDialog.FileName;

            path = path.Replace("\\select.this.directory", "");
            path = path.Replace(".this.directory", "");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            m_tbdest.Text = path;
        }

        private void SelectDestFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog srcFile = new OpenFileDialog();

            srcFile.Filter = "App|*.zip|All files|*.*";

            if (true == srcFile.ShowDialog())
            {
                m_tbdest.Text = srcFile.FileName;
            }
        }

        private void StartCompress_Click(object sender, RoutedEventArgs e)
        {
            if (m_tbsource.Text.Length < 0)
            {
                MessageBox.Show("Source path can not empty.");
                return;
            }

            if (m_tbdest.Text.Length < 0)
            {
                MessageBox.Show("Destination path can not empty.");
                return;
            }

            if (true == m_rbzip.IsChecked)
            {
                ZipCompress.Compress();
            }
            else if (true == m_rbunzip.IsChecked)
            {
                ZipCompress.DecompressFile();
            }
            else if (true == m_rbadd.IsChecked)
            {
                ZipCompress.AddfileToZip();
            }
        }
    }
}
