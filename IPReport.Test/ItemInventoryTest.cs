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
	public class ItemInventoryTest
	{
		ItemInventory itemInventoryTest = null;

		public static string TestInventoryNode = "<ItemInventoryRet>" +
                "<ListID>-8963436493188202239</ListID>" +
                "<TimeCreated>2010-02-24T14:07:10-06:00</TimeCreated>" +
                "<TimeModified>2012-08-20T20:25:24-06:00</TimeModified>" +
                "<COGSAccount>Cost of Goods Sold</COGSAccount>" +
                "<Cost>22.05</Cost>" +
                "<DepartmentCode>GAT</DepartmentCode>" +
                "<DepartmentListID>-6591161192474050303</DepartmentListID>" +
                "<Desc1>Spa Baby Eco Tub</Desc1>" +
                "<IncomeAccount>Merchandise Sales</IncomeAccount>" +
                "<IsBelowReorder>False</IsBelowReorder>" +
                "<IsEligibleForCommission>True</IsEligibleForCommission>" +
                "<IsEligibleForRewards>True</IsEligibleForRewards>" +
                "<IsPrintingTags>True</IsPrintingTags>" +
                "<IsUnorderable>False</IsUnorderable>" +
                "<IsWebItem>False</IsWebItem>" +
                "<ItemNumber>3644</ItemNumber>" +
                "<ItemType>Inventory</ItemType>" +
                "<Keywords>Baby, Eco, Spa, Tub</Keywords>" +
                "<LastReceived>2012-08-07</LastReceived>" +
                "<MarginPercent>56</MarginPercent>" +
                "<MarkupPercent>127</MarkupPercent>" +
                "<MSRP>0.00</MSRP>" +
                "<OnHandStore01>3.00</OnHandStore01>" +
                "<OnHandStore02>6.00</OnHandStore02>" +
                "<OrderCost>21.50</OrderCost>" +
                "<Price1>49.99</Price1>" +
                "<Price2>49.99</Price2>" +
                "<Price3>49.99</Price3>" +
                "<Price4>49.99</Price4>" +
                "<Price5>49.99</Price5>" +
                "<QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>" +
                "<QuantityOnHand>9.00</QuantityOnHand>" +
                "<QuantityOnOrder>0.00</QuantityOnOrder>" +
                "<QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>" +
                "<ReorderPoint>2.00</ReorderPoint>" +
                "<ReorderPointStore01>0.00</ReorderPointStore01>" +
                "<ReorderPointStore02>0.00</ReorderPointStore02>" +
                "<SerialFlag>Optional</SerialFlag>" +
                "<StoreExchangeStatus>Modified</StoreExchangeStatus>" +
                "<TaxCode>Tax</TaxCode>" +
                "<UPC>0838521000021</UPC>" +
                "<VendorListID>-8963441075960250111</VendorListID>" +
                "<WebPrice>49.99</WebPrice>" +
                "<Weight>0.00</Weight>" +
                "<AvailableQty>" +
    "<QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>" +
    "<QuantityOnOrder>0.00</QuantityOnOrder>" +
    "<QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>" +
    "<StoreNumber>1</StoreNumber>" +
                "</AvailableQty>" +
                "<AvailableQty>" +
    "<QuantityOnCustomerOrder>0.00</QuantityOnCustomerOrder>" +
    "<QuantityOnOrder>0.00</QuantityOnOrder>" +
    "<QuantityOnPendingOrder>0.00</QuantityOnPendingOrder>" +
    "<StoreNumber>2</StoreNumber>" +
                "</AvailableQty>" +
                "<UnitOfMeasure1>" +
    "<MSRP>0.00</MSRP>" +
    "<NumberOfBaseUnits>1.00</NumberOfBaseUnits>" +
    "<Price1>0.00</Price1>" +
    "<Price2>0.00</Price2>" +
    "<Price3>0.00</Price3>" +
    "<Price4>0.00</Price4>" +
    "<Price5>0.00</Price5>" +
                "</UnitOfMeasure1>" +
                "<UnitOfMeasure2>" +
    "<MSRP>0.00</MSRP>" +
    "<NumberOfBaseUnits>1.00</NumberOfBaseUnits>" +
    "<Price1>0.00</Price1>" +
    "<Price2>0.00</Price2>" +
    "<Price3>0.00</Price3>" +
    "<Price4>0.00</Price4>" +
    "<Price5>0.00</Price5>" +
                "</UnitOfMeasure2>" +
                "<UnitOfMeasure3>" +
    "<MSRP>0.00</MSRP>" +
    "<NumberOfBaseUnits>1.00</NumberOfBaseUnits>" +
    "<Price1>0.00</Price1>" +
    "<Price2>0.00</Price2>" +
    "<Price3>0.00</Price3>" +
    "<Price4>0.00</Price4>" +
    "<Price5>0.00</Price5>" +
                "</UnitOfMeasure3>" +
                "<VendorInfo2>" +
    "<OrderCost>0.00</OrderCost>" +
                "</VendorInfo2>" +
                "<VendorInfo3>" +
    "<OrderCost>0.00</OrderCost>" +
                "</VendorInfo3>" +
                "<VendorInfo4>" +
    "<OrderCost>0.00</OrderCost>" +
                "</VendorInfo4>" +
                "<VendorInfo5>" +
    "<OrderCost>0.00</OrderCost>" +
                "</VendorInfo5>" +
			"</ItemInventoryRet>";

		[TestFixtureSetUp]
		public void Init()
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(TestInventoryNode);

			XmlNodeList items = doc.GetElementsByTagName("ItemInventoryRet");

			itemInventoryTest = new ItemInventory(items[0]);
		}

		[Test]
		public void TestOnHandStore01()
		{
			Assert.AreEqual("3.00",itemInventoryTest.OnHandStore01);
		}

		[Test]
		public void TestOnHandStore02()
		{
			Assert.AreEqual("6.00",itemInventoryTest.OnHandStore02);
		}

		[Test]
		public void TestPrice()
		{
			Assert.AreEqual("49.99", itemInventoryTest.Price1);
		}

		[Test]
		public void TestDepartmentListID()
		{
			Assert.AreEqual("-6591161192474050303", itemInventoryTest.DepartmentListID);
		}
	}
}
