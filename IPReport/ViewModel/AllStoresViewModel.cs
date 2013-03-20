using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using IPReport.Model;
using IPReport.DataAccess;

namespace IPReport.ViewModel
{
	public class AllStoresViewModel : WorkspaceViewModel
	{
		private ObservableCollection<Store> _stores = new ObservableCollection<Store>();
		public ObservableCollection<Store> Stores
		{
			get { return _stores; }
			
		}
		
		private AllStoresViewModel()
		{
			foreach (Store store in StoreRepository.Instance.Stores)
			{
				_stores.Add(store);
			}
		}

		public static AllStoresViewModel GetInstance()
		{
			return new AllStoresViewModel();
		}

		public override string DisplayName
		{
			get
			{
				return "Stores";
			}
		}
	}
}
