using System.Collections.Generic;
using System.Xml;

namespace IPReport.Model
{
	public class SalesReceipt : QBDataItem
	{
		private List<SalesReceiptItem> _items;
		public List<SalesReceiptItem> Items
		{
			get { return _items; }
			private set { _items = value; }
		}

		public string TxnID { get { return GetNodeInnerText("TxnID"); } }
		public string ItemsCount { get { return GetNodeInnerText("ItemsCount"); } }
		public string Subtotal { get { return GetNodeInnerText("Subtotal"); } }
		public string Discount { get { return GetNodeInnerText("Discount"); } }
        public string Associate { get { return GetNodeInnerText("Associate"); } }
        public string Cashier { get { return GetNodeInnerText("Cashier"); } }

		public SalesReceipt(XmlNode node)
			: base(node)
		{
			_items = new List<SalesReceiptItem>();

			GetItems();	
		}

		private void GetItems()
		{
			XmlNodeList itemList = Node.SelectNodes("./SalesReceiptItemRet");
			if (itemList != null)
			{
				foreach (XmlNode itemNode in itemList)
				{
					SalesReceiptItem item = new SalesReceiptItem(itemNode);
					_items.Add(item);
				}
			}
		}
	}
}
