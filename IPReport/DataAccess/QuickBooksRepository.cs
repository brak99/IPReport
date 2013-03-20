using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using IPReport.Util;

namespace IPReport.DataAccess
{
	public class QuickBooksRepository
	{
		protected static XmlDocument CreateBaseDocument()
		{
			//Create the XML document to hold our request
			XmlDocument requestXmlDoc = new XmlDocument();
			//Add the prolog processing instructions
			XmlDeclaration declaration = requestXmlDoc.CreateXmlDeclaration("1.0", null, null);
			declaration.Encoding = "utf-8";

			requestXmlDoc.AppendChild(declaration);
			requestXmlDoc.AppendChild(requestXmlDoc.CreateProcessingInstruction("qbposxml", "version=\"3.0\""));

			return requestXmlDoc;
		}

		protected static XmlDocument Query(XmlDocument requestXmlDoc)
		{
			IQuickBooksQueryService queryService = ServiceContainer.Instance.GetService<IQuickBooksQueryService>();

			string queryResponse = queryService.Query(requestXmlDoc.OuterXml);

			XmlDocument responseXmlDoc = new XmlDocument();
			if (!String.IsNullOrEmpty(queryResponse))
			{
				responseXmlDoc.LoadXml(queryResponse);
			}

			return responseXmlDoc;
		}

		protected static XmlElement CreateXmlMsgRequest(XmlDocument requestXmlDoc)
		{
			//Create the outer request envelope tag
			XmlElement qbposxml = requestXmlDoc.CreateElement("QBPOSXML");
			requestXmlDoc.AppendChild(qbposxml);

			//Create the inner request envelope & any needed attributes
			XmlElement qbposxmlmsgsrq = requestXmlDoc.CreateElement("QBPOSXMLMsgsRq");
			qbposxml.AppendChild(qbposxmlmsgsrq);
			qbposxmlmsgsrq.SetAttribute("onError", "stopOnError");

			return qbposxmlmsgsrq;
		}

	}
}
