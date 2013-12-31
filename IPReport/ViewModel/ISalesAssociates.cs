using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.ViewModel
{
	public interface ISalesAssociates
	{
		IEnumerable<string> SalesAssociates();
	}
}
