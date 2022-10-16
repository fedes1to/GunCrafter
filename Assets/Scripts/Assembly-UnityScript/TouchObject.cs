using System;

[Serializable]
public class TouchObject
{
	public int TouchID;

	public bool IsOverObject;

	public TouchObject(int T, bool I)
	{
		TouchID = T;
		IsOverObject = I;
	}
}
