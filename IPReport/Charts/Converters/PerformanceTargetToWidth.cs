using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using De.TorstenMandelkow.MetroChart;
using System.Windows;

namespace De.TorstenMandelkow.MetroChart
{
	public class PerformanceTargetToWidth : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			decimal? performanceTarget = values[0] as decimal?;
			double? sumOfDataPointGroup = values[1] as double?;
			double? realWidth = values[2] as double?;

			if (realWidth.HasValue && performanceTarget.HasValue && sumOfDataPointGroup.HasValue)
			{
				double width = realWidth.Value * ((double)(performanceTarget.Value) / sumOfDataPointGroup.Value);
				GridLength gridLength = new GridLength(width, GridUnitType.Pixel);
				

				return gridLength;
			}

			return 0.0;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
