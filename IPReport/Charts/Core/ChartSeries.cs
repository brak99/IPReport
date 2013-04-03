﻿using System;
using System.Collections;
namespace De.TorstenMandelkow.MetroChart
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Collections.Specialized;

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
    using Windows.UI.Xaml.Data;

#else
    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows;
#endif

    public class ChartSeries : ItemsControl
    { 
        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register("DisplayMember",
            typeof(string),
            typeof(ChartSeries),
            new PropertyMetadata(null));
        public static readonly DependencyProperty ValueMemberProperty =
            DependencyProperty.Register("ValueMember",
            typeof(string),
            typeof(ChartSeries),
            new PropertyMetadata(null));
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption",
            typeof(string),
            typeof(ChartSeries),
            new PropertyMetadata("Dammit"));
		public static readonly DependencyProperty PerformanceTargetMemberProperty =
			DependencyProperty.Register("PerformanceTargetMember",
			typeof(string),
			typeof(ChartSeries),
			new PropertyMetadata(null));
		public static readonly DependencyProperty ActualPerformanceMemberProperty =
			DependencyProperty.Register("ActualPerformanceMember",
			typeof(string),
			typeof(ChartSeries),
			new PropertyMetadata(null));
		public static readonly DependencyProperty ActualPerformanceProperty =
			DependencyProperty.Register("ActualPerformance",
			typeof(double),
			typeof(ChartSeries),
			new PropertyMetadata(null));
		public static readonly DependencyProperty PerformanceTargetProperty =
			DependencyProperty.Register("PerformanceTarget",
			typeof(double),
			typeof(ChartSeries),
			new PropertyMetadata(null));

        public ChartSeries()
        {   
        }

        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        public string DisplayMember
        {
            get
            {
                return (string)GetValue(DisplayMemberProperty);
            }
            set
            {
                SetValue(DisplayMemberProperty, value);
            }
        }

        public string ValueMember
        {
            get
            {
                return (string)GetValue(ValueMemberProperty);
            }
            set
            {
                SetValue(ValueMemberProperty, value);
            }
        }

		public string PerformanceTargetMember
		{
			get { return (string)GetValue(PerformanceTargetMemberProperty); }
			set { SetValue(PerformanceTargetMemberProperty, value); }
		}

		public string ActualPerformanceMember
		{
			get { return (string)GetValue(ActualPerformanceMemberProperty); }
			set { SetValue(ActualPerformanceMemberProperty, value); }
		}

		public double ActualPerformance
		{
			get { return (double)GetValue(ActualPerformanceProperty); }
			set { SetValue(ActualPerformanceProperty, value); }
		}

		public double PerformanceTarget
		{
			get { return (double)GetValue(PerformanceTargetProperty); }
			set { SetValue(PerformanceTargetProperty, value); }
		}
    }
}
