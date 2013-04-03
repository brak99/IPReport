using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using De.TorstenMandelkow.MetroChart;
using System.Windows;

namespace De.TorstenMandelkow.MetroChart
{
	public class BulletGraph : ChartBase
	{
		static BulletGraph()
		{
#if NETFX_CORE
                        
#elif SILVERLIGHT
    
#else
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BulletGraph), new FrameworkPropertyMetadata(typeof(BulletGraph)));
#endif
		}

		public BulletGraph()
		{

		}
		protected override double GridLinesMaxValue
		{
			get
			{
				return MaxDataPointGroupSum;
			}
		}

		protected override void OnMaxDataPointGroupSumChanged(double p)
		{
			UpdateGridLines();
		}
	}
}
