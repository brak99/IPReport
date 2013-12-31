using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using IPReport.DataAccess;
using IPReport.Util;

namespace IPReport.View
{
	public class StoreNumberToNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string storeName = "";
			if (value != null)
			{
				string storeNumber = value as string;
				storeName = storeNumber;

				IStoreName storeNameService = ServiceContainer.Instance.GetService<IStoreName>();

				if (storeNameService != null)
				{
					storeName = storeNameService.GetStoreName(Int32.Parse(storeNumber));
				}
			}

			return storeName;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
