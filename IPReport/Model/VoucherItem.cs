using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPReport.Model
{
	public class VoucherItem : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string Cost { get { return GetNodeInnerText("Cost"); } }
		public string Desc1 { get { return GetNodeInnerText("Cost"); } }
		public string Desc2 { get { return GetNodeInnerText("Cost"); } }
		public string QtyReceived { get { return GetNodeInnerText("QtyReceived"); } }

		public VoucherItem(XmlNode node)
			: base(node)
		{

		}
	}
}
