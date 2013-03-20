using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using IPReport.Util;
using System.Xml.Linq;

namespace IPReport.ViewModel
{
	public class DepartmentViewModel : ViewModelBase
	{
		private string _listId;
		public string ListId
		{
			get { return _listId; }
			set { _listId = value; }
		}
		private string _code;
		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}
		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		private decimal _retailValue;
		public decimal RetailValue
		{
			get { return _retailValue; }
			set { _retailValue = value; }
		}
		//private List<ItemInventory> _inventory = new List<ItemInventory>();
		//public List<ItemInventory> Inventory
		//{
		//    get { return _inventory; }
		//    private set { _inventory = value; }
		//}
		private Dictionary<string, ItemInventory> _inventory = new Dictionary<string, ItemInventory>();
		public Dictionary<string, ItemInventory> Inventory
		{
			get { return _inventory; }
			private set { _inventory = value; }
		}
		private decimal _totalReceivedForMonth;
		public decimal TotalReceivedForMonth
		{
			get { return _totalReceivedForMonth; }
			private set { _totalReceivedForMonth = value; }
		}
		private decimal _totalReceivedForMonthRetail;
		public decimal TotalReceivedForMonthRetail
		{
			get { return _totalReceivedForMonthRetail; }
			private set { _totalReceivedForMonthRetail = value; }
		}
		private decimal _totalTransferredInForMonth;
		public decimal TotalTransferredInForMonth
		{
			get { return _totalTransferredInForMonth; }
			private set { _totalTransferredInForMonth = value; }
		}
		private decimal _totalTransferredOutForMonth;
		public decimal TotalTransferredOutForMonth
		{
			get { return _totalTransferredOutForMonth; }
			private set { _totalTransferredOutForMonth = value; }
		}
		private ObservableCollection<TransferSlipItem> _transfersTo = new ObservableCollection<TransferSlipItem>();
		public ObservableCollection<TransferSlipItem> TransfersTo
		{
			get { return _transfersTo; }
			private set { _transfersTo = value; }
		}
		private ObservableCollection<TransferSlipItem> _transfersFrom = new ObservableCollection<TransferSlipItem>();
		public ObservableCollection<TransferSlipItem> TransfersFrom
		{
			get { return _transfersFrom; }
			private set { _transfersFrom = value; }
		}
		private ObservableCollection<SalesReceiptItem> _salesItems = new ObservableCollection<SalesReceiptItem>();
		public ObservableCollection<SalesReceiptItem> SalesItems
		{
			get { return _salesItems; }
			private set { _salesItems = value; }
		}
		private ObservableCollection<VoucherItem> _voucherItems = new ObservableCollection<VoucherItem>();
		public ObservableCollection<VoucherItem> VoucherItems
		{
			get { return _voucherItems; }
			set { _voucherItems = value; }
		}
		private decimal _salesForMonth;
		public decimal SalesForMonth
		{
			get { return _salesForMonth; }
			private set { _salesForMonth = value; }
		}
		private decimal _discountForMonth;
		public decimal DiscountForMonth
		{
			get { return _discountForMonth; }
			private set { _discountForMonth = value; }
		}
		private decimal _markupsForMonth;
		public decimal MarkupsForMonth
		{
			get { return _markupsForMonth; }
			private set { _markupsForMonth = value; }
		}
		public override string DisplayName
		{
			get { return _name; }
		}
		private int _storeNumber;

		public DepartmentViewModel(int storeNumber)
		{
			_transfersTo.CollectionChanged += OnTransfersToChanged;
			_transfersFrom.CollectionChanged += OnTransfersFromChanged;
			_salesItems.CollectionChanged += OnSalesItemsChanged;
			_voucherItems.CollectionChanged += OnVoucherItemsChanged;

			_totalReceivedForMonth = 0.0M;
			_totalReceivedForMonthRetail = 0.0M;
			_totalTransferredInForMonth = 0.0M;
			_totalTransferredOutForMonth = 0.0M;
			_salesForMonth = 0.0M;
			_discountForMonth = 0.0M;
			_markupsForMonth = 0.0M;
			_retailValue = 0.0M;

			_storeNumber = storeNumber;
		}

		protected void OnVoucherItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (args.NewItems != null && args.NewItems.Count > 0)
			{
				foreach (VoucherItem item in args.NewItems)
				{
					decimal qtyReceived = Convert.ToDecimal(item.QtyReceived);
					//IRetailCost retailCostService = ServiceContainer.Instance.GetService<IRetailCost>();
					//decimal retailCost = retailCostService.RetailCostByListId(item.ListID);
					decimal retailCost = GetRetailCost(item.ListID);

					TotalReceivedForMonth += Convert.ToDecimal(item.Cost) * qtyReceived;
					TotalReceivedForMonthRetail += retailCost * qtyReceived;
				}
			}
		}

		protected void OnSalesItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (args.NewItems != null && args.NewItems.Count > 0)
			{
				foreach (SalesReceiptItem item in args.NewItems)
				{
					decimal price = Convert.ToDecimal(item.Price);
					decimal qty = Convert.ToDecimal(item.Qty);
					decimal discount = Convert.ToDecimal(item.Discount);
					decimal markup = Convert.ToDecimal(item.Markup);

					SalesForMonth += price * qty;
					DiscountForMonth += discount;
					MarkupsForMonth += markup;
				}
			}
		}

		protected void OnTransfersToChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (args.NewItems != null && args.NewItems.Count > 0)
			{
				foreach (TransferSlipItem item in args.NewItems)
				{
					decimal qtyReceived = Convert.ToDecimal(item.Qty);
					IRetailCost retailCostService = ServiceContainer.Instance.GetService<IRetailCost>();
					decimal retailCost = retailCostService.RetailCostByListId(item.ListID);

					TotalTransferredInForMonth += retailCost * qtyReceived;
				}
			}
		}
		protected void OnTransfersFromChanged(object sender, NotifyCollectionChangedEventArgs args)
		{
			if (args.NewItems != null && args.NewItems.Count > 0)
			{
				foreach (TransferSlipItem item in args.NewItems)
				{
					decimal qtyReceived = Convert.ToDecimal(item.Qty);
					IRetailCost retailCostService = ServiceContainer.Instance.GetService<IRetailCost>();
					decimal retailCost = retailCostService.RetailCostByListId(item.ListID);

					TotalTransferredOutForMonth += retailCost * qtyReceived;
				}
			}
		}
		private decimal GetRetailCost(string listId)
		{
			IRetailCost retailCostService = ServiceContainer.Instance.GetService<IRetailCost>();
			//decimal retailCost = retailCostService.RetailCostByListId(item.ListID);

			if (_inventory.ContainsKey(listId))
			{
				return Convert.ToDecimal(_inventory[listId].Price1);
			}

			return retailCostService.RetailCostByListId(listId);
		}

		protected override void OnDispose()
		{
			_voucherItems.CollectionChanged -= OnVoucherItemsChanged;
			_salesItems.CollectionChanged -= OnSalesItemsChanged;
			_transfersFrom.CollectionChanged -= OnTransfersFromChanged;
			_transfersTo.CollectionChanged -= OnTransfersToChanged;
		}

		public XElement ToXml()
		{
			XElement department = new XElement("DepartmentGroup");
			XElement name = new XElement("Name", DisplayName);
			XElement sales = new XElement("SALES", SalesForMonth);
			XElement mkdns = new XElement("MKDNS", DiscountForMonth);
			XElement mkups = new XElement("MKUPS", MarkupsForMonth);
			XElement phyinv = new XElement("PHY_INV", RetailValue);
			XElement reccst = new XElement("REC_CST", TotalReceivedForMonth);
			XElement recret = new XElement("REC_RET", TotalReceivedForMonthRetail);
			XElement trin = new XElement("TR_IN", TotalTransferredInForMonth);
			XElement trout = new XElement("TR_OUT", TotalTransferredOutForMonth);

			department.Add(name);
			department.Add(sales);
			department.Add(mkdns);
			department.Add(mkups);
			department.Add(phyinv);
			department.Add(reccst);
			department.Add(recret);
			department.Add(trin);
			department.Add(trout);

			return department;
		}

		public string ToCsv()
		{
			string csv = DisplayName;
			csv += "," + SalesForMonth;
			csv += "," + DiscountForMonth;
			csv += "," + MarkupsForMonth;
			csv += "," + RetailValue;
			csv += "," + TotalReceivedForMonth;
			csv += "," + TotalReceivedForMonthRetail;
			csv += "," + TotalTransferredInForMonth;
			csv += "," + TotalTransferredOutForMonth;

			return csv;
		}
	}
}
