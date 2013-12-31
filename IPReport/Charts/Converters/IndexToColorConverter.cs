using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;
using System.Windows;
using System.Windows.Data;

namespace IPReport.Charts.Converters
{
	public class IndexToColorConverter : IValueConverter
	{
		public Type KeyType { get; set; }

        /// <summary>
        /// Store the key-value pairs for the conversion
        /// </summary>
        public Dictionary<object, object> Values { get; set; }

		public IndexToColorConverter()
        {
            Values = new Dictionary<object, object>();
        }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (KeyType == null)
			{
				KeyType = Values.Keys.First().GetType();
			}

			int index = Int32.Parse(value.ToString());

			if (Values.ContainsKey(value.ToString()))
			{
				return Values[value.ToString()];
			}

			return new SolidColorBrush(Colors.Black);
		}

		public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
