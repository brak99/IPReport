using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interop.QBPOSXMLRPLIB;

namespace IPReport.Util
{
	class QuickBooksQuery : IQuickBooksQueryService
	{
		private RequestProcessor _requestProcessor = new RequestProcessor();
		private string _connectionString = "";

		public string Query(string queryString)
		{
			bool connectionOpen = false;
			bool sessionBegun = false;
			string ticket = "";
			string response = "";

			try
			{
				_requestProcessor.OpenConnection("80042", "IPReport");
				connectionOpen = true;
				ticket = _requestProcessor.BeginSession(_connectionString);

				response = _requestProcessor.ProcessRequest(ticket, queryString);

				//resultBox.Text = responseStr;

				//End the session and close the connection to QuickBooks
				_requestProcessor.EndSession(ticket);
				sessionBegun = false;
				_requestProcessor.CloseConnection();
				connectionOpen = false;
			}
			catch (System.Exception)
			{
				if (sessionBegun)
				{
					_requestProcessor.EndSession(ticket);

				}
				if (connectionOpen)
				{
					_requestProcessor.CloseConnection();
				}
			}

			return response;
		}
	}
}
