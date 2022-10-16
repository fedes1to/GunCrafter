using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native.PInvoke
{
	internal class LeaderboardManager
	{
		[CompilerGenerated]
		private sealed class _003CLoadLeaderboardData_003Ec__AnonStorey0
		{
			internal ScorePageToken token;

			internal string playerId;

			internal int rowCount;

			internal Action<LeaderboardScoreData> callback;

			internal LeaderboardManager _0024this;

			internal void _003C_003Em__0(FetchResponse rsp)
			{
				_0024this.HandleFetch(token, rsp, playerId, rowCount, callback);
			}
		}

		[CompilerGenerated]
		private sealed class _003CHandleFetch_003Ec__AnonStorey1
		{
			internal LeaderboardScoreData data;

			internal string selfPlayerId;

			internal int maxResults;

			internal ScorePageToken token;

			internal Action<LeaderboardScoreData> callback;

			internal LeaderboardManager _0024this;

			internal void _003C_003Em__0(FetchScoreSummaryResponse rsp)
			{
				_0024this.HandleFetchScoreSummary(data, rsp, selfPlayerId, maxResults, token, callback);
			}
		}

		[CompilerGenerated]
		private sealed class _003CLoadScorePage_003Ec__AnonStorey2
		{
			internal LeaderboardScoreData data;

			internal ScorePageToken token;

			internal Action<LeaderboardScoreData> callback;

			internal LeaderboardManager _0024this;

			internal void _003C_003Em__0(FetchScorePageResponse rsp)
			{
				_0024this.HandleFetchScorePage(data, token, rsp, callback);
			}
		}

		private readonly GameServices mServices;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.LeaderboardManager.ShowAllUICallback _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.LeaderboardManager.ShowUICallback _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		private static Func<IntPtr, FetchResponse> _003C_003Ef__mg_0024cache2;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchCallback _003C_003Ef__mg_0024cache3;

		[CompilerGenerated]
		private static Func<IntPtr, FetchScoreSummaryResponse> _003C_003Ef__mg_0024cache4;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScoreSummaryCallback _003C_003Ef__mg_0024cache5;

		[CompilerGenerated]
		private static Func<IntPtr, FetchScorePageResponse> _003C_003Ef__mg_0024cache6;

		[CompilerGenerated]
		private static GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScorePageCallback _003C_003Ef__mg_0024cache7;

		internal int LeaderboardMaxResults
		{
			get
			{
				return 25;
			}
		}

		internal LeaderboardManager(GameServices services)
		{
			mServices = Misc.CheckNotNull(services);
		}

		internal void SubmitScore(string leaderboardId, long score, string metadata)
		{
			Misc.CheckNotNull(leaderboardId, "leaderboardId");
			Logger.d("Native Submitting score: " + score + " for lb " + leaderboardId + " with metadata: " + metadata);
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_SubmitScore(mServices.AsHandle(), leaderboardId, (ulong)score, metadata ?? string.Empty);
		}

		internal void ShowAllUI(Action<CommonErrorStatus.UIStatus> callback)
		{
			Misc.CheckNotNull(callback);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache0 == null)
			{
				_003C_003Ef__mg_0024cache0 = Callbacks.InternalShowUICallback;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_ShowAllUI(self, _003C_003Ef__mg_0024cache0, Callbacks.ToIntPtr(callback));
		}

		internal void ShowUI(string leaderboardId, LeaderboardTimeSpan span, Action<CommonErrorStatus.UIStatus> callback)
		{
			Misc.CheckNotNull(callback);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache1 == null)
			{
				_003C_003Ef__mg_0024cache1 = Callbacks.InternalShowUICallback;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_ShowUI(self, leaderboardId, (Types.LeaderboardTimeSpan)span, _003C_003Ef__mg_0024cache1, Callbacks.ToIntPtr(callback));
		}

		public void LoadLeaderboardData(string leaderboardId, LeaderboardStart start, int rowCount, LeaderboardCollection collection, LeaderboardTimeSpan timeSpan, string playerId, Action<LeaderboardScoreData> callback)
		{
			_003CLoadLeaderboardData_003Ec__AnonStorey0 _003CLoadLeaderboardData_003Ec__AnonStorey = new _003CLoadLeaderboardData_003Ec__AnonStorey0();
			_003CLoadLeaderboardData_003Ec__AnonStorey.playerId = playerId;
			_003CLoadLeaderboardData_003Ec__AnonStorey.rowCount = rowCount;
			_003CLoadLeaderboardData_003Ec__AnonStorey.callback = callback;
			_003CLoadLeaderboardData_003Ec__AnonStorey._0024this = this;
			NativeScorePageToken internalObject = new NativeScorePageToken(GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_ScorePageToken(mServices.AsHandle(), leaderboardId, (Types.LeaderboardStart)start, (Types.LeaderboardTimeSpan)timeSpan, (Types.LeaderboardCollection)collection));
			_003CLoadLeaderboardData_003Ec__AnonStorey.token = new ScorePageToken(internalObject, leaderboardId, collection, timeSpan);
			HandleRef self = mServices.AsHandle();
			if (_003C_003Ef__mg_0024cache3 == null)
			{
				_003C_003Ef__mg_0024cache3 = InternalFetchCallback;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchCallback callback2 = _003C_003Ef__mg_0024cache3;
			Action<FetchResponse> callback3 = _003CLoadLeaderboardData_003Ec__AnonStorey._003C_003Em__0;
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				_003C_003Ef__mg_0024cache2 = FetchResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_Fetch(self, Types.DataSource.CACHE_OR_NETWORK, leaderboardId, callback2, Callbacks.ToIntPtr(callback3, _003C_003Ef__mg_0024cache2));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchCallback))]
		private static void InternalFetchCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("LeaderboardManager#InternalFetchCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void HandleFetch(ScorePageToken token, FetchResponse response, string selfPlayerId, int maxResults, Action<LeaderboardScoreData> callback)
		{
			_003CHandleFetch_003Ec__AnonStorey1 _003CHandleFetch_003Ec__AnonStorey = new _003CHandleFetch_003Ec__AnonStorey1();
			_003CHandleFetch_003Ec__AnonStorey.selfPlayerId = selfPlayerId;
			_003CHandleFetch_003Ec__AnonStorey.maxResults = maxResults;
			_003CHandleFetch_003Ec__AnonStorey.token = token;
			_003CHandleFetch_003Ec__AnonStorey.callback = callback;
			_003CHandleFetch_003Ec__AnonStorey._0024this = this;
			_003CHandleFetch_003Ec__AnonStorey.data = new LeaderboardScoreData(_003CHandleFetch_003Ec__AnonStorey.token.LeaderboardId, (ResponseStatus)response.GetStatus());
			if (response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID && response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
			{
				Logger.w("Error returned from fetch: " + response.GetStatus());
				_003CHandleFetch_003Ec__AnonStorey.callback(_003CHandleFetch_003Ec__AnonStorey.data);
				return;
			}
			_003CHandleFetch_003Ec__AnonStorey.data.Title = response.Leaderboard().Title();
			_003CHandleFetch_003Ec__AnonStorey.data.Id = _003CHandleFetch_003Ec__AnonStorey.token.LeaderboardId;
			HandleRef self = mServices.AsHandle();
			string leaderboardId = _003CHandleFetch_003Ec__AnonStorey.token.LeaderboardId;
			LeaderboardTimeSpan timeSpan = _003CHandleFetch_003Ec__AnonStorey.token.TimeSpan;
			LeaderboardCollection collection = _003CHandleFetch_003Ec__AnonStorey.token.Collection;
			if (_003C_003Ef__mg_0024cache5 == null)
			{
				_003C_003Ef__mg_0024cache5 = InternalFetchSummaryCallback;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScoreSummaryCallback callback2 = _003C_003Ef__mg_0024cache5;
			Action<FetchScoreSummaryResponse> callback3 = _003CHandleFetch_003Ec__AnonStorey._003C_003Em__0;
			if (_003C_003Ef__mg_0024cache4 == null)
			{
				_003C_003Ef__mg_0024cache4 = FetchScoreSummaryResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScoreSummary(self, Types.DataSource.CACHE_OR_NETWORK, leaderboardId, (Types.LeaderboardTimeSpan)timeSpan, (Types.LeaderboardCollection)collection, callback2, Callbacks.ToIntPtr(callback3, _003C_003Ef__mg_0024cache4));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScoreSummaryCallback))]
		private static void InternalFetchSummaryCallback(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("LeaderboardManager#InternalFetchSummaryCallback", Callbacks.Type.Temporary, response, data);
		}

		internal void HandleFetchScoreSummary(LeaderboardScoreData data, FetchScoreSummaryResponse response, string selfPlayerId, int maxResults, ScorePageToken token, Action<LeaderboardScoreData> callback)
		{
			if (response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID && response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
			{
				Logger.w("Error returned from fetchScoreSummary: " + response);
				data.Status = (ResponseStatus)response.GetStatus();
				callback(data);
				return;
			}
			NativeScoreSummary scoreSummary = response.GetScoreSummary();
			data.ApproximateCount = scoreSummary.ApproximateResults();
			data.PlayerScore = scoreSummary.LocalUserScore().AsScore(data.Id, selfPlayerId);
			if (maxResults <= 0)
			{
				callback(data);
			}
			else
			{
				LoadScorePage(data, maxResults, token, callback);
			}
		}

		public void LoadScorePage(LeaderboardScoreData data, int maxResults, ScorePageToken token, Action<LeaderboardScoreData> callback)
		{
			_003CLoadScorePage_003Ec__AnonStorey2 _003CLoadScorePage_003Ec__AnonStorey = new _003CLoadScorePage_003Ec__AnonStorey2();
			_003CLoadScorePage_003Ec__AnonStorey.data = data;
			_003CLoadScorePage_003Ec__AnonStorey.token = token;
			_003CLoadScorePage_003Ec__AnonStorey.callback = callback;
			_003CLoadScorePage_003Ec__AnonStorey._0024this = this;
			if (_003CLoadScorePage_003Ec__AnonStorey.data == null)
			{
				_003CLoadScorePage_003Ec__AnonStorey.data = new LeaderboardScoreData(_003CLoadScorePage_003Ec__AnonStorey.token.LeaderboardId);
			}
			NativeScorePageToken nativeScorePageToken = (NativeScorePageToken)_003CLoadScorePage_003Ec__AnonStorey.token.InternalObject;
			HandleRef self = mServices.AsHandle();
			IntPtr token2 = nativeScorePageToken.AsPointer();
			if (_003C_003Ef__mg_0024cache7 == null)
			{
				_003C_003Ef__mg_0024cache7 = InternalFetchScorePage;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScorePageCallback callback2 = _003C_003Ef__mg_0024cache7;
			Action<FetchScorePageResponse> callback3 = _003CLoadScorePage_003Ec__AnonStorey._003C_003Em__0;
			if (_003C_003Ef__mg_0024cache6 == null)
			{
				_003C_003Ef__mg_0024cache6 = FetchScorePageResponse.FromPointer;
			}
			GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePage(self, Types.DataSource.CACHE_OR_NETWORK, token2, (uint)maxResults, callback2, Callbacks.ToIntPtr(callback3, _003C_003Ef__mg_0024cache6));
		}

		[MonoPInvokeCallback(typeof(GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScorePageCallback))]
		private static void InternalFetchScorePage(IntPtr response, IntPtr data)
		{
			Callbacks.PerformInternalCallback("LeaderboardManager#InternalFetchScorePage", Callbacks.Type.Temporary, response, data);
		}

		internal void HandleFetchScorePage(LeaderboardScoreData data, ScorePageToken token, FetchScorePageResponse rsp, Action<LeaderboardScoreData> callback)
		{
			data.Status = (ResponseStatus)rsp.GetStatus();
			if (rsp.GetStatus() != CommonErrorStatus.ResponseStatus.VALID && rsp.GetStatus() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
			{
				callback(data);
			}
			NativeScorePage scorePage = rsp.GetScorePage();
			if (!scorePage.Valid())
			{
				callback(data);
			}
			if (scorePage.HasNextScorePage())
			{
				data.NextPageToken = new ScorePageToken(scorePage.GetNextScorePageToken(), token.LeaderboardId, token.Collection, token.TimeSpan);
			}
			if (scorePage.HasPrevScorePage())
			{
				data.PrevPageToken = new ScorePageToken(scorePage.GetPreviousScorePageToken(), token.LeaderboardId, token.Collection, token.TimeSpan);
			}
			foreach (NativeScoreEntry item in scorePage)
			{
				data.AddScore(item.AsScore(data.Id));
			}
			callback(data);
		}
	}
}
