using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using IPReport.DataAccess;
using System.IO;
using IPReport.Model;

namespace IPReport.Test
{
	public class TestStoreRepository : StoreRepository
	{
		public TestStoreRepository() : base()
		{

		}
	}
	[TestFixture]
	public class StoreRepositoryTests
	{
		[Test]
		public void TestMissingFile()
		{

			Assert.AreEqual(9, StoreRepository.Instance.Stores.Count);
			//Assert.AreEqual(2, StoreRepository.Instance.Stores.Count);

		}

		//[Test]
		//public void TestSave()
		//{
		//    StoreRepository.Instance.SaveStores("stores.xml");

		//    Assert.AreEqual(true, File.Exists("stores.xml"));
		//}

		[Test]
		public void TestSaveInactive()
		{
			StoreRepository repo = StoreRepository.Instance;

			Store store = repo.Stores[1];
			store.Active = false;

			StoreRepository.Instance.SaveStores();

			TestStoreRepository testRepo = new TestStoreRepository();
			store = testRepo.Stores[1];

			Assert.AreEqual(false, store.Active);
		}

		[Test]
		public void TestSaveActive()
		{
			StoreRepository repo = StoreRepository.Instance;

			Store store = repo.Stores[1];
			store.Active = true;

			StoreRepository.Instance.SaveStores();

			TestStoreRepository testRepo = new TestStoreRepository();

			store = testRepo.Stores[1];

			Assert.AreEqual(true, store.Active);
		}
	}
}
