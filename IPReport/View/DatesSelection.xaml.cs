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
	/// Interaction logic for DatesSelection.xaml
	/// </summary>
	public partial class DatesSelection : Window
	{
		public DatesSelection()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}
