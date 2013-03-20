using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;
using System.Collections.ObjectModel;
using IPReport.DataAccess;

namespace IPReport.ViewModel
{
	public class DepartmentRetailValueViewModel : WorkspaceViewModel
	{
		public ObservableCollection<StoreReportItem> _departmentGroupRetailValues;

		public ObservableCollection<StoreReportItem> GroupRetailValues
		{
			get { return _departmentGroupRetailValues; }
		}

		private DepartmentRetailValueViewModel()
		{
			
			DepartmentGroupsRepository groupRepository = new DepartmentGroupsRepository();

			foreach (Store store in StoreRepository.Instance.Stores)
			{
				//foreach (Department department in store.Departments)
				//{
				//    List<string> group = new List<string>();
				//    StoreReportItem storeReportItem = StoreReportItem.GetReportItem(store, departmentGroup.Departments);
				//    _departmentGroupRetailValues.Add(storeReportItem);
				//}
			}
	
		}

		public static DepartmentRetailValueViewModel GetInstance()
		{
			DepartmentRetailValueViewModel departmentRetailValue = new DepartmentRetailValueViewModel();

			departmentRetailValue.DisplayName = "Dep Retail Value";

			return departmentRetailValue;
		}
	}
}
