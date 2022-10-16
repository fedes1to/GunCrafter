using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class CaptureOverlayStateListenerHelper : BaseReferenceHolder
	{
		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.OnCaptureOverlayStateChangedCallback _003C_003Ef__mg_0024cache0;

		internal CaptureOverlayStateListenerHelper(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.CaptureOverlayStateListenerHelper_Dispose(selfPointer);
		}

		internal CaptureOverlayStateListenerHelper SetOnCaptureOverlayStateChangedCallback(Action<Types.VideoCaptureOverlayState> callback)
		{
			HandleRef self = SelfPtr();
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = InternalOnCaptureOverlayStateChangedCallback;
			}
			GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.CaptureOverlayStateListenerHelper_SetOnCaptureOverlayStateChangedCallback(self, _003C_003Ef__mg_0024cache0, Callbacks.ToIntPtr(callback));
			return this;
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.OnCaptureOverlayStateChangedCallback))]
		internal static void InternalOnCaptureOverlayStateChangedCallback(Types.VideoCaptureOverlayState response, IntPtr data)
		{
			Action<Types.VideoCaptureOverlayState> action = Callbacks.IntPtrToPermanentCallback<Action<Types.VideoCaptureOverlayState>>(data);
			try
			{
				action(response);
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalOnCaptureOverlayStateChangedCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal static CaptureOverlayStateListenerHelper Create()
		{
			return new CaptureOverlayStateListenerHelper(GooglePlayGames.Native.Cwrapper.CaptureOverlayStateListenerHelper.CaptureOverlayStateListenerHelper_Construct());
		}
	}
}
