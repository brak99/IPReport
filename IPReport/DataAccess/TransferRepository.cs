using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using IPReport.Util;
using System.Windows;

namespace IPReport.DataAccess
{
	public class TransferRepository : QuickBooksRepository
	{
		public static XmlNodeList GetTransfersForMonthFromStore(DateTime startDate, int fromStore)
		{
			XmlNodeList voucherList = null;

			XmlDocument requestXmlDoc = CreateBaseDocument();

			XmlElement qbposxmlmsgsrq = CreateXmlMsgRequest(requestXmlDoc);

			XmlElement transferQueryRequest = requestXmlDoc.CreateElement("TransferSlipQueryRq");
			qbposxmlmsgsrq.AppendChild(transferQueryRequest);

			XmlElement timeCreatedFilter = requestXmlDoc.CreateElement("TimeCreatedRangeFilter");
			transferQueryRequest.AppendChild(timeCreatedFilter);
			XmlElement fromTimeCreated = requestXmlDoc.CreateElement("FromTimeCreated");
			timeCreatedFilter.AppendChild(fromTimeCreated);
			DateTime start = DateUtil.FirstDayOfMonthFromDateTime(startDate);
			fromTimeCreated.InnerText = start.ToString("yyyy-MM-dd");

			XmlElement toTimeCreated = requestXmlDoc.CreateElement("ToTimeCreated");
			timeCreatedFilter.AppendChild(toTimeCreated);
			DateTime end = DateUtil.LastDayOfMonthFromDateTime(startDate);
			toTimeCreated.InnerText = end.ToString("yyyy-MM-dd");

			XmlElement fromStoreNumberFilter = requestXmlDoc.CreateElement("FromStoreNumberFilter");
			transferQueryRequest.AppendChild(fromStoreNumberFilter);

			XmlElement matchNumberCriterion = requestXmlDoc.CreateElement("MatchNumericCriterion");
			fromStoreNumberFilter.AppendChild(matchNumberCriterion);
			matchNumberCriterion.InnerText = "Equal";
			
			XmlElement fromStoreNumber = requestXmlDoc.CreateElement("FromStoreNumber");
			fromStoreNumberFilter.AppendChild(fromStoreNumber);
			fromStoreNumber.InnerText = fromStore.ToString();

			//MessageBox.Show(requestXmlDoc.OuterXml);
			XmlDocument responseXmlDoc = Query(requestXmlDoc);
			//MessageBox.Show(responseXmlDoc.OuterXml);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("TransferSlipQueryRs");

			if (responseList.Count > 0)
			{
				voucherList = responseList[0].SelectNodes("//TransferSlipRet");
			}

			return voucherList;
		}

		public static XmlNodeList GetTransfersForMonthToStore(DateTime startDate, int fromStore)
		{
			XmlNodeList voucherList = null;

			XmlDocument requestXmlDoc = CreateBaseDocument();

			//Create the outer request envelope tag
			XmlElement qbposxml = requestXmlDoc.CreateElement("QBPOSXML");
			requestXmlDoc.AppendChild(qbposxml);

			//Create the inner request envelope & any needed attributes
			XmlElement qbposxmlmsgsrq = requestXmlDoc.CreateElement("QBPOSXMLMsgsRq");
			qbposxml.AppendChild(qbposxmlmsgsrq);
			qbposxmlmsgsrq.SetAttribute("onError", "stopOnError");

			XmlElement transferQueryRequest = requestXmlDoc.CreateElement("TransferSlipQueryRq");
			qbposxmlmsgsrq.AppendChild(transferQueryRequest);

			XmlElement timeCreatedFilter = requestXmlDoc.CreateElement("TimeCreatedRangeFilter");
			transferQueryRequest.AppendChild(timeCreatedFilter);
			XmlElement fromTimeCreated = requestXmlDoc.CreateElement("FromTimeCreated");
			timeCreatedFilter.AppendChild(fromTimeCreated);
			DateTime start = DateUtil.FirstDayOfMonthFromDateTime(startDate);
            fromTimeCreated.InnerText = DateUtil.FormatDate(start);

			XmlElement toTimeCreated = requestXmlDoc.CreateElement("ToTimeCreated");
			timeCreatedFilter.AppendChild(toTimeCreated);
			DateTime end = DateUtil.LastDayOfMonthFromDateTime(startDate);
            toTimeCreated.InnerText = DateUtil.FormatDate(end);

			XmlElement toStoreNumberFilter = requestXmlDoc.CreateElement("ToStoreNumberFilter");
			transferQueryRequest.AppendChild(toStoreNumberFilter);

			XmlElement matchNumberCriterion = requestXmlDoc.CreateElement("MatchNumericCriterion");
			toStoreNumberFilter.AppendChild(matchNumberCriterion);
			matchNumberCriterion.InnerText = "Equal";

			XmlElement fromStoreNumber = requestXmlDoc.CreateElement("ToStoreNumber");
			toStoreNumberFilter.AppendChild(fromStoreNumber);
			fromStoreNumber.InnerText = fromStore.ToString();

			IQuickBooksQueryService queryService = ServiceContainer.Instance.GetService<IQuickBooksQueryService>();

			XmlDocument responseXmlDoc = Query(requestXmlDoc);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("TransferSlipQueryRs");

			if (responseList.Count > 0)
			{
				voucherList = responseList[0].SelectNodes("//TransferSlipRet");
			}
			
			return voucherList;
		}
	}
}
