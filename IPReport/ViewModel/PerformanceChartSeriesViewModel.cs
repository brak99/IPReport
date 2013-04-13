using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Charts.ViewModel;

namespace IPReport.ViewModel
{
	public class PerformanceChartSeriesViewModel : ChartSeriesViewModel
	{

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

		private PerformanceChartSeriesViewModel()
		{

		}

		public static PerformanceChartSeriesViewModel GetInstance()
		{
			return new PerformanceChartSeriesViewModel();
		}
	}
}
