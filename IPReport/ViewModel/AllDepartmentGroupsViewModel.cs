using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using System.Windows;
using IPReport.DataAccess;
using IPReport.Model;
using System.ComponentModel;
using System.Windows.Data;

namespace IPReport.ViewModel
{
	public class AllDepartmentGroupsViewModel : WorkspaceViewModel
	{
		private static int _newGroupNumber = 1;

		ObservableCollection<EditDepartmentGroupViewModel> _departmentGroups = new ObservableCollection<EditDepartmentGroupViewModel>();
		public ObservableCollection<EditDepartmentGroupViewModel> DepartmentGroups
		{
			get { return _departmentGroups; }
			private set { _departmentGroups = value; }
		}

		private AllDepartmentGroupsViewModel(ObservableCollection<DepartmentGroupViewModel> departmentGroups)
		{
			foreach (DepartmentGroupViewModel groupViewModel in departmentGroups)
			{
				_departmentGroups.Add(EditDepartmentGroupViewModel.GetInstance(groupViewModel));
			}
			
		}

		public static AllDepartmentGroupsViewModel GetInstance(ObservableCollection<DepartmentGroupViewModel> departmentGroups)
		{
			return new AllDepartmentGroupsViewModel(departmentGroups);
		}

		public override string DisplayName
		{
			get
			{
				return "All Department Groups";
			}
		}

		private DelegateCommand<object> _addDepartmentGroupCommand;
		public ICommand AddDepartmentGroupCommand
		{
			get
			{
				if (_addDepartmentGroupCommand == null)
				{
					_addDepartmentGroupCommand = new DelegateCommand<object>(param => AddDepartmentGroup(param, null));
				}

				return _addDepartmentGroupCommand;
			}
		}

		private void AddDepartmentGroup(object sender, RoutedEventArgs args)
		{
			string newGroupName = "<new group " + _newGroupNumber++ + ">";

			DepartmentGroup departmentGroup = DepartmentGroupsRepository.Instance.AddDepartmentGroup(newGroupName);

			DepartmentGroupViewModel departmentGroupViewModel = DepartmentGroupViewModel.GetInstance(departmentGroup);

			EditDepartmentGroupViewModel newEditGroup = EditDepartmentGroupViewModel.GetInstance(departmentGroupViewModel);
			_departmentGroups.Add(newEditGroup);

			ICollectionView collectionView = CollectionViewSource.GetDefaultView(_departmentGroups);

			collectionView.MoveCurrentTo(newEditGroup);
		}

		private DelegateCommand<EditDepartmentGroupViewModel> _deleteDepartmentGroupCommand;
		public ICommand DeleteDepartmentGroupCommand
		{
			get
			{
				if (_deleteDepartmentGroupCommand == null)
				{
					_deleteDepartmentGroupCommand = new DelegateCommand<EditDepartmentGroupViewModel>(param => DeleteDepartmentGroup(param, null), param => this.CanDeleteDepartmentGroup);
				}

				return _deleteDepartmentGroupCommand;
			}
		}

		private void DeleteDepartmentGroup(EditDepartmentGroupViewModel departmentGroup, RoutedEventArgs args)
		{
			if (departmentGroup != null)
			{
				_departmentGroups.Remove(departmentGroup);
			}
		}

		public bool CanDeleteDepartmentGroup
		{
			get
			{
				ICollectionView collectionView = CollectionViewSource.GetDefaultView(_departmentGroups);

				EditDepartmentGroupViewModel currentGroup = collectionView.CurrentItem as EditDepartmentGroupViewModel;

				if (currentGroup != null && !currentGroup.ReadOnly)
				{
					return true;
				}

				return false;
			}
		}
	}
}
