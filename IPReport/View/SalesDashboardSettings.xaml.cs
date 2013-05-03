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

namespace IPReport.View
{
	/// <summary>
	/// Interaction logic for SalesDashboardSettings.xaml
	/// </summary>
	public partial class SalesDashboardSettings : Window
	{
		public SalesDashboardSettings()
		{
			InitializeComponent();
		}

		private void OK_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				DataGrid dataGrid = sender as DataGrid;

				if (e.Key == Key.Enter)
				{
					if (dataGrid.CurrentCell.Column.DisplayIndex == 1)
					{
						dataGrid.CurrentCell = new DataGridCellInfo(dataGrid.Items[dataGrid.Items.Count-1], dataGrid.Columns[0]);
						e.Handled = true;
					}
				}
			}
			catch (System.Exception ex)
			{
				
			}
		}
	}
}
