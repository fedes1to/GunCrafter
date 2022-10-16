using UnityEngine;

public class SafeArea : MonoBehaviour
{
	public static Rect GetSafeArea()
	{
		float x = 0f;
		float y = 0f;
		float width = Screen.width;
		float height = Screen.height;
		if (Screen.width > Screen.height)
		{
			y = 0f;
			height = Screen.height;
		}
		return new Rect(x, y, width, height);
	}

	public static bool IsiPhoneXAspectRatio()
	{
		bool flag = Mathf.Round((float)Screen.width * 1f / (float)Screen.height * 10f) == Mathf.Round(21.653334f);
		bool flag2 = Mathf.Round((float)Screen.height * 1f / (float)Screen.width * 10f) == Mathf.Round(21.653334f);
		return flag || flag2;
	}
}
