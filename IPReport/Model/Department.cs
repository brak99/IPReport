using System.Xml.Linq;
using System.Xml;

namespace IPReport.Model
{
	public class Department : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string TimeCreated { get { return GetNodeInnerText("TimeCreated"); } }
		public string TimeModified { get { return GetNodeInnerText("TimeModified"); } }
		public string DefaultMarginPercent { get { return GetNodeInnerText("DefaultMarginPercent"); } }
		public string DefaultMarkupPercent { get { return GetNodeInnerText("DefaultMarkupPercent"); } }
		public string DepartmentCode { get { return GetNodeInnerText("DepartmentCode"); } }
		public string DepartmentName { get { return GetNodeInnerText("DepartmentName"); } }
		public string StoreExchangeStatus { get { return GetNodeInnerText("StoreExchangeStatus"); } }
		public string TaxCode { get { return GetNodeInnerText("TaxCode"); } }

		public Department(XmlNode departmentNode) :
			base(departmentNode)
		{
		}

		public XElement ToXml()
		{
			XElement department = new XElement("Department");
			XElement listId = new XElement("ListID", ListID);
			XElement departmentCode = new XElement("DepartmentCode", DepartmentCode);
			XElement name = new XElement("DepartmentName", DepartmentName);

			department.Add(listId);
			department.Add(departmentCode);
			department.Add(name);

			return department;
		}
	}
}
