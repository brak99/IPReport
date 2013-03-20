using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPReport.Model
{
	public class TransferSlipItem : QBDataItem
	{
		public string ListID { get { return GetNodeInnerText("ListID"); } }
		public string Qty { get { return GetNodeInnerText("Qty"); } }
		public string NumberOfBaseUnits { get { return GetNodeInnerText("NumberOfBaseUnits"); } }

		public TransferSlipItem(XmlNode node)
			: base(node)
		{

		}

	}
}
