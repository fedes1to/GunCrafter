using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeEvent : BaseReferenceHolder, IEvent
	{
		public string Id
		{
			get
			{
				return PInvokeUtilities.OutParamsToString(_003Cget_Id_003Em__0);
			}
		}

		public string Name
		{
			get
			{
				return PInvokeUtilities.OutParamsToString(_003Cget_Name_003Em__1);
			}
		}

		public string Description
		{
			get
			{
				return PInvokeUtilities.OutParamsToString(_003Cget_Description_003Em__2);
			}
		}

		public string ImageUrl
		{
			get
			{
				return PInvokeUtilities.OutParamsToString(_003Cget_ImageUrl_003Em__3);
			}
		}

		public ulong CurrentCount
		{
			get
			{
				return Event.Event_Count(SelfPtr());
			}
		}

		public EventVisibility Visibility
		{
			get
			{
				Types.EventVisibility eventVisibility = Event.Event_Visibility(SelfPtr());
				switch (eventVisibility)
				{
				case Types.EventVisibility.HIDDEN:
					return EventVisibility.Hidden;
				case Types.EventVisibility.REVEALED:
					return EventVisibility.Revealed;
				default:
					throw new InvalidOperationException("Unknown visibility: " + eventVisibility);
				}
			}
		}

		internal NativeEvent(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			Event.Event_Dispose(selfPointer);
		}

		public override string ToString()
		{
			if (IsDisposed())
			{
				return "[NativeEvent: DELETED]";
			}
			return string.Format("[NativeEvent: Id={0}, Name={1}, Description={2}, ImageUrl={3}, CurrentCount={4}, Visibility={5}]", Id, Name, Description, ImageUrl, CurrentCount, Visibility);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_Id_003Em__0(byte[] out_string, UIntPtr out_size)
		{
			return Event.Event_Id(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_Name_003Em__1(byte[] out_string, UIntPtr out_size)
		{
			return Event.Event_Name(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_Description_003Em__2(byte[] out_string, UIntPtr out_size)
		{
			return Event.Event_Description(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_ImageUrl_003Em__3(byte[] out_string, UIntPtr out_size)
		{
			return Event.Event_ImageUrl(SelfPtr(), out_string, out_size);
		}
	}
}
