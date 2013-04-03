
using System.Windows;
using System.Reflection;
using System;

namespace De.TorstenMandelkow.MetroChart
{
	public class PerformanceTargetDataPointGroup : DataPointGroup
	{
		public static readonly DependencyProperty PerformanceTargetProperty =
			DependencyProperty.Register("PerformanceTargetMember",
			typeof(string),
			typeof(PerformanceTargetDataPointGroup),
			new PropertyMetadata(null));

		public static readonly DependencyProperty ActualPerformanceProperty =
			DependencyProperty.Register("ActualPerformanceMember",
			typeof(string),
			typeof(PerformanceTargetDataPointGroup),
			new PropertyMetadata(null));

		public string PerformanceTargetMember
		{
			get { return (string)GetValue(PerformanceTargetProperty); }
			set { SetValue(PerformanceTargetProperty, value); }
		}

		public string ActualPerformanceMember
		{
			get { return (string)GetValue(ActualPerformanceProperty); }
			set { SetValue(ActualPerformanceProperty, value); }
		}

		public double ActualPerformance
		{
			get
			{
				if (ReferencedObject == null)
				{
					return 0.0d;
				}
				return double.Parse(GetItemValue(ReferencedObject, ActualPerformanceMember).ToString());
			}
		}

		public double PerformanceTarget
		{
			get
			{
				if (ReferencedObject == null)
				{
					return 0.0d;
				}
				return double.Parse(GetItemValue(ReferencedObject, PerformanceTargetMember).ToString());
			}
		}

		private string GetItemValue(object item, string propertyName)
		{
			if (item != null)
			{
				foreach (PropertyInfo info in item.GetType().GetAllProperties())
				{
					if (info.Name == propertyName)
					{
						object v = info.GetValue(item, null);
						return v.ToString();
					}
				}
				throw new Exception(string.Format("Property '{0}' not found on item of type '{1}'", propertyName, item.GetType().ToString()));
			}
			return null;
		}
	}
}
