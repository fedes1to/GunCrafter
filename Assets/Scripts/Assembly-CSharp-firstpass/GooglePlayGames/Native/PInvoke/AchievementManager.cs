using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class AchievementManager
	{
		internal class FetchResponse : BaseReferenceHolder
		{
			internal FetchResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchResponse_GetStatus(SelfPtr());
			}

			internal NativeAchievement Achievement()
			{
				IntPtr selfPointer = GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchResponse_GetData(SelfPtr());
				return new NativeAchievement(selfPointer);
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchResponse_Dispose(selfPointer);
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

		internal class FetchAllResponse : BaseReferenceHolder, IEnumerable<NativeAchievement>, IEnumerable
		{
			internal FetchAllResponse(IntPtr selfPointer)
				: base(selfPointer)
			{
			}

			internal CommonErrorStatus.ResponseStatus Status()
			{
				return GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchAllResponse_GetStatus(SelfPtr());
			}

			private UIntPtr Length()
			{
				return GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchAllResponse_GetData_Length(SelfPtr());
			}

			private NativeAchievement GetElement(UIntPtr index)
			{
				if (index.ToUInt64() >= Length().ToUInt64())
				{
					throw new ArgumentOutOfRangeException();
				}
				return new NativeAchievement(GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchAllResponse_GetData_GetElement(SelfPtr(), index));
			}

			public IEnumerator<NativeAchievement> GetEnumerator()
			{
				return PInvokeUtilities.ToEnumerator(GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchAllResponse_GetData_Length(SelfPtr()), _003CGetEnumerator_003Em__0);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			protected override void CallDispose(HandleRef selfPointer)
			{
				GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchAllResponse_Dispose(selfPointer);
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
			private NativeAchievement _003CGetEnumerator_003Em__0(UIntPtr index)
			{
				return GetElement(index);
			}
		}

		private readonly GameServices mServices;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.AchievementManager.ShowAllUICallback _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static Func<IntPtr, FetchAllResponse> _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.AchievementManager.FetchAllCallback _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static Func<IntPtr, FetchResponse> _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.AchievementManager.FetchCallback _003C_003Ef__mg_0024cache4;

		internal AchievementManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void ShowAllUI(Action<CommonErrorStatus.UIStatus> callback)
		{
			Misc.CheckNotNull(callback);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = Callbacks.InternalShowUICallback;
			}
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_ShowAllUI(self, _003C_003Ef__mg_0024cache0, Callbacks.ToIntPtr(callback));
		}

		internal void FetchAll(Action<FetchAllResponse> callback)
		{
			Misc.CheckNotNull(callback);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = InternalFetchAllCallback;
			}
			GooglePlayGames.Native.Cwrapper.AchievementManager.FetchAllCallback callback2 = _003C_003Ef__mg_0024cache2;
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = FetchAllResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_FetchAll(self, Types.DataSource.CACHE_OR_NETWORK, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache1));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.AchievementManager.FetchAllCallback))]
		private static void InternalFetchAllCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("AchievementManager#InternalFetchAllCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void Fetch(string achId, Action<FetchResponse> callback)
		{
			Misc.CheckNotNull(achId);
			Misc.CheckNotNull(callback);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = InternalFetchCallback;
			}
			GooglePlayGames.Native.Cwrapper.AchievementManager.FetchCallback callback2 = _003C_003Ef__mg_0024cache4;
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = FetchResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_Fetch(self, Types.DataSource.CACHE_OR_NETWORK, achId, callback2, Callbacks.ToIntPtr(callback, _003C_003Ef__mg_0024cache3));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.AchievementManager.FetchCallback))]
		private static void InternalFetchCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("AchievementManager#InternalFetchCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void Increment(string achievementId, uint numSteps)
		{
			Misc.CheckNotNull(achievementId);
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_Increment(mServices.AsHandle(), achievementId, numSteps);
		}

		internal void SetStepsAtLeast(string achivementId, uint numSteps)
		{
			Misc.CheckNotNull(achivementId);
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_SetStepsAtLeast(mServices.AsHandle(), achivementId, numSteps);
		}

		internal void Reveal(string achievementId)
		{
			Misc.CheckNotNull(achievementId);
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_Reveal(mServices.AsHandle(), achievementId);
		}

		internal void Unlock(string achievementId)
		{
			Misc.CheckNotNull(achievementId);
			GooglePlayGames.Native.Cwrapper.AchievementManager.AchievementManager_Unlock(mServices.AsHandle(), achievementId);
		}
	}
}
