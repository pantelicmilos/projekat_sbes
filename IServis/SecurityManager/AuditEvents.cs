using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace SecurityManager
{
	public enum AuditEventTypes
	{

		//promeni na svoje metode
		//razlika izmedju modova

		PokreniTimerUspesno = 0,
		ZaustaviTimerUspesno = 1,
		PonistiTimerUspesno = 2,
		PostaviTimerUspesno = 3
	}

	public class AuditEvents
	{
		private static ResourceManager resourceManager = null;
		private static object resourceLock = new object();

		private static ResourceManager ResourceMgr
		{
			get
			{
				lock (resourceLock)
				{
					if (resourceManager == null)
					{
						resourceManager = new ResourceManager
							(typeof(AuditEventFile).ToString(),
							Assembly.GetExecutingAssembly());
					}
					return resourceManager;
				}
			}
		}

		public static string PokreniTimerUspesno
		{
			get
			{
				// TO DO
				return ResourceMgr.GetString(AuditEventTypes.PokreniTimerUspesno.ToString());
			}
		}

		public static string ZaustaviTimerUspesno
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.ZaustaviTimerUspesno.ToString());
			}
		}

		public static string PonistiTimerUspesno
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.PonistiTimerUspesno.ToString());
			}
		}

		public static string PostaviTimerUspesno
		{
			get
			{
				//TO DO
				return ResourceMgr.GetString(AuditEventTypes.PostaviTimerUspesno.ToString());
			}
		}
	}
}
