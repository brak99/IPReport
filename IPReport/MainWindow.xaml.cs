using System.Windows;
using System.Xml;
using Interop.QBPOSXMLRPLIB;
using System.Collections.Generic;
using System.Text;
using System;
using System.Windows.Input;
using IPReport.ViewModel;
using IPReport.Util;
using IPReport.DataAccess;
using IPReport.Model;
using IPReport.View;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace IPReport
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : ISaveFilePath
	{
		public RequestProcessor requestProcessor = null;

		private ICommand _connectCommand;
		public ICommand ConnectCommand
		{
			get
			{
				if (_connectCommand == null)
				{
					_connectCommand = new DelegateCommand<object>(param => this.ConnectClick(param, null));
				}

				return _connectCommand;
			}
		}

		private void ConnectClick(object sender, RoutedEventArgs e)
		{
			ServiceContainer.Instance.AddService<IRetailCost>(new InventoryRepository());
			ServiceContainer.Instance.AddService<IItemDepartmentService>(new ItemDepartmentRepository());

			//((MainWindowViewModel)DataContext).UpdateAll();
		}


		private ICommand _debugConnectCommand;
		public ICommand DebugConnectCommand
		{
			get
			{
				if (_debugConnectCommand == null)
				{
					_debugConnectCommand = new DelegateCommand<object>(param => this.DebugConnectClick(param, null));
				}

				return _debugConnectCommand;
			}
		}


		private void DebugConnectClick(object sender, RoutedEventArgs e)
		{
			ServiceContainer.Instance.AddService<IQuickBooksQueryService>(new FakeQBQueryService());
			ServiceContainer.Instance.AddService<IDateService>(new FakeDateService());
			ServiceContainer.Instance.AddService<IRetailCost>(new InventoryRepository());
			ServiceContainer.Instance.AddService<IItemDepartmentService>(new ItemDepartmentRepository());

			MainWindowViewModel vm = DataContext as MainWindowViewModel;
			//vm.UpdateAll();
		}

		private ICommand _reportDateCommand;
		public ICommand ReportDateCommand
		{
			get
			{
				if (_reportDateCommand == null)
				{
					_reportDateCommand = new DelegateCommand<object>(param => this.ReportDateClick(param, null));
				}

				return _reportDateCommand;
			}
		}

		private void ReportDateClick(object sender, RoutedEventArgs e)
		{
			IDateService dateService = ServiceContainer.Instance.GetService<IDateService>();

			DateSelection dateSelection = new DateSelection();
			dateSelection.Owner = this;

			dateSelection.datePicker1.DisplayDate = dateService.DateForReport();
			dateSelection.datePicker1.SelectedDate = dateService.DateForReport();

			dateSelection.ShowDialog();

			if (dateSelection.DialogResult == true)
			{
				dateService.SetDateForReport((DateTime)dateSelection.datePicker1.SelectedDate);
			}
		}


		private ICommand _queryTestCommand;
		public ICommand QueryTestCommand
		{
			get
			{
				if (_queryTestCommand == null)
				{
					_queryTestCommand = new DelegateCommand<object>(param => this.QueryTest(param, null));
				}

				return _queryTestCommand;
			}
		}

		private void QueryTest(object sender, RoutedEventArgs e)
		{
			DebugTestQueryWindow window = new DebugTestQueryWindow();

			window.ShowDialog();
		}

		

		public MainWindow()
		{
			InitializeComponent();

			DataContext = new MainWindowViewModel();

			ServiceContainer.Instance.AddService<IQuickBooksQueryService>(new QuickBooksQuery());
			ServiceContainer.Instance.AddService<ISaveFilePath>(this);
			ServiceContainer.Instance.AddService<IDateService>(new ReportDateService());
		}

		~MainWindow()
		{
			StoreRepository.Instance.SaveStores();
			DepartmentGroupsRepository.Instance.SaveDepartmentGroups();
		}

		public string SaveFilePath(string filter, string title)
		{
			string path = "";

			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = filter;
			saveDialog.Title = title;

			saveDialog.ShowDialog();

			path = saveDialog.FileName;

			return path;
		}
	}
}
