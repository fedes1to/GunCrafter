using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Video;
using GooglePlayGames.OurUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames
{
	public class PlayGamesPlatform : ISocialPlatform
	{
		[CompilerGenerated]
		private sealed class _003CInitializeNearby_003Ec__AnonStorey0
		{
			internal Action<INearbyConnectionClient> callback;

			internal void _003C_003Em__0(INearbyConnectionClient client)
			{
				Debug.Log("Nearby Client Created!!");
				sNearbyConnectionClient = client;
				if (callback != null)
				{
					callback(client);
				}
				else
				{
					Debug.Log("Initialize Nearby callback is null");
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CAuthenticate_003Ec__AnonStorey1
		{
			internal Action<bool> callback;

			internal void _003C_003Em__0(bool success, string msg)
			{
				callback(success);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadAchievementDescriptions_003Ec__AnonStorey2
		{
			internal Action<IAchievementDescription[]> callback;

			internal void _003C_003Em__0(Achievement[] ach)
			{
				IAchievementDescription[] array = new IAchievementDescription[ach.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new PlayGamesAchievement(ach[i]);
				}
				callback(array);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadAchievements_003Ec__AnonStorey3
		{
			internal Action<IAchievement[]> callback;

			internal void _003C_003Em__0(Achievement[] ach)
			{
				IAchievement[] array = new IAchievement[ach.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new PlayGamesAchievement(ach[i]);
				}
				callback(array);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadScores_003Ec__AnonStorey4
		{
			internal Action<IScore[]> callback;

			internal void _003C_003Em__0(LeaderboardScoreData scoreData)
			{
				callback(scoreData.Scores);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadScores_003Ec__AnonStorey5
		{
			internal ILeaderboard board;

			internal Action<bool> callback;

			internal PlayGamesPlatform _0024this;

			internal void _003C_003Em__0(LeaderboardScoreData scoreData)
			{
				_0024this.HandleLoadingScores((PlayGamesLeaderboard)board, scoreData, callback);
			}
		}

		[CompilerGenerated]
		private sealed class _003CHandleLoadingScores_003Ec__AnonStorey6
		{
			internal PlayGamesLeaderboard board;

			internal Action<bool> callback;

			internal PlayGamesPlatform _0024this;

			internal void _003C_003Em__0(LeaderboardScoreData nextScoreData)
			{
				_0024this.HandleLoadingScores(board, nextScoreData, callback);
			}
		}

		private static volatile PlayGamesPlatform sInstance;

		private static volatile bool sNearbyInitializePending;

		private static volatile INearbyConnectionClient sNearbyConnectionClient;

		private readonly PlayGamesClientConfiguration mConfiguration;

		private PlayGamesLocalUser mLocalUser;

		private IPlayGamesClient mClient;

		private string mDefaultLbUi;

		private Dictionary<string, string> mIdMap = new Dictionary<string, string>();

		public static bool DebugLogEnabled
		{
			get
			{
				return GooglePlayGames.OurUtils.Logger.DebugLogEnabled;
			}
			set
			{
				GooglePlayGames.OurUtils.Logger.DebugLogEnabled = value;
			}
		}

		public static PlayGamesPlatform Instance
		{
			get
			{
				if (sInstance == null)
				{
					GooglePlayGames.OurUtils.Logger.d("Instance was not initialized, using default configuration.");
					InitializeInstance(PlayGamesClientConfiguration.DefaultConfiguration);
				}
				return sInstance;
			}
		}

		public static INearbyConnectionClient Nearby
		{
			get
			{
				if (sNearbyConnectionClient == null && !sNearbyInitializePending)
				{
					sNearbyInitializePending = true;
					InitializeNearby(null);
				}
				return sNearbyConnectionClient;
			}
		}

		public IRealTimeMultiplayerClient RealTime
		{
			get
			{
				return mClient.GetRtmpClient();
			}
		}

		public ITurnBasedMultiplayerClient TurnBased
		{
			get
			{
				return mClient.GetTbmpClient();
			}
		}

		public ISavedGameClient SavedGame
		{
			get
			{
				return mClient.GetSavedGameClient();
			}
		}

		public IEventsClient Events
		{
			get
			{
				return mClient.GetEventsClient();
			}
		}

		[Obsolete("Quests are being removed in 2018.")]
		public IQuestsClient Quests
		{
			get
			{
				return mClient.GetQuestsClient();
			}
		}

		public IVideoClient Video
		{
			get
			{
				return mClient.GetVideoClient();
			}
		}

		public ILocalUser localUser
		{
			get
			{
				return mLocalUser;
			}
		}

		internal PlayGamesPlatform(IPlayGamesClient client)
		{
			mClient = Misc.CheckNotNull(client);
			mLocalUser = new PlayGamesLocalUser(this);
			mConfiguration = PlayGamesClientConfiguration.DefaultConfiguration;
		}

		private PlayGamesPlatform(PlayGamesClientConfiguration configuration)
		{
			GooglePlayGames.OurUtils.Logger.w("Creating new PlayGamesPlatform");
			mLocalUser = new PlayGamesLocalUser(this);
			mConfiguration = configuration;
		}

		public static void InitializeInstance(PlayGamesClientConfiguration configuration)
		{
			if (sInstance != null)
			{
				GooglePlayGames.OurUtils.Logger.w("PlayGamesPlatform already initialized. Ignoring this call.");
			}
			else
			{
				sInstance = new PlayGamesPlatform(configuration);
			}
		}

		public static void InitializeNearby(Action<INearbyConnectionClient> callback)
		{
			_003CInitializeNearby_003Ec__AnonStorey0 _003CInitializeNearby_003Ec__AnonStorey = new _003CInitializeNearby_003Ec__AnonStorey0();
			_003CInitializeNearby_003Ec__AnonStorey.callback = callback;
			Debug.Log("Calling InitializeNearby!");
			if (sNearbyConnectionClient == null)
			{
				NearbyConnectionClientFactory.Create(_003CInitializeNearby_003Ec__AnonStorey._003C_003Em__0);
			}
			else if (_003CInitializeNearby_003Ec__AnonStorey.callback != null)
			{
				Debug.Log("Nearby Already initialized: calling callback directly");
				_003CInitializeNearby_003Ec__AnonStorey.callback(sNearbyConnectionClient);
			}
			else
			{
				Debug.Log("Nearby Already initialized");
			}
		}

		public static PlayGamesPlatform Activate()
		{
			GooglePlayGames.OurUtils.Logger.d("Activating PlayGamesPlatform.");
			Social.Active = Instance;
			GooglePlayGames.OurUtils.Logger.d("PlayGamesPlatform activated: " + Social.Active);
			return Instance;
		}

		public IntPtr GetApiClient()
		{
			return mClient.GetApiClient();
		}

		public void SetGravityForPopups(Gravity gravity)
		{
			mClient.SetGravityForPopups(gravity);
		}

		public void AddIdMapping(string fromId, string toId)
		{
			mIdMap[fromId] = toId;
		}

		public void Authenticate(Action<bool> callback)
		{
			Authenticate(callback, false);
		}

		public void Authenticate(Action<bool, string> callback)
		{
			Authenticate(callback, false);
		}

		public void Authenticate(Action<bool> callback, bool silent)
		{
			_003CAuthenticate_003Ec__AnonStorey1 _003CAuthenticate_003Ec__AnonStorey = new _003CAuthenticate_003Ec__AnonStorey1();
			_003CAuthenticate_003Ec__AnonStorey.callback = callback;
			Authenticate(_003CAuthenticate_003Ec__AnonStorey._003C_003Em__0, silent);
		}

		public void Authenticate(Action<bool, string> callback, bool silent)
		{
			if (mClient == null)
			{
				GooglePlayGames.OurUtils.Logger.d("Creating platform-specific Play Games client.");
				mClient = PlayGamesClientFactory.GetPlatformPlayGamesClient(mConfiguration);
			}
			mClient.Authenticate(callback, silent);
		}

		public void Authenticate(ILocalUser unused, Action<bool> callback)
		{
			Authenticate(callback, false);
		}

		public void Authenticate(ILocalUser unused, Action<bool, string> callback)
		{
			Authenticate(callback, false);
		}

		public bool IsAuthenticated()
		{
			return mClient != null && mClient.IsAuthenticated();
		}

		public void SignOut()
		{
			if (mClient != null)
			{
				mClient.SignOut();
			}
			mLocalUser = new PlayGamesLocalUser(this);
		}

		public void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("GetUserId() can only be called after authentication.");
				callback(new IUserProfile[0]);
			}
			else
			{
				mClient.LoadUsers(userIds, callback);
			}
		}

		public string GetUserId()
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("GetUserId() can only be called after authentication.");
				return "0";
			}
			return mClient.GetUserId();
		}

		public string GetIdToken()
		{
			if (mClient != null)
			{
				return mClient.GetIdToken();
			}
			GooglePlayGames.OurUtils.Logger.e("No client available, returning null.");
			return null;
		}

		public string GetServerAuthCode()
		{
			if (mClient != null && mClient.IsAuthenticated())
			{
				return mClient.GetServerAuthCode();
			}
			return null;
		}

		public string GetUserEmail()
		{
			return mClient.GetUserEmail();
		}

		public void GetPlayerStats(Action<CommonStatusCodes, PlayerStats> callback)
		{
			if (mClient != null && mClient.IsAuthenticated())
			{
				mClient.GetPlayerStats(callback);
				return;
			}
			GooglePlayGames.OurUtils.Logger.e("GetPlayerStats can only be called after authentication.");
			callback(CommonStatusCodes.SignInRequired, new PlayerStats());
		}

		public Achievement GetAchievement(string achievementId)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("GetAchievement can only be called after authentication.");
				return null;
			}
			return mClient.GetAchievement(achievementId);
		}

		public string GetUserDisplayName()
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("GetUserDisplayName can only be called after authentication.");
				return string.Empty;
			}
			return mClient.GetUserDisplayName();
		}

		public string GetUserImageUrl()
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("GetUserImageUrl can only be called after authentication.");
				return null;
			}
			return mClient.GetUserImageUrl();
		}

		public void ReportProgress(string achievementID, double progress, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("ReportProgress can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			GooglePlayGames.OurUtils.Logger.d("ReportProgress, " + achievementID + ", " + progress);
			achievementID = MapId(achievementID);
			if (progress < 1E-06)
			{
				GooglePlayGames.OurUtils.Logger.d("Progress 0.00 interpreted as request to reveal.");
				mClient.RevealAchievement(achievementID, callback);
				return;
			}
			bool flag = false;
			int num = 0;
			int num2 = 0;
			Achievement achievement = mClient.GetAchievement(achievementID);
			if (achievement == null)
			{
				GooglePlayGames.OurUtils.Logger.w("Unable to locate achievement " + achievementID);
				GooglePlayGames.OurUtils.Logger.w("As a quick fix, assuming it's standard.");
				flag = false;
			}
			else
			{
				flag = achievement.IsIncremental;
				num = achievement.CurrentSteps;
				num2 = achievement.TotalSteps;
				GooglePlayGames.OurUtils.Logger.d("Achievement is " + ((!flag) ? "STANDARD" : "INCREMENTAL"));
				if (flag)
				{
					GooglePlayGames.OurUtils.Logger.d("Current steps: " + num + "/" + num2);
				}
			}
			if (flag)
			{
				GooglePlayGames.OurUtils.Logger.d("Progress " + progress + " interpreted as incremental target (approximate).");
				if (progress >= 0.0 && progress <= 1.0)
				{
					GooglePlayGames.OurUtils.Logger.w("Progress " + progress + " is less than or equal to 1. You might be trying to use values in the range of [0,1], while values are expected to be within the range [0,100]. If you are using the latter, you can safely ignore this message.");
				}
				int num3 = (int)Math.Round(progress / 100.0 * (double)num2);
				int num4 = num3 - num;
				GooglePlayGames.OurUtils.Logger.d("Target steps: " + num3 + ", cur steps:" + num);
				GooglePlayGames.OurUtils.Logger.d("Steps to increment: " + num4);
				if (num4 >= 0)
				{
					mClient.IncrementAchievement(achievementID, num4, callback);
				}
			}
			else if (progress >= 100.0)
			{
				GooglePlayGames.OurUtils.Logger.d("Progress " + progress + " interpreted as UNLOCK.");
				mClient.UnlockAchievement(achievementID, callback);
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("Progress " + progress + " not enough to unlock non-incremental achievement.");
			}
		}

		public void UnlockAchievement(string achievementID, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("UnlockAchievement can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("UnlockAchievement: " + achievementID);
				achievementID = MapId(achievementID);
				mClient.UnlockAchievement(achievementID, callback);
			}
		}

		public void IncrementAchievement(string achievementID, int steps, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("IncrementAchievement can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("IncrementAchievement: " + achievementID + ", steps " + steps);
				achievementID = MapId(achievementID);
				mClient.IncrementAchievement(achievementID, steps, callback);
			}
		}

		public void SetStepsAtLeast(string achievementID, int steps, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("SetStepsAtLeast can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("SetStepsAtLeast: " + achievementID + ", steps " + steps);
				achievementID = MapId(achievementID);
				mClient.SetStepsAtLeast(achievementID, steps, callback);
			}
		}

		public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
		{
			_003CLoadAchievementDescriptions_003Ec__AnonStorey2 _003CLoadAchievementDescriptions_003Ec__AnonStorey = new _003CLoadAchievementDescriptions_003Ec__AnonStorey2();
			_003CLoadAchievementDescriptions_003Ec__AnonStorey.callback = callback;
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("LoadAchievementDescriptions can only be called after authentication.");
				if (_003CLoadAchievementDescriptions_003Ec__AnonStorey.callback != null)
				{
					_003CLoadAchievementDescriptions_003Ec__AnonStorey.callback(null);
				}
			}
			else
			{
				mClient.LoadAchievements(_003CLoadAchievementDescriptions_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public void LoadAchievements(Action<IAchievement[]> callback)
		{
			_003CLoadAchievements_003Ec__AnonStorey3 _003CLoadAchievements_003Ec__AnonStorey = new _003CLoadAchievements_003Ec__AnonStorey3();
			_003CLoadAchievements_003Ec__AnonStorey.callback = callback;
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("LoadAchievements can only be called after authentication.");
				_003CLoadAchievements_003Ec__AnonStorey.callback(null);
			}
			else
			{
				mClient.LoadAchievements(_003CLoadAchievements_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public IAchievement CreateAchievement()
		{
			return new PlayGamesAchievement();
		}

		public void ReportScore(long score, string board, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("ReportScore can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("ReportScore: score=" + score + ", board=" + board);
				string leaderboardId = MapId(board);
				mClient.SubmitScore(leaderboardId, score, callback);
			}
		}

		public void ReportScore(long score, string board, string metadata, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("ReportScore can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
				return;
			}
			GooglePlayGames.OurUtils.Logger.d("ReportScore: score=" + score + ", board=" + board + " metadata=" + metadata);
			string leaderboardId = MapId(board);
			mClient.SubmitScore(leaderboardId, score, metadata, callback);
		}

		public void LoadScores(string leaderboardId, Action<IScore[]> callback)
		{
			_003CLoadScores_003Ec__AnonStorey4 _003CLoadScores_003Ec__AnonStorey = new _003CLoadScores_003Ec__AnonStorey4();
			_003CLoadScores_003Ec__AnonStorey.callback = callback;
			LoadScores(leaderboardId, LeaderboardStart.PlayerCentered, mClient.LeaderboardMaxResults(), LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime, _003CLoadScores_003Ec__AnonStorey._003C_003Em__0);
		}

		public void LoadScores(string leaderboardId, LeaderboardStart start, int rowCount, LeaderboardCollection collection, LeaderboardTimeSpan timeSpan, Action<LeaderboardScoreData> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("LoadScores can only be called after authentication.");
				callback(new LeaderboardScoreData(leaderboardId, ResponseStatus.NotAuthorized));
			}
			else
			{
				mClient.LoadScores(leaderboardId, start, rowCount, collection, timeSpan, callback);
			}
		}

		public void LoadMoreScores(ScorePageToken token, int rowCount, Action<LeaderboardScoreData> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("LoadMoreScores can only be called after authentication.");
				callback(new LeaderboardScoreData(token.LeaderboardId, ResponseStatus.NotAuthorized));
			}
			else
			{
				mClient.LoadMoreScores(token, rowCount, callback);
			}
		}

		public ILeaderboard CreateLeaderboard()
		{
			return new PlayGamesLeaderboard(mDefaultLbUi);
		}

		public void ShowAchievementsUI()
		{
			ShowAchievementsUI(null);
		}

		public void ShowAchievementsUI(Action<UIStatus> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("ShowAchievementsUI can only be called after authentication.");
				return;
			}
			GooglePlayGames.OurUtils.Logger.d("ShowAchievementsUI callback is " + callback);
			mClient.ShowAchievementsUI(callback);
		}

		public void ShowLeaderboardUI()
		{
			GooglePlayGames.OurUtils.Logger.d("ShowLeaderboardUI with default ID");
			ShowLeaderboardUI(MapId(mDefaultLbUi), null);
		}

		public void ShowLeaderboardUI(string leaderboardId)
		{
			if (leaderboardId != null)
			{
				leaderboardId = MapId(leaderboardId);
			}
			mClient.ShowLeaderboardUI(leaderboardId, LeaderboardTimeSpan.AllTime, null);
		}

		public void ShowLeaderboardUI(string leaderboardId, Action<UIStatus> callback)
		{
			ShowLeaderboardUI(leaderboardId, LeaderboardTimeSpan.AllTime, callback);
		}

		public void ShowLeaderboardUI(string leaderboardId, LeaderboardTimeSpan span, Action<UIStatus> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("ShowLeaderboardUI can only be called after authentication.");
				if (callback != null)
				{
					callback(UIStatus.NotAuthorized);
				}
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("ShowLeaderboardUI, lbId=" + leaderboardId + " callback is " + callback);
				mClient.ShowLeaderboardUI(leaderboardId, span, callback);
			}
		}

		public void SetDefaultLeaderboardForUI(string lbid)
		{
			GooglePlayGames.OurUtils.Logger.d("SetDefaultLeaderboardForUI: " + lbid);
			if (lbid != null)
			{
				lbid = MapId(lbid);
			}
			mDefaultLbUi = lbid;
		}

		public void LoadFriends(ILocalUser user, Action<bool> callback)
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("LoadScores can only be called after authentication.");
				if (callback != null)
				{
					callback(false);
				}
			}
			else
			{
				mClient.LoadFriends(callback);
			}
		}

		public void LoadScores(ILeaderboard board, Action<bool> callback)
		{
			_003CLoadScores_003Ec__AnonStorey5 _003CLoadScores_003Ec__AnonStorey = new _003CLoadScores_003Ec__AnonStorey5();
			_003CLoadScores_003Ec__AnonStorey.board = board;
			_003CLoadScores_003Ec__AnonStorey.callback = callback;
			_003CLoadScores_003Ec__AnonStorey._0024this = this;
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.e("LoadScores can only be called after authentication.");
				if (_003CLoadScores_003Ec__AnonStorey.callback != null)
				{
					_003CLoadScores_003Ec__AnonStorey.callback(false);
				}
				return;
			}
			LeaderboardTimeSpan timeSpan;
			switch (_003CLoadScores_003Ec__AnonStorey.board.timeScope)
			{
			case TimeScope.AllTime:
				timeSpan = LeaderboardTimeSpan.AllTime;
				break;
			case TimeScope.Week:
				timeSpan = LeaderboardTimeSpan.Weekly;
				break;
			case TimeScope.Today:
				timeSpan = LeaderboardTimeSpan.Daily;
				break;
			default:
				timeSpan = LeaderboardTimeSpan.AllTime;
				break;
			}
			((PlayGamesLeaderboard)_003CLoadScores_003Ec__AnonStorey.board).loading = true;
			GooglePlayGames.OurUtils.Logger.d(string.Concat("LoadScores, board=", _003CLoadScores_003Ec__AnonStorey.board, " callback is ", _003CLoadScores_003Ec__AnonStorey.callback));
			mClient.LoadScores(_003CLoadScores_003Ec__AnonStorey.board.id, LeaderboardStart.PlayerCentered, (_003CLoadScores_003Ec__AnonStorey.board.range.count <= 0) ? mClient.LeaderboardMaxResults() : _003CLoadScores_003Ec__AnonStorey.board.range.count, (_003CLoadScores_003Ec__AnonStorey.board.userScope != UserScope.FriendsOnly) ? LeaderboardCollection.Public : LeaderboardCollection.Social, timeSpan, _003CLoadScores_003Ec__AnonStorey._003C_003Em__0);
		}

		public bool GetLoading(ILeaderboard board)
		{
			return board != null && board.loading;
		}

		public void RegisterInvitationDelegate(InvitationReceivedDelegate deleg)
		{
			mClient.RegisterInvitationDelegate(deleg);
		}

		internal void HandleLoadingScores(PlayGamesLeaderboard board, LeaderboardScoreData scoreData, Action<bool> callback)
		{
			_003CHandleLoadingScores_003Ec__AnonStorey6 _003CHandleLoadingScores_003Ec__AnonStorey = new _003CHandleLoadingScores_003Ec__AnonStorey6();
			_003CHandleLoadingScores_003Ec__AnonStorey.board = board;
			_003CHandleLoadingScores_003Ec__AnonStorey.callback = callback;
			_003CHandleLoadingScores_003Ec__AnonStorey._0024this = this;
			bool flag = _003CHandleLoadingScores_003Ec__AnonStorey.board.SetFromData(scoreData);
			if (flag && !_003CHandleLoadingScores_003Ec__AnonStorey.board.HasAllScores() && scoreData.NextPageToken != null)
			{
				int rowCount = _003CHandleLoadingScores_003Ec__AnonStorey.board.range.count - _003CHandleLoadingScores_003Ec__AnonStorey.board.ScoreCount;
				mClient.LoadMoreScores(scoreData.NextPageToken, rowCount, _003CHandleLoadingScores_003Ec__AnonStorey._003C_003Em__0);
			}
			else
			{
				_003CHandleLoadingScores_003Ec__AnonStorey.callback(flag);
			}
		}

		internal IUserProfile[] GetFriends()
		{
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.d("Cannot get friends when not authenticated!");
				return new IUserProfile[0];
			}
			return mClient.GetFriends();
		}

		private string MapId(string id)
		{
			if (id == null)
			{
				return null;
			}
			if (mIdMap.ContainsKey(id))
			{
				string text = mIdMap[id];
				GooglePlayGames.OurUtils.Logger.d("Mapping alias " + id + " to ID " + text);
				return text;
			}
			return id;
		}
	}
}
