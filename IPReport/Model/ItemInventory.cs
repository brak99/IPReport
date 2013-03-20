using System.Xml;

namespace IPReport.Model
{
	public class ItemInventory : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string Cost { get { return GetNodeInnerText("Cost"); } }
		public string DepartmentCode { get { return GetNodeInnerText("DepartmentCode"); } }
		public string DepartmentListID { get { return GetNodeInnerText("DepartmentListID"); } }
		public string Desc1 { get { return GetNodeInnerText("Desc1"); } }
		public string Desc2 { get { return GetNodeInnerText("Desc2"); } }
		public string ItemNumber { get { return GetNodeInnerText("ItemNumber"); } }
		public string OnHandStore01 { get { return GetNodeInnerText("OnHandStore01"); } }
		public string OnHandStore02 { get { return GetNodeInnerText("OnHandStore02"); } }
		public string OnHandStore03 { get { return GetNodeInnerText("OnHandStore03"); } }
		public string OnHandStore04 { get { return GetNodeInnerText("OnHandStore04"); } }
		public string OnHandStore05 { get { return GetNodeInnerText("OnHandStore05"); } }
		public string OnHandStore06 { get { return GetNodeInnerText("OnHandStore06"); } }
		public string OnHandStore07 { get { return GetNodeInnerText("OnHandStore07"); } }
		public string OnHandStore08 { get { return GetNodeInnerText("OnHandStore08"); } }
		public string OnHandStore09 { get { return GetNodeInnerText("OnHandStore09"); } }
		public string Price1 { get { return GetNodeInnerText("Price1"); } }
		public string Price2 { get { return GetNodeInnerText("Price2"); } }
		public string Price3 { get { return GetNodeInnerText("Price3"); } }
		public string Price4 { get { return GetNodeInnerText("Price4"); } }
		public string Price5 { get { return GetNodeInnerText("Price5"); } }
		public string Price6 { get { return GetNodeInnerText("Price6"); } }
		public string QuantityOnHand { get { return GetNodeInnerText("QuantityOnHand"); } }
		public string QuantityOnOrder { get { return GetNodeInnerText("QuantityOnOrder"); } }

		public ItemInventory(XmlNode node)
			: base(node)
		{

		}
	}
}
