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
using IPReport.Util;
using System.Globalization;


namespace IPReport.ViewModel
{
	public class MonthTarget
	{
		public int Month { get; set; }
		public decimal Target { get; set; }
	}
	public class StringWrapper
	{
		public string Value { get; set; }
	}

	public class SalesDashboardSettingsViewModel : WorkspaceViewModel
	{
		private object _lockObject = new object();

		private const string LoginToIgnore = "LoginToIgnore";
		private const string MonthlyRevenueTargetsName = "MonthlyRevenueTargets";

		private ObservableCollection<StringWrapper> _ignoreList;
		public ObservableCollection<StringWrapper> IgnoreList
		{
			get { return _ignoreList; }
		}

		private ObservableCollection<MonthTarget> _monthlyRevenueTargets = new ObservableCollection<MonthTarget>();
		public ObservableCollection<MonthTarget> MonthlyRevenueTargets
		{
			get { return _monthlyRevenueTargets; }
			private set { _monthlyRevenueTargets = value; }
		}
		protected SalesDashboardSettingsViewModel()
		{
			_ignoreList = new ObservableCollection<StringWrapper>();

			for (int i = 1; i < 13; i++)
			{
				_monthlyRevenueTargets.Add(new MonthTarget() { Month = i, Target = 0.0m });
			}

			LoadSettings(SalesDashboardSettingsLocation());
		}

		public static SalesDashboardSettingsViewModel GetInstance()
		{
			return new SalesDashboardSettingsViewModel();
		}

		protected void LoadSettings(string settingsDataFile)
		{
			try
			{
				lock (_lockObject)
				{
					using (Stream stream = new FileStream(settingsDataFile, FileMode.OpenOrCreate))
					using (XmlReader reader = new XmlTextReader(stream))
					{
						XElement settingsElement = XDocument.Load(reader).Element("settings");

						LoadIgnoreList(settingsElement);

						LoadMonthlyRevenueTargets(settingsElement);
					}
				}


			}
			catch (System.Exception)
			{

			}
		}

		public void Save()
		{
			string settingsFile = SalesDashboardSettingsLocation();
			SaveSettings(settingsFile);
		}

		protected void SaveSettings(string settingsFile)
		{
			try
			{
				lock (_lockObject)
				{
					using (Stream stream = new FileStream(settingsFile, FileMode.Create, FileAccess.Write))
					{
						XDocument groupsDocument = new XDocument();
						XElement settingsElement = new XElement("settings");
						groupsDocument.Add(settingsElement);

						AddIgnoreSettings(settingsElement);
						
						AddMonthlyRevenueTargets(settingsElement);

						groupsDocument.Save(stream);
					}
				}
			}
			catch (System.Exception)
			{

			}
		}

		private void AddIgnoreSettings(XElement settingsElement)
		{
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
		}

		private string SalesDashboardSettingsLocation()
		{
			string commonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string fullPath = Path.Combine(commonApplicationData, "salesdashboardsettings.xml");
			return fullPath;
		}

		protected void LoadIgnoreList(XElement settingsElement)
		{
			_ignoreList.Clear();
			XElement ignoreElement = settingsElement.Element("ignore");
			if (ignoreElement != null)
			{
				foreach (XElement ignoreValue in ignoreElement.Elements(LoginToIgnore))
				{
					_ignoreList.Add(new StringWrapper() { Value = ignoreValue.Value });
				}
			}
			
		}

		protected void LoadMonthlyRevenueTargets(XElement settingsElement)
		{
			XElement monthlyTargetsElement = settingsElement.Element(MonthlyRevenueTargetsName);
			if (monthlyTargetsElement != null)
			{
				for (int i = 1; i < 13; i++)
				{
					XElement monthTarget = monthlyTargetsElement.Element(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
					decimal target = Convert.ToDecimal(monthTarget.Value);
					_monthlyRevenueTargets.First(monTarget => monTarget.Month == i).Target = target;
				}
			}
		}

		private void AddMonthlyRevenueTargets(XElement settingsElement)
		{
			XElement monthlyTargetsElement = new XElement(MonthlyRevenueTargetsName);
			foreach (MonthTarget monthlyTarget in _monthlyRevenueTargets)
			{
				XElement monthTarget = new XElement(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthlyTarget.Month));
				monthTarget.Value = monthlyTarget.Target.ToString();
				monthlyTargetsElement.Add(monthTarget);
			}
			settingsElement.Add(monthlyTargetsElement);
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
