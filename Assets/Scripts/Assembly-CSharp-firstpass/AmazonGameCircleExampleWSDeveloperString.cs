using System.Collections.Generic;
using UnityEngine;

public class AmazonGameCircleExampleWSDeveloperString
{
	private AGSSyncableDeveloperString developerString;

	private HashSet<string> developerStringKeys;

	private const string nullDataMapLabel = "Missing Whispersync DataMap";

	private const string nullDeveloperString = "DeveloperString not yet initialized";

	private const string refreshDeveloperStringsButtonLabel = "Refresh Developer String Keys";

	private const string cloudTimestampLabel = "Cloud Timestamp {0}";

	private const string cloudValueLabel = "Cloud Value {0}";

	private const string hashCodeLabel = "HashCode {0}";

	private const string timestampLabel = "Timestamp {0}";

	private const string valueLabel = "Value {0}";

	private const string inConflictLabel = "inConflict {0}";

	private const string isSetLabel = "isSet {0}";

	private const string setValueButtonLabel = "Set Value to \"{0}\"";

	private const string developerStringKey = "DeveloperString";

	private const string developerStringValue = "DeveloperStringValue";

	public void DrawGUI(AGSGameDataMap dataMap)
	{
		if (dataMap == null)
		{
			AmazonGUIHelpers.CenteredLabel("Missing Whispersync DataMap");
			return;
		}
		if (developerString == null)
		{
			InitializeDeveloperString(dataMap);
		}
		if (developerString == null)
		{
			AmazonGUIHelpers.CenteredLabel("DeveloperString not yet initialized");
			return;
		}
		if (GUILayout.Button("Refresh Developer String Keys"))
		{
			developerStringKeys = dataMap.getDeveloperStringKeys();
		}
		if (developerStringKeys != null)
		{
			foreach (string developerStringKey in developerStringKeys)
			{
				AmazonGUIHelpers.CenteredLabel(developerStringKey);
			}
		}
		AmazonGUIHelpers.CenteredLabel(string.Format("Cloud Value {0}", developerString.getCloudValue()));
		AmazonGUIHelpers.CenteredLabel(string.Format("Value {0}", developerString.getValue()));
		AmazonGUIHelpers.CenteredLabel(string.Format("inConflict {0}", developerString.inConflict().ToString()));
		AmazonGUIHelpers.CenteredLabel(string.Format("isSet {0}", developerString.isSet().ToString()));
		if (GUILayout.Button(string.Format("Set Value to \"{0}\"", "DeveloperStringValue")))
		{
			developerString.setValue("DeveloperStringValue");
			if (developerString.inConflict())
			{
				developerString.markAsResolved();
			}
		}
	}

	private void InitializeDeveloperString(AGSGameDataMap dataMap)
	{
		developerString = dataMap.getDeveloperString("DeveloperString");
	}
}
