using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeRealTimeRoom : BaseReferenceHolder
	{
		internal NativeRealTimeRoom(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal string Id()
		{
			return PInvokeUtilities.OutParamsToString(_003CId_003Em__0);
		}

		internal IEnumerable<MultiplayerParticipant> Participants()
		{
			return PInvokeUtilities.ToEnumerable(RealTimeRoom.RealTimeRoom_Participants_Length(SelfPtr()), _003CParticipants_003Em__1);
		}

		internal uint ParticipantCount()
		{
			return RealTimeRoom.RealTimeRoom_Participants_Length(SelfPtr()).ToUInt32();
		}

		internal Types.RealTimeRoomStatus Status()
		{
			return RealTimeRoom.RealTimeRoom_Status(SelfPtr());
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			RealTimeRoom.RealTimeRoom_Dispose(selfPointer);
		}

		internal static NativeRealTimeRoom FromPointer(IntPtr selfPointer)
		{
			if (selfPointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeRealTimeRoom(selfPointer);
		}

		[CompilerGenerated]
		private UIntPtr _003CId_003Em__0(byte[] out_string, UIntPtr size)
		{
			return RealTimeRoom.RealTimeRoom_Id(SelfPtr(), out_string, size);
		}

		[CompilerGenerated]
		private MultiplayerParticipant _003CParticipants_003Em__1(UIntPtr index)
		{
			return new MultiplayerParticipant(RealTimeRoom.RealTimeRoom_Participants_GetElement(SelfPtr(), index));
		}
	}
}
