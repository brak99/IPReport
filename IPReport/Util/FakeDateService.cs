using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	public class FakeDateService : IDateService
	{
		public DateTime DateForReport()
		{
			return DateTime.Now;
		}
		public void SetDateForReport(DateTime reportDate)
		{
			
		}
	}
}
