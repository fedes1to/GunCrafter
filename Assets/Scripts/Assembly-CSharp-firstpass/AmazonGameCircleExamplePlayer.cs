using System;
using System.Collections.Generic;
using UnityEngine;

public class AmazonGameCircleExamplePlayer : AmazonGameCircleExampleBase
{
	private string playerStatus;

	private string playerStatusMessage;

	private AGSPlayer player;

	private DateTime? lastSignInStateChangeEvent;

	private bool haveGotStateChangeEvent;

	private bool signedInStateChange;

	private List<string> friendIds;

	private string friendsRequestError = string.Empty;

	private string friendsStatus;

	private List<AGSPlayer> friends;

	private const string playerMenuTitle = "Player";

	private const string playerReceivedLabel = "Retrieved local player data";

	private const string playerFailedLabel = "Failed to retrieve local player data";

	private const string playerRetrieveButtonLabel = "Retrieve local player data";

	private const string playerLabel = "ID: {0} Alias: {1}\nAvatarUrl: {2}";

	private const string playerRetrievingLabel = "Retrieving local player data...";

	private const string isSignedInLabel = "Signed In: {0}";

	private const string getFriendsButtonLabel = "Get Friend ID's";

	private const string friendsLabel = "Friends ID's:";

	private const string friendsRetrievingLabel = "Retrieving friends...";

	private const string friendsRequestFailedLabel = "Friends request failed: {0}";

	private const string signedInEventLabel = "Player signed in {0,5:N1} seconds ago.";

	private const string signedOutEventLabel = "Player signed out {0,5:N1} seconds ago.";

	private const string nullAsString = "null";

	private static AmazonGameCircleExamplePlayer instance;

	private AmazonGameCircleExamplePlayer()
	{
		AGSPlayerClient.RequestLocalPlayerCompleted += OnPlayerRequestCompleted;
		AGSPlayerClient.RequestFriendIdsCompleted += OnGetFriendIdsCompleted;
		AGSPlayerClient.OnSignedInStateChangedEvent += OnSignedInStateChanged;
		AGSPlayerClient.RequestBatchFriendsCompleted += OnBatchFriendsRequestCompleted;
	}

	public static AmazonGameCircleExamplePlayer Instance()
	{
		if (instance == null)
		{
			instance = new AmazonGameCircleExamplePlayer();
		}
		return instance;
	}

	public override string MenuTitle()
	{
		return "Player";
	}

	public override void DrawMenu()
	{
		AmazonGUIHelpers.CenteredLabel(string.Format("Signed In: {0}", (!AGSPlayerClient.IsSignedIn()) ? "false" : "true"));
		if (GUILayout.Button("Retrieve local player data"))
		{
			AGSPlayerClient.RequestLocalPlayer();
			playerStatus = "Retrieving local player data...";
		}
		if (!string.IsNullOrEmpty(playerStatus))
		{
			AmazonGUIHelpers.CenteredLabel(playerStatus);
			if (!string.IsNullOrEmpty(playerStatusMessage))
			{
				AmazonGUIHelpers.CenteredLabel(playerStatusMessage);
			}
			if (player != null)
			{
				AmazonGUIHelpers.CenteredLabel(player.ToString());
			}
		}
		if (GUILayout.Button("Get Friend ID's"))
		{
			AGSPlayerClient.RequestFriendIds();
		}
		if (!string.IsNullOrEmpty(friendsRequestError))
		{
			AmazonGUIHelpers.CenteredLabel(string.Format("Friends request failed: {0}", friendsRequestError));
		}
		if (friendIds != null)
		{
			AmazonGUIHelpers.CenteredLabel("Friends ID's:");
			foreach (string friendId in friendIds)
			{
				AmazonGUIHelpers.CenteredLabel(friendId);
			}
			if (GUILayout.Button("Request Friends"))
			{
				friendsStatus = "Requesting friends...";
				AGSPlayerClient.RequestBatchFriends(friendIds);
			}
		}
		if (!string.IsNullOrEmpty(friendsStatus))
		{
			AmazonGUIHelpers.CenteredLabel(friendsStatus);
		}
		if (friends != null)
		{
			AmazonGUIHelpers.CenteredLabel("Friends:");
			foreach (AGSPlayer friend in friends)
			{
				AmazonGUIHelpers.CenteredLabel(friend.ToString());
			}
		}
		if (!haveGotStateChangeEvent)
		{
			return;
		}
		DateTime? dateTime = lastSignInStateChangeEvent;
		if (dateTime.HasValue)
		{
			double totalSeconds = (DateTime.Now - lastSignInStateChangeEvent.Value).TotalSeconds;
			if (signedInStateChange)
			{
				AmazonGUIHelpers.CenteredLabel(string.Format("Player signed in {0,5:N1} seconds ago.", totalSeconds));
			}
			else
			{
				AmazonGUIHelpers.CenteredLabel(string.Format("Player signed out {0,5:N1} seconds ago.", totalSeconds));
			}
		}
	}

	private void OnPlayerRequestCompleted(AGSRequestPlayerResponse response)
	{
		if (response.IsError())
		{
			playerStatus = "Failed to retrieve local player data";
			playerStatusMessage = response.error;
			player = null;
		}
		else
		{
			playerStatus = "Retrieved local player data";
			playerStatusMessage = null;
			player = response.player;
		}
	}

	private void OnGetFriendIdsCompleted(AGSRequestFriendIdsResponse response)
	{
		if (response.IsError())
		{
			friendIds = null;
			friendsRequestError = response.error;
		}
		else
		{
			friendsRequestError = string.Empty;
			friendIds = response.friendIds;
		}
	}

	private void OnBatchFriendsRequestCompleted(AGSRequestBatchFriendsResponse response)
	{
		if (response.IsError())
		{
			friendsStatus = string.Format("Error requesting friends: {0}", response.error);
			return;
		}
		friendsStatus = string.Empty;
		friends = response.friends;
	}

	private void OnSignedInStateChanged(bool isSignedIn)
	{
		haveGotStateChangeEvent = true;
		signedInStateChange = isSignedIn;
		lastSignInStateChangeEvent = DateTime.Now;
	}
}
