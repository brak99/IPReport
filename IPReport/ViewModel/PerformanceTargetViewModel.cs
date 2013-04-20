using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using IPReport.Charts.ViewModel;

namespace IPReport.ViewModel
{
	public class PerformanceSeriesData : SeriesData
	{
		public decimal PerformanceTarget { get; set; }

		public decimal ActualPerformance { get; set; }
	}


	public class PerformanceTargetViewModel : GroupedSeriesViewModel
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

		//public string Name
		//{
		//    get;
		//    set;
		//}

		public static new PerformanceTargetViewModel GetInstance()
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

		//private decimal _actualPerformance;
		//public decimal ActualPerformance
		//{
		//    get { return _actualPerformance; }
		//    set
		//    {
		//        _actualPerformance = value;

		//        _poorSeries.ActualPerformance = value;
		//        _goodSeries.ActualPerformance = value;
		//        _satisfactorySeries.ActualPerformance = value;
		//    }
		//}

		//private decimal _performanceTarget;
		//public decimal PerformanceTarget
		//{
		//    get {return _performanceTarget;}
		//    set
		//    {
		//        _performanceTarget = value;
		//        _poorSeries.PerformanceTarget = value;
		//        _goodSeries.PerformanceTarget = value;
		//        _satisfactorySeries.PerformanceTarget = value;
		//        //AddPerformanceSeries();
		//    }
		//}

		

		private ObservableCollection<PerformanceSeriesData> _performanceRanges = new ObservableCollection<PerformanceSeriesData>();
		public ObservableCollection<PerformanceSeriesData> PerformanceRanges
		{
			get { return _performanceRanges; }
		}
		private PerformanceSeriesData _poorSeries = new PerformanceSeriesData();
		private PerformanceSeriesData _satisfactorySeries = new PerformanceSeriesData();
		private PerformanceSeriesData _goodSeries = new PerformanceSeriesData();

		public void AddPerformanceSeries(string name, decimal performanceTarget, decimal actualPerformance)
		{
			PerformanceSeriesData poorSeries = new PerformanceSeriesData();
			poorSeries.ActualPerformance = actualPerformance;
			poorSeries.PerformanceTarget = performanceTarget;
			poorSeries.DisplayName = "Poor";

			PerformanceSeriesData satisfactorySeries = new PerformanceSeriesData();
			satisfactorySeries.ActualPerformance = actualPerformance;
			satisfactorySeries.PerformanceTarget = performanceTarget;
			satisfactorySeries.DisplayName = "Satisfactory";

			PerformanceSeriesData goodSeries = new PerformanceSeriesData();
			goodSeries.ActualPerformance = actualPerformance;
			goodSeries.PerformanceTarget = performanceTarget;
			goodSeries.DisplayName = "Good";


			SalesChartData poorData = CreatePoorSeries(performanceTarget, name);
			SalesChartData satisfactoryData = CreateSatisfactorySeries(performanceTarget, name);
			satisfactoryData.Number -= poorData.Number;
			SalesChartData goodData = CreateGoodSeries(performanceTarget, name);
			goodData.Number -= satisfactoryData.Number;
			goodData.Number -= poorData.Number;

			if (actualPerformance > poorData.Number + satisfactoryData.Number + goodData.Number)
			{
				goodData.Number = actualPerformance - poorData.Number - satisfactoryData.Number;
			}

			poorSeries.Items.Add(poorData);
			satisfactorySeries.Items.Add(satisfactoryData);
			goodSeries.Items.Add(goodData);


			Series.Add(poorSeries);
			Series.Add(satisfactorySeries);
			Series.Add(goodSeries);
		}

		private SalesChartData CreatePoorSeries(decimal performanceTarget, string name)
		{
			SalesChartData poorData = new SalesChartData();
			poorData.Category = name;
			poorData.Number = performanceTarget * (decimal)PoorPerformance;
			return poorData;
		}

		private SalesChartData CreateSatisfactorySeries(decimal performanceTarget, string name)
		{
			SalesChartData satisfactoryData = new SalesChartData();
			satisfactoryData.Category = name;
			satisfactoryData.Number = performanceTarget * (decimal)SatisfactoryPerformance;
			return satisfactoryData;
		}

		private SalesChartData CreateGoodSeries(decimal performanceTarget, string name)
		{
			SalesChartData goodData = new SalesChartData();
			goodData.Category = name;
			goodData.Number = performanceTarget * (decimal)GoodPerformance;
			return goodData;
		}

		//private void AddPerformanceSeries(string name)
		//{
		//    //Clear();

		//    SalesChartData poorData = new SalesChartData();
		//    poorData.Category = Name;
		//    poorData.Number = PerformanceTarget * (decimal)PoorPerformance;

		//    SalesChartData satisfactoryData = new SalesChartData();
		//    satisfactoryData.Category = Name;
		//    satisfactoryData.Number = PerformanceTarget * (decimal)SatisfactoryPerformance;
		//    satisfactoryData.Number -= poorData.Number;

		//    SalesChartData goodData = new SalesChartData();
		//    goodData.Category = Name;
		//    goodData.Number = PerformanceTarget * (decimal)GoodPerformance;
		//    goodData.Number -= poorData.Number;
		//    goodData.Number -= satisfactoryData.Number;

		//    _poorSeries.Items.Add(poorData);
		//    _satisfactorySeries.Items.Add(satisfactoryData);
		//    _goodSeries.Items.Add(goodData);

		//    Series.Add(_poorSeries);
		//    Series.Add(_satisfactorySeries);
		//    Series.Add(_goodSeries);
		//}

		public void Clear()
		{
			Series.Clear();
			_performanceRanges.Clear();
			_poorSeries.Items.Clear();
			_satisfactorySeries.Items.Clear();
			_goodSeries.Items.Clear();
		}
	}
}
