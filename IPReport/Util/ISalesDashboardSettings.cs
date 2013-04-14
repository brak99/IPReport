using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	interface ISalesDashboardSettings
	{
		bool? ShowDashboardSettings(object dataContext);
	}
}
