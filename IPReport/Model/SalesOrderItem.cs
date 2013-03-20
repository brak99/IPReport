using System.Xml;

namespace IPReport.Model
{
	public class SalesOrderItem : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string TxnLineID { get { return GetNodeInnerText("TxnLineID"); } }
		public string Discount { get { return GetNodeInnerText("Discount"); } }
		public string Qty { get { return GetNodeInnerText("Qty"); } }
		public string QtySold { get { return GetNodeInnerText("QtySold"); } }
		public string Price { get { return GetNodeInnerText("Price"); } }

		public SalesOrderItem(XmlNode node)
			: base(node)
		{

		}
	}
}
