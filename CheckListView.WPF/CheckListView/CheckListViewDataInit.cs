using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CheckListView
{
    public class CheckListViewData
    {
        public string colorName { get; set; }
        public bool colorChkd { get; set; }
        public Brush colorBkgd { get; set; }
    }

    public class CheckListViewDataInit
    {
        public static List<CheckListViewData> checkLists = new List<CheckListViewData>();

        public static int ListDataInit()
        {
            int jumpCount = 0;
            Type type = typeof(Colors);

            PropertyInfo[] pInfo = type.GetProperties();

            foreach (PropertyInfo p in pInfo)
            {
                if (jumpCount > 9)
                {
                    Color color = (Color)ColorConverter.ConvertFromString(p.Name);

                    checkLists.Add(new CheckListViewData()
                    {
                        colorName = p.Name,
                        colorChkd = false,
                        colorBkgd = new SolidColorBrush(color)
                    });

                    if (jumpCount > 25)
                        break;
                }

                jumpCount++;
            }

            return 0;
        }

        public static int ListDataCount()
        {
            return checkLists.Count;
        }
    }
}
