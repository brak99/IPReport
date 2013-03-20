using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Util;

namespace IPReport.DataAccess
{
	public class ItemDepartmentRepository : IItemDepartmentService
	{
		private Dictionary<string, string> _itemDepartments = new Dictionary<string, string>();

		public void SaveItemDepartment(string itemListId, string departmentListId)
		{
			if (!_itemDepartments.ContainsKey(itemListId))
			{
				_itemDepartments.Add(itemListId, departmentListId);
			}
		}

		public string GetItemDepartment(string itemListId)
		{
			if (_itemDepartments.ContainsKey(itemListId))
			{
				return _itemDepartments[itemListId];
			}

			return "XXX";
		}

	}
}
