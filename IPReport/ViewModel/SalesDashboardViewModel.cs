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

namespace IPReport.ViewModel
{
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
        private decimal _marginPercent;
        public decimal MarginPercent
        {
            get { return _marginPercent; }
            set { _marginPercent = value;
            OnPropertyChanged("MarginPercent");
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

            EndDate = DateTime.Now;
        }

        public void Update(object sender, RoutedEventArgs args)
        {
            if (StartDate.HasValue && EndDate.HasValue)
            {
                PopulateSales();
                PopulateTime();
                PopulateAverages();
            }
        }

        private void PopulateAverages()
        {
            foreach (AssociateSales associateSales in AssociateSales)
            {
                associateSales.SalesPerHour = associateSales.HoursWorked == 0.0m ? 0.0m : (associateSales.NumberSales / associateSales.HoursWorked);
                associateSales.AverageItemsPerSale = associateSales.NumberSales == 0.0m ? 0.0m : associateSales.TotalItems / associateSales.NumberSales;
                associateSales.AveragePerSale = associateSales.NumberSales == 0.0m ? 0.0m : associateSales.TotalSales / associateSales.NumberSales;
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
            XmlNodeList timeList = TimeEntryRepository.GetTimeEntries(DateUtil.StartOfDay(StartDate.Value), DateUtil.EndOfDay(EndDate.Value));

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

        private void PopulateSales()
        {
            XmlNodeList salesList = SalesRepository.GetSales(DateUtil.StartOfDay(StartDate.Value), DateUtil.EndOfDay(EndDate.Value));

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
                        associateSales.TotalSales += Convert.ToDecimal(salesReceipt.Subtotal);
                        associateSales.TotalItems += Convert.ToInt32(salesReceipt.ItemsCount);
                    }
                    else
                    {
                        associateSales = new AssociateSales();
                        associateSales.SalesAssociate = salesReceipt.Associate;
                        associateSales.NumberSales = 1;
                        associateSales.TotalSales += Convert.ToDecimal(salesReceipt.Subtotal);
                        associateSales.TotalItems += Convert.ToInt32(salesReceipt.ItemsCount);
                        AssociateSales.Add(associateSales);
                    }
                }
            }
        }
    }
}
