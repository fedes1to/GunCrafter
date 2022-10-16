using System;
using UnityEngine;

public class HeroWidgetServiceWrapper
{
	public AndroidJavaObject customUnityActivity;

	private static HeroWidgetServiceWrapper s_Instance;

	private AndroidJavaObject heroWidgetServiceHelper;

	public HeroWidgetServiceWrapper()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		customUnityActivity = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		string text = "com.amazon.device.home.HeroWidget";
		Debug.Log("checking for hero widget class at: " + text);
		if (ClassExists(text))
		{
			string text2 = "com.amazon.demo.herowidget.HeroWidgetServiceHelper";
			Debug.Log("creating " + text2);
			heroWidgetServiceHelper = new AndroidJavaObject(text2);
			if (heroWidgetServiceHelper == null || heroWidgetServiceHelper.GetRawObject() == IntPtr.Zero)
			{
				Debug.LogError("Could not construct HeroWidgetServiceHelper despite HeroWidget being present - HeroWidgetServiceWrapper will not be available");
				heroWidgetServiceHelper = null;
			}
		}
		else
		{
			Debug.Log("no " + text + " on device - not gonna even try HeroWidgetServiceWrapper");
		}
	}

	public GroupedListHeroWidget CreateGroupedListHeroWidget()
	{
		if (heroWidgetServiceHelper == null)
		{
			return null;
		}
		AndroidJavaObject groupedListWidget = heroWidgetServiceHelper.Call<AndroidJavaObject>("createGroupedListHeroWidget", new object[0]);
		return new GroupedListHeroWidget(groupedListWidget);
	}

	public GroupedListHeroWidget.Group CreateGroupedListGroup()
	{
		if (heroWidgetServiceHelper == null)
		{
			return null;
		}
		AndroidJavaObject group = heroWidgetServiceHelper.Call<AndroidJavaObject>("createGroupedListGroup", new object[0]);
		return new GroupedListHeroWidget.Group(group);
	}

	public GroupedListHeroWidget.GroupList CreateGroupedListGroupList()
	{
		if (heroWidgetServiceHelper == null)
		{
			return null;
		}
		AndroidJavaObject groupList = heroWidgetServiceHelper.Call<AndroidJavaObject>("createGroupedListGroupList", new object[0]);
		return new GroupedListHeroWidget.GroupList(groupList);
	}

	public GroupedListHeroWidget.ListEntry CreateGroupedListListEntry()
	{
		if (heroWidgetServiceHelper == null)
		{
			return null;
		}
		AndroidJavaObject listEntry = heroWidgetServiceHelper.Call<AndroidJavaObject>("createGroupedListListEntry", new object[0]);
		return new GroupedListHeroWidget.ListEntry(listEntry);
	}

	public GroupedListHeroWidget.ListEntryList CreateGroupedListListEntryList()
	{
		if (heroWidgetServiceHelper == null)
		{
			return null;
		}
		AndroidJavaObject listEntryList = heroWidgetServiceHelper.Call<AndroidJavaObject>("createGroupedListListEntryList", new object[0]);
		return new GroupedListHeroWidget.ListEntryList(listEntryList);
	}

	public void UpdateWidget(AndroidJavaObject widget)
	{
		if (heroWidgetServiceHelper != null)
		{
			heroWidgetServiceHelper.Call("updateWidget", widget);
		}
	}

	public void SetGroupedListListEntryContentIntent(AndroidJavaObject listEntry, string data)
	{
		if (heroWidgetServiceHelper != null)
		{
			heroWidgetServiceHelper.Call("setGroupedListListEntryContentIntent", listEntry, data);
		}
	}

	public void SetGroupedListListEntryVisualStyle(AndroidJavaObject listEntry, string styleName)
	{
		if (heroWidgetServiceHelper != null)
		{
			heroWidgetServiceHelper.Call("setGroupedListListEntryVisualStyle", listEntry, styleName);
		}
	}

	public void SetGroupedListListEntryIcon(AndroidJavaObject listEntry, int ordinal, string iconId)
	{
		if (heroWidgetServiceHelper != null)
		{
			heroWidgetServiceHelper.Call("setIcon", listEntry, ordinal, iconId);
		}
	}

	public string GetExtrasValue()
	{
		if (heroWidgetServiceHelper == null)
		{
			return string.Empty;
		}
		return heroWidgetServiceHelper.Call<string>("getExtrasValue", new object[0]);
	}

	public static HeroWidgetServiceWrapper Instance()
	{
		if (s_Instance == null)
		{
			s_Instance = new HeroWidgetServiceWrapper();
		}
		return s_Instance;
	}

	public bool IsServiceAvailable()
	{
		return heroWidgetServiceHelper != null && heroWidgetServiceHelper.GetRawObject() != IntPtr.Zero;
	}

	public bool ClassExists(string classPath)
	{
		if (customUnityActivity == null)
		{
			return false;
		}
		return customUnityActivity.Call<bool>("isClassPresent", new object[1] { classPath });
	}
}
