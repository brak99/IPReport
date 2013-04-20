using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Diagnostics;

namespace IPReport
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			Application.Current.DispatcherUnhandledException += AppDispatcherUnhandledException;

			base.OnStartup(e);
		}

		void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			string message = string.Format("UNHANDLED EXCEPTION: {0} - {1}\n\n{2}", e.Exception.GetType(), e.Exception.Message, e.Exception.StackTrace);
			//EventLog.WriteEntry("IPReport", message, EventLogEntryType.Error);
			MessageBox.Show(message);
			if (e.Exception.InnerException != null)
			{
				message = string.Format("Inner EXCEPTION: {0} - {1}\n\n{2}", e.Exception.InnerException.GetType(), e.Exception.InnerException.Message, e.Exception.InnerException.StackTrace);
				//EventLog.WriteEntry("IPReport", message, EventLogEntryType.Error);
				MessageBox.Show(message);
			}
			
		}
	}
}
