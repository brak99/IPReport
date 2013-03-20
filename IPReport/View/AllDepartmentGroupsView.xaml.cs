using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IPReport.View
{
	/// <summary>
	/// Interaction logic for AllDepartmentGroupsView.xaml
	/// </summary>
	public partial class AllDepartmentGroupsView : UserControl
	{
		private ICommand _addGroupCommand;
		public ICommand AddGroupCommand
		{
			get
			{
				if (_addGroupCommand == null)
				{
					_addGroupCommand = new DelegateCommand<object>(param => this.AddGroup(param, null));
				}

				return _addGroupCommand;
			}
		}

		private void AddGroup(object sender, RoutedEventArgs e)
		{
			
		}

		public bool CanAddGroup
		{
			get
			{
				return true;
			}
		}

		private ICommand _deleteGroupCommand;
		public ICommand DeleteGroupCommand
		{
			get
			{
				if (_deleteGroupCommand == null)
				{
					_deleteGroupCommand = new DelegateCommand<object>(param => this.DeleteGroup(param, null));
				}

				return _deleteGroupCommand;
			}
		}

		private void DeleteGroup(object sender, RoutedEventArgs e)
		{
			
		}

		public bool CanDeleteGroup
		{
			get
			{
				return DepartmentGroupsListView.SelectedItems.Count > 0;
			}
		}

		private ICommand _editGroupCommand;
		public ICommand EditGroupCommand
		{
			get
			{
				if (_editGroupCommand == null)
				{
					_editGroupCommand = new DelegateCommand<object>(param => this.EditGroup(param, null));
				}

				return _editGroupCommand;
			}
		}

		private void EditGroup(object sender, RoutedEventArgs e)
		{

		}

		public bool CanEditGroup
		{
			get
			{
				return DepartmentGroupsListView.SelectedItems.Count > 0;
			}
		}
		public AllDepartmentGroupsView()
		{
			InitializeComponent();
		}
	}
}
