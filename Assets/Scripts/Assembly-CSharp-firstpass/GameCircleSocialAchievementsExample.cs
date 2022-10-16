using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GameCircleSocialAchievementsExample
{
	private bool achievementsMenuFoldout;

	private bool achievementsFoldout;

	private IAchievement[] achievements;

	private GameCircleSocialExample.AsyncOperationStatus achievementStatus;

	private bool achievementsDescriptionsFoldout;

	private IAchievementDescription[] achievementDescriptions;

	private GameCircleSocialExample.AsyncOperationStatus achievementDescriptionStatus;

	private const string achievementMenuLabel = "Achievements Menu";

	private const string achievementOverlayLabel = "Achievement Overlay";

	private const string achievementsLabel = "Achievements";

	private const string achievementDescriptionsLabel = "Achievement Descriptions";

	private const string retrieveDataButtonLabel = "Retrieve";

	private const string noAchievementsLabel = "No achievements available";

	private const string noAchievementDescriptionsLabel = "No achievement descriptions available";

	private const string waitingLabel = "Waiting on async operation...";

	private const string achievementPercent = "{0,5:N1}% Completed";

	public void DrawAchievementsMenu()
	{
		achievementsMenuFoldout = AmazonGUIHelpers.FoldoutWithLabel(achievementsMenuFoldout, "Achievements Menu");
		if (achievementsMenuFoldout)
		{
			if (GUILayout.Button("Achievement Overlay"))
			{
				Social.ShowAchievementsUI();
			}
			GUILayout.BeginVertical(GUI.skin.box);
			ShowAchievements();
			GUILayout.EndVertical();
			GUILayout.BeginVertical(GUI.skin.box);
			ShowAchievementDescriptions();
			GUILayout.EndVertical();
		}
	}

	private void ShowAchievements()
	{
		achievementsFoldout = AmazonGUIHelpers.FoldoutWithLabel(achievementsFoldout, "Achievements");
		if (!achievementsFoldout)
		{
			return;
		}
		switch (achievementStatus)
		{
		case GameCircleSocialExample.AsyncOperationStatus.Inactive:
			if (GUILayout.Button("Retrieve"))
			{
				achievementStatus = GameCircleSocialExample.AsyncOperationStatus.Waiting;
				Social.LoadAchievements(AchievementsCallback);
			}
			break;
		case GameCircleSocialExample.AsyncOperationStatus.Waiting:
			AmazonGUIHelpers.CenteredLabel("Waiting on async operation...");
			break;
		case GameCircleSocialExample.AsyncOperationStatus.Failed:
			AmazonGUIHelpers.CenteredLabel("No achievements available");
			break;
		case GameCircleSocialExample.AsyncOperationStatus.Success:
		{
			if (achievements == null || achievements.Length == 0)
			{
				AmazonGUIHelpers.CenteredLabel("No achievement descriptions available");
				break;
			}
			IAchievement[] array = achievements;
			foreach (IAchievement achievement in array)
			{
				GUILayout.BeginVertical(GUI.skin.box);
				GUILayout.BeginHorizontal();
				AmazonGUIHelpers.CenteredLabel(achievement.id);
				AmazonGUIHelpers.CenteredLabel(string.Format("{0,5:N1}% Completed", achievement.percentCompleted));
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();
			}
			break;
		}
		}
	}

	private void ShowAchievementDescriptions()
	{
		achievementsDescriptionsFoldout = AmazonGUIHelpers.FoldoutWithLabel(achievementsDescriptionsFoldout, "Achievement Descriptions");
		if (!achievementsDescriptionsFoldout)
		{
			return;
		}
		switch (achievementDescriptionStatus)
		{
		case GameCircleSocialExample.AsyncOperationStatus.Inactive:
			if (GUILayout.Button("Retrieve"))
			{
				achievementDescriptionStatus = GameCircleSocialExample.AsyncOperationStatus.Waiting;
				Social.LoadAchievementDescriptions(AchievementDescriptionsCallback);
			}
			break;
		case GameCircleSocialExample.AsyncOperationStatus.Waiting:
			AmazonGUIHelpers.CenteredLabel("Waiting on async operation...");
			break;
		case GameCircleSocialExample.AsyncOperationStatus.Failed:
			AmazonGUIHelpers.CenteredLabel("No achievement descriptions available");
			break;
		case GameCircleSocialExample.AsyncOperationStatus.Success:
		{
			if (achievementDescriptions == null || achievementDescriptions.Length == 0)
			{
				AmazonGUIHelpers.CenteredLabel("No achievement descriptions available");
				break;
			}
			IAchievementDescription[] array = achievementDescriptions;
			foreach (IAchievementDescription achievementDescription in array)
			{
				GUILayout.BeginVertical(GUI.skin.box);
				GUILayout.BeginHorizontal();
				AmazonGUIHelpers.CenteredLabel(achievementDescription.id);
				AmazonGUIHelpers.CenteredLabel(achievementDescription.title);
				GUILayout.EndHorizontal();
				AmazonGUIHelpers.CenteredLabel(achievementDescription.achievedDescription);
				GUILayout.EndVertical();
			}
			break;
		}
		}
	}

	private void AchievementsCallback(IAchievement[] achievements)
	{
		if (achievements == null)
		{
			achievementStatus = GameCircleSocialExample.AsyncOperationStatus.Failed;
			return;
		}
		achievementStatus = GameCircleSocialExample.AsyncOperationStatus.Success;
		this.achievements = achievements;
	}

	private void AchievementDescriptionsCallback(IAchievementDescription[] descriptions)
	{
		if (descriptions == null)
		{
			achievementDescriptionStatus = GameCircleSocialExample.AsyncOperationStatus.Failed;
			return;
		}
		achievementDescriptionStatus = GameCircleSocialExample.AsyncOperationStatus.Success;
		achievementDescriptions = descriptions;
	}
}
