using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	public class ReportDateService : IDateService
	{
		private DateTime _dateForReport = DateTime.Now;

		public DateTime DateForReport()
		{
			return _dateForReport;
		}

		public void SetDateForReport(DateTime reportDate)
		{
			_dateForReport = reportDate;
		}
	}
}
