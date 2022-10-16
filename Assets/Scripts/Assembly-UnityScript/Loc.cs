using System;
using System.Collections.Generic;
using System.IO;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Loc : MonoBehaviour
{
	[NonSerialized]
	private static bool ShowWarnings;

	[NonSerialized]
	public static Dictionary<string, string> LocalizationDictionary = new Dictionary<string, string>();

	public static void LoadResource(string value)
	{
		TextAsset textAsset = Resources.Load(value) as TextAsset;
		if (textAsset != null)
		{
			LoadLanguage(textAsset);
		}
		else
		{
			Debug.LogError("Missing localization file at " + value + ". Did you mean to use the no-argument version of LoadResource()?");
		}
	}

	public static void LoadResource()
	{
		TextAsset textAsset = Resources.Load("Localization/" + Settings.Language + "/" + Settings.Language) as TextAsset;
		if (textAsset == null)
		{
			textAsset = Resources.Load("Localization/" + Settings.Language + "/Localizable") as TextAsset;
		}
		if (textAsset != null)
		{
			LoadLanguage(textAsset);
		}
		else
		{
			Debug.LogError("Missing localization file!");
		}
	}

	private static void LoadLanguage(TextAsset asset)
	{
		LocalizationDictionary.Clear();
		int num = 1;
		StringReader stringReader = new StringReader(asset.text);
		string text = stringReader.ReadLine();
		while (text != null)
		{
			UnityScript.Lang.Array array = text.Split("\""[0]);
			if (array.length > 1)
			{
				object obj = array[1];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string text2 = (string)obj;
				object obj2 = array[3];
				if (!(obj2 is string))
				{
					obj2 = RuntimeServices.Coerce(obj2, typeof(string));
				}
				string text3 = (string)obj2;
				if (text2 != null && text3 != null)
				{
					string text4 = text2.ToLower();
					if (LocalizationDictionary.ContainsKey(text4))
					{
						Debug.LogWarning(string.Format("Duplicate key '{1}' in language file '{0}' detected.", asset.text, text2));
					}
					try
					{
						LocalizationDictionary.Add(text4, text3);
					}
					catch (Exception ex)
					{
						Debug.Log("Error: " + ex.Message + " - Key is: " + text4);
					}
				}
				num++;
			}
			text = stringReader.ReadLine();
		}
	}

	public static string L(string key)
	{
		string key2 = key.ToLower();
		string result;
		if (LocalizationDictionary.ContainsKey(key2))
		{
			result = LocalizationDictionary[key2];
		}
		else
		{
			if (ShowWarnings)
			{
				Debug.LogWarning("Couldn't find key " + key + " in language dictionary");
			}
			result = key;
		}
		return result;
	}

	public static string L(string key, string Rep0)
	{
		string workingString = L(key);
		return ReplaceValue(workingString, Rep0);
	}

	public static string L(string key, string Rep0, string Rep1)
	{
		string workingString = L(key);
		return ReplaceValue(workingString, Rep0, Rep1);
	}

	public static string L(string key, string Rep0, string Rep1, string Rep2)
	{
		string workingString = L(key);
		return ReplaceValue(workingString, Rep0, Rep1, Rep2);
	}

	public static string ReplaceValue(string WorkingString, string Rep0)
	{
		WorkingString = ReplaceValueExecute(WorkingString, "_XXX_", Rep0);
		return WorkingString;
	}

	public static string ReplaceValue(string WorkingString, string Rep0, string Rep1)
	{
		WorkingString = ReplaceValueExecute(WorkingString, "_XXX_", Rep0);
		WorkingString = ReplaceValueExecute(WorkingString, "_YYY_", Rep1);
		return WorkingString;
	}

	public static string ReplaceValue(string WorkingString, string Rep0, string Rep1, string Rep2)
	{
		WorkingString = ReplaceValueExecute(WorkingString, "_XXX_", Rep0);
		WorkingString = ReplaceValueExecute(WorkingString, "_YYY_", Rep1);
		WorkingString = ReplaceValueExecute(WorkingString, "_ZZZ_", Rep2);
		return WorkingString;
	}

	public static string ReplaceValueExecute(string WorkingString, string OriginalBit, string ReplacementBit)
	{
		if (!WorkingString.Contains(OriginalBit))
		{
			Debug.LogError("Couldn't find " + OriginalBit + " in: " + WorkingString);
		}
		WorkingString = WorkingString.Replace(OriginalBit, ReplacementBit);
		return WorkingString;
	}

	public static bool ContainsL(string key)
	{
		string key2 = key.ToLower();
		return LocalizationDictionary.ContainsKey(key2) ? true : false;
	}

	public virtual void Main()
	{
	}
}
