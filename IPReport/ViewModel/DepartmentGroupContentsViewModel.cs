using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;
using IPReport.DataAccess;

namespace IPReport.ViewModel
{
	public class DepartmentGroupContentsViewModel : WorkspaceViewModel
	{
		private DepartmentGroupViewModel _departmentGroupViewModel;

		private List<Tuple<bool, Department>> _departments;

		public override string DisplayName
		{
			get { return "Department Groups"; }
		}

		public string DepartmentsList
		{
			get
			{
				string departmentList = "";

				foreach (DepartmentViewModel departmentViewModel in _departmentGroupViewModel.Departments)
				{
					departmentList += departmentViewModel.Code + ", ";
				}

				if (departmentList.Length > 1)
				{
					char[] toTrim = {',', ' '};
					departmentList.TrimEnd(toTrim);
				}

				return departmentList;
			}
		}
		private DepartmentGroupContentsViewModel(DepartmentGroupViewModel departmentGroupViewModel)
		{
			_departmentGroupViewModel = departmentGroupViewModel;

			GetAllDepartments();
			
		}

		public static DepartmentGroupContentsViewModel GetInstance(DepartmentGroupViewModel departmentGroupViewModel)
		{
			return new DepartmentGroupContentsViewModel(departmentGroupViewModel);
		}

		private void GetAllDepartments()
		{
			foreach (Department department in DepartmentRepository.Instance.Departments)
			{
				bool selected = false;

				foreach (DepartmentViewModel departmentViewModel in _departmentGroupViewModel.Departments)
				{
					if (String.Compare(departmentViewModel.Code, department.DepartmentCode, StringComparison.OrdinalIgnoreCase) == 0)
					{
						selected = true;
						break;
					}
				}

				_departments.Add(new Tuple<bool, Department>(selected, department));
			}
		}
	}
}
