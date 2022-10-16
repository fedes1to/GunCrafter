using System;
using System.Text.RegularExpressions;
using UnityEngine;

[Serializable]
public class Settings : MonoBehaviour
{
	[NonSerialized]
	public static float DPI;

	[NonSerialized]
	public static float Scale;

	[NonSerialized]
	public static string Suffix;

	[NonSerialized]
	public static int SuffixInteger;

	[NonSerialized]
	public static int Quality;

	[NonSerialized]
	public static string Language = string.Empty;

	[NonSerialized]
	public static string DeviceID;

	[NonSerialized]
	public static bool SupportedLanguage;

	[NonSerialized]
	public static bool IsPro;

	[NonSerialized]
	public static bool RetrievedPro;

	[NonSerialized]
	public static string ProPath = "Naquatic/ProSetting";

	[NonSerialized]
	public static bool ChineseTraditional;

	private float BackupTime;

	private float BackupDelay;

	public virtual void Awake()
	{
		Application.targetFrameRate = 60;
		Initialize();
		if (!Saver.isOpen())
		{
			Saver.Open();
		}
		DeviceID = Regex.Replace(SystemInfo.deviceUniqueIdentifier, "[^\\w\\._]", string.Empty);
		if (Saver.Get("StoredDeviceID") != string.Empty)
		{
			DeviceID = Saver.Get("StoredDeviceID");
		}
		else
		{
			Saver.Set("StoredDeviceID", DeviceID);
		}
		DPI = Screen.dpi;
		GetScale();
		if (!(Scale > 1f))
		{
			Quality = 1;
		}
		else
		{
			Quality = 5;
		}
		if (Application.isEditor)
		{
			DPI = 326f;
		}
		if (DPI == 0f)
		{
			DPI = 163f;
		}
		SetLanguage();
	}

	public static void SetLanguage()
	{
		int i = 0;
		SystemLanguage[] supportedLanguages = App.SupportedLanguages;
		for (int length = supportedLanguages.Length; i < length; i++)
		{
			if (supportedLanguages[i] != Application.systemLanguage)
			{
				continue;
			}
			if (Application.systemLanguage == SystemLanguage.Chinese)
			{
				if (ChineseTraditional)
				{
					if (SupportsTraditionalChinese())
					{
						Language = "ChineseTraditional";
						SupportedLanguage = true;
					}
					else
					{
						Language = "English";
						SupportedLanguage = false;
					}
				}
				else
				{
					Language = Application.systemLanguage.ToString();
					SupportedLanguage = true;
				}
			}
			else
			{
				Language = Application.systemLanguage.ToString();
				SupportedLanguage = true;
			}
		}
		if (Application.systemLanguage.ToString() == "Unknown")
		{
			SupportedLanguage = true;
		}
		if (Language == string.Empty)
		{
			Language = "English";
		}
		if (Application.isEditor)
		{
			Language = "English";
		}
	}

	public static bool SupportsTraditionalChinese()
	{
		int num = 0;
		SystemLanguage[] supportedLanguages = App.SupportedLanguages;
		int length = supportedLanguages.Length;
		int result;
		while (true)
		{
			if (num < length)
			{
				if (supportedLanguages[num] == SystemLanguage.Thai)
				{
					result = 1;
					break;
				}
				num++;
				continue;
			}
			result = 0;
			break;
		}
		return (byte)result != 0;
	}

	public virtual void ReceiveLanguage(string Message)
	{
		ChineseTraditional = true;
	}

	public static void Initialize()
	{
		if (!RetrievedPro)
		{
			RetrievedPro = true;
			TextAsset textAsset = (TextAsset)Resources.Load(ProPath, typeof(TextAsset));
			if (textAsset == null)
			{
				IsPro = false;
			}
			else
			{
				IsPro = bool.Parse(textAsset.text);
			}
			App.InitializeMetadata();
			App.Initialize();
		}
	}

	public static void GetScale()
	{
		if (!App.IsPortrait)
		{
			if (!((float)Screen.width * 1f / (float)Screen.height <= 1.5f))
			{
				Scale = (float)Screen.height * 1f / 320f;
			}
			else
			{
				Scale = (float)Screen.width * 1f / 480f;
			}
		}
		else if (!((float)Screen.height * 1f / (float)Screen.width <= 1.5f))
		{
			Scale = (float)Screen.width * 1f / 320f;
		}
		else
		{
			Scale = (float)Screen.height * 1f / 480f;
		}
		if (!(Scale > 1f))
		{
			Suffix = string.Empty;
			SuffixInteger = 1;
		}
		else if (!(Scale > 2f))
		{
			Suffix = "@2x";
			SuffixInteger = 2;
		}
		else
		{
			Suffix = "@2x~ipad";
			SuffixInteger = 4;
		}
	}

	public virtual void Update()
	{
		if (!(Time.time - BackupTime <= 60f) && !(BackupDelay > 0f))
		{
			BackupTime = Time.time;
			Saver.Save(true);
		}
		BackupDelay -= Time.deltaTime;
	}

	public virtual void OnApplicationPause(bool pause)
	{
	}

	public virtual void OnApplicationFocus(bool GainedFocus)
	{
		if (!Application.isEditor && !GainedFocus)
		{
			BackupDelay = 2f;
			Saver.Save();
		}
	}

	public virtual void Main()
	{
	}
}
