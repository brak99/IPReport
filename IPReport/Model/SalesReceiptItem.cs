using System.Xml;

namespace IPReport.Model
{
	public class SalesReceiptItem : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string Discount { get { return GetNodeInnerText("Discount"); } }
		public string Markup { get { return "0.0"; } }
		public string Qty { get { return GetNodeInnerText("Qty"); } }
		public string Price { get { return GetNodeInnerText("Price"); } }
		public string Desc1 { get { return GetNodeInnerText("Desc1"); } }
		public string Desc2 { get { return GetNodeInnerText("Desc2"); } }

		public SalesReceiptItem(XmlNode node)
			: base(node)
		{

		}
	}
}
