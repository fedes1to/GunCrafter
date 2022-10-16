using System;
using System.Runtime.CompilerServices;
using Com.Google.Android.Gms.Common.Api;
using Com.Google.Android.Gms.Games;
using Com.Google.Android.Gms.Games.Stats;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android
{
	internal class AndroidClient : IClientImpl
	{
		private class StatsResultCallback : ResultCallbackProxy<Stats_LoadPlayerStatsResultObject>
		{
			private Action<int, Com.Google.Android.Gms.Games.Stats.PlayerStats> callback;

			public StatsResultCallback(Action<int, Com.Google.Android.Gms.Games.Stats.PlayerStats> callback)
			{
				this.callback = callback;
			}

			public override void OnResult(Stats_LoadPlayerStatsResultObject arg_Result_1)
			{
				callback(arg_Result_1.getStatus().getStatusCode(), arg_Result_1.getPlayerStats());
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetPlayerStats_003Ec__AnonStorey1
		{
			internal Action<CommonStatusCodes, GooglePlayGames.BasicApi.PlayerStats> callback;

			internal void _003C_003Em__0(int result, Com.Google.Android.Gms.Games.Stats.PlayerStats stats)
			{
				Debug.Log("Result for getStats: " + result);
				GooglePlayGames.BasicApi.PlayerStats arg = null;
				if (stats != null)
				{
					arg = new GooglePlayGames.BasicApi.PlayerStats
					{
						AvgSessonLength = stats.getAverageSessionLength(),
						DaysSinceLastPlayed = stats.getDaysSinceLastPlayed(),
						NumberOfPurchases = stats.getNumberOfPurchases(),
						NumberOfSessions = stats.getNumberOfSessions(),
						SessPercentile = stats.getSessionPercentile(),
						SpendPercentile = stats.getSpendPercentile(),
						ChurnProbability = stats.getChurnProbability(),
						SpendProbability = stats.getSpendProbability(),
						HighSpenderProbability = stats.getHighSpenderProbability(),
						TotalSpendNext28Days = stats.getTotalSpendNext28Days()
					};
				}
				callback((CommonStatusCodes)result, arg);
			}
		}

		[CompilerGenerated]
		private sealed class _003CCreatePlatformConfiguration_003Ec__AnonStorey0
		{
			internal IntPtr intentRef;

			internal void _003C_003Em__0()
			{
				try
				{
					LaunchBridgeIntent(intentRef);
				}
				finally
				{
					AndroidJNI.DeleteGlobalRef(intentRef);
				}
			}
		}

		internal const string BridgeActivityClass = "com.google.games.bridge.NativeBridgeActivity";

		private const string LaunchBridgeMethod = "launchBridgeIntent";

		private const string LaunchBridgeSignature = "(Landroid/app/Activity;Landroid/content/Intent;)V";

		private TokenClient tokenClient;

		private static AndroidJavaObject invisible;

		[CompilerGenerated]
		private static Action<IntPtr> _003C_003Ef__am_0024cache0;

		public PlatformConfiguration CreatePlatformConfiguration(PlayGamesClientConfiguration clientConfig)
		{
			AndroidPlatformConfiguration androidPlatformConfiguration = AndroidPlatformConfiguration.Create();
			using (AndroidJavaObject androidJavaObject = AndroidTokenClient.GetActivity())
			{
				androidPlatformConfiguration.SetActivity(androidJavaObject.GetRawObject());
				if (_003C_003Ef__am_0024cache0 == null)
				{
					_003C_003Ef__am_0024cache0 = _003CCreatePlatformConfiguration_003Em__0;
				}
				androidPlatformConfiguration.SetOptionalIntentHandlerForUI(_003C_003Ef__am_0024cache0);
				if (clientConfig.IsHidingPopups)
				{
					androidPlatformConfiguration.SetOptionalViewForPopups(CreateHiddenView(androidJavaObject.GetRawObject()));
					return androidPlatformConfiguration;
				}
				return androidPlatformConfiguration;
			}
		}

		public TokenClient CreateTokenClient(bool reset)
		{
			if (tokenClient == null)
			{
				tokenClient = new AndroidTokenClient();
			}
			else if (reset)
			{
				tokenClient.Signout();
			}
			return tokenClient;
		}

		private IntPtr CreateHiddenView(IntPtr activity)
		{
			if (invisible == null || invisible.GetRawObject() == IntPtr.Zero)
			{
				invisible = new AndroidJavaObject("android.view.View", activity);
				invisible.Call("setVisibility", 4);
				invisible.Call("setClickable", false);
			}
			return invisible.GetRawObject();
		}

		private static void LaunchBridgeIntent(IntPtr bridgedIntent)
		{
			object[] args = new object[2];
			jvalue[] array = AndroidJNIHelper.CreateJNIArgArray(args);
			try
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.NativeBridgeActivity"))
				{
					using (AndroidJavaObject androidJavaObject = AndroidTokenClient.GetActivity())
					{
						IntPtr staticMethodID = AndroidJNI.GetStaticMethodID(androidJavaClass.GetRawClass(), "launchBridgeIntent", "(Landroid/app/Activity;Landroid/content/Intent;)V");
						array[0].l = androidJavaObject.GetRawObject();
						array[1].l = bridgedIntent;
						AndroidJNI.CallStaticVoidMethod(androidJavaClass.GetRawClass(), staticMethodID, array);
					}
				}
			}
			catch (Exception ex)
			{
				GooglePlayGames.OurUtils.Logger.e("Exception launching bridge intent: " + ex.Message);
				GooglePlayGames.OurUtils.Logger.e(ex.ToString());
			}
			finally
			{
				AndroidJNIHelper.DeleteJNIArgArray(args, array);
			}
		}

		public void Signout()
		{
			if (tokenClient != null)
			{
				tokenClient.Signout();
			}
		}

		public void GetPlayerStats(IntPtr apiClient, Action<CommonStatusCodes, GooglePlayGames.BasicApi.PlayerStats> callback)
		{
			_003CGetPlayerStats_003Ec__AnonStorey1 _003CGetPlayerStats_003Ec__AnonStorey = new _003CGetPlayerStats_003Ec__AnonStorey1();
			_003CGetPlayerStats_003Ec__AnonStorey.callback = callback;
			GoogleApiClient arg_GoogleApiClient_ = new GoogleApiClient(apiClient);
			StatsResultCallback resultCallback;
			try
			{
				resultCallback = new StatsResultCallback(_003CGetPlayerStats_003Ec__AnonStorey._003C_003Em__0);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				_003CGetPlayerStats_003Ec__AnonStorey.callback(CommonStatusCodes.DeveloperError, null);
				return;
			}
			PendingResult<Stats_LoadPlayerStatsResultObject> pendingResult = Games.Stats.loadPlayerStats(arg_GoogleApiClient_, true);
			pendingResult.setResultCallback(resultCallback);
		}

		public void SetGravityForPopups(IntPtr apiClient, Gravity gravity)
		{
			GoogleApiClient arg_GoogleApiClient_ = new GoogleApiClient(apiClient);
			Games.setGravityForPopups(arg_GoogleApiClient_, (int)(gravity | Gravity.CENTER_HORIZONTAL));
		}

		[CompilerGenerated]
		private static void _003CCreatePlatformConfiguration_003Em__0(IntPtr intent)
		{
			_003CCreatePlatformConfiguration_003Ec__AnonStorey0 _003CCreatePlatformConfiguration_003Ec__AnonStorey = new _003CCreatePlatformConfiguration_003Ec__AnonStorey0();
			_003CCreatePlatformConfiguration_003Ec__AnonStorey.intentRef = AndroidJNI.NewGlobalRef(intent);
			PlayGamesHelperObject.RunOnGameThread(_003CCreatePlatformConfiguration_003Ec__AnonStorey._003C_003Em__0);
		}
	}
}
