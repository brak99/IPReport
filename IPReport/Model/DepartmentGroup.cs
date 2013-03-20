using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ComponentModel;

namespace IPReport.Model
{
	public class DepartmentGroup : INotifyPropertyChanged
	{
		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (String.Compare(_name, value, StringComparison.Ordinal) != 0)
				{
					_name = value;
					OnPropertyChanged("Name");
				}
			}
		}

		public bool ReadOnly
		{
			get;
			private set;
		}
		private List<string> _departments = new List<string>();

		public List<string> Departments
		{
			get { return _departments; }
		}

		public void AddDepartment(string departmentCode)
		{
			Departments.Add(departmentCode);
		}

		public void RemoveDepartment(string departmentCode)
		{
			Departments.Remove(departmentCode);
		}

		private DepartmentGroup()
		{
			ReadOnly = false;
		}

		public static DepartmentGroup GetInstance(string name)
		{
			DepartmentGroup departmentGroup = new DepartmentGroup();
			departmentGroup.Name = name;

			return departmentGroup;
		}

		public static DepartmentGroup GetReadOnlyInstance(string name)
		{
			DepartmentGroup departmentGroup = new DepartmentGroup();
			departmentGroup.Name = name;
			departmentGroup.ReadOnly = true;

			return departmentGroup;
		}
		public static DepartmentGroup GetInstance(XElement element)
		{
			DepartmentGroup departmentGroup = new DepartmentGroup();
			departmentGroup.Name = (string)element.Element("Name");

			foreach (XElement departmentElement in element.Elements("Department"))
			{
				departmentGroup.AddDepartment(departmentElement.Value);
			}

			return departmentGroup;
		}

		public XElement ToXml()
		{
			XElement group = new XElement("Group");

			XElement name = new XElement("Name", Name);		
			group.Add(name);

			foreach (string department in _departments)
			{
				XElement departmentElement = new XElement("Department", department);
				group.Add(departmentElement);
			}

			return group;
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
            //this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
	}
}
