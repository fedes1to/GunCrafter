using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameCircleSocialLeaderboardsExample
{
	private bool leaderboardsMenuFoldout;

	private long scoreValue;

	private IScore[] scores;

	private bool? scoreReportSuccessful;

	private const string leaderboardsMenuLabel = "Leaderboards Menu";

	private const string leaderboardsOverlayLabel = "Leaderboards Overlay";

	private const string scoreValueLabel = "{0}";

	private const string reportScoreButtonLabel = "Report Score";

	private const string scoreReportSuccessLabel = "Score Report Success";

	private const string scoreReportFailureLabel = "Score Report Failure";

	private const string retrieveScoresButtonLabel = "Retrieve Scores";

	private const string scoreLeaderboardLabel = "Leaderboard {0}";

	private const string scoreRankLabel = "Rank {0}";

	private const string scoreUserLabel = "User {0}";

	private const string leaderboardExampleID = "Replace with your own Leaderboard ID";

	private const long scoreMinValue = 0L;

	private const long scoreMaxValue = 10000L;

	public void DrawLeaderboardsMenu()
	{
		leaderboardsMenuFoldout = AmazonGUIHelpers.FoldoutWithLabel(leaderboardsMenuFoldout, "Leaderboards Menu");
		if (leaderboardsMenuFoldout)
		{
			if (GUILayout.Button("Leaderboards Overlay"))
			{
				Social.ShowLeaderboardUI();
			}
			DisplayScoreReporter();
			DisplayScoreReportResult();
			DisplayScoreRetrieval();
		}
	}

	private void DisplayScoreReporter()
	{
		scoreValue = (long)AmazonGUIHelpers.DisplayCenteredSlider(scoreValue, 0f, 10000f, "{0}");
		if (GUILayout.Button("Report Score"))
		{
			Social.ReportScore(scoreValue, "Replace with your own Leaderboard ID", ReportScoreCallback);
		}
	}

	private void DisplayScoreReportResult()
	{
		string text = string.Empty;
		if (scoreReportSuccessful.HasValue)
		{
			text = ((!scoreReportSuccessful.Value) ? "Score Report Failure" : "Score Report Success");
		}
		AmazonGUIHelpers.CenteredLabel(text);
	}

	private void DisplayScoreRetrieval()
	{
		if (GUILayout.Button("Retrieve Scores"))
		{
			Social.LoadScores("Replace with your own Leaderboard ID", RetrieveScoreCallback);
		}
		if (scores != null)
		{
			IScore[] array = scores;
			foreach (IScore score in array)
			{
				GUILayout.BeginVertical(GUI.skin.box);
				GUILayout.BeginHorizontal();
				AmazonGUIHelpers.CenteredLabel(string.Format("Leaderboard {0}", score.leaderboardID));
				AmazonGUIHelpers.CenteredLabel(score.formattedValue);
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
				AmazonGUIHelpers.CenteredLabel(string.Format("User {0}", score.userID));
				AmazonGUIHelpers.CenteredLabel(string.Format("Rank {0}", score.rank));
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();
			}
		}
	}

	private void ReportScoreCallback(bool success)
	{
		scoreReportSuccessful = success;
	}

	private void RetrieveScoreCallback(IScore[] scores)
	{
		this.scores = scores;
	}
}
