using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using IPReport.Model;

namespace IPReport.ViewModel
{
    public class StoreSalesViewModel :
        WorkspaceViewModel
    {
        private StoreViewModel _storeViewModel;
        private Dictionary<string, double> _associateSales = new Dictionary<string, double>();
        private string _storeName = "";

        public static StoreSalesViewModel GetInstance(StoreViewModel storeViewModel)
        {
            return new StoreSalesViewModel(storeViewModel);
        }

        private StoreSalesViewModel(StoreViewModel storeViewModel)
        {
            _storeViewModel = storeViewModel;
            _storeName = _storeViewModel.DisplayName;
        }

        public override string DisplayName
        {
            get { return _storeName + "[Sales]"; }
        }

        //TODO: make readonly
        public Dictionary<string, double> AssociateSales
        {
            get { return _associateSales; }
        }

        public void Refresh()
        {
            ReadOnlyCollection<SalesReceipt> storeReceipts = _storeViewModel.SalesReceipts;

            foreach (SalesReceipt salesReceipt in storeReceipts)
            {
                double sales;

                if (_associateSales.TryGetValue(salesReceipt.Associate, out sales))
                {
                    double associateSale = Convert.ToDouble(salesReceipt.Subtotal);
                    _associateSales[salesReceipt.Associate] += associateSale;
                }
                else
                {
                    double associateSale = Convert.ToDouble(salesReceipt.Subtotal);
                    _associateSales.Add(salesReceipt.Associate, associateSale);
                }
            }
        }
    }
}
