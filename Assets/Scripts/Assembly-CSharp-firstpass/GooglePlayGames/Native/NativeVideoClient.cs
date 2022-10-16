using System;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Video;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal class NativeVideoClient : IVideoClient
	{
		[CompilerGenerated]
		private sealed class _003CGetCaptureCapabilities_003Ec__AnonStorey0
		{
			internal Action<ResponseStatus, GooglePlayGames.BasicApi.Video.VideoCapabilities> callback;

			internal NativeVideoClient _0024this;

			internal void _003C_003Em__0(GetCaptureCapabilitiesResponse response)
			{
				ResponseStatus arg = ConversionUtils.ConvertResponseStatus(response.GetStatus());
				if (!response.RequestSucceeded())
				{
					callback(arg, null);
				}
				else
				{
					callback(arg, _0024this.FromNativeVideoCapabilities(response.GetData()));
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetCaptureState_003Ec__AnonStorey1
		{
			internal Action<ResponseStatus, GooglePlayGames.BasicApi.Video.VideoCaptureState> callback;

			internal NativeVideoClient _0024this;

			internal void _003C_003Em__0(GetCaptureStateResponse response)
			{
				ResponseStatus arg = ConversionUtils.ConvertResponseStatus(response.GetStatus());
				if (!response.RequestSucceeded())
				{
					callback(arg, null);
				}
				else
				{
					callback(arg, _0024this.FromNativeVideoCaptureState(response.GetData()));
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CIsCaptureAvailable_003Ec__AnonStorey2
		{
			internal Action<ResponseStatus, bool> callback;

			internal void _003C_003Em__0(IsCaptureAvailableResponse response)
			{
				ResponseStatus arg = ConversionUtils.ConvertResponseStatus(response.GetStatus());
				if (!response.RequestSucceeded())
				{
					callback(arg, false);
				}
				else
				{
					callback(arg, response.IsCaptureAvailable());
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey3
		{
			internal CaptureOverlayStateListener listener;

			internal void _003C_003Em__0(Types.VideoCaptureOverlayState response)
			{
				listener.OnCaptureOverlayStateChanged(ConversionUtils.ConvertNativeVideoCaptureOverlayState(response));
			}
		}

		private readonly GooglePlayGames.Native.PInvoke.VideoManager mManager;

		internal NativeVideoClient(GooglePlayGames.Native.PInvoke.VideoManager manager)
		{
			mManager = Misc.CheckNotNull(manager);
		}

		public void GetCaptureCapabilities(Action<ResponseStatus, GooglePlayGames.BasicApi.Video.VideoCapabilities> callback)
		{
			_003CGetCaptureCapabilities_003Ec__AnonStorey0 _003CGetCaptureCapabilities_003Ec__AnonStorey = new _003CGetCaptureCapabilities_003Ec__AnonStorey0();
			_003CGetCaptureCapabilities_003Ec__AnonStorey.callback = callback;
			_003CGetCaptureCapabilities_003Ec__AnonStorey._0024this = this;
			Misc.CheckNotNull(_003CGetCaptureCapabilities_003Ec__AnonStorey.callback);
			_003CGetCaptureCapabilities_003Ec__AnonStorey.callback = CallbackUtils.ToOnGameThread(_003CGetCaptureCapabilities_003Ec__AnonStorey.callback);
			mManager.GetCaptureCapabilities(_003CGetCaptureCapabilities_003Ec__AnonStorey._003C_003Em__0);
		}

		private GooglePlayGames.BasicApi.Video.VideoCapabilities FromNativeVideoCapabilities(NativeVideoCapabilities capabilities)
		{
			bool[] array = new bool[mManager.NumCaptureModes];
			array[0] = capabilities.SupportsCaptureMode(Types.VideoCaptureMode.FILE);
			array[1] = capabilities.SupportsCaptureMode(Types.VideoCaptureMode.STREAM);
			bool[] array2 = new bool[mManager.NumQualityLevels];
			array2[0] = capabilities.SupportsQualityLevel(Types.VideoQualityLevel.SD);
			array2[1] = capabilities.SupportsQualityLevel(Types.VideoQualityLevel.HD);
			array2[2] = capabilities.SupportsQualityLevel(Types.VideoQualityLevel.XHD);
			array2[3] = capabilities.SupportsQualityLevel(Types.VideoQualityLevel.FULLHD);
			return new GooglePlayGames.BasicApi.Video.VideoCapabilities(capabilities.IsCameraSupported(), capabilities.IsMicSupported(), capabilities.IsWriteStorageSupported(), array, array2);
		}

		public void ShowCaptureOverlay()
		{
			mManager.ShowCaptureOverlay();
		}

		public void GetCaptureState(Action<ResponseStatus, GooglePlayGames.BasicApi.Video.VideoCaptureState> callback)
		{
			_003CGetCaptureState_003Ec__AnonStorey1 _003CGetCaptureState_003Ec__AnonStorey = new _003CGetCaptureState_003Ec__AnonStorey1();
			_003CGetCaptureState_003Ec__AnonStorey.callback = callback;
			_003CGetCaptureState_003Ec__AnonStorey._0024this = this;
			Misc.CheckNotNull(_003CGetCaptureState_003Ec__AnonStorey.callback);
			_003CGetCaptureState_003Ec__AnonStorey.callback = CallbackUtils.ToOnGameThread(_003CGetCaptureState_003Ec__AnonStorey.callback);
			mManager.GetCaptureState(_003CGetCaptureState_003Ec__AnonStorey._003C_003Em__0);
		}

		private GooglePlayGames.BasicApi.Video.VideoCaptureState FromNativeVideoCaptureState(NativeVideoCaptureState captureState)
		{
			return new GooglePlayGames.BasicApi.Video.VideoCaptureState(captureState.IsCapturing(), ConversionUtils.ConvertNativeVideoCaptureMode(captureState.CaptureMode()), ConversionUtils.ConvertNativeVideoQualityLevel(captureState.QualityLevel()), captureState.IsOverlayVisible(), captureState.IsPaused());
		}

		public void IsCaptureAvailable(VideoCaptureMode captureMode, Action<ResponseStatus, bool> callback)
		{
			_003CIsCaptureAvailable_003Ec__AnonStorey2 _003CIsCaptureAvailable_003Ec__AnonStorey = new _003CIsCaptureAvailable_003Ec__AnonStorey2();
			_003CIsCaptureAvailable_003Ec__AnonStorey.callback = callback;
			Misc.CheckNotNull(_003CIsCaptureAvailable_003Ec__AnonStorey.callback);
			_003CIsCaptureAvailable_003Ec__AnonStorey.callback = CallbackUtils.ToOnGameThread(_003CIsCaptureAvailable_003Ec__AnonStorey.callback);
			mManager.IsCaptureAvailable(ConversionUtils.ConvertVideoCaptureMode(captureMode), _003CIsCaptureAvailable_003Ec__AnonStorey._003C_003Em__0);
		}

		public bool IsCaptureSupported()
		{
			return mManager.IsCaptureSupported();
		}

		public void RegisterCaptureOverlayStateChangedListener(CaptureOverlayStateListener listener)
		{
			_003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey3 _003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey = new _003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey3();
			_003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey.listener = listener;
			Misc.CheckNotNull(_003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey.listener);
			GooglePlayGames.Native.PInvoke.CaptureOverlayStateListenerHelper helper = GooglePlayGames.Native.PInvoke.CaptureOverlayStateListenerHelper.Create().SetOnCaptureOverlayStateChangedCallback(_003CRegisterCaptureOverlayStateChangedListener_003Ec__AnonStorey._003C_003Em__0);
			mManager.RegisterCaptureOverlayStateChangedListener(helper);
		}

		public void UnregisterCaptureOverlayStateChangedListener()
		{
			mManager.UnregisterCaptureOverlayStateChangedListener();
		}
	}
}
