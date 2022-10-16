using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class AmazonGameCircleExampleLeaderboards : AmazonGameCircleExampleBase
{
	private Dictionary<string, string> leaderboardsSubmissionStatus = new Dictionary<string, string>();

	private Dictionary<string, string> leaderboardsSubmissionStatusMessage = new Dictionary<string, string>();

	private Dictionary<string, string> leaderboardsLocalScoreStatus = new Dictionary<string, string>();

	private Dictionary<string, string> leaderboardsLocalScoreStatusMessage = new Dictionary<string, string>();

	private Dictionary<string, List<string>> leaderboardsScoresStatus = new Dictionary<string, List<string>>();

	private Dictionary<string, string> leaderboardsScoresStatusMessage = new Dictionary<string, string>();

	private Dictionary<string, List<string>> leaderboardsPercentilesStatus = new Dictionary<string, List<string>>();

	private Dictionary<string, string> leaderboardsPercentilesStatusMessage = new Dictionary<string, string>();

	private Dictionary<string, bool> showPlayerScoreRequestButtons = new Dictionary<string, bool>();

	private Dictionary<string, Dictionary<string, string>> scoreForPlayer = new Dictionary<string, Dictionary<string, string>>();

	private Dictionary<string, bool> showPlayerPercentileRequestButtons = new Dictionary<string, bool>();

	private Dictionary<string, Dictionary<string, List<string>>> percentilesForPlayer = new Dictionary<string, Dictionary<string, List<string>>>();

	private Dictionary<string, bool> leaderboardsFoldout = new Dictionary<string, bool>();

	private List<string> friendIds;

	private string friendStatus;

	private long leaderboardScoreValue;

	private string requestLeaderboardsStatus;

	private string requestLeaderboardsStatusMessage;

	private List<AGSLeaderboard> leaderboardList;

	private bool leaderboardsReady;

	private DateTime leaderboardsRequestTime;

	private LeaderboardScope leaderboardScoreScope;

	private AGSLeaderboard invalidLeaderboard;

	private readonly Regex addNewlineEverySecondCommaRegex = new Regex("(,([^,]+),)");

	private const int betweenCommaRegexGroup = 2;

	private const string leaderboardsMenuTitle = "Leaderboards";

	private const string DisplayLeaderboardOverlayButtonLabel = "Leaderboards Overlay";

	private const string requestLeaderboardsButtonLabel = "Request Leaderboards";

	private const string requestingLeaderboardsLabel = "Requesting Leaderboards...";

	private const string requestLeaderboardsFailedLabel = "Request Leaderboards failed with error:";

	private const string requestLeaderboardsSucceededLabel = "Available Leaderboards";

	private const string noLeaderboardsAvailableLabel = "No Leaderboards Available";

	private const string leaderboardIDLabel = "Leaderboard \"{0}\"";

	private const string leaderboardRequestTimeLabel = "{0,5:N1} seconds";

	private const string leaderboardScoreDisplayLabel = "{0} score units";

	private const string submitLeaderboardButtonLabel = "Submit Score";

	private const string leaderboardFailed = "Leaderboard \"{0}\" failed with error:";

	private const string leaderboardSucceeded = "Score uploaded to \"{0}\" successfully.";

	private const string requestLeaderboardScoreButtonLabel = "Request Local Player Score";

	private const string leaderboardRankScoreLabel = "Rank {0} with score of {1}.";

	private const string leaderboardScoreFailed = "\"{0}\" score request failed with error:";

	private const string requestTopScoresButtonLabel = "Request Top Scores";

	private const string topScoresFailed = "\"{0}\" top scores request failed with error:";

	private const string topScoreItemLabel = "Player: {0}\nScore: {1:D}, FormattedScore:{2}, Rank: {3:D}";

	private const string requestLeaderboardPercentilesButtonLabel = "Request Leaderboard Percentiles";

	private const string percentilesFailed = "\"{0}\" percentiles request failed with error:";

	private const string percentileRankLabel = "Player: {0}\nPercentile: {1:D}, Score: {2:D}";

	private const string localPlayerIndexLabel = "Local user has an index of {0:D}.";

	private const int leaderboardMinValue = -10000;

	private const int leaderboardMaxValue = 10000;

	private static AmazonGameCircleExampleLeaderboards instance;

	[CompilerGenerated]
	private static MatchEvaluator _003C_003Ef__am_0024cache0;

	private AmazonGameCircleExampleLeaderboards()
	{
		AGSLeaderboardsClient.RequestLeaderboardsCompleted += OnRequestLeaderboardsCompleted;
		AGSLeaderboardsClient.SubmitScoreCompleted += OnSubmitScoreCompleted;
		AGSLeaderboardsClient.RequestLocalPlayerScoreCompleted += OnRequestLocalPlayerScoreCompleted;
		AGSLeaderboardsClient.RequestScoresCompleted += OnRequestScoresCompleted;
		AGSLeaderboardsClient.RequestPercentileRanksCompleted += OnRequestPercentileRanksCompleted;
		AGSLeaderboardsClient.RequestPercentileRanksCompleted += OnRequestPercentileRanksCompleted;
		AGSLeaderboardsClient.RequestScoreForPlayerCompleted += OnRequestScoreForPlayerCompleted;
		AGSLeaderboardsClient.RequestPercentileRanksForPlayerCompleted += OnRequestPercentilesForPlayerCompleted;
		AGSPlayerClient.RequestFriendIdsCompleted += OnRequestFriendsCompleted;
		invalidLeaderboard = new AGSLeaderboard();
		invalidLeaderboard.id = "Invalid Leaderboard ID";
	}

	public static AmazonGameCircleExampleLeaderboards Instance()
	{
		if (instance == null)
		{
			instance = new AmazonGameCircleExampleLeaderboards();
		}
		return instance;
	}

	public override string MenuTitle()
	{
		return "Leaderboards";
	}

	public override void DrawMenu()
	{
		if (GUILayout.Button("Leaderboards Overlay"))
		{
			AGSLeaderboardsClient.ShowLeaderboardsOverlay();
		}
		if (string.IsNullOrEmpty(requestLeaderboardsStatus))
		{
			if (GUILayout.Button("Request Leaderboards"))
			{
				leaderboardsRequestTime = DateTime.Now;
				AGSLeaderboardsClient.RequestLeaderboards();
				requestLeaderboardsStatus = "Requesting Leaderboards...";
			}
			return;
		}
		AmazonGUIHelpers.CenteredLabel(requestLeaderboardsStatus);
		if (!string.IsNullOrEmpty(requestLeaderboardsStatusMessage))
		{
			AmazonGUIHelpers.CenteredLabel(requestLeaderboardsStatusMessage);
		}
		if (!leaderboardsReady)
		{
			AmazonGUIHelpers.CenteredLabel(string.Format("{0,5:N1} seconds", (DateTime.Now - leaderboardsRequestTime).TotalSeconds));
			return;
		}
		if (leaderboardList != null && leaderboardList.Count > 0)
		{
			foreach (AGSLeaderboard leaderboard in leaderboardList)
			{
				DisplayLeaderboard(leaderboard);
			}
		}
		else
		{
			AmazonGUIHelpers.CenteredLabel("No Leaderboards Available");
		}
		if (invalidLeaderboard != null)
		{
			DisplayLeaderboard(invalidLeaderboard);
		}
	}

	private void DisplayLeaderboard(AGSLeaderboard leaderboard)
	{
		GUILayout.BeginVertical(GUI.skin.box);
		if (!leaderboardsFoldout.ContainsKey(leaderboard.id))
		{
			leaderboardsFoldout.Add(leaderboard.id, false);
		}
		leaderboardsFoldout[leaderboard.id] = AmazonGUIHelpers.FoldoutWithLabel(leaderboardsFoldout[leaderboard.id], string.Format("Leaderboard \"{0}\"", leaderboard.id));
		if (leaderboardsFoldout[leaderboard.id])
		{
			AmazonGUIHelpers.AnchoredLabel(AddNewlineEverySecondComma(leaderboard.ToString()), TextAnchor.UpperCenter);
			leaderboardScoreValue = (long)AmazonGUIHelpers.DisplayCenteredSlider(leaderboardScoreValue, -10000f, 10000f, "{0} score units");
			if (leaderboardsSubmissionStatus.ContainsKey(leaderboard.id) && !string.IsNullOrEmpty(leaderboardsSubmissionStatus[leaderboard.id]))
			{
				AmazonGUIHelpers.CenteredLabel(leaderboardsSubmissionStatus[leaderboard.id]);
				if (leaderboardsSubmissionStatusMessage.ContainsKey(leaderboard.id) && !string.IsNullOrEmpty(leaderboardsSubmissionStatusMessage[leaderboard.id]))
				{
					AmazonGUIHelpers.CenteredLabel(leaderboardsSubmissionStatusMessage[leaderboard.id]);
				}
			}
			if (GUILayout.Button("Submit Score"))
			{
				AGSLeaderboardsClient.SubmitScore(leaderboard.id, leaderboardScoreValue);
			}
			if (leaderboardsLocalScoreStatus.ContainsKey(leaderboard.id) && !string.IsNullOrEmpty(leaderboardsLocalScoreStatus[leaderboard.id]))
			{
				AmazonGUIHelpers.AnchoredLabel(leaderboardsLocalScoreStatus[leaderboard.id], TextAnchor.UpperCenter);
				if (leaderboardsLocalScoreStatusMessage.ContainsKey(leaderboard.id) && !string.IsNullOrEmpty(leaderboardsLocalScoreStatusMessage[leaderboard.id]))
				{
					AmazonGUIHelpers.AnchoredLabel(leaderboardsLocalScoreStatusMessage[leaderboard.id], TextAnchor.UpperCenter);
				}
			}
			if (GUILayout.Button("Request Local Player Score"))
			{
				AGSLeaderboardsClient.RequestLocalPlayerScore(leaderboard.id, leaderboardScoreScope);
			}
			if (leaderboardsScoresStatus.ContainsKey(leaderboard.id))
			{
				foreach (string item in leaderboardsScoresStatus[leaderboard.id])
				{
					if (!string.IsNullOrEmpty(item))
					{
						AmazonGUIHelpers.AnchoredLabel(item, TextAnchor.UpperCenter);
					}
				}
				if (leaderboardsScoresStatusMessage.ContainsKey(leaderboard.id) && !string.IsNullOrEmpty(leaderboardsScoresStatusMessage[leaderboard.id]))
				{
					AmazonGUIHelpers.AnchoredLabel(leaderboardsScoresStatusMessage[leaderboard.id], TextAnchor.UpperCenter);
				}
			}
			if (GUILayout.Button("Request Top Scores"))
			{
				AGSLeaderboardsClient.RequestScores(leaderboard.id, leaderboardScoreScope);
			}
			if (leaderboardsPercentilesStatus.ContainsKey(leaderboard.id))
			{
				foreach (string item2 in leaderboardsPercentilesStatus[leaderboard.id])
				{
					if (!string.IsNullOrEmpty(item2))
					{
						AmazonGUIHelpers.AnchoredLabel(item2, TextAnchor.UpperCenter);
					}
				}
				if (leaderboardsPercentilesStatusMessage.ContainsKey(leaderboard.id) && !string.IsNullOrEmpty(leaderboardsPercentilesStatusMessage[leaderboard.id]))
				{
					AmazonGUIHelpers.AnchoredLabel(leaderboardsPercentilesStatusMessage[leaderboard.id], TextAnchor.UpperCenter);
				}
			}
			if (GUILayout.Button("Request Leaderboard Percentiles"))
			{
				AGSLeaderboardsClient.RequestPercentileRanks(leaderboard.id, leaderboardScoreScope);
			}
			if (friendIds == null && GUILayout.Button("Get Friends"))
			{
				friendStatus = "Waiting for friends...";
				AGSPlayerClient.RequestFriendIds();
			}
			if (!string.IsNullOrEmpty(friendStatus))
			{
				AmazonGUIHelpers.CenteredLabel(friendStatus);
			}
			if (friendIds != null)
			{
				if (!showPlayerScoreRequestButtons.ContainsKey(leaderboard.id))
				{
					showPlayerScoreRequestButtons.Add(leaderboard.id, false);
				}
				GUILayout.BeginVertical(GUI.skin.box);
				showPlayerScoreRequestButtons[leaderboard.id] = AmazonGUIHelpers.FoldoutWithLabel(showPlayerScoreRequestButtons[leaderboard.id], "Request score for friend");
				if (showPlayerScoreRequestButtons[leaderboard.id])
				{
					foreach (string friendId in friendIds)
					{
						if (GUILayout.Button(string.Format("Score for {0}", friendId)))
						{
							AGSLeaderboardsClient.RequestScoreForPlayer(leaderboard.id, friendId, leaderboardScoreScope);
						}
						if (scoreForPlayer.ContainsKey(leaderboard.id) && scoreForPlayer[leaderboard.id].ContainsKey(friendId))
						{
							AmazonGUIHelpers.CenteredLabel(scoreForPlayer[leaderboard.id][friendId]);
						}
					}
				}
				GUILayout.EndVertical();
				if (!showPlayerPercentileRequestButtons.ContainsKey(leaderboard.id))
				{
					showPlayerPercentileRequestButtons.Add(leaderboard.id, false);
				}
				GUILayout.BeginVertical(GUI.skin.box);
				showPlayerPercentileRequestButtons[leaderboard.id] = AmazonGUIHelpers.FoldoutWithLabel(showPlayerPercentileRequestButtons[leaderboard.id], "Request percentiles for friend");
				if (showPlayerPercentileRequestButtons[leaderboard.id])
				{
					foreach (string friendId2 in friendIds)
					{
						if (GUILayout.Button(string.Format("Percentiles for {0}", friendId2)))
						{
							AGSLeaderboardsClient.RequestPercentileRanksForPlayer(leaderboard.id, friendId2, leaderboardScoreScope);
						}
						if (!percentilesForPlayer.ContainsKey(leaderboard.id) || !percentilesForPlayer[leaderboard.id].ContainsKey(friendId2))
						{
							continue;
						}
						foreach (string item3 in percentilesForPlayer[leaderboard.id][friendId2])
						{
							AmazonGUIHelpers.CenteredLabel(item3);
						}
					}
				}
				GUILayout.EndVertical();
			}
		}
		GUILayout.EndVertical();
	}

	private string AddNewlineEverySecondComma(string stringToChange)
	{
		Regex regex = addNewlineEverySecondCommaRegex;
		if (_003C_003Ef__am_0024cache0 == null)
		{
			_003C_003Ef__am_0024cache0 = _003CAddNewlineEverySecondComma_003Em__0;
		}
		return regex.Replace(stringToChange, _003C_003Ef__am_0024cache0);
	}

	private void OnRequestLeaderboardsCompleted(AGSRequestLeaderboardsResponse response)
	{
		if (response.IsError())
		{
			requestLeaderboardsStatus = "Request Leaderboards failed with error:";
			requestLeaderboardsStatusMessage = response.error;
		}
		else
		{
			requestLeaderboardsStatus = "Available Leaderboards";
			leaderboardList = response.leaderboards;
			leaderboardsReady = true;
		}
	}

	private void OnSubmitScoreCompleted(AGSSubmitScoreResponse response)
	{
		if (response.IsError())
		{
			leaderboardsSubmissionStatus[response.leaderboardId] = string.Format("Leaderboard \"{0}\" failed with error:", response.leaderboardId);
			leaderboardsSubmissionStatusMessage[response.leaderboardId] = response.error;
		}
		else
		{
			leaderboardsSubmissionStatus[response.leaderboardId] = string.Format("Score uploaded to \"{0}\" successfully.", response.leaderboardId);
		}
	}

	private void OnRequestLocalPlayerScoreCompleted(AGSRequestScoreResponse response)
	{
		if (response.IsError())
		{
			leaderboardsLocalScoreStatus[response.leaderboardId] = string.Format("\"{0}\" score request failed with error:", response.leaderboardId);
			leaderboardsLocalScoreStatusMessage[response.leaderboardId] = response.error;
		}
		else
		{
			leaderboardsLocalScoreStatus[response.leaderboardId] = string.Format("Rank {0} with score of {1}.", response.rank, response.score);
		}
	}

	private void OnRequestScoresCompleted(AGSRequestScoresResponse response)
	{
		List<string> list = new List<string>();
		if (response.IsError())
		{
			list.Add(string.Format("Error with scores request: {0}", response.error));
		}
		else
		{
			list.Add(string.Format("Leaderboard: [{0}]", response.leaderboard.ToString()));
			list.Add(string.Format("Scope: {0}", response.scope));
			foreach (AGSScore score in response.scores)
			{
				list.Add(string.Format("Player: {0}\nScore: {1:D}, FormattedScore:{2}, Rank: {3:D}", score.player.ToString(), score.scoreValue, score.scoreString, score.rank));
			}
		}
		leaderboardsScoresStatus[response.leaderboardId] = list;
	}

	private void OnRequestPercentileRanksCompleted(AGSRequestPercentilesResponse response)
	{
		if (response.IsError())
		{
			List<string> list = new List<string>();
			list.Add(string.Format("\"{0}\" percentiles request failed with error:", response.leaderboardId));
			leaderboardsPercentilesStatus[response.leaderboardId] = list;
			leaderboardsPercentilesStatusMessage[response.leaderboardId] = response.error;
			return;
		}
		List<string> list2 = new List<string>();
		foreach (AGSLeaderboardPercentile percentile in response.percentiles)
		{
			list2.Add(string.Format("Player: {0}\nPercentile: {1:D}, Score: {2:D}", percentile.player.ToString(), percentile.percentile, percentile.score));
		}
		list2.Add(string.Format("Local user has an index of {0:D}.", response.userIndex));
		leaderboardsPercentilesStatus[response.leaderboardId] = list2;
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

	private void OnRequestScoreForPlayerCompleted(AGSRequestScoreForPlayerResponse response)
	{
		if (!scoreForPlayer.ContainsKey(response.leaderboardId))
		{
			scoreForPlayer.Add(response.leaderboardId, new Dictionary<string, string>());
		}
		if (response.IsError())
		{
			scoreForPlayer[response.leaderboardId][response.playerId] = string.Format("Error getting score: {0}", response.error);
		}
		else
		{
			scoreForPlayer[response.leaderboardId][response.playerId] = string.Format("Rank: {0}, Score: {1}, Scope: {2}", response.rank, response.score, response.scope);
		}
	}

	private void OnRequestPercentilesForPlayerCompleted(AGSRequestPercentilesForPlayerResponse response)
	{
		if (!percentilesForPlayer.ContainsKey(response.leaderboardId))
		{
			percentilesForPlayer.Add(response.leaderboardId, new Dictionary<string, List<string>>());
		}
		percentilesForPlayer[response.leaderboardId][response.playerId] = new List<string>();
		if (response.IsError())
		{
			percentilesForPlayer[response.leaderboardId][response.playerId].Add(string.Format("Error getting percentiles: {0}", response.error));
			return;
		}
		percentilesForPlayer[response.leaderboardId][response.playerId].Add(string.Format("Leaderboard: {0}", response.leaderboard.ToString()));
		percentilesForPlayer[response.leaderboardId][response.playerId].Add(string.Format("Scope: {0}", response.scope.ToString()));
		foreach (AGSLeaderboardPercentile percentile in response.percentiles)
		{
			percentilesForPlayer[response.leaderboardId][response.playerId].Add(string.Format("Player: {0}\nPercentile: {1:D}, Score: {2:D}", percentile.player.ToString(), percentile.percentile, percentile.score));
		}
		percentilesForPlayer[response.leaderboardId][response.playerId].Add(string.Format("Requested player has an index of {0}.", response.userIndex));
	}

	[CompilerGenerated]
	private static string _003CAddNewlineEverySecondComma_003Em__0(Match regexMatchEvaluator)
	{
		return "," + regexMatchEvaluator.Groups[2].Value + ",\n";
	}
}
