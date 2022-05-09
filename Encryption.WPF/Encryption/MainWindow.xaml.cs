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
using System.Security.Cryptography;

namespace Encryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DES DESalg = DES.Create();
        private static Aes AESalg = Aes.Create();

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
            string destData = "";
            var index = m_cbEncrypt.SelectedIndex;

            switch (index)
            {
                case 0: // MD5
                    if (true == m_rbEncrypt.IsChecked)
                    {
                        MD5Encrypt.Generate(m_EncryptSrc.Text, out destData);

                        m_EncryptDest.Text = destData;
                    }
                    else if (true == m_rbDecrypt.IsChecked)
                    {
                        m_rbEncrypt.IsChecked = true;

                        MessageBox.Show("MD5 does not support decryption.");
                    }
                    else if (true == m_rbCompare.IsChecked)
                    {
                        int isSame = MD5Encrypt.Compare(m_EncryptSrc.Text, m_EncryptDest.Text);

                        MessageBox.Show("Compare Result: " + (0 == isSame).ToString());
                    }
                    break;

                case 1: // SHA1
                case 2: // SHA256
                case 3: // SHA384
                case 4: // SHA512
                    if (true == m_rbEncrypt.IsChecked)
                    {
                        SHAEncrypt.Generate(index, m_EncryptSrc.Text, out destData);

                        m_EncryptDest.Text = destData;
                    }
                    else if (true == m_rbDecrypt.IsChecked)
                    {
                        m_rbEncrypt.IsChecked = true;

                        MessageBox.Show("SHA does not support decryption.");
                    }
                    else if (true == m_rbCompare.IsChecked)
                    {
                        int isSame = SHAEncrypt.Compare(index, m_EncryptSrc.Text, m_EncryptDest.Text);

                        MessageBox.Show("Compare Result: " + (0 == isSame).ToString());
                    }
                    break;

                case 5: // DES
                    if (true == m_rbEncrypt.IsChecked)
                    {
                        DESEncrypt.Generate(m_EncryptSrc.Text, DESalg.Key, DESalg.IV, out destData);

                        m_EncryptDest.Text = destData;
                    }
                    else if (true == m_rbDecrypt.IsChecked)
                    {
                        DESEncrypt.Parse(m_EncryptSrc.Text, DESalg.Key, DESalg.IV, out destData);

                        m_EncryptDest.Text = destData;
                    }
                    else if (true == m_rbCompare.IsChecked)
                    {
                        int isSame = DESEncrypt.Compare(m_EncryptSrc.Text, DESalg.Key, DESalg.IV, m_EncryptDest.Text);

                        MessageBox.Show("Compare Result: " + (0 == isSame).ToString());
                    }
                    break;

                case 6: // AES
                    if (true == m_rbEncrypt.IsChecked)
                    {
                        AESEncrypt.Generate(m_EncryptSrc.Text, AESalg.Key, AESalg.IV, out destData);

                        m_EncryptDest.Text = destData;
                    }
                    else if (true == m_rbDecrypt.IsChecked)
                    {
                        AESEncrypt.Parse(m_EncryptSrc.Text, AESalg.Key, AESalg.IV, out destData);

                        m_EncryptDest.Text = destData;
                    }
                    else if (true == m_rbCompare.IsChecked)
                    {
                        int isSame = AESEncrypt.Compare(m_EncryptSrc.Text, AESalg.Key, AESalg.IV, m_EncryptDest.Text);

                        MessageBox.Show("Compare Result: " + (0 == isSame).ToString());
                    }
                    break;

                default:
                    break;
            }

        }
    }
}
