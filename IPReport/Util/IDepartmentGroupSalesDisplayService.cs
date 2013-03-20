using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.ViewModel;
using System.Windows;

namespace IPReport.Util
{
	public interface IDepartmentGroupSalesDisplayService
	{
		void ShowDepartmentSales(DepartmentGroupViewModel departmentGroupViewModel);
	}
}
