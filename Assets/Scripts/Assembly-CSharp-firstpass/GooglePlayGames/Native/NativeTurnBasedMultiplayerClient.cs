using System;
using System.Collections;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	public class NativeTurnBasedMultiplayerClient : ITurnBasedMultiplayerClient
	{
		[CompilerGenerated]
		private sealed class _003CCreateQuickMatch_003Ec__AnonStorey1
		{
			internal Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback;

			internal void _003C_003Em__0(UIStatus status, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match)
			{
				callback(status == UIStatus.Valid, match);
			}
		}

		[CompilerGenerated]
		private sealed class _003CCreateWithInvitationScreen_003Ec__AnonStorey2
		{
			internal Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback;

			internal void _003C_003Em__0(UIStatus status, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match)
			{
				callback(status == UIStatus.Valid, match);
			}
		}

		[CompilerGenerated]
		private sealed class _003CCreateWithInvitationScreen_003Ec__AnonStorey3
		{
			internal Action<UIStatus, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback;

			internal uint variant;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(PlayerSelectUIResponse result)
			{
				if (result.Status() != CommonErrorStatus.UIStatus.VALID)
				{
					callback((UIStatus)result.Status(), null);
					return;
				}
				using (GooglePlayGames.Native.PInvoke.TurnBasedMatchConfigBuilder turnBasedMatchConfigBuilder = GooglePlayGames.Native.PInvoke.TurnBasedMatchConfigBuilder.Create())
				{
					turnBasedMatchConfigBuilder.PopulateFromUIResponse(result).SetVariant(variant);
					using (GooglePlayGames.Native.PInvoke.TurnBasedMatchConfig config = turnBasedMatchConfigBuilder.Build())
					{
						_0024this.mTurnBasedManager.CreateMatch(config, _0024this.BridgeMatchToUserCallback(callback));
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAllInvitations_003Ec__AnonStorey4
		{
			internal Action<Invitation[]> callback;

			internal void _003C_003Em__0(TurnBasedManager.TurnBasedMatchesResponse allMatches)
			{
				Invitation[] array = new Invitation[allMatches.InvitationCount()];
				int num = 0;
				foreach (GooglePlayGames.Native.PInvoke.MultiplayerInvitation item in allMatches.Invitations())
				{
					array[num++] = item.AsInvitation();
				}
				callback(array);
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetAllMatches_003Ec__AnonStorey5
		{
			internal Action<GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch[]> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(TurnBasedManager.TurnBasedMatchesResponse allMatches)
			{
				int num = allMatches.MyTurnMatchesCount() + allMatches.TheirTurnMatchesCount() + allMatches.CompletedMatchesCount();
				GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch[] array = new GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch[num];
				int num2 = 0;
				foreach (NativeTurnBasedMatch item in allMatches.MyTurnMatches())
				{
					array[num2++] = item.AsTurnBasedMatch(_0024this.mNativeClient.GetUserId());
				}
				foreach (NativeTurnBasedMatch item2 in allMatches.TheirTurnMatches())
				{
					array[num2++] = item2.AsTurnBasedMatch(_0024this.mNativeClient.GetUserId());
				}
				foreach (NativeTurnBasedMatch item3 in allMatches.CompletedMatches())
				{
					array[num2++] = item3.AsTurnBasedMatch(_0024this.mNativeClient.GetUserId());
				}
				callback(array);
			}
		}

		[CompilerGenerated]
		private sealed class _003CBridgeMatchToUserCallback_003Ec__AnonStorey6
		{
			internal Action<UIStatus, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> userCallback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(TurnBasedManager.TurnBasedMatchResponse callbackResult)
			{
				using (NativeTurnBasedMatch nativeTurnBasedMatch = callbackResult.Match())
				{
					if (nativeTurnBasedMatch == null)
					{
						UIStatus arg = UIStatus.InternalError;
						switch (callbackResult.ResponseStatus())
						{
						case CommonErrorStatus.MultiplayerStatus.VALID:
							arg = UIStatus.Valid;
							break;
						case CommonErrorStatus.MultiplayerStatus.VALID_BUT_STALE:
							arg = UIStatus.Valid;
							break;
						case CommonErrorStatus.MultiplayerStatus.ERROR_INTERNAL:
							arg = UIStatus.InternalError;
							break;
						case CommonErrorStatus.MultiplayerStatus.ERROR_NOT_AUTHORIZED:
							arg = UIStatus.NotAuthorized;
							break;
						case CommonErrorStatus.MultiplayerStatus.ERROR_VERSION_UPDATE_REQUIRED:
							arg = UIStatus.VersionUpdateRequired;
							break;
						case CommonErrorStatus.MultiplayerStatus.ERROR_TIMEOUT:
							arg = UIStatus.Timeout;
							break;
						}
						userCallback(arg, null);
					}
					else
					{
						GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch turnBasedMatch = nativeTurnBasedMatch.AsTurnBasedMatch(_0024this.mNativeClient.GetUserId());
						Logger.d("Passing converted match to user callback:" + turnBasedMatch);
						userCallback(UIStatus.Valid, turnBasedMatch);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CAcceptFromInbox_003Ec__AnonStorey7
		{
			internal Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(TurnBasedManager.MatchInboxUIResponse callbackResult)
			{
				using (NativeTurnBasedMatch nativeTurnBasedMatch = callbackResult.Match())
				{
					if (nativeTurnBasedMatch == null)
					{
						callback(false, null);
						return;
					}
					GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch turnBasedMatch = nativeTurnBasedMatch.AsTurnBasedMatch(_0024this.mNativeClient.GetUserId());
					Logger.d("Passing converted match to user callback:" + turnBasedMatch);
					callback(true, turnBasedMatch);
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CAcceptInvitation_003Ec__AnonStorey8
		{
			internal string invitationId;

			internal Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.MultiplayerInvitation invitation)
			{
				if (invitation == null)
				{
					Logger.e("Could not find invitation with id " + invitationId);
					callback(false, null);
				}
				else
				{
					_0024this.mTurnBasedManager.AcceptInvitation(invitation, _0024this.BridgeMatchToUserCallback(_003C_003Em__1));
				}
			}

			internal void _003C_003Em__1(UIStatus status, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match)
			{
				callback(status == UIStatus.Valid, match);
			}
		}

		[CompilerGenerated]
		private sealed class _003CFindInvitationWithId_003Ec__AnonStorey9
		{
			internal Action<GooglePlayGames.Native.PInvoke.MultiplayerInvitation> callback;

			internal string invitationId;

			internal void _003C_003Em__0(TurnBasedManager.TurnBasedMatchesResponse allMatches)
			{
				if (allMatches.Status() <= (CommonErrorStatus.MultiplayerStatus)0)
				{
					callback(null);
					return;
				}
				foreach (GooglePlayGames.Native.PInvoke.MultiplayerInvitation item in allMatches.Invitations())
				{
					using (item)
					{
						if (item.Id().Equals(invitationId))
						{
							callback(item);
							return;
						}
					}
				}
				callback(null);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRegisterMatchDelegate_003Ec__AnonStoreyA
		{
			internal MatchDelegate del;

			internal void _003C_003Em__0(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, bool autoLaunch)
			{
				del(match, autoLaunch);
			}
		}

		[CompilerGenerated]
		private sealed class _003CHandleMatchEvent_003Ec__AnonStoreyB
		{
			internal Action<GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch, bool> currentDelegate;

			internal NativeTurnBasedMatch match;

			internal bool shouldAutolaunch;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0()
			{
				currentDelegate(match.AsTurnBasedMatch(_0024this.mNativeClient.GetUserId()), shouldAutolaunch);
				match.ForgetMe();
			}
		}

		[CompilerGenerated]
		private sealed class _003CTakeTurn_003Ec__AnonStoreyC
		{
			internal byte[] data;

			internal Action<bool> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.MultiplayerParticipant pendingParticipant, NativeTurnBasedMatch foundMatch)
			{
				_0024this.mTurnBasedManager.TakeTurn(foundMatch, data, pendingParticipant, _003C_003Em__1);
			}

			internal void _003C_003Em__1(TurnBasedManager.TurnBasedMatchResponse result)
			{
				if (result.RequestSucceeded())
				{
					callback(true);
					return;
				}
				Logger.d("Taking turn failed: " + result.ResponseStatus());
				callback(false);
			}
		}

		[CompilerGenerated]
		private sealed class _003CFindEqualVersionMatch_003Ec__AnonStoreyD
		{
			internal GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match;

			internal Action<bool> onFailure;

			internal Action<NativeTurnBasedMatch> onVersionMatch;

			internal void _003C_003Em__0(TurnBasedManager.TurnBasedMatchResponse response)
			{
				using (NativeTurnBasedMatch nativeTurnBasedMatch = response.Match())
				{
					if (nativeTurnBasedMatch == null)
					{
						Logger.e(string.Format("Could not find match {0}", match.MatchId));
						onFailure(false);
					}
					else if (nativeTurnBasedMatch.Version() != match.Version)
					{
						Logger.e(string.Format("Attempted to update a stale version of the match. Expected version was {0} but current version is {1}.", match.Version, nativeTurnBasedMatch.Version()));
						onFailure(false);
					}
					else
					{
						onVersionMatch(nativeTurnBasedMatch);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE
		{
			internal string participantId;

			internal Action<GooglePlayGames.Native.PInvoke.MultiplayerParticipant, NativeTurnBasedMatch> onFoundParticipantAndMatch;

			internal GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match;

			internal Action<bool> onFailure;

			internal void _003C_003Em__0(NativeTurnBasedMatch foundMatch)
			{
				if (participantId == null)
				{
					using (GooglePlayGames.Native.PInvoke.MultiplayerParticipant arg = GooglePlayGames.Native.PInvoke.MultiplayerParticipant.AutomatchingSentinel())
					{
						onFoundParticipantAndMatch(arg, foundMatch);
						return;
					}
				}
				using (GooglePlayGames.Native.PInvoke.MultiplayerParticipant multiplayerParticipant = foundMatch.ParticipantWithId(participantId))
				{
					if (multiplayerParticipant == null)
					{
						Logger.e(string.Format("Located match {0} but desired participant with ID {1} could not be found", match.MatchId, participantId));
						onFailure(false);
					}
					else
					{
						onFoundParticipantAndMatch(multiplayerParticipant, foundMatch);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CFinish_003Ec__AnonStoreyF
		{
			internal MatchOutcome outcome;

			internal Action<bool> callback;

			internal byte[] data;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(NativeTurnBasedMatch foundMatch)
			{
				GooglePlayGames.Native.PInvoke.ParticipantResults participantResults = foundMatch.Results();
				foreach (string participantId in outcome.ParticipantIds)
				{
					Types.MatchResult matchResult = ResultToMatchResult(outcome.GetResultFor(participantId));
					uint placementFor = outcome.GetPlacementFor(participantId);
					if (participantResults.HasResultsForParticipant(participantId))
					{
						Types.MatchResult matchResult2 = participantResults.ResultsForParticipant(participantId);
						uint num = participantResults.PlacingForParticipant(participantId);
						if (matchResult != matchResult2 || placementFor != num)
						{
							Logger.e(string.Format("Attempted to override existing results for participant {0}: Placing {1}, Result {2}", participantId, num, matchResult2));
							callback(false);
							return;
						}
					}
					else
					{
						GooglePlayGames.Native.PInvoke.ParticipantResults participantResults2 = participantResults;
						participantResults = participantResults2.WithResult(participantId, placementFor, matchResult);
						participantResults2.Dispose();
					}
				}
				_0024this.mTurnBasedManager.FinishMatchDuringMyTurn(foundMatch, data, participantResults, _003C_003Em__1);
			}

			internal void _003C_003Em__1(TurnBasedManager.TurnBasedMatchResponse response)
			{
				callback(response.RequestSucceeded());
			}
		}

		[CompilerGenerated]
		private sealed class _003CAcknowledgeFinished_003Ec__AnonStorey10
		{
			internal Action<bool> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(NativeTurnBasedMatch foundMatch)
			{
				_0024this.mTurnBasedManager.ConfirmPendingCompletion(foundMatch, _003C_003Em__1);
			}

			internal void _003C_003Em__1(TurnBasedManager.TurnBasedMatchResponse response)
			{
				callback(response.RequestSucceeded());
			}
		}

		[CompilerGenerated]
		private sealed class _003CLeave_003Ec__AnonStorey11
		{
			internal Action<bool> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(NativeTurnBasedMatch foundMatch)
			{
				_0024this.mTurnBasedManager.LeaveMatchDuringTheirTurn(foundMatch, _003C_003Em__1);
			}

			internal void _003C_003Em__1(CommonErrorStatus.MultiplayerStatus status)
			{
				callback(status > (CommonErrorStatus.MultiplayerStatus)0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLeaveDuringTurn_003Ec__AnonStorey12
		{
			internal Action<bool> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.MultiplayerParticipant pendingParticipant, NativeTurnBasedMatch foundMatch)
			{
				_0024this.mTurnBasedManager.LeaveDuringMyTurn(foundMatch, pendingParticipant, _003C_003Em__1);
			}

			internal void _003C_003Em__1(CommonErrorStatus.MultiplayerStatus status)
			{
				callback(status > (CommonErrorStatus.MultiplayerStatus)0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CCancel_003Ec__AnonStorey13
		{
			internal Action<bool> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(NativeTurnBasedMatch foundMatch)
			{
				_0024this.mTurnBasedManager.CancelMatch(foundMatch, _003C_003Em__1);
			}

			internal void _003C_003Em__1(CommonErrorStatus.MultiplayerStatus status)
			{
				callback(status > (CommonErrorStatus.MultiplayerStatus)0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRematch_003Ec__AnonStorey14
		{
			internal Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback;

			internal NativeTurnBasedMultiplayerClient _0024this;

			internal void _003C_003Em__0(bool failed)
			{
				callback(false, null);
			}

			internal void _003C_003Em__1(NativeTurnBasedMatch foundMatch)
			{
				_0024this.mTurnBasedManager.Rematch(foundMatch, _0024this.BridgeMatchToUserCallback(_003C_003Em__2));
			}

			internal void _003C_003Em__2(UIStatus status, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch m)
			{
				callback(status == UIStatus.Valid, m);
			}
		}

		private readonly TurnBasedManager mTurnBasedManager;

		private readonly NativeClient mNativeClient;

		private volatile Action<GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch, bool> mMatchDelegate;

		internal NativeTurnBasedMultiplayerClient(NativeClient nativeClient, TurnBasedManager manager)
		{
			mTurnBasedManager = manager;
			mNativeClient = nativeClient;
		}

		public void CreateQuickMatch(uint minOpponents, uint maxOpponents, uint variant, Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			CreateQuickMatch(minOpponents, maxOpponents, variant, 0uL, callback);
		}

		public void CreateQuickMatch(uint minOpponents, uint maxOpponents, uint variant, ulong exclusiveBitmask, Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			_003CCreateQuickMatch_003Ec__AnonStorey1 _003CCreateQuickMatch_003Ec__AnonStorey = new _003CCreateQuickMatch_003Ec__AnonStorey1();
			_003CCreateQuickMatch_003Ec__AnonStorey.callback = callback;
			_003CCreateQuickMatch_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CCreateQuickMatch_003Ec__AnonStorey.callback);
			using (GooglePlayGames.Native.PInvoke.TurnBasedMatchConfigBuilder turnBasedMatchConfigBuilder = GooglePlayGames.Native.PInvoke.TurnBasedMatchConfigBuilder.Create())
			{
				turnBasedMatchConfigBuilder.SetVariant(variant).SetMinimumAutomatchingPlayers(minOpponents).SetMaximumAutomatchingPlayers(maxOpponents)
					.SetExclusiveBitMask(exclusiveBitmask);
				using (GooglePlayGames.Native.PInvoke.TurnBasedMatchConfig config = turnBasedMatchConfigBuilder.Build())
				{
					mTurnBasedManager.CreateMatch(config, BridgeMatchToUserCallback(_003CCreateQuickMatch_003Ec__AnonStorey._003C_003Em__0));
				}
			}
		}

		public void CreateWithInvitationScreen(uint minOpponents, uint maxOpponents, uint variant, Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			_003CCreateWithInvitationScreen_003Ec__AnonStorey2 _003CCreateWithInvitationScreen_003Ec__AnonStorey = new _003CCreateWithInvitationScreen_003Ec__AnonStorey2();
			_003CCreateWithInvitationScreen_003Ec__AnonStorey.callback = callback;
			CreateWithInvitationScreen(minOpponents, maxOpponents, variant, _003CCreateWithInvitationScreen_003Ec__AnonStorey._003C_003Em__0);
		}

		public void CreateWithInvitationScreen(uint minOpponents, uint maxOpponents, uint variant, Action<UIStatus, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			_003CCreateWithInvitationScreen_003Ec__AnonStorey3 _003CCreateWithInvitationScreen_003Ec__AnonStorey = new _003CCreateWithInvitationScreen_003Ec__AnonStorey3();
			_003CCreateWithInvitationScreen_003Ec__AnonStorey.callback = callback;
			_003CCreateWithInvitationScreen_003Ec__AnonStorey.variant = variant;
			_003CCreateWithInvitationScreen_003Ec__AnonStorey._0024this = this;
			_003CCreateWithInvitationScreen_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CCreateWithInvitationScreen_003Ec__AnonStorey.callback);
			mTurnBasedManager.ShowPlayerSelectUI(minOpponents, maxOpponents, true, _003CCreateWithInvitationScreen_003Ec__AnonStorey._003C_003Em__0);
		}

		public void GetAllInvitations(Action<Invitation[]> callback)
		{
			_003CGetAllInvitations_003Ec__AnonStorey4 _003CGetAllInvitations_003Ec__AnonStorey = new _003CGetAllInvitations_003Ec__AnonStorey4();
			_003CGetAllInvitations_003Ec__AnonStorey.callback = callback;
			mTurnBasedManager.GetAllTurnbasedMatches(_003CGetAllInvitations_003Ec__AnonStorey._003C_003Em__0);
		}

		public void GetAllMatches(Action<GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch[]> callback)
		{
			_003CGetAllMatches_003Ec__AnonStorey5 _003CGetAllMatches_003Ec__AnonStorey = new _003CGetAllMatches_003Ec__AnonStorey5();
			_003CGetAllMatches_003Ec__AnonStorey.callback = callback;
			_003CGetAllMatches_003Ec__AnonStorey._0024this = this;
			mTurnBasedManager.GetAllTurnbasedMatches(_003CGetAllMatches_003Ec__AnonStorey._003C_003Em__0);
		}

		private Action<TurnBasedManager.TurnBasedMatchResponse> BridgeMatchToUserCallback(Action<UIStatus, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> userCallback)
		{
			_003CBridgeMatchToUserCallback_003Ec__AnonStorey6 _003CBridgeMatchToUserCallback_003Ec__AnonStorey = new _003CBridgeMatchToUserCallback_003Ec__AnonStorey6();
			_003CBridgeMatchToUserCallback_003Ec__AnonStorey.userCallback = userCallback;
			_003CBridgeMatchToUserCallback_003Ec__AnonStorey._0024this = this;
			return _003CBridgeMatchToUserCallback_003Ec__AnonStorey._003C_003Em__0;
		}

		public void AcceptFromInbox(Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			_003CAcceptFromInbox_003Ec__AnonStorey7 _003CAcceptFromInbox_003Ec__AnonStorey = new _003CAcceptFromInbox_003Ec__AnonStorey7();
			_003CAcceptFromInbox_003Ec__AnonStorey.callback = callback;
			_003CAcceptFromInbox_003Ec__AnonStorey._0024this = this;
			_003CAcceptFromInbox_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CAcceptFromInbox_003Ec__AnonStorey.callback);
			mTurnBasedManager.ShowInboxUI(_003CAcceptFromInbox_003Ec__AnonStorey._003C_003Em__0);
		}

		public void AcceptInvitation(string invitationId, Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			_003CAcceptInvitation_003Ec__AnonStorey8 _003CAcceptInvitation_003Ec__AnonStorey = new _003CAcceptInvitation_003Ec__AnonStorey8();
			_003CAcceptInvitation_003Ec__AnonStorey.invitationId = invitationId;
			_003CAcceptInvitation_003Ec__AnonStorey.callback = callback;
			_003CAcceptInvitation_003Ec__AnonStorey._0024this = this;
			_003CAcceptInvitation_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CAcceptInvitation_003Ec__AnonStorey.callback);
			FindInvitationWithId(_003CAcceptInvitation_003Ec__AnonStorey.invitationId, _003CAcceptInvitation_003Ec__AnonStorey._003C_003Em__0);
		}

		private void FindInvitationWithId(string invitationId, Action<GooglePlayGames.Native.PInvoke.MultiplayerInvitation> callback)
		{
			_003CFindInvitationWithId_003Ec__AnonStorey9 _003CFindInvitationWithId_003Ec__AnonStorey = new _003CFindInvitationWithId_003Ec__AnonStorey9();
			_003CFindInvitationWithId_003Ec__AnonStorey.callback = callback;
			_003CFindInvitationWithId_003Ec__AnonStorey.invitationId = invitationId;
			mTurnBasedManager.GetAllTurnbasedMatches(_003CFindInvitationWithId_003Ec__AnonStorey._003C_003Em__0);
		}

		public void RegisterMatchDelegate(MatchDelegate del)
		{
			_003CRegisterMatchDelegate_003Ec__AnonStoreyA _003CRegisterMatchDelegate_003Ec__AnonStoreyA = new _003CRegisterMatchDelegate_003Ec__AnonStoreyA();
			_003CRegisterMatchDelegate_003Ec__AnonStoreyA.del = del;
			if (_003CRegisterMatchDelegate_003Ec__AnonStoreyA.del == null)
			{
				mMatchDelegate = null;
			}
			else
			{
				mMatchDelegate = Callbacks.AsOnGameThreadCallback<GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch, bool>(_003CRegisterMatchDelegate_003Ec__AnonStoreyA._003C_003Em__0);
			}
		}

		internal void HandleMatchEvent(Types.MultiplayerEvent eventType, string matchId, NativeTurnBasedMatch match)
		{
			_003CHandleMatchEvent_003Ec__AnonStoreyB _003CHandleMatchEvent_003Ec__AnonStoreyB = new _003CHandleMatchEvent_003Ec__AnonStoreyB();
			_003CHandleMatchEvent_003Ec__AnonStoreyB.match = match;
			_003CHandleMatchEvent_003Ec__AnonStoreyB._0024this = this;
			_003CHandleMatchEvent_003Ec__AnonStoreyB.currentDelegate = mMatchDelegate;
			if (_003CHandleMatchEvent_003Ec__AnonStoreyB.currentDelegate != null)
			{
				if (eventType == Types.MultiplayerEvent.REMOVED)
				{
					Logger.d("Ignoring REMOVE event for match " + matchId);
					return;
				}
				_003CHandleMatchEvent_003Ec__AnonStoreyB.shouldAutolaunch = eventType == Types.MultiplayerEvent.UPDATED_FROM_APP_LAUNCH;
				_003CHandleMatchEvent_003Ec__AnonStoreyB.match.ReferToMe();
				Callbacks.AsCoroutine(WaitForLogin(_003CHandleMatchEvent_003Ec__AnonStoreyB._003C_003Em__0));
			}
		}

		private IEnumerator WaitForLogin(Action method)
		{
			if (string.IsNullOrEmpty(mNativeClient.GetUserId()))
			{
				yield return null;
			}
			method();
		}

		public void TakeTurn(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, byte[] data, string pendingParticipantId, Action<bool> callback)
		{
			_003CTakeTurn_003Ec__AnonStoreyC _003CTakeTurn_003Ec__AnonStoreyC = new _003CTakeTurn_003Ec__AnonStoreyC();
			_003CTakeTurn_003Ec__AnonStoreyC.data = data;
			_003CTakeTurn_003Ec__AnonStoreyC.callback = callback;
			_003CTakeTurn_003Ec__AnonStoreyC._0024this = this;
			Logger.describe(_003CTakeTurn_003Ec__AnonStoreyC.data);
			_003CTakeTurn_003Ec__AnonStoreyC.callback = Callbacks.AsOnGameThreadCallback(_003CTakeTurn_003Ec__AnonStoreyC.callback);
			FindEqualVersionMatchWithParticipant(match, pendingParticipantId, _003CTakeTurn_003Ec__AnonStoreyC.callback, _003CTakeTurn_003Ec__AnonStoreyC._003C_003Em__0);
		}

		private void FindEqualVersionMatch(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, Action<bool> onFailure, Action<NativeTurnBasedMatch> onVersionMatch)
		{
			_003CFindEqualVersionMatch_003Ec__AnonStoreyD _003CFindEqualVersionMatch_003Ec__AnonStoreyD = new _003CFindEqualVersionMatch_003Ec__AnonStoreyD();
			_003CFindEqualVersionMatch_003Ec__AnonStoreyD.match = match;
			_003CFindEqualVersionMatch_003Ec__AnonStoreyD.onFailure = onFailure;
			_003CFindEqualVersionMatch_003Ec__AnonStoreyD.onVersionMatch = onVersionMatch;
			mTurnBasedManager.GetMatch(_003CFindEqualVersionMatch_003Ec__AnonStoreyD.match.MatchId, _003CFindEqualVersionMatch_003Ec__AnonStoreyD._003C_003Em__0);
		}

		private void FindEqualVersionMatchWithParticipant(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, string participantId, Action<bool> onFailure, Action<GooglePlayGames.Native.PInvoke.MultiplayerParticipant, NativeTurnBasedMatch> onFoundParticipantAndMatch)
		{
			_003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE _003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE = new _003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE();
			_003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE.participantId = participantId;
			_003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE.onFoundParticipantAndMatch = onFoundParticipantAndMatch;
			_003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE.match = match;
			_003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE.onFailure = onFailure;
			FindEqualVersionMatch(_003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE.match, _003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE.onFailure, _003CFindEqualVersionMatchWithParticipant_003Ec__AnonStoreyE._003C_003Em__0);
		}

		public int GetMaxMatchDataSize()
		{
			throw new NotImplementedException();
		}

		public void Finish(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, byte[] data, MatchOutcome outcome, Action<bool> callback)
		{
			_003CFinish_003Ec__AnonStoreyF _003CFinish_003Ec__AnonStoreyF = new _003CFinish_003Ec__AnonStoreyF();
			_003CFinish_003Ec__AnonStoreyF.outcome = outcome;
			_003CFinish_003Ec__AnonStoreyF.callback = callback;
			_003CFinish_003Ec__AnonStoreyF.data = data;
			_003CFinish_003Ec__AnonStoreyF._0024this = this;
			_003CFinish_003Ec__AnonStoreyF.callback = Callbacks.AsOnGameThreadCallback(_003CFinish_003Ec__AnonStoreyF.callback);
			FindEqualVersionMatch(match, _003CFinish_003Ec__AnonStoreyF.callback, _003CFinish_003Ec__AnonStoreyF._003C_003Em__0);
		}

		private static Types.MatchResult ResultToMatchResult(MatchOutcome.ParticipantResult result)
		{
			switch (result)
			{
			case MatchOutcome.ParticipantResult.Loss:
				return Types.MatchResult.LOSS;
			case MatchOutcome.ParticipantResult.None:
				return Types.MatchResult.NONE;
			case MatchOutcome.ParticipantResult.Tie:
				return Types.MatchResult.TIE;
			case MatchOutcome.ParticipantResult.Win:
				return Types.MatchResult.WIN;
			default:
				Logger.e("Received unknown ParticipantResult " + result);
				return Types.MatchResult.NONE;
			}
		}

		public void AcknowledgeFinished(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, Action<bool> callback)
		{
			_003CAcknowledgeFinished_003Ec__AnonStorey10 _003CAcknowledgeFinished_003Ec__AnonStorey = new _003CAcknowledgeFinished_003Ec__AnonStorey10();
			_003CAcknowledgeFinished_003Ec__AnonStorey.callback = callback;
			_003CAcknowledgeFinished_003Ec__AnonStorey._0024this = this;
			_003CAcknowledgeFinished_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CAcknowledgeFinished_003Ec__AnonStorey.callback);
			FindEqualVersionMatch(match, _003CAcknowledgeFinished_003Ec__AnonStorey.callback, _003CAcknowledgeFinished_003Ec__AnonStorey._003C_003Em__0);
		}

		public void Leave(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, Action<bool> callback)
		{
			_003CLeave_003Ec__AnonStorey11 _003CLeave_003Ec__AnonStorey = new _003CLeave_003Ec__AnonStorey11();
			_003CLeave_003Ec__AnonStorey.callback = callback;
			_003CLeave_003Ec__AnonStorey._0024this = this;
			_003CLeave_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CLeave_003Ec__AnonStorey.callback);
			FindEqualVersionMatch(match, _003CLeave_003Ec__AnonStorey.callback, _003CLeave_003Ec__AnonStorey._003C_003Em__0);
		}

		public void LeaveDuringTurn(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, string pendingParticipantId, Action<bool> callback)
		{
			_003CLeaveDuringTurn_003Ec__AnonStorey12 _003CLeaveDuringTurn_003Ec__AnonStorey = new _003CLeaveDuringTurn_003Ec__AnonStorey12();
			_003CLeaveDuringTurn_003Ec__AnonStorey.callback = callback;
			_003CLeaveDuringTurn_003Ec__AnonStorey._0024this = this;
			_003CLeaveDuringTurn_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CLeaveDuringTurn_003Ec__AnonStorey.callback);
			FindEqualVersionMatchWithParticipant(match, pendingParticipantId, _003CLeaveDuringTurn_003Ec__AnonStorey.callback, _003CLeaveDuringTurn_003Ec__AnonStorey._003C_003Em__0);
		}

		public void Cancel(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, Action<bool> callback)
		{
			_003CCancel_003Ec__AnonStorey13 _003CCancel_003Ec__AnonStorey = new _003CCancel_003Ec__AnonStorey13();
			_003CCancel_003Ec__AnonStorey.callback = callback;
			_003CCancel_003Ec__AnonStorey._0024this = this;
			_003CCancel_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CCancel_003Ec__AnonStorey.callback);
			FindEqualVersionMatch(match, _003CCancel_003Ec__AnonStorey.callback, _003CCancel_003Ec__AnonStorey._003C_003Em__0);
		}

		public void Rematch(GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch match, Action<bool, GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch> callback)
		{
			_003CRematch_003Ec__AnonStorey14 _003CRematch_003Ec__AnonStorey = new _003CRematch_003Ec__AnonStorey14();
			_003CRematch_003Ec__AnonStorey.callback = callback;
			_003CRematch_003Ec__AnonStorey._0024this = this;
			_003CRematch_003Ec__AnonStorey.callback = Callbacks.AsOnGameThreadCallback(_003CRematch_003Ec__AnonStorey.callback);
			FindEqualVersionMatch(match, _003CRematch_003Ec__AnonStorey._003C_003Em__0, _003CRematch_003Ec__AnonStorey._003C_003Em__1);
		}

		public void DeclineInvitation(string invitationId)
		{
			FindInvitationWithId(invitationId, _003CDeclineInvitation_003Em__0);
		}

		[CompilerGenerated]
		private void _003CDeclineInvitation_003Em__0(GooglePlayGames.Native.PInvoke.MultiplayerInvitation invitation)
		{
			if (invitation != null)
			{
				mTurnBasedManager.DeclineInvitation(invitation);
			}
		}
	}
}
