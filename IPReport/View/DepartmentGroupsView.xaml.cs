using System.Windows.Controls;
using System.Windows.Input;
using IPReport.Util;
using IPReport.ViewModel;
using System.Windows;

namespace IPReport.View
{
	/// <summary>
	/// Interaction logic for DepartmentGroupsView.xaml
	/// </summary>
	public partial class DepartmentGroupsView : UserControl
	{
		public DepartmentGroupsView()
		{
			InitializeComponent();
		}

		private void DepartmentGroupDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ListViewItem item = sender as ListViewItem;

			DepartmentGroupViewModel viewModel = item.Content as DepartmentGroupViewModel;

			IDepartmentGroupSalesDisplayService salesDisplay = ServiceContainer.Instance.GetService<IDepartmentGroupSalesDisplayService>();

			salesDisplay.ShowDepartmentSales(viewModel);
		}
	}
}
