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
	/// Interaction logic for MonthSelect.xaml
	/// </summary>
	public partial class MonthSelect : Window
	{
		public MonthSelect()
		{
			InitializeComponent();
		}

		private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
		{
			Calendar.SelectedDate = Calendar.DisplayDate;
			Calendar.DisplayMode = CalendarMode.Year;
		}
	}
}
