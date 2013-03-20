using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.Model;
using System.Xml;
using IPReport.ViewModel;
using IPReport.Util;
using System.IO;
using IPReport.DataAccess;

namespace IPReport.Test
{
	public class FakeQBService : IQuickBooksQueryService
	{
		string testDep = @"<?xml version=""1.0"" encoding=""windows-1252""?>
				<QBPOSXML>
				<QBPOSXMLMsgsRs>
				<DepartmentQueryRs retCount=""68"" statusCode=""0"" statusMessage=""Status OK"" statusSeverity=""Info""><DepartmentRet>
                <ListID>-6591161192474050303</ListID>
                <TimeCreated>2011-11-12T20:50:43-06:00</TimeCreated>
                <TimeModified>2011-11-12T20:50:43-06:00</TimeModified>
                <DefaultMarginPercent>0</DefaultMarginPercent>
                <DefaultMarkupPercent>0</DefaultMarkupPercent>
                <DepartmentCode>GAT</DepartmentCode>
                <DepartmentName>Gear Bath Tubs</DepartmentName>
                <StoreExchangeStatus>Modified</StoreExchangeStatus>
                <TaxCode>Tax</TaxCode>
            </DepartmentRet>
			</DepartmentQueryRs>
			</QBPOSXMLMsgsRs>
			</QBPOSXML>";

		public string Query(string queryString)
		{
			string queryReturn = "";

			if (queryString.Contains("DepartmentQueryRq"))
			{
				queryReturn = testDep;
			}
			else if (queryString.Contains("ItemInventoryQueryRq"))
			{
				FileStream fs = new FileStream("../unit_test_data/InventoryResponse1.xml", FileMode.Open,
									 FileAccess.Read);
				StreamReader sr = new StreamReader(fs);
				queryReturn = sr.ReadToEnd();

				sr.Close();
			}

			return queryReturn;
		}
	}

	[TestFixture]
	public class StoreViewModelTests
	{
		[SetUp]
		public void Setup()
		{
			Store.Reset();
			ServiceContainer.Instance.AddService<IDateService>(new FakeDateService());
			ServiceContainer.Instance.AddService<IStatusUpdate>(new FakeStatusUpdateService());
		}

		[Test]
		public void TestRetailValue()
		{
			Store store1 = Store.GetInstance("one", true);

			Assert.AreEqual("Store01", store1.QuickBooksTitle);

			ServiceContainer.Instance.AddService<IQuickBooksQueryService>(new FakeQBService());

			DepartmentRepository.Instance.Refresh();

			StoreViewModel vm = StoreViewModel.GetInstance(store1);

			vm.Refresh();

			Assert.AreEqual(2, vm.RetailValues.Count);

			Assert.AreEqual(469.89, vm.RetailValues[0].RetailValue);
		}
	}
}
