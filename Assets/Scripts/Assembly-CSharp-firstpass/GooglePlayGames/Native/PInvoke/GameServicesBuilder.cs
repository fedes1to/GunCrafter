using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class GameServicesBuilder : BaseReferenceHolder
	{
		internal delegate void AuthFinishedCallback(Types.AuthOperation operation, CommonErrorStatus.AuthStatus status);

		internal delegate void AuthStartedCallback(Types.AuthOperation operation);

		[CompilerGenerated]
		private static Builder.OnAuthActionFinishedCallback _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static Builder.OnAuthActionStartedCallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Builder.OnTurnBasedMatchEventCallback _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static Builder.OnMultiplayerInvitationEventCallback _003C_003Ef__mg_0024cache3;

		private GameServicesBuilder(IntPtr selfPointer)
			: base(selfPointer)
		{
			InternalHooks.InternalHooks_ConfigureForUnityPlugin(SelfPtr(), "0.9.39a");
		}

		internal void SetOnAuthFinishedCallback(AuthFinishedCallback callback)
		{
			HandleRef self = SelfPtr();
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = InternalAuthFinishedCallback;
			}
			Builder.GameServices_Builder_SetOnAuthActionFinished(self, _003C_003Ef__mg_0024cache0, Callbacks.ToIntPtr(callback));
		}

		internal void EnableSnapshots()
		{
			Builder.GameServices_Builder_EnableSnapshots(SelfPtr());
		}

		internal void AddOauthScope(string scope)
		{
			Builder.GameServices_Builder_AddOauthScope(SelfPtr(), scope);
		}

		[MonoPInvokeCallback(typeof(Builder.OnAuthActionFinishedCallback))]
		private static void InternalAuthFinishedCallback(Types.AuthOperation op, CommonErrorStatus.AuthStatus status, IntPtr data)
		{
			AuthFinishedCallback authFinishedCallback = Callbacks.IntPtrToPermanentCallback<AuthFinishedCallback>(data);
			if (authFinishedCallback == null)
			{
				return;
			}
			try
			{
				authFinishedCallback(op, status);
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalAuthFinishedCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal void SetOnAuthStartedCallback(AuthStartedCallback callback)
		{
			HandleRef self = SelfPtr();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = InternalAuthStartedCallback;
			}
			Builder.GameServices_Builder_SetOnAuthActionStarted(self, _003C_003Ef__mg_0024cache1, Callbacks.ToIntPtr(callback));
		}

		[MonoPInvokeCallback(typeof(Builder.OnAuthActionStartedCallback))]
		private static void InternalAuthStartedCallback(Types.AuthOperation op, IntPtr data)
		{
			AuthStartedCallback authStartedCallback = Callbacks.IntPtrToPermanentCallback<AuthStartedCallback>(data);
			try
			{
				if (authStartedCallback != null)
				{
					authStartedCallback(op);
				}
			}
			catch (Exception ex)
			{
				Logger.e("Error encountered executing InternalAuthStartedCallback. Smothering to avoid passing exception into Native: " + ex);
			}
		}

		internal void SetShowConnectingPopup(bool flag)
		{
			Builder.GameServices_Builder_SetShowConnectingPopup(SelfPtr(), flag);
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			Builder.GameServices_Builder_Dispose(selfPointer);
		}

		[MonoPInvokeCallback(typeof(Builder.OnTurnBasedMatchEventCallback))]
		private static void InternalOnTurnBasedMatchEventCallback(Types.MultiplayerEvent eventType, string matchId, IntPtr match, IntPtr userData)
		{
			Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch> action = Callbacks.IntPtrToPermanentCallback<Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch>>(userData);
			using (NativeTurnBasedMatch arg = NativeTurnBasedMatch.FromPointer(match))
			{
				try
				{
					if (action != null)
					{
						action(eventType, matchId, arg);
					}
				}
				catch (Exception ex)
				{
					Logger.e("Error encountered executing InternalOnTurnBasedMatchEventCallback. Smothering to avoid passing exception into Native: " + ex);
				}
			}
		}

		internal void SetOnTurnBasedMatchEventCallback(Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch> callback)
		{
			IntPtr callback_arg = Callbacks.ToIntPtr(callback);
			HandleRef self = SelfPtr();
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = InternalOnTurnBasedMatchEventCallback;
			}
			Builder.GameServices_Builder_SetOnTurnBasedMatchEvent(self, _003C_003Ef__mg_0024cache2, callback_arg);
		}

		[MonoPInvokeCallback(typeof(Builder.OnMultiplayerInvitationEventCallback))]
		private static void InternalOnMultiplayerInvitationEventCallback(Types.MultiplayerEvent eventType, string matchId, IntPtr match, IntPtr userData)
		{
			Action<Types.MultiplayerEvent, string, MultiplayerInvitation> action = Callbacks.IntPtrToPermanentCallback<Action<Types.MultiplayerEvent, string, MultiplayerInvitation>>(userData);
			using (MultiplayerInvitation arg = MultiplayerInvitation.FromPointer(match))
			{
				try
				{
					if (action != null)
					{
						action(eventType, matchId, arg);
					}
				}
				catch (Exception ex)
				{
					Logger.e("Error encountered executing InternalOnMultiplayerInvitationEventCallback. Smothering to avoid passing exception into Native: " + ex);
				}
			}
		}

		internal void SetOnMultiplayerInvitationEventCallback(Action<Types.MultiplayerEvent, string, MultiplayerInvitation> callback)
		{
			IntPtr callback_arg = Callbacks.ToIntPtr(callback);
			HandleRef self = SelfPtr();
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalOnMultiplayerInvitationEventCallback;
			}
			Builder.GameServices_Builder_SetOnMultiplayerInvitationEvent(self, _003C_003Ef__mg_0024cache3, callback_arg);
		}

		internal GameServices Build(PlatformConfiguration configRef)
		{
			IntPtr selfPointer = Builder.GameServices_Builder_Create(SelfPtr(), HandleRef.ToIntPtr(configRef.AsHandle()));
			if (selfPointer.Equals(IntPtr.Zero))
			{
				throw new InvalidOperationException("There was an error creating a GameServices object. Check for log errors from GamesNativeSDK");
			}
			return new GameServices(selfPointer);
		}

		internal static GameServicesBuilder Create()
		{
			IntPtr selfPointer = Builder.GameServices_Builder_Construct();
			return new GameServicesBuilder(selfPointer);
		}
	}
}
