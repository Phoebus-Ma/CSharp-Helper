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
using System.Windows.Threading;

namespace AudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer   = new DispatcherTimer();
            timer.Interval          = TimeSpan.FromSeconds(1);
            timer.Tick              += display_tick;
            timer.Start();
        }

        void display_tick(object sender, EventArgs e)
        {
            if (null != mediaPlayer.Source)
            {
                m_lbltime.Content = String.Format("{0} / {1}",
                    mediaPlayer.Position.ToString(@"mm\:ss"),
                    mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));

                m_sldProgress.Value = mediaPlayer.Position.TotalSeconds
                    * 100 / mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            }
            else
            {
                m_lbltime.Content = "";
            }
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                m_audioPath.Text = openFileDialog.FileName;
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}
