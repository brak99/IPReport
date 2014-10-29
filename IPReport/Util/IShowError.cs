using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPReport.Util
{
	public interface IShowError
	{
		void ShowError(string errorMessage, string errorTitle);
		void ShowWarning(string warningMessage, string warningTitle);
	}
}
