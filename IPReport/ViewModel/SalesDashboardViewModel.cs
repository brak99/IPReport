using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using IPReport.DataAccess;
using System.Xml;
using IPReport.Model;
using IPReport.Util;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.ObjectModel;
using IPReport.Charts.ViewModel;

namespace IPReport.ViewModel
{
    public class SalesChartData
    {
        public string Category { get; set; }
        public decimal Number { get; set; }
    }
    public class SeriesData
    {
        public SeriesData()
        {
            Items = new ObservableCollection<SalesChartData>();
        }

        public string DisplayName { get; set; }

        public string Description { get; set; }

		public ObservableCollection<SalesChartData> Items { get; set; }
    }

	
    public class AssociateSales : INotifyPropertyChanged
    {
        private string _salesAssociate;
        public string SalesAssociate
        {
            get { return _salesAssociate; }
            set { 
                _salesAssociate = value;
                OnPropertyChanged("SalesAssociate");
            }
        }
        private decimal _hoursWorked;
        public decimal HoursWorked
        {
            get { return _hoursWorked; }
            set { _hoursWorked = value;
            OnPropertyChanged("HoursWorked");
            }
        }
        private int _numberSales;
        public int NumberSales
        {
            get { return _numberSales; }
            set { _numberSales = value;
            OnPropertyChanged("NumberSales");
            }
        }
        private decimal _totalSales;
        public decimal TotalSales
        {
            get { return _totalSales; }
            set { _totalSales = value;
            OnPropertyChanged("TotalSales");
            }
        }
        private decimal _totalCost;
        public decimal TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value;
            OnPropertyChanged("TotalCost");
            }
        }
        private decimal _averagePerSale;
        public decimal AveragePerSale
        {
            get { return _averagePerSale; }
            set { _averagePerSale = value;
            OnPropertyChanged("AveragePerSale");
            }
        }
        private int _totalItems;
        public int TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value;
            OnPropertyChanged("TotalItems");
            }
        }
        private decimal _averageItemsPerSale;
        public decimal AverageItemsPerSale
        {
            get { return _averageItemsPerSale; }
            set { _averageItemsPerSale = value;
            OnPropertyChanged("AverageItemsPerSale");
            }
        }
        private decimal _salesPerHour;
        public decimal SalesPerHour
        {
            get { return _salesPerHour; }
            set { _salesPerHour = value;
            OnPropertyChanged("SalesPerHour");
            }
        }
        private decimal _profitMargin;
        public decimal ProfitMargin
        {
            get { return _profitMargin; }
            set { _profitMargin = value;
            OnPropertyChanged("ProfitMargin");
            }
        }
		private decimal _averagePricePerItemSold;
		public decimal AveragePricePerItemSold
		{
			get { return _averagePricePerItemSold; }
			set { _averagePricePerItemSold = value;
			OnPropertyChanged("AveragePricePerItemSold");
			}
		}
        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
    }

	public class ItemSold
	{
		public int Quantity { get; set; }
		public string Desc1 { get; set; }
		public string Desc2 { get; set; }
		public string Id { get; set; }
	}
    // Sales Associate        Hours Worked       # of sales       % of total store sales       Total Sales $     Avg $ per sale      Avg Items Per Sale     Sales per hour     margin %
    public class SalesDashboardViewModel : WorkspaceViewModel, IReportMonth
    {
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set 
			{ 
				_startDate = value;
				OnPropertyChanged("StartDate");
				//UpdateRevenueTarget();
			}
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set 
			{ 
				_endDate = value;
				OnPropertyChanged("EndDate");
				//UpdateRevenueTarget();
			}
        }

		private int _reportMonth;
		public int ReportMonth
		{
			get { return _reportMonth; }
			set 
			{ 
				_reportMonth = value;
				UpdateStartAndEndDates();
			}
		}

		public int GetReportMonth()
		{
			return ReportMonth;
		}

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new DelegateCommand<object>(param => this.Update(param, null));
                }

                return _updateCommand;
           
            }
        }

		private ICommand _settingsCommand;
		public ICommand SettingsCommand
		{
			get
			{
				if (_settingsCommand == null)
				{
					_settingsCommand = new DelegateCommand<object>(param => this.Settings(param, null));
				}

				return _settingsCommand;

			}
		}

		private ICommand _nextMonthCommand;
		public ICommand NextMonthCommand
		{
			get
			{
				if (_nextMonthCommand == null)
				{
					_nextMonthCommand = new DelegateCommand<object>(param => this.NextMonth(param, null));
				}

				return _nextMonthCommand;

			}
		}

		private ICommand _previousMonthCommand;
		public ICommand PreviousMonthCommand
		{
			get
			{
				if (_previousMonthCommand == null)
				{
					_previousMonthCommand = new DelegateCommand<object>(param => this.PreviousMonth(param, null));
				}

				return _previousMonthCommand;

			}
		}

		private SalesDashboardSettingsViewModel _settings = SalesDashboardSettingsViewModel.GetInstance();

		private PerformanceTargetViewModel _monthlyRevenuePerformance = PerformanceTargetViewModel.GetInstance();
		public PerformanceTargetViewModel MonthlyRevenuePerformance
		{
			get
			{
				return _monthlyRevenuePerformance;
			}
		}

		public GroupedSeriesViewModel _salesAssociatePerformance = GroupedSeriesViewModel.GetInstance();
		public GroupedSeriesViewModel SalesAssociatePerformance
		{
			get
			{
				return _salesAssociatePerformance;
			}
		}

		private PerformanceTargetViewModel _salesAssociateTargetPerformance = PerformanceTargetViewModel.GetInstance();
		public IPReport.ViewModel.PerformanceTargetViewModel SalesAssociateTargetPerformance
		{
			get { return _salesAssociateTargetPerformance; }
		}

		public ObservableCollection<AssociateSales> AssociateSales
        {
            get
            {
                return _associateSales;
            }
        }

		protected Dictionary<string, ItemSold> _itemsSold = new Dictionary<string, ItemSold>();

		protected ObservableCollection<ItemSold> _topItemsSold = new ObservableCollection<ItemSold>();
		public ObservableCollection<ItemSold> TopItemsSold
		{
			get { return _topItemsSold; }
		}
        protected List<SalesReceipt> _salesReceipts = new List<SalesReceipt>();
        protected List<TimeEntry> _timeEntries = new List<TimeEntry>();
        protected ObservableCollection<AssociateSales> _associateSales = new ObservableCollection<AssociateSales>();

        public static SalesDashboardViewModel GetInstance()
        {
            return new SalesDashboardViewModel();
        }

        protected SalesDashboardViewModel()
        {
			ReportMonth = DateTime.Now.Month;
			ServiceContainer.Instance.AddService<IReportMonth>(this);

			UpdateStartAndEndDates();

            PopulateChartData();
			
        }

		private void NextMonth(object sender, RoutedEventArgs args)
		{
			StartDate = StartDate.Value.AddMonths(1);
			EndDate = DateUtil.LastDayOfMonthFromDateTime(StartDate.Value);
			Update(null, null);
		}

		private void PreviousMonth(object sender, RoutedEventArgs args)
		{
			StartDate = StartDate.Value.AddMonths(-1);
			EndDate = DateUtil.LastDayOfMonthFromDateTime(StartDate.Value);
			Update(null, null);
		}

		private void UpdateStartAndEndDates()
		{
			StartDate = new DateTime(DateTime.Now.Year, ReportMonth, 1);
			EndDate = DateUtil.LastDayOfMonthFromDateTime(StartDate.Value);
		}
        public void Update(object sender, RoutedEventArgs args)
        {
            if (StartDate.HasValue && EndDate.HasValue)
            {
				ZeroOut();
                PopulateSales();
                PopulateTime();
                PopulateAverages();
                PopulateChartData();
            }
        }

		private decimal TotalHoursForTheMonth()
		{
			ObservableCollection<MonthlyHours> monthHours = _settings.MonthHours;

			decimal totalHours = 0.0m;

			if (monthHours != null)
			{
				foreach (MonthlyHours monthlyHours in monthHours)
				{
					totalHours += monthlyHours.Hours;
				}

			}
			
			return totalHours;
		}

        private void PopulateChartData()
        {
			MonthlyRevenuePerformance.Clear();
			MonthlyRevenuePerformance.GoodPerformance = (double)_settings.GoodPerformance;
			MonthlyRevenuePerformance.SatisfactoryPerformance = (double)_settings.SatisfactoryPerformance;
			MonthlyRevenuePerformance.PoorPerformance = (double)_settings.PoorPerformance;

			SalesAssociateTargetPerformance.Clear();

			SalesAssociateTargetPerformance.GoodPerformance = (double)_settings.GoodPerformance;
			SalesAssociateTargetPerformance.SatisfactoryPerformance = (double)_settings.SatisfactoryPerformance;
			SalesAssociateTargetPerformance.PoorPerformance = (double)_settings.PoorPerformance;

			_salesAssociatePerformance.Series.Clear();
			SeriesData costSeriesData = new SeriesData();
			costSeriesData.DisplayName = "Cost";
			SeriesData marginSeriesData = new SeriesData();
			marginSeriesData.DisplayName = "Margin";

			decimal actualRevenuePerformance = 0.0m;

			decimal totalHoursForTheMonth = TotalHoursForTheMonth();
			decimal targetRevenue = _settings.MonthlyRevenueTargets.FirstOrDefault(revenueTarget => revenueTarget.Month == ReportMonth).Target;
			decimal targetDollarPerHour = totalHoursForTheMonth != 0 ? targetRevenue / totalHoursForTheMonth : 0.0m;

			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();

            foreach (AssociateSales associateSales in AssociateSales)
            {
				StringWrapper wrapper = new StringWrapper();
				wrapper.Value = associateSales.SalesAssociate;

				if (_settings.IgnoreList.FirstOrDefault(ignore => ignore.Value == associateSales.SalesAssociate) != null)
				{
					continue;
				}

				if (statusUpdate != null)
				{
					statusUpdate.UpdateStatus("Calculating sales data for " + associateSales.SalesAssociate);
				}

                SalesChartData costData = new SalesChartData();
                costData.Category = associateSales.SalesAssociate;
                costData.Number = associateSales.TotalCost;

                SalesChartData marginData = new SalesChartData();
                marginData.Category = costData.Category;
                marginData.Number = associateSales.TotalSales - associateSales.TotalCost;
				
				//_monthlyRevenuePerformance.ActualPerformance += associateSales.TotalSales;
				actualRevenuePerformance += associateSales.TotalSales;

				costSeriesData.Items.Add(costData);
				marginSeriesData.Items.Add(marginData);

				if (_settings.MonthHours != null)
				{
					MonthlyHours salesAssociateScheduledHours = _settings.MonthHours.FirstOrDefault(monthHours => monthHours.Associate == associateSales.SalesAssociate);

					if (salesAssociateScheduledHours != null)
					{
						decimal associateTarget = salesAssociateScheduledHours.Hours * targetDollarPerHour;

						SalesAssociateTargetPerformance.AddPerformanceSeries(associateSales.SalesAssociate, associateTarget, associateSales.TotalSales);
					}
				}
            }

			_salesAssociatePerformance.Series.Add(costSeriesData);
			_salesAssociatePerformance.Series.Add(marginSeriesData);

			decimal performanceTarget = _settings.MonthlyRevenueTargets.First(target => target.Month == ReportMonth).Target;
			MonthlyRevenuePerformance.AddPerformanceSeries("revenue", performanceTarget, actualRevenuePerformance);


        }

		protected void CalculateSalesAssociatePerformanceTargetData()
		{
			decimal revenueTarget = _settings.MonthlyRevenueTargets.First(target => target.Month == ReportMonth).Target;
			decimal totalHours = 0.0m;

			HoursForTheMonth hoursForTheMonth = _settings.HoursForTheYear.First(monthHours => monthHours.Month == ReportMonth);

			foreach (MonthlyHours monthlyHours in hoursForTheMonth.Hours)
			{
				totalHours += monthlyHours.Hours;
			}
		}
		//protected void UpdateRevenueTarget()
		//{
		//    _monthlyRevenuePerformance.PerformanceTarget = _settings.MonthlyRevenueTargets.First(target => target.Month == ReportMonth).Target;
		//}

        private void PopulateAverages()
        {
            foreach (AssociateSales associateSales in AssociateSales)
            {
                associateSales.SalesPerHour = associateSales.HoursWorked == 0.0m ? 0.0m : (associateSales.NumberSales / associateSales.HoursWorked);
                associateSales.AverageItemsPerSale = associateSales.NumberSales == 0.0m ? 0.0m : (decimal)associateSales.TotalItems / (decimal)associateSales.NumberSales;
                associateSales.AveragePerSale = associateSales.NumberSales == 0.0m ? 0.0m : associateSales.TotalSales / associateSales.NumberSales;
                associateSales.ProfitMargin = associateSales.TotalCost == 0.0m ? 0.0m : ((associateSales.TotalSales - associateSales.TotalCost) / associateSales.TotalSales)*100.0m;
				associateSales.AveragePricePerItemSold = associateSales.TotalItems == 0.0m ? 0.0m : (associateSales.TotalSales / associateSales.TotalItems);
            }
        }

        protected AssociateSales GetAssociate(string salesAssociate)
        {
            AssociateSales associateSales;

            try
            {
                associateSales = AssociateSales.FirstOrDefault(associate => associate.SalesAssociate == salesAssociate);
            }
            catch (InvalidOperationException)
            {
                associateSales = null;
            }

            return associateSales;
        }

        private void PopulateTime()
        {
            XmlNodeList timeList = TimeEntryRepository.GetTimeEntries(StartDate.Value, EndDate.Value);

            if (timeList != null)
            {
                int i = 1;
                _timeEntries.Clear();
                
                IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();

                foreach (XmlNode node in timeList)
                {
                    statusUpdate.UpdateStatus("Processing " + i++ + " of " + timeList.Count + " time entries");

                    TimeEntry timeEntry = new TimeEntry(node);

                    _timeEntries.Add(timeEntry);

                    AssociateSales associateSales = GetAssociate(timeEntry.EmployeeLoginName);

                    if (associateSales != null)
                    {
                        DateTime clockIn = DateUtil.ParseDate(timeEntry.ClockInTime);
                        DateTime clockOut = DateUtil.ParseDate(timeEntry.ClockOutTime);

                        associateSales.HoursWorked += (decimal)((clockOut - clockIn).TotalHours);
                    }
                    else
                    {
                        associateSales = new AssociateSales();
                        associateSales.SalesAssociate = timeEntry.EmployeeLoginName;
                        DateTime clockIn = DateUtil.ParseDate(timeEntry.ClockInTime);
                        DateTime clockOut = DateUtil.ParseDate(timeEntry.ClockOutTime);

                        associateSales.HoursWorked = (decimal)((clockOut - clockIn).TotalHours);

                        AssociateSales.Add(associateSales);
                    }
                }
            }

        }

		private void ZeroOut()
		{
			_associateSales.Clear();
			_itemsSold.Clear();
			_topItemsSold.Clear();
		}

        private void PopulateSales()
        {
            XmlNodeList salesList = SalesRepository.GetSales(StartDate.Value, EndDate.Value);

            if (salesList != null)
            {
                int i = 1;
                _salesReceipts.Clear();

                IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();

                foreach (XmlNode node in salesList)
                {
                    statusUpdate.UpdateStatus("Processing " + i++ + " of " + salesList.Count + " sales receipts");

                    SalesReceipt salesReceipt = new SalesReceipt(node);

                    _salesReceipts.Add(salesReceipt);
                   
                    AssociateSales associateSales = GetAssociate(salesReceipt.Associate);
                    if (associateSales != null)
                    {
                        associateSales.NumberSales++;
                        TotalUpSales(associateSales, salesReceipt);
                    }
                    else
                    {
                        associateSales = new AssociateSales();
                        associateSales.SalesAssociate = salesReceipt.Associate;
                        associateSales.NumberSales = 1;
                        TotalUpSales(associateSales, salesReceipt);
                        
                        AssociateSales.Add(associateSales);
                    }
                    TotalUpCost(associateSales, salesReceipt);
                }

				GetTopItemsSold();
            }
        }

        private void TotalUpSales(AssociateSales associateSales, SalesReceipt salesReceipt)
        {
            associateSales.TotalSales += Convert.ToDecimal(salesReceipt.Subtotal);
            associateSales.TotalItems += Convert.ToInt32(salesReceipt.ItemsCount);

			Dictionary<string, object> testing = new Dictionary<string, object>();

			foreach (SalesReceiptItem salesReceiptItem in salesReceipt.Items)
			{
				ItemSold itemSold;

				if (_itemsSold.TryGetValue(salesReceiptItem.ListID, out itemSold))
				{
					itemSold.Quantity += (int)(Convert.ToDecimal(salesReceiptItem.Qty));
				}
				else
				{
					_itemsSold.Add(salesReceiptItem.ListID, new ItemSold()
										{ 
											Quantity = (int)(Convert.ToDecimal(salesReceiptItem.Qty)), 
											Id = salesReceiptItem.ListID, 
											Desc1 = salesReceiptItem.Desc1, 
											Desc2 = salesReceiptItem.Desc2
										}
									);

				}
				
			}

			
        }

		private void GetTopItemsSold()
		{
			_topItemsSold.Clear();

			List<ItemSold> sortedList = _itemsSold.Values.ToList();
			sortedList = sortedList.OrderByDescending(item => item.Quantity).ToList();

			for (int i = 0; i < 10 && i < sortedList.Count; i++)
			{
				_topItemsSold.Add(sortedList[i]);
			}
			OnPropertyChanged("TopItemsSold");
		}
        private void TotalUpCost(AssociateSales associateSales, SalesReceipt salesReceipt)
        {
            foreach (SalesReceiptItem item in salesReceipt.Items)
            {
                associateSales.TotalCost += Convert.ToDecimal(item.Cost);
            }
        }

		private void Settings(object sender, RoutedEventArgs args)
		{
			ISalesDashboardSettings settingsService = ServiceContainer.Instance.GetService<ISalesDashboardSettings>();

			if (settingsService != null)
			{
				bool? result = settingsService.ShowDashboardSettings(_settings);

				if (result.HasValue && result.Value == true)
				{
					_settings.Save();
					Update(null, null);
				}
			}
		}

    }
}
