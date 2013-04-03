﻿namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Collections.ObjectModel;

#if NETFX_CORE
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Shapes;
    using Windows.UI.Xaml.Markup;
    using Windows.UI.Xaml;
    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Core;
#else
    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows;
#endif
    
    public class DataPointGroup : DependencyObject, INotifyPropertyChanged
    {
        public static readonly DependencyProperty SumOfDataPointGroupProperty =
            DependencyProperty.Register("SumOfDataPointGroup",
            typeof(double),
            typeof(DataPointGroup),
            new PropertyMetadata(0.0));
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem",
            typeof(object),
            typeof(DataPointGroup),
            new PropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public double SumOfDataPointGroup
        {
            get { return (double)GetValue(SumOfDataPointGroupProperty); }
            set { SetValue(SumOfDataPointGroupProperty, value); }
        }

        public ObservableCollection<DataPoint> DataPoints
        { get; set; }
       
        public DataPointGroup()
        {
            DataPoints = new ObservableCollection<DataPoint>();
            DataPoints.CollectionChanged += Items_CollectionChanged;
        }

        void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach(var item in e.NewItems)
            {
                if (item is INotifyPropertyChanged)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += DataPointGroup_PropertyChanged;
                }
            }
        }

        void DataPointGroup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                RecalcValues();
            }
        }

        private void RecalcValues()
        {
            if (this.Caption == "Correctness")
            {
            }
            double maxValue = 0.0;
            double sum = 0.0;
            foreach (var item in DataPoints)
            {
                item.StartValue = sum;
                sum += item.Value;
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                }
            }
            SumOfDataPointGroup = sum;
            RaisePropertyChangeEvent("SumOfDataPointGroup");
        }

        public string Caption { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangeEvent(String propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

		private object _ReferencedObject;

		public object ReferencedObject
		{
			get
			{
				return _ReferencedObject;
			}
			set
			{
				_ReferencedObject = value;
				//RaisePropertyChangeEvent("Value");
				//RaisePropertyChangeEvent("DisplayName");
				//if (_ReferencedObject is INotifyPropertyChanged)
				//{
				//    (_ReferencedObject as INotifyPropertyChanged).PropertyChanged += DataPoint_PropertyChanged;
				//}
			}
		}
    }
}
