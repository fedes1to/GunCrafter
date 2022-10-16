using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.Native
{
	internal class NativeSavedGameClient : ISavedGameClient
	{
		private class NativeConflictResolver : IConflictResolver
		{
			private readonly GooglePlayGames.Native.PInvoke.SnapshotManager mManager;

			private readonly string mConflictId;

			private readonly NativeSnapshotMetadata mOriginal;

			private readonly NativeSnapshotMetadata mUnmerged;

			private readonly Action<SavedGameRequestStatus, ISavedGameMetadata> mCompleteCallback;

			private readonly Action mRetryFileOpen;

			internal NativeConflictResolver(GooglePlayGames.Native.PInvoke.SnapshotManager manager, string conflictId, NativeSnapshotMetadata original, NativeSnapshotMetadata unmerged, Action<SavedGameRequestStatus, ISavedGameMetadata> completeCallback, Action retryOpen)
			{
				mManager = Misc.CheckNotNull(manager);
				mConflictId = Misc.CheckNotNull(conflictId);
				mOriginal = Misc.CheckNotNull(original);
				mUnmerged = Misc.CheckNotNull(unmerged);
				mCompleteCallback = Misc.CheckNotNull(completeCallback);
				mRetryFileOpen = Misc.CheckNotNull(retryOpen);
			}

			public void ChooseMetadata(ISavedGameMetadata chosenMetadata)
			{
				NativeSnapshotMetadata nativeSnapshotMetadata = chosenMetadata as NativeSnapshotMetadata;
				if (nativeSnapshotMetadata != mOriginal && nativeSnapshotMetadata != mUnmerged)
				{
					Logger.e("Caller attempted to choose a version of the metadata that was not part of the conflict");
					mCompleteCallback(SavedGameRequestStatus.BadInputError, null);
				}
				else
				{
					mManager.Resolve(nativeSnapshotMetadata, new NativeSnapshotMetadataChange.Builder().Build(), mConflictId, _003CChooseMetadata_003Em__0);
				}
			}

			[CompilerGenerated]
			private void _003CChooseMetadata_003Em__0(GooglePlayGames.Native.PInvoke.SnapshotManager.CommitResponse response)
			{
				if (!response.RequestSucceeded())
				{
					mCompleteCallback(AsRequestStatus(response.ResponseStatus()), null);
				}
				else
				{
					mRetryFileOpen();
				}
			}
		}

		private class Prefetcher
		{
			private readonly object mLock = new object();

			private bool mOriginalDataFetched;

			private byte[] mOriginalData;

			private bool mUnmergedDataFetched;

			private byte[] mUnmergedData;

			private Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback;

			private readonly Action<byte[], byte[]> mDataFetchedCallback;

			[CompilerGenerated]
			private static Action<SavedGameRequestStatus, ISavedGameMetadata> _003C_003Ef__am_0024cache0;

			[CompilerGenerated]
			private static Action<SavedGameRequestStatus, ISavedGameMetadata> _003C_003Ef__am_0024cache1;

			internal Prefetcher(Action<byte[], byte[]> dataFetchedCallback, Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback)
			{
				mDataFetchedCallback = Misc.CheckNotNull(dataFetchedCallback);
				this.completedCallback = Misc.CheckNotNull(completedCallback);
			}

			internal void OnOriginalDataRead(GooglePlayGames.Native.PInvoke.SnapshotManager.ReadResponse readResponse)
			{
				lock (mLock)
				{
					if (!readResponse.RequestSucceeded())
					{
						Logger.e("Encountered error while prefetching original data.");
						completedCallback(AsRequestStatus(readResponse.ResponseStatus()), null);
						if (_003C_003Ef__am_0024cache0 == null)
						{
							_003C_003Ef__am_0024cache0 = _003COnOriginalDataRead_003Em__0;
						}
						completedCallback = _003C_003Ef__am_0024cache0;
					}
					else
					{
						Logger.d("Successfully fetched original data");
						mOriginalDataFetched = true;
						mOriginalData = readResponse.Data();
						MaybeProceed();
					}
				}
			}

			internal void OnUnmergedDataRead(GooglePlayGames.Native.PInvoke.SnapshotManager.ReadResponse readResponse)
			{
				lock (mLock)
				{
					if (!readResponse.RequestSucceeded())
					{
						Logger.e("Encountered error while prefetching unmerged data.");
						completedCallback(AsRequestStatus(readResponse.ResponseStatus()), null);
						if (_003C_003Ef__am_0024cache1 == null)
						{
							_003C_003Ef__am_0024cache1 = _003COnUnmergedDataRead_003Em__1;
						}
						completedCallback = _003C_003Ef__am_0024cache1;
					}
					else
					{
						Logger.d("Successfully fetched unmerged data");
						mUnmergedDataFetched = true;
						mUnmergedData = readResponse.Data();
						MaybeProceed();
					}
				}
			}

			private void MaybeProceed()
			{
				if (mOriginalDataFetched && mUnmergedDataFetched)
				{
					Logger.d("Fetched data for original and unmerged, proceeding");
					mDataFetchedCallback(mOriginalData, mUnmergedData);
					return;
				}
				Logger.d("Not all data fetched - original:" + mOriginalDataFetched + " unmerged:" + mUnmergedDataFetched);
			}

			[CompilerGenerated]
			private static void _003COnOriginalDataRead_003Em__0(SavedGameRequestStatus P_0, ISavedGameMetadata P_1)
			{
			}

			[CompilerGenerated]
			private static void _003COnUnmergedDataRead_003Em__1(SavedGameRequestStatus P_0, ISavedGameMetadata P_1)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003COpenWithAutomaticConflictResolution_003Ec__AnonStorey0
		{
			internal ConflictResolutionStrategy resolutionStrategy;

			internal Action<SavedGameRequestStatus, ISavedGameMetadata> callback;

			internal void _003C_003Em__0(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData, ISavedGameMetadata unmerged, byte[] unmergedData)
			{
				switch (resolutionStrategy)
				{
				case ConflictResolutionStrategy.UseOriginal:
					resolver.ChooseMetadata(original);
					break;
				case ConflictResolutionStrategy.UseUnmerged:
					resolver.ChooseMetadata(unmerged);
					break;
				case ConflictResolutionStrategy.UseLongestPlaytime:
					if (original.TotalTimePlayed >= unmerged.TotalTimePlayed)
					{
						resolver.ChooseMetadata(original);
					}
					else
					{
						resolver.ChooseMetadata(unmerged);
					}
					break;
				default:
					Logger.e("Unhandled strategy " + resolutionStrategy);
					callback(SavedGameRequestStatus.InternalError, null);
					break;
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CToOnGameThread_003Ec__AnonStorey1
		{
			private sealed class _003CToOnGameThread_003Ec__AnonStorey2
			{
				internal IConflictResolver resolver;

				internal ISavedGameMetadata original;

				internal byte[] originalData;

				internal ISavedGameMetadata unmerged;

				internal byte[] unmergedData;

				internal _003CToOnGameThread_003Ec__AnonStorey1 _003C_003Ef__ref_00241;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00241.conflictCallback(resolver, original, originalData, unmerged, unmergedData);
				}
			}

			internal ConflictCallback conflictCallback;

			internal void _003C_003Em__0(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData, ISavedGameMetadata unmerged, byte[] unmergedData)
			{
				_003CToOnGameThread_003Ec__AnonStorey2 _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey2();
				_003CToOnGameThread_003Ec__AnonStorey._003C_003Ef__ref_00241 = this;
				_003CToOnGameThread_003Ec__AnonStorey.resolver = resolver;
				_003CToOnGameThread_003Ec__AnonStorey.original = original;
				_003CToOnGameThread_003Ec__AnonStorey.originalData = originalData;
				_003CToOnGameThread_003Ec__AnonStorey.unmerged = unmerged;
				_003CToOnGameThread_003Ec__AnonStorey.unmergedData = unmergedData;
				Logger.d("Invoking conflict callback");
				PlayGamesHelperObject.RunOnGameThread(_003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		[CompilerGenerated]
		private sealed class _003CInternalManualOpen_003Ec__AnonStorey3
		{
			private sealed class _003CInternalManualOpen_003Ec__AnonStorey4
			{
				internal NativeConflictResolver resolver;

				internal NativeSnapshotMetadata original;

				internal NativeSnapshotMetadata unmerged;

				internal _003CInternalManualOpen_003Ec__AnonStorey3 _003C_003Ef__ref_00243;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00243._0024this.InternalManualOpen(_003C_003Ef__ref_00243.filename, _003C_003Ef__ref_00243.source, _003C_003Ef__ref_00243.prefetchDataOnConflict, _003C_003Ef__ref_00243.conflictCallback, _003C_003Ef__ref_00243.completedCallback);
				}

				internal void _003C_003Em__1(byte[] originalData, byte[] unmergedData)
				{
					_003C_003Ef__ref_00243.conflictCallback(resolver, original, originalData, unmerged, unmergedData);
				}
			}

			internal Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback;

			internal string filename;

			internal DataSource source;

			internal bool prefetchDataOnConflict;

			internal ConflictCallback conflictCallback;

			internal NativeSavedGameClient _0024this;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.SnapshotManager.OpenResponse response)
			{
				if (!response.RequestSucceeded())
				{
					completedCallback(AsRequestStatus(response.ResponseStatus()), null);
				}
				else if (response.ResponseStatus() == CommonErrorStatus.SnapshotOpenStatus.VALID)
				{
					completedCallback(SavedGameRequestStatus.Success, response.Data());
				}
				else if (response.ResponseStatus() == CommonErrorStatus.SnapshotOpenStatus.VALID_WITH_CONFLICT)
				{
					_003CInternalManualOpen_003Ec__AnonStorey4 _003CInternalManualOpen_003Ec__AnonStorey = new _003CInternalManualOpen_003Ec__AnonStorey4();
					_003CInternalManualOpen_003Ec__AnonStorey._003C_003Ef__ref_00243 = this;
					_003CInternalManualOpen_003Ec__AnonStorey.original = response.ConflictOriginal();
					_003CInternalManualOpen_003Ec__AnonStorey.unmerged = response.ConflictUnmerged();
					_003CInternalManualOpen_003Ec__AnonStorey.resolver = new NativeConflictResolver(_0024this.mSnapshotManager, response.ConflictId(), _003CInternalManualOpen_003Ec__AnonStorey.original, _003CInternalManualOpen_003Ec__AnonStorey.unmerged, completedCallback, _003CInternalManualOpen_003Ec__AnonStorey._003C_003Em__0);
					if (!prefetchDataOnConflict)
					{
						conflictCallback(_003CInternalManualOpen_003Ec__AnonStorey.resolver, _003CInternalManualOpen_003Ec__AnonStorey.original, null, _003CInternalManualOpen_003Ec__AnonStorey.unmerged, null);
						return;
					}
					Prefetcher @object = new Prefetcher(_003CInternalManualOpen_003Ec__AnonStorey._003C_003Em__1, completedCallback);
					_0024this.mSnapshotManager.Read(_003CInternalManualOpen_003Ec__AnonStorey.original, @object.OnOriginalDataRead);
					_0024this.mSnapshotManager.Read(_003CInternalManualOpen_003Ec__AnonStorey.unmerged, @object.OnUnmergedDataRead);
				}
				else
				{
					Logger.e("Unhandled response status");
					completedCallback(SavedGameRequestStatus.InternalError, null);
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CReadBinaryData_003Ec__AnonStorey5
		{
			internal Action<SavedGameRequestStatus, byte[]> completedCallback;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.SnapshotManager.ReadResponse response)
			{
				if (!response.RequestSucceeded())
				{
					completedCallback(AsRequestStatus(response.ResponseStatus()), null);
				}
				else
				{
					completedCallback(SavedGameRequestStatus.Success, response.Data());
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CShowSelectSavedGameUI_003Ec__AnonStorey6
		{
			internal Action<SelectUIStatus, ISavedGameMetadata> callback;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.SnapshotManager.SnapshotSelectUIResponse response)
			{
				callback(AsUIStatus(response.RequestStatus()), (!response.RequestSucceeded()) ? null : response.Data());
			}
		}

		[CompilerGenerated]
		private sealed class _003CCommitUpdate_003Ec__AnonStorey7
		{
			internal Action<SavedGameRequestStatus, ISavedGameMetadata> callback;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.SnapshotManager.CommitResponse response)
			{
				if (!response.RequestSucceeded())
				{
					callback(AsRequestStatus(response.ResponseStatus()), null);
				}
				else
				{
					callback(SavedGameRequestStatus.Success, response.Data());
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CFetchAllSavedGames_003Ec__AnonStorey8
		{
			internal Action<SavedGameRequestStatus, List<ISavedGameMetadata>> callback;

			internal void _003C_003Em__0(GooglePlayGames.Native.PInvoke.SnapshotManager.FetchAllResponse response)
			{
				if (!response.RequestSucceeded())
				{
					callback(AsRequestStatus(response.ResponseStatus()), new List<ISavedGameMetadata>());
				}
				else
				{
					callback(SavedGameRequestStatus.Success, response.Data().Cast<ISavedGameMetadata>().ToList());
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003CToOnGameThread_003Ec__AnonStorey9<T1, T2>
		{
			private sealed class _003CToOnGameThread_003Ec__AnonStoreyA
			{
				internal T1 val1;

				internal T2 val2;

				internal _003CToOnGameThread_003Ec__AnonStorey9<T1, T2> _003C_003Ef__ref_00249;

				internal void _003C_003Em__0()
				{
					_003C_003Ef__ref_00249.toConvert(val1, val2);
				}
			}

			internal Action<T1, T2> toConvert;

			internal void _003C_003Em__0(T1 val1, T2 val2)
			{
				_003CToOnGameThread_003Ec__AnonStoreyA _003CToOnGameThread_003Ec__AnonStoreyA = new _003CToOnGameThread_003Ec__AnonStoreyA();
				_003CToOnGameThread_003Ec__AnonStoreyA._003C_003Ef__ref_00249 = this;
				_003CToOnGameThread_003Ec__AnonStoreyA.val1 = val1;
				_003CToOnGameThread_003Ec__AnonStoreyA.val2 = val2;
				PlayGamesHelperObject.RunOnGameThread(_003CToOnGameThread_003Ec__AnonStoreyA._003C_003Em__0);
			}
		}

		private static readonly Regex ValidFilenameRegex = new Regex("\\A[a-zA-Z0-9-._~]{1,100}\\Z");

		private readonly GooglePlayGames.Native.PInvoke.SnapshotManager mSnapshotManager;

		internal NativeSavedGameClient(GooglePlayGames.Native.PInvoke.SnapshotManager manager)
		{
			mSnapshotManager = Misc.CheckNotNull(manager);
		}

		public void OpenWithAutomaticConflictResolution(string filename, DataSource source, ConflictResolutionStrategy resolutionStrategy, Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
		{
			_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey0 _003COpenWithAutomaticConflictResolution_003Ec__AnonStorey = new _003COpenWithAutomaticConflictResolution_003Ec__AnonStorey0();
			_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.resolutionStrategy = resolutionStrategy;
			_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.callback = callback;
			Misc.CheckNotNull(filename);
			Misc.CheckNotNull(_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.callback);
			_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.callback = ToOnGameThread(_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.callback);
			if (!IsValidFilename(filename))
			{
				Logger.e("Received invalid filename: " + filename);
				_003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.callback(SavedGameRequestStatus.BadInputError, null);
			}
			else
			{
				OpenWithManualConflictResolution(filename, source, false, _003COpenWithAutomaticConflictResolution_003Ec__AnonStorey._003C_003Em__0, _003COpenWithAutomaticConflictResolution_003Ec__AnonStorey.callback);
			}
		}

		private ConflictCallback ToOnGameThread(ConflictCallback conflictCallback)
		{
			_003CToOnGameThread_003Ec__AnonStorey1 _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey1();
			_003CToOnGameThread_003Ec__AnonStorey.conflictCallback = conflictCallback;
			return _003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0;
		}

		public void OpenWithManualConflictResolution(string filename, DataSource source, bool prefetchDataOnConflict, ConflictCallback conflictCallback, Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback)
		{
			Misc.CheckNotNull(filename);
			Misc.CheckNotNull(conflictCallback);
			Misc.CheckNotNull(completedCallback);
			conflictCallback = ToOnGameThread(conflictCallback);
			completedCallback = ToOnGameThread(completedCallback);
			if (!IsValidFilename(filename))
			{
				Logger.e("Received invalid filename: " + filename);
				completedCallback(SavedGameRequestStatus.BadInputError, null);
			}
			else
			{
				InternalManualOpen(filename, source, prefetchDataOnConflict, conflictCallback, completedCallback);
			}
		}

		private void InternalManualOpen(string filename, DataSource source, bool prefetchDataOnConflict, ConflictCallback conflictCallback, Action<SavedGameRequestStatus, ISavedGameMetadata> completedCallback)
		{
			_003CInternalManualOpen_003Ec__AnonStorey3 _003CInternalManualOpen_003Ec__AnonStorey = new _003CInternalManualOpen_003Ec__AnonStorey3();
			_003CInternalManualOpen_003Ec__AnonStorey.completedCallback = completedCallback;
			_003CInternalManualOpen_003Ec__AnonStorey.filename = filename;
			_003CInternalManualOpen_003Ec__AnonStorey.source = source;
			_003CInternalManualOpen_003Ec__AnonStorey.prefetchDataOnConflict = prefetchDataOnConflict;
			_003CInternalManualOpen_003Ec__AnonStorey.conflictCallback = conflictCallback;
			_003CInternalManualOpen_003Ec__AnonStorey._0024this = this;
			mSnapshotManager.Open(_003CInternalManualOpen_003Ec__AnonStorey.filename, AsDataSource(_003CInternalManualOpen_003Ec__AnonStorey.source), Types.SnapshotConflictPolicy.MANUAL, _003CInternalManualOpen_003Ec__AnonStorey._003C_003Em__0);
		}

		public void ReadBinaryData(ISavedGameMetadata metadata, Action<SavedGameRequestStatus, byte[]> completedCallback)
		{
			_003CReadBinaryData_003Ec__AnonStorey5 _003CReadBinaryData_003Ec__AnonStorey = new _003CReadBinaryData_003Ec__AnonStorey5();
			_003CReadBinaryData_003Ec__AnonStorey.completedCallback = completedCallback;
			Misc.CheckNotNull(metadata);
			Misc.CheckNotNull(_003CReadBinaryData_003Ec__AnonStorey.completedCallback);
			_003CReadBinaryData_003Ec__AnonStorey.completedCallback = ToOnGameThread(_003CReadBinaryData_003Ec__AnonStorey.completedCallback);
			NativeSnapshotMetadata nativeSnapshotMetadata = metadata as NativeSnapshotMetadata;
			if (nativeSnapshotMetadata == null)
			{
				Logger.e("Encountered metadata that was not generated by this ISavedGameClient");
				_003CReadBinaryData_003Ec__AnonStorey.completedCallback(SavedGameRequestStatus.BadInputError, null);
			}
			else if (!nativeSnapshotMetadata.IsOpen)
			{
				Logger.e("This method requires an open ISavedGameMetadata.");
				_003CReadBinaryData_003Ec__AnonStorey.completedCallback(SavedGameRequestStatus.BadInputError, null);
			}
			else
			{
				mSnapshotManager.Read(nativeSnapshotMetadata, _003CReadBinaryData_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public void ShowSelectSavedGameUI(string uiTitle, uint maxDisplayedSavedGames, bool showCreateSaveUI, bool showDeleteSaveUI, Action<SelectUIStatus, ISavedGameMetadata> callback)
		{
			_003CShowSelectSavedGameUI_003Ec__AnonStorey6 _003CShowSelectSavedGameUI_003Ec__AnonStorey = new _003CShowSelectSavedGameUI_003Ec__AnonStorey6();
			_003CShowSelectSavedGameUI_003Ec__AnonStorey.callback = callback;
			Misc.CheckNotNull(uiTitle);
			Misc.CheckNotNull(_003CShowSelectSavedGameUI_003Ec__AnonStorey.callback);
			_003CShowSelectSavedGameUI_003Ec__AnonStorey.callback = ToOnGameThread(_003CShowSelectSavedGameUI_003Ec__AnonStorey.callback);
			if (maxDisplayedSavedGames == 0)
			{
				Logger.e("maxDisplayedSavedGames must be greater than 0");
				_003CShowSelectSavedGameUI_003Ec__AnonStorey.callback(SelectUIStatus.BadInputError, null);
			}
			else
			{
				mSnapshotManager.SnapshotSelectUI(showCreateSaveUI, showDeleteSaveUI, maxDisplayedSavedGames, uiTitle, _003CShowSelectSavedGameUI_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public void CommitUpdate(ISavedGameMetadata metadata, SavedGameMetadataUpdate updateForMetadata, byte[] updatedBinaryData, Action<SavedGameRequestStatus, ISavedGameMetadata> callback)
		{
			_003CCommitUpdate_003Ec__AnonStorey7 _003CCommitUpdate_003Ec__AnonStorey = new _003CCommitUpdate_003Ec__AnonStorey7();
			_003CCommitUpdate_003Ec__AnonStorey.callback = callback;
			Misc.CheckNotNull(metadata);
			Misc.CheckNotNull(updatedBinaryData);
			Misc.CheckNotNull(_003CCommitUpdate_003Ec__AnonStorey.callback);
			_003CCommitUpdate_003Ec__AnonStorey.callback = ToOnGameThread(_003CCommitUpdate_003Ec__AnonStorey.callback);
			NativeSnapshotMetadata nativeSnapshotMetadata = metadata as NativeSnapshotMetadata;
			if (nativeSnapshotMetadata == null)
			{
				Logger.e("Encountered metadata that was not generated by this ISavedGameClient");
				_003CCommitUpdate_003Ec__AnonStorey.callback(SavedGameRequestStatus.BadInputError, null);
			}
			else if (!nativeSnapshotMetadata.IsOpen)
			{
				Logger.e("This method requires an open ISavedGameMetadata.");
				_003CCommitUpdate_003Ec__AnonStorey.callback(SavedGameRequestStatus.BadInputError, null);
			}
			else
			{
				mSnapshotManager.Commit(nativeSnapshotMetadata, AsMetadataChange(updateForMetadata), updatedBinaryData, _003CCommitUpdate_003Ec__AnonStorey._003C_003Em__0);
			}
		}

		public void FetchAllSavedGames(DataSource source, Action<SavedGameRequestStatus, List<ISavedGameMetadata>> callback)
		{
			_003CFetchAllSavedGames_003Ec__AnonStorey8 _003CFetchAllSavedGames_003Ec__AnonStorey = new _003CFetchAllSavedGames_003Ec__AnonStorey8();
			_003CFetchAllSavedGames_003Ec__AnonStorey.callback = callback;
			Misc.CheckNotNull(_003CFetchAllSavedGames_003Ec__AnonStorey.callback);
			_003CFetchAllSavedGames_003Ec__AnonStorey.callback = ToOnGameThread(_003CFetchAllSavedGames_003Ec__AnonStorey.callback);
			mSnapshotManager.FetchAll(AsDataSource(source), _003CFetchAllSavedGames_003Ec__AnonStorey._003C_003Em__0);
		}

		public void Delete(ISavedGameMetadata metadata)
		{
			Misc.CheckNotNull(metadata);
			mSnapshotManager.Delete((NativeSnapshotMetadata)metadata);
		}

		internal static bool IsValidFilename(string filename)
		{
			if (filename == null)
			{
				return false;
			}
			return ValidFilenameRegex.IsMatch(filename);
		}

		private static Types.SnapshotConflictPolicy AsConflictPolicy(ConflictResolutionStrategy strategy)
		{
			switch (strategy)
			{
			case ConflictResolutionStrategy.UseLongestPlaytime:
				return Types.SnapshotConflictPolicy.LONGEST_PLAYTIME;
			case ConflictResolutionStrategy.UseOriginal:
				return Types.SnapshotConflictPolicy.LAST_KNOWN_GOOD;
			case ConflictResolutionStrategy.UseUnmerged:
				return Types.SnapshotConflictPolicy.MOST_RECENTLY_MODIFIED;
			default:
				throw new InvalidOperationException("Found unhandled strategy: " + strategy);
			}
		}

		private static SavedGameRequestStatus AsRequestStatus(CommonErrorStatus.SnapshotOpenStatus status)
		{
			switch (status)
			{
			case CommonErrorStatus.SnapshotOpenStatus.VALID:
				return SavedGameRequestStatus.Success;
			case CommonErrorStatus.SnapshotOpenStatus.ERROR_NOT_AUTHORIZED:
				return SavedGameRequestStatus.AuthenticationError;
			case CommonErrorStatus.SnapshotOpenStatus.ERROR_TIMEOUT:
				return SavedGameRequestStatus.TimeoutError;
			default:
				Logger.e("Encountered unknown status: " + status);
				return SavedGameRequestStatus.InternalError;
			}
		}

		private static Types.DataSource AsDataSource(DataSource source)
		{
			switch (source)
			{
			case DataSource.ReadCacheOrNetwork:
				return Types.DataSource.CACHE_OR_NETWORK;
			case DataSource.ReadNetworkOnly:
				return Types.DataSource.NETWORK_ONLY;
			default:
				throw new InvalidOperationException("Found unhandled DataSource: " + source);
			}
		}

		private static SavedGameRequestStatus AsRequestStatus(CommonErrorStatus.ResponseStatus status)
		{
			switch (status)
			{
			case CommonErrorStatus.ResponseStatus.ERROR_INTERNAL:
				return SavedGameRequestStatus.InternalError;
			case CommonErrorStatus.ResponseStatus.ERROR_LICENSE_CHECK_FAILED:
				Logger.e("User attempted to use the game without a valid license.");
				return SavedGameRequestStatus.AuthenticationError;
			case CommonErrorStatus.ResponseStatus.ERROR_NOT_AUTHORIZED:
				Logger.e("User was not authorized (they were probably not logged in).");
				return SavedGameRequestStatus.AuthenticationError;
			case CommonErrorStatus.ResponseStatus.ERROR_TIMEOUT:
				return SavedGameRequestStatus.TimeoutError;
			case CommonErrorStatus.ResponseStatus.VALID:
			case CommonErrorStatus.ResponseStatus.VALID_BUT_STALE:
				return SavedGameRequestStatus.Success;
			default:
				Logger.e("Unknown status: " + status);
				return SavedGameRequestStatus.InternalError;
			}
		}

		private static SelectUIStatus AsUIStatus(CommonErrorStatus.UIStatus uiStatus)
		{
			switch (uiStatus)
			{
			case CommonErrorStatus.UIStatus.VALID:
				return SelectUIStatus.SavedGameSelected;
			case CommonErrorStatus.UIStatus.ERROR_CANCELED:
				return SelectUIStatus.UserClosedUI;
			case CommonErrorStatus.UIStatus.ERROR_INTERNAL:
				return SelectUIStatus.InternalError;
			case CommonErrorStatus.UIStatus.ERROR_NOT_AUTHORIZED:
				return SelectUIStatus.AuthenticationError;
			case CommonErrorStatus.UIStatus.ERROR_TIMEOUT:
				return SelectUIStatus.TimeoutError;
			default:
				Logger.e("Encountered unknown UI Status: " + uiStatus);
				return SelectUIStatus.InternalError;
			}
		}

		private static NativeSnapshotMetadataChange AsMetadataChange(SavedGameMetadataUpdate update)
		{
			NativeSnapshotMetadataChange.Builder builder = new NativeSnapshotMetadataChange.Builder();
			if (update.IsCoverImageUpdated)
			{
				builder.SetCoverImageFromPngData(update.UpdatedPngCoverImage);
			}
			if (update.IsDescriptionUpdated)
			{
				builder.SetDescription(update.UpdatedDescription);
			}
			if (update.IsPlayedTimeUpdated)
			{
				builder.SetPlayedTime((ulong)update.UpdatedPlayedTime.Value.TotalMilliseconds);
			}
			return builder.Build();
		}

		private static Action<T1, T2> ToOnGameThread<T1, T2>(Action<T1, T2> toConvert)
		{
			_003CToOnGameThread_003Ec__AnonStorey9<T1, T2> _003CToOnGameThread_003Ec__AnonStorey = new _003CToOnGameThread_003Ec__AnonStorey9<T1, T2>();
			_003CToOnGameThread_003Ec__AnonStorey.toConvert = toConvert;
			return _003CToOnGameThread_003Ec__AnonStorey._003C_003Em__0;
		}
	}
}
