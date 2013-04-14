using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.Specialized;


namespace IPReport.ViewModel
{
	public class StringWrapper
	{
		public string Value { get; set; }
	}

	public class SalesDashboardSettingsViewModel : WorkspaceViewModel
	{
		private object _lockObject = new object();

		private const string LoginToIgnore = "LoginToIgnore";

		private ObservableCollection<StringWrapper> _ignoreList;
		public ObservableCollection<StringWrapper> IgnoreList
		{
			get { return _ignoreList; }
		}

		private SalesDashboardSettingsViewModel()
		{
			_ignoreList = new ObservableCollection<StringWrapper>();

			LoadSettings(SalesDashboardSettingsLocation());
		}

		public static SalesDashboardSettingsViewModel GetInstance()
		{
			return new SalesDashboardSettingsViewModel();
		}

		private void LoadSettings(string settingsDataFile)
		{
			try
			{
				lock (_lockObject)
				{
					using (Stream stream = new FileStream(settingsDataFile, FileMode.OpenOrCreate))
					using (XmlReader reader = new XmlTextReader(stream))
					{
						XElement settingsElement = XDocument.Load(reader).Element("settings");

						XElement ignoreElement = settingsElement.Element("ignore");
						if (ignoreElement != null)
						{
							LoadIgnoreList(ignoreElement);
						}
					}
				}


			}
			catch (System.Exception)
			{

			}
		}

		public void Save()
		{
			SaveSettings();
		}

		private void SaveSettings()
		{
			string settingsFile = SalesDashboardSettingsLocation();

			try
			{
				lock (_lockObject)
				{
					using (Stream stream = new FileStream(settingsFile, FileMode.Create, FileAccess.Write))
					{

						XDocument groupsDocument = new XDocument();

						XElement settingsElement = new XElement("settings");
						groupsDocument.Add(settingsElement);

						XElement ignoreElement = new XElement("ignore");
						settingsElement.Add(ignoreElement);
						foreach (StringWrapper ignoredUser in _ignoreList)
						{
							if (!String.IsNullOrEmpty(ignoredUser.Value))
							{
								XElement loginToIgnore = new XElement(LoginToIgnore);
								loginToIgnore.Value = ignoredUser.Value;
								ignoreElement.Add(loginToIgnore);
							}
							
						}

						groupsDocument.Save(stream);
					}
				}
			}
			catch (System.Exception)
			{

			}
		}
		private string SalesDashboardSettingsLocation()
		{
			string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string fullPath = Path.Combine(commonApplicationData, "salesdashboardsettings.xml");
			return fullPath;
		}

		private void LoadIgnoreList(XElement settingsElement)
		{
			_ignoreList.Clear();

			foreach (XElement ignoreElement in settingsElement.Elements(LoginToIgnore))
			{
				_ignoreList.Add(new StringWrapper() { Value = ignoreElement.Value });
			}
		}

		private void AddIgnoreValue(object sender, RoutedEventArgs args)
		{
			_ignoreList.Add(new StringWrapper() { Value = "<new ignore>" });
		}

		private void DeleteIgnoreValue(object sender, RoutedEventArgs args)
		{
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(IgnoreList);

			string currentIgnore = collectionView.CurrentItem as string;
			StringWrapper wrapper = new StringWrapper() { Value = currentIgnore };

			IgnoreList.Remove(wrapper);
		}
	}
}
