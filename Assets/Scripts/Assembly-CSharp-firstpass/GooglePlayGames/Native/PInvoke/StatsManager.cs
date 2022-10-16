using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class StatsManager
	{
		internal class FetchForPlayerResponse : BaseReferenceHolder
		{
			internal FetchForPlayerResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_GetStatus(SelfPtr());
			}

			internal NativePlayerStats PlayerStats()
			{
				IntPtr selfPointer = GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_GetData(SelfPtr());
				return new NativePlayerStats(selfPointer);
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_Dispose(selfPointer);
			}

			internal static FetchForPlayerResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new FetchForPlayerResponse(pointer);
			}
		}

		private readonly GameServices mServices;

		[CompilerGenerated]
		private static Func<IntPtr, FetchForPlayerResponse> _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.StatsManager.FetchForPlayerCallback _003C_003Ef__mg_0024cache1;

		internal StatsManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void FetchForPlayer(Action<FetchForPlayerResponse> callback)
		{
			Misc.CheckNotNull(callback);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalFetchForPlayerCallback;
			}
			GooglePlayGames.Native.Cwrapper.StatsManager.FetchForPlayerCallback callback2 = _003C_003Ef__mg_0024cache1;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = FetchForPlayerResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayer(self, Types.DataSource.CACHE_OR_NETWORK, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache0));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.StatsManager.FetchForPlayerCallback))]
		private static void InternalFetchForPlayerCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("StatsManager#InternalFetchForPlayerCallback", Callbacks.Type.Temporary, response, data);
		}
	}
}
