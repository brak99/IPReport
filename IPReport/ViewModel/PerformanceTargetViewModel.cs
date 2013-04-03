using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace IPReport.ViewModel
{
	public class PerformanceRangeData
	{
		public string Category { get; set; }
		public decimal Number { get; set; }
	}
	public class PerformanceSeriesData : WorkspaceViewModel
	{
		public PerformanceSeriesData()
		{
			Items = new ObservableCollection<PerformanceRangeData>();
		}

		public string DisplayName { get; set; }

		public string Description { get; set; }

		private decimal _actualPerformance;
		public decimal ActualPerformance
		{
			get { return _actualPerformance; }
			set 
			{ 
				_actualPerformance = value;
				OnPropertyChanged("ActualPerformance");

			}
		}

		private decimal _performanceTarget;
		public decimal PerformanceTarget
		{
			get { return _performanceTarget; }
			set
			{
				_performanceTarget = value;
				OnPropertyChanged("PerformanceTarget");

			}
		}
		public ObservableCollection<PerformanceRangeData> Items { get; set; }
	}

	public class PerformanceTargetViewModel : WorkspaceViewModel
	{
		public double PoorPerformance
		{
			get;
			set;
		}

		public double SatisfactoryPerformance
		{
			get;
			set;
		}

		public double GoodPerformance
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public static PerformanceTargetViewModel GetInstance()
		{
			return new PerformanceTargetViewModel();
		}

		private PerformanceTargetViewModel()
		{
			PoorPerformance = 0.6;
			SatisfactoryPerformance = .9;
			GoodPerformance = 1.2;

			_poorSeries.DisplayName = "Poor";
			_satisfactorySeries.DisplayName = "Satisfactory";
			_goodSeries.DisplayName = "Good";
		}

		private decimal _actualPerformance;
		public decimal ActualPerformance
		{
			get { return _actualPerformance; }
			set
			{
				_actualPerformance = value;

				_poorSeries.ActualPerformance = value;
				_goodSeries.ActualPerformance = value;
				_satisfactorySeries.ActualPerformance = value;
			}
		}

		private decimal _performanceTarget;
		public decimal PerformanceTarget
		{
			get {return _performanceTarget;}
			set
			{
				_performanceTarget = value;
				_poorSeries.PerformanceTarget = value;
				_goodSeries.PerformanceTarget = value;
				_satisfactorySeries.PerformanceTarget = value;
				CalculateRanges();
			}
		}

		private ObservableCollection<PerformanceSeriesData> _performanceRanges = new ObservableCollection<PerformanceSeriesData>();
		public ObservableCollection<PerformanceSeriesData> PerformanceRanges
		{
			get { return _performanceRanges; }
		}
		private PerformanceSeriesData _poorSeries = new PerformanceSeriesData();
		private PerformanceSeriesData _satisfactorySeries = new PerformanceSeriesData();
		private PerformanceSeriesData _goodSeries = new PerformanceSeriesData();

		private void CalculateRanges()
		{
			_performanceRanges.Clear();
			_poorSeries.Items.Clear();
			_satisfactorySeries.Items.Clear();
			_goodSeries.Items.Clear();

			_performanceRanges.Add(_poorSeries);
			_performanceRanges.Add(_satisfactorySeries);
			_performanceRanges.Add(_goodSeries);

			PerformanceRangeData poorData = new PerformanceRangeData();
			poorData.Category = Name;
			poorData.Number = PerformanceTarget * (decimal)PoorPerformance;

			PerformanceRangeData satisfactoryData = new PerformanceRangeData();
			satisfactoryData.Category = Name;
			satisfactoryData.Number = PerformanceTarget * (decimal)SatisfactoryPerformance;
			satisfactoryData.Number -= poorData.Number;

			PerformanceRangeData goodData = new PerformanceRangeData();
			goodData.Category = Name;
			goodData.Number = PerformanceTarget * (decimal)GoodPerformance;
			goodData.Number -= poorData.Number;
			goodData.Number -= satisfactoryData.Number;

			_poorSeries.Items.Add(poorData);
			_satisfactorySeries.Items.Add(satisfactoryData);
			_goodSeries.Items.Add(goodData);
		}
	}
}
