using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using De.TorstenMandelkow.MetroChart;
using IPReport.ViewModel;
using System.Collections.Specialized;
using System.Windows.Media;

namespace IPReport.Charts.ViewModel
{
	public class GroupedSeriesViewModel : WorkspaceViewModel
	{
		private double _maxDataPointGroupSum;
		public double MaxDataPointGroupSum
		{
			get { return _maxDataPointGroupSum; }
			set 
			{ 
				_maxDataPointGroupSum = value; 
				OnPropertyChanged("MaxDataPointGroupSum"); 
				UpdateMaxDataPointGroupSumOnDataPoints();
				UpdateGridLines();
			}
		}

		private double _maxDataPointValue;
		public double MaxDataPointValue
		{
			get { return _maxDataPointValue; }
			set { _maxDataPointValue = value; OnPropertyChanged("MaxDataPointValue"); }
		}

		protected double GridLinesMaxValue
		{
			get { return MaxDataPointGroupSum; }
		}

		private ObservableCollection<string> _gridLines = new ObservableCollection<string>();
		public ObservableCollection<string> GridLines
		{
			get
			{
				return _gridLines;
			}
		}
		private ObservableCollection<SeriesData> _series = new ObservableCollection<SeriesData>();
		public ObservableCollection<SeriesData> Series
		{
			get { return _series; }
		}

		protected GroupedSeriesViewModel()
		{
			_series.CollectionChanged += OnGroupedSeriesChanged;
		}


		public static GroupedSeriesViewModel GetInstance()
		{
			return new GroupedSeriesViewModel();
		}

		protected virtual void OnGroupedSeriesChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			UpdateGroupedSeries();
		}

		ObservableCollection<ChartSeriesViewModel> groupedSeries = new ObservableCollection<ChartSeriesViewModel>();
		private void UpdateGroupedSeries()
		{
			List<ChartSeriesViewModel> result = new List<ChartSeriesViewModel>();
			try
			{
				foreach (SeriesData initialSeries in Series)
				{

					foreach (SalesChartData seriesItem in initialSeries.Items)
					{
						string seriesItemCaption = seriesItem.Category; //Security
						ChartSeriesViewModel dataPointGroup = result.Find(salesChartData => salesChartData.Caption == seriesItemCaption);

						if (dataPointGroup == null)
						{
							//TODO: this stuff doesn't work for the performance target vm
							//  performance target and actual performance need to be dragged along
							//  because at the lower UI level it ends up missing the performance target and actual
							//  performance (because it's a ChartSeriesViewModel) so the WidthsAndDataGroupToWidth 
							//  converter fails

							dataPointGroup = CreateViewModel(initialSeries);
							

							dataPointGroup.Caption = seriesItemCaption;
							result.Add(dataPointGroup);

							AddApplicableSeries(dataPointGroup, seriesItem);
							
						}
						else
						{
							foreach (DataPoint dataPoint in dataPointGroup.DataPoints)
							{
								if (dataPoint.SeriesCaption == initialSeries.DisplayName)
								{
									dataPoint.ReferencedObject = seriesItem;
								}
							}
						}
					}
				}

			}
			catch (Exception)
			{
			}

			//finished, copy all to the array
			DataPointGroups.Clear();
			foreach (var item in result)
			{
				DataPointGroups.Add(item);
			}
			RecalcSumOfDataPointGroups();
		}

		protected virtual void AddApplicableSeries(ChartSeriesViewModel dataPointGroup, SalesChartData seriesItem)
		{
			int seriesIndex = 0;
			foreach (SeriesData allSeries in Series)
			{
				DataPoint dataPoint = new DataPoint();
				dataPoint.SeriesCaption = allSeries.DisplayName;
				dataPointGroup.DataPoints.Add(dataPoint);
				dataPoint.ReferencedObject = seriesItem;
				dataPoint.SeriesNumber = seriesIndex++;
			}
		}

		void dataPointGroup_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SumOfDataPointGroup")
			{
				RecalcSumOfDataPointGroups();
			}
		}

		private void RecalcSumOfDataPointGroups()
		{
			double maxValue = 0.0;
			foreach (var dataPointGroup in DataPointGroups)
			{
				if (dataPointGroup.SumOfDataPointGroup > maxValue)
				{
					maxValue = dataPointGroup.SumOfDataPointGroup;
				}
			}
			MaxDataPointGroupSum = CalculateMaxValue(maxValue);
			foreach (var dataPointGroup in DataPointGroups)
			{
				dataPointGroup.MaxSumOfDataPointGroup = MaxDataPointGroupSum;
			}
		}

		protected void UpdateGridLines()
		{
			double distance = CalculateDistance(GridLinesMaxValue);
			_gridLines.Clear();
			for (var i = distance; i <= GridLinesMaxValue; i += distance)
			{
				_gridLines.Add(i.ToString());
			}
		}

		private void UpdateMaxDataPointGroupSumOnDataPoints()
		{
			foreach (ChartSeriesViewModel chartSeries in DataPointGroups)
			{
				foreach (DataPoint dataPoint in chartSeries.DataPoints)
				{
					dataPoint.MaxDataPointGroupSum = MaxDataPointGroupSum;
				}
			}
		}
		void groupdItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			RecalcMaxDataPointValue();
		}

		private void RecalcMaxDataPointValue()
		{
			double maxValue = 0.0;
			foreach (var dataPointGroup in DataPointGroups)
			{
				foreach (var dataPoint in dataPointGroup.DataPoints)
				{
					if (dataPoint.Value > maxValue)
					{
						maxValue = dataPoint.Value;
					}
				}
			}
			MaxDataPointValue = CalculateMaxValue(maxValue);
		}

		public ObservableCollection<ChartSeriesViewModel> DataPointGroups
		{
			get
			{
				return groupedSeries;
			}
		}

		/// <summary>
		/// take a number, e.g.
		/// 43456 -> 50000
		/// 1324 -> 1400
		/// 123 -> 130
		/// 8 -> 10
		/// 23 -> 30
		/// 82 -> 90
		/// 92 -> 100
		/// 1.5 -> 2
		/// 33 -> 40
		/// </summary>
		/// <param name="newMaxValue"></param>
		/// <returns></returns>
		private double CalculateMaxValue(double newMaxValue)
		{
			double bestMaxValue = 0.0;
			int bestDivisor = 1;

			GetBestValues(newMaxValue, ref bestMaxValue, ref bestDivisor);

			return bestMaxValue;
		}

		private double CalculateDistance(double givenBestMaxValue)
		{
			double bestMaxValue = 0.0;
			int bestDivisor = 1;
			double distance = 0.0;

			GetBestValues(givenBestMaxValue, ref bestMaxValue, ref bestDivisor);
			distance = bestMaxValue / bestDivisor;

			return distance;
		}


		private void GetBestValues(double wert, ref double bestMaxValue, ref int bestDivisor)
		{
			string wertString = wert.ToString(System.Globalization.CultureInfo.InvariantCulture);
			double tensBelowNull = 1;

			if (wert <= 1)
			{
				//0.72  -> 0.8
				//0.00145
				//0.0007453 0> 7453

				//count digits after comma
				int digitsAfterComma = wertString.Replace("0.", "").Length;
				tensBelowNull = Math.Pow(10, digitsAfterComma);
				wert = wert * tensBelowNull;
				wertString = wert.ToString(System.Globalization.CultureInfo.InvariantCulture);
			}
			if (wertString.Contains("."))
			{
				wertString = wertString.Substring(0, wertString.IndexOf("."));
			}
			int digitsBeforeComma = wertString.Length;
			int roundedValue = (int)Math.Ceiling(wert);
			double tens = 0;
			if (digitsBeforeComma > 2)
			{
				tens = Math.Pow(10, digitsBeforeComma - 2);
				double wertWith2Digits = wert / tens;
				roundedValue = (int)Math.Ceiling(wertWith2Digits);
			}
			else if (digitsBeforeComma == 1)
			{
				tens = 0.1;
				double wertWith2Digits = wert / tens;
				roundedValue = (int)Math.Ceiling(wertWith2Digits);
			}

			int finaldivisor = FindBestDivisor(ref roundedValue);

			double roundedValueDouble = roundedValue / tensBelowNull;

			if (tens > 0)
			{
				roundedValueDouble = roundedValueDouble * tens;
			}

			bestMaxValue = roundedValueDouble;
			bestDivisor = finaldivisor;

		}

		private int FindBestDivisor(ref int roundedValue)
		{
			if (IsUseNextBiggestMaxValue)
			{
				roundedValue += 1;
			}
			while (true)
			{
				int[] divisors = new int[] { 2, 5, 10, 25 };
				foreach (int divisor in divisors)
				{
					int div = roundedValue % divisor;
					int mod = roundedValue / divisor;

					if ((roundedValue < 10) && (mod == 1))
					{
						return roundedValue;
					}

					if ((div == 0) && (mod <= 10))
					{
						return mod;
					}
				}
				roundedValue = roundedValue + 1;
			}
		}

		private ChartSeriesViewModel CreateViewModel(SeriesData seriesItem)
		{
			PerformanceSeriesData performanceSeriesData = seriesItem as PerformanceSeriesData;

			if (performanceSeriesData != null)
			{
				PerformanceChartSeriesViewModel viewModel = PerformanceChartSeriesViewModel.GetInstance();
				viewModel.ActualPerformance = performanceSeriesData.ActualPerformance;
				viewModel.PerformanceTarget = performanceSeriesData.PerformanceTarget;
				return viewModel;
			}
			else
			{
				return ChartSeriesViewModel.GetInstance();
			}
		}

		/// <summary>
		/// In ColumnGrid we need some space above the column to show the number above the column,
		/// this is not needed in StackedChart
		/// </summary>
		public virtual bool IsUseNextBiggestMaxValue
		{
			get
			{
				return false;
			}
		}

	}
}
