using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using xf.examen.themoviedb.Models;

namespace xf.examen.themoviedb.Converters
{
    public class ArrayToJoinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string returnJoined = string.Empty;
            if (value.GetType() == typeof(List<Productions>))
            {
                var valueConverted = (List<Productions>)value;
                returnJoined = string.Join(", ", valueConverted.Select(x => x.Name));
            }
            else if (value.GetType() == typeof(List<Genre>))
            {
                var valueConverted = (List<Genre>)value;
                returnJoined = string.Join(", ", valueConverted.Select(x => x.Name));
            }

            return returnJoined;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
