using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using IPReport.DataAccess;
using IPReport.Model;
using System.Threading.Tasks;
using IPReport.Util;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Collections.Specialized;

namespace IPReport.ViewModel
{
    public class InventoryViewModel : WorkspaceViewModel
    {
        private AllDepartmentsViewModel _allDepartments;
        private AllDepartmentsRetailValueViewModel _allDepartmentsRetailValue;

        private AllStoresViewModel _allStores;
        private GroupedStoreViewModel _departmentGroupsStore;
        private AllDepartmentGroupsViewModel _allDepartmentGroupsViewModel;


        public InventoryViewModel()
        {
            _allDepartments = AllDepartmentsViewModel.GetInstance();
            _allDepartmentsRetailValue = AllDepartmentsRetailValueViewModel.GetInstance();

            _allStores = AllStoresViewModel.GetInstance();

            Workspaces.Add(_allStores);
            Workspaces.Add(_allDepartments);

            _departmentGroupsStore = GroupedStoreViewModel.GetInstance(StoreViewModel.GetInstance(StoreRepository.Instance.Stores[0]));
            _departmentGroupsStore.Refresh();

            _allDepartmentGroupsViewModel = AllDepartmentGroupsViewModel.GetInstance(_departmentGroupsStore.DepartmentGroups);
            Workspaces.Add(_allDepartmentGroupsViewModel);
        }

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new DelegateCommand<object>(param => this.UpdateClick(param, null), param => this.CanUpdate);
                }

                return _updateCommand;
            }
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

            IQuickBooksUpdate quickBooksUpdate = collectionView.CurrentItem as IQuickBooksUpdate;

            quickBooksUpdate.Update();
        }

        private bool CanUpdate
        {
            get
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

                IQuickBooksUpdate quickBooksUpdate = collectionView.CurrentItem as IQuickBooksUpdate;

                if (quickBooksUpdate != null)
                {
                    return true;
                }

                return false;
            }
        }

        private ICommand _saveToXmlCommand;
        public ICommand SaveToXmlCommand
        {
            get
            {
                if (_saveToXmlCommand == null)
                {
                    _saveToXmlCommand = new DelegateCommand<object>(param => this.SaveToXml(param, null), param => this.CanSaveToXml);
                }

                return _saveToXmlCommand;
            }
        }

        private bool CanSaveToXml
        {
            get
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

                ISaveToXml saveToXml = collectionView.CurrentItem as ISaveToXml;

                if (saveToXml != null)
                {
                    return true;
                }

                return false;
            }
        }
        private void SaveToXml(object sender, RoutedEventArgs args)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

            ISaveToXml saveToXml = collectionView.CurrentItem as ISaveToXml;

            string path = ServiceContainer.Instance.GetService<ISaveFilePath>().SaveFilePath("XML File|*.xml", "Save as XML");

            saveToXml.SaveToXml(path);
        }

        private ICommand _saveToCsvCommand;
        public ICommand SaveToCsvCommand
        {
            get
            {
                if (_saveToCsvCommand == null)
                {
                    _saveToCsvCommand = new DelegateCommand<object>(param => this.SaveToCsv(param, null), param => this.CanSaveToCsv);
                }

                return _saveToCsvCommand;
            }
        }

        private bool CanSaveToCsv
        {
            get
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

                ISaveToCsv saveToCsv = collectionView.CurrentItem as ISaveToCsv;

                if (saveToCsv != null)
                {
                    return true;
                }

                return false;
            }
        }
        private void SaveToCsv(object sender, RoutedEventArgs args)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

            ISaveToCsv saveToCsv = collectionView.CurrentItem as ISaveToCsv;

            string path = ServiceContainer.Instance.GetService<ISaveFilePath>().SaveFilePath("CSV File|*.csv", "Save as CSV");

            saveToCsv.SaveToCsv(path);
        }

        private ICommand _saveToOtbCommand;
        public ICommand SaveToOtbCommand
        {
            get
            {
                if (_saveToOtbCommand == null)
                {
                    _saveToOtbCommand = new DelegateCommand<object>(param => this.SaveToOtb(param, null), param => this.CanSaveToOtb);
                }

                return _saveToOtbCommand;
            }
        }

        private bool CanSaveToOtb
        {
            get
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

                ISaveToOtb saveToOtb = collectionView.CurrentItem as ISaveToOtb;

                if (saveToOtb != null)
                {
                    return true;
                }

                return false;
            }
        }
        private void SaveToOtb(object sender, RoutedEventArgs args)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);

            ISaveToOtb saveToOtb = collectionView.CurrentItem as ISaveToOtb;

            string path = ServiceContainer.Instance.GetService<ISaveFilePath>().SaveFilePath("OTB File|*.txt", "Save as OTB");

            saveToOtb.SaveToOtb(path);
        }

        #region Workspaces

        ThreadObservableCollection<WorkspaceViewModel> _workspaces;

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ThreadObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ThreadObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        public void UpdateAll()
        {
            Task runReportTask = Task.Factory.StartNew(() =>
            {
                DepartmentRepository.Instance.Refresh();

                Workspaces.Clear();

                Workspaces.Add(_allStores);
                Workspaces.Add(_allDepartmentGroupsViewModel);

                _allDepartments.Refresh();

                Workspaces.Add(_allDepartments);

                foreach (Store store in StoreRepository.Instance.Stores)
                {
                    StoreViewModel storeViewModel = StoreViewModel.GetInstance(store);

                    if (!storeViewModel.Active)
                    {
                        continue;
                    }

                    //_workingOn = "Getting data for " + store.Name;
                    base.OnPropertyChanged("WorkingOn");

                    storeViewModel.Refresh();
                    Workspaces.Add(storeViewModel);

                    GroupedStoreViewModel groupModel = GroupedStoreViewModel.GetInstance(storeViewModel);
                    Workspaces.Add(groupModel);

                    StoreSalesViewModel storeSales = StoreSalesViewModel.GetInstance(storeViewModel);
                    storeSales.Refresh();
                    Workspaces.Add(storeSales);
                }
            }

            );

        }
        #endregion // Workspaces

    }
}
