namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows;

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
    using System.Windows.Data;
	using IPReport.ViewModel;
#endif

    public abstract class ChartBase : ItemsControl
    {
        #region Fields

        public static readonly DependencyProperty PlotterAreaStyleProperty =
            DependencyProperty.Register("PlotterAreaStyle",
            typeof(Style),
            typeof(ChartBase),
            new PropertyMetadata(null));
        public static readonly DependencyProperty ChartAreaStyleProperty =
            DependencyProperty.Register("ChartAreaStyle",
            typeof(Style),
            typeof(ChartBase),
            new PropertyMetadata(null));
        public static readonly DependencyProperty ChartLegendItemStyleProperty =
            DependencyProperty.Register("ChartLegendItemStyle",
            typeof(Style),
            typeof(ChartBase),
            new PropertyMetadata(null));
        

        public static readonly DependencyProperty ChartTitleProperty =
            DependencyProperty.Register("ChartTitle",
            typeof(string),
            typeof(ChartBase),
            new PropertyMetadata("WpfSimpleChart"));
        public static readonly DependencyProperty ChartSubTitleProperty =
            DependencyProperty.Register("ChartSubTitle",
            typeof(string),
            typeof(ChartBase),
            new PropertyMetadata("WpfSimpleChart"));
        public static readonly DependencyProperty ChartBackgroundBorderColorProperty =
            DependencyProperty.Register("ChartBackgroundBorderColor",
            typeof(Brush),
            typeof(ChartBase),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xB1, 0xB1, 0x4A))));
        public static readonly DependencyProperty ChartBackgroundBorderThicknessProperty =
            DependencyProperty.Register("ChartBackgroundBorderThickness",
            typeof(Thickness),
            typeof(ChartBase),
            new PropertyMetadata(new Thickness(0, 0, 0, 0)));
        public static readonly DependencyProperty ChartBackgroundCornerRadiusProperty =
            DependencyProperty.Register("ChartBackgroundCornerRadius",
            typeof(CornerRadius),
            typeof(ChartBase),
            new PropertyMetadata(new CornerRadius(0, 0, 0, 0)));
        public static readonly DependencyProperty ChartBackgroundProperty =
            DependencyProperty.Register("ChartBackground",
            typeof(Brush),
            typeof(ChartBase),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0xFF, 0xD9, 0xD9, 0x98))));
        public static readonly DependencyProperty ChartBorderColorProperty =
            DependencyProperty.Register("ChartBorderColor",
            typeof(Brush),
            typeof(ChartBase),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 0, 0, 0))));
        public static readonly DependencyProperty ChartBorderThicknessProperty =
            DependencyProperty.Register("ChartBorderThickness",
            typeof(Thickness),
            typeof(ChartBase),
            new PropertyMetadata(new Thickness(0, 0, 0, 0)));
        public static readonly DependencyProperty ChartColorMouseOverProperty =
            DependencyProperty.Register("ChartColorMouseOver",
            typeof(Brush),
            typeof(ChartBase),
            new PropertyMetadata(new SolidColorBrush(Colors.Red)));
        public static readonly DependencyProperty ChartColorProperty =
            DependencyProperty.Register("ChartColor",
            typeof(Brush),
            typeof(ChartBase),
            new PropertyMetadata(new SolidColorBrush(Colors.Red)));      
        public static readonly DependencyProperty ChartLegendVisibilityProperty =
            DependencyProperty.Register("ChartLegendVisibility",
            typeof(Visibility),
            typeof(ChartBase),
            new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty ChartMarginProperty =
            DependencyProperty.Register("ChartMargin",
            typeof(Thickness),
            typeof(ChartBase),
            new PropertyMetadata(new Thickness(20)));
        public static readonly DependencyProperty PaletteProperty =
            DependencyProperty.Register("Palette",
            typeof(ResourceDictionaryCollection),
            typeof(ChartBase),
            new PropertyMetadata(null));
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem",
            typeof(object),
            typeof(ChartBase),
            new PropertyMetadata(null));

        public static readonly DependencyProperty TitleStyleProperty =
            DependencyProperty.Register("TitleStyle",
            typeof(Style),
            typeof(ChartBase),
            new PropertyMetadata(null));
#endregion Fields


        #region INotifiy stuff

        private static void OnSeriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ChartBase).AttachEventHandler(e.NewValue);
        }

        private void AttachEventHandler(object collection)
        {
            if (collection is INotifyCollectionChanged)
            {
                (collection as INotifyCollectionChanged).CollectionChanged += ChartBase_CollectionChanged;
            }
        }

        void ChartBase_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var newSeries in e.NewItems)
                {
                    if (newSeries is ItemsControl)
                    {
#if NETFX_CORE
                        (newSeries as ItemsControl).Items.VectorChanged += Items_VectorChanged;

#else
                        if ((newSeries as ItemsControl).Items is INotifyCollectionChanged)
                        {
                            ((INotifyCollectionChanged)(newSeries as ItemsControl).Items).CollectionChanged += new NotifyCollectionChangedEventHandler(Window1_CollectionChanged);
                        }
#endif
                    }
                }
            }
        }

#if NETFX_CORE
        void Items_VectorChanged(Windows.Foundation.Collections.IObservableVector<object> sender, Windows.Foundation.Collections.IVectorChangedEventArgs @event)
        {
            UpdateGroupedSeries();
            UpdateGroupedPieSeries();
        }
#else
        private void Window1_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }
#endif
        #endregion

        #region Constructors               

        public ChartBase()
        {

        }

        #endregion Constructors

        #region Properties

        public Style PlotterAreaStyle
        {
            get { return (Style)GetValue(PlotterAreaStyleProperty); }
            set { SetValue(PlotterAreaStyleProperty, value); }
        }

        public Style ChartAreaStyle
        {
            get { return (Style)GetValue(ChartAreaStyleProperty); }
            set { SetValue(ChartAreaStyleProperty, value); }
        }

        public Style ChartLegendItemStyle
        {
            get { return (Style)GetValue(ChartLegendItemStyleProperty); }
            set { SetValue(ChartLegendItemStyleProperty, value); }
        }
        
        
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string ChartTitle
        {
            get { return (string)GetValue(ChartTitleProperty); }
            set { SetValue(ChartTitleProperty, value); }
        }

        public string ChartSubTitle
        {
            get { return (string)GetValue(ChartSubTitleProperty); }
            set { SetValue(ChartSubTitleProperty, value); }
        }

        public Style TitleStyle
        {
            get { return (Style)GetValue(TitleStyleProperty); }
            set { SetValue(TitleStyleProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public ResourceDictionaryCollection Palette
        {
            get { return (ResourceDictionaryCollection)GetValue(PaletteProperty); }
            set { SetValue(PaletteProperty, value); }
        }

        /// <summary>
        /// Gets or sets the chart background.
        /// </summary>
        /// <value>The chart background.</value>
        public Brush ChartBackground
        {
            get { return (Brush)GetValue(ChartBackgroundProperty); }
            set { SetValue(ChartBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the chart background border.
        /// </summary>
        /// <value>The color of the chart background border.</value>
        public Brush ChartBackgroundBorderColor
        {
            get { return (Brush)GetValue(ChartBackgroundBorderColorProperty); }
            set { SetValue(ChartBackgroundBorderColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the chart background border thickness.
        /// </summary>
        /// <value>The chart background border thickness.</value>
        public Thickness ChartBackgroundBorderThickness
        {
            get { return (Thickness)GetValue(ChartBackgroundBorderThicknessProperty); }
            set { SetValue(ChartBackgroundBorderThicknessProperty, value); }
        }

        /// <summary>
        /// Gets or sets the chart background corner radius.
        /// </summary>
        /// <value>The chart background corner radius.</value>
        public CornerRadius ChartBackgroundCornerRadius
        {
            get { return (CornerRadius)GetValue(ChartBackgroundCornerRadiusProperty); }
            set { SetValue(ChartBackgroundCornerRadiusProperty, value); }
        }

        /// <summary>
        /// Gets or sets the chart margin.
        /// </summary>
        /// <value>The chart margin.</value>
        public Thickness ChartMargin
        {
            get { return (Thickness)GetValue(ChartMarginProperty); }
            set { SetValue(ChartMarginProperty, value);}
        }

        /// <summary>
        /// Gets or sets the color of the chart border.
        /// </summary>
        /// <value>The color of the chart border.</value>
        public Brush ChartBorderColor
        {
            get
            {
                return (Brush)GetValue(ChartBorderColorProperty);
            }
            set
            {
                SetValue(ChartBorderColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the chart border thickness.
        /// </summary>
        /// <value>The chart border thickness.</value>
        public Thickness ChartBorderThickness
        {
            get
            {
                return (Thickness)GetValue(ChartBorderThicknessProperty);
            }
            set
            {
                SetValue(ChartBorderThicknessProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the chart.
        /// </summary>
        /// <value>The color of the chart.</value>
        public Brush ChartColor
        {
            get
            {
                return (Brush)GetValue(ChartColorProperty);
            }
            set
            {
                SetValue(ChartColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the chart color mouse over.
        /// </summary>
        /// <value>The chart color mouse over.</value>
        public Brush ChartColorMouseOver
        {
            get
            {
                return (Brush)GetValue(ChartColorMouseOverProperty);
            }
            set
            {
                SetValue(ChartColorMouseOverProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the chart legend visibility.
        /// </summary>
        /// <value>The chart legend visibility.</value>
        public Visibility ChartLegendVisibility
        {
            get
            {
                return (Visibility)GetValue(ChartLegendVisibilityProperty);
            }
            set
            {
                SetValue(ChartLegendVisibilityProperty, value);
            }
        }

        #endregion Properties

        private ObservableCollection<string> gridLines = new ObservableCollection<string>();
        public ObservableCollection<string> GridLines
        {
            get
            {
                return gridLines;                
            }
        }

        
		
    }
}