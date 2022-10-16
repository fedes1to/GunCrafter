using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using UnityEngine;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NearbyConnectionsManager : BaseReferenceHolder
	{
		private static readonly string sServiceId = ReadServiceId();

		[CompilerGenerated]
		private static Func<IntPtr, NativeStartAdvertisingResult> _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static Func<IntPtr, NativeConnectionRequest> _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static NearbyConnectionTypes.StartAdvertisingCallback _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static NearbyConnectionTypes.ConnectionRequestCallback _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static Func<NativeAppIdentifier, IntPtr> _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		private static Func<IntPtr, NativeConnectionResponse> _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static NearbyConnectionTypes.ConnectionResponseCallback _003C_003Ef__mg_0024cache5;

		public string AppBundleId
		{
			get
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
					return @static.Call<string>("getPackageName", new object[0]);
				}
			}
		}

		public static string ServiceId
		{
			get
			{
				return sServiceId;
			}
		}

		internal NearbyConnectionsManager(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			NearbyConnections.NearbyConnections_Dispose(selfPointer);
		}

		internal void SendUnreliable(string remoteEndpointId, byte[] payload)
		{
			NearbyConnections.NearbyConnections_SendUnreliableMessage(SelfPtr(), remoteEndpointId, payload, new UIntPtr((ulong)payload.Length));
		}

		internal void SendReliable(string remoteEndpointId, byte[] payload)
		{
			NearbyConnections.NearbyConnections_SendReliableMessage(SelfPtr(), remoteEndpointId, payload, new UIntPtr((ulong)payload.Length));
		}

		internal void StartAdvertising(string name, List<NativeAppIdentifier> appIds, long advertisingDuration, Action<long, NativeStartAdvertisingResult> advertisingCallback, Action<long, NativeConnectionRequest> connectionRequestCallback)
		{
			HandleRef self = SelfPtr();
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003CStartAdvertising_003Em__0;
			}
			IntPtr[] app_identifiers = appIds.Select(_003C_003Ef__am_0024cache0).ToArray();
			UIntPtr app_identifiers_size = new UIntPtr((ulong)appIds.Count);
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = InternalStartAdvertisingCallback;
			}
			NearbyConnectionTypes.StartAdvertisingCallback start_advertising_callback = _003C_003Ef__mg_0024cache2;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = NativeStartAdvertisingResult.FromPointer;
			}
			IntPtr start_advertising_callback_arg = Callbacks.ToIntPtr(advertisingCallback, _003C_003Ef__mg_0024cache0);
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalConnectionRequestCallback;
			}
			NearbyConnectionTypes.ConnectionRequestCallback request_callback = _003C_003Ef__mg_0024cache3;
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = NativeConnectionRequest.FromPointer;
			}
			NearbyConnections.NearbyConnections_StartAdvertising(self, name, app_identifiers, app_identifiers_size, advertisingDuration, start_advertising_callback, start_advertising_callback_arg, request_callback, Callbacks.ToIntPtr(connectionRequestCallback, _003C_003Ef__mg_0024cache1));
		}

		[MonoPInvokeCallback(typeof(NearbyConnectionTypes.StartAdvertisingCallback))]
		private static void InternalStartAdvertisingCallback(long id, IntPtr result, IntPtr userData)
		{
			Callbacks.PerformInternalCallback("NearbyConnectionsManager#InternalStartAdvertisingCallback", Callbacks.Type.Permanent, id, result, userData);
		}

		[MonoPInvokeCallback(typeof(NearbyConnectionTypes.ConnectionRequestCallback))]
		private static void InternalConnectionRequestCallback(long id, IntPtr result, IntPtr userData)
		{
			Callbacks.PerformInternalCallback("NearbyConnectionsManager#InternalConnectionRequestCallback", Callbacks.Type.Permanent, id, result, userData);
		}

		internal void StopAdvertising()
		{
			NearbyConnections.NearbyConnections_StopAdvertising(SelfPtr());
		}

		internal void SendConnectionRequest(string name, string remoteEndpointId, byte[] payload, Action<long, NativeConnectionResponse> callback, NativeMessageListenerHelper listener)
		{
			HandleRef self = SelfPtr();
			UIntPtr payload_size = new UIntPtr((ulong)payload.Length);
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = InternalConnectResponseCallback;
			}
			NearbyConnectionTypes.ConnectionResponseCallback callback2 = _003C_003Ef__mg_0024cache5;
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = NativeConnectionResponse.FromPointer;
			}
			NearbyConnections.NearbyConnections_SendConnectionRequest(self, name, remoteEndpointId, payload, payload_size, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache4), listener.AsPointer());
		}

		[MonoPInvokeCallback(typeof(NearbyConnectionTypes.ConnectionResponseCallback))]
		private static void InternalConnectResponseCallback(long localClientId, IntPtr response, IntPtr userData)
		{
			Callbacks.PerformInternalCallback("NearbyConnectionManager#InternalConnectResponseCallback", Callbacks.Type.Temporary, localClientId, response, userData);
		}

		internal void AcceptConnectionRequest(string remoteEndpointId, byte[] payload, NativeMessageListenerHelper listener)
		{
			NearbyConnections.NearbyConnections_AcceptConnectionRequest(SelfPtr(), remoteEndpointId, payload, new UIntPtr((ulong)payload.Length), listener.AsPointer());
		}

		internal void DisconnectFromEndpoint(string remoteEndpointId)
		{
			NearbyConnections.NearbyConnections_Disconnect(SelfPtr(), remoteEndpointId);
		}

		internal void StopAllConnections()
		{
			NearbyConnections.NearbyConnections_Stop(SelfPtr());
		}

		internal void StartDiscovery(string serviceId, long duration, NativeEndpointDiscoveryListenerHelper listener)
		{
			NearbyConnections.NearbyConnections_StartDiscovery(SelfPtr(), serviceId, duration, listener.AsPointer());
		}

		internal void StopDiscovery(string serviceId)
		{
			NearbyConnections.NearbyConnections_StopDiscovery(SelfPtr(), serviceId);
		}

		internal void RejectConnectionRequest(string remoteEndpointId)
		{
			NearbyConnections.NearbyConnections_RejectConnectionRequest(SelfPtr(), remoteEndpointId);
		}

		internal void Shutdown()
		{
			NearbyConnections.NearbyConnections_Stop(SelfPtr());
		}

		internal string LocalEndpointId()
		{
			return PInvokeUtilities.OutParamsToString(_003CLocalEndpointId_003Em__1);
		}

		internal string LocalDeviceId()
		{
			return PInvokeUtilities.OutParamsToString(_003CLocalDeviceId_003Em__2);
		}

		internal static string ReadServiceId()
		{
			Debug.Log("Initializing ServiceId property!!!!");
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				using (AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					string text = androidJavaObject.Call<string>("getPackageName", new object[0]);
					AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("getPackageManager", new object[0]);
					AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("getApplicationInfo", new object[2] { text, 128 });
					AndroidJavaObject androidJavaObject4 = androidJavaObject3.Get<AndroidJavaObject>("metaData");
					string text2 = androidJavaObject4.Call<string>("getString", new object[1] { "com.google.android.gms.nearby.connection.SERVICE_ID" });
					Debug.Log("SystemId from Manifest: " + text2);
					return text2;
				}
			}
		}

		[CompilerGenerated]
		private static IntPtr _003CStartAdvertising_003Em__0(NativeAppIdentifier id)
		{
			return id.AsPointer();
		}

		[CompilerGenerated]
		private UIntPtr _003CLocalEndpointId_003Em__1(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnections.NearbyConnections_GetLocalEndpointId(SelfPtr(), out_arg, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003CLocalDeviceId_003Em__2(byte[] out_arg, UIntPtr out_size)
		{
			return NearbyConnections.NearbyConnections_GetLocalDeviceId(SelfPtr(), out_arg, out_size);
		}
	}
}
