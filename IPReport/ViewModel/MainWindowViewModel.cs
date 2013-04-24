using System;
using System.Collections.Specialized;
using IPReport.Model;
using IPReport.DataAccess;
using System.Windows;
using IPReport.Util;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;

namespace IPReport.ViewModel
{
	public class MainWindowViewModel : WorkspaceViewModel, IStatusUpdate
	{
        private InventoryViewModel _inventory;
        private SalesDashboardViewModel _sales;

        public MainWindowViewModel()
        {
            ServiceContainer.Instance.AddService<IStatusUpdate>(this);

            _inventory = new InventoryViewModel();
            _sales = SalesDashboardViewModel.GetInstance();

           
        }

        public WorkspaceViewModel Inventory
        {
            get { return _inventory; }
        }

        public WorkspaceViewModel Sales
        {
            get { return _sales; }
        }

        
		public void UpdateStatus(string status)
		{
			WorkingOn = status;
			CommandManager.InvalidateRequerySuggested();
		}

		private string _workingOn;
		public string WorkingOn
		{
			get
			{
				return _workingOn;
			}

			private set
			{
				_workingOn = value;
				OnPropertyChanged("WorkingOn");
			}
		}
	}
}
