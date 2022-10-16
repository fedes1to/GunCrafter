using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Com.Google.Android.Gms.Common.Api;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android
{
	internal class AndroidTokenClient : TokenClient
	{
		[CompilerGenerated]
		private sealed class _003CFetchTokens_003Ec__AnonStorey0
		{
			internal Action<int> callback;

			internal AndroidTokenClient _0024this;

			internal void _003C_003Em__0()
			{
				_0024this.DoFetchToken(callback);
			}
		}

		[CompilerGenerated]
		private sealed class _003CDoFetchToken_003Ec__AnonStorey1
		{
			internal Action<int> callback;

			internal AndroidTokenClient _0024this;

			internal void _003C_003Em__0(int rc, string authCode, string email, string idToken)
			{
				_0024this.authCode = authCode;
				_0024this.email = email;
				_0024this.idToken = idToken;
				callback(rc);
			}
		}

		private const string TokenFragmentClass = "com.google.games.bridge.TokenFragment";

		private const string FetchTokenSignature = "(Landroid/app/Activity;ZZZLjava/lang/String;Z[Ljava/lang/String;ZLjava/lang/String;)Lcom/google/android/gms/common/api/PendingResult;";

		private const string FetchTokenMethod = "fetchToken";

		private bool requestEmail;

		private bool requestAuthCode;

		private bool requestIdToken;

		private List<string> oauthScopes;

		private string webClientId;

		private bool forceRefresh;

		private bool hidePopups;

		private string accountName;

		private string email;

		private string authCode;

		private string idToken;

		[CompilerGenerated]
		private static Action _003C_003Ef__am_0024cache0;

		public static AndroidJavaObject GetActivity()
		{
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				return androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
		}

		public void SetRequestAuthCode(bool flag, bool forceRefresh)
		{
			requestAuthCode = flag;
			this.forceRefresh = forceRefresh;
		}

		public void SetRequestEmail(bool flag)
		{
			requestEmail = flag;
		}

		public void SetRequestIdToken(bool flag)
		{
			requestIdToken = flag;
		}

		public void SetWebClientId(string webClientId)
		{
			this.webClientId = webClientId;
		}

		public void SetHidePopups(bool flag)
		{
			hidePopups = flag;
		}

		public void SetAccountName(string accountName)
		{
			this.accountName = accountName;
		}

		public void AddOauthScopes(string[] scopes)
		{
			if (scopes != null)
			{
				if (oauthScopes == null)
				{
					oauthScopes = new List<string>();
				}
				oauthScopes.AddRange(scopes);
			}
		}

		public void Signout()
		{
			authCode = null;
			email = null;
			idToken = null;
			if (_003C_003Ef__am_0024cache0 == null)
			{
				_003C_003Ef__am_0024cache0 = _003CSignout_003Em__0;
			}
			PlayGamesHelperObject.RunOnGameThread(_003C_003Ef__am_0024cache0);
		}

		public bool NeedsToRun()
		{
			return requestAuthCode || requestEmail || requestIdToken;
		}

		public void FetchTokens(Action<int> callback)
		{
			_003CFetchTokens_003Ec__AnonStorey0 _003CFetchTokens_003Ec__AnonStorey = new _003CFetchTokens_003Ec__AnonStorey0();
			_003CFetchTokens_003Ec__AnonStorey.callback = callback;
			_003CFetchTokens_003Ec__AnonStorey._0024this = this;
			PlayGamesHelperObject.RunOnGameThread(_003CFetchTokens_003Ec__AnonStorey._003C_003Em__0);
		}

		internal void DoFetchToken(Action<int> callback)
		{
			_003CDoFetchToken_003Ec__AnonStorey1 _003CDoFetchToken_003Ec__AnonStorey = new _003CDoFetchToken_003Ec__AnonStorey1();
			_003CDoFetchToken_003Ec__AnonStorey.callback = callback;
			_003CDoFetchToken_003Ec__AnonStorey._0024this = this;
			object[] args = new object[9];
			jvalue[] array = AndroidJNIHelper.CreateJNIArgArray(args);
			try
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.TokenFragment"))
				{
					using (AndroidJavaObject androidJavaObject = GetActivity())
					{
						IntPtr staticMethodID = AndroidJNI.GetStaticMethodID(androidJavaClass.GetRawClass(), "fetchToken", "(Landroid/app/Activity;ZZZLjava/lang/String;Z[Ljava/lang/String;ZLjava/lang/String;)Lcom/google/android/gms/common/api/PendingResult;");
						array[0].l = androidJavaObject.GetRawObject();
						array[1].z = requestAuthCode;
						array[2].z = requestEmail;
						array[3].z = requestIdToken;
						array[4].l = AndroidJNI.NewStringUTF(webClientId);
						array[5].z = forceRefresh;
						array[6].l = AndroidJNIHelper.ConvertToJNIArray(oauthScopes.ToArray());
						array[7].z = hidePopups;
						array[8].l = AndroidJNI.NewStringUTF(accountName);
						IntPtr ptr = AndroidJNI.CallStaticObjectMethod(androidJavaClass.GetRawClass(), staticMethodID, array);
						PendingResult<TokenResult> pendingResult = new PendingResult<TokenResult>(ptr);
						pendingResult.setResultCallback(new TokenResultCallback(_003CDoFetchToken_003Ec__AnonStorey._003C_003Em__0));
					}
				}
			}
			catch (Exception ex)
			{
				GooglePlayGames.OurUtils.Logger.e("Exception launching token request: " + ex.Message);
				GooglePlayGames.OurUtils.Logger.e(ex.ToString());
			}
			finally
			{
				AndroidJNIHelper.DeleteJNIArgArray(args, array);
			}
		}

		public string GetEmail()
		{
			return email;
		}

		public string GetAuthCode()
		{
			return authCode;
		}

		public string GetIdToken()
		{
			return idToken;
		}

		[CompilerGenerated]
		private static void _003CSignout_003Em__0()
		{
			Debug.Log("Calling Signout in token client");
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.TokenFragment");
			androidJavaClass.CallStatic("signOut", GetActivity());
		}
	}
}
