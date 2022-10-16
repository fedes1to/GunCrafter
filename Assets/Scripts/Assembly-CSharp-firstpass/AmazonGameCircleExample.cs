using System.Collections.Generic;
using UnityEngine;

public class AmazonGameCircleExample : MonoBehaviour
{
	private const string gameCircleOverlayButtonLabel = "Show GameCircle Overlay";

	private const string gameCircleSignInButtonLabel = "Show GameCircle Sign In";

	private const string isServiceReadyLabel = "Service ready: {0}";

	private AmazonGameCircleExampleInitialization initializationMenu = new AmazonGameCircleExampleInitialization();

	private List<AmazonGameCircleExampleBase> gameCircleExampleMenus = new List<AmazonGameCircleExampleBase>();

	private bool initialized;

	private Vector2 scroll = Vector2.zero;

	private bool uiInitialized;

	private GUISkin localGuiSkin;

	private GUISkin originalGuiSkin;

	private void Start()
	{
		Initialize();
	}

	private void OnGUI()
	{
		InitializeUI();
		ApplyLocalUISkin();
		AmazonGUIHelpers.BeginMenuLayout();
		scroll = GUILayout.BeginScrollView(scroll);
		AmazonGUIHelpers.CenteredLabel(string.Format("Service ready: {0}", AGSClient.IsServiceReady()));
		if (initializationMenu.InitializationStatus != AmazonGameCircleExampleInitialization.EInitializationStatus.Ready)
		{
			initializationMenu.DrawMenu();
		}
		else
		{
			if (GUILayout.Button("Show GameCircle Overlay"))
			{
				AGSClient.ShowGameCircleOverlay();
			}
			if (GUILayout.Button("Show GameCircle Sign In"))
			{
				AGSClient.ShowSignInPage();
			}
			foreach (AmazonGameCircleExampleBase gameCircleExampleMenu in gameCircleExampleMenus)
			{
				GUILayout.BeginVertical(GUI.skin.box);
				gameCircleExampleMenu.foldoutOpen = AmazonGUIHelpers.FoldoutWithLabel(gameCircleExampleMenu.foldoutOpen, gameCircleExampleMenu.MenuTitle());
				if (gameCircleExampleMenu.foldoutOpen)
				{
					gameCircleExampleMenu.DrawMenu();
				}
				GUILayout.EndVertical();
			}
		}
		GUILayout.EndScrollView();
		AmazonGUIHelpers.EndMenuLayout();
		RevertLocalUISkin();
	}

	private void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			gameCircleExampleMenus.Add(AmazonGameCircleExamplePlayer.Instance());
			gameCircleExampleMenus.Add(AmazonGameCircleExampleAchievements.Instance());
			gameCircleExampleMenus.Add(AmazonGameCircleExampleLeaderboards.Instance());
			gameCircleExampleMenus.Add(AmazonGameCircleExampleWhispersync.Instance());
		}
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
}
