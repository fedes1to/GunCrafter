using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class QuestManager
	{
		internal class FetchResponse : BaseReferenceHolder
		{
			internal FetchResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus ResponseStatus()
			{
				return GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchResponse_GetStatus(SelfPtr());
			}

			internal NativeQuest Data()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				return new NativeQuest(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchResponse_GetData(SelfPtr()));
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.ResponseStatus)0;
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchResponse_Dispose(selfPointer);
			}

			internal static FetchResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new FetchResponse(pointer);
			}
		}

		internal class FetchListResponse : BaseReferenceHolder
		{
			internal FetchListResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus ResponseStatus()
			{
				return GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchListResponse_GetStatus(SelfPtr());
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.ResponseStatus)0;
			}

			internal IEnumerable<NativeQuest> Data()
			{
				return PInvokeUtilities.ToEnumerable(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchListResponse_GetData_Length(SelfPtr()), _003CData_003Em__0);
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchListResponse_Dispose(selfPointer);
			}

			internal static FetchListResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new FetchListResponse(pointer);
			}

			[CompilerGenerated]
			private NativeQuest _003CData_003Em__0(UIntPtr index)
			{
				return new NativeQuest(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchListResponse_GetData_GetElement(SelfPtr(), index));
			}
		}

		internal class ClaimMilestoneResponse : BaseReferenceHolder
		{
			internal ClaimMilestoneResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.QuestClaimMilestoneStatus ResponseStatus()
			{
				return GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ClaimMilestoneResponse_GetStatus(SelfPtr());
			}

			internal NativeQuest Quest()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				NativeQuest nativeQuest = new NativeQuest(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ClaimMilestoneResponse_GetQuest(SelfPtr()));
				if (nativeQuest.Valid())
				{
					return nativeQuest;
				}
				nativeQuest.Dispose();
				return null;
			}

			internal NativeQuestMilestone ClaimedMilestone()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				NativeQuestMilestone nativeQuestMilestone = new NativeQuestMilestone(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ClaimMilestoneResponse_GetClaimedMilestone(SelfPtr()));
				if (nativeQuestMilestone.Valid())
				{
					return nativeQuestMilestone;
				}
				nativeQuestMilestone.Dispose();
				return null;
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.QuestClaimMilestoneStatus)0;
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ClaimMilestoneResponse_Dispose(selfPointer);
			}

			internal static ClaimMilestoneResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new ClaimMilestoneResponse(pointer);
			}
		}

		internal class AcceptResponse : BaseReferenceHolder
		{
			internal AcceptResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.QuestAcceptStatus ResponseStatus()
			{
				return GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_AcceptResponse_GetStatus(SelfPtr());
			}

			internal NativeQuest AcceptedQuest()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				return new NativeQuest(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_AcceptResponse_GetAcceptedQuest(SelfPtr()));
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.QuestAcceptStatus)0;
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_AcceptResponse_Dispose(selfPointer);
			}

			internal static AcceptResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new AcceptResponse(pointer);
			}
		}

		internal class QuestUIResponse : BaseReferenceHolder
		{
			internal QuestUIResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.UIStatus RequestStatus()
			{
				return GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_QuestUIResponse_GetStatus(SelfPtr());
			}

			internal bool RequestSucceeded()
			{
				return RequestStatus() > (CommonErrorStatus.UIStatus)0;
			}

			internal NativeQuest AcceptedQuest()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				NativeQuest nativeQuest = new NativeQuest(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_QuestUIResponse_GetAcceptedQuest(SelfPtr()));
				if (nativeQuest.Valid())
				{
					return nativeQuest;
				}
				nativeQuest.Dispose();
				return null;
			}

			internal NativeQuestMilestone MilestoneToClaim()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				NativeQuestMilestone nativeQuestMilestone = new NativeQuestMilestone(GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_QuestUIResponse_GetMilestoneToClaim(SelfPtr()));
				if (nativeQuestMilestone.Valid())
				{
					return nativeQuestMilestone;
				}
				nativeQuestMilestone.Dispose();
				return null;
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_QuestUIResponse_Dispose(selfPointer);
			}

			internal static QuestUIResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new QuestUIResponse(pointer);
			}
		}

		private readonly GameServices mServices;

		[CompilerGenerated]
		private static Func<IntPtr, FetchResponse> _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.QuestManager.FetchCallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Func<IntPtr, FetchListResponse> _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.QuestManager.FetchListCallback _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static Func<IntPtr, QuestUIResponse> _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.QuestManager.QuestUICallback _003C_003Ef__mg_0024cache5;

		[CompilerGenerated]
		private static Func<IntPtr, QuestUIResponse> _003C_003Ef__mg_0024cache6;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.QuestManager.QuestUICallback _003C_003Ef__mg_0024cache7;

		[CompilerGenerated]
		private static Func<IntPtr, AcceptResponse> _003C_003Ef__mg_0024cache8;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.QuestManager.AcceptCallback _003C_003Ef__mg_0024cache9;

		[CompilerGenerated]
		private static Func<IntPtr, ClaimMilestoneResponse> _003C_003Ef__mg_0024cacheA;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.QuestManager.ClaimMilestoneCallback _003C_003Ef__mg_0024cacheB;

		internal QuestManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void Fetch(Types.DataSource source, string questId, Action<FetchResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalFetchCallback;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.FetchCallback callback2 = _003C_003Ef__mg_0024cache1;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = FetchResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_Fetch(self, source, questId, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache0));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.QuestManager.FetchCallback))]
		internal static void InternalFetchCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("QuestManager#FetchCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void FetchList(Types.DataSource source, int fetchFlags, Action<FetchListResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalFetchListCallback;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.FetchListCallback callback2 = _003C_003Ef__mg_0024cache3;
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = FetchListResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_FetchList(self, source, fetchFlags, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache2));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.QuestManager.FetchListCallback))]
		internal static void InternalFetchListCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("QuestManager#FetchListCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void ShowAllQuestUI(Action<QuestUIResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = InternalQuestUICallback;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestUICallback callback2 = _003C_003Ef__mg_0024cache5;
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = QuestUIResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ShowAllUI(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache4));
		}

		internal void ShowQuestUI(NativeQuest quest, Action<QuestUIResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			IntPtr quest2 = quest.AsPointer();
			if (_003C_003Ef__mg_0024cache7 == null)
			{
				_003C_003Ef__mg_0024cache7 = InternalQuestUICallback;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestUICallback callback2 = _003C_003Ef__mg_0024cache7;
			if (_003C_003Ef__mg_0024cache6 == null)
			{
				_003C_003Ef__mg_0024cache6 = QuestUIResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ShowUI(self, quest2, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache6));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.QuestManager.QuestUICallback))]
		internal static void InternalQuestUICallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("QuestManager#QuestUICallback", Callbacks.Type.Temporary, response, data);
		}

		internal void Accept(NativeQuest quest, Action<AcceptResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			IntPtr quest2 = quest.AsPointer();
			if (_003C_003Ef__mg_0024cache9 == null)
			{
				_003C_003Ef__mg_0024cache9 = InternalAcceptCallback;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.AcceptCallback callback2 = _003C_003Ef__mg_0024cache9;
			if (_003C_003Ef__mg_0024cache8 == null)
			{
				_003C_003Ef__mg_0024cache8 = AcceptResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_Accept(self, quest2, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache8));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.QuestManager.AcceptCallback))]
		internal static void InternalAcceptCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("QuestManager#AcceptCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void ClaimMilestone(NativeQuestMilestone milestone, Action<ClaimMilestoneResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			IntPtr milestone2 = milestone.AsPointer();
			if (_003C_003Ef__mg_0024cacheB == null)
			{
				_003C_003Ef__mg_0024cacheB = InternalClaimMilestoneCallback;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.ClaimMilestoneCallback callback2 = _003C_003Ef__mg_0024cacheB;
			if (_003C_003Ef__mg_0024cacheA == null)
			{
				_003C_003Ef__mg_0024cacheA = ClaimMilestoneResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.QuestManager.QuestManager_ClaimMilestone(self, milestone2, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cacheA));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.QuestManager.ClaimMilestoneCallback))]
		internal static void InternalClaimMilestoneCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("QuestManager#ClaimMilestoneCallback", Callbacks.Type.Temporary, response, data);
		}
	}
}
