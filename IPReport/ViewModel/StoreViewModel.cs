using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.DataAccess;
using IPReport.Model;
using System.Xml;
using System.Collections.ObjectModel;
using IPReport.Util;
using System.Windows;
using System.IO;
using System.Xml.Linq;

namespace IPReport.ViewModel
{
	public class StoreViewModel : WorkspaceViewModel, ISaveToXml, ISaveToCsv
	{
		private Store _store;

		private List<Department> _departments = new List<Department>();
		private DepartmentViewModel _defaultDepartment;
        private List<SalesReceipt> _salesReceipts = new List<SalesReceipt>();

		ObservableCollection<DepartmentViewModel> _departmentRetailValue = new ObservableCollection<DepartmentViewModel>();

		public static StoreViewModel GetInstance(Store store)
		{
			return new StoreViewModel(store);
		}

		public ObservableCollection<DepartmentViewModel> RetailValues
		{
			get { return _departmentRetailValue; }
		}

		private StoreViewModel(Store store)
		{
			_store = store;
			PopulateBaseDepartments();
		}

		public override string DisplayName
		{
			get	{ return _store.Name; }
		}

		public bool Active
		{
			get { return _store.Active; }
		}

		public string BuildingStoreNumber
		{
			get { return _store.BuildingStoreNumber; }
		}

        public ReadOnlyCollection<SalesReceipt> SalesReceipts
        {
            get
            {
                return _salesReceipts.AsReadOnly();
            }
        }

		public void Refresh()
		{
			_departments.Clear();
			_departmentRetailValue.Clear();

			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();

			foreach (Department department in DepartmentRepository.Instance.Departments)
			{
				_departments.Add(department);

				DepartmentViewModel departmentViewModel = new DepartmentViewModel(_store.StoreNumber);
				departmentViewModel.ListId = department.ListID;
				departmentViewModel.Code = department.DepartmentCode;
				departmentViewModel.Name = department.DepartmentName;
				departmentViewModel.RetailValue = 0.0M;

				_departmentRetailValue.Add(departmentViewModel);

				statusUpdate.UpdateStatus(DisplayName + ": adding department " + departmentViewModel.DisplayName);

				if (String.Compare(department.DepartmentCode, "XXX", StringComparison.OrdinalIgnoreCase) == 0)
				{
					_defaultDepartment = departmentViewModel;
				}

				PopulateInventory(departmentViewModel);	
			}

			PopulateTransfers();

			PopulateVouchers();

			PopulateSales();
		}

		private void PopulateBaseDepartments()
		{
			_departments.Clear();

			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();

			foreach (Department department in DepartmentRepository.Instance.Departments)
			{
				_departments.Add(department);

				DepartmentViewModel departmentViewModel = new DepartmentViewModel(_store.StoreNumber);
				departmentViewModel.ListId = department.ListID;
				departmentViewModel.Code = department.DepartmentCode;
				departmentViewModel.Name = department.DepartmentName;
				departmentViewModel.RetailValue = 0.0M;

				_departmentRetailValue.Add(departmentViewModel);

				statusUpdate.UpdateStatus(DisplayName + ": adding department " + departmentViewModel.DisplayName);

			}
		}
		private void PopulateInventory(DepartmentViewModel departmentValue)
		{
			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();
			statusUpdate.UpdateStatus("Running inventory query for " + departmentValue.DisplayName);

			XmlNodeList inventoryNodeList = InventoryRepository.GetInventory(departmentValue.ListId);

			if (inventoryNodeList != null)
			{
				foreach (XmlNode node in inventoryNodeList)
				{
					ItemInventory itemInventory = new ItemInventory(node);

					AddToInventory(itemInventory, departmentValue);
				}
			}
		}

		private void AddToInventory(ItemInventory itemInventory, DepartmentViewModel departmentValue)
		{
			decimal quantity = QuantityOnHand(itemInventory);
			decimal price = Convert.ToDecimal(itemInventory.Price1);
			decimal retailValue = quantity * price;

			try
			{
				departmentValue.RetailValue += retailValue;
				departmentValue.Inventory.Add(itemInventory.ListID, itemInventory);

				IItemDepartmentService itemDepartmentService = ServiceContainer.Instance.GetService<IItemDepartmentService>();
				itemDepartmentService.SaveItemDepartment(itemInventory.ListID, departmentValue.ListId);

				IStatusUpdate statusUpdateService = ServiceContainer.Instance.GetService<IStatusUpdate>();
				statusUpdateService.UpdateStatus("Adding " + itemInventory.Desc1 + " to " + DisplayName);
			}
			catch (System.Exception)
			{

			}

		}

		private void PopulateVouchers()
		{
			IStatusUpdate statusUpdateService = ServiceContainer.Instance.GetService<IStatusUpdate>();
			statusUpdateService.UpdateStatus("Running Voucher query");

			IDateService dateService = ServiceContainer.Instance.GetService<IDateService>();
			XmlNodeList vouchers = VoucherRepository.GetVouchersForMonth(dateService.DateForReport(), _store.StoreNumber);

			if (vouchers != null)
			{
				foreach (XmlNode node in vouchers)
				{
					Voucher voucher = new Voucher(node);
					IItemDepartmentService itemDepartmentService = ServiceContainer.Instance.GetService<IItemDepartmentService>();

					foreach (VoucherItem item in voucher.Items)
					{
						string departmentId = itemDepartmentService.GetItemDepartment(item.ListID);
						DepartmentViewModel department = GetDepartment(departmentId);
						department.VoucherItems.Add(item);
					}
				}
			}
		}

		private void PopulateTransfers()
		{
			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();
			//statusUpdate.UpdateStatus("Running transfer query for " + department.DisplayName);

			IDateService dateService = ServiceContainer.Instance.GetService<IDateService>();
			XmlNodeList transfers = TransferRepository.GetTransfersForMonthFromStore(dateService.DateForReport(), _store.StoreNumber);

			if (transfers != null)
			{
				//if (transfers.Count > 0)
				//    MessageBox.Show("transfers fromstore occurred for " + department.Name);

				IItemDepartmentService itemDepartmentService = ServiceContainer.Instance.GetService<IItemDepartmentService>();

				int i = 1;
				
				foreach (XmlNode node in transfers)
				{
					statusUpdate.UpdateStatus("Processing " + i++ + " of " + transfers.Count + " from store transfers");

					TransferSlip transferSlip = new TransferSlip(node);
					foreach (TransferSlipItem item in transferSlip.Items)
					{
						string departmentId = itemDepartmentService.GetItemDepartment(item.ListID);
						DepartmentViewModel department = GetDepartment(departmentId);
						department.TransfersFrom.Add(item);
					}
				}
			}

			transfers = TransferRepository.GetTransfersForMonthToStore(dateService.DateForReport(), _store.StoreNumber);

			if (transfers != null)
			{
				IItemDepartmentService itemDepartmentService = ServiceContainer.Instance.GetService<IItemDepartmentService>();

				int i = 1;

				foreach (XmlNode node in transfers)
				{
					statusUpdate.UpdateStatus("Processing " + i++ + " of " + transfers.Count + " to store transfers");

					TransferSlip transferSlip = new TransferSlip(node);

					foreach (TransferSlipItem item in transferSlip.Items)
					{
						string departmentId = itemDepartmentService.GetItemDepartment(item.ListID);
						DepartmentViewModel department = GetDepartment(departmentId);
						department.TransfersTo.Add(item);
					}
				}
			}
		}

		private void PopulateSales()
		{
			IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();
			statusUpdate.UpdateStatus("Running Sales query");

			IDateService dateService = ServiceContainer.Instance.GetService<IDateService>();

			DateTime startDate = dateService.DateForReport();
			startDate = DateUtil.FirstDayOfMonthFromDateTime(startDate);

			XmlNodeList salesList = SalesRepository.GetSales(startDate, _store.StoreNumber);

			if (salesList != null)
			{
				int i = 1;
                _salesReceipts.Clear();

				foreach (XmlNode node in salesList)
				{
					statusUpdate.UpdateStatus("Processing " + i++ + " of " + salesList.Count + " sales receipts");

					SalesReceipt salesReceipt = new SalesReceipt(node);

                    _salesReceipts.Add(salesReceipt);

					IItemDepartmentService itemDepartmentService = ServiceContainer.Instance.GetService<IItemDepartmentService>();
					foreach (SalesReceiptItem item in salesReceipt.Items)
					{
						string departmentId = itemDepartmentService.GetItemDepartment(item.ListID);
						DepartmentViewModel department = GetDepartment(departmentId);
						department.SalesItems.Add(item);
					}
				}
			}
		}

        private void PopulateTimeEntries()
        {
            IStatusUpdate statusUpdate = ServiceContainer.Instance.GetService<IStatusUpdate>();
            statusUpdate.UpdateStatus("Running Time query");

            IDateService dateService = ServiceContainer.Instance.GetService<IDateService>();

            XmlNodeList salesList = SalesRepository.GetSales(dateService.DateForReport(), _store.StoreNumber);

            if (salesList != null)
            {
                int i = 1;
                _salesReceipts.Clear();

                foreach (XmlNode node in salesList)
                {
                    statusUpdate.UpdateStatus("Processing " + i++ + " of " + salesList.Count + " sales receipts");

                    SalesReceipt salesReceipt = new SalesReceipt(node);

                    _salesReceipts.Add(salesReceipt);

                    IItemDepartmentService itemDepartmentService = ServiceContainer.Instance.GetService<IItemDepartmentService>();
                    foreach (SalesReceiptItem item in salesReceipt.Items)
                    {
                        string departmentId = itemDepartmentService.GetItemDepartment(item.ListID);
                        DepartmentViewModel department = GetDepartment(departmentId);
                        department.SalesItems.Add(item);
                    }
                }
            }
        }
		private DepartmentViewModel GetDepartment(string listID)
		{
			foreach (DepartmentViewModel department in _departmentRetailValue)
			{
				if (String.Compare(listID, department.ListId, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return department;
				}
			}

			return _defaultDepartment;
		}

		private decimal QuantityOnHand(ItemInventory itemInventory)
		{
			decimal quantity = 0.0M;

			string quantityString = "";

			switch (_store.QuickBooksTitle)
			{
				case "Store01":
					quantityString = itemInventory.OnHandStore01;
					break;
				case "Store02":
					quantityString = itemInventory.OnHandStore02;
					break;
				case "Store03":
					quantityString = itemInventory.OnHandStore03;
					break;
				case "Store04":
					quantityString = itemInventory.OnHandStore04;
					break;
				case "Store05":
					quantityString = itemInventory.OnHandStore05;
					break;
				case "Store06":
					quantityString = itemInventory.OnHandStore06;
					break;
				case "Store07":
					quantityString = itemInventory.OnHandStore07;
					break;
				case "Store08":
					quantityString = itemInventory.OnHandStore08;
					break;
				case "Store09":
					quantityString = itemInventory.OnHandStore09;
					break;
			}

			if (!(quantityString.Length == 0))
			{
				quantity = Convert.ToDecimal(quantityString);
			}

			return quantity;
		}

		public void SaveToXml(string path)
		{
			try
			{
				using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
				{
					XDocument departmentsDocument = new XDocument();

					XElement departmentsElement = new XElement("departments");
					departmentsDocument.Add(departmentsElement);

					foreach (DepartmentViewModel department in _departmentRetailValue)
					{
						XElement departmentElement = department.ToXml();
						departmentsElement.Add(departmentElement);
					}

					departmentsDocument.Save(stream);

				}
			}
			catch (System.Exception)
			{

			}
		}

		public void SaveToCsv(string path)
		{
			try
			{
				using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
				{
					using (StreamWriter writer = new StreamWriter(stream))
					{
						foreach (DepartmentViewModel department in _departmentRetailValue)
						{
							string departmentElement = department.ToCsv();
							writer.WriteLine(departmentElement);
						}
					}
				}
			}
			catch (System.Exception)
			{

			}
		}
	}
}
