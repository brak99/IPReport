using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	public interface IStatusUpdate
	{
		void UpdateStatus(string status);
	}
}
