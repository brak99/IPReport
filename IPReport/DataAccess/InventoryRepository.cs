using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using IPReport.Util;
using IPReport.Model;

namespace IPReport.DataAccess
{
	public class InventoryRepository : QuickBooksRepository, IRetailCost
	{
		public static XmlNodeList GetInventory(string departmentId)
		{
			XmlNodeList inventoryList = null;

			XmlDocument requestXmlDoc = CreateBaseDocument();

			XmlElement itemInventoryRequest = CreateInventoryQuery(requestXmlDoc);

			XmlElement departmentListId = requestXmlDoc.CreateElement("DepartmentListID");
			itemInventoryRequest.AppendChild(departmentListId);
			departmentListId.InnerText = departmentId;

			XmlDocument responseXmlDoc = Query(requestXmlDoc);
			
			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("ItemInventoryQueryRs");

			if (responseList.Count > 0)
			{
				inventoryList = responseList[0].SelectNodes("//ItemInventoryRet");
			}

			return inventoryList;
		}

		private static XmlElement CreateInventoryQuery(XmlDocument requestXmlDoc)
		{
			XmlElement qbposxmlmsgsrq = CreateXmlMsgRequest(requestXmlDoc);
			
			XmlElement itemInventoryRequest = requestXmlDoc.CreateElement("ItemInventoryQueryRq");
			qbposxmlmsgsrq.AppendChild(itemInventoryRequest);

			return itemInventoryRequest;
		}


		public decimal RetailCostByListId(string listId)
		{
			decimal retailCost = 0.0M;

			XmlNodeList inventoryList = null;

			XmlDocument requestXmlDoc = CreateBaseDocument();

			XmlElement itemInventoryRequest = CreateInventoryQuery(requestXmlDoc);

			XmlElement listIdElement = requestXmlDoc.CreateElement("ListID");
			itemInventoryRequest.AppendChild(listIdElement);
			listIdElement.InnerText = listId;

			XmlDocument responseXmlDoc = Query(requestXmlDoc);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("ItemInventoryQueryRs");

			if (responseList.Count > 0)
			{
				inventoryList = responseList[0].SelectNodes("//ItemInventoryRet");
				//expecting only one
				XmlNode itemNode = inventoryList[0];
				ItemInventory itemInventory = new ItemInventory(itemNode);

				retailCost = Convert.ToDecimal(itemInventory.Price1);
			}

			return retailCost;
		}
	}
}
