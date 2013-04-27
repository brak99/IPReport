using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IPReport.Util
{
	public interface IDateService
	{
		DateTime DateForReport { get; set; }
		void SetDateForReport(DateTime reportDate);
		ICommand NextMonthCommand { get; }
		ICommand PreviousMonthCommand { get; }
	}
}
