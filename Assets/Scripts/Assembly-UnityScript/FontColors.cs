using System;
using UnityEngine;

[Serializable]
public class FontColors
{
	public string Name;

	public Color Col;

	public FontColors(string N, Color C)
	{
		Name = N;
		Col = C;
	}
}
