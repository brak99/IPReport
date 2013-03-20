using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPReport.DataAccess;
using IPReport.Model;

namespace IPReport.ViewModel
{
	public class AllDepartmentsRetailValueViewModel : WorkspaceViewModel
	{
		public static AllDepartmentsRetailValueViewModel GetInstance()
		{
			return new AllDepartmentsRetailValueViewModel();
		}

		private AllDepartmentsRetailValueViewModel()
		{

		}

		public override string DisplayName
		{
			get
			{
				return "All Departments Retail Value";
			}
		} 

		public void Refresh()
		{
			foreach (Store store in StoreRepository.Instance.Stores)
			{

			}
		}
	}
}
