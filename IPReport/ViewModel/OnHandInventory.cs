using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Util;
using System.Xml;
using IPReport.Model;
using System.Collections;
using System.Windows;

namespace IPReport.ViewModel
{
	public class OnHandInventory
	{
		protected List<Department> _departments = new List<Department>();

		public List<Department> Departments
		{
			get { return _departments; }
			private set { _departments = value; }
		}

		public OnHandInventory()
		{

		}

		public void GetAllDepartments()
		{
			Departments.Clear();

			IQuickBooksQueryService queryService = ServiceContainer.Instance.GetService<IQuickBooksQueryService>();

			XmlDocument requestXmlDoc = CreateBaseDocument();

			//Create the outer request envelope tag
			XmlElement qbposxml = requestXmlDoc.CreateElement("QBPOSXML");
			requestXmlDoc.AppendChild(qbposxml);

			//Create the inner request envelope & any needed attributes
			XmlElement qbposxmlmsgsrq = requestXmlDoc.CreateElement("QBPOSXMLMsgsRq");
			qbposxml.AppendChild(qbposxmlmsgsrq);
			qbposxmlmsgsrq.SetAttribute("onError", "stopOnError");

			XmlElement departmentQueryRequest = requestXmlDoc.CreateElement("DepartmentQueryRq");
			qbposxmlmsgsrq.AppendChild(departmentQueryRequest);

			string departmentsResponse = queryService.Query(requestXmlDoc.OuterXml);

			//MessageBox.Show(departmentsResponse, "dept query");

			//Parse the response XML string into an XmlDocument
			XmlDocument responseXmlDoc = new XmlDocument();
			responseXmlDoc.LoadXml(departmentsResponse);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("DepartmentQueryRs");

			if (responseList.Count > 0)
			{
				XmlNodeList departmentNodes = responseList[0].SelectNodes("//DepartmentRet");

				foreach (XmlNode node in departmentNodes)
				{
					Department department = new Department(node);
					_departments.Add(department);
				}
			}
			
		}

		public XmlNodeList GetInventory(Department department)
		{
			XmlNodeList inventoryList = null;

			XmlDocument requestXmlDoc = CreateBaseDocument();

			//Create the outer request envelope tag
			XmlElement qbposxml = requestXmlDoc.CreateElement("QBPOSXML");
			requestXmlDoc.AppendChild(qbposxml);

			//Create the inner request envelope & any needed attributes
			XmlElement qbposxmlmsgsrq = requestXmlDoc.CreateElement("QBPOSXMLMsgsRq");
			qbposxml.AppendChild(qbposxmlmsgsrq);
			qbposxmlmsgsrq.SetAttribute("onError", "stopOnError");

			XmlElement departmentQueryRequest = requestXmlDoc.CreateElement("ItemInventoryQueryRq");
			qbposxmlmsgsrq.AppendChild(departmentQueryRequest);

			XmlElement departmentListId = requestXmlDoc.CreateElement("DepartmentListID");
			departmentQueryRequest.AppendChild(departmentListId);
			departmentListId.InnerText = department.ListID;

			IQuickBooksQueryService queryService = ServiceContainer.Instance.GetService<IQuickBooksQueryService>();

			string inventoryResponse = queryService.Query(requestXmlDoc.OuterXml);

			//MessageBox.Show(inventoryResponse, "inventory for " + department.DepartmentName);

			//Parse the response XML string into an XmlDocument
			XmlDocument responseXmlDoc = new XmlDocument();
			responseXmlDoc.LoadXml(inventoryResponse);

			XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("ItemInventoryQueryRs");

			if (responseList.Count > 0)
			{
				inventoryList = responseList[0].SelectNodes("//ItemInventoryRet");

				foreach (XmlNode inventoryNode in inventoryList)
				{
					ItemInventory itemInventory = new ItemInventory(inventoryNode);


				}
			}
			
			return inventoryList;
		}

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
	}
}
