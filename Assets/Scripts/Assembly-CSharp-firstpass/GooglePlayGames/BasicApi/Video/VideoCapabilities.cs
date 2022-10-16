using System;
using System.Linq;
using System.Runtime.CompilerServices;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Video
{
	public class VideoCapabilities
	{
		private bool mIsCameraSupported;

		private bool mIsMicSupported;

		private bool mIsWriteStorageSupported;

		private bool[] mCaptureModesSupported;

		private bool[] mQualityLevelsSupported;

		[CompilerGenerated]
		private static Func<bool, string> _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		private static Func<bool, string> _003C_003Ef__am_0024cache1;

		public bool IsCameraSupported
		{
			get
			{
				return mIsCameraSupported;
			}
		}

		public bool IsMicSupported
		{
			get
			{
				return mIsMicSupported;
			}
		}

		public bool IsWriteStorageSupported
		{
			get
			{
				return mIsWriteStorageSupported;
			}
		}

		internal VideoCapabilities(bool isCameraSupported, bool isMicSupported, bool isWriteStorageSupported, bool[] captureModesSupported, bool[] qualityLevelsSupported)
		{
			mIsCameraSupported = isCameraSupported;
			mIsMicSupported = isMicSupported;
			mIsWriteStorageSupported = isWriteStorageSupported;
			mCaptureModesSupported = captureModesSupported;
			mQualityLevelsSupported = qualityLevelsSupported;
		}

		public bool SupportsCaptureMode(VideoCaptureMode captureMode)
		{
			if (captureMode != VideoCaptureMode.Unknown)
			{
				return mCaptureModesSupported[(int)captureMode];
			}
			Logger.w("SupportsCaptureMode called with an unknown captureMode.");
			return false;
		}

		public bool SupportsQualityLevel(VideoQualityLevel qualityLevel)
		{
			if (qualityLevel != VideoQualityLevel.Unknown)
			{
				return mQualityLevelsSupported[(int)qualityLevel];
			}
			Logger.w("SupportsCaptureMode called with an unknown qualityLevel.");
			return false;
		}

		public override string ToString()
		{
			object[] obj = new object[5] { mIsCameraSupported, mIsMicSupported, mIsWriteStorageSupported, null, null };
			bool[] source = mCaptureModesSupported;
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003CToString_003Em__0;
			}
			obj[3] = string.Join(",", source.Select(_003C_003Ef__am_0024cache0).ToArray());
			bool[] source2 = mQualityLevelsSupported;
			if (_003C_003Ef__am_0024cache1 == null)
			{
				_003C_003Ef__am_0024cache1 = _003CToString_003Em__1;
			}
			obj[4] = string.Join(",", source2.Select(_003C_003Ef__am_0024cache1).ToArray());
			return string.Format("[VideoCapabilities: mIsCameraSupported={0}, mIsMicSupported={1}, mIsWriteStorageSupported={2}, mCaptureModesSupported={3}, mQualityLevelsSupported={4}]", obj);
		}

		[CompilerGenerated]
		private static string _003CToString_003Em__0(bool p)
		{
			return p.ToString();
		}

		[CompilerGenerated]
		private static string _003CToString_003Em__1(bool p)
		{
			return p.ToString();
		}
	}
}
