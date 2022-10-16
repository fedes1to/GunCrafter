using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class AmazonGameCircleExampleAchievements : AmazonGameCircleExampleBase
{
	private Dictionary<string, string> achievementsSubmissionStatus = new Dictionary<string, string>();

	private Dictionary<string, string> achievementsSubmissionStatusMessage = new Dictionary<string, string>();

	private Dictionary<string, bool> achievementsFoldout = new Dictionary<string, bool>();

	private string requestAchievementsStatus;

	private string requestAchievementsStatusMessage;

	private List<AGSAchievement> achievementList;

	private bool achievementsReady;

	private Dictionary<string, List<string>> achievementsForFriend = new Dictionary<string, List<string>>();

	private List<string> friendIds;

	private string friendStatus;

	private bool showFriendsAchievements;

	private DateTime achievementsRequestTime;

	private AGSAchievement invalidAchievement;

	private readonly Regex addNewlineEveryThirdCommaRegex = new Regex("(,([^,]+,[^,]+),)");

	private const int betweenCommaRegexGroup = 2;

	private const string achievementsMenuTitle = "Achievements";

	private const string displayAchievementOverlayButtonLabel = "Achievements Overlay";

	private const string achievementProgressLabel = "Achievement \"{0}\"";

	private const string submitAchievementButtonLabel = "Submit Achievement Progress";

	private const string achievementFailedLabel = "Achievement \"{0}\" failed with error:";

	private const string achievementSucceededLabel = "Achievement \"{0}\" uploaded successfully.";

	private const string achievementPercent = "{0}%";

	private const string requestAchievementsButtonLabel = "Request Achievements";

	private const string requestingAchievementsLabel = "Requesting Achievements...";

	private const string requestAchievementsFailedLabel = "Request Achievements failed with error:";

	private const string requestAchievementsSucceededLabel = "Available Achievements";

	private const string noAchievementsAvailableLabel = "No Achievements Available";

	private const string achievementRequestTimeLabel = "{0,5:N1} seconds";

	private const string submittingInformationString = "Submitting Achievement...";

	private const string noErrorMessageReceived = "MISSING ERROR STRING";

	private const float achievementMinValue = -200f;

	private const float achievementMaxValue = 200f;

	private static AmazonGameCircleExampleAchievements instance;

	[CompilerGenerated]
	private static MatchEvaluator _003C_003Ef__am_0024cache0;

	private AmazonGameCircleExampleAchievements()
	{
		AGSAchievementsClient.RequestAchievementsCompleted += OnRequestAchievementsCompleted;
		AGSAchievementsClient.RequestAchievementsForPlayerCompleted += OnRequestAchievementsForFriendCompleted;
		AGSAchievementsClient.UpdateAchievementCompleted += OnUpdateAchievementCompleted;
		AGSPlayerClient.RequestFriendIdsCompleted += OnRequestFriendsCompleted;
		invalidAchievement = new AGSAchievement();
		invalidAchievement.title = "Invalid Achievement Title";
		invalidAchievement.id = "Invalid Achievement ID";
		invalidAchievement.progress = 0f;
	}

	public static AmazonGameCircleExampleAchievements Instance()
	{
		if (instance == null)
		{
			instance = new AmazonGameCircleExampleAchievements();
		}
		return instance;
	}

	public override string MenuTitle()
	{
		return "Achievements";
	}

	public override void DrawMenu()
	{
		if (GUILayout.Button("Achievements Overlay"))
		{
			AGSAchievementsClient.ShowAchievementsOverlay();
		}
		if (string.IsNullOrEmpty(requestAchievementsStatus))
		{
			if (GUILayout.Button("Request Achievements"))
			{
				achievementsRequestTime = DateTime.Now;
				requestAchievementsStatus = "Requesting Achievements...";
				AGSAchievementsClient.RequestAchievements();
			}
		}
		else
		{
			AmazonGUIHelpers.CenteredLabel(requestAchievementsStatus);
			if (!string.IsNullOrEmpty(requestAchievementsStatusMessage))
			{
				AmazonGUIHelpers.CenteredLabel(requestAchievementsStatusMessage);
			}
			if (!achievementsReady)
			{
				AmazonGUIHelpers.CenteredLabel(string.Format("{0,5:N1} seconds", (DateTime.Now - achievementsRequestTime).TotalSeconds));
			}
			else
			{
				if (achievementList != null && achievementList.Count > 0)
				{
					foreach (AGSAchievement achievement in achievementList)
					{
						DisplayAchievement(achievement);
					}
				}
				else
				{
					AmazonGUIHelpers.CenteredLabel("No Achievements Available");
				}
				if (invalidAchievement != null)
				{
					DisplayAchievement(invalidAchievement);
				}
			}
		}
		if (friendIds == null && GUILayout.Button("Get Friends"))
		{
			AGSPlayerClient.RequestFriendIds();
		}
		if (!string.IsNullOrEmpty(friendStatus))
		{
			AmazonGUIHelpers.CenteredLabel(friendStatus);
		}
		if (friendIds == null)
		{
			return;
		}
		GUILayout.BeginVertical(GUI.skin.box);
		showFriendsAchievements = AmazonGUIHelpers.FoldoutWithLabel(showFriendsAchievements, "Request Achievements For Friends");
		if (showFriendsAchievements)
		{
			foreach (string friendId in friendIds)
			{
				if (GUILayout.Button(string.Format("Achievements for {0}", friendId)))
				{
					AGSAchievementsClient.RequestAchievementsForPlayer(friendId);
				}
				if (!achievementsForFriend.ContainsKey(friendId))
				{
					continue;
				}
				foreach (string item in achievementsForFriend[friendId])
				{
					AmazonGUIHelpers.CenteredLabel(item);
				}
			}
		}
		GUILayout.EndVertical();
	}

	private void DisplayAchievement(AGSAchievement achievement)
	{
		GUILayout.BeginVertical(GUI.skin.box);
		if (!achievementsFoldout.ContainsKey(achievement.id))
		{
			achievementsFoldout.Add(achievement.id, false);
		}
		achievementsFoldout[achievement.id] = AmazonGUIHelpers.FoldoutWithLabel(achievementsFoldout[achievement.id], string.Format("Achievement \"{0}\"", achievement.id));
		if (achievementsFoldout[achievement.id])
		{
			AmazonGUIHelpers.AnchoredLabel(AddNewlineEveryThirdComma(achievement.ToString()), TextAnchor.UpperCenter);
			if (!achievementsSubmissionStatus.ContainsKey(achievement.id) || string.IsNullOrEmpty(achievementsSubmissionStatus[achievement.id]))
			{
				achievement.progress = AmazonGUIHelpers.DisplayCenteredSlider(achievement.progress, -200f, 200f, "{0}%");
				if (GUILayout.Button("Submit Achievement Progress"))
				{
					achievementsSubmissionStatus[achievement.id] = string.Format("Submitting Achievement...");
					AGSAchievementsClient.UpdateAchievementProgress(achievement.id, achievement.progress);
				}
			}
			else
			{
				AmazonGUIHelpers.CenteredLabel(achievementsSubmissionStatus[achievement.id]);
				if (achievementsSubmissionStatusMessage.ContainsKey(achievement.id) && !string.IsNullOrEmpty(achievementsSubmissionStatusMessage[achievement.id]))
				{
					AmazonGUIHelpers.CenteredLabel(achievementsSubmissionStatusMessage[achievement.id]);
				}
			}
		}
		GUILayout.EndVertical();
	}

	private string AddNewlineEveryThirdComma(string stringToChange)
	{
		Regex regex = addNewlineEveryThirdCommaRegex;
		if (_003C_003Ef__am_0024cache0 == null)
		{
			_003C_003Ef__am_0024cache0 = _003CAddNewlineEveryThirdComma_003Em__0;
		}
		return regex.Replace(stringToChange, _003C_003Ef__am_0024cache0);
	}

	private void OnRequestAchievementsCompleted(AGSRequestAchievementsResponse response)
	{
		if (response.IsError())
		{
			requestAchievementsStatus = "Request Achievements failed with error:";
			requestAchievementsStatusMessage = response.error;
		}
		else
		{
			requestAchievementsStatus = "Available Achievements";
			achievementList = response.achievements;
			achievementsReady = true;
		}
	}

	private void OnUpdateAchievementCompleted(AGSUpdateAchievementResponse response)
	{
		if (response.IsError())
		{
			achievementsSubmissionStatus[response.achievementId] = string.Format("Achievement \"{0}\" failed with error:", response.achievementId);
			achievementsSubmissionStatusMessage[response.achievementId] = response.error;
		}
		else
		{
			achievementsSubmissionStatus[response.achievementId] = string.Format("Achievement \"{0}\" uploaded successfully.", response.achievementId);
		}
	}

	private void OnRequestFriendsCompleted(AGSRequestFriendIdsResponse response)
	{
		if (response.IsError())
		{
			friendStatus = string.Format("Error getting friends: {0}", response.error);
		}
		else if (response.friendIds.Count > 0)
		{
			friendIds = response.friendIds;
			friendStatus = null;
		}
		else
		{
			friendStatus = "Local player has no friends.";
		}
	}

	private void OnRequestAchievementsForFriendCompleted(AGSRequestAchievementsForPlayerResponse response)
	{
		achievementsForFriend[response.playerId] = new List<string>();
		if (response.IsError())
		{
			achievementsForFriend[response.playerId].Add(string.Format("Error getting achievements for player: {0}", response.error));
			return;
		}
		foreach (AGSAchievement achievement in response.achievements)
		{
			achievementsForFriend[response.playerId].Add(achievement.ToString());
		}
	}

	[CompilerGenerated]
	private static string _003CAddNewlineEveryThirdComma_003Em__0(Match regexMatchEvaluator)
	{
		return "," + regexMatchEvaluator.Groups[2].Value + ",\n";
	}
}
