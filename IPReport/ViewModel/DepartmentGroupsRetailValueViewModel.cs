using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;
using System.Collections.ObjectModel;
using IPReport.DataAccess;

namespace IPReport.ViewModel
{
	public class DepartmentGroupsRetailValueViewModel : WorkspaceViewModel
	{
		public ObservableCollection<StoreReportItem> _departmentGroupRetailValues;

		public ObservableCollection<StoreReportItem> GroupRetailValues
		{
			get { return _departmentGroupRetailValues; }
		}

		private DepartmentGroupsRetailValueViewModel()
		{
			
			DepartmentGroupsRepository groupRepository = new DepartmentGroupsRepository();

			foreach (Store store in StoreRepository.Instance.Stores)
			{
				foreach (DepartmentGroup departmentGroup in groupRepository.Groups)
				{
					//List<string> group = new List<string>();
					//StoreReportItem storeReportItem = StoreReportItem.GetReportItem(store, departmentGroup.Departments);
					//_departmentGroupRetailValues.Add(storeReportItem);
				}
			}
	
		}

		public static DepartmentGroupsRetailValueViewModel GetInstance()
		{
			DepartmentGroupsRetailValueViewModel departmentRetailValue = new DepartmentGroupsRetailValueViewModel();

			departmentRetailValue.DisplayName = "Retail Value";

			return departmentRetailValue;
		}
	}
}
