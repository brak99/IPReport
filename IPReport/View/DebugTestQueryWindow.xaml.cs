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
using IPReport.Util;

namespace IPReport.View
{
	/// <summary>
	/// Interaction logic for DebugTestQueryWindow.xaml
	/// </summary>
	public partial class DebugTestQueryWindow : Window
	{
		public DebugTestQueryWindow()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void QueryButton_Click(object sender, RoutedEventArgs e)
		{
			string query = QueryBox.Text;

			IQuickBooksQueryService quickBooksQuery = ServiceContainer.Instance.GetService<IQuickBooksQueryService>();

			string result = quickBooksQuery.Query(query);

			ResultBox.Text = result;
		}
	}
}
