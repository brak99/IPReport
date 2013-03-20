using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.ViewModel
{
    public class SalesDashboardViewModel : WorkspaceViewModel
    {
        public static SalesDashboardViewModel GetInstance()
        {
            return new SalesDashboardViewModel();
        }

        protected SalesDashboardViewModel()
        {

        }
    }
}
