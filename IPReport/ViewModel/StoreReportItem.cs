using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;

namespace IPReport.ViewModel
{
	public class StoreReportItem
	{
		private Store _store;

		public Store Store
		{
			get { return _store; }
		}

		public string Title { get; set; }
		private double _retailTotal;
		public double RetailTotal
		{
			get { return _retailTotal; }
			private set { _retailTotal = value; }
		}

		protected StoreReportItem(Store store)
		{
			_store = store;
			RetailTotal = 0.0d;
		}

		//public static StoreReportItem GetReportItem(Store store, List<string> departments)
		//{
		//    StoreReportItem reportLine = new StoreReportItem(store);

		//    foreach (string department in departments)
		//    {
		//        double departmentValue = store.RetailValue(department);
		//        reportLine._retailTotal += departmentValue;
		//    }

		//    return reportLine;
		//}

	}
}
