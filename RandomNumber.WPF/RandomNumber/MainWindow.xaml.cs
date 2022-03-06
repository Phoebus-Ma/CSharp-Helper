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

namespace RandomNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random numRand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateNumbers_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            int typeIndex = 0;
            float tempValue = 0;
            string status = "";

            if ((tbox_begin.Text.Length > 0) && (tbox_end.Text.Length > 0))
            {
                int begin_num = Convert.ToInt32(tbox_begin.Text);
                int end_num = Convert.ToInt32(tbox_end.Text);

                if (begin_num < end_num)
                {
                    if (true == rdb_cnt5.IsChecked)
                        count = 5;
                    else if (true == rdb_cnt10.IsChecked)
                        count = 10;
                    else
                        count = 1;

                    if (true == rdb_typeFloat.IsChecked)
                        typeIndex = 1;
                    else if (true == rdb_typeBool.IsChecked)
                        typeIndex = 2;
                    else
                        typeIndex = 0;

                    for (int i = 0; i < count; i++)
                    {
                        tempValue = numRand.Next(begin_num, end_num);

                        switch (typeIndex)
                        {
                            case 0:
                                status += tempValue.ToString();
                                break;

                            case 1:
                                tempValue += numRand.NextSingle();
                                status += tempValue.ToString("n2");
                                break;

                            case 2:
                                if (1 == (tempValue % 2))
                                    status += "False";
                                else
                                    status += "True";
                                break;

                            default:
                                break;
                        }


                        if ((i > 0) && (0 == ((i + 1) % 5)))
                            status += "\n";
                        else if (count > 1)
                            status += "\t";
                    }
                }
                else
                {
                    status = "Error in begin number > end number.";
                }
            }
            else
            {
                status = "Error in number range.";
            }

            tbox_result.Text = status;
        }
    }
}
