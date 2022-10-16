using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeAppIdentifier : BaseReferenceHolder
	{
		internal NativeAppIdentifier(IntPtr pointer)
			: base(pointer)
		{
		}

		[DllImport("gpg")]
		internal static extern IntPtr NearbyUtils_ConstructAppIdentifier(string appId);

		internal string Id()
		{
			return PInvokeUtilities.OutParamsToString(_003CId_003Em__0);
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnectionTypes.AppIdentifier_Dispose(selfPointer);
		}

		internal static NativeAppIdentifier FromString(string appId)
		{
			return new NativeAppIdentifier(NearbyUtils_ConstructAppIdentifier(appId));
		}

		[CompilerGenerated]
		private UIntPtr _003CId_003Em__0(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnectionTypes.AppIdentifier_GetIdentifier(SelfPtr(), out_arg, out_size);
		}
	}
}
