using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class TurnBasedMatchConfig : BaseReferenceHolder
	{
		[CompilerGenerated]
		private sealed class _003CPlayerIdAtIndex_003Ec__AnonStorey0
		{
			internal UIntPtr index;

			internal TurnBasedMatchConfig _0024this;

			internal UIntPtr _003C_003Em__0(byte[] out_string, UIntPtr size)
			{
				return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_PlayerIdsToInvite_GetElement(_0024this.SelfPtr(), index, out_string, size);
			}
		}

		internal TurnBasedMatchConfig(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		private string PlayerIdAtIndex(UIntPtr index)
		{
			_003CPlayerIdAtIndex_003Ec__AnonStorey0 _003CPlayerIdAtIndex_003Ec__AnonStorey = new _003CPlayerIdAtIndex_003Ec__AnonStorey0();
			_003CPlayerIdAtIndex_003Ec__AnonStorey.index = index;
			_003CPlayerIdAtIndex_003Ec__AnonStorey._0024this = this;
			return PInvokeUtilities.OutParamsToString(_003CPlayerIdAtIndex_003Ec__AnonStorey._003C_003Em__0);
		}

		internal IEnumerator<string> PlayerIdsToInvite()
		{
			return PInvokeUtilities.ToEnumerator(GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_PlayerIdsToInvite_Length(SelfPtr()), PlayerIdAtIndex);
		}

		internal uint Variant()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_Variant(SelfPtr());
		}

		internal long ExclusiveBitMask()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_ExclusiveBitMask(SelfPtr());
		}

		internal uint MinimumAutomatchingPlayers()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_MinimumAutomatchingPlayers(SelfPtr());
		}

		internal uint MaximumAutomatchingPlayers()
		{
			return GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_MaximumAutomatchingPlayers(SelfPtr());
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig.TurnBasedMatchConfig_Dispose(selfPointer);
		}
	}
}
