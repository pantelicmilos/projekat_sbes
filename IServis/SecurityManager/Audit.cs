using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SecurityManager
{
	public class Audit : IDisposable
	{

		private static EventLog customLog = null;
		const string SourceName = "SecurityManager.Audit";
		const string LogName = "MySecTest";

		static Audit()
		{
			try
			{
				if (!EventLog.SourceExists(SourceName))
				{
					EventLog.CreateEventSource(SourceName, LogName);
				}
				customLog = new EventLog(LogName,
					Environment.MachineName, SourceName);
			}
			catch (Exception e)
			{
				customLog = null;
				Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
			}
		}


		public static void PokreniTimerUspesno(string userName)
		{
			//TO DO

			if (customLog != null)
			{
				string UserPokreniTimerUspesno =
					AuditEvents.PokreniTimerUspesno;
				string message = String.Format(UserPokreniTimerUspesno,
					userName);
				customLog.WriteEntry(message);
			}
			else
			{
				throw new ArgumentException(string.Format("Error while trying to start timer event (eventid = {0}) to event log.",
					(int)AuditEventTypes.PokreniTimerUspesno));
			}
		}

		public static void ZaustaviTimerUspesno(string userName)
		{
			//TO DO
			if (customLog != null)
			{
				string UserZaustaviTimerUspesno =
					AuditEvents.ZaustaviTimerUspesno;
				string message = String.Format(UserZaustaviTimerUspesno,
					userName);
				customLog.WriteEntry(message);
			}
			else
			{
				throw new ArgumentException(string.Format("Error while trying to stop timer event (eventid = {0}) to event log.",
					(int)AuditEventTypes.ZaustaviTimerUspesno));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="serviceName"> should be read from the OperationContext as follows: OperationContext.Current.IncomingMessageHeaders.Action</param>
		/// <param name="reason">permission name</param>
		public static void PonistiTimerUspesno(string userName)
		{
			if (customLog != null)
			{
				string UserPonistiTimerUspesno =
					AuditEvents.PonistiTimerUspesno;
				string message = String.Format(UserPonistiTimerUspesno,
					userName);
				customLog.WriteEntry(message);
			}
			else
			{
				throw new ArgumentException(string.Format("Error while trying to cancel timer event (eventid = {0}) to event log.",
					(int)AuditEventTypes.PonistiTimerUspesno));
			}
		}

		public static void PostaviTimerUspesno(string userName)
		{
			//TO DO
			if (customLog != null)
			{
				string UserPostaviTimerUspesno =
					AuditEvents.PostaviTimerUspesno;
				string message = String.Format(UserPostaviTimerUspesno,
					userName);
				customLog.WriteEntry(message);
			}
			else
			{
				throw new ArgumentException(string.Format("Error while trying to set timer event (eventid = {0}) to event log.",
					(int)AuditEventTypes.PostaviTimerUspesno));
			}
		}

		public void Dispose()
		{
			if (customLog != null)
			{
				customLog.Dispose();
				customLog = null;
			}
		}
	}
}
