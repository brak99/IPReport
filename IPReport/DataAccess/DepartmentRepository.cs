using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;
using IPReport.Util;
using System.Xml;
using System.IO;

namespace IPReport.DataAccess
{
	public class DepartmentRepository : QuickBooksRepository
	{
		public static readonly DepartmentRepository Instance = new DepartmentRepository();

		protected readonly List<Department> _departments = new List<Department>();

		public List<Department> Departments
		{
			get { return _departments; }
		}

		private DepartmentRepository()
		{
			try
			{
				string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				string fullPath = Path.Combine(commonApplicationData, "departments.xml");

				using (FileStream fs = new FileStream(fullPath, FileMode.Open,
									 FileAccess.Read))
				{
					StreamReader sr = new StreamReader(fs);
					string queryReturn = sr.ReadToEnd();

					PopulateDepartments(queryReturn);
				}

				if (_departments.Count == 0)
				{
					Refresh();
				}
			}
			catch (System.Exception)
			{
				
			}
		}

		public void Refresh()
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

			SaveResponse(departmentsResponse);

			//MessageBox.Show(departmentsResponse, "dept query");

			//Parse the response XML string into an XmlDocument
			PopulateDepartments(departmentsResponse);	
		}

		private void SaveResponse(string response)
		{
			try
			{
                string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string fullPath = Path.Combine(commonApplicationData, "departments.xml");
                
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

		private void PopulateDepartments(string departmentsResponse)
		{
			XmlDocument responseXmlDoc = new XmlDocument();

			AddDefaultDepartment(responseXmlDoc);

			if (!String.IsNullOrEmpty(departmentsResponse))
			{
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
		}

		public void AddDefaultDepartment(XmlDocument document)
		{
			XmlElement departmentRet = document.CreateElement("DepartmentRet");
			XmlElement ListId = document.CreateElement("ListID");
			departmentRet.AppendChild(ListId);
			ListId.InnerText = "Default";

			XmlElement departmentCode = document.CreateElement("DepartmentCode");
			departmentRet.AppendChild(departmentCode);
			departmentCode.InnerText = "XXX";

			XmlElement departmentName = document.CreateElement("DepartmentName");
			departmentRet.AppendChild(departmentName);
			departmentName.InnerText = "Default";

			Department department = new Department(departmentRet);
			_departments.Add(department);
		}
	}
}
