using System;
using System.Collections.ObjectModel;
using De.TorstenMandelkow.MetroChart;
using System.ComponentModel;
using System.Windows.Data;
using IPReport.ViewModel;
using System.Collections.Specialized;

namespace IPReport.Charts.ViewModel
{
	public class ChartSeriesViewModel : WorkspaceViewModel
	{
        public object SelectedItem
        {
            get 
			{
				ICollectionView collectionView = CollectionViewSource.GetDefaultView(DataPoints);
				return collectionView.CurrentItem;
			}
            set 
			{
				ICollectionView collectionView = CollectionViewSource.GetDefaultView(DataPoints);
				collectionView.MoveCurrentTo(value);
			}
        }

		private double _sumOfDataPointGroup;
        public double SumOfDataPointGroup
        {
			get { return _sumOfDataPointGroup; }
            set 
			{ 
				_sumOfDataPointGroup = value;
				OnPropertyChanged("SumOfDataPointGroup");
			}
        }

		public double _maxSumOfDataPointGroup;
		public double MaxSumOfDataPointGroup
		{
			get { return _maxSumOfDataPointGroup; }
			set
			{
				_maxSumOfDataPointGroup = value;
				OnPropertyChanged("MaxSumOfDataPointGroup");
			}
		}

        public ObservableCollection<DataPoint> DataPoints
        { get; private set; }

		public static ChartSeriesViewModel GetInstance()
		{
			return new ChartSeriesViewModel();
		}

		protected ChartSeriesViewModel()
        {
            DataPoints = new ObservableCollection<DataPoint>();
            DataPoints.CollectionChanged += DataPointsCollectionChanged;
        }

		void DataPointsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
			if (e.NewItems != null)
			{
				foreach (var item in e.NewItems)
				{
					if (item is INotifyPropertyChanged)
					{
						(item as INotifyPropertyChanged).PropertyChanged += DataPointGroup_PropertyChanged;
					}
				}
			}

			if (e.OldItems != null)
			{
				foreach (var item in e.OldItems)
				{
					(item as INotifyPropertyChanged).PropertyChanged -= DataPointGroup_PropertyChanged;
				}
			}
        }

        void DataPointGroup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                RecalcValues();
            }
        }

        private void RecalcValues()
        {
            double maxValue = 0.0;
            double sum = 0.0;
            foreach (DataPoint dataPoint in DataPoints)
            {
                dataPoint.StartValue = sum;
                sum += dataPoint.Value;
                if (dataPoint.Value > maxValue)
                {
                    maxValue = dataPoint.Value;
                }
            }
            SumOfDataPointGroup = sum;
			OnPropertyChanged("SumOfDataPointGroup");
        }

        public string Caption { get; set; }

	}
}
