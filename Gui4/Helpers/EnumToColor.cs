using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Gui4.Helpers
{
    public class EnumToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            KarmaEnum karma = (KarmaEnum)value;
            switch (karma)
            {
                case KarmaEnum.Good:
                    return Brushes.LightGreen;
                    
                case KarmaEnum.Bad:
                    return Brushes.LightPink ;
                case KarmaEnum.Neutral:
                    return Brushes.LightYellow;
                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
