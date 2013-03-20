using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IPReport.Util;

namespace IPReport.Test
{
	class TestQBQueryService : IQuickBooksQueryService
	{
		public string Query(string queryString)
		{
			string queryReturn = "";

			if (queryString.Contains("DepartmentQueryRq"))
			{
				queryReturn = TestResponses.DepartmentResponse;
			}
			else if (queryString.Contains("ItemInventoryQueryRq"))
			{
				queryReturn = TestResponses.InventoryResponse;
			}

			return queryReturn;
		}
	}
}
