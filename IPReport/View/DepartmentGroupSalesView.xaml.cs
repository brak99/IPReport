using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IPReport.ViewModel;
using IPReport.Util;

namespace IPReport.View
{
	/// <summary>
	/// Interaction logic for DepartmentGroupSalesView.xaml
	/// </summary>
	public partial class DepartmentGroupSalesView : Window
	{
		public DepartmentGroupSalesView()
		{
			InitializeComponent();
		}

		private void DepartmentGroupDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ListViewItem item = sender as ListViewItem;

			DepartmentViewModel viewModel = item.Content as DepartmentViewModel;

			IDepartmentSalesDisplayService salesDisplay = ServiceContainer.Instance.GetService<IDepartmentSalesDisplayService>();

			salesDisplay.DisplaySales(viewModel);
		}
	}
}
