using UnityEngine;

namespace ChartboostSDK
{
	public class CBExternal
	{
		private static bool initialized;

		private static string _logTag = "ChartboostSDK";

		private static AndroidJavaObject _plugin;

		public static void Log(string message)
		{
			if (Debug.isDebugBuild && !Application.isEditor)
			{
				Debug.Log(_logTag + "/" + message);
			}
		}

		public static bool isInitialized()
		{
			return initialized;
		}

		private static bool checkInitialized()
		{
			if (initialized)
			{
				return true;
			}
			Debug.LogError("The Chartboost SDK needs to be initialized before we can show any ads");
			return false;
		}

		public static void init()
		{
		}

		public static void initWithAppId(string appId, string appSignature)
		{
		}

		public static bool isAnyViewVisible()
		{
			bool result = false;
			if (!checkInitialized())
			{
				return result;
			}
			result = _plugin.Call<bool>("isAnyViewVisible", new object[0]);
			Log("Android : isAnyViewVisible = " + result);
			return result;
		}

		public static void cacheInterstitial(CBLocation location)
		{
			if (checkInitialized())
			{
				if (location == null)
				{
					Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
					return;
				}
				_plugin.Call("cacheInterstitial", location.ToString());
				Log("Android : cacheInterstitial at location = " + location.ToString());
			}
		}

		public static bool hasInterstitial(CBLocation location)
		{
			if (!checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			Log("Android : hasInterstitial at location = " + location.ToString());
			return _plugin.Call<bool>("hasInterstitial", new object[1] { location.ToString() });
		}

		public static void showInterstitial(CBLocation location)
		{
			if (checkInitialized())
			{
				if (location == null)
				{
					Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
					return;
				}
				_plugin.Call("showInterstitial", location.ToString());
				Log("Android : showInterstitial at location = " + location.ToString());
			}
		}

		public static void cacheInPlay(CBLocation location)
		{
			if (checkInitialized())
			{
				if (location == null)
				{
					Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
					return;
				}
				_plugin.Call("cacheInPlay", location.ToString());
				Log("Android : cacheInPlay at location = " + location.ToString());
			}
		}

		public static bool hasInPlay(CBLocation location)
		{
			if (!checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			Log("Android : hasInPlay at location = " + location.ToString());
			return _plugin.Call<bool>("hasCachedInPlay", new object[1] { location.ToString() });
		}

		public static CBInPlay getInPlay(CBLocation location)
		{
			Log("Android : getInPlay at location = " + location.ToString());
			if (!checkInitialized())
			{
				return null;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return null;
			}
			try
			{
				AndroidJavaObject inPlayAd = _plugin.Call<AndroidJavaObject>("getInPlay", new object[1] { location.ToString() });
				return new CBInPlay(inPlayAd, _plugin);
			}
			catch
			{
				return null;
			}
		}

		public static void cacheRewardedVideo(CBLocation location)
		{
			if (checkInitialized())
			{
				if (location == null)
				{
					Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
					return;
				}
				_plugin.Call("cacheRewardedVideo", location.ToString());
				Log("Android : cacheRewardedVideo at location = " + location.ToString());
			}
		}

		public static bool hasRewardedVideo(CBLocation location)
		{
			if (!checkInitialized())
			{
				return false;
			}
			if (location == null)
			{
				Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
				return false;
			}
			Log("Android : hasRewardedVideo at location = " + location.ToString());
			return _plugin.Call<bool>("hasRewardedVideo", new object[1] { location.ToString() });
		}

		public static void showRewardedVideo(CBLocation location)
		{
			if (checkInitialized())
			{
				if (location == null)
				{
					Debug.LogError("Chartboost SDK: location passed is null cannot perform the operation requested");
					return;
				}
				_plugin.Call("showRewardedVideo", location.ToString());
				Log("Android : showRewardedVideo at location = " + location.ToString());
			}
		}

		public static void chartBoostShouldDisplayInterstitialCallbackResult(bool result)
		{
			if (checkInitialized())
			{
				_plugin.Call("chartBoostShouldDisplayInterstitialCallbackResult", result);
				Log("Android : chartBoostShouldDisplayInterstitialCallbackResult");
			}
		}

		public static void chartBoostShouldDisplayRewardedVideoCallbackResult(bool result)
		{
			if (checkInitialized())
			{
				_plugin.Call("chartBoostShouldDisplayRewardedVideoCallbackResult", result);
				Log("Android : chartBoostShouldDisplayRewardedVideoCallbackResult");
			}
		}

		public static void didPassAgeGate(bool pass)
		{
			_plugin.Call("didPassAgeGate", pass);
		}

		public static void setShouldPauseClickForConfirmation(bool shouldPause)
		{
			_plugin.Call("setShouldPauseClickForConfirmation", shouldPause);
		}

		public static string getCustomId()
		{
			return _plugin.Call<string>("getCustomId", new object[0]);
		}

		public static void setCustomId(string customId)
		{
			_plugin.Call("setCustomId", customId);
		}

		public static bool getAutoCacheAds()
		{
			return _plugin.Call<bool>("getAutoCacheAds", new object[0]);
		}

		public static void setAutoCacheAds(bool autoCacheAds)
		{
			_plugin.Call("setAutoCacheAds", autoCacheAds);
		}

		public static void setShouldRequestInterstitialsInFirstSession(bool shouldRequest)
		{
			_plugin.Call("setShouldRequestInterstitialsInFirstSession", shouldRequest);
		}

		public static void setShouldPrefetchVideoContent(bool shouldPrefetch)
		{
			_plugin.Call("setShouldPrefetchVideoContent", shouldPrefetch);
		}

		public static void trackLevelInfo(string eventLabel, CBLevelType type, int mainLevel, int subLevel, string description)
		{
			_plugin.Call("trackLevelInfo", eventLabel, (int)type, mainLevel, subLevel, description);
			Log(string.Format("Android : PIA Level Tracking:\n\teventLabel = {0}\n\ttype = {1}\n\tmainLevel = {2}\n\tsubLevel = {3}\n\tdescription = {4}", eventLabel, (int)type, mainLevel, subLevel, description));
		}

		public static void trackLevelInfo(string eventLabel, CBLevelType type, int mainLevel, string description)
		{
			_plugin.Call("trackLevelInfo", eventLabel, (int)type, mainLevel, description);
			Log(string.Format("Android : PIA Level Tracking:\n\teventLabel = {0}\n\ttype = {1}\n\tmainLevel = {2}\n\tdescription = {3}", eventLabel, (int)type, mainLevel, description));
		}

		public static void setGameObjectName(string name)
		{
			_plugin.Call("setGameObjectName", name);
		}

		public static void pause(bool paused)
		{
			if (checkInitialized())
			{
				_plugin.Call("pause", paused);
				Log("Android : pause");
			}
		}

		public static void destroy()
		{
			if (checkInitialized())
			{
				_plugin.Call("destroy");
				initialized = false;
				Log("Android : destroy");
			}
		}

		public static bool onBackPressed()
		{
			bool flag = false;
			if (!checkInitialized())
			{
				return false;
			}
			flag = _plugin.Call<bool>("onBackPressed", new object[0]);
			Log("Android : onBackPressed");
			return flag;
		}

		public static void trackInAppGooglePlayPurchaseEvent(string title, string description, string price, string currency, string productID, string purchaseData, string purchaseSignature)
		{
			Log("Android: trackInAppGooglePlayPurchaseEvent");
			_plugin.Call("trackInAppGooglePlayPurchaseEvent", title, description, price, currency, productID, purchaseData, purchaseSignature);
		}

		public static void trackInAppAmazonStorePurchaseEvent(string title, string description, string price, string currency, string productID, string userID, string purchaseToken)
		{
			Log("Android: trackInAppAmazonStorePurchaseEvent");
			_plugin.Call("trackInAppAmazonStorePurchaseEvent", title, description, price, currency, productID, userID, purchaseToken);
		}

		public static void setMediation(CBMediation mediator, string version)
		{
			_plugin.Call("setMediation", mediator.ToString(), version);
			Log("Android : setMediation to = " + mediator.ToString() + " " + version);
		}

		public static void restrictDataCollection(bool limit)
		{
			Log("Android: restrictDataCollection set to " + limit);
			_plugin.Call("restrictDataCollection", limit);
		}

		public static void setPIDataUseConsent(CBPIDataUseConsent consent)
		{
			Log("Android: setPIDataUseConsent set to " + consent);
			_plugin.Call("setPIDataUseConsent", (int)consent);
		}

		public static void setMuted(bool mute)
		{
			Log("Android: setMuted not supported on Android");
		}

		public static bool isWebViewEnabled()
		{
			return _plugin.Call<bool>("isWebViewEnabled", new object[0]);
		}
	}
}
