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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IPReport.ViewModel;

namespace IPReport.View
{
    /// <summary>
    /// Interaction logic for SalesDashboardView.xaml
    /// </summary>
    public partial class SalesDashboardView : UserControl
    {
        public SalesDashboardView()
        {
            InitializeComponent();
        }
		
		private void MonthToggleButton_Click(object sender, RoutedEventArgs e)
		{
			MonthSelect dialog = new MonthSelect();
			//dialog.DataContext = DataContext;
			dialog.Calendar.SelectedDate = ((SalesDashboardViewModel)DataContext).StartDate;
			dialog.ShowDialog();
			((SalesDashboardViewModel)DataContext).StartDate = dialog.Calendar.SelectedDate.Value;
		}

		private void MonthSelectControl_LostFocus(object sender, RoutedEventArgs e)
		{
			((SalesDashboardViewModel)DataContext).StartDate = MonthSelect.SelectedDate.Value;
		}
    }
}
