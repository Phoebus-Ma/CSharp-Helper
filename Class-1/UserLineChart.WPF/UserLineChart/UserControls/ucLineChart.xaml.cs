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

namespace UserLineChart.UserControls
{
    /// <summary>
    /// Interaction logic for ucLineChart.xaml
    /// </summary>
    public partial class ucLineChart : UserControl
    {
        private const int LineNum = 2;
        private double[] xPos = new double[LineNum];
        private double[] xMove = new double[LineNum];

        public ucLineChart()
        {
            InitializeComponent();
        }

        public int AddPonit(int index, Point drawPoint, double areaWidth)
        {
            if (index < LineNum)
            {
                xPos[index] += 2;
                drawPoint.X = xPos[index];
                xMove[index] = drawPoint.X * (-1) + areaWidth - 2;
                m_ucChartCanvas.Margin = new Thickness(xMove[index], 0, 0, 0);

                if (0 == index)
                {
                    m_ucChartPoly1.Points.Add(drawPoint);

                    if (drawPoint.X > areaWidth)
                        m_ucChartPoly1.Points.RemoveAt(0);
                }
                else
                {
                    m_ucChartPoly2.Points.Add(drawPoint);

                    if (drawPoint.X > areaWidth)
                        m_ucChartPoly1.Points.RemoveAt(0);
                }
            }

            return 0;
        }

        public int ClearPoint()
        {
            if (0 < m_ucChartPoly1.Points.Count)
                m_ucChartPoly1.Points.Clear();

            if (0 < m_ucChartPoly2.Points.Count)
                m_ucChartPoly2.Points.Clear();

            return 0;
        }
    }
}
