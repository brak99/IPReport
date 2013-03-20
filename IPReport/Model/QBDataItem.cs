using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace IPReport.Model
{
	public abstract class QBDataItem
	{
		private XmlNode _node;

		protected System.Xml.XmlNode Node
		{
			get { return _node; }
			private set { _node = value; }
		}

		internal QBDataItem(XmlNode node)
		{
			_node = node;
		}

		protected string GetNodeInnerText(string attributeName)
		{
			string returnValue = "";

			try
			{
				XmlElement element = _node[attributeName];
				returnValue = element.InnerText;
			}
			catch (System.Exception)
			{

			}

			return returnValue;
		}
	}
}
