using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.ViewModel;
using IPReport.View;
using System.Windows;

namespace IPReport.Util
{
	public class DepartmentGroupSalesDisplayService : IDepartmentGroupSalesDisplayService
	{
		public void ShowDepartmentSales(DepartmentGroupViewModel viewModel)
		{
			DepartmentGroupSalesView salesDisplay = new DepartmentGroupSalesView();
			salesDisplay.DataContext = viewModel;
			salesDisplay.Owner = Application.Current.MainWindow;

			salesDisplay.ShowDialog();
		}
	}
}
