using System;
using System.Collections;
namespace De.TorstenMandelkow.MetroChart
{
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
        public ChartSeries()
        {   
        }
    }
}
