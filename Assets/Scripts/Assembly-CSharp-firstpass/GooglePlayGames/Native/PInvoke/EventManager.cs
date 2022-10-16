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
	internal class EventManager
	{
		internal class FetchResponse : BaseReferenceHolder
		{
			internal FetchResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus ResponseStatus()
			{
				return GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchResponse_GetStatus(SelfPtr());
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.ResponseStatus)0;
			}

			internal NativeEvent Data()
			{
				if (!RequestSucceeded())
				{
					return null;
				}
				return new NativeEvent(GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchResponse_GetData(SelfPtr()));
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchResponse_Dispose(selfPointer);
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

		internal class FetchAllResponse : BaseReferenceHolder
		{
			[CompilerGenerated]
			private static Func<IntPtr, NativeEvent> _003C_003Ef__am_0024cache0;

			internal FetchAllResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus ResponseStatus()
			{
				return GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchAllResponse_GetStatus(SelfPtr());
			}

			internal List<NativeEvent> Data()
			{
				IntPtr[] source = PInvokeUtilities.OutParamsToArray<IntPtr>(_003CData_003Em__0);
				if (_003C_003Ef__am_0024cache0 == null)
				{
					_003C_003Ef__am_0024cache0 = _003CData_003Em__1;
				}
				return source.Select(_003C_003Ef__am_0024cache0).ToList();
			}

			internal bool RequestSucceeded()
			{
				return ResponseStatus() > (CommonErrorStatus.ResponseStatus)0;
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchAllResponse_Dispose(selfPointer);
			}

			internal static FetchAllResponse FromPointer(IntPtr pointer)
			{
				if (pointer.Equals(IntPtr.Zero))
				{
					return null;
				}
				return new FetchAllResponse(pointer);
			}

			[CompilerGenerated]
			private UIntPtr _003CData_003Em__0(IntPtr[] out_arg, UIntPtr out_size)
			{
				return GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchAllResponse_GetData(SelfPtr(), out_arg, out_size);
			}

			[CompilerGenerated]
			private static NativeEvent _003CData_003Em__1(IntPtr ptr)
			{
				return new NativeEvent(ptr);
			}
		}

		private readonly GameServices mServices;

		[CompilerGenerated]
		private static Func<IntPtr, FetchAllResponse> _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.EventManager.FetchAllCallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Func<IntPtr, FetchResponse> _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.EventManager.FetchCallback _003C_003Ef__mg_0024cache3;

		internal EventManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void FetchAll(Types.DataSource source, Action<FetchAllResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalFetchAllCallback;
			}
			GooglePlayGames.Native.Cwrapper.EventManager.FetchAllCallback callback2 = _003C_003Ef__mg_0024cache1;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = FetchAllResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.EventManager.EventManager_FetchAll(self, source, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache0));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.EventManager.FetchAllCallback))]
		internal static void InternalFetchAllCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("EventManager#FetchAllCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void Fetch(Types.DataSource source, string eventId, Action<FetchResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalFetchCallback;
			}
			GooglePlayGames.Native.Cwrapper.EventManager.FetchCallback callback2 = _003C_003Ef__mg_0024cache3;
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = FetchResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.EventManager.EventManager_Fetch(self, source, eventId, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache2));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.EventManager.FetchCallback))]
		internal static void InternalFetchCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("EventManager#FetchCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void Increment(string eventId, uint steps)
		{
			GooglePlayGames.Native.Cwrapper.EventManager.EventManager_Increment(mServices.AsHandle(), eventId, steps);
		}
	}
}
