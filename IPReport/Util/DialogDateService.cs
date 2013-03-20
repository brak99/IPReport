using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.View;

namespace IPReport.Util
{
	public class DialogDateService : IDateService
	{
		private DateTime _dateForReport = DateTime.Now;

		public DateTime DateForReport()
		{
			DateTime reportDate = DateTime.Now;

			DateSelection dateSelection = new DateSelection();

			dateSelection.datePicker1.DisplayDate = _dateForReport;

			dateSelection.ShowDialog();

			_dateForReport = dateSelection.datePicker1.DisplayDate;

			return _dateForReport;
		}
	}
}
