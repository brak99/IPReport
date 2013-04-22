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
			//try
			//{
			//    if (e.Key == Key.Enter)
			//{	
			//        e.Handled = true;
			//        DataGrid dataGrid = sender as DataGrid;

			//        int cellColumn = dataGrid.CurrentCell.Column.DisplayIndex;
			//        dataGrid.CurrentCell = dataGrid.Ite
			//        DataGridColumn leftmostColumn = dataGrid.ColumnFromDisplayIndex(0);
			//        dataGrid.
			//        //var cell = GetCell(dgIssuance, dgIssuance.Items.Count - 1, 2);
			//        //if (cell != null)
			//        //{
			//        //    cell.IsSelected = true;
			//        //    cell.Focus();
			//        //    dg.BeginEdit();
			//        //}
			//    }
			//}
			//catch (Exception ex)
			//{
			//    //MessageBox(ex.Message, "Error", MessageType.Error);
			//}
		}

	}
}
