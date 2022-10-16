using System;
using System.Runtime.CompilerServices;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal static class CallbackUtils
	{
		[CompilerGenerated]
		private sealed class _003CToOnGameThread_003Ec__AnonStorey0<T>
		{
			private sealed class _003CToOnGameThread_003Ec__AnonStorey1
			{
				internal T val;

				internal _003CToOnGameThread_003Ec__AnonStorey0<T> _003C_003Ef__ref_00240;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00240.toConvert(val);
				}
			}

			internal Action<T> toConvert;

			internal void _003C_003Em__0(T val)
			{
				_003CToOnGameThread_003Ec__AnonStorey1 _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey1();
				_003CToOnGameThread_003Ec__AnonStorey._003C_003Ef__ref_00240 = this;
				_003CToOnGameThread_003Ec__AnonStorey.val = val;
				PlayGamesHelperObject.RunOnGameThread(_003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CToOnGameThread_003Ec__AnonStorey2<T1, T2>
		{
			private sealed class _003CToOnGameThread_003Ec__AnonStorey3
			{
				internal T1 val1;

				internal T2 val2;

				internal _003CToOnGameThread_003Ec__AnonStorey2<T1, T2> _003C_003Ef__ref_00242;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00242.toConvert(val1, val2);
				}
			}

			internal Action<T1, T2> toConvert;

			internal void _003C_003Em__0(T1 val1, T2 val2)
			{
				_003CToOnGameThread_003Ec__AnonStorey3 _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey3();
				_003CToOnGameThread_003Ec__AnonStorey._003C_003Ef__ref_00242 = this;
				_003CToOnGameThread_003Ec__AnonStorey.val1 = val1;
				_003CToOnGameThread_003Ec__AnonStorey.val2 = val2;
				PlayGamesHelperObject.RunOnGameThread(_003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CToOnGameThread_003Ec__AnonStorey4<T1, T2, T3>
		{
			private sealed class _003CToOnGameThread_003Ec__AnonStorey5
			{
				internal T1 val1;

				internal T2 val2;

				internal T3 val3;

				internal _003CToOnGameThread_003Ec__AnonStorey4<T1, T2, T3> _003C_003Ef__ref_00244;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00244.toConvert(val1, val2, val3);
				}
			}

			internal Action<T1, T2, T3> toConvert;

			internal void _003C_003Em__0(T1 val1, T2 val2, T3 val3)
			{
				_003CToOnGameThread_003Ec__AnonStorey5 _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey5();
				_003CToOnGameThread_003Ec__AnonStorey._003C_003Ef__ref_00244 = this;
				_003CToOnGameThread_003Ec__AnonStorey.val1 = val1;
				_003CToOnGameThread_003Ec__AnonStorey.val2 = val2;
				_003CToOnGameThread_003Ec__AnonStorey.val3 = val3;
				PlayGamesHelperObject.RunOnGameThread(_003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		internal static Action<T> ToOnGameThread<T>(Action<T> toConvert)
		{
			_003CToOnGameThread_003Ec__AnonStorey0<T> _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey0<T>();
			_003CToOnGameThread_003Ec__AnonStorey.toConvert = toConvert;
			if (_003CToOnGameThread_003Ec__AnonStorey.toConvert == null)
			{
				return _003CToOnGameThread_00601_003Em__0;
			}
			return _003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0;
		}

		internal static Action<T1, T2> ToOnGameThread<T1, T2>(Action<T1, T2> toConvert)
		{
			_003CToOnGameThread_003Ec__AnonStorey2<T1, T2> _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey2<T1, T2>();
			_003CToOnGameThread_003Ec__AnonStorey.toConvert = toConvert;
			if (_003CToOnGameThread_003Ec__AnonStorey.toConvert == null)
			{
				return _003CToOnGameThread_00602_003Em__1;
			}
			return _003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0;
		}

		internal static Action<T1, T2, T3> ToOnGameThread<T1, T2, T3>(Action<T1, T2, T3> toConvert)
		{
			_003CToOnGameThread_003Ec__AnonStorey4<T1, T2, T3> _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey4<T1, T2, T3>();
			_003CToOnGameThread_003Ec__AnonStorey.toConvert = toConvert;
			if (_003CToOnGameThread_003Ec__AnonStorey.toConvert == null)
			{
				return _003CToOnGameThread_00603_003Em__2;
			}
			return _003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0;
		}

		[CompilerGenerated]
		private static void _003CToOnGameThread_00601_003Em__0<T>(T P_0)
		{
		}

		[CompilerGenerated]
		private static void _003CToOnGameThread_00602_003Em__1<T1, T2>(T1 P_0, T2 P_1)
		{
		}

		[CompilerGenerated]
		private static void _003CToOnGameThread_00603_003Em__2<T1, T2, T3>(T1 P_0, T2 P_1, T3 P_2)
		{
		}
	}
}
