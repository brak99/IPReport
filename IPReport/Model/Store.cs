using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace IPReport.Model
{
	public class Store
	{
		private static int _storeCount = 1;

		int _storeNumber;
		public int StoreNumber
		{
			get { return _storeNumber; }
			set { _storeNumber = value; }
		}
		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string _buildingStoreNumber;
		public string BuildingStoreNumber
		{
			get { return _buildingStoreNumber; }
			set { _buildingStoreNumber = value; }
		}
		//Dictionary<string,  double> _departmentRetailValue = new Dictionary<string, double>();

		private string _quickBooksTitle;
		public string QuickBooksTitle
		{
			get { return _quickBooksTitle; }
			private set { _quickBooksTitle = value; }
		}

		private bool _active;
		public bool Active
		{
			get { return _active; }
			set { _active = value; }
		}
		public static Store GetInstance(string name, bool active)
		{
			Store store = new Store(name);
			store.QuickBooksTitle = "Store0" + _storeCount++;
			store.Active = active;

			return store;
		}

		public static Store GetInstance(XElement storeElement)
		{
			Store store = new Store((string)storeElement.Element("Name"));
			store.QuickBooksTitle = (string)storeElement.Element("QuickBooksTitle");
			store.StoreNumber = Convert.ToInt32(storeElement.Element("StoreNumber").Value);
			store.Active = Convert.ToBoolean(storeElement.Element("Active").Value);
			store.BuildingStoreNumber = (string)storeElement.Element("BuildingStoreNumber");

			return store;

		}
		private Store(string name)
		{
			_name = name;
			_storeNumber = _storeCount;
		}

		public static void Reset()
		{
			_storeCount = 1;
		}

		public XElement ToXml()
		{
			XElement store = new XElement("Store");
			XElement quickBooksTitle = new XElement("QuickBooksTitle", QuickBooksTitle);
			XElement storeNumber = new XElement("StoreNumber", StoreNumber);
			XElement name = new XElement("Name", Name);
			XElement active = new XElement("Active", Active);
			XElement buildingStoreNumber = new XElement("BuildingStoreNumber", BuildingStoreNumber);

			store.Add(quickBooksTitle);
			store.Add(storeNumber);
			store.Add(name);
			store.Add(active);
			store.Add(buildingStoreNumber);

			return store;
		}
	}
}
