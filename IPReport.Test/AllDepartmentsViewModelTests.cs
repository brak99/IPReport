using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.ViewModel;
using IPReport.DataAccess;
using IPReport.Util;

namespace IPReport.Test
{
	[TestFixture]
	public class AllDepartmentsViewModelTests
	{
		[SetUp]
		public void Setup()
		{
			ServiceContainer.Instance.AddService<IDateService>(new FakeDateService());
			ServiceContainer.Instance.AddService<IStatusUpdate>(new FakeStatusUpdateService());
		}

		[Test]
		public void TestDefaultSetup()
		{
			ServiceContainer.Instance.AddService<IQuickBooksQueryService>(new FakeQBService());

			DepartmentRepository.Instance.Refresh();

			AllDepartmentsViewModel allDepartments = AllDepartmentsViewModel.GetInstance();

			//Two departments, GAT and Default
			Assert.AreEqual(2, allDepartments.Departments.Count);
		}
	}
}
