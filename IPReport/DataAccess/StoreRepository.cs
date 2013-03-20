using System;
using System.Collections.Generic;
using IPReport.Model;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace IPReport.DataAccess
{
	public class StoreRepository
	{
		private object _lockObject = new object();
		public static readonly StoreRepository Instance = new StoreRepository();

		protected readonly List<Store> _stores = new List<Store>();

		public ReadOnlyCollection<Store> Stores
		{
			get { return _stores.AsReadOnly(); }
		}

		protected StoreRepository()
		{
			lock (_lockObject)
			{
				LoadStores(StoreFileLocation());
			}
		}

		private string StoreFileLocation()
		{
			string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string fullPath = Path.Combine(commonApplicationData, "stores.xml");

			return fullPath;
		}

		private void InitDefaultStores()
		{
			_stores.Add(Store.GetInstance("Store01", true));
			_stores.Add(Store.GetInstance("Store02", false));
			_stores.Add(Store.GetInstance("Store03", false));
			_stores.Add(Store.GetInstance("Store04", false));
			_stores.Add(Store.GetInstance("Store05", false));
			_stores.Add(Store.GetInstance("Store06", false));
			_stores.Add(Store.GetInstance("Store07", false));
			_stores.Add(Store.GetInstance("Store08", false));
			_stores.Add(Store.GetInstance("Store09", false));
		}

		public void SaveStores()
		{
			lock (_lockObject)
			{
				try
				{
					using (Stream stream = new FileStream(StoreFileLocation(), FileMode.Create))
					{
						XDocument storesDocument = new XDocument();

						XElement storesElement = new XElement("stores");
						storesDocument.Add(storesElement);

						foreach (Store store in _stores)
						{
							XElement storeElement = store.ToXml();
							storesElement.Add(storeElement);
						}

						storesDocument.Save(stream);

					}
				}
				catch (System.Exception)
				{

				}
			}
		}

		void LoadStores(string storeDataFile)
		{
			try
			{
				
				using (Stream stream = new FileStream(storeDataFile, FileMode.OpenOrCreate))
				using (XmlReader reader = new XmlTextReader(stream))
				{
					_stores.Clear();

					XElement storesElement = XDocument.Load(reader).Element("stores");

					foreach (XElement storeElement in storesElement.Elements("Store"))
					{
						Store store = Store.GetInstance(storeElement);

						_stores.Add(store);

					}
					//_stores = (from storeElem in XDocument.Load(reader).Element("stores").Elements("store")
					// select Store.GetInstance(
					//    (string)storeElem.Attribute("Name")
					//     )).ToList();
				}
			}
			catch (System.Exception)
			{
				InitDefaultStores();	
			}
		}
	}
}
