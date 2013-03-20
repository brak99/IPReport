using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using IPReport.Model;
using System.ComponentModel;
using IPReport.DataAccess;

namespace IPReport.ViewModel
{
	public class DepartmentSelect : INotifyPropertyChanged
	{
		public Department Department {get; set;}

		private bool _selected;
		public bool Selected 
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				OnPropertyChanged("Selected");
			}
		}
		public bool CanEdit
		{
			get;
			set;
		}
		
		#region INotifyPropertyChanged Members

		/// <summary>
		/// Raised when a property on this object has a new value.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises this object's PropertyChanged event.
		/// </summary>
		/// <param name="propertyName">The property that has a new value.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}

		#endregion // INotifyPropertyChanged Members
	}

	public class EditDepartmentGroupViewModel : WorkspaceViewModel
	{
		public ObservableCollection<DepartmentSelect> _selectedDepartments = new ObservableCollection<DepartmentSelect>();
		public ObservableCollection<DepartmentSelect> SelectedDepartments
		{
			get { return _selectedDepartments; }
			set { _selectedDepartments = value; }
		}

		public string Name
		{
			get { return _groupViewModel.Name; }
			set 
			{ 
				_groupViewModel.Name = value;
				base.OnPropertyChanged("Name");
			}
		}
		private DepartmentGroupViewModel _groupViewModel;

		private EditDepartmentGroupViewModel(DepartmentGroupViewModel groupViewModel)
		{
			_groupViewModel = groupViewModel;

			AllDepartmentsViewModel allDepartments = AllDepartmentsViewModel.GetInstance();

			foreach (Department department in allDepartments.Departments)
			{
				DepartmentSelect departmentSelect = new DepartmentSelect();
				departmentSelect.Department = department;
				departmentSelect.Selected = IsDepartmentInGroup(department.DepartmentCode);
				departmentSelect.CanEdit = !ReadOnly;
				
				_selectedDepartments.Add(departmentSelect);
				departmentSelect.PropertyChanged += DepartmentSelectChanged;
			}
		}

		public static EditDepartmentGroupViewModel GetInstance(DepartmentGroupViewModel groupViewModel)
		{
			return new EditDepartmentGroupViewModel(groupViewModel);
		}

		private void DepartmentSelectChanged(object sender, PropertyChangedEventArgs args)
		{
			if (String.Compare("Selected", args.PropertyName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				DepartmentSelect departmentSelect = sender as DepartmentSelect;
				if (departmentSelect.Selected)
				{
					_groupViewModel.AddDepartment(departmentSelect.Department.DepartmentCode);
				}
				else
				{
					_groupViewModel.RemoveDepartment(departmentSelect.Department.DepartmentCode);
				}

				base.OnPropertyChanged("DepartmentsList");

				DepartmentGroupsRepository.Instance.SaveDepartmentGroups();
			}
			else if (String.Compare("Selected", args.PropertyName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				DepartmentSelect departmentSelect = sender as DepartmentSelect;
			}
		}

		private bool IsDepartmentInGroup(string departmentCode)
		{
			bool departmentInGroup = false;
			foreach (DepartmentViewModel department in _groupViewModel.Departments)
			{
				if (String.Compare(department.Code, departmentCode, StringComparison.OrdinalIgnoreCase) == 0)
				{
					departmentInGroup = true;
					break;
				}
			}
			return departmentInGroup;
		}
		public string DepartmentsList
		{
			get
			{
				string departmentList = "";

				foreach (string department in _groupViewModel.DepartmentGroup.Departments)
				{
					departmentList += department + ", ";
				}

				if (departmentList.Length > 1)
				{
					char[] toTrim = { ',', ' ' };
					departmentList = departmentList.TrimEnd(toTrim);
				}

				return departmentList;
			}
		}


		public bool ReadOnly
		{
			get
			{
				return _groupViewModel.ReadOnly;
			}
		}

		public bool CanEdit
		{
			get
			{
				return !_groupViewModel.ReadOnly;
			}
		}
	}
}
