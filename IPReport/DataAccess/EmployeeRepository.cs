using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using IPReport.Util;
using IPReport.Model;

namespace IPReport.DataAccess
{
	public class EmployeeRepository : QuickBooksRepository
	{
		public static readonly EmployeeRepository Instance = new EmployeeRepository();

		protected List<Employee> _employees = new List<Employee>();

		public List<Employee> Employees
		{
			get { return _employees; }
		}
		public void Refresh()
		{
			Employees.Clear();

			IQuickBooksQueryService queryService = ServiceContainer.Instance.GetService<IQuickBooksQueryService>();

			XmlDocument requestXmlDoc = CreateBaseDocument();

			//Create the inner request envelope & any needed attributes
			XmlElement qbposxmlmsgsrq = CreateXmlMsgRequest(requestXmlDoc);

			XmlElement employeeQueryRequest = requestXmlDoc.CreateElement("EmployeeQueryRq");
			qbposxmlmsgsrq.AppendChild(employeeQueryRequest);

			if (queryService != null)
			{
				string employeesResponse = queryService.Query(requestXmlDoc.OuterXml);

				SaveResponse(employeesResponse);

				//Parse the response XML string into an XmlDocument
				PopulateEmployees(employeesResponse);
			}
			
		}

		private void SaveResponse(string response)
		{
			try
			{
				string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				string fullPath = Path.Combine(commonApplicationData, "employees.xml");

				using (FileStream fs = new FileStream(fullPath, FileMode.Create,
									 FileAccess.Write))
				{
					StreamWriter sw = new StreamWriter(fs);
					sw.Write(response);
					sw.Flush();
				}
			}
			catch (System.Exception)
			{

			}
		}

		private void PopulateEmployees(string employeesResponse)
		{
			XmlDocument responseXmlDoc = new XmlDocument();

			if (!String.IsNullOrEmpty(employeesResponse))
			{
				responseXmlDoc.LoadXml(employeesResponse);

				XmlNodeList responseList = responseXmlDoc.GetElementsByTagName("EmployeeQueryRs");

				if (responseList.Count > 0)
				{
					XmlNodeList departmentNodes = responseList[0].SelectNodes("//EmployeeRet");

					foreach (XmlNode node in departmentNodes)
					{
						Employee employee = new Employee(node);
						_employees.Add(employee);
					}
				}


			}
		}

	}
}
