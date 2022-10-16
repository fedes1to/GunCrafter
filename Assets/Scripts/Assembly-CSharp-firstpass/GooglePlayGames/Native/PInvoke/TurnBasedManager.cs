using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class TurnBasedManager
	{
		internal delegate void TurnBasedMatchCallback(TurnBasedMatchResponse response);

		internal class MatchInboxUIResponse : BaseReferenceHolder
		{
			internal MatchInboxUIResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.UIStatus UiStatus()
			{
				return TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_MatchInboxUIResponse_GetStatus(SelfPtr());
			}

			internal NativeTurnBasedMatch Match()
			{
				if (UiStatus() != CommonErrorStatus.UIStatus.VALID)
				{
					return null;
				}
				return new NativeTurnBasedMatch(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_MatchInboxUIResponse_GetMatch(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_MatchInboxUIResponse_Dispose(selfPointer);
			}

			internal static MatchInboxUIResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new MatchInboxUIResponse(pointer);
			}
		}

		internal class TurnBasedMatchResponse : BaseReferenceHolder
		{
			internal TurnBasedMatchResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.MultiplayerStatus ResponseStatus()
			{
				return TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchResponse_GetStatus(SelfPtr());
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.MultiplayerStatus)0;
			}

			internal NativeTurnBasedMatch Match()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				return new NativeTurnBasedMatch(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchResponse_GetMatch(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchResponse_Dispose(selfPointer);
			}

			internal static TurnBasedMatchResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new TurnBasedMatchResponse(pointer);
			}
		}

		internal class TurnBasedMatchesResponse : BaseReferenceHolder
		{
			internal TurnBasedMatchesResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_Dispose(SelfPtr());
			}

			internal CommonErrorStatus.MultiplayerStatus Status()
			{
				return TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetStatus(SelfPtr());
			}

			internal IEnumerable<MultiplayerInvitation> Invitations()
			{
				return PInvokeUtilities.ToEnumerable(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetInvitations_Length(SelfPtr()), _003CInvitations_003Em__0);
			}

			internal int InvitationCount()
			{
				return (int)TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetInvitations_Length(SelfPtr()).ToUInt32();
			}

			internal IEnumerable<NativeTurnBasedMatch> MyTurnMatches()
			{
				return PInvokeUtilities.ToEnumerable(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetMyTurnMatches_Length(SelfPtr()), _003CMyTurnMatches_003Em__1);
			}

			internal int MyTurnMatchesCount()
			{
				return (int)TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetMyTurnMatches_Length(SelfPtr()).ToUInt32();
			}

			internal IEnumerable<NativeTurnBasedMatch> TheirTurnMatches()
			{
				return PInvokeUtilities.ToEnumerable(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetTheirTurnMatches_Length(SelfPtr()), _003CTheirTurnMatches_003Em__2);
			}

			internal int TheirTurnMatchesCount()
			{
				return (int)TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetTheirTurnMatches_Length(SelfPtr()).ToUInt32();
			}

			internal IEnumerable<NativeTurnBasedMatch> CompletedMatches()
			{
				return PInvokeUtilities.ToEnumerable(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetCompletedMatches_Length(SelfPtr()), _003CCompletedMatches_003Em__3);
			}

			internal int CompletedMatchesCount()
			{
				return (int)TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetCompletedMatches_Length(SelfPtr()).ToUInt32();
			}

			internal static TurnBasedMatchesResponse FromPointer(IntPtr pointer)
			{
				if (PInvokeUtilities.IsNull(pointer))
				{
					return null;
				}
				return new TurnBasedMatchesResponse(pointer);
			}

			[CompilerGenerated]
			private MultiplayerInvitation _003CInvitations_003Em__0(UIntPtr index)
			{
				return new MultiplayerInvitation(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetInvitations_GetElement(SelfPtr(), index));
			}

			[CompilerGenerated]
			private NativeTurnBasedMatch _003CMyTurnMatches_003Em__1(UIntPtr index)
			{
				return new NativeTurnBasedMatch(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetMyTurnMatches_GetElement(SelfPtr(), index));
			}

			[CompilerGenerated]
			private NativeTurnBasedMatch _003CTheirTurnMatches_003Em__2(UIntPtr index)
			{
				return new NativeTurnBasedMatch(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetTheirTurnMatches_GetElement(SelfPtr(), index));
			}

			[CompilerGenerated]
			private NativeTurnBasedMatch _003CCompletedMatches_003Em__3(UIntPtr index)
			{
				return new NativeTurnBasedMatch(TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TurnBasedMatchesResponse_GetCompletedMatches_GetElement(SelfPtr(), index));
			}
		}

		private readonly GameServices mGameServices;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Func<IntPtr, PlayerSelectUIResponse> _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.PlayerSelectUICallback _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static Func<IntPtr, TurnBasedMatchesResponse> _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchesCallback _003C_003Ef__mg_0024cache5;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cache6;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cache7;

		[CompilerGenerated]
		private static Func<IntPtr, MatchInboxUIResponse> _003C_003Ef__mg_0024cache8;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.MatchInboxUICallback _003C_003Ef__mg_0024cache9;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.MultiplayerStatusCallback _003C_003Ef__mg_0024cacheA;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cacheB;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cacheC;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.MultiplayerStatusCallback _003C_003Ef__mg_0024cacheD;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.MultiplayerStatusCallback _003C_003Ef__mg_0024cacheE;

		[CompilerGenerated]
		private static TurnBasedMultiplayerManager.TurnBasedMatchCallback _003C_003Ef__mg_0024cacheF;

		[CompilerGenerated]
		private static Func<IntPtr, TurnBasedMatchResponse> _003C_003Ef__mg_0024cache10;

		internal TurnBasedManager(GameServices services)
		{
			mGameServices = services;
		}

		internal void GetMatch(string matchId, Action<TurnBasedMatchResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_FetchMatch(self, matchId, _003C_003Ef__mg_0024cache0, ToCallbackPointer(callback));
		}

		[MonoPInvokeCallback(typeof(TurnBasedMultiplayerManager.TurnBasedMatchCallback))]
		internal static void InternalTurnBasedMatchCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("TurnBasedManager#InternalTurnBasedMatchCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void CreateMatch(TurnBasedMatchConfig config, Action<TurnBasedMatchResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr config2 = config.AsPointer();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_CreateTurnBasedMatch(self, config2, _003C_003Ef__mg_0024cache1, ToCallbackPointer(callback));
		}

		internal void ShowPlayerSelectUI(uint minimumPlayers, uint maxiumPlayers, bool allowAutomatching, Action<PlayerSelectUIResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalPlayerSelectUIcallback;
			}
			TurnBasedMultiplayerManager.PlayerSelectUICallback callback2 = _003C_003Ef__mg_0024cache3;
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = PlayerSelectUIResponse.FromPointer;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_ShowPlayerSelectUI(self, minimumPlayers, maxiumPlayers, allowAutomatching, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache2));
		}

		[MonoPInvokeCallback(typeof(TurnBasedMultiplayerManager.PlayerSelectUICallback))]
		internal static void InternalPlayerSelectUIcallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("TurnBasedManager#PlayerSelectUICallback", Callbacks.Type.Temporary, response, data);
		}

		internal void GetAllTurnbasedMatches(Action<TurnBasedMatchesResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = InternalTurnBasedMatchesCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMatchesCallback callback2 = _003C_003Ef__mg_0024cache5;
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = TurnBasedMatchesResponse.FromPointer;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_FetchMatches(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache4));
		}

		[MonoPInvokeCallback(typeof(TurnBasedMultiplayerManager.TurnBasedMatchesCallback))]
		internal static void InternalTurnBasedMatchesCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("TurnBasedManager#TurnBasedMatchesCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void AcceptInvitation(MultiplayerInvitation invitation, Action<TurnBasedMatchResponse> callback)
		{
			Logger.d("Accepting invitation: " + invitation.AsPointer().ToInt64());
			HandleRef self = mGameServices.AsHandle();
			IntPtr invitation2 = invitation.AsPointer();
			if (_003C_003Ef__mg_0024cache6 == null)
			{
				_003C_003Ef__mg_0024cache6 = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_AcceptInvitation(self, invitation2, _003C_003Ef__mg_0024cache6, ToCallbackPointer(callback));
		}

		internal void DeclineInvitation(MultiplayerInvitation invitation)
		{
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_DeclineInvitation(mGameServices.AsHandle(), invitation.AsPointer());
		}

		internal void TakeTurn(NativeTurnBasedMatch match, byte[] data, MultiplayerParticipant nextParticipant, Action<TurnBasedMatchResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			UIntPtr match_data_size = new UIntPtr((uint)data.Length);
			IntPtr results = match.Results().AsPointer();
			IntPtr next_participant = nextParticipant.AsPointer();
			if (_003C_003Ef__mg_0024cache7 == null)
			{
				_003C_003Ef__mg_0024cache7 = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_TakeMyTurn(self, match2, data, match_data_size, results, next_participant, _003C_003Ef__mg_0024cache7, ToCallbackPointer(callback));
		}

		[MonoPInvokeCallback(typeof(TurnBasedMultiplayerManager.MatchInboxUICallback))]
		internal static void InternalMatchInboxUICallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("TurnBasedManager#MatchInboxUICallback", Callbacks.Type.Temporary, response, data);
		}

		internal void ShowInboxUI(Action<MatchInboxUIResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache9 == null)
			{
				_003C_003Ef__mg_0024cache9 = InternalMatchInboxUICallback;
			}
			TurnBasedMultiplayerManager.MatchInboxUICallback callback2 = _003C_003Ef__mg_0024cache9;
			if (_003C_003Ef__mg_0024cache8 == null)
			{
				_003C_003Ef__mg_0024cache8 = MatchInboxUIResponse.FromPointer;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_ShowMatchInboxUI(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache8));
		}

		[MonoPInvokeCallback(typeof(TurnBasedMultiplayerManager.MultiplayerStatusCallback))]
		internal static void InternalMultiplayerStatusCallback(CommonErrorStatus.MultiplayerStatus status, IntPtr data)
		{
			Logger.d("InternalMultiplayerStatusCallback: " + status);
			Action<CommonErrorStatus.MultiplayerStatus> action = Callbacks.IntPtrToTempCallback<Action<CommonErrorStatus.MultiplayerStatus>>(data);
			try
			{
				action(status);
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalMultiplayerStatusCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal void LeaveDuringMyTurn(NativeTurnBasedMatch match, MultiplayerParticipant nextParticipant, Action<CommonErrorStatus.MultiplayerStatus> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			IntPtr next_participant = nextParticipant.AsPointer();
			if (_003C_003Ef__mg_0024cacheA == null)
			{
				_003C_003Ef__mg_0024cacheA = InternalMultiplayerStatusCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_LeaveMatchDuringMyTurn(self, match2, next_participant, _003C_003Ef__mg_0024cacheA, Callbacks.ToIntPtr(callback));
		}

		internal void FinishMatchDuringMyTurn(NativeTurnBasedMatch match, byte[] data, ParticipantResults results, Action<TurnBasedMatchResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			UIntPtr match_data_size = new UIntPtr((uint)data.Length);
			IntPtr results2 = results.AsPointer();
			if (_003C_003Ef__mg_0024cacheB == null)
			{
				_003C_003Ef__mg_0024cacheB = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_FinishMatchDuringMyTurn(self, match2, data, match_data_size, results2, _003C_003Ef__mg_0024cacheB, ToCallbackPointer(callback));
		}

		internal void ConfirmPendingCompletion(NativeTurnBasedMatch match, Action<TurnBasedMatchResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			if (_003C_003Ef__mg_0024cacheC == null)
			{
				_003C_003Ef__mg_0024cacheC = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_ConfirmPendingCompletion(self, match2, _003C_003Ef__mg_0024cacheC, ToCallbackPointer(callback));
		}

		internal void LeaveMatchDuringTheirTurn(NativeTurnBasedMatch match, Action<CommonErrorStatus.MultiplayerStatus> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			if (_003C_003Ef__mg_0024cacheD == null)
			{
				_003C_003Ef__mg_0024cacheD = InternalMultiplayerStatusCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_LeaveMatchDuringTheirTurn(self, match2, _003C_003Ef__mg_0024cacheD, Callbacks.ToIntPtr(callback));
		}

		internal void CancelMatch(NativeTurnBasedMatch match, Action<CommonErrorStatus.MultiplayerStatus> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			if (_003C_003Ef__mg_0024cacheE == null)
			{
				_003C_003Ef__mg_0024cacheE = InternalMultiplayerStatusCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_CancelMatch(self, match2, _003C_003Ef__mg_0024cacheE, Callbacks.ToIntPtr(callback));
		}

		internal void Rematch(NativeTurnBasedMatch match, Action<TurnBasedMatchResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr match2 = match.AsPointer();
			if (_003C_003Ef__mg_0024cacheF == null)
			{
				_003C_003Ef__mg_0024cacheF = InternalTurnBasedMatchCallback;
			}
			TurnBasedMultiplayerManager.TurnBasedMultiplayerManager_Rematch(self, match2, _003C_003Ef__mg_0024cacheF, ToCallbackPointer(callback));
		}

		private static IntPtr ToCallbackPointer(Action<TurnBasedMatchResponse> callback)
		{
			if (_003C_003Ef__mg_0024cache10 == null)
			{
				_003C_003Ef__mg_0024cache10 = TurnBasedMatchResponse.FromPointer;
			}
			return Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache10);
		}
	}
}
