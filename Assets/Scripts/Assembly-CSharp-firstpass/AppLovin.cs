using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AppLovin
{
	public const float AD_POSITION_CENTER = -10000f;

	public const float AD_POSITION_LEFT = -20000f;

	public const float AD_POSITION_RIGHT = -30000f;

	public const float AD_POSITION_TOP = -40000f;

	public const float AD_POSITION_BOTTOM = -50000f;

	private const char _InternalPrimarySeparator = '\u001c';

	private const char _InternalSecondarySeparator = '\u001d';

	public AndroidJavaClass applovinFacade = new AndroidJavaClass("com.applovin.sdk.unity.AppLovinFacade");

	public AndroidJavaObject currentActivity;

	public static AppLovin DefaultPlugin;

	public AppLovin(AndroidJavaObject activity)
	{
		if (activity == null)
		{
			throw new MissingReferenceException("No parent activity specified");
		}
		currentActivity = activity;
	}

	public AppLovin()
	{
	}

	public static AppLovin getDefaultPlugin()
	{
		if (DefaultPlugin == null)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			DefaultPlugin = new AppLovin(androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"));
		}
		return DefaultPlugin;
	}

	public void initializeSdk()
	{
		applovinFacade.CallStatic("InitializeSdk", currentActivity);
	}

	public void showAd()
	{
		applovinFacade.CallStatic("ShowAd", currentActivity);
	}

	public void showInterstitial(string placement = null)
	{
		applovinFacade.CallStatic("ShowInterstitial", currentActivity, placement);
	}

	public void hideAd()
	{
		applovinFacade.CallStatic("HideAd", currentActivity);
	}

	public void setAdPosition(float x, float y)
	{
		applovinFacade.CallStatic("SetAdPosition", currentActivity, x, y);
	}

	public void setAdWidth(int width)
	{
		applovinFacade.CallStatic("SetAdWidth", currentActivity, width);
	}

	public void setVerboseLoggingOn(string sdkKey)
	{
		applovinFacade.CallStatic("SetVerboseLoggingOn", "true");
	}

	private void setMuted(string muted)
	{
		applovinFacade.CallStatic("SetMuted", muted);
	}

	private bool isMuted()
	{
		string value = applovinFacade.CallStatic<string>("IsMuted", new object[0]);
		return bool.Parse(value);
	}

	private void setTestAdsEnabled(string enabled)
	{
		applovinFacade.CallStatic("SetTestAdsEnabled", enabled);
	}

	private bool isTestAdsEnabled()
	{
		string value = applovinFacade.CallStatic<string>("IsTestAdsEnabled", new object[0]);
		return bool.Parse(value);
	}

	public void setSdkKey(string sdkKey)
	{
		applovinFacade.CallStatic("SetSdkKey", currentActivity, sdkKey);
	}

	public void preloadInterstitial()
	{
		applovinFacade.CallStatic("PreloadInterstitial", currentActivity);
	}

	public bool hasPreloadedInterstitial()
	{
		string value = applovinFacade.CallStatic<string>("IsInterstitialReady", new object[1] { currentActivity });
		return bool.Parse(value);
	}

	public bool isInterstitialShowing()
	{
		string value = applovinFacade.CallStatic<string>("IsInterstitialShowing", new object[1] { currentActivity });
		return bool.Parse(value);
	}

	public void setAdListener(string gameObjectToNotify)
	{
		applovinFacade.CallStatic("SetUnityAdListener", gameObjectToNotify);
	}

	public void setRewardedVideoUsername(string username)
	{
		applovinFacade.CallStatic("SetIncentivizedUsername", currentActivity, username);
	}

	public void loadIncentInterstitial()
	{
		applovinFacade.CallStatic("LoadIncentInterstitial", currentActivity);
	}

	public void showIncentInterstitial(string placement = null)
	{
		applovinFacade.CallStatic("ShowIncentInterstitial", currentActivity, placement);
	}

	public bool isIncentInterstitialReady()
	{
		string value = applovinFacade.CallStatic<string>("IsIncentReady", new object[1] { currentActivity });
		return bool.Parse(value);
	}

	public bool isPreloadedInterstitialVideo()
	{
		string value = applovinFacade.CallStatic<string>("IsCurrentInterstitialVideo", new object[1] { currentActivity });
		return bool.Parse(value);
	}

	public void trackEvent(string eventType, IDictionary<string, string> parameters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (parameters != null)
		{
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				if (parameter.Key != null && parameter.Value != null)
				{
					stringBuilder.Append(parameter.Key);
					stringBuilder.Append('\u001d');
					stringBuilder.Append(parameter.Value);
					stringBuilder.Append('\u001c');
				}
			}
		}
		applovinFacade.CallStatic("TrackEvent", currentActivity, eventType, stringBuilder.ToString());
	}

	public void enableImmersiveMode()
	{
		applovinFacade.CallStatic("EnableImmersiveMode", currentActivity);
	}

	public static void ShowAd()
	{
		getDefaultPlugin().showAd();
	}

	public static void ShowAd(float x, float y)
	{
		SetAdPosition(x, y);
		ShowAd();
	}

	public static void ShowInterstitial()
	{
		getDefaultPlugin().showInterstitial();
	}

	public static void ShowInterstitial(string placement)
	{
		getDefaultPlugin().showInterstitial(placement);
	}

	public static void LoadRewardedInterstitial()
	{
		getDefaultPlugin().loadIncentInterstitial();
	}

	public static void ShowRewardedInterstitial()
	{
		getDefaultPlugin().showIncentInterstitial();
	}

	public static void ShowRewardedInterstitial(string placement)
	{
		getDefaultPlugin().showIncentInterstitial(placement);
	}

	public static void HideAd()
	{
		getDefaultPlugin().hideAd();
	}

	public static void SetAdPosition(float x, float y)
	{
		getDefaultPlugin().setAdPosition(x, y);
	}

	public static void SetAdWidth(int width)
	{
		getDefaultPlugin().setAdWidth(width);
	}

	public static void SetSdkKey(string sdkKey)
	{
		getDefaultPlugin().setSdkKey(sdkKey);
	}

	public static void SetVerboseLoggingOn(string verboseLogging)
	{
		getDefaultPlugin().setVerboseLoggingOn(verboseLogging);
	}

	public static void SetMuted(string muted)
	{
		getDefaultPlugin().setMuted(muted);
	}

	public static bool IsMuted()
	{
		return getDefaultPlugin().isMuted();
	}

	public static void SetTestAdsEnabled(string enabled)
	{
		getDefaultPlugin().setTestAdsEnabled(enabled);
	}

	public static bool IsTestAdsEnabled()
	{
		return getDefaultPlugin().isTestAdsEnabled();
	}

	public static void PreloadInterstitial()
	{
		getDefaultPlugin().preloadInterstitial();
	}

	public static bool HasPreloadedInterstitial()
	{
		return getDefaultPlugin().hasPreloadedInterstitial();
	}

	public static bool IsInterstitialShowing()
	{
		return getDefaultPlugin().isInterstitialShowing();
	}

	public static bool IsIncentInterstitialReady()
	{
		return getDefaultPlugin().isIncentInterstitialReady();
	}

	public static bool IsPreloadedInterstitialVideo()
	{
		return getDefaultPlugin().isPreloadedInterstitialVideo();
	}

	public static void InitializeSdk()
	{
		getDefaultPlugin().initializeSdk();
	}

	public static void SetUnityAdListener(string gameObjectToNotify)
	{
		getDefaultPlugin().setAdListener(gameObjectToNotify);
	}

	public static void SetRewardedVideoUsername(string username)
	{
		getDefaultPlugin().setRewardedVideoUsername(username);
	}

	public static void TrackEvent(string eventType, IDictionary<string, string> parameters)
	{
		getDefaultPlugin().trackEvent(eventType, parameters);
	}

	public static void EnableImmersiveMode()
	{
		getDefaultPlugin().enableImmersiveMode();
	}
}
