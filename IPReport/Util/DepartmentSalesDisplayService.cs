using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.ViewModel;
using IPReport.View;
using System.Windows;

namespace IPReport.Util
{
	public class DepartmentSalesDisplayService : IDepartmentSalesDisplayService
	{
		public void DisplaySales(DepartmentViewModel viewModel)
		{
			DepartmentSalesDisplayView salesDisplay = new DepartmentSalesDisplayView();
			salesDisplay.DataContext = viewModel;
			salesDisplay.Owner = Application.Current.MainWindow;

			salesDisplay.ShowDialog();
		}
	}
}
