using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.Charts.ViewModel;
using De.TorstenMandelkow.MetroChart;
using IPReport.ViewModel;

namespace IPReport.Test
{
	[TestFixture]
	public class ChartSeriesViewModelTests
	{
		[Test]
		public void AddDataPointUpdatesSums()
		{
			ChartSeriesViewModel vm = ChartSeriesViewModel.GetInstance();

			SalesChartData salesChartData = new SalesChartData { Number = 100.0M };
			DataPoint dataPoint = new DataPoint { StartValue = 1.0d };

			vm.DataPoints.Add(dataPoint);

			Assert.AreEqual(1, vm.DataPoints.Count);
			Assert.AreEqual(0.0d, vm.SumOfDataPointGroup);

			dataPoint.ReferencedObject = salesChartData;

			Assert.AreEqual(100.0d, vm.SumOfDataPointGroup);
		}

		[Test]
		public void DeleteDataPoints()
		{
			ChartSeriesViewModel vm = ChartSeriesViewModel.GetInstance();

			SalesChartData salesChartData = new SalesChartData { Number = 100.0M };
			DataPoint dataPoint = new DataPoint { StartValue = 1.0d };

			vm.DataPoints.Add(dataPoint);

			Assert.AreEqual(1, vm.DataPoints.Count);
			Assert.AreEqual(0.0d, vm.SumOfDataPointGroup);

			dataPoint.ReferencedObject = salesChartData;

			Assert.AreEqual(100.0d, vm.SumOfDataPointGroup);

			vm.DataPoints.Remove(dataPoint);

			Assert.AreEqual(0, vm.DataPoints.Count);

		}

		[Test]
		public void ChangeDataPointUpdatesSums()
		{
			ChartSeriesViewModel vm = ChartSeriesViewModel.GetInstance();

			SalesChartData salesChartData = new SalesChartData { Number = 100.0M };
			DataPoint dataPoint = new DataPoint { StartValue = 1.0d };

			vm.DataPoints.Add(dataPoint);

			Assert.AreEqual(1, vm.DataPoints.Count);
			Assert.AreEqual(0.0d, vm.SumOfDataPointGroup);

			dataPoint.ReferencedObject = salesChartData;

			Assert.AreEqual(100.0d, vm.SumOfDataPointGroup);

			dataPoint.ReferencedObject = new SalesChartData { Number = 50.0M };

			Assert.AreEqual(50.0d, vm.SumOfDataPointGroup);
		}
	}
}
