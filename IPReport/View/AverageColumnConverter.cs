using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using IPReport.ViewModel;

namespace IPReport.View
{
	public class AverageColumnConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			decimal average = 0.0m;

			if (value != null && parameter != null)
			{
				string propertyName = parameter as string;

				CollectionViewGroup collectionViewGroup = value as CollectionViewGroup;

				decimal total = 0.0m;

				foreach (AssociateSales associateSales in collectionViewGroup.Items)
				{
					switch (propertyName)
					{
						case "HoursWorked":
							total += associateSales.HoursWorked;
							break;
						case "NumberSales":
							total += associateSales.NumberSales;
							break;
						case "TotalSales":
							total += associateSales.TotalSales;
							break;
						case "AveragePerSale":
							total += associateSales.AveragePerSale;
							break;
						case "AverageItemsPerSale":
							total += associateSales.AverageItemsPerSale;
							break;
						case "SalesPerHour":
							total += associateSales.SalesPerHour;
							break;
						case "AveragePricePerItemSold":
							total += associateSales.AveragePricePerItemSold;
							break;
						case "ProfitMargin":
							total += associateSales.ProfitMargin;
							break;
					}
					
				}

				average = total / collectionViewGroup.ItemCount;
			}
			return average;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
