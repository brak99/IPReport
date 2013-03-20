using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IPReport.Model;

using NUnit.Framework;
using System.Xml;
using IPReport.ViewModel;

namespace IPReport.Test
{
	[TestFixture]
	public class StoreReportItemTest
	{
		string testDep1 = @"<DepartmentRet>
                <ListID>-6591161192474050303</ListID>
                <TimeCreated>2011-11-12T20:50:43-06:00</TimeCreated>
                <TimeModified>2011-11-12T20:50:43-06:00</TimeModified>
                <DefaultMarginPercent>0</DefaultMarginPercent>
                <DefaultMarkupPercent>0</DefaultMarkupPercent>
                <DepartmentCode>GAT</DepartmentCode>
                <DepartmentName>Gear Bath Tubs</DepartmentName>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
            </DepartmentRet>";

		string testDep2 = @"<DepartmentRet>
                <ListID>999</ListID>
                <TimeCreated>2011-11-12T20:50:43-06:00</TimeCreated>
                <TimeModified>2011-11-12T20:50:43-06:00</TimeModified>
                <DefaultMarginPercent>0</DefaultMarginPercent>
                <DefaultMarkupPercent>0</DefaultMarkupPercent>
                <DepartmentCode>HUH</DepartmentCode>
                <DepartmentName>Stuff</DepartmentName>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
            </DepartmentRet>";

		//[Test]
		//public void TestDepartmentTotals()
		//{
		//    Store store1 = Store.GetInstance("one");

		//    Assert.AreEqual("Store01", store1.QuickBooksTitle);

		//    XmlDocument doc = new XmlDocument();
		//    doc.LoadXml(testDep1);

		//    XmlNodeList departments = doc.GetElementsByTagName("DepartmentRet");

		//    Department testDepartment = new Department(departments[0]);

		//    store1.AddDepartment(testDepartment);

		//    XmlDocument doc2 = new XmlDocument();
		//    doc2.LoadXml(testDep2);

		//    departments = doc2.GetElementsByTagName("DepartmentRet");

		//    testDepartment = new Department(departments[0]);

		//    store1.AddDepartment(testDepartment);

		//    XmlDocument invDoc = new XmlDocument();
		//    XmlTextReader reader = new XmlTextReader("../unit_test_data/InventoryResponse2.xml");
		//    invDoc.Load(reader);

		//    XmlNodeList items = invDoc.GetElementsByTagName("ItemInventoryQueryRs");

		//    XmlNodeList inventoryList = items[0].SelectNodes("//ItemInventoryRet");

		//    foreach (XmlNode node in inventoryList)
		//    {
		//        ItemInventory itemInventory = new ItemInventory(node);
		//        store1.AddToInventory(itemInventory);
		//    }

		//    List<string> departmentTotalGroup = new List<string>();

		//    departmentTotalGroup.Add("999");
		//    departmentTotalGroup.Add("-6591161192474050303");

		//    StoreReportItem lineItem = StoreReportItem.GetReportItem(store1, departmentTotalGroup);

		//    Console.WriteLine("store 1 group total is " + lineItem.RetailTotal);
		//    Assert.AreEqual(469.89, lineItem.RetailTotal);
		//}
	}
}
