using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.BasicApi.Video;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames.Native
{
	public class NativeClient : IPlayGamesClient
	{
		private enum AuthState
		{
			Unauthenticated = 0,
			Authenticated = 1,
			SilentPending = 2
		}

		[CompilerGenerated]
		private sealed class _003CAsOnGameThreadCallback_003Ec__AnonStorey0<T>
		{
			internal Action<T> callback;

			internal void _003C_003Em__0(T result)
			{
				InvokeCallbackOnGameThread(callback, result);
			}
		}

		[CompilerGenerated]
		private sealed class _003CInvokeCallbackOnGameThread_003Ec__AnonStorey1<T, S>
		{
			internal Action<T, S> callback;

			internal T data;

			internal S msg;

			internal void _003C_003Em__0()
			{
				GooglePlayGames.OurUtils.Logger.d("Invoking user callback on game thread");
				callback(data, msg);
			}
		}

		[CompilerGenerated]
		private sealed class _003CInvokeCallbackOnGameThread_003Ec__AnonStorey2<T>
		{
			internal Action<T> callback;

			internal T data;

			internal void _003C_003Em__0()
			{
				GooglePlayGames.OurUtils.Logger.d("Invoking user callback on game thread");
				callback(data);
			}
		}

		[CompilerGenerated]
		private sealed class _003CHandleInvitation_003Ec__AnonStorey3
		{
			internal Action<Invitation, bool> currentHandler;

			internal Invitation invite;

			internal bool shouldAutolaunch;

			internal void _003C_003Em__0()
			{
				currentHandler(invite, shouldAutolaunch);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadFriends_003Ec__AnonStorey4
		{
			internal Action<bool> callback;

			internal NativeClient _0024this;

			internal void _003C_003Em__0()
			{
				callback(false);
			}

			internal void _003C_003Em__1()
			{
				callback(true);
			}

			internal void _003C_003Em__2(ResponseStatus status, List<GooglePlayGames.BasicApi.Multiplayer.Player> players)
			{
				if (status == ResponseStatus.Success || status == ResponseStatus.SuccessWithStale)
				{
					_0024this.mFriends = players;
					PlayGamesHelperObject.RunOnGameThread(_003C_003Em__3);
				}
				else
				{
					_0024this.mFriends = new List<GooglePlayGames.BasicApi.Multiplayer.Player>();
					GooglePlayGames.OurUtils.Logger.e(string.Concat("Got ", status, " loading friends"));
					PlayGamesHelperObject.RunOnGameThread(_003C_003Em__4);
				}
			}

			internal void _003C_003Em__3()
			{
				callback(true);
			}

			internal void _003C_003Em__4()
			{
				callback(false);
			}
		}

		[CompilerGenerated]
		private sealed class _003CHandleAuthTransition_003Ec__AnonStorey5
		{
			internal uint currentAuthGeneration;

			internal NativeClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.AchievementManager.FetchAllResponse results)
			{
				_0024this.PopulateAchievements(currentAuthGeneration, results);
			}

			internal void _003C_003Em__1(GooglePlayGames.Native.PInvoke.PlayerManager.FetchSelfResponse results)
			{
				_0024this.PopulateUser(currentAuthGeneration, results);
			}
		}

		[CompilerGenerated]
		private sealed class _003CSetGravityForPopups_003Ec__AnonStorey6
		{
			internal Gravity gravity;

			internal NativeClient _0024this;

			internal void _003C_003Em__0()
			{
				_0024this.clientImpl.SetGravityForPopups(_0024this.GetApiClient(), gravity);
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetPlayerStats_003Ec__AnonStorey7
		{
			internal Action<CommonStatusCodes, GooglePlayGames.BasicApi.PlayerStats> callback;

			internal NativeClient _0024this;

			internal void _003C_003Em__0()
			{
				_0024this.clientImpl.GetPlayerStats(_0024this.GetApiClient(), callback);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadUsers_003Ec__AnonStorey8
		{
			private sealed class _003CLoadUsers_003Ec__AnonStorey9
			{
				internal IUserProfile[] users;

				internal _003CLoadUsers_003Ec__AnonStorey8 _003C_003Ef__ref_00248;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00248.callback(users);
				}
			}

			internal Action<IUserProfile[]> callback;

			internal void _003C_003Em__0(NativePlayer[] nativeUsers)
			{
				_003CLoadUsers_003Ec__AnonStorey9 _003CLoadUsers_003Ec__AnonStorey = new _003CLoadUsers_003Ec__AnonStorey9();
				_003CLoadUsers_003Ec__AnonStorey._003C_003Ef__ref_00248 = this;
				_003CLoadUsers_003Ec__AnonStorey.users = new IUserProfile[nativeUsers.Length];
				for (int i = 0; i < _003CLoadUsers_003Ec__AnonStorey.users.Length; i++)
				{
					_003CLoadUsers_003Ec__AnonStorey.users[i] = nativeUsers[i].AsPlayer();
				}
				PlayGamesHelperObject.RunOnGameThread(_003CLoadUsers_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadAchievements_003Ec__AnonStoreyA
		{
			internal Action<GooglePlayGames.BasicApi.Achievement[]> callback;

			internal GooglePlayGames.BasicApi.Achievement[] data;

			internal void _003C_003Em__0()
			{
				callback(data);
			}
		}

		[CompilerGenerated]
		private sealed class _003CUnlockAchievement_003Ec__AnonStoreyB
		{
			internal string achId;

			internal NativeClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.BasicApi.Achievement a)
			{
				a.IsUnlocked = true;
				_0024this.GameServices().AchievementManager().Unlock(achId);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRevealAchievement_003Ec__AnonStoreyC
		{
			internal string achId;

			internal NativeClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.BasicApi.Achievement a)
			{
				a.IsRevealed = true;
				_0024this.GameServices().AchievementManager().Reveal(achId);
			}
		}

		[CompilerGenerated]
		private sealed class _003CUpdateAchievement_003Ec__AnonStoreyD
		{
			internal string achId;

			internal Action<bool> callback;

			internal NativeClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.AchievementManager.FetchResponse rsp)
			{
				if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID)
				{
					_0024this.mAchievements.Remove(achId);
					_0024this.mAchievements.Add(achId, rsp.Achievement().AsAchievement());
					callback(true);
					return;
				}
				GooglePlayGames.OurUtils.Logger.e("Cannot refresh achievement " + achId + ": " + rsp.Status());
				callback(false);
			}
		}

		[CompilerGenerated]
		private sealed class _003CIncrementAchievement_003Ec__AnonStoreyE
		{
			internal string achId;

			internal Action<bool> callback;

			internal NativeClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.AchievementManager.FetchResponse rsp)
			{
				if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID)
				{
					_0024this.mAchievements.Remove(achId);
					_0024this.mAchievements.Add(achId, rsp.Achievement().AsAchievement());
					callback(true);
					return;
				}
				GooglePlayGames.OurUtils.Logger.e("Cannot refresh achievement " + achId + ": " + rsp.Status());
				callback(false);
			}
		}

		[CompilerGenerated]
		private sealed class _003CSetStepsAtLeast_003Ec__AnonStoreyF
		{
			internal string achId;

			internal Action<bool> callback;

			internal NativeClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.AchievementManager.FetchResponse rsp)
			{
				if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID)
				{
					_0024this.mAchievements.Remove(achId);
					_0024this.mAchievements.Add(achId, rsp.Achievement().AsAchievement());
					callback(true);
					return;
				}
				GooglePlayGames.OurUtils.Logger.e("Cannot refresh achievement " + achId + ": " + rsp.Status());
				callback(false);
			}
		}

		[CompilerGenerated]
		private sealed class _003CShowAchievementsUI_003Ec__AnonStorey10
		{
			internal Action<UIStatus> cb;

			internal void _003C_003Em__0(CommonErrorStatus.UIStatus result)
			{
				cb((UIStatus)result);
			}
		}

		[CompilerGenerated]
		private sealed class _003CShowLeaderboardUI_003Ec__AnonStorey11
		{
			internal Action<UIStatus> cb;

			internal void _003C_003Em__0(CommonErrorStatus.UIStatus result)
			{
				cb((UIStatus)result);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRegisterInvitationDelegate_003Ec__AnonStorey12
		{
			internal InvitationReceivedDelegate invitationDelegate;

			internal void _003C_003Em__0(Invitation invitation, bool autoAccept)
			{
				invitationDelegate(invitation, autoAccept);
			}
		}

		private readonly IClientImpl clientImpl;

		private readonly object GameServicesLock = new object();

		private readonly object AuthStateLock = new object();

		private readonly PlayGamesClientConfiguration mConfiguration;

		private GooglePlayGames.Native.PInvoke.GameServices mServices;

		private volatile NativeTurnBasedMultiplayerClient mTurnBasedClient;

		private volatile NativeRealtimeMultiplayerClient mRealTimeClient;

		private volatile ISavedGameClient mSavedGameClient;

		private volatile IEventsClient mEventsClient;

		private volatile IQuestsClient mQuestsClient;

		private volatile IVideoClient mVideoClient;

		private volatile TokenClient mTokenClient;

		private volatile Action<Invitation, bool> mInvitationDelegate;

		private volatile Dictionary<string, GooglePlayGames.BasicApi.Achievement> mAchievements;

		private volatile GooglePlayGames.BasicApi.Multiplayer.Player mUser;

		private volatile List<GooglePlayGames.BasicApi.Multiplayer.Player> mFriends;

		private volatile Action<bool, string> mPendingAuthCallbacks;

		private volatile Action<bool, string> mSilentAuthCallbacks;

		private volatile AuthState mAuthState;

		private volatile uint mAuthGeneration;

		private volatile bool mSilentAuthFailed;

		private volatile bool friendsLoading;

		[CompilerGenerated]
		private static Predicate<GooglePlayGames.BasicApi.Achievement> _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		private static Predicate<GooglePlayGames.BasicApi.Achievement> _003C_003Ef__am_0024cache1;

		internal NativeClient(PlayGamesClientConfiguration configuration, IClientImpl clientImpl)
		{
			PlayGamesHelperObject.CreateObject();
			mConfiguration = Misc.CheckNotNull(configuration);
			this.clientImpl = clientImpl;
		}

		private GooglePlayGames.Native.PInvoke.GameServices GameServices()
		{
			lock (GameServicesLock)
			{
				return mServices;
			}
		}

		public void Authenticate(Action<bool, string> callback, bool silent)
		{
			lock (AuthStateLock)
			{
				if (mAuthState == AuthState.Authenticated)
				{
					InvokeCallbackOnGameThread(callback, true, null);
					return;
				}
				if (mSilentAuthFailed && silent)
				{
					InvokeCallbackOnGameThread(callback, false, "silent auth failed");
					return;
				}
				if (callback != null)
				{
					if (silent)
					{
						mSilentAuthCallbacks = (Action<bool, string>)Delegate.Combine(mSilentAuthCallbacks, callback);
					}
					else
					{
						mPendingAuthCallbacks = (Action<bool, string>)Delegate.Combine(mPendingAuthCallbacks, callback);
					}
				}
			}
			friendsLoading = false;
			InitializeTokenClient();
			if (mTokenClient.NeedsToRun())
			{
				Debug.Log("Starting Auth with token client.");
				mTokenClient.FetchTokens(_003CAuthenticate_003Em__0);
				return;
			}
			InitializeGameServices();
			if (!silent)
			{
				GameServices().StartAuthorizationUI();
			}
		}

		private static Action<T> AsOnGameThreadCallback<T>(Action<T> callback)
		{
			_003CAsOnGameThreadCallback_003Ec__AnonStorey0<T> _003CAsOnGameThreadCallback_003Ec__AnonStorey = new _003CAsOnGameThreadCallback_003Ec__AnonStorey0<T>();
			_003CAsOnGameThreadCallback_003Ec__AnonStorey.callback = callback;
			if (_003CAsOnGameThreadCallback_003Ec__AnonStorey.callback == null)
			{
				return _003CAsOnGameThreadCallback_00601_003Em__1;
			}
			return _003CAsOnGameThreadCallback_003Ec__AnonStorey._003C_003Em__0;
		}

		private static void InvokeCallbackOnGameThread<T, S>(Action<T, S> callback, T data, S msg)
		{
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey1<T, S> _003CInvokeCallbackOnGameThread_003Ec__AnonStorey = new _003CInvokeCallbackOnGameThread_003Ec__AnonStorey1<T, S>();
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.callback = callback;
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.data = data;
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.msg = msg;
			if (_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.callback != null)
			{
				PlayGamesHelperObject.RunOnGameThread(_003CInvokeCallbackOnGameThread_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		private static void InvokeCallbackOnGameThread<T>(Action<T> callback, T data)
		{
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey2<T> _003CInvokeCallbackOnGameThread_003Ec__AnonStorey = new _003CInvokeCallbackOnGameThread_003Ec__AnonStorey2<T>();
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.callback = callback;
			_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.data = data;
			if (_003CInvokeCallbackOnGameThread_003Ec__AnonStorey.callback != null)
			{
				PlayGamesHelperObject.RunOnGameThread(_003CInvokeCallbackOnGameThread_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		private void InitializeGameServices()
		{
			lock (GameServicesLock)
			{
				if (mServices != null)
				{
					return;
				}
				using (GameServicesBuilder gameServicesBuilder = GameServicesBuilder.Create())
				{
					using (PlatformConfiguration configRef = clientImpl.CreatePlatformConfiguration(mConfiguration))
					{
						RegisterInvitationDelegate(mConfiguration.InvitationDelegate);
						gameServicesBuilder.SetOnAuthFinishedCallback(HandleAuthTransition);
						gameServicesBuilder.SetOnTurnBasedMatchEventCallback(_003CInitializeGameServices_003Em__2);
						gameServicesBuilder.SetOnMultiplayerInvitationEventCallback(HandleInvitation);
						if (mConfiguration.EnableSavedGames)
						{
							gameServicesBuilder.EnableSnapshots();
						}
						string[] scopes = mConfiguration.Scopes;
						for (int i = 0; i < scopes.Length; i++)
						{
							gameServicesBuilder.AddOauthScope(scopes[i]);
						}
						if (mConfiguration.IsHidingPopups)
						{
							gameServicesBuilder.SetShowConnectingPopup(false);
						}
						Debug.Log("Building GPG services, implicitly attempts silent auth");
						mAuthState = AuthState.SilentPending;
						mServices = gameServicesBuilder.Build(configRef);
						mEventsClient = new NativeEventClient(new GooglePlayGames.Native.PInvoke.EventManager(mServices));
						mQuestsClient = new NativeQuestClient(new GooglePlayGames.Native.PInvoke.QuestManager(mServices));
						mVideoClient = new NativeVideoClient(new GooglePlayGames.Native.PInvoke.VideoManager(mServices));
						mTurnBasedClient = new NativeTurnBasedMultiplayerClient(this, new TurnBasedManager(mServices));
						mTurnBasedClient.RegisterMatchDelegate(mConfiguration.MatchDelegate);
						mRealTimeClient = new NativeRealtimeMultiplayerClient(this, new RealtimeManager(mServices));
						if (mConfiguration.EnableSavedGames)
						{
							mSavedGameClient = new NativeSavedGameClient(new GooglePlayGames.Native.PInvoke.SnapshotManager(mServices));
						}
						else
						{
							mSavedGameClient = new UnsupportedSavedGamesClient("You must enable saved games before it can be used. See PlayGamesClientConfiguration.Builder.EnableSavedGames.");
						}
						mAuthState = AuthState.SilentPending;
						InitializeTokenClient();
					}
				}
			}
		}

		private void InitializeTokenClient()
		{
			if (mTokenClient == null)
			{
				mTokenClient = clientImpl.CreateTokenClient(true);
				if (!GameInfo.WebClientIdInitialized() && (mConfiguration.IsRequestingIdToken || mConfiguration.IsRequestingAuthCode))
				{
					GooglePlayGames.OurUtils.Logger.e("Server Auth Code and ID Token require web clientId to configured.");
				}
				string[] scopes = mConfiguration.Scopes;
				mTokenClient.SetWebClientId(string.Empty);
				mTokenClient.SetRequestAuthCode(mConfiguration.IsRequestingAuthCode, mConfiguration.IsForcingRefresh);
				mTokenClient.SetRequestEmail(mConfiguration.IsRequestingEmail);
				mTokenClient.SetRequestIdToken(mConfiguration.IsRequestingIdToken);
				mTokenClient.SetHidePopups(mConfiguration.IsHidingPopups);
				mTokenClient.AddOauthScopes(scopes);
				mTokenClient.SetAccountName(mConfiguration.AccountName);
			}
		}

		internal void HandleInvitation(GooglePlayGames.Native.Cwrapper.Types.MultiplayerEvent eventType, string invitationId, GooglePlayGames.Native.PInvoke.MultiplayerInvitation invitation)
		{
			_003CHandleInvitation_003Ec__AnonStorey3 _003CHandleInvitation_003Ec__AnonStorey = new _003CHandleInvitation_003Ec__AnonStorey3();
			_003CHandleInvitation_003Ec__AnonStorey.currentHandler = mInvitationDelegate;
			if (_003CHandleInvitation_003Ec__AnonStorey.currentHandler == null)
			{
				GooglePlayGames.OurUtils.Logger.d(string.Concat("Received ", eventType, " for invitation ", invitationId, " but no handler was registered."));
			}
			else if (eventType == GooglePlayGames.Native.Cwrapper.Types.MultiplayerEvent.REMOVED)
			{
				GooglePlayGames.OurUtils.Logger.d("Ignoring REMOVED for invitation " + invitationId);
			}
			else
			{
				_003CHandleInvitation_003Ec__AnonStorey.shouldAutolaunch = eventType == GooglePlayGames.Native.Cwrapper.Types.MultiplayerEvent.UPDATED_FROM_APP_LAUNCH;
				_003CHandleInvitation_003Ec__AnonStorey.invite = invitation.AsInvitation();
				PlayGamesHelperObject.RunOnGameThread(_003CHandleInvitation_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public string GetUserEmail()
		{
			if (!IsAuthenticated())
			{
				Debug.Log("Cannot get API client - not authenticated");
				return null;
			}
			return mTokenClient.GetEmail();
		}

		public string GetIdToken()
		{
			if (!IsAuthenticated())
			{
				Debug.Log("Cannot get API client - not authenticated");
				return null;
			}
			return mTokenClient.GetIdToken();
		}

		public string GetServerAuthCode()
		{
			if (!IsAuthenticated())
			{
				Debug.Log("Cannot get API client - not authenticated");
				return null;
			}
			return mTokenClient.GetAuthCode();
		}

		public bool IsAuthenticated()
		{
			lock (AuthStateLock)
			{
				return mAuthState == AuthState.Authenticated;
			}
		}

		public void LoadFriends(Action<bool> callback)
		{
			_003CLoadFriends_003Ec__AnonStorey4 _003CLoadFriends_003Ec__AnonStorey = new _003CLoadFriends_003Ec__AnonStorey4();
			_003CLoadFriends_003Ec__AnonStorey.callback = callback;
			_003CLoadFriends_003Ec__AnonStorey._0024this = this;
			if (!IsAuthenticated())
			{
				GooglePlayGames.OurUtils.Logger.d("Cannot loadFriends when not authenticated");
				PlayGamesHelperObject.RunOnGameThread(_003CLoadFriends_003Ec__AnonStorey._003C_003Em__0);
			}
			else if (mFriends != null)
			{
				PlayGamesHelperObject.RunOnGameThread(_003CLoadFriends_003Ec__AnonStorey._003C_003Em__1);
			}
			else
			{
				mServices.PlayerManager().FetchFriends(_003CLoadFriends_003Ec__AnonStorey._003C_003Em__2);
			}
		}

		public IUserProfile[] GetFriends()
		{
			if (mFriends == null && !friendsLoading)
			{
				GooglePlayGames.OurUtils.Logger.w("Getting friends before they are loaded!!!");
				friendsLoading = true;
				LoadFriends(_003CGetFriends_003Em__3);
			}
			return (mFriends != null) ? mFriends.ToArray() : new IUserProfile[0];
		}

		private void PopulateAchievements(uint authGeneration, GooglePlayGames.Native.PInvoke.AchievementManager.FetchAllResponse response)
		{
			if (authGeneration != mAuthGeneration)
			{
				GooglePlayGames.OurUtils.Logger.d("Received achievement callback after signout occurred, ignoring");
				return;
			}
			GooglePlayGames.OurUtils.Logger.d("Populating Achievements, status = " + response.Status());
			lock (AuthStateLock)
			{
				if (response.Status() != CommonErrorStatus.ResponseStatus.VALID && response.Status() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
				{
					GooglePlayGames.OurUtils.Logger.e("Error retrieving achievements - check the log for more information. Failing signin.");
					Action<bool, string> action = mPendingAuthCallbacks;
					mPendingAuthCallbacks = null;
					if (action != null)
					{
						InvokeCallbackOnGameThread(action, false, "Cannot load achievements, Authenication failing");
					}
					SignOut();
					return;
				}
				Dictionary<string, GooglePlayGames.BasicApi.Achievement> dictionary = new Dictionary<string, GooglePlayGames.BasicApi.Achievement>();
				foreach (NativeAchievement item in response)
				{
					using (item)
					{
						dictionary[item.Id()] = item.AsAchievement();
					}
				}
				GooglePlayGames.OurUtils.Logger.d("Found " + dictionary.Count + " Achievements");
				mAchievements = dictionary;
			}
			GooglePlayGames.OurUtils.Logger.d("Maybe finish for Achievements");
			MaybeFinishAuthentication();
		}

		private void MaybeFinishAuthentication()
		{
			Action<bool, string> action = null;
			lock (AuthStateLock)
			{
				if (mUser == null || mAchievements == null)
				{
					GooglePlayGames.OurUtils.Logger.d(string.Concat("Auth not finished. User=", mUser, " achievements=", mAchievements));
					return;
				}
				GooglePlayGames.OurUtils.Logger.d("Auth finished. Proceeding.");
				action = mPendingAuthCallbacks;
				mPendingAuthCallbacks = null;
				mAuthState = AuthState.Authenticated;
			}
			if (action != null)
			{
				GooglePlayGames.OurUtils.Logger.d("Invoking Callbacks: " + action);
				InvokeCallbackOnGameThread(action, true, null);
			}
		}

		private void PopulateUser(uint authGeneration, GooglePlayGames.Native.PInvoke.PlayerManager.FetchSelfResponse response)
		{
			GooglePlayGames.OurUtils.Logger.d("Populating User");
			if (authGeneration != mAuthGeneration)
			{
				GooglePlayGames.OurUtils.Logger.d("Received user callback after signout occurred, ignoring");
				return;
			}
			lock (AuthStateLock)
			{
				if (response.Status() != CommonErrorStatus.ResponseStatus.VALID && response.Status() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
				{
					GooglePlayGames.OurUtils.Logger.e("Error retrieving user, signing out");
					Action<bool, string> action = mPendingAuthCallbacks;
					mPendingAuthCallbacks = null;
					if (action != null)
					{
						InvokeCallbackOnGameThread(action, false, "Cannot load user profile");
					}
					SignOut();
					return;
				}
				mUser = response.Self().AsPlayer();
				mFriends = null;
			}
			GooglePlayGames.OurUtils.Logger.d("Found User: " + mUser);
			GooglePlayGames.OurUtils.Logger.d("Maybe finish for User");
			MaybeFinishAuthentication();
		}

		private void HandleAuthTransition(GooglePlayGames.Native.Cwrapper.Types.AuthOperation operation, CommonErrorStatus.AuthStatus status)
		{
			GooglePlayGames.OurUtils.Logger.d(string.Concat("Starting Auth Transition. Op: ", operation, " status: ", status));
			lock (AuthStateLock)
			{
				switch (operation)
				{
				case GooglePlayGames.Native.Cwrapper.Types.AuthOperation.SIGN_IN:
					if (status == CommonErrorStatus.AuthStatus.VALID)
					{
						_003CHandleAuthTransition_003Ec__AnonStorey5 _003CHandleAuthTransition_003Ec__AnonStorey = new _003CHandleAuthTransition_003Ec__AnonStorey5();
						_003CHandleAuthTransition_003Ec__AnonStorey._0024this = this;
						if (mSilentAuthCallbacks != null)
						{
							mPendingAuthCallbacks = (Action<bool, string>)Delegate.Combine(mPendingAuthCallbacks, mSilentAuthCallbacks);
							mSilentAuthCallbacks = null;
						}
						_003CHandleAuthTransition_003Ec__AnonStorey.currentAuthGeneration = mAuthGeneration;
						mServices.AchievementManager().FetchAll(_003CHandleAuthTransition_003Ec__AnonStorey._003C_003Em__0);
						mServices.PlayerManager().FetchSelf(_003CHandleAuthTransition_003Ec__AnonStorey._003C_003Em__1);
					}
					else if (mAuthState == AuthState.SilentPending)
					{
						mSilentAuthFailed = true;
						mAuthState = AuthState.Unauthenticated;
						Action<bool, string> callback = mSilentAuthCallbacks;
						mSilentAuthCallbacks = null;
						GooglePlayGames.OurUtils.Logger.d("Invoking callbacks, AuthState changed from silentPending to Unauthenticated.");
						InvokeCallbackOnGameThread(callback, false, "silent auth failed");
						if (mPendingAuthCallbacks != null)
						{
							GooglePlayGames.OurUtils.Logger.d("there are pending auth callbacks - starting AuthUI");
							GameServices().StartAuthorizationUI();
						}
					}
					else
					{
						GooglePlayGames.OurUtils.Logger.d(string.Concat("AuthState == ", mAuthState, " calling auth callbacks with failure"));
						UnpauseUnityPlayer();
						Action<bool, string> callback2 = mPendingAuthCallbacks;
						mPendingAuthCallbacks = null;
						InvokeCallbackOnGameThread(callback2, false, "Authentication failed");
					}
					break;
				case GooglePlayGames.Native.Cwrapper.Types.AuthOperation.SIGN_OUT:
					ToUnauthenticated();
					break;
				default:
					GooglePlayGames.OurUtils.Logger.e("Unknown AuthOperation " + operation);
					break;
				}
			}
		}

		private void UnpauseUnityPlayer()
		{
		}

		private void ToUnauthenticated()
		{
			lock (AuthStateLock)
			{
				mUser = null;
				mFriends = null;
				mAchievements = null;
				mAuthState = AuthState.Unauthenticated;
				mTokenClient = clientImpl.CreateTokenClient(true);
				mAuthGeneration++;
			}
		}

		public void SignOut()
		{
			ToUnauthenticated();
			if (GameServices() != null)
			{
				mTokenClient.Signout();
				GameServices().SignOut();
			}
		}

		public string GetUserId()
		{
			if (mUser == null)
			{
				return null;
			}
			return mUser.id;
		}

		public string GetUserDisplayName()
		{
			if (mUser == null)
			{
				return null;
			}
			return mUser.userName;
		}

		public string GetUserImageUrl()
		{
			if (mUser == null)
			{
				return null;
			}
			return mUser.AvatarURL;
		}

		public void SetGravityForPopups(Gravity gravity)
		{
			_003CSetGravityForPopups_003Ec__AnonStorey6 _003CSetGravityForPopups_003Ec__AnonStorey = new _003CSetGravityForPopups_003Ec__AnonStorey6();
			_003CSetGravityForPopups_003Ec__AnonStorey.gravity = gravity;
			_003CSetGravityForPopups_003Ec__AnonStorey._0024this = this;
			PlayGamesHelperObject.RunOnGameThread(_003CSetGravityForPopups_003Ec__AnonStorey._003C_003Em__0);
		}

		public void GetPlayerStats(Action<CommonStatusCodes, GooglePlayGames.BasicApi.PlayerStats> callback)
		{
			_003CGetPlayerStats_003Ec__AnonStorey7 _003CGetPlayerStats_003Ec__AnonStorey = new _003CGetPlayerStats_003Ec__AnonStorey7();
			_003CGetPlayerStats_003Ec__AnonStorey.callback = callback;
			_003CGetPlayerStats_003Ec__AnonStorey._0024this = this;
			PlayGamesHelperObject.RunOnGameThread(_003CGetPlayerStats_003Ec__AnonStorey._003C_003Em__0);
		}

		public void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
		{
			_003CLoadUsers_003Ec__AnonStorey8 _003CLoadUsers_003Ec__AnonStorey = new _003CLoadUsers_003Ec__AnonStorey8();
			_003CLoadUsers_003Ec__AnonStorey.callback = callback;
			mServices.PlayerManager().FetchList(userIds, _003CLoadUsers_003Ec__AnonStorey._003C_003Em__0);
		}

		public GooglePlayGames.BasicApi.Achievement GetAchievement(string achId)
		{
			if (mAchievements == null || !mAchievements.ContainsKey(achId))
			{
				return null;
			}
			return mAchievements[achId];
		}

		public void LoadAchievements(Action<GooglePlayGames.BasicApi.Achievement[]> callback)
		{
			_003CLoadAchievements_003Ec__AnonStoreyA _003CLoadAchievements_003Ec__AnonStoreyA = new _003CLoadAchievements_003Ec__AnonStoreyA();
			_003CLoadAchievements_003Ec__AnonStoreyA.callback = callback;
			_003CLoadAchievements_003Ec__AnonStoreyA.data = new GooglePlayGames.BasicApi.Achievement[mAchievements.Count];
			mAchievements.Values.CopyTo(_003CLoadAchievements_003Ec__AnonStoreyA.data, 0);
			PlayGamesHelperObject.RunOnGameThread(_003CLoadAchievements_003Ec__AnonStoreyA._003C_003Em__0);
		}

		public void UnlockAchievement(string achId, Action<bool> callback)
		{
			_003CUnlockAchievement_003Ec__AnonStoreyB _003CUnlockAchievement_003Ec__AnonStoreyB = new _003CUnlockAchievement_003Ec__AnonStoreyB();
			_003CUnlockAchievement_003Ec__AnonStoreyB.achId = achId;
			_003CUnlockAchievement_003Ec__AnonStoreyB._0024this = this;
			string achId2 = _003CUnlockAchievement_003Ec__AnonStoreyB.achId;
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003CUnlockAchievement_003Em__4;
			}
			UpdateAchievement("Unlock", achId2, callback, _003C_003Ef__am_0024cache0, _003CUnlockAchievement_003Ec__AnonStoreyB._003C_003Em__0);
		}

		public void RevealAchievement(string achId, Action<bool> callback)
		{
			_003CRevealAchievement_003Ec__AnonStoreyC _003CRevealAchievement_003Ec__AnonStoreyC = new _003CRevealAchievement_003Ec__AnonStoreyC();
			_003CRevealAchievement_003Ec__AnonStoreyC.achId = achId;
			_003CRevealAchievement_003Ec__AnonStoreyC._0024this = this;
			string achId2 = _003CRevealAchievement_003Ec__AnonStoreyC.achId;
			if (_003C_003Ef__am_0024cache1 == null)
			{
				_003C_003Ef__am_0024cache1 = _003CRevealAchievement_003Em__5;
			}
			UpdateAchievement("Reveal", achId2, callback, _003C_003Ef__am_0024cache1, _003CRevealAchievement_003Ec__AnonStoreyC._003C_003Em__0);
		}

		private void UpdateAchievement(string updateType, string achId, Action<bool> callback, Predicate<GooglePlayGames.BasicApi.Achievement> alreadyDone, Action<GooglePlayGames.BasicApi.Achievement> updateAchievment)
		{
			_003CUpdateAchievement_003Ec__AnonStoreyD _003CUpdateAchievement_003Ec__AnonStoreyD = new _003CUpdateAchievement_003Ec__AnonStoreyD();
			_003CUpdateAchievement_003Ec__AnonStoreyD.achId = achId;
			_003CUpdateAchievement_003Ec__AnonStoreyD.callback = callback;
			_003CUpdateAchievement_003Ec__AnonStoreyD._0024this = this;
			_003CUpdateAchievement_003Ec__AnonStoreyD.callback = AsOnGameThreadCallback(_003CUpdateAchievement_003Ec__AnonStoreyD.callback);
			Misc.CheckNotNull(_003CUpdateAchievement_003Ec__AnonStoreyD.achId);
			InitializeGameServices();
			GooglePlayGames.BasicApi.Achievement achievement = GetAchievement(_003CUpdateAchievement_003Ec__AnonStoreyD.achId);
			if (achievement == null)
			{
				GooglePlayGames.OurUtils.Logger.d("Could not " + updateType + ", no achievement with ID " + _003CUpdateAchievement_003Ec__AnonStoreyD.achId);
				_003CUpdateAchievement_003Ec__AnonStoreyD.callback(false);
			}
			else if (alreadyDone(achievement))
			{
				GooglePlayGames.OurUtils.Logger.d("Did not need to perform " + updateType + ": on achievement " + _003CUpdateAchievement_003Ec__AnonStoreyD.achId);
				_003CUpdateAchievement_003Ec__AnonStoreyD.callback(true);
			}
			else
			{
				GooglePlayGames.OurUtils.Logger.d("Performing " + updateType + " on " + _003CUpdateAchievement_003Ec__AnonStoreyD.achId);
				updateAchievment(achievement);
				GameServices().AchievementManager().Fetch(_003CUpdateAchievement_003Ec__AnonStoreyD.achId, _003CUpdateAchievement_003Ec__AnonStoreyD._003C_003Em__0);
			}
		}

		public void IncrementAchievement(string achId, int steps, Action<bool> callback)
		{
			_003CIncrementAchievement_003Ec__AnonStoreyE _003CIncrementAchievement_003Ec__AnonStoreyE = new _003CIncrementAchievement_003Ec__AnonStoreyE();
			_003CIncrementAchievement_003Ec__AnonStoreyE.achId = achId;
			_003CIncrementAchievement_003Ec__AnonStoreyE.callback = callback;
			_003CIncrementAchievement_003Ec__AnonStoreyE._0024this = this;
			Misc.CheckNotNull(_003CIncrementAchievement_003Ec__AnonStoreyE.achId);
			_003CIncrementAchievement_003Ec__AnonStoreyE.callback = AsOnGameThreadCallback(_003CIncrementAchievement_003Ec__AnonStoreyE.callback);
			InitializeGameServices();
			GooglePlayGames.BasicApi.Achievement achievement = GetAchievement(_003CIncrementAchievement_003Ec__AnonStoreyE.achId);
			if (achievement == null)
			{
				GooglePlayGames.OurUtils.Logger.e("Could not increment, no achievement with ID " + _003CIncrementAchievement_003Ec__AnonStoreyE.achId);
				_003CIncrementAchievement_003Ec__AnonStoreyE.callback(false);
			}
			else if (!achievement.IsIncremental)
			{
				GooglePlayGames.OurUtils.Logger.e("Could not increment, achievement with ID " + _003CIncrementAchievement_003Ec__AnonStoreyE.achId + " was not incremental");
				_003CIncrementAchievement_003Ec__AnonStoreyE.callback(false);
			}
			else if (steps < 0)
			{
				GooglePlayGames.OurUtils.Logger.e("Attempted to increment by negative steps");
				_003CIncrementAchievement_003Ec__AnonStoreyE.callback(false);
			}
			else
			{
				GameServices().AchievementManager().Increment(_003CIncrementAchievement_003Ec__AnonStoreyE.achId, Convert.ToUInt32(steps));
				GameServices().AchievementManager().Fetch(_003CIncrementAchievement_003Ec__AnonStoreyE.achId, _003CIncrementAchievement_003Ec__AnonStoreyE._003C_003Em__0);
			}
		}

		public void SetStepsAtLeast(string achId, int steps, Action<bool> callback)
		{
			_003CSetStepsAtLeast_003Ec__AnonStoreyF _003CSetStepsAtLeast_003Ec__AnonStoreyF = new _003CSetStepsAtLeast_003Ec__AnonStoreyF();
			_003CSetStepsAtLeast_003Ec__AnonStoreyF.achId = achId;
			_003CSetStepsAtLeast_003Ec__AnonStoreyF.callback = callback;
			_003CSetStepsAtLeast_003Ec__AnonStoreyF._0024this = this;
			Misc.CheckNotNull(_003CSetStepsAtLeast_003Ec__AnonStoreyF.achId);
			_003CSetStepsAtLeast_003Ec__AnonStoreyF.callback = AsOnGameThreadCallback(_003CSetStepsAtLeast_003Ec__AnonStoreyF.callback);
			InitializeGameServices();
			GooglePlayGames.BasicApi.Achievement achievement = GetAchievement(_003CSetStepsAtLeast_003Ec__AnonStoreyF.achId);
			if (achievement == null)
			{
				GooglePlayGames.OurUtils.Logger.e("Could not increment, no achievement with ID " + _003CSetStepsAtLeast_003Ec__AnonStoreyF.achId);
				_003CSetStepsAtLeast_003Ec__AnonStoreyF.callback(false);
			}
			else if (!achievement.IsIncremental)
			{
				GooglePlayGames.OurUtils.Logger.e("Could not increment, achievement with ID " + _003CSetStepsAtLeast_003Ec__AnonStoreyF.achId + " is not incremental");
				_003CSetStepsAtLeast_003Ec__AnonStoreyF.callback(false);
			}
			else if (steps < 0)
			{
				GooglePlayGames.OurUtils.Logger.e("Attempted to increment by negative steps");
				_003CSetStepsAtLeast_003Ec__AnonStoreyF.callback(false);
			}
			else
			{
				GameServices().AchievementManager().SetStepsAtLeast(_003CSetStepsAtLeast_003Ec__AnonStoreyF.achId, Convert.ToUInt32(steps));
				GameServices().AchievementManager().Fetch(_003CSetStepsAtLeast_003Ec__AnonStoreyF.achId, _003CSetStepsAtLeast_003Ec__AnonStoreyF._003C_003Em__0);
			}
		}

		public void ShowAchievementsUI(Action<UIStatus> cb)
		{
			_003CShowAchievementsUI_003Ec__AnonStorey10 _003CShowAchievementsUI_003Ec__AnonStorey = new _003CShowAchievementsUI_003Ec__AnonStorey10();
			_003CShowAchievementsUI_003Ec__AnonStorey.cb = cb;
			if (IsAuthenticated())
			{
				Action<CommonErrorStatus.UIStatus> callback = Callbacks.NoopUICallback;
				if (_003CShowAchievementsUI_003Ec__AnonStorey.cb != null)
				{
					callback = _003CShowAchievementsUI_003Ec__AnonStorey._003C_003Em__0;
				}
				callback = AsOnGameThreadCallback(callback);
				GameServices().AchievementManager().ShowAllUI(callback);
			}
		}

		public int LeaderboardMaxResults()
		{
			return GameServices().LeaderboardManager().LeaderboardMaxResults;
		}

		public void ShowLeaderboardUI(string leaderboardId, LeaderboardTimeSpan span, Action<UIStatus> cb)
		{
			_003CShowLeaderboardUI_003Ec__AnonStorey11 _003CShowLeaderboardUI_003Ec__AnonStorey = new _003CShowLeaderboardUI_003Ec__AnonStorey11();
			_003CShowLeaderboardUI_003Ec__AnonStorey.cb = cb;
			if (IsAuthenticated())
			{
				Action<CommonErrorStatus.UIStatus> callback = Callbacks.NoopUICallback;
				if (_003CShowLeaderboardUI_003Ec__AnonStorey.cb != null)
				{
					callback = _003CShowLeaderboardUI_003Ec__AnonStorey._003C_003Em__0;
				}
				callback = AsOnGameThreadCallback(callback);
				if (leaderboardId == null)
				{
					GameServices().LeaderboardManager().ShowAllUI(callback);
				}
				else
				{
					GameServices().LeaderboardManager().ShowUI(leaderboardId, span, callback);
				}
			}
		}

		public void LoadScores(string leaderboardId, LeaderboardStart start, int rowCount, LeaderboardCollection collection, LeaderboardTimeSpan timeSpan, Action<LeaderboardScoreData> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			GameServices().LeaderboardManager().LoadLeaderboardData(leaderboardId, start, rowCount, collection, timeSpan, mUser.id, callback);
		}

		public void LoadMoreScores(ScorePageToken token, int rowCount, Action<LeaderboardScoreData> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			GameServices().LeaderboardManager().LoadScorePage(null, rowCount, token, callback);
		}

		public void SubmitScore(string leaderboardId, long score, Action<bool> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			if (!IsAuthenticated())
			{
				callback(false);
			}
			InitializeGameServices();
			if (leaderboardId == null)
			{
				throw new ArgumentNullException("leaderboardId");
			}
			GameServices().LeaderboardManager().SubmitScore(leaderboardId, score, null);
			callback(true);
		}

		public void SubmitScore(string leaderboardId, long score, string metadata, Action<bool> callback)
		{
			callback = AsOnGameThreadCallback(callback);
			if (!IsAuthenticated())
			{
				callback(false);
			}
			InitializeGameServices();
			if (leaderboardId == null)
			{
				throw new ArgumentNullException("leaderboardId");
			}
			GameServices().LeaderboardManager().SubmitScore(leaderboardId, score, metadata);
			callback(true);
		}

		public IRealTimeMultiplayerClient GetRtmpClient()
		{
			if (!IsAuthenticated())
			{
				return null;
			}
			lock (GameServicesLock)
			{
				return mRealTimeClient;
			}
		}

		public ITurnBasedMultiplayerClient GetTbmpClient()
		{
			lock (GameServicesLock)
			{
				return mTurnBasedClient;
			}
		}

		public ISavedGameClient GetSavedGameClient()
		{
			lock (GameServicesLock)
			{
				return mSavedGameClient;
			}
		}

		public IEventsClient GetEventsClient()
		{
			lock (GameServicesLock)
			{
				return mEventsClient;
			}
		}

		public IQuestsClient GetQuestsClient()
		{
			lock (GameServicesLock)
			{
				return mQuestsClient;
			}
		}

		public IVideoClient GetVideoClient()
		{
			lock (GameServicesLock)
			{
				return mVideoClient;
			}
		}

		public void RegisterInvitationDelegate(InvitationReceivedDelegate invitationDelegate)
		{
			_003CRegisterInvitationDelegate_003Ec__AnonStorey12 _003CRegisterInvitationDelegate_003Ec__AnonStorey = new _003CRegisterInvitationDelegate_003Ec__AnonStorey12();
			_003CRegisterInvitationDelegate_003Ec__AnonStorey.invitationDelegate = invitationDelegate;
			if (_003CRegisterInvitationDelegate_003Ec__AnonStorey.invitationDelegate == null)
			{
				mInvitationDelegate = null;
			}
			else
			{
				mInvitationDelegate = Callbacks.AsOnGameThreadCallback<Invitation, bool>(_003CRegisterInvitationDelegate_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public IntPtr GetApiClient()
		{
			return InternalHooks.InternalHooks_GetApiClient(mServices.AsHandle());
		}

		[CompilerGenerated]
		private void _003CAuthenticate_003Em__0(int result)
		{
			InitializeGameServices();
			if (result == 0)
			{
				GameServices().StartAuthorizationUI();
			}
			else
			{
				HandleAuthTransition(GooglePlayGames.Native.Cwrapper.Types.AuthOperation.SIGN_IN, (CommonErrorStatus.AuthStatus)result);
			}
		}

		[CompilerGenerated]
		private static void _003CAsOnGameThreadCallback_00601_003Em__1<T>(T P_0)
		{
		}

		[CompilerGenerated]
		private void _003CInitializeGameServices_003Em__2(GooglePlayGames.Native.Cwrapper.Types.MultiplayerEvent eventType, string matchId, NativeTurnBasedMatch match)
		{
			mTurnBasedClient.HandleMatchEvent(eventType, matchId, match);
		}

		[CompilerGenerated]
		private void _003CGetFriends_003Em__3(bool ok)
		{
			GooglePlayGames.OurUtils.Logger.d("loading: " + ok + " mFriends = " + mFriends);
			if (!ok)
			{
				GooglePlayGames.OurUtils.Logger.e("Friends list did not load successfully.  Disabling loading until re-authenticated");
			}
			friendsLoading = !ok;
		}

		[CompilerGenerated]
		private static bool _003CUnlockAchievement_003Em__4(GooglePlayGames.BasicApi.Achievement a)
		{
			return a.IsUnlocked;
		}

		[CompilerGenerated]
		private static bool _003CRevealAchievement_003Em__5(GooglePlayGames.BasicApi.Achievement a)
		{
			return a.IsRevealed;
		}
	}
}
