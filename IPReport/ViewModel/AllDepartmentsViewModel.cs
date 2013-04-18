using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;
using System.Collections.ObjectModel;
using IPReport.DataAccess;
using System.IO;
using System.Xml.Linq;
using IPReport.Util;

namespace IPReport.ViewModel
{
	public class AllDepartmentsViewModel : WorkspaceViewModel, ISaveToXml, IQuickBooksUpdate
	{
		ObservableCollection<Department> _departments = new ObservableCollection<Department>();

		public ObservableCollection<Department> Departments
		{
			get { return _departments; }
		}

		public override string DisplayName
		{
			get
			{
				return "All Departments";
			}
		}

		public static AllDepartmentsViewModel GetInstance()
		{
			return new AllDepartmentsViewModel();
		}

		private AllDepartmentsViewModel()
		{
			Refresh();
		}

        public void Update()
        {
            DepartmentRepository.Instance.Refresh();
            Refresh();
        }

		public void Refresh()
		{
			try
			{
				App.Current.Dispatcher.Invoke((Action)(() => Departments.Clear()));
			}
			catch (System.Exception ex)
			{
				Departments.Clear();
			}
			

			foreach (Department department in DepartmentRepository.Instance.Departments)
			{
				_departments.Add(department);
			}

			base.OnPropertyChanged("Departments");
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

					foreach (Department department in _departments)
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
	}
}
