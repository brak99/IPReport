using IPReport.Util;
using IPReport.Model;
using IPReport.DataAccess;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;

namespace IPReport.ViewModel
{
	public class GroupedStoreViewModel : WorkspaceViewModel, ISaveToXml, ISaveToCsv, ISaveToOtb
	{
		private StoreViewModel _store;
		private List<DepartmentGroup> _departments = new List<DepartmentGroup>();

		private DepartmentGroupViewModel _defaultGroupViewModel = DepartmentGroupViewModel.GetInstance(DepartmentGroup.GetReadOnlyInstance("Default"));

		private ObservableCollection<DepartmentGroupViewModel> _departmentGroups = new ObservableCollection<DepartmentGroupViewModel>();
		public ObservableCollection<DepartmentGroupViewModel> DepartmentGroups
		{
			get { return _departmentGroups; }
			private set { _departmentGroups = value; }
		}
		public static GroupedStoreViewModel GetInstance(StoreViewModel store)
		{
			return new GroupedStoreViewModel(store);
		}

		private GroupedStoreViewModel(StoreViewModel store)
		{
			_store = store;
			Refresh();
		}

		public override string DisplayName
		{
			get { return _store.DisplayName + "[Grouped]"; }
		}

		public void Refresh()
		{
			_departments.Clear();
			_departmentGroups.Clear();

			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();

			_departmentGroups.Add(_defaultGroupViewModel);

			//set up all the groups
			foreach (DepartmentGroup group in DepartmentGroupsRepository.Instance.Groups)
			{
				_departments.Add(group);
				DepartmentGroupViewModel groupViewModel = DepartmentGroupViewModel.GetInstance(group);
				_departmentGroups.Add(groupViewModel);
			}

			//add all the departments where they belong
			foreach (DepartmentViewModel departmentViewModel in _store.RetailValues)
			{
				bool foundHome = false;

				foreach (DepartmentGroupViewModel groupViewModel in _departmentGroups)
				{
					if (groupViewModel.TryAddDepartment(departmentViewModel))
					{
						foundHome = true;
						break;
					}
				}

				if (!foundHome)
				{
					_defaultGroupViewModel.ForceAddDepartment(departmentViewModel);
				}
			}
		}

		public void SaveToXml(string path)
		{
			try
			{
				using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
				{
					XDocument departmentsDocument = new XDocument();

					XElement departmentsElement = new XElement("departments");
					departmentsDocument.Add(departmentsElement);

					foreach (DepartmentGroupViewModel department in _departmentGroups)
					{
						XElement departmentElement = department.ToXml();
						departmentsElement.Add(departmentElement);
					}

					departmentsDocument.Save(stream);

				}
			}
			catch (System.Exception)
			{

			}
		}

		public void SaveToCsv(string path)
		{
			try
			{
				using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
				{
					using (StreamWriter writer = new StreamWriter(stream))
					{
						foreach (DepartmentGroupViewModel department in _departmentGroups)
						{
							string departmentElement = department.ToCsv();
							writer.WriteLine(departmentElement);
						}
					}
				}
			}
			catch (System.Exception)
			{

			}
		}

		public void SaveToOtb(string path)
		{
			try
			{
				using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
				{
					using (StreamWriter writer = new StreamWriter(stream))
					{
						foreach (DepartmentGroupViewModel department in _departmentGroups)
						{
							string departmentElement = department.ToOTB(_store.BuildingStoreNumber);
							writer.WriteLine(departmentElement);
						}
					}
				}
			}
			catch (System.Exception)
			{

			}
		}
	}
}
