using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IPReport.Util
{
	public class FakeDateService : IDateService
	{

		public DateTime DateForReport
		{
			get { return DateTime.Now; }
			set { }
		}
		public void SetDateForReport(DateTime reportDate)
		{
			
		}
		public ICommand NextMonthCommand
		{
			get
			{ return null; }
		}

		public ICommand PreviousMonthCommand
		{
			get
			{ return null; }
		}
	}
}
