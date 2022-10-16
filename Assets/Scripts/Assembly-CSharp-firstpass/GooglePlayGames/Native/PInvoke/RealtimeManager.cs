using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class RealtimeManager
	{
		internal class RealTimeRoomResponse : BaseReferenceHolder
		{
			internal RealTimeRoomResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.MultiplayerStatus ResponseStatus()
			{
				return RealTimeMultiplayerManager.RealTimeMultiplayerManager_RealTimeRoomResponse_GetStatus(SelfPtr());
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.MultiplayerStatus)0;
			}

			internal NativeRealTimeRoom Room()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				return new NativeRealTimeRoom(RealTimeMultiplayerManager.RealTimeMultiplayerManager_RealTimeRoomResponse_GetRoom(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				RealTimeMultiplayerManager.RealTimeMultiplayerManager_RealTimeRoomResponse_Dispose(selfPointer);
			}

			internal static RealTimeRoomResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new RealTimeRoomResponse(pointer);
			}
		}

		internal class RoomInboxUIResponse : BaseReferenceHolder
		{
			internal RoomInboxUIResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.UIStatus ResponseStatus()
			{
				return RealTimeMultiplayerManager.RealTimeMultiplayerManager_RoomInboxUIResponse_GetStatus(SelfPtr());
			}

			internal MultiplayerInvitation Invitation()
			{
				if (ResponseStatus() != CommonErrorStatus.UIStatus.VALID)
				{
					return null;
				}
				return new MultiplayerInvitation(RealTimeMultiplayerManager.RealTimeMultiplayerManager_RoomInboxUIResponse_GetInvitation(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				RealTimeMultiplayerManager.RealTimeMultiplayerManager_RoomInboxUIResponse_Dispose(selfPointer);
			}

			internal static RoomInboxUIResponse FromPointer(IntPtr pointer)
			{
				if (PInvokeUtilities.IsNull(pointer))
				{
					return null;
				}
				return new RoomInboxUIResponse(pointer);
			}
		}

		internal class WaitingRoomUIResponse : BaseReferenceHolder
		{
			internal WaitingRoomUIResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.UIStatus ResponseStatus()
			{
				return RealTimeMultiplayerManager.RealTimeMultiplayerManager_WaitingRoomUIResponse_GetStatus(SelfPtr());
			}

			internal NativeRealTimeRoom Room()
			{
				if (ResponseStatus() != CommonErrorStatus.UIStatus.VALID)
				{
					return null;
				}
				return new NativeRealTimeRoom(RealTimeMultiplayerManager.RealTimeMultiplayerManager_WaitingRoomUIResponse_GetRoom(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				RealTimeMultiplayerManager.RealTimeMultiplayerManager_WaitingRoomUIResponse_Dispose(selfPointer);
			}

			internal static WaitingRoomUIResponse FromPointer(IntPtr pointer)
			{
				if (PInvokeUtilities.IsNull(pointer))
				{
					return null;
				}
				return new WaitingRoomUIResponse(pointer);
			}
		}

		internal class FetchInvitationsResponse : BaseReferenceHolder
		{
			internal FetchInvitationsResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.ResponseStatus)0;
			}

			internal CommonErrorStatus.ResponseStatus ResponseStatus()
			{
				return RealTimeMultiplayerManager.RealTimeMultiplayerManager_FetchInvitationsResponse_GetStatus(SelfPtr());
			}

			internal IEnumerable<MultiplayerInvitation> Invitations()
			{
				return PInvokeUtilities.ToEnumerable(RealTimeMultiplayerManager.RealTimeMultiplayerManager_FetchInvitationsResponse_GetInvitations_Length(SelfPtr()), _003CInvitations_003Em__0);
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				RealTimeMultiplayerManager.RealTimeMultiplayerManager_FetchInvitationsResponse_Dispose(selfPointer);
			}

			internal static FetchInvitationsResponse FromPointer(IntPtr pointer)
			{
				if (PInvokeUtilities.IsNull(pointer))
				{
					return null;
				}
				return new FetchInvitationsResponse(pointer);
			}

			[CompilerGenerated]
			private MultiplayerInvitation _003CInvitations_003Em__0(UIntPtr index)
			{
				return new MultiplayerInvitation(RealTimeMultiplayerManager.RealTimeMultiplayerManager_FetchInvitationsResponse_GetInvitations_GetElement(SelfPtr(), index));
			}
		}

		private readonly GameServices mGameServices;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.RealTimeRoomCallback _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static Func<IntPtr, PlayerSelectUIResponse> _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.PlayerSelectUICallback _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static Func<IntPtr, RoomInboxUIResponse> _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.RoomInboxUICallback _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static Func<IntPtr, WaitingRoomUIResponse> _003C_003Ef__mg_0024cache5;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.WaitingRoomUICallback _003C_003Ef__mg_0024cache6;

		[CompilerGenerated]
		private static Func<IntPtr, FetchInvitationsResponse> _003C_003Ef__mg_0024cache7;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.FetchInvitationsCallback _003C_003Ef__mg_0024cache8;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.LeaveRoomCallback _003C_003Ef__mg_0024cache9;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.RealTimeRoomCallback _003C_003Ef__mg_0024cacheA;

		[CompilerGenerated]
		private static RealTimeMultiplayerManager.SendReliableMessageCallback _003C_003Ef__mg_0024cacheB;

		[CompilerGenerated]
		private static Func<MultiplayerParticipant, IntPtr> _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		private static Func<IntPtr, RealTimeRoomResponse> _003C_003Ef__mg_0024cacheC;

		internal RealtimeManager(GameServices gameServices)
		{
			mGameServices = Misc.CheckNotNull(gameServices);
		}

		internal void CreateRoom(RealtimeRoomConfig config, RealTimeEventListenerHelper helper, Action<RealTimeRoomResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr config2 = config.AsPointer();
			IntPtr helper2 = helper.AsPointer();
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = InternalRealTimeRoomCallback;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_CreateRealTimeRoom(self, config2, helper2, _003C_003Ef__mg_0024cache0, ToCallbackPointer(callback));
		}

		internal void ShowPlayerSelectUI(uint minimumPlayers, uint maxiumPlayers, bool allowAutomatching, Action<PlayerSelectUIResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = InternalPlayerSelectUIcallback;
			}
			RealTimeMultiplayerManager.PlayerSelectUICallback callback2 = _003C_003Ef__mg_0024cache2;
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = PlayerSelectUIResponse.FromPointer;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_ShowPlayerSelectUI(self, minimumPlayers, maxiumPlayers, allowAutomatching, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache1));
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.PlayerSelectUICallback))]
		internal static void InternalPlayerSelectUIcallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("RealtimeManager#PlayerSelectUICallback", Callbacks.Type.Temporary, response, data);
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.RealTimeRoomCallback))]
		internal static void InternalRealTimeRoomCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("RealtimeManager#InternalRealTimeRoomCallback", Callbacks.Type.Temporary, response, data);
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.RoomInboxUICallback))]
		internal static void InternalRoomInboxUICallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("RealtimeManager#InternalRoomInboxUICallback", Callbacks.Type.Temporary, response, data);
		}

		internal void ShowRoomInboxUI(Action<RoomInboxUIResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = InternalRoomInboxUICallback;
			}
			RealTimeMultiplayerManager.RoomInboxUICallback callback2 = _003C_003Ef__mg_0024cache4;
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = RoomInboxUIResponse.FromPointer;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_ShowRoomInboxUI(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache3));
		}

		internal void ShowWaitingRoomUI(NativeRealTimeRoom room, uint minimumParticipantsBeforeStarting, Action<WaitingRoomUIResponse> callback)
		{
			Misc.CheckNotNull(room);
			HandleRef self = mGameServices.AsHandle();
			IntPtr room2 = room.AsPointer();
			if (_003C_003Ef__mg_0024cache6 == null)
			{
				_003C_003Ef__mg_0024cache6 = InternalWaitingRoomUICallback;
			}
			RealTimeMultiplayerManager.WaitingRoomUICallback callback2 = _003C_003Ef__mg_0024cache6;
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = WaitingRoomUIResponse.FromPointer;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_ShowWaitingRoomUI(self, room2, minimumParticipantsBeforeStarting, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache5));
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.WaitingRoomUICallback))]
		internal static void InternalWaitingRoomUICallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("RealtimeManager#InternalWaitingRoomUICallback", Callbacks.Type.Temporary, response, data);
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.FetchInvitationsCallback))]
		internal static void InternalFetchInvitationsCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("RealtimeManager#InternalFetchInvitationsCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void FetchInvitations(Action<FetchInvitationsResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache8 == null)
			{
				_003C_003Ef__mg_0024cache8 = InternalFetchInvitationsCallback;
			}
			RealTimeMultiplayerManager.FetchInvitationsCallback callback2 = _003C_003Ef__mg_0024cache8;
			if (_003C_003Ef__mg_0024cache7 == null)
			{
				_003C_003Ef__mg_0024cache7 = FetchInvitationsResponse.FromPointer;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_FetchInvitations(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache7));
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.LeaveRoomCallback))]
		internal static void InternalLeaveRoomCallback(CommonErrorStatus.ResponseStatus response, IntPtr data)
		{
			Logger.d("Entering internal callback for InternalLeaveRoomCallback");
			Action<CommonErrorStatus.ResponseStatus> action = Callbacks.IntPtrToTempCallback<Action<CommonErrorStatus.ResponseStatus>>(data);
			if (action == null)
			{
				return;
			}
			try
			{
				action(response);
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalLeaveRoomCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal void LeaveRoom(NativeRealTimeRoom room, Action<CommonErrorStatus.ResponseStatus> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr room2 = room.AsPointer();
			if (_003C_003Ef__mg_0024cache9 == null)
			{
				_003C_003Ef__mg_0024cache9 = InternalLeaveRoomCallback;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_LeaveRoom(self, room2, _003C_003Ef__mg_0024cache9, Callbacks.ToIntPtr(callback));
		}

		internal void AcceptInvitation(MultiplayerInvitation invitation, RealTimeEventListenerHelper listener, Action<RealTimeRoomResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr invitation2 = invitation.AsPointer();
			IntPtr helper = listener.AsPointer();
			if (_003C_003Ef__mg_0024cacheA == null)
			{
				_003C_003Ef__mg_0024cacheA = InternalRealTimeRoomCallback;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_AcceptInvitation(self, invitation2, helper, _003C_003Ef__mg_0024cacheA, ToCallbackPointer(callback));
		}

		internal void DeclineInvitation(MultiplayerInvitation invitation)
		{
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_DeclineInvitation(mGameServices.AsHandle(), invitation.AsPointer());
		}

		internal void SendReliableMessage(NativeRealTimeRoom room, MultiplayerParticipant participant, byte[] data, Action<CommonErrorStatus.MultiplayerStatus> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr room2 = room.AsPointer();
			IntPtr participant2 = participant.AsPointer();
			UIntPtr data_size = PInvokeUtilities.ArrayToSizeT(data);
			if (_003C_003Ef__mg_0024cacheB == null)
			{
				_003C_003Ef__mg_0024cacheB = InternalSendReliableMessageCallback;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_SendReliableMessage(self, room2, participant2, data, data_size, _003C_003Ef__mg_0024cacheB, Callbacks.ToIntPtr(callback));
		}

		[MonoPInvokeCallback(typeof(RealTimeMultiplayerManager.SendReliableMessageCallback))]
		internal static void InternalSendReliableMessageCallback(CommonErrorStatus.MultiplayerStatus response, IntPtr data)
		{
			Logger.d("Entering internal callback for InternalSendReliableMessageCallback " + response);
			Action<CommonErrorStatus.MultiplayerStatus> action = Callbacks.IntPtrToTempCallback<Action<CommonErrorStatus.MultiplayerStatus>>(data);
			if (action == null)
			{
				return;
			}
			try
			{
				action(response);
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalSendReliableMessageCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal void SendUnreliableMessageToAll(NativeRealTimeRoom room, byte[] data)
		{
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_SendUnreliableMessageToOthers(mGameServices.AsHandle(), room.AsPointer(), data, PInvokeUtilities.ArrayToSizeT(data));
		}

		internal void SendUnreliableMessageToSpecificParticipants(NativeRealTimeRoom room, List<MultiplayerParticipant> recipients, byte[] data)
		{
			HandleRef self = mGameServices.AsHandle();
			IntPtr room2 = room.AsPointer();
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003CSendUnreliableMessageToSpecificParticipants_003Em__0;
			}
			RealTimeMultiplayerManager.RealTimeMultiplayerManager_SendUnreliableMessage(self, room2, recipients.Select(_003C_003Ef__am_0024cache0).ToArray(), new UIntPtr((ulong)recipients.LongCount()), data, PInvokeUtilities.ArrayToSizeT(data));
		}

		private static IntPtr ToCallbackPointer(Action<RealTimeRoomResponse> callback)
		{
			if (_003C_003Ef__mg_0024cacheC == null)
			{
				_003C_003Ef__mg_0024cacheC = RealTimeRoomResponse.FromPointer;
			}
			return Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cacheC);
		}

		[CompilerGenerated]
		private static IntPtr _003CSendUnreliableMessageToSpecificParticipants_003Em__0(MultiplayerParticipant r)
		{
			return r.AsPointer();
		}
	}
}
