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
			double? realWidth = values[1] as double?;
			PerformanceTargetDataPointGroup performanceTargetDataPointGroup = values[0] as PerformanceTargetDataPointGroup;

			if (realWidth.HasValue && performanceTargetDataPointGroup != null)
			{
				double width = realWidth.Value * (performanceTargetDataPointGroup.ActualPerformance / performanceTargetDataPointGroup.SumOfDataPointGroup);
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