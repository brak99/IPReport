using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De.TorstenMandelkow.MetroChart
{
	public class PerformanceTargetDataPoint : DataPoint
	{
		public string PerformanceTargetMember { get; set; }

		public string ActualPerformanceMember { get; set; }
	}
}
