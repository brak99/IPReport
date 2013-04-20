using System.Xml.Linq;
using System.Xml;

namespace IPReport.Model
{
	public class Employee : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string TimeCreated { get { return GetNodeInnerText("TimeCreated"); } }
		public string TimeModified { get { return GetNodeInnerText("TimeModified"); } }
		public string FirstName { get { return GetNodeInnerText("FirstName"); } }
		public string LastName { get { return GetNodeInnerText("LastName"); } }
		public string LoginName { get { return GetNodeInnerText("LoginName"); } }
		
		public Employee(XmlNode employeeNode) :
			base(employeeNode)
		{
		}

		public XElement ToXml()
		{
			XElement department = new XElement("Department");
			XElement listId = new XElement("ListID", ListID);
			XElement firstName = new XElement("FirstName", FirstName);
			XElement lastName = new XElement("LastName", LastName);
			XElement loginName = new XElement("LoginName", LastName);

			department.Add(listId);
			department.Add(firstName);
			department.Add(lastName);
			department.Add(loginName);

			return department;
		}
	}
}
