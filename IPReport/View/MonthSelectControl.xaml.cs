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

namespace IPReport.View
{
	/// <summary>
	/// Interaction logic for MonthSelectControl.xaml
	/// </summary>
	public partial class MonthSelectControl : UserControl
	{
		public DateTime? SelectedDate
		{
			get { return Calendar.SelectedDate; }
			set { Calendar.SelectedDate = value; }
		}

		public MonthSelectControl()
		{
			InitializeComponent();
			DataContext = null;
		}

		private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
		{
			Calendar.SelectedDate = Calendar.DisplayDate;
			Calendar.DisplayMode = CalendarMode.Year;
		}

		private void Calendar_SizeChanged(object sender, SizeChangedEventArgs e)
		{

		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			Calendar.DisplayMode = CalendarMode.Year;
			Calendar.UpdateLayout();
		}

	}
}
