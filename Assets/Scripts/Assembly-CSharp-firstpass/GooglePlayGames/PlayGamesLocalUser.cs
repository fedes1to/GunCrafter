using System;
using System.Runtime.CompilerServices;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames
{
	public class PlayGamesLocalUser : PlayGamesUserProfile, ILocalUser, IUserProfile
	{
		[CompilerGenerated]
		private sealed class _003CGetStats_003Ec__AnonStorey0
		{
			internal Action<CommonStatusCodes, PlayerStats> callback;

			internal PlayGamesLocalUser _0024this;

			internal void _003C_003Em__0(CommonStatusCodes rc, PlayerStats stats)
			{
				_0024this.mStats = stats;
				callback(rc, stats);
			}
		}

		internal PlayGamesPlatform mPlatform;

		private string emailAddress;

		private PlayerStats mStats;

		public IUserProfile[] friends
		{
			get
			{
				return mPlatform.GetFriends();
			}
		}

		public bool authenticated
		{
			get
			{
				return mPlatform.IsAuthenticated();
			}
		}

		public bool underage
		{
			get
			{
				return true;
			}
		}

		public new string userName
		{
			get
			{
				string text = string.Empty;
				if (authenticated)
				{
					text = mPlatform.GetUserDisplayName();
					if (!base.userName.Equals(text))
					{
						ResetIdentity(text, mPlatform.GetUserId(), mPlatform.GetUserImageUrl());
					}
				}
				return text;
			}
		}

		public new string id
		{
			get
			{
				string text = string.Empty;
				if (authenticated)
				{
					text = mPlatform.GetUserId();
					if (!base.id.Equals(text))
					{
						ResetIdentity(mPlatform.GetUserDisplayName(), text, mPlatform.GetUserImageUrl());
					}
				}
				return text;
			}
		}

		public new bool isFriend
		{
			get
			{
				return true;
			}
		}

		public new UserState state
		{
			get
			{
				return UserState.Online;
			}
		}

		public new string AvatarURL
		{
			get
			{
				string text = string.Empty;
				if (authenticated)
				{
					text = mPlatform.GetUserImageUrl();
					if (!base.id.Equals(text))
					{
						ResetIdentity(mPlatform.GetUserDisplayName(), mPlatform.GetUserId(), text);
					}
				}
				return text;
			}
		}

		public string Email
		{
			get
			{
				if (authenticated && string.IsNullOrEmpty(emailAddress))
				{
					emailAddress = mPlatform.GetUserEmail();
					emailAddress = emailAddress ?? string.Empty;
				}
				return (!authenticated) ? string.Empty : emailAddress;
			}
		}

		internal PlayGamesLocalUser(PlayGamesPlatform plaf)
			: base("localUser", string.Empty, string.Empty)
		{
			mPlatform = plaf;
			emailAddress = null;
			mStats = null;
		}

		public void Authenticate(Action<bool> callback)
		{
			mPlatform.Authenticate(callback);
		}

		public void Authenticate(Action<bool, string> callback)
		{
			mPlatform.Authenticate(callback);
		}

		public void Authenticate(Action<bool> callback, bool silent)
		{
			mPlatform.Authenticate(callback, silent);
		}

		public void Authenticate(Action<bool, string> callback, bool silent)
		{
			mPlatform.Authenticate(callback, silent);
		}

		public void LoadFriends(Action<bool> callback)
		{
			mPlatform.LoadFriends(this, callback);
		}

		public string GetIdToken()
		{
			return mPlatform.GetIdToken();
		}

		public void GetStats(Action<CommonStatusCodes, PlayerStats> callback)
		{
			_003CGetStats_003Ec__AnonStorey0 _003CGetStats_003Ec__AnonStorey = new _003CGetStats_003Ec__AnonStorey0();
			_003CGetStats_003Ec__AnonStorey.callback = callback;
			_003CGetStats_003Ec__AnonStorey._0024this = this;
			if (mStats == null || !mStats.Valid)
			{
				mPlatform.GetPlayerStats(_003CGetStats_003Ec__AnonStorey._003C_003Em__0);
			}
			else
			{
				_003CGetStats_003Ec__AnonStorey.callback(CommonStatusCodes.Success, mStats);
			}
		}
	}
}
