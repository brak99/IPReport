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
			double? realWidth = values[1] as double?;
			PerformanceTargetDataPointGroup performanceTargetDataPointGroup = values[0] as PerformanceTargetDataPointGroup;

			if (realWidth.HasValue && performanceTargetDataPointGroup != null)
			{
				double width = realWidth.Value * (performanceTargetDataPointGroup.PerformanceTarget / performanceTargetDataPointGroup.SumOfDataPointGroup);
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
