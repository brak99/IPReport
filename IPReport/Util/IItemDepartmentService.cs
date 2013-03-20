using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	public interface IItemDepartmentService
	{
		void SaveItemDepartment(string itemListId, string departmentListId);
		string GetItemDepartment(string itemListId);
	}
}
