using System;
using UnityScript.Lang;

[Serializable]
public class OnlinePlayer
{
	public string Name;

	public int Mode;

	public int DatabaseID;

	public int Seed;

	public UnityScript.Lang.Array Prefix;

	public string Key;

	public bool IsYou;

	public string GCID;

	public bool Disconnected;

	public virtual string DebugData()
	{
		string empty = string.Empty;
		empty += "Name: " + Name + "; ";
		empty += "Mode: " + Mode + "; ";
		empty += "DatabaseID: " + DatabaseID + "; ";
		empty += "Seed: " + Seed + "; ";
		empty += "Prefix: ";
		for (int i = default(int); i < Prefix.length; i++)
		{
			if (i != 0)
			{
				empty += ",";
			}
			empty += Prefix[i];
		}
		empty += "; ";
		return empty + ("Key: " + Key + ";");
	}
}
