using System.Xml;
using System.Collections.Generic;

namespace IPReport.Model
{
	public class SalesOrder : QBDataItem
	{
		private List<SalesOrderItem> _items;
		public List<SalesOrderItem> Items
		{
			get { return _items; }
			private set { _items = value; }
		}

		public string TxnID { get { return GetNodeInnerText("TxnID"); } }
		public string ItemsCount { get { return GetNodeInnerText("ItemsCount"); } }
		public string Subtotal { get { return GetNodeInnerText("Subtotal"); } }
		public string Discount { get { return GetNodeInnerText("Discount"); } }

		public SalesOrder(XmlNode node)
			: base(node)
		{
			_items = new List<SalesOrderItem>();

			GetItems();	
		}

		private void GetItems()
		{
			XmlNodeList itemList = Node.SelectNodes("./SalesOrderItemRet");
			if (itemList != null)
			{
				foreach (XmlNode itemNode in itemList)
				{
					SalesOrderItem item = new SalesOrderItem(itemNode);
					_items.Add(item);
				}
			}
		}
	}
}
