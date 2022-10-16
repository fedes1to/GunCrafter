using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeEndpointDetails : BaseReferenceHolder
	{
		internal NativeEndpointDetails(IntPtr pointer)
			: base(pointer)
		{
		}

		internal string EndpointId()
		{
			return PInvokeUtilities.OutParamsToString(_003CEndpointId_003Em__0);
		}

		internal string DeviceId()
		{
			return PInvokeUtilities.OutParamsToString(_003CDeviceId_003Em__1);
		}

		internal string Name()
		{
			return PInvokeUtilities.OutParamsToString(_003CName_003Em__2);
		}

		internal string ServiceId()
		{
			return PInvokeUtilities.OutParamsToString(_003CServiceId_003Em__3);
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnectionTypes.EndpointDetails_Dispose(selfPointer);
		}

		internal EndpointDetails ToDetails()
		{
			return new EndpointDetails(EndpointId(), DeviceId(), Name(), ServiceId());
		}

		internal static NativeEndpointDetails FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeEndpointDetails(pointer);
		}

		[CompilerGenerated]
		private UIntPtr _003CEndpointId_003Em__0(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnectionTypes.EndpointDetails_GetEndpointId(SelfPtr(), out_arg, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003CDeviceId_003Em__1(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnectionTypes.EndpointDetails_GetDeviceId(SelfPtr(), out_arg, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003CName_003Em__2(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnectionTypes.EndpointDetails_GetName(SelfPtr(), out_arg, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003CServiceId_003Em__3(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnectionTypes.EndpointDetails_GetServiceId(SelfPtr(), out_arg, out_size);
		}
	}
}
