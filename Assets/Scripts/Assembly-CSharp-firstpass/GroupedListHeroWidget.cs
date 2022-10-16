using UnityEngine;

public class GroupedListHeroWidget
{
	public class Group
	{
		public AndroidJavaObject heroWidgetServiceGroup;

		public Group(AndroidJavaObject group)
		{
			heroWidgetServiceGroup = group;
		}

		public AndroidJavaObject GetAndroidJavaObject()
		{
			return heroWidgetServiceGroup;
		}

		public void SetGroupName(string groupName)
		{
			heroWidgetServiceGroup.Call("setGroupName", groupName);
		}

		public void SetListEntries(AndroidJavaObject listEntries)
		{
			heroWidgetServiceGroup.Call("setListEntries", listEntries);
		}
	}

	public class GroupList
	{
		public AndroidJavaObject heroWidgetServiceGroupList;

		public GroupList(AndroidJavaObject groupList)
		{
			heroWidgetServiceGroupList = groupList;
		}

		public AndroidJavaObject GetAndroidJavaObject()
		{
			return heroWidgetServiceGroupList;
		}

		public void Add(Group group)
		{
			heroWidgetServiceGroupList.Call<bool>("add", new object[1] { group.GetAndroidJavaObject() });
		}
	}

	public class ListEntry
	{
		public AndroidJavaObject heroWidgetServiceListEntry;

		public ListEntry(AndroidJavaObject listEntry)
		{
			heroWidgetServiceListEntry = listEntry;
		}

		public AndroidJavaObject GetAndroidJavaObject()
		{
			return heroWidgetServiceListEntry;
		}

		public void SetPrimaryText(string text)
		{
			heroWidgetServiceListEntry.Call<AndroidJavaObject>("setPrimaryText", new object[1] { text });
		}

		public void SetSecondaryText(string text)
		{
			heroWidgetServiceListEntry.Call<AndroidJavaObject>("setSecondaryText", new object[1] { text });
		}

		public void SetTertiaryText(string text)
		{
			heroWidgetServiceListEntry.Call<AndroidJavaObject>("setTertiaryText ", new object[1] { text });
		}

		public void SetIcon(int ordinal, string iconId)
		{
			HeroWidgetServiceWrapper.Instance().SetGroupedListListEntryIcon(heroWidgetServiceListEntry, ordinal, iconId);
		}

		public void SetHighlight(bool highlight)
		{
			heroWidgetServiceListEntry.Call<AndroidJavaObject>("setHighlight", new object[1] { highlight });
		}

		public void SetContentIntent(string data)
		{
			HeroWidgetServiceWrapper.Instance().SetGroupedListListEntryContentIntent(heroWidgetServiceListEntry, data);
		}

		public void SetVisualStyle(VisualStyle visualStyle)
		{
			HeroWidgetServiceWrapper.Instance().SetGroupedListListEntryVisualStyle(heroWidgetServiceListEntry, visualStyle.ToString());
		}
	}

	public class ListEntryList
	{
		public AndroidJavaObject heroWidgetServiceListEntryList;

		public ListEntryList(AndroidJavaObject listEntryList)
		{
			heroWidgetServiceListEntryList = listEntryList;
		}

		public AndroidJavaObject GetAndroidJavaObject()
		{
			return heroWidgetServiceListEntryList;
		}

		public void Add(ListEntry listEntry)
		{
			heroWidgetServiceListEntryList.Call<bool>("add", new object[1] { listEntry.GetAndroidJavaObject() });
		}
	}

	public enum VisualStyle
	{
		DEFAULT = 0,
		PEEKABLE = 1,
		SHOPPING = 2,
		SIMPLE = 3
	}

	public AndroidJavaObject heroWidgetServiceGroupedListWidget;

	public GroupedListHeroWidget(AndroidJavaObject groupedListWidget)
	{
		heroWidgetServiceGroupedListWidget = groupedListWidget;
	}

	public AndroidJavaObject GetAndroidJavaObject()
	{
		return heroWidgetServiceGroupedListWidget;
	}

	public void SetGroups(AndroidJavaObject groups)
	{
		if (heroWidgetServiceGroupedListWidget != null)
		{
			heroWidgetServiceGroupedListWidget.Call("setGroups", groups);
		}
	}
}
