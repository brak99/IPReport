
using IPReport.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System;
using System.Xml.Linq;
using IPReport.Util;
namespace IPReport.ViewModel
{
	public class DepartmentGroupViewModel : WorkspaceViewModel
	{
		private DepartmentGroup _departmentGroup;
		public IPReport.Model.DepartmentGroup DepartmentGroup
		{
			get { return _departmentGroup; }
			private set { _departmentGroup = value; }
		}
		private ObservableCollection<DepartmentViewModel> _departments = new ObservableCollection<DepartmentViewModel>();
		public ObservableCollection<DepartmentViewModel> Departments
		{
			get { return _departments; }
			private set { _departments = value; }
		}

		public static DepartmentGroupViewModel GetInstance(DepartmentGroup departmentGroup)
		{
			return new DepartmentGroupViewModel(departmentGroup);
		}

		private DepartmentGroupViewModel(DepartmentGroup departmentGroup)
		{
			_departmentGroup = departmentGroup;

			_totalReceivedForMonth = 0.0M;
			_totalReceivedForMonthRetail = 0.0M;
			_totalTransferredInForMonth = 0.0M;
			_totalTransferredOutForMonth = 0.0M;
			_salesForMonth = 0.0M;
			_discountForMonth = 0.0M;
			_retailValue = 0.0M;
            _inventoryAdjustment = 0.0m;

			_departments.CollectionChanged += OnDepartmentsChanged;
		}

		private decimal _retailValue;
		public decimal RetailValue
		{
			get { return _retailValue; }
			set { _retailValue = value; }
		}
		private decimal _totalReceivedForMonth;
		public decimal TotalReceivedForMonth
		{
			get { return _totalReceivedForMonth; }
			private set { _totalReceivedForMonth = value; }
		}
		private decimal _totalReceivedForMonthRetail;
		public decimal TotalReceivedForMonthRetail
		{
			get { return _totalReceivedForMonthRetail; }
			private set { _totalReceivedForMonthRetail = value; }
		}
		private decimal _totalTransferredInForMonth;
		public decimal TotalTransferredInForMonth
		{
			get { return _totalTransferredInForMonth; }
			private set { _totalTransferredInForMonth = value; }
		}
		private decimal _totalTransferredOutForMonth;
		public decimal TotalTransferredOutForMonth
		{
			get { return _totalTransferredOutForMonth; }
			private set { _totalTransferredOutForMonth = value; }
		}
		private decimal _salesForMonth;
		public decimal SalesForMonth
		{
			get { return _salesForMonth; }
			private set { _salesForMonth = value; }
		}
		private decimal _discountForMonth;
		public decimal DiscountForMonth
		{
			get { return _discountForMonth; }
			private set { _discountForMonth = value; }
		}
		private decimal _markupsForMonth;
		public decimal MarkupsForMonth
		{
			get { return _markupsForMonth; }
			private set { _markupsForMonth = value; }
		}
        private decimal _inventoryAdjustment;
        public decimal InventoryAdjustment
        {
            get { return _inventoryAdjustment; }
            private set { _inventoryAdjustment = value; }
        }
		public override string DisplayName
		{
			get { return _departmentGroup.Name; }
		}
		public string Name
		{
			get { return _departmentGroup.Name; }
			set 
			{ 
				_departmentGroup.Name = value;
				base.OnPropertyChanged("DisplayName");
			}
		}
		public bool ReadOnly
		{
			get
			{
				return _departmentGroup.ReadOnly;
			}
		}
		protected void OnDepartmentsChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (args.NewItems != null && args.NewItems.Count > 0)
			{
				foreach (DepartmentViewModel department in args.NewItems)
				{
					RetailValue += department.RetailValue;
					TotalReceivedForMonth += department.TotalReceivedForMonth;
					TotalReceivedForMonthRetail += department.TotalReceivedForMonthRetail;
					TotalTransferredInForMonth += department.TotalTransferredInForMonth;
					TotalTransferredOutForMonth += department.TotalTransferredOutForMonth;
					SalesForMonth += department.SalesForMonth;
					DiscountForMonth += department.DiscountForMonth;
					MarkupsForMonth += department.MarkupsForMonth;
				}
			}
		}

		public void AddDepartment(string departmentCode)
		{
			_departmentGroup.Departments.Add(departmentCode);
		}
		public void RemoveDepartment(string departmentCode)
		{
			_departmentGroup.Departments.Remove(departmentCode);
		}

		public void ForceAddDepartment(DepartmentViewModel department)
		{
			Departments.Add(department);
		}

		public bool TryAddDepartment(DepartmentViewModel department)
		{
			bool departmentAdded = false;

			if (DepartmentBelongs(department))
			{
				Departments.Add(department);

				departmentAdded = true;
			}

			return departmentAdded;
		}

		private bool DepartmentBelongs(DepartmentViewModel department)
		{
			bool departmentBelongs = false;

			foreach (string departmentId in _departmentGroup.Departments)
			{
				if (String.Compare(departmentId, department.Code, StringComparison.OrdinalIgnoreCase) == 0)
				{
					departmentBelongs = true;
				}
			}
			return departmentBelongs;
		}

		public XElement ToXml()
		{
			XElement department = new XElement("DepartmentGroup");
			XElement name = new XElement("Name", DisplayName);
			XElement sales = new XElement("SALES", SalesForMonth);
			XElement mkdns = new XElement("MKDNS", DiscountForMonth);
			XElement mkups = new XElement("MKUPS", MarkupsForMonth);
			XElement phyinv = new XElement("PHY_INV", RetailValue);
			XElement reccst = new XElement("REC_CST", TotalReceivedForMonth);
			XElement recret = new XElement("REC_RET", TotalReceivedForMonthRetail);
			XElement trin = new XElement("TR_IN", TotalTransferredInForMonth);
			XElement trout = new XElement("TR_OUT", TotalTransferredOutForMonth);

			department.Add(name);
			department.Add(sales);
			department.Add(mkdns);
			department.Add(mkups);
			department.Add(phyinv);
			department.Add(reccst);
			department.Add(recret);
			department.Add(trin);
			department.Add(trout);

			return department;
		}

		public string ToCsv()
		{
			string csv = DisplayName;
			csv += "," + SalesForMonth;
			csv += "," + DiscountForMonth;
			csv += "," + RetailValue;
			csv += "," + TotalReceivedForMonth;
			csv += "," + TotalReceivedForMonthRetail;
			csv += "," + TotalTransferredInForMonth;
			csv += "," + TotalTransferredOutForMonth;

			return csv;
		}

		public string ToOTB(string store)
		{
			IDateService dateService = ServiceContainer.Instance.GetService<IDateService>();
			DateTime reportDate = dateService.DateForReport();

			string otb = "\"EC142\"" + " ";
			otb += DisplayName + " ";
			otb += store + " ";
			otb += reportDate.ToString("yyMM") + " ";  //TODO Check format
			otb += DiscountForMonth + " ";
            otb += InventoryAdjustment + " ";
			otb += RetailValue + " ";
			otb += "0" + " ";
			otb += "0" + " ";
			otb += TotalReceivedForMonth + " ";
			otb += TotalReceivedForMonthRetail + " ";
			otb += SalesForMonth + " ";
			otb += TotalTransferredOutForMonth + " ";
			otb += TotalTransferredInForMonth + " ";
			//vendor returns retail
			//vendor return cost
            otb += "Quickbooks" + " ";
			otb += DateTime.Now.ToString("MM/dd/yy") + " ";
			otb += "IPReport" + " ";
			otb += "IPReport" + " ";
			otb += DateTime.Now.ToString("MM/dd/yy") + " ";
			otb += "0" + " ";
			otb += "100" + " "; //represents the department code
			otb += "1" + " ";

			return otb;
		}
	}
}
