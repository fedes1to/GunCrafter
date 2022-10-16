using System;
using UnityEngine;

[Serializable]
public class BlockSet
{
	public string Name;

	public GameObject[] Blocks;

	[HideInInspector]
	public Texture2D[] InventoryGUIs;
}
