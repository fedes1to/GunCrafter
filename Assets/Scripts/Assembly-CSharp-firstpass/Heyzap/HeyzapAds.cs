using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Heyzap
{
	public class HeyzapAds : MonoBehaviour
	{
		public delegate void NetworkCallbackListener(string network, string callback);

		public static class NetworkCallback
		{
			public const string INITIALIZED = "initialized";

			public const string SHOW = "show";

			public const string SHOW_FAILED = "failed";

			public const string AVAILABLE = "available";

			public const string HIDE = "hide";

			public const string FETCH_FAILED = "fetch_failed";

			public const string CLICK = "click";

			public const string DISMISS = "dismiss";

			public const string INCENTIVIZED_RESULT_COMPLETE = "incentivized_result_complete";

			public const string INCENTIVIZED_RESULT_INCOMPLETE = "incentivized_result_incomplete";

			public const string AUDIO_STARTING = "audio_starting";

			public const string AUDIO_FINISHED = "audio_finished";

			public const string BANNER_LOADED = "banner-loaded";

			public const string BANNER_CLICK = "banner-click";

			public const string BANNER_HIDE = "banner-hide";

			public const string BANNER_DISMISS = "banner-dismiss";

			public const string BANNER_FETCH_FAILED = "banner-fetch_failed";

			public const string LEAVE_APPLICATION = "leave_application";

			public const string FACEBOOK_LOGGING_IMPRESSION = "logging_impression";
		}

		public static class Network
		{
			public const string HEYZAP = "heyzap";

			public const string HEYZAP_CROSS_PROMO = "heyzap_cross_promo";

			public const string HEYZAP_EXCHANGE = "heyzap_exchange";

			public const string FACEBOOK = "facebook";

			public const string UNITYADS = "unityads";

			public const string APPLOVIN = "applovin";

			public const string VUNGLE = "vungle";

			public const string CHARTBOOST = "chartboost";

			public const string ADCOLONY = "adcolony";

			public const string ADMOB = "admob";

			public const string IAD = "iad";

			public const string LEADBOLT = "leadbolt";

			public const string INMOBI = "inmobi";

			public const string DOMOB = "domob";

			public const string MOPUB = "mopub";

			public const string FYBER_EXCHANGE = "fyber_exchange";
		}

		private static NetworkCallbackListener networkCallbackListener;

		private static HeyzapAds _instance;

		public const int FLAG_NO_OPTIONS = 0;

		public const int FLAG_DISABLE_AUTOMATIC_FETCHING = 1;

		public const int FLAG_INSTALL_TRACKING_ONLY = 2;

		public const int FLAG_AMAZON = 4;

		public const int FLAG_DISABLE_MEDIATION = 8;

		public const int FLAG_DISABLE_AUTOMATIC_IAP_RECORDING = 16;

		public const int FLAG_NATIVE_ADS_ONLY = 32;

		public const int FLAG_CHILD_DIRECTED_ADS = 64;

		public const string DEFAULT_TAG = "default";

		[CompilerGenerated]
		private static Func<KeyValuePair<string, string>, string> _003C_003Ef__am_0024cache0;

		public static void Start(string publisher_id, int options)
		{
			HeyzapAdsAndroid.Start(publisher_id, options);
			InitReceiver();
			HZInterstitialAd.InitReceiver();
			HZVideoAd.InitReceiver();
			HZIncentivizedAd.InitReceiver();
			HZBannerAd.InitReceiver();
			HZOfferWallAd.InitReceiver();
			HZDemographics.InitReceiver();
		}

		public static string GetRemoteData()
		{
			return HeyzapAdsAndroid.GetRemoteData();
		}

		public static void SetGdprConsent(bool isGdprConsentGiven)
		{
			HeyzapAdsAndroid.SetGdprConsent(isGdprConsentGiven);
		}

		public static void SetGdprConsentData(Dictionary<string, string> gdprConsentData)
		{
			string gdprConsentData2 = null;
			if (gdprConsentData != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (KeyValuePair<string, string> gdprConsentDatum in gdprConsentData)
				{
					if (gdprConsentDatum.Value != null)
					{
						dictionary.Add(gdprConsentDatum.Key, gdprConsentDatum.Value);
					}
				}
				gdprConsentData2 = GetGdprConsentDataAsJsonString(dictionary);
			}
			HeyzapAdsAndroid.SetGdprConsentData(gdprConsentData2);
		}

		public static void ClearGdprConsentData()
		{
			HeyzapAdsAndroid.ClearGdprConsentData();
		}

		public static void ShowMediationTestSuite()
		{
			HeyzapAdsAndroid.ShowMediationTestSuite();
		}

		public static bool OnBackPressed()
		{
			return HeyzapAdsAndroid.OnBackPressed();
		}

		public static bool IsNetworkInitialized(string network)
		{
			return HeyzapAdsAndroid.IsNetworkInitialized(network);
		}

		public static void SetNetworkCallbackListener(NetworkCallbackListener listener)
		{
			networkCallbackListener = listener;
		}

		public static void PauseExpensiveWork()
		{
			HeyzapAdsAndroid.PauseExpensiveWork();
		}

		public static void ResumeExpensiveWork()
		{
			HeyzapAdsAndroid.ResumeExpensiveWork();
		}

		public static void ShowDebugLogs()
		{
			HeyzapAdsAndroid.ShowDebugLogs();
		}

		public static void HideDebugLogs()
		{
			HeyzapAdsAndroid.HideDebugLogs();
		}

		public static void ShowThirdPartyDebugLogs()
		{
		}

		public static void HideThirdPartyDebugLogs()
		{
		}

		public static void SetBundleIdentifier(string bundleID)
		{
			HeyzapAdsAndroid.SetBundleIdentifier(bundleID);
		}

		public static void AddFacebookTestDevice(string device_id)
		{
		}

		public void SetNetworkCallbackMessage(string message)
		{
			string[] array = message.Split(',');
			SetNetworkCallback(array[0], array[1]);
		}

		protected static void SetNetworkCallback(string network, string callback)
		{
			if (networkCallbackListener != null)
			{
				networkCallbackListener(network, callback);
			}
		}

		public static void InitReceiver()
		{
			if (_instance == null)
			{
				GameObject gameObject = new GameObject("HeyzapAds");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				_instance = gameObject.AddComponent<HeyzapAds>();
			}
		}

		public static string TagForString(string tag)
		{
			if (tag == null)
			{
				tag = "default";
			}
			return tag;
		}

		private static string GetGdprConsentDataAsJsonString(Dictionary<string, string> gdprConsentData)
		{
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003CGetGdprConsentDataAsJsonString_003Em__0;
			}
			IEnumerable<string> source = gdprConsentData.Select(_003C_003Ef__am_0024cache0);
			return "{" + string.Join(",", source.ToArray()) + "}";
		}

		[CompilerGenerated]
		private static string _003CGetGdprConsentDataAsJsonString_003Em__0(KeyValuePair<string, string> d)
		{
			return string.Format("\"{0}\": \"{1}\"", d.Key, d.Value);
		}
	}
}
