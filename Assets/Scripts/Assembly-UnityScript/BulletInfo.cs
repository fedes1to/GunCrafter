using System;
using UnityEngine;

[Serializable]
public class BulletInfo
{
	public bool WasYou;

	public RaycastHit RayHit;

	public BulletInfo(bool W, RaycastHit R)
	{
		WasYou = W;
		RayHit = R;
	}
}
