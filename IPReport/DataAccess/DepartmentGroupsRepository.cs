using System.Collections.Generic;
using IPReport.Model;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System;

namespace IPReport.DataAccess
{
	public class DepartmentGroupsRepository
	{
		private object _lockObject = new object();

		public static readonly DepartmentGroupsRepository Instance = new DepartmentGroupsRepository();

		private List<DepartmentGroup> _groups = new List<DepartmentGroup>();

		public ReadOnlyCollection<DepartmentGroup> Groups
		{
			get { return _groups.AsReadOnly(); }
		}

		private DepartmentGroupsRepository()
		{
			LoadDepartmentGroups(DepartmentGroupsLocation());
		}

		private string DepartmentGroupsLocation()
		{
			string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string fullPath = Path.Combine(commonApplicationData, "departmentgroups.xml");
			return fullPath;
		}

		void LoadDepartmentGroups(string departmentGroupsDataFile)
		{
			try
			{
				lock (_lockObject)
				{
					using (Stream stream = new FileStream(departmentGroupsDataFile, FileMode.OpenOrCreate))
					using (XmlReader reader = new XmlTextReader(stream))
					{
						XElement groupsElement = XDocument.Load(reader).Element("groups");

						foreach (XElement groupElement in groupsElement.Elements("Group"))
						{
							DepartmentGroup departmentGroup = DepartmentGroup.GetInstance(groupElement);

							_groups.Add(departmentGroup);
						}
					}
				}
				
				
			}
			catch (System.Exception)
			{
				
			}
		}

		public void SaveDepartmentGroups()
		{
			string departmentGroupsDataFile = DepartmentGroupsLocation();

			try
			{
				lock (_lockObject)
				{
					using (Stream stream = new FileStream(departmentGroupsDataFile, FileMode.Create, FileAccess.Write))
					{
						
						XDocument groupsDocument = new XDocument();

						XElement groupsElement = new XElement("groups");
						groupsDocument.Add(groupsElement);

						foreach (DepartmentGroup group in _groups)
						{
							XElement groupElement = group.ToXml();
							groupsElement.Add(groupElement);
						}

						groupsDocument.Save(stream);

					}
				}
				
			}
			catch (System.Exception)
			{

			}
		}

		public DepartmentGroup AddDepartmentGroup(string groupName)
		{
			DepartmentGroup departmentGroup = DepartmentGroup.GetInstance(groupName);

			_groups.Add(departmentGroup);

			return departmentGroup;
		}
	}
}
