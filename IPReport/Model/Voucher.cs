using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPReport.Model
{
	public class Voucher : QBDataItem
	{
		private List<VoucherItem> _items;
		public List<VoucherItem> Items
		{
			get { return _items; }
			private set { _items = value; }
		}

		public string TxnID { get { return GetNodeInnerText("TxnID"); } }
		public string ItemsCount { get { return GetNodeInnerText("ItemsCount"); } }
		public string Total { get { return GetNodeInnerText("Total"); } }
		public string TotalQty { get { return GetNodeInnerText("TotalQty"); } }
		public string StoreNumber { get { return GetNodeInnerText("StoreNumber"); } }
		public string Subtotal { get { return GetNodeInnerText("Subtotal"); } }

		public Voucher(XmlNode node)
			: base(node)
		{
			_items = new List<VoucherItem>();

			GetItems();
		}

		private void GetItems()
		{
			XmlNodeList itemList = Node.SelectNodes("./VoucherItemRet");
			if (itemList != null)
			{
				foreach (XmlNode itemNode in itemList)
				{
					VoucherItem item = new VoucherItem(itemNode);
					_items.Add(item);
				}
			}
		}
	}
}
