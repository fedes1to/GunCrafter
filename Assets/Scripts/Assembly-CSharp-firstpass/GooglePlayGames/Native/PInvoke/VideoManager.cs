using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class VideoManager
	{
		private readonly GameServices mServices;

		[CompilerGenerated]
		private static Func<IntPtr, GetCaptureCapabilitiesResponse> _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.VideoManager.CaptureCapabilitiesCallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Func<IntPtr, GetCaptureStateResponse> _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.VideoManager.CaptureStateCallback _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static Func<IntPtr, IsCaptureAvailableResponse> _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.VideoManager.IsCaptureAvailableCallback _003C_003Ef__mg_0024cache5;

		internal int NumCaptureModes
		{
			get
			{
				return 2;
			}
		}

		internal int NumQualityLevels
		{
			get
			{
				return 4;
			}
		}

		internal VideoManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void GetCaptureCapabilities(Action<GetCaptureCapabilitiesResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalCaptureCapabilitiesCallback;
			}
			GooglePlayGames.Native.Cwrapper.VideoManager.CaptureCapabilitiesCallback callback2 = _003C_003Ef__mg_0024cache1;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = GetCaptureCapabilitiesResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_GetCaptureCapabilities(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache0));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.VideoManager.CaptureCapabilitiesCallback))]
		internal static void InternalCaptureCapabilitiesCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("VideoManager#CaptureCapabilitiesCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void ShowCaptureOverlay()
		{
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_ShowCaptureOverlay(mServices.AsHandle());
		}

		internal void GetCaptureState(Action<GetCaptureStateResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalCaptureStateCallback;
			}
			GooglePlayGames.Native.Cwrapper.VideoManager.CaptureStateCallback callback2 = _003C_003Ef__mg_0024cache3;
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = GetCaptureStateResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_GetCaptureState(self, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache2));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.VideoManager.CaptureStateCallback))]
		internal static void InternalCaptureStateCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("VideoManager#CaptureStateCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void IsCaptureAvailable(Types.VideoCaptureMode captureMode, Action<IsCaptureAvailableResponse> callback)
		{
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = InternalIsCaptureAvailableCallback;
			}
			GooglePlayGames.Native.Cwrapper.VideoManager.IsCaptureAvailableCallback callback2 = _003C_003Ef__mg_0024cache5;
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = IsCaptureAvailableResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_IsCaptureAvailable(self, captureMode, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache4));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.VideoManager.IsCaptureAvailableCallback))]
		internal static void InternalIsCaptureAvailableCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("VideoManager#IsCaptureAvailableCallback", Callbacks.Type.Temporary, response, data);
		}

		internal bool IsCaptureSupported()
		{
			return GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_IsCaptureSupported(mServices.AsHandle());
		}

		internal void RegisterCaptureOverlayStateChangedListener(CaptureOverlayStateListenerHelper helper)
		{
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_RegisterCaptureOverlayStateChangedListener(mServices.AsHandle(), helper.AsPointer());
		}

		internal void UnregisterCaptureOverlayStateChangedListener()
		{
			GooglePlayGames.Native.Cwrapper.VideoManager.VideoManager_UnregisterCaptureOverlayStateChangedListener(mServices.AsHandle());
		}
	}
}
