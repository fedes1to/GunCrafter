using UnityEngine;

public class GameCircleSocialExample : MonoBehaviour
{
	public enum AsyncOperationStatus
	{
		Inactive = 0,
		Waiting = 1,
		Failed = 2,
		Success = 3
	}

	private Vector2 scroll = Vector2.zero;

	private bool uiInitialized;

	private GUISkin localGuiSkin;

	private GUISkin originalGuiSkin;

	private AsyncOperationStatus socialInitialization;

	private GameCircleSocialAchievementsExample achievementsExample = new GameCircleSocialAchievementsExample();

	private GameCircleSocialLeaderboardsExample leaderboardsExample = new GameCircleSocialLeaderboardsExample();

	private const string initializeSocialButtonLabel = "Initialize GameCircle Social API";

	private const string waitingForSocialInitialization = "Initializing...";

	private const string initializationFailedLabel = "Failed to initialize";

	private const string initializationSuccessfulLabel = "GameCircle Initialized";

	private const string waitingLabel = "Waiting on async operation...";

	private void Start()
	{
		Social.Active = GameCircleSocial.Instance;
	}

	private void OnGUI()
	{
		InitializeUI();
		ApplyLocalUISkin();
		AmazonGUIHelpers.BeginMenuLayout();
		scroll = GUILayout.BeginScrollView(scroll);
		switch (socialInitialization)
		{
		case AsyncOperationStatus.Inactive:
			DrawInitializationMenu();
			break;
		case AsyncOperationStatus.Waiting:
			AmazonGUIHelpers.CenteredLabel("Initializing...");
			break;
		case AsyncOperationStatus.Failed:
			AmazonGUIHelpers.CenteredLabel("Failed to initialize");
			break;
		case AsyncOperationStatus.Success:
			DrawSocialMenu();
			break;
		}
		GUILayout.EndScrollView();
		AmazonGUIHelpers.EndMenuLayout();
		RevertLocalUISkin();
	}

	private void InitializeUI()
	{
		if (!uiInitialized)
		{
			uiInitialized = true;
			localGuiSkin = GUI.skin;
			originalGuiSkin = GUI.skin;
			AmazonGUIHelpers.SetGUISkinTouchFriendly(localGuiSkin);
		}
	}

	private void ApplyLocalUISkin()
	{
		GUI.skin = localGuiSkin;
	}

	private void RevertLocalUISkin()
	{
		GUI.skin = originalGuiSkin;
	}

	private void DrawInitializationMenu()
	{
		if (GUILayout.Button("Initialize GameCircle Social API") && Social.localUser != null)
		{
			socialInitialization = AsyncOperationStatus.Waiting;
			Social.localUser.Authenticate(AuthenticateCallback);
		}
	}

	private void DrawSocialMenu()
	{
		AmazonGUIHelpers.CenteredLabel("GameCircle Initialized");
		GUILayout.BeginVertical(GUI.skin.box);
		achievementsExample.DrawAchievementsMenu();
		GUILayout.EndVertical();
		GUILayout.BeginVertical(GUI.skin.box);
		leaderboardsExample.DrawLeaderboardsMenu();
		GUILayout.EndVertical();
	}

	private void AuthenticateCallback(bool success)
	{
		if (success)
		{
			socialInitialization = AsyncOperationStatus.Success;
		}
		else
		{
			socialInitialization = AsyncOperationStatus.Failed;
		}
	}
}
