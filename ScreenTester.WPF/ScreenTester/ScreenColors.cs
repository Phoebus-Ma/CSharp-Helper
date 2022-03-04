using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ScreenTester
{
    internal class ScreenColors
    {
        private static List<Color> backColor = new()
        {
            Colors.Red,
            Colors.Orange,
            Colors.Yellow,
            Colors.Green,
            Colors.DeepSkyBlue,
            Colors.Blue,
            Colors.Indigo,
            Colors.Gray,
            Colors.White,
            Colors.Black,
        };

        public static SolidColorBrush GetBrushColor(int index)
        {
            SolidColorBrush solidcolor = new SolidColorBrush(backColor[index % backColor.Count]);

            return solidcolor;
        }
    }
}
