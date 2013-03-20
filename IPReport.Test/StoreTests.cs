using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IPReport.Model;

using NUnit.Framework;
using System.Xml;
using System.Diagnostics;

namespace IPReport.Test
{
	[TestFixture]
	public class StoreTests
	{
		string testDep = @"<DepartmentRet>
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

		[SetUp]
		public void Setup()
		{
			Store.Reset();
		}
		[Test]
		public void TestGetInstance()
		{
			Store store1 = Store.GetInstance("one", true);

			Assert.AreEqual("Store01", store1.QuickBooksTitle);

			Store store2 = Store.GetInstance("two", true);

			Assert.AreEqual("Store02", store2.QuickBooksTitle);

		}
	}
}
