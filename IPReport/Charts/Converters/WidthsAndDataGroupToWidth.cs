using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace De.TorstenMandelkow.MetroChart
{
	public class WidthsAndDataGroupToWidth : IMultiValueConverter
	{

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			decimal? actualPerformance = values[0] as decimal?;
			double? maxSumOfDataPointGroup = values[1] as double?;
			double? realWidth = values[2] as double?;

			if (realWidth.HasValue && actualPerformance.HasValue && maxSumOfDataPointGroup.HasValue)
			{
				double width = realWidth.Value * ((double)actualPerformance.Value / maxSumOfDataPointGroup.Value);
				return width;
			}

			return 0.0;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}