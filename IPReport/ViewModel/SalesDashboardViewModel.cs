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

	public class PerformanceSeriesData : SeriesData
	{
		public decimal PerformanceTarget { get; set; }

		public decimal ActualPerformance { get; set; }
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
    // Sales Associate        Hours Worked       # of sales       % of total store sales       Total Sales $     Avg $ per sale      Avg Items Per Sale     Sales per hour     margin %
    public class SalesDashboardViewModel : WorkspaceViewModel
    {
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
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

		private SalesDashboardSettingsViewModel _settings = SalesDashboardSettingsViewModel.GetInstance();

        private SeriesData _revenueCostSeries = new SeriesData();
        private SeriesData _revenueProfitSeries = new SeriesData();

        private ObservableCollection<SeriesData> _revenueData = new ObservableCollection<SeriesData>();
        public ObservableCollection<SeriesData> RevenueData
        {
            get
            {
                return _revenueData;
            }
        }

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

        private SeriesData _associateSalesCostSeries = new SeriesData();
        private SeriesData _associateSalesMarginSeries = new SeriesData();
		private SeriesData _associateOtherSeries = new SeriesData();

        
        public ObservableCollection<AssociateSales> AssociateSales
        {
            get
            {
                return _associateSales;
            }
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
            StartDate = DateUtil.StartOfWeek(DateTime.Now);

            EndDate = DateUtil.EndOfDay(DateTime.Now);

            _associateSalesCostSeries.Description = "Cost";
            _associateSalesCostSeries.DisplayName = "Cost";

            _associateSalesMarginSeries.Description = "Margin";
			_associateSalesMarginSeries.DisplayName = "Margin";

            _revenueCostSeries.Description = "Cost";
            _revenueCostSeries.DisplayName = "Cost";
            _revenueProfitSeries.Description = "Margin";
            _revenueProfitSeries.DisplayName = "Margin";

            PopulateChartData();
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

        private void PopulateChartData()
        {
			MonthlyRevenuePerformance.Name = "Revenue";

			_salesAssociatePerformance.Series.Clear();
			SeriesData costSeriesData = new SeriesData();
			costSeriesData.DisplayName = "Cost";
			SeriesData marginSeriesData = new SeriesData();
			marginSeriesData.DisplayName = "Margin";

            _associateSalesCostSeries.Items.Clear();
            _associateSalesMarginSeries.Items.Clear();
			_associateOtherSeries.Items.Clear();

            SalesChartData revenueCost = new SalesChartData();
            SalesChartData revenueProfit = new SalesChartData();
			SalesChartData theOtherThing = new SalesChartData();

			_monthlyRevenuePerformance.ActualPerformance = 0.0m;

            foreach (AssociateSales associateSales in AssociateSales)
            {
				StringWrapper wrapper = new StringWrapper();
				wrapper.Value = associateSales.SalesAssociate;

				try
				{
					if (_settings.IgnoreList.First(ignore => ignore.Value == associateSales.SalesAssociate) != null)
					{
						continue;
					}
				}
				catch (System.Exception)
				{
					
				}
				
                SalesChartData costData = new SalesChartData();
                costData.Category = associateSales.SalesAssociate;
                costData.Number = associateSales.TotalCost;
                revenueCost.Number += costData.Number;

                SalesChartData marginData = new SalesChartData();
                marginData.Category = costData.Category;
                marginData.Number = associateSales.TotalSales - associateSales.TotalCost;
                revenueProfit.Number += marginData.Number;

				
				_monthlyRevenuePerformance.ActualPerformance += associateSales.TotalSales;

				SalesChartData otherData = new SalesChartData();
				otherData.Category = costData.Category;
				otherData.Number = 100m;

				SalesChartData costData2 = new SalesChartData();
				costData2.Category = costData.Category;
				costData2.Number = costData.Number;

				SalesChartData marginData2 = new SalesChartData();
				marginData2.Category = marginData.Category;
				marginData2.Number = marginData.Number;

                _associateSalesCostSeries.Items.Add(costData);
                _associateSalesMarginSeries.Items.Add(marginData);
				_associateOtherSeries.Items.Add(otherData);

				costSeriesData.Items.Add(costData);
				marginSeriesData.Items.Add(marginData);

            }

			//_revenueProfitSeries.Items.Add(revenueProfit);
			//_revenueCostSeries.Items.Add(revenueCost);

			_salesAssociatePerformance.Series.Add(costSeriesData);
			_salesAssociatePerformance.Series.Add(marginSeriesData);

			//_monthlyRevenuePerformance.PerformanceTarget = _settings.YearlyRevenue/12.0m;
			
        }

        private void PopulateAverages()
        {
            foreach (AssociateSales associateSales in AssociateSales)
            {
                associateSales.SalesPerHour = associateSales.HoursWorked == 0.0m ? 0.0m : (associateSales.NumberSales / associateSales.HoursWorked);
                associateSales.AverageItemsPerSale = associateSales.NumberSales == 0.0m ? 0.0m : associateSales.TotalItems / associateSales.NumberSales;
                associateSales.AveragePerSale = associateSales.NumberSales == 0.0m ? 0.0m : associateSales.TotalSales / associateSales.NumberSales;
                associateSales.ProfitMargin = associateSales.TotalCost == 0.0m ? 0.0m : ((associateSales.TotalSales - associateSales.TotalCost) / associateSales.TotalSales)*100.0m;
            }
        }

        protected AssociateSales GetAssociate(string salesAssociate)
        {
            AssociateSales associateSales;

            try
            {
                associateSales = AssociateSales.First(associate => associate.SalesAssociate == salesAssociate);
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
            }
        }

        private void TotalUpSales(AssociateSales associateSales, SalesReceipt salesReceipt)
        {
            associateSales.TotalSales += Convert.ToDecimal(salesReceipt.Subtotal);
            associateSales.TotalItems += Convert.ToInt32(salesReceipt.ItemsCount);
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
				}
			}
		}

    }
}
