using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi
{
	public struct PlayGamesClientConfiguration
	{
		public class Builder
		{
			private bool mEnableSaveGames;

			private List<string> mScopes;

			private bool mHidePopups;

			private bool mRequestAuthCode;

			private bool mForceRefresh;

			private bool mRequestEmail;

			private bool mRequestIdToken;

			private string mAccountName;

			private InvitationReceivedDelegate mInvitationDelegate;

			private MatchDelegate mMatchDelegate;

			[CompilerGenerated]
			private static InvitationReceivedDelegate _003C_003Ef__am_0024cache0;

			[CompilerGenerated]
			private static MatchDelegate _003C_003Ef__am_0024cache1;

			public Builder()
			{
				if (_003C_003Ef__am_0024cache0 == null)
				{
					_003C_003Ef__am_0024cache0 = _003CmInvitationDelegate_003Em__0;
				}
				mInvitationDelegate = _003C_003Ef__am_0024cache0;
				if (_003C_003Ef__am_0024cache1 == null)
				{
					_003C_003Ef__am_0024cache1 = _003CmMatchDelegate_003Em__1;
				}
				mMatchDelegate = _003C_003Ef__am_0024cache1;
//				base._002Ector();
			}

			public Builder EnableSavedGames()
			{
				mEnableSaveGames = true;
				return this;
			}

			public Builder EnableHidePopups()
			{
				mHidePopups = true;
				return this;
			}

			public Builder RequestServerAuthCode(bool forceRefresh)
			{
				mRequestAuthCode = true;
				mForceRefresh = forceRefresh;
				return this;
			}

			public Builder RequestEmail()
			{
				mRequestEmail = true;
				return this;
			}

			public Builder RequestIdToken()
			{
				mRequestIdToken = true;
				return this;
			}

			public Builder SetAccountName(string accountName)
			{
				mAccountName = accountName;
				return this;
			}

			public Builder AddOauthScope(string scope)
			{
				if (mScopes == null)
				{
					mScopes = new List<string>();
				}
				mScopes.Add(scope);
				return this;
			}

			public Builder WithInvitationDelegate(InvitationReceivedDelegate invitationDelegate)
			{
				mInvitationDelegate = Misc.CheckNotNull(invitationDelegate);
				return this;
			}

			public Builder WithMatchDelegate(MatchDelegate matchDelegate)
			{
				mMatchDelegate = Misc.CheckNotNull(matchDelegate);
				return this;
			}

			public PlayGamesClientConfiguration Build()
			{
				return new PlayGamesClientConfiguration(this);
			}

			internal bool HasEnableSaveGames()
			{
				return mEnableSaveGames;
			}

			internal bool IsRequestingAuthCode()
			{
				return mRequestAuthCode;
			}

			internal bool IsHidingPopups()
			{
				return mHidePopups;
			}

			internal bool IsForcingRefresh()
			{
				return mForceRefresh;
			}

			internal bool IsRequestingEmail()
			{
				return mRequestEmail;
			}

			internal bool IsRequestingIdToken()
			{
				return mRequestIdToken;
			}

			internal string GetAccountName()
			{
				return mAccountName;
			}

			internal string[] getScopes()
			{
				return (mScopes != null) ? mScopes.ToArray() : new string[0];
			}

			internal MatchDelegate GetMatchDelegate()
			{
				return mMatchDelegate;
			}

			internal InvitationReceivedDelegate GetInvitationDelegate()
			{
				return mInvitationDelegate;
			}

			[CompilerGenerated]
			private static void _003CmInvitationDelegate_003Em__0(Invitation P_0, bool P_1)
			{
			}

			[CompilerGenerated]
			private static void _003CmMatchDelegate_003Em__1(TurnBasedMatch P_0, bool P_1)
			{
			}
		}

		public static readonly PlayGamesClientConfiguration DefaultConfiguration = new Builder().Build();

		private readonly bool mEnableSavedGames;

		private readonly string[] mScopes;

		private readonly bool mRequestAuthCode;

		private readonly bool mForceRefresh;

		private readonly bool mHidePopups;

		private readonly bool mRequestEmail;

		private readonly bool mRequestIdToken;

		private readonly string mAccountName;

		private readonly InvitationReceivedDelegate mInvitationDelegate;

		private readonly MatchDelegate mMatchDelegate;

		public bool EnableSavedGames
		{
			get
			{
				return mEnableSavedGames;
			}
		}

		public bool IsHidingPopups
		{
			get
			{
				return mHidePopups;
			}
		}

		public bool IsRequestingAuthCode
		{
			get
			{
				return mRequestAuthCode;
			}
		}

		public bool IsForcingRefresh
		{
			get
			{
				return mForceRefresh;
			}
		}

		public bool IsRequestingEmail
		{
			get
			{
				return mRequestEmail;
			}
		}

		public bool IsRequestingIdToken
		{
			get
			{
				return mRequestIdToken;
			}
		}

		public string AccountName
		{
			get
			{
				return mAccountName;
			}
		}

		public string[] Scopes
		{
			get
			{
				return mScopes;
			}
		}

		public InvitationReceivedDelegate InvitationDelegate
		{
			get
			{
				return mInvitationDelegate;
			}
		}

		public MatchDelegate MatchDelegate
		{
			get
			{
				return mMatchDelegate;
			}
		}

		private PlayGamesClientConfiguration(Builder builder)
		{
			mEnableSavedGames = builder.HasEnableSaveGames();
			mInvitationDelegate = builder.GetInvitationDelegate();
			mMatchDelegate = builder.GetMatchDelegate();
			mScopes = builder.getScopes();
			mHidePopups = builder.IsHidingPopups();
			mRequestAuthCode = builder.IsRequestingAuthCode();
			mForceRefresh = builder.IsForcingRefresh();
			mRequestEmail = builder.IsRequestingEmail();
			mRequestIdToken = builder.IsRequestingIdToken();
			mAccountName = builder.GetAccountName();
		}
	}
}
