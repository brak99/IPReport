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
	public class TimeEntryRepository : QuickBooksRepository
	{
		public static XmlNodeList GetTimeEntries(DateTime startDate, DateTime endDate)
		{
			XmlNodeList timeEntryList = null;

            XmlDocument requestXmlDoc = TimeEntriesRequest(startDate, endDate);

			XmlDocument responseXmlDoc = Query(requestXmlDoc);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("TimeEntryQueryRs");

			if (responseList.Count > 0)
			{
				timeEntryList = responseList[0].SelectNodes("//TimeEntryRet");
			}

			return timeEntryList;
		}

        protected static XmlDocument TimeEntriesRequest(DateTime startDate, DateTime endDate)
        {
            XmlDocument requestXmlDoc = CreateBaseDocument();

            XmlElement qbposxmlmsgsrq = CreateXmlMsgRequest(requestXmlDoc);

            XmlElement timeEntryQuery = requestXmlDoc.CreateElement("TimeEntryQueryRq");
            qbposxmlmsgsrq.AppendChild(timeEntryQuery);

            XmlElement clockInRangeFilter = requestXmlDoc.CreateElement("ClockInTimeRangeFilter");
            timeEntryQuery.AppendChild(clockInRangeFilter);
            
            XmlElement fromClockInTime = requestXmlDoc.CreateElement("FromClockInTime");
            clockInRangeFilter.AppendChild(fromClockInTime);
            fromClockInTime.InnerText = DateUtil.FormatDate(startDate);
            
            XmlElement toClockInTime = requestXmlDoc.CreateElement("ToClockInTime");
            clockInRangeFilter.AppendChild(toClockInTime);
            toClockInTime.InnerText = DateUtil.FormatDate(endDate);

            return requestXmlDoc;
        }

        protected static XmlDocument TimeEntriesRequest(DateTime startDate, DateTime endDate, int storeNumber)
        {
            XmlDocument requestXmlDoc = TimeEntriesRequest(startDate, endDate);

            XmlElement timeEntryQuery = (XmlElement)requestXmlDoc.GetElementsByTagName("TimeEntryQueryRq").Item(0);

            XmlElement storeNumberFilter = requestXmlDoc.CreateElement("StoreNumberFilter");
            timeEntryQuery.AppendChild(storeNumberFilter);

            XmlElement matchNumberCriterion = requestXmlDoc.CreateElement("MatchNumericCriterion");
            storeNumberFilter.AppendChild(matchNumberCriterion);
            matchNumberCriterion.InnerText = "Equal";

            XmlElement toStoreNumber = requestXmlDoc.CreateElement("StoreNumber");
            storeNumberFilter.AppendChild(toStoreNumber);
            toStoreNumber.InnerText = storeNumber.ToString();

            return requestXmlDoc;
        }
	}
}
