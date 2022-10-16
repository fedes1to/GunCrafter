using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmazonGameCircleExampleWhispersync : AmazonGameCircleExampleBase
{
	private DateTime? lastOnNewCloudData;

	private DateTime? lastOnDataUploadedToCloud;

	private DateTime? lastOnThrottled;

	private DateTime? lastOnDiskWriteComplete;

	private DateTime? lastOnFirstSynchronize;

	private DateTime? lastOnAlreadySynchronized;

	private DateTime? lastOnSyncFailed;

	private string failReason = string.Empty;

	private bool syncableNumbersFoldout;

	private bool accumulatingNumbersFoldout;

	private bool syncableNumberListsFoldout;

	private bool hashSetsFoldout;

	private bool developerStringFoldout;

	private List<AmazonGameCircleExampleWSSyncableNumber> syncableNumbers;

	private List<AmazonGameCircleExampleWSAccumulatingNumber> accumulatingNumbers;

	private List<AmazonGameCircleExampleWSNumberList> syncableNumberLists;

	private AmazonGameCircleExampleWSHashSets hashSets;

	private AmazonGameCircleExampleWSDeveloperString developerString;

	private AGSGameDataMap dataMap;

	private const string whispersyncMenuTitle = "Whispersync";

	private const string syncableNumbersLabel = "Syncable Numbers";

	private const string accumulatingNumbersLabel = "Accumulating Numbers";

	private const string syncDataButtonLabel = "Synchronize";

	private const string flushButtonLabel = "Flush";

	private const string noCloudDataReceivedLabel = "No cloud data received.";

	private const string cloudDataLastReceivedLabel = "Received cloud data {0,5:N1} seconds ago.";

	private const string uploadedToCloudLabel = "Uploaded cloud data {0,5:N1} seconds ago.";

	private const string lastThrottledLabel = "Throttled {0,5:N1} seconds ago.";

	private const string diskWriteCompleteLabel = "Disk write complete {0,5:N1} seconds ago.";

	private const string firstSynchronizeLabel = "First synchronize {0,5:N1} seconds ago.";

	private const string alreadySychronizedLabel = "Already synchronized called {0,5:N1} seconds ago.";

	private const string syncFailedLabel = "Sync failed {0,5:N1} seconds ago. Reason: {1}";

	private const string hashSetsLabel = "Hash Sets";

	private const string numberListsLabel = "Syncable Number Lists";

	private const string developerStringLabel = "Developer String";

	private const string whispersyncUnavailableLabel = "No Whispersync data available.";

	private static AmazonGameCircleExampleWhispersync instance;

	private AmazonGameCircleExampleWhispersync()
	{
		InitSyncableNumbers();
		InitSyncableNumberLists();
		InitAccumulatingNumbers();
		InitHashSets();
		InitDeveloperString();
	}

	public static AmazonGameCircleExampleWhispersync Instance()
	{
		if (instance == null)
		{
			instance = new AmazonGameCircleExampleWhispersync();
		}
		return instance;
	}

	public override string MenuTitle()
	{
		return "Whispersync";
	}

	public override void DrawMenu()
	{
		if (lastOnNewCloudData.HasValue)
		{
			double totalSeconds = (DateTime.Now - lastOnNewCloudData.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("Received cloud data {0,5:N1} seconds ago.", totalSeconds));
		}
		if (lastOnDataUploadedToCloud.HasValue)
		{
			double totalSeconds2 = (DateTime.Now - lastOnDataUploadedToCloud.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("Uploaded cloud data {0,5:N1} seconds ago.", totalSeconds2));
		}
		if (lastOnThrottled.HasValue)
		{
			double totalSeconds3 = (DateTime.Now - lastOnThrottled.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("Throttled {0,5:N1} seconds ago.", totalSeconds3));
		}
		if (lastOnDiskWriteComplete.HasValue)
		{
			double totalSeconds4 = (DateTime.Now - lastOnDiskWriteComplete.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("Disk write complete {0,5:N1} seconds ago.", totalSeconds4));
		}
		if (lastOnFirstSynchronize.HasValue)
		{
			double totalSeconds5 = (DateTime.Now - lastOnFirstSynchronize.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("First synchronize {0,5:N1} seconds ago.", totalSeconds5));
		}
		if (lastOnAlreadySynchronized.HasValue)
		{
			double totalSeconds6 = (DateTime.Now - lastOnAlreadySynchronized.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("Already synchronized called {0,5:N1} seconds ago.", totalSeconds6));
		}
		if (lastOnSyncFailed.HasValue)
		{
			double totalSeconds7 = (DateTime.Now - lastOnSyncFailed.Value).TotalSeconds;
			AmazonGUIHelpers.CenteredLabel(string.Format("Sync failed {0,5:N1} seconds ago. Reason: {1}", totalSeconds7, failReason));
		}
		else
		{
			AmazonGUIHelpers.CenteredLabel("No cloud data received.");
		}
		if (GUILayout.Button("Synchronize"))
		{
			AGSWhispersyncClient.Synchronize();
		}
		GUILayout.Label(GUIContent.none);
		if (GUILayout.Button("Flush"))
		{
			AGSWhispersyncClient.Flush();
		}
		GUILayout.Label(GUIContent.none);
		InitializeDataMapIfAvailable();
		if (dataMap == null)
		{
			AmazonGUIHelpers.CenteredLabel("No Whispersync data available.");
			return;
		}
		DrawSyncableNumbers();
		DrawAccumulatingNumbers();
		DrawSyncableNumberLists();
		DrawHashSets();
		DrawDeveloperString();
	}

	private void DrawSyncableNumbers()
	{
		if (syncableNumbers == null)
		{
			return;
		}
		GUILayout.BeginVertical(GUI.skin.box);
		syncableNumbersFoldout = AmazonGUIHelpers.FoldoutWithLabel(syncableNumbersFoldout, "Syncable Numbers");
		if (syncableNumbersFoldout)
		{
			foreach (AmazonGameCircleExampleWSSyncableNumber syncableNumber in syncableNumbers)
			{
				syncableNumber.DrawGUI(dataMap);
			}
		}
		GUILayout.EndVertical();
	}

	private void DrawAccumulatingNumbers()
	{
		if (accumulatingNumbers == null)
		{
			return;
		}
		GUILayout.BeginVertical(GUI.skin.box);
		accumulatingNumbersFoldout = AmazonGUIHelpers.FoldoutWithLabel(accumulatingNumbersFoldout, "Accumulating Numbers");
		if (accumulatingNumbersFoldout)
		{
			foreach (AmazonGameCircleExampleWSAccumulatingNumber accumulatingNumber in accumulatingNumbers)
			{
				accumulatingNumber.DrawGUI(dataMap);
			}
		}
		GUILayout.EndVertical();
	}

	private void DrawSyncableNumberLists()
	{
		if (syncableNumberLists == null)
		{
			return;
		}
		GUILayout.BeginVertical(GUI.skin.box);
		syncableNumberListsFoldout = AmazonGUIHelpers.FoldoutWithLabel(syncableNumberListsFoldout, "Syncable Number Lists");
		if (syncableNumberListsFoldout)
		{
			foreach (AmazonGameCircleExampleWSNumberList syncableNumberList in syncableNumberLists)
			{
				syncableNumberList.DrawGUI(dataMap);
			}
		}
		GUILayout.EndVertical();
	}

	private void DrawHashSets()
	{
		if (hashSets != null)
		{
			GUILayout.BeginVertical(GUI.skin.box);
			hashSetsFoldout = AmazonGUIHelpers.FoldoutWithLabel(hashSetsFoldout, "Hash Sets");
			if (hashSetsFoldout)
			{
				hashSets.DrawGUI(dataMap);
			}
			GUILayout.EndVertical();
		}
	}

	private void DrawDeveloperString()
	{
		if (developerString != null)
		{
			GUILayout.BeginVertical(GUI.skin.box);
			developerStringFoldout = AmazonGUIHelpers.FoldoutWithLabel(developerStringFoldout, "Developer String");
			if (developerStringFoldout)
			{
				developerString.DrawGUI(dataMap);
			}
			GUILayout.EndVertical();
		}
	}

	private void InitializeDataMapIfAvailable()
	{
		if (dataMap == null)
		{
			dataMap = AGSWhispersyncClient.GetGameData();
			if (dataMap != null)
			{
				AGSWhispersyncClient.OnNewCloudDataEvent += OnNewCloudData;
				AGSWhispersyncClient.OnDataUploadedToCloudEvent += OnDataUploadedToCloud;
				AGSWhispersyncClient.OnThrottledEvent += OnThrottled;
				AGSWhispersyncClient.OnDiskWriteCompleteEvent += OnDiskWriteComplete;
				AGSWhispersyncClient.OnFirstSynchronizeEvent += OnFirstSynchronize;
				AGSWhispersyncClient.OnAlreadySynchronizedEvent += OnAlreadySynchronized;
				AGSWhispersyncClient.OnSyncFailedEvent += OnSyncFailed;
			}
		}
	}

	private void InitSyncableNumbers()
	{
		if (syncableNumbers != null)
		{
			return;
		}
		syncableNumbers = new List<AmazonGameCircleExampleWSSyncableNumber>();
		Array values = Enum.GetValues(typeof(AmazonGameCircleExampleWSSyncableNumber.SyncableNumberBehavior));
		Array values2 = Enum.GetValues(typeof(AmazonGameCircleExampleWSSyncableNumber.AvailableSyncableNumberType));
		IEnumerator enumerator = values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AmazonGameCircleExampleWSSyncableNumber.SyncableNumberBehavior newBehavior = (AmazonGameCircleExampleWSSyncableNumber.SyncableNumberBehavior)enumerator.Current;
				IEnumerator enumerator2 = values2.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						AmazonGameCircleExampleWSSyncableNumber.AvailableSyncableNumberType newType = (AmazonGameCircleExampleWSSyncableNumber.AvailableSyncableNumberType)enumerator2.Current;
						syncableNumbers.Add(new AmazonGameCircleExampleWSSyncableNumber(newBehavior, newType));
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = enumerator2 as IDisposable) != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable2;
			if ((disposable2 = enumerator as IDisposable) != null)
			{
				disposable2.Dispose();
			}
		}
	}

	private void InitSyncableNumberLists()
	{
		if (syncableNumberLists != null)
		{
			return;
		}
		syncableNumberLists = new List<AmazonGameCircleExampleWSNumberList>();
		Array values = Enum.GetValues(typeof(AmazonGameCircleExampleWSNumberList.AvailableListType));
		IEnumerator enumerator = values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AmazonGameCircleExampleWSNumberList.AvailableListType availableListType = (AmazonGameCircleExampleWSNumberList.AvailableListType)enumerator.Current;
				syncableNumberLists.Add(new AmazonGameCircleExampleWSNumberList(availableListType));
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void InitAccumulatingNumbers()
	{
		if (accumulatingNumbers != null)
		{
			return;
		}
		accumulatingNumbers = new List<AmazonGameCircleExampleWSAccumulatingNumber>();
		Array values = Enum.GetValues(typeof(AmazonGameCircleExampleWSAccumulatingNumber.AvailableAccumulatingNumberType));
		IEnumerator enumerator = values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				AmazonGameCircleExampleWSAccumulatingNumber.AvailableAccumulatingNumberType newType = (AmazonGameCircleExampleWSAccumulatingNumber.AvailableAccumulatingNumberType)enumerator.Current;
				accumulatingNumbers.Add(new AmazonGameCircleExampleWSAccumulatingNumber(newType));
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
	}

	private void InitHashSets()
	{
		if (hashSets == null)
		{
			hashSets = new AmazonGameCircleExampleWSHashSets();
		}
	}

	private void InitDeveloperString()
	{
		if (developerString == null)
		{
			developerString = new AmazonGameCircleExampleWSDeveloperString();
		}
	}

	private void OnNewCloudData()
	{
		lastOnNewCloudData = DateTime.Now;
	}

	private void OnDataUploadedToCloud()
	{
		lastOnDataUploadedToCloud = DateTime.Now;
	}

	private void OnThrottled()
	{
		lastOnThrottled = DateTime.Now;
	}

	private void OnDiskWriteComplete()
	{
		lastOnDiskWriteComplete = DateTime.Now;
	}

	private void OnFirstSynchronize()
	{
		lastOnFirstSynchronize = DateTime.Now;
	}

	private void OnAlreadySynchronized()
	{
		lastOnAlreadySynchronized = DateTime.Now;
	}

	private void OnSyncFailed()
	{
		lastOnSyncFailed = DateTime.Now;
		failReason = AGSWhispersyncClient.failReason;
	}
}
