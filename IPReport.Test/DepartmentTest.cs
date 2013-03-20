using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml;

using IPReport.Model;

namespace IPReport.Test
{
	[TestFixture]
	public class DepartmentTest
	{
		Department testDepartment;

		public static string TestDepartmentNode = "<DepartmentRet> "
                + "<ListID>-9159787098314735359</ListID>"
                + "<TimeCreated>2010-01-02T16:12:35-06:00</TimeCreated>"
                + "<TimeModified>2011-11-12T20:46:41-06:00</TimeModified>"
                + "<DefaultMarginPercent>0</DefaultMarginPercent>"
                + "<DefaultMarkupPercent>0</DefaultMarkupPercent>"
               + " <DepartmentCode>CCC</DepartmentCode>"
                + "<DepartmentName>Classes Classes Classes</DepartmentName>"
                + "<StoreExchangeStatus>Modified</StoreExchangeStatus>"
                + "<TaxCode>Non</TaxCode>"
            + "</DepartmentRet>";

		[TestFixtureSetUp]
		public void Init()
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(TestDepartmentNode);

			XmlNodeList departments = doc.GetElementsByTagName("DepartmentRet");

			testDepartment = new Department(departments[0]);
		}

		[Test]
		public void TestListId()
		{
			Assert.AreEqual("-9159787098314735359", testDepartment.ListID);
		}

		[Test]
		public void TestDepartmentCode()
		{
			Assert.AreEqual("CCC", testDepartment.DepartmentCode);
		}

		[Test]
		public void TestDepartmentName()
		{
			Assert.AreEqual("Classes Classes Classes", testDepartment.DepartmentName);
		}
	}
}
