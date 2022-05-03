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

namespace Encryption
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

        private void ClearContent_Click(object sender, RoutedEventArgs e)
        {
            m_EncryptSrc.Text = "";
            m_EncryptDest.Text = "";
        }

        private void StartEncryption_Click(object sender, RoutedEventArgs e)
        {
            string encryptData = "";
            var index = m_cbEncrypt.SelectedIndex;

            switch (index)
            {
                /* MD5. */
                case 0:
                    if (true == m_rbEncrypt.IsChecked)
                    {
                        MD5Encrypt.MD5Generate(m_EncryptSrc.Text, out encryptData);

                        m_EncryptDest.Text = encryptData;
                    }
                    else if (true == m_rbDecrypt.IsChecked)
                    {
                        m_rbEncrypt.IsChecked = true;

                        MessageBox.Show("MD5 does not support decryption.");
                    }
                    else if (true == m_rbCompare.IsChecked)
                    {
                        int isSame = MD5Encrypt.MD5Compare(m_EncryptSrc.Text, m_EncryptDest.Text);

                        MessageBox.Show("Compare Result: " + (0 == isSame).ToString());
                    }
                    break;

                case 1: // SHA1
                case 2: // SHA256
                case 3: // SHA384
                case 4: // SHA512
                    if (true == m_rbEncrypt.IsChecked)
                    {
                        SHAEncryption.SHAGenerate(index, m_EncryptSrc.Text, out encryptData);

                        m_EncryptDest.Text = encryptData;
                    }
                    else if (true == m_rbDecrypt.IsChecked)
                    {
                        m_rbEncrypt.IsChecked = true;

                        MessageBox.Show("SHA does not support decryption.");
                    }
                    else if (true == m_rbCompare.IsChecked)
                    {
                        int isSame = SHAEncryption.SHACompare(index, m_EncryptSrc.Text, m_EncryptDest.Text);

                        MessageBox.Show("Compare Result: " + (0 == isSame).ToString());
                    }
                    break;

                default:
                    break;
            }

        }
    }
}
