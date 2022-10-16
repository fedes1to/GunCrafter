using System;
using System.Collections;
using System.IO;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class Saver : MonoBehaviour
{
	[NonSerialized]
	private static Hashtable data = new Hashtable();

	[NonSerialized]
	private static string filePath = "/faults.def";

	[NonSerialized]
	private static int saverState;

	[NonSerialized]
	private static string ThePath;

	public static void Open()
	{
		ThePath = "/data/data/" + App.BundleID + "/files";
		try
		{
			StreamReader streamReader = new StreamReader(ThePath + filePath);
			int num = UnityBuiltins.parseInt(streamReader.ReadLine());
			string text = streamReader.ReadLine();
			string[] array = text.Split("`"[0]);
			int num2 = array.Length;
			if ((num2 + 3) * (text.Length + 5) * 2 + 3 != num)
			{
				num2 = 0;
			}
			data.Clear();
			for (int i = 0; i < num2 - 1; i += 2)
			{
				if (!string.IsNullOrEmpty(array[i]) && !string.IsNullOrEmpty(array[i + 1]))
				{
					data[array[i]] = array[i + 1];
				}
			}
			streamReader.Close();
			saverState = 1;
		}
		catch (Exception ex)
		{
			Debug.Log("Error: " + ex.Message);
		}
	}

	public static string Get(string key)
	{
		return data.ContainsKey(key) ? data[key].ToString() : string.Empty;
	}

	public static int GetInt(string key)
	{
		int result;
		if (!data.ContainsKey(key))
		{
			result = 0;
		}
		else
		{
			object obj = data[key];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			result = int.Parse((string)obj);
		}
		return result;
	}

	public static float GetFloat(string key)
	{
		float result;
		if (!data.ContainsKey(key))
		{
			result = 0f;
		}
		else
		{
			object obj = data[key];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			result = float.Parse((string)obj);
		}
		return result;
	}

	public static bool GetBoolean(string key)
	{
		return data.ContainsKey(key) && bool.Parse(data[key].ToString());
	}

	public static DateTime GetDate(string key)
	{
		return data.ContainsKey(key) ? DateTime.Parse(data[key].ToString()) : DateTime.Parse("01/01/2011 01:01:01");
	}

	public static void Set(string key, string value)
	{
		saverState = 2;
		data[key] = value;
	}

	public static void Set(string key, int value)
	{
		saverState = 2;
		data[key] = value.ToString();
	}

	public static void SetInt(string key, int value)
	{
		saverState = 2;
		data[key] = value.ToString();
	}

	public static void Set(string key, float value)
	{
		saverState = 2;
		data[key] = value.ToString();
	}

	public static void SetFloat(string key, float value)
	{
		saverState = 2;
		data[key] = value.ToString();
	}

	public static void Set(string key, bool value)
	{
		saverState = 2;
		data[key] = value.ToString();
	}

	public static void Save(bool IsBackup)
	{
	}

	public static void Save()
	{
		try
		{
			string text = string.Empty;
			bool flag = true;
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(data);
			while (enumerator.MoveNext())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)enumerator.Current;
				if (flag)
				{
					flag = false;
				}
				else
				{
					text += "`";
				}
				text += dictionaryEntry.Key + "`" + dictionaryEntry.Value;
				UnityRuntimeServices.Update(enumerator, dictionaryEntry);
			}
			int value = (data.Count * 2 + 3) * (text.Length + 5) * 2 + 3;
			StreamWriter streamWriter = new StreamWriter(ThePath + filePath);
			streamWriter.WriteLine(value);
			streamWriter.WriteLine(text);
			streamWriter.Close();
			saverState = 1;
		}
		catch (Exception ex)
		{
			Debug.Log("Error: " + ex.Message);
		}
	}

	public static bool isOpen()
	{
		return saverState > 0;
	}

	public static bool needsSave()
	{
		return saverState == 2;
	}

	public virtual void Main()
	{
	}
}
