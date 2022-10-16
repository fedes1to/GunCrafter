using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GooglePlayGames.OurUtils
{
	public class Logger
	{
		[CompilerGenerated]
		private sealed class _003Cd_003Ec__AnonStorey0
		{
			internal string msg;

			internal void _003C_003Em__0()
			{
				Debug.Log(ToLogMessage(string.Empty, "DEBUG", msg));
			}
		}

		[CompilerGenerated]
		private sealed class _003Cw_003Ec__AnonStorey1
		{
			internal string msg;

			internal void _003C_003Em__0()
			{
				Debug.LogWarning(ToLogMessage("!!!", "WARNING", msg));
			}
		}

		[CompilerGenerated]
		private sealed class _003Ce_003Ec__AnonStorey2
		{
			internal string msg;

			internal void _003C_003Em__0()
			{
				Debug.LogWarning(ToLogMessage("***", "ERROR", msg));
			}
		}

		private static bool debugLogEnabled;

		private static bool warningLogEnabled = true;

		public static bool DebugLogEnabled
		{
			get
			{
				return debugLogEnabled;
			}
			set
			{
				debugLogEnabled = value;
			}
		}

		public static bool WarningLogEnabled
		{
			get
			{
				return warningLogEnabled;
			}
			set
			{
				warningLogEnabled = value;
			}
		}

		public static void d(string msg)
		{
			_003Cd_003Ec__AnonStorey0 _003Cd_003Ec__AnonStorey = new _003Cd_003Ec__AnonStorey0();
			_003Cd_003Ec__AnonStorey.msg = msg;
			if (debugLogEnabled)
			{
				PlayGamesHelperObject.RunOnGameThread(_003Cd_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public static void w(string msg)
		{
			_003Cw_003Ec__AnonStorey1 _003Cw_003Ec__AnonStorey = new _003Cw_003Ec__AnonStorey1();
			_003Cw_003Ec__AnonStorey.msg = msg;
			if (warningLogEnabled)
			{
				PlayGamesHelperObject.RunOnGameThread(_003Cw_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public static void e(string msg)
		{
			_003Ce_003Ec__AnonStorey2 _003Ce_003Ec__AnonStorey = new _003Ce_003Ec__AnonStorey2();
			_003Ce_003Ec__AnonStorey.msg = msg;
			if (warningLogEnabled)
			{
				PlayGamesHelperObject.RunOnGameThread(_003Ce_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public static string describe(byte[] b)
		{
			return (b != null) ? ("byte[" + b.Length + "]") : "(null)";
		}

		private static string ToLogMessage(string prefix, string logType, string msg)
		{
			return string.Format("{0} [Play Games Plugin DLL] {1} {2}: {3}", prefix, DateTime.Now.ToString("MM/dd/yy H:mm:ss zzz"), logType, msg);
		}
	}
}
