using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using IPReport.Model;
using IPReport.Util;
using System.Windows;

namespace IPReport.DataAccess
{
	public class SalesRepository : QuickBooksRepository
	{
        public static XmlNodeList GetSales(DateTime startDate, DateTime endDate)
        {
            XmlNodeList salesOrderList = null;

            XmlDocument requestXmlDoc = SalesReceiptRequest(startDate, endDate);

            XmlDocument responseXmlDoc = Query(requestXmlDoc);

            XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("SalesReceiptQueryRs");

            if (responseList.Count > 0)
            {
                salesOrderList = responseList[0].SelectNodes("//SalesReceiptRet");
            }

            return salesOrderList;
        }

		public static XmlNodeList GetSales(DateTime startDate, int storeNumber)
		{
			XmlNodeList salesOrderList = null;

            XmlDocument requestXmlDoc = SalesReceiptRequest(startDate, storeNumber);

			XmlDocument responseXmlDoc = Query(requestXmlDoc);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("SalesReceiptQueryRs");

			if (responseList.Count > 0)
			{
				salesOrderList = responseList[0].SelectNodes("//SalesReceiptRet");
			}

			return salesOrderList;
		}

        protected static XmlDocument SalesReceiptRequest(DateTime startDate, int storeNumber)
        {
            DateTime end = DateUtil.LastDayOfMonthFromDateTime(startDate);

            XmlDocument requestXmlDoc = SalesReceiptRequest(startDate, end);
            
            XmlElement storeNumberFilter = requestXmlDoc.CreateElement("StoreNumberFilter");
            XmlElement salesReceiptQuery = (XmlElement)requestXmlDoc.GetElementsByTagName("SalesReceiptQueryRq")[0];

            salesReceiptQuery.AppendChild(storeNumberFilter);
            XmlElement matchNumberCriterion = requestXmlDoc.CreateElement("MatchNumericCriterion");
            matchNumberCriterion.InnerText = "Equal";
            storeNumberFilter.AppendChild(matchNumberCriterion);
            XmlElement storeNumberElement = requestXmlDoc.CreateElement("StoreNumber");
            storeNumberElement.InnerText = storeNumber.ToString();
            storeNumberFilter.AppendChild(storeNumberElement);

            return requestXmlDoc;
        }

        protected static XmlDocument SalesReceiptRequest(DateTime startDate, DateTime endDate)
        {
            XmlDocument requestXmlDoc = CreateBaseDocument();

            XmlElement qbposxmlmsgsrq = CreateXmlMsgRequest(requestXmlDoc);

            XmlElement salesReceiptQuery = requestXmlDoc.CreateElement("SalesReceiptQueryRq");
            qbposxmlmsgsrq.AppendChild(salesReceiptQuery);

            XmlElement timeCreatedFilter = requestXmlDoc.CreateElement("TimeCreatedRangeFilter");
            salesReceiptQuery.AppendChild(timeCreatedFilter);
            XmlElement fromTimeCreated = requestXmlDoc.CreateElement("FromTimeCreated");
            timeCreatedFilter.AppendChild(fromTimeCreated);
            
            fromTimeCreated.InnerText = DateUtil.FormatDate(startDate);

            XmlElement toTimeCreated = requestXmlDoc.CreateElement("ToTimeCreated");
            timeCreatedFilter.AppendChild(toTimeCreated);
            
            toTimeCreated.InnerText = DateUtil.FormatDate(endDate);

            return requestXmlDoc;
        }
	}
}
