using System;
using System.Xml;
using IPReport.Util;
using System.Windows;

namespace IPReport.DataAccess
{
	public class VoucherRepository : QuickBooksRepository
	{
		public static XmlNodeList GetVouchersForMonth(DateTime startDate, int storeNumber)
		{
			//MessageBox.Show("Getting vouchers for " + startDate.ToString());
			XmlNodeList voucherList = null;

			XmlDocument requestXmlDoc = CreateBaseDocument();

			XmlElement qbposxmlmsgsrq = CreateXmlMsgRequest(requestXmlDoc);

			XmlElement voucherQueryRequest = requestXmlDoc.CreateElement("VoucherQueryRq");
			qbposxmlmsgsrq.AppendChild(voucherQueryRequest);

			XmlElement timeCreatedFilter = requestXmlDoc.CreateElement("TimeCreatedRangeFilter");
			voucherQueryRequest.AppendChild(timeCreatedFilter);
			XmlElement fromTimeCreated = requestXmlDoc.CreateElement("FromTimeCreated");
			timeCreatedFilter.AppendChild(fromTimeCreated);
			DateTime start = DateUtil.FirstDayOfMonthFromDateTime(startDate);
            fromTimeCreated.InnerText = DateUtil.FormatDate(start);

			XmlElement toTimeCreated = requestXmlDoc.CreateElement("ToTimeCreated");
			timeCreatedFilter.AppendChild(toTimeCreated);
			DateTime end = DateUtil.LastDayOfMonthFromDateTime(startDate);
            toTimeCreated.InnerText = DateUtil.FormatDate(end);

			XmlElement storeNumberFilter = requestXmlDoc.CreateElement("StoreNumberFilter");
			voucherQueryRequest.AppendChild(storeNumberFilter);
			XmlElement matchNumberCriterion = requestXmlDoc.CreateElement("MatchNumericCriterion");
			storeNumberFilter.AppendChild(matchNumberCriterion); 
			matchNumberCriterion.InnerText = "Equal";
			
			XmlElement storeNumberElement = requestXmlDoc.CreateElement("StoreNumber");
			storeNumberFilter.AppendChild(storeNumberElement);
			storeNumberElement.InnerText = storeNumber.ToString();
			

			XmlDocument responseXmlDoc = Query(requestXmlDoc);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("VoucherQueryRs");

			//MessageBox.Show(responseList.Count + "vouchers to process");

			if (responseList.Count > 0)
			{
				voucherList = responseList[0].SelectNodes("//VoucherRet");
			}
		
			return voucherList;
		}

	}
}
