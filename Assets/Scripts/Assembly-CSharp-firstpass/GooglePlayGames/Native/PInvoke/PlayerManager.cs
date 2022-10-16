using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class PlayerManager
	{
		internal class FetchListResponse : BaseReferenceHolder, IEnumerable<NativePlayer>, IEnumerable
		{
			internal FetchListResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_Dispose(SelfPtr());
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_GetStatus(SelfPtr());
			}

			public IEnumerator<NativePlayer> GetEnumerator()
			{
				return PInvokeUtilities.ToEnumerator(Length(), _003CGetEnumerator_003Em__0);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			internal UIntPtr Length()
			{
				return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_GetData_Length(SelfPtr());
			}

			internal NativePlayer GetElement(UIntPtr index)
			{
				if (index.ToUInt64() >= Length().ToUInt64())
				{
					throw new ArgumentOutOfRangeException();
				}
				return new NativePlayer(GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_GetData_GetElement(SelfPtr(), index));
			}

			internal static FetchListResponse FromPointer(IntPtr selfPointer)
			{
				if (PInvokeUtilities.IsNull(selfPointer))
				{
					return null;
				}
				return new FetchListResponse(selfPointer);
			}

			[CompilerGenerated]
			private NativePlayer _003CGetEnumerator_003Em__0(UIntPtr index)
			{
				return GetElement(index);
			}
		}

		internal class FetchResponseCollector
		{
			internal int pendingCount;

			internal List<NativePlayer> results = new List<NativePlayer>();

			internal Action<NativePlayer[]> callback;
		}

		internal class FetchResponse : BaseReferenceHolder
		{
			internal FetchResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchResponse_Dispose(SelfPtr());
			}

			internal NativePlayer GetPlayer()
			{
				return new NativePlayer(GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchResponse_GetData(SelfPtr()));
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchResponse_GetStatus(SelfPtr());
			}

			internal static FetchResponse FromPointer(IntPtr selfPointer)
			{
				if (PInvokeUtilities.IsNull(selfPointer))
				{
					return null;
				}
				return new FetchResponse(selfPointer);
			}
		}

		internal class FetchSelfResponse : BaseReferenceHolder
		{
			internal FetchSelfResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelfResponse_GetStatus(SelfPtr());
			}

			internal NativePlayer Self()
			{
				return new NativePlayer(GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelfResponse_GetData(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelfResponse_Dispose(SelfPtr());
			}

			internal static FetchSelfResponse FromPointer(IntPtr selfPointer)
			{
				if (PInvokeUtilities.IsNull(selfPointer))
				{
					return null;
				}
				return new FetchSelfResponse(selfPointer);
			}
		}

		[CompilerGenerated]
		private sealed class _003CFetchList_003Ec__AnonStorey0
		{
			internal FetchResponseCollector coll;

			internal PlayerManager _0024this;

			internal void _003C_003Em__0(FetchResponse rsp)
			{
				_0024this.HandleFetchResponse(coll, rsp);
			}
		}

		[CompilerGenerated]
		private sealed class _003CFetchFriends_003Ec__AnonStorey1
		{
			internal Action<ResponseStatus, List<GooglePlayGames.BasicApi.Multiplayer.Player>> callback;

			internal PlayerManager _0024this;

			internal void _003C_003Em__0(FetchListResponse rsp)
			{
				_0024this.HandleFetchCollected(rsp, callback);
			}
		}

		private readonly GameServices mGameServices;

		[CompilerGenerated]
		private static Func<IntPtr, FetchSelfResponse> _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.PlayerManager.FetchSelfCallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Func<IntPtr, FetchResponse> _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.PlayerManager.FetchCallback _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static Func<IntPtr, FetchListResponse> _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.PlayerManager.FetchListCallback _003C_003Ef__mg_0024cache5;

		internal PlayerManager(GameServices services)
		{
			mGameServices = Misc.CheckNotNull(services);
		}

		internal void FetchSelf(Action<FetchSelfResponse> callback)
		{
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalFetchSelfCallback;
			}
			GooglePlayGames.Native.Cwrapper.PlayerManager.FetchSelfCallback callback2 = _003C_003Ef__mg_0024cache1;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = FetchSelfResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelf(self, Types.DataSource.CACHE_OR_NETWORK, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache0));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.PlayerManager.FetchSelfCallback))]
		private static void InternalFetchSelfCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("PlayerManager#InternalFetchSelfCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void FetchList(string[] userIds, Action<NativePlayer[]> callback)
		{
			_003CFetchList_003Ec__AnonStorey0 _003CFetchList_003Ec__AnonStorey = new _003CFetchList_003Ec__AnonStorey0();
			_003CFetchList_003Ec__AnonStorey._0024this = this;
			_003CFetchList_003Ec__AnonStorey.coll = new FetchResponseCollector();
			_003CFetchList_003Ec__AnonStorey.coll.pendingCount = userIds.Length;
			_003CFetchList_003Ec__AnonStorey.coll.callback = callback;
			foreach (string player_id in userIds)
			{
				HandleRef self = mGameServices.AsHandle();
				if (_003C_003Ef__mg_0024cache3 == null)
				{
					_003C_003Ef__mg_0024cache3 = InternalFetchCallback;
				}
				GooglePlayGames.Native.Cwrapper.PlayerManager.FetchCallback callback2 = _003C_003Ef__mg_0024cache3;
				Action<FetchResponse> callback3 = _003CFetchList_003Ec__AnonStorey._003C_003Em__0;
				if (_003C_003Ef__mg_0024cache2 == null)
				{
					_003C_003Ef__mg_0024cache2 = FetchResponse.FromPointer;
				}
				GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_Fetch(self, Types.DataSource.CACHE_OR_NETWORK, player_id, callback2, Callbacks.ToIntPtr(callback3, _003C_003Ef__mg_0024cache2));
			}
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.PlayerManager.FetchCallback))]
		private static void InternalFetchCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("PlayerManager#InternalFetchCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void HandleFetchResponse(FetchResponseCollector collector, FetchResponse resp)
		{
			if (resp.Status() == CommonErrorStatus.ResponseStatus.VALID || resp.Status() == CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
			{
				NativePlayer player = resp.GetPlayer();
				collector.results.Add(player);
			}
			collector.pendingCount--;
			if (collector.pendingCount == 0)
			{
				collector.callback(collector.results.ToArray());
			}
		}

		internal void FetchFriends(Action<ResponseStatus, List<GooglePlayGames.BasicApi.Multiplayer.Player>> callback)
		{
			_003CFetchFriends_003Ec__AnonStorey1 _003CFetchFriends_003Ec__AnonStorey = new _003CFetchFriends_003Ec__AnonStorey1();
			_003CFetchFriends_003Ec__AnonStorey.callback = callback;
			_003CFetchFriends_003Ec__AnonStorey._0024this = this;
			HandleRef self = mGameServices.AsHandle();
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = InternalFetchConnectedCallback;
			}
			GooglePlayGames.Native.Cwrapper.PlayerManager.FetchListCallback callback2 = _003C_003Ef__mg_0024cache5;
			Action<FetchListResponse> callback3 = _003CFetchFriends_003Ec__AnonStorey._003C_003Em__0;
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = FetchListResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchConnected(self, Types.DataSource.CACHE_OR_NETWORK, callback2, Callbacks.ToIntPtr(callback3, _003C_003Ef__mg_0024cache4));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.PlayerManager.FetchListCallback))]
		private static void InternalFetchConnectedCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("PlayerManager#InternalFetchConnectedCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void HandleFetchCollected(FetchListResponse rsp, Action<ResponseStatus, List<GooglePlayGames.BasicApi.Multiplayer.Player>> callback)
		{
			List<GooglePlayGames.BasicApi.Multiplayer.Player> list = new List<GooglePlayGames.BasicApi.Multiplayer.Player>();
			if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID || rsp.Status() == CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
			{
				Logger.d("Got " + rsp.Length().ToUInt64() + " players");
				foreach (NativePlayer item in rsp)
				{
					list.Add(item.AsPlayer());
				}
			}
			callback((ResponseStatus)rsp.Status(), list);
		}
	}
}
