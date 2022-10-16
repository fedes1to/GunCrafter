using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal class NativeNearbyConnectionsClient : INearbyConnectionClient
	{
		protected class OnGameThreadMessageListener : IMessageListener
		{
			[CompilerGenerated]
			private sealed class _003COnMessageReceived_003Ec__AnonStorey0
			{
				internal string remoteEndpointId;

				internal byte[] data;

				internal bool isReliableMessage;

				internal OnGameThreadMessageListener _0024this;

				internal void _003C_003Em__0()
				{
					_0024this.mListener.OnMessageReceived(remoteEndpointId, data, isReliableMessage);
				}
			}

			[CompilerGenerated]
			private sealed class _003COnRemoteEndpointDisconnected_003Ec__AnonStorey1
			{
				internal string remoteEndpointId;

				internal OnGameThreadMessageListener _0024this;

				internal void _003C_003Em__0()
				{
					_0024this.mListener.OnRemoteEndpointDisconnected(remoteEndpointId);
				}
			}

			private readonly IMessageListener mListener;

			public OnGameThreadMessageListener(IMessageListener listener)
			{
				mListener = Misc.CheckNotNull(listener);
			}

			public void OnMessageReceived(string remoteEndpointId, byte[] data, bool isReliableMessage)
			{
				_003COnMessageReceived_003Ec__AnonStorey0 _003COnMessageReceived_003Ec__AnonStorey = new _003COnMessageReceived_003Ec__AnonStorey0();
				_003COnMessageReceived_003Ec__AnonStorey.remoteEndpointId = remoteEndpointId;
				_003COnMessageReceived_003Ec__AnonStorey.data = data;
				_003COnMessageReceived_003Ec__AnonStorey.isReliableMessage = isReliableMessage;
				_003COnMessageReceived_003Ec__AnonStorey._0024this = this;
				PlayGamesHelperObject.RunOnGameThread(_003COnMessageReceived_003Ec__AnonStorey._003C_003Em__0);
			}

			public void OnRemoteEndpointDisconnected(string remoteEndpointId)
			{
				_003COnRemoteEndpointDisconnected_003Ec__AnonStorey1 _003COnRemoteEndpointDisconnected_003Ec__AnonStorey = new _003COnRemoteEndpointDisconnected_003Ec__AnonStorey1();
				_003COnRemoteEndpointDisconnected_003Ec__AnonStorey.remoteEndpointId = remoteEndpointId;
				_003COnRemoteEndpointDisconnected_003Ec__AnonStorey._0024this = this;
				PlayGamesHelperObject.RunOnGameThread(_003COnRemoteEndpointDisconnected_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		protected class OnGameThreadDiscoveryListener : IDiscoveryListener
		{
			[CompilerGenerated]
			private sealed class _003COnEndpointFound_003Ec__AnonStorey0
			{
				internal EndpointDetails discoveredEndpoint;

				internal OnGameThreadDiscoveryListener _0024this;

				internal void _003C_003Em__0()
				{
					_0024this.mListener.OnEndpointFound(discoveredEndpoint);
				}
			}

			[CompilerGenerated]
			private sealed class _003COnEndpointLost_003Ec__AnonStorey1
			{
				internal string lostEndpointId;

				internal OnGameThreadDiscoveryListener _0024this;

				internal void _003C_003Em__0()
				{
					_0024this.mListener.OnEndpointLost(lostEndpointId);
				}
			}

			private readonly IDiscoveryListener mListener;

			public OnGameThreadDiscoveryListener(IDiscoveryListener listener)
			{
				mListener = Misc.CheckNotNull(listener);
			}

			public void OnEndpointFound(EndpointDetails discoveredEndpoint)
			{
				_003COnEndpointFound_003Ec__AnonStorey0 _003COnEndpointFound_003Ec__AnonStorey = new _003COnEndpointFound_003Ec__AnonStorey0();
				_003COnEndpointFound_003Ec__AnonStorey.discoveredEndpoint = discoveredEndpoint;
				_003COnEndpointFound_003Ec__AnonStorey._0024this = this;
				PlayGamesHelperObject.RunOnGameThread(_003COnEndpointFound_003Ec__AnonStorey._003C_003Em__0);
			}

			public void OnEndpointLost(string lostEndpointId)
			{
				_003COnEndpointLost_003Ec__AnonStorey1 _003COnEndpointLost_003Ec__AnonStorey = new _003COnEndpointLost_003Ec__AnonStorey1();
				_003COnEndpointLost_003Ec__AnonStorey.lostEndpointId = lostEndpointId;
				_003COnEndpointLost_003Ec__AnonStorey._0024this = this;
				PlayGamesHelperObject.RunOnGameThread(_003COnEndpointLost_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CStartAdvertising_003Ec__AnonStorey0
		{
			internal Action<AdvertisingResult> resultCallback;

			internal Action<ConnectionRequest> requestCallback;

			internal void _003C_003Em__0(long localClientId, NativeStartAdvertisingResult result)
			{
				resultCallback(result.AsResult());
			}

			internal void _003C_003Em__1(long localClientId, NativeConnectionRequest request)
			{
				requestCallback(request.AsRequest());
			}
		}

		[CompilerGenerated]
		private sealed class _003CSendConnectionRequest_003Ec__AnonStorey1
		{
			internal Action<ConnectionResponse> responseCallback;

			internal void _003C_003Em__0(long localClientId, NativeConnectionResponse response)
			{
				responseCallback(response.AsResponse(localClientId));
			}
		}

		[CompilerGenerated]
		private sealed class _003CToMessageListener_003Ec__AnonStorey2
		{
			internal IMessageListener listener;

			internal void _003C_003Em__0(long localClientId, string endpointId, byte[] data, bool isReliable)
			{
				listener.OnMessageReceived(endpointId, data, isReliable);
			}

			internal void _003C_003Em__1(long localClientId, string endpointId)
			{
				listener.OnRemoteEndpointDisconnected(endpointId);
			}
		}

		[CompilerGenerated]
		private sealed class _003CToDiscoveryListener_003Ec__AnonStorey3
		{
			internal IDiscoveryListener listener;

			internal void _003C_003Em__0(long localClientId, NativeEndpointDetails endpoint)
			{
				listener.OnEndpointFound(endpoint.ToDetails());
			}

			internal void _003C_003Em__1(long localClientId, string lostEndpointId)
			{
				listener.OnEndpointLost(lostEndpointId);
			}
		}

		private readonly NearbyConnectionsManager mManager;

		[CompilerGenerated]
		private static Func<string, NativeAppIdentifier> _003C_003Ef__mg_0024cache0;

		internal NativeNearbyConnectionsClient(NearbyConnectionsManager manager)
		{
			mManager = Misc.CheckNotNull(manager);
		}

		public int MaxUnreliableMessagePayloadLength()
		{
			return 1168;
		}

		public int MaxReliableMessagePayloadLength()
		{
			return 4096;
		}

		public void SendReliable(List<string> recipientEndpointIds, byte[] payload)
		{
			InternalSend(recipientEndpointIds, payload, true);
		}

		public void SendUnreliable(List<string> recipientEndpointIds, byte[] payload)
		{
			InternalSend(recipientEndpointIds, payload, false);
		}

		private void InternalSend(List<string> recipientEndpointIds, byte[] payload, bool isReliable)
		{
			if (recipientEndpointIds == null)
			{
				throw new ArgumentNullException("recipientEndpointIds");
			}
			if (payload == null)
			{
				throw new ArgumentNullException("payload");
			}
			if (recipientEndpointIds.Contains(null))
			{
				throw new InvalidOperationException("Cannot send a message to a null recipient");
			}
			if (recipientEndpointIds.Count == 0)
			{
				Logger.w("Attempted to send a reliable message with no recipients");
				return;
			}
			if (isReliable)
			{
				if (payload.Length > MaxReliableMessagePayloadLength())
				{
					throw new InvalidOperationException("cannot send more than " + MaxReliableMessagePayloadLength() + " bytes");
				}
			}
			else if (payload.Length > MaxUnreliableMessagePayloadLength())
			{
				throw new InvalidOperationException("cannot send more than " + MaxUnreliableMessagePayloadLength() + " bytes");
			}
			foreach (string recipientEndpointId in recipientEndpointIds)
			{
				if (isReliable)
				{
					mManager.SendReliable(recipientEndpointId, payload);
				}
				else
				{
					mManager.SendUnreliable(recipientEndpointId, payload);
				}
			}
		}

		public void StartAdvertising(string name, List<string> appIdentifiers, TimeSpan? advertisingDuration, Action<AdvertisingResult> resultCallback, Action<ConnectionRequest> requestCallback)
		{
			_003CStartAdvertising_003Ec__AnonStorey0 _003CStartAdvertising_003Ec__AnonStorey = new _003CStartAdvertising_003Ec__AnonStorey0();
			_003CStartAdvertising_003Ec__AnonStorey.resultCallback = resultCallback;
			_003CStartAdvertising_003Ec__AnonStorey.requestCallback = requestCallback;
			Misc.CheckNotNull(appIdentifiers, "appIdentifiers");
			Misc.CheckNotNull(_003CStartAdvertising_003Ec__AnonStorey.resultCallback, "resultCallback");
			Misc.CheckNotNull(_003CStartAdvertising_003Ec__AnonStorey.requestCallback, "connectionRequestCallback");
			if (advertisingDuration.HasValue && advertisingDuration.Value.Ticks < 0)
			{
				throw new InvalidOperationException("advertisingDuration must be positive");
			}
			_003CStartAdvertising_003Ec__AnonStorey.resultCallback = Callbacks.AsOnGameThreadCallback(_003CStartAdvertising_003Ec__AnonStorey.resultCallback);
			_003CStartAdvertising_003Ec__AnonStorey.requestCallback = Callbacks.AsOnGameThreadCallback(_003CStartAdvertising_003Ec__AnonStorey.requestCallback);
			NearbyConnectionsManager nearbyConnectionsManager = mManager;
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = NativeAppIdentifier.FromString;
			}
			nearbyConnectionsManager.StartAdvertising(name, appIdentifiers.Select(_003C_003Ef__mg_0024cache0).ToList(), ToTimeoutMillis(advertisingDuration), _003CStartAdvertising_003Ec__AnonStorey._003C_003Em__0, _003CStartAdvertising_003Ec__AnonStorey._003C_003Em__1);
		}

		private static long ToTimeoutMillis(TimeSpan? span)
		{
			return (!span.HasValue) ? 0 : PInvokeUtilities.ToMilliseconds(span.Value);
		}

		public void StopAdvertising()
		{
			mManager.StopAdvertising();
		}

		public void SendConnectionRequest(string name, string remoteEndpointId, byte[] payload, Action<ConnectionResponse> responseCallback, IMessageListener listener)
		{
			_003CSendConnectionRequest_003Ec__AnonStorey1 _003CSendConnectionRequest_003Ec__AnonStorey = new _003CSendConnectionRequest_003Ec__AnonStorey1();
			_003CSendConnectionRequest_003Ec__AnonStorey.responseCallback = responseCallback;
			Misc.CheckNotNull(remoteEndpointId, "remoteEndpointId");
			Misc.CheckNotNull(payload, "payload");
			Misc.CheckNotNull(_003CSendConnectionRequest_003Ec__AnonStorey.responseCallback, "responseCallback");
			Misc.CheckNotNull(listener, "listener");
			_003CSendConnectionRequest_003Ec__AnonStorey.responseCallback = Callbacks.AsOnGameThreadCallback(_003CSendConnectionRequest_003Ec__AnonStorey.responseCallback);
			using (NativeMessageListenerHelper listener2 = ToMessageListener(listener))
			{
				mManager.SendConnectionRequest(name, remoteEndpointId, payload, _003CSendConnectionRequest_003Ec__AnonStorey._003C_003Em__0, listener2);
			}
		}

		private static NativeMessageListenerHelper ToMessageListener(IMessageListener listener)
		{
			_003CToMessageListener_003Ec__AnonStorey2 _003CToMessageListener_003Ec__AnonStorey = new _003CToMessageListener_003Ec__AnonStorey2();
			_003CToMessageListener_003Ec__AnonStorey.listener = listener;
			_003CToMessageListener_003Ec__AnonStorey.listener = new OnGameThreadMessageListener(_003CToMessageListener_003Ec__AnonStorey.listener);
			NativeMessageListenerHelper nativeMessageListenerHelper = new NativeMessageListenerHelper();
			nativeMessageListenerHelper.SetOnMessageReceivedCallback(_003CToMessageListener_003Ec__AnonStorey._003C_003Em__0);
			nativeMessageListenerHelper.SetOnDisconnectedCallback(_003CToMessageListener_003Ec__AnonStorey._003C_003Em__1);
			return nativeMessageListenerHelper;
		}

		public void AcceptConnectionRequest(string remoteEndpointId, byte[] payload, IMessageListener listener)
		{
			Misc.CheckNotNull(remoteEndpointId, "remoteEndpointId");
			Misc.CheckNotNull(payload, "payload");
			Misc.CheckNotNull(listener, "listener");
			Logger.d("Calling AcceptConncectionRequest");
			mManager.AcceptConnectionRequest(remoteEndpointId, payload, ToMessageListener(listener));
			Logger.d("Called!");
		}

		public void StartDiscovery(string serviceId, TimeSpan? advertisingTimeout, IDiscoveryListener listener)
		{
			Misc.CheckNotNull(serviceId, "serviceId");
			Misc.CheckNotNull(listener, "listener");
			using (NativeEndpointDiscoveryListenerHelper listener2 = ToDiscoveryListener(listener))
			{
				mManager.StartDiscovery(serviceId, ToTimeoutMillis(advertisingTimeout), listener2);
			}
		}

		private static NativeEndpointDiscoveryListenerHelper ToDiscoveryListener(IDiscoveryListener listener)
		{
			_003CToDiscoveryListener_003Ec__AnonStorey3 _003CToDiscoveryListener_003Ec__AnonStorey = new _003CToDiscoveryListener_003Ec__AnonStorey3();
			_003CToDiscoveryListener_003Ec__AnonStorey.listener = listener;
			_003CToDiscoveryListener_003Ec__AnonStorey.listener = new OnGameThreadDiscoveryListener(_003CToDiscoveryListener_003Ec__AnonStorey.listener);
			NativeEndpointDiscoveryListenerHelper nativeEndpointDiscoveryListenerHelper = new NativeEndpointDiscoveryListenerHelper();
			nativeEndpointDiscoveryListenerHelper.SetOnEndpointFound(_003CToDiscoveryListener_003Ec__AnonStorey._003C_003Em__0);
			nativeEndpointDiscoveryListenerHelper.SetOnEndpointLostCallback(_003CToDiscoveryListener_003Ec__AnonStorey._003C_003Em__1);
			return nativeEndpointDiscoveryListenerHelper;
		}

		public void StopDiscovery(string serviceId)
		{
			Misc.CheckNotNull(serviceId, "serviceId");
			mManager.StopDiscovery(serviceId);
		}

		public void RejectConnectionRequest(string requestingEndpointId)
		{
			Misc.CheckNotNull(requestingEndpointId, "requestingEndpointId");
			mManager.RejectConnectionRequest(requestingEndpointId);
		}

		public void DisconnectFromEndpoint(string remoteEndpointId)
		{
			mManager.DisconnectFromEndpoint(remoteEndpointId);
		}

		public void StopAllConnections()
		{
			mManager.StopAllConnections();
		}

		public string LocalEndpointId()
		{
			return mManager.LocalEndpointId();
		}

		public string LocalDeviceId()
		{
			return mManager.LocalDeviceId();
		}

		public string GetAppBundleId()
		{
			return mManager.AppBundleId;
		}

		public string GetServiceId()
		{
			return NearbyConnectionsManager.ServiceId;
		}
	}
}
