using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IPReport.Model;
using IPReport.ViewModel;
using IPReport.Util;

using NUnit.Framework;
using System.Xml;

namespace IPReport.Test
{
	[TestFixture]
	public class OnHandInventoryTests : OnHandInventory
	{
		[TestFixtureSetUp]
		public void Init()
		{
			ServiceContainer.Instance.AddService<IQuickBooksQueryService>(new TestQBQueryService());
		}

		[Test]
		public void TestDepartments()
		{
			OnHandInventory inventoryReport = new OnHandInventory();

			inventoryReport.GetAllDepartments();

			Assert.AreEqual(68, inventoryReport.Departments.Count);
		}

		[Test]
		public void TestInventory()
		{
			GetAllDepartments();

			Department dept = Departments[0];

			XmlNodeList inventoryList = GetInventory(dept);

			Assert.AreEqual(4, inventoryList.Count);

		}
	}
}
