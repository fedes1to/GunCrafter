using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.Native.Cwrapper;

namespace GooglePlayGames.Native.PInvoke
{
	internal class NativeQuest : BaseReferenceHolder, IQuest
	{
		private volatile NativeQuestMilestone mCachedMilestone;

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

		public string BannerUrl
		{
			get
			{
				return PInvokeUtilities.OutParamsToString(_003Cget_BannerUrl_003Em__3);
			}
		}

		public string IconUrl
		{
			get
			{
				return PInvokeUtilities.OutParamsToString(_003Cget_IconUrl_003Em__4);
			}
		}

		public DateTime StartTime
		{
			get
			{
				return PInvokeUtilities.FromMillisSinceUnixEpoch(Quest.Quest_StartTime(SelfPtr()));
			}
		}

		public DateTime ExpirationTime
		{
			get
			{
				return PInvokeUtilities.FromMillisSinceUnixEpoch(Quest.Quest_ExpirationTime(SelfPtr()));
			}
		}

		public DateTime? AcceptedTime
		{
			get
			{
				long num = Quest.Quest_AcceptedTime(SelfPtr());
				if (num == 0)
				{
					return null;
				}
				return PInvokeUtilities.FromMillisSinceUnixEpoch(num);
			}
		}

		public IQuestMilestone Milestone
		{
			get
			{
				if (mCachedMilestone == null)
				{
					mCachedMilestone = NativeQuestMilestone.FromPointer(Quest.Quest_CurrentMilestone(SelfPtr()));
				}
				return mCachedMilestone;
			}
		}

		public QuestState State
		{
			get
			{
				Types.QuestState questState = Quest.Quest_State(SelfPtr());
				switch (questState)
				{
				case Types.QuestState.UPCOMING:
					return QuestState.Upcoming;
				case Types.QuestState.OPEN:
					return QuestState.Open;
				case Types.QuestState.ACCEPTED:
					return QuestState.Accepted;
				case Types.QuestState.COMPLETED:
					return QuestState.Completed;
				case Types.QuestState.EXPIRED:
					return QuestState.Expired;
				case Types.QuestState.FAILED:
					return QuestState.Failed;
				default:
					throw new InvalidOperationException("Unknown state: " + questState);
				}
			}
		}

		internal NativeQuest(IntPtr selfPointer)
			: base(selfPointer)
		{
		}

		internal bool Valid()
		{
			return Quest.Quest_Valid(SelfPtr());
		}

		protected override void CallDispose(HandleRef selfPointer)
		{
			Quest.Quest_Dispose(selfPointer);
		}

		public override string ToString()
		{
			if (IsDisposed())
			{
				return "[NativeQuest: DELETED]";
			}
			return string.Format("[NativeQuest: Id={0}, Name={1}, Description={2}, BannerUrl={3}, IconUrl={4}, State={5}, StartTime={6}, ExpirationTime={7}, AcceptedTime={8}]", Id, Name, Description, BannerUrl, IconUrl, State, StartTime, ExpirationTime, AcceptedTime);
		}

		internal static NativeQuest FromPointer(IntPtr pointer)
		{
			if (pointer.Equals(IntPtr.Zero))
			{
				return null;
			}
			return new NativeQuest(pointer);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_Id_003Em__0(byte[] out_string, UIntPtr out_size)
		{
			return Quest.Quest_Id(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_Name_003Em__1(byte[] out_string, UIntPtr out_size)
		{
			return Quest.Quest_Name(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_Description_003Em__2(byte[] out_string, UIntPtr out_size)
		{
			return Quest.Quest_Description(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_BannerUrl_003Em__3(byte[] out_string, UIntPtr out_size)
		{
			return Quest.Quest_BannerUrl(SelfPtr(), out_string, out_size);
		}

		[CompilerGenerated]
		private UIntPtr _003Cget_IconUrl_003Em__4(byte[] out_string, UIntPtr out_size)
		{
			return Quest.Quest_IconUrl(SelfPtr(), out_string, out_size);
		}
	}
}
