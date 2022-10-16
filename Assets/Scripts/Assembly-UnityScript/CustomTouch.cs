using System;
using UnityEngine;

[Serializable]
public class CustomTouch
{
	public int fingerId;

	public Vector2 position;

	public TouchPhase phase;

	public Vector2 delta;

	public float time;

	public bool TouchesAllMember;
}
