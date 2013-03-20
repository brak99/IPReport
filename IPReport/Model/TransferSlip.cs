using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPReport.Model
{
	public class TransferSlip : QBDataItem
	{
		private List<TransferSlipItem> _items;
		public List<TransferSlipItem> Items
		{
			get { return _items; }
			private set { _items = value; }
		}

		public string TxnID { get { return GetNodeInnerText("TxnID"); } }
		public string ItemsCount { get { return GetNodeInnerText("ItemsCount"); } }
		public string ToStoreNumber { get { return GetNodeInnerText("ToStoreNumber"); } }
		public string FromStoreNumber { get { return GetNodeInnerText("FromStoreNumber"); } }
		public string TotalCost { get { return GetNodeInnerText("TotalCost"); } }

		public TransferSlip(XmlNode node)
			: base(node)
		{
			_items = new List<TransferSlipItem>();

			GetItems();
		}

		private void GetItems()
		{
			XmlNodeList itemList = Node.SelectNodes("./TransferSlipItemRet");
			if (itemList != null)
			{
				foreach (XmlNode itemNode in itemList)
				{
					TransferSlipItem item = new TransferSlipItem(itemNode);
					_items.Add(item);
				}
			}
		}
	}
}
