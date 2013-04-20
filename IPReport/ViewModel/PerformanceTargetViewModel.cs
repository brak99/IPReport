using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using IPReport.Charts.ViewModel;
using De.TorstenMandelkow.MetroChart;

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

		public static new PerformanceTargetViewModel GetInstance()
		{
			return new PerformanceTargetViewModel();
		}

		private PerformanceTargetViewModel()
		{
			PoorPerformance = 0.6;
			SatisfactoryPerformance = .9;
			GoodPerformance = 1.2;
		}

		
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

		public void Clear()
		{
			Series.Clear();
		}

		protected override void AddApplicableSeries(ChartSeriesViewModel dataPointGroup, SalesChartData seriesItem)
		{
			int seriesIndex = 0;
			foreach (SeriesData allSeries in Series)
			{
				//need to loop through the items in allSeries.Items and match the names
				// what it's doing now is adding all in Series to each person so people
				// are getting 30 SeriesData in the performanceviewmodel situation

				bool shouldAdd = false;
				foreach (SalesChartData salesChartData in allSeries.Items)
				{
					if (salesChartData.Category == dataPointGroup.Caption)
					{
						shouldAdd = true;
						break;
					}
				}
				if (shouldAdd)
				{
					DataPoint dataPoint = new DataPoint();
					dataPoint.SeriesCaption = allSeries.DisplayName;
					dataPointGroup.DataPoints.Add(dataPoint);
					dataPoint.ReferencedObject = seriesItem;
					dataPoint.SeriesNumber = seriesIndex++;
				}
				
			}
		}
	}
}
