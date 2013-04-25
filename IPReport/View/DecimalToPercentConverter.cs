using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace IPReport.View
{
	public class DecimalToPercentConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			decimal decimalPercentage = (decimal)value;
			return decimalPercentage * 100.0m;
		}

		public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			decimal percentage = System.Convert.ToDecimal(value);
			return percentage / 100.0m;
		}
	}
}
