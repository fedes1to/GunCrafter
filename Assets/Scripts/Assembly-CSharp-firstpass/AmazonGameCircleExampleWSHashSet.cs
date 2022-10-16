using System;
using System.Collections.Generic;
using UnityEngine;

public class AmazonGameCircleExampleWSHashSet
{
	private string hashSetTitle;

	private HashSet<string> hashSet;

	private bool foldoutOpen;

	private const string emptyHashSetLabel = "Key list is empty";

	private const string refreshHashSetButtonLabel = "Refresh";

	private event Func<HashSet<string>> refreshHashSetFunction;

	public AmazonGameCircleExampleWSHashSet(string title, Func<HashSet<string>> refreshFunction)
	{
		hashSetTitle = title;
		if (refreshFunction != null)
		{
			refreshHashSetFunction += refreshFunction;
			Refresh();
		}
	}

	public void DrawGUI()
	{
		GUILayout.BeginVertical(GUI.skin.box);
		foldoutOpen = AmazonGUIHelpers.FoldoutWithLabel(foldoutOpen, hashSetTitle);
		if (foldoutOpen)
		{
			if (GUILayout.Button("Refresh"))
			{
				Refresh();
			}
			if (hashSet.Count == 0)
			{
				AmazonGUIHelpers.CenteredLabel("Key list is empty");
			}
			else
			{
				foreach (string item in hashSet)
				{
					AmazonGUIHelpers.CenteredLabel(item);
				}
			}
		}
		GUILayout.EndVertical();
	}

	public void Refresh()
	{
		if (this.refreshHashSetFunction != null)
		{
			hashSet = this.refreshHashSetFunction();
		}
	}
}
