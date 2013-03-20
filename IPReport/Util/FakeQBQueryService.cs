using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	public class FakeQBQueryService : IQuickBooksQueryService
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
			else if (queryString.Contains("SalesReceiptQueryRq"))
			{
				queryReturn = TestResponses.SalesReceiptResponse;
			}
			else if (queryString.Contains("TransferSlipQueryRq"))
			{
				queryReturn = TestResponses.TransferFromStoreResponse;
			}
			else if (queryString.Contains("VoucherQueryRq"))
			{
				queryReturn = TestResponses.VoucherQueryResponse;
			}
			return queryReturn;
		}
	}
}
