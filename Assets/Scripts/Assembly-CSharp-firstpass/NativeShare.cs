using UnityEngine;

public static class NativeShare
{
	public static void Share(string body, string filePath = null, string url = null, string subject = "", string mimeType = "text/html", bool chooser = false, string chooserText = "Select sharing app")
	{
		ShareMultiple(body, new string[1] { filePath }, url, subject, mimeType, chooser);
	}

	public static void ShareMultiple(string body, string[] filePaths = null, string url = null, string subject = "", string mimeType = "text/html", bool chooser = false, string chooserText = "Select sharing app")
	{
		ShareAndroid(body, subject, url, filePaths, mimeType, chooser, chooserText);
	}

	public static void ShareAndroid(string body, string subject, string url, string[] filePaths, string mimeType, bool chooser, string chooserText)
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent"))
		{
			using (AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent"))
			{
				using (androidJavaObject.Call<AndroidJavaObject>("setAction", new object[1] { androidJavaClass.GetStatic<string>("ACTION_SEND") }))
				{
				}
				using (androidJavaObject.Call<AndroidJavaObject>("setType", new object[1] { mimeType }))
				{
				}
				using (androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[2]
				{
					androidJavaClass.GetStatic<string>("EXTRA_SUBJECT"),
					subject
				}))
				{
				}
				using (androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[2]
				{
					androidJavaClass.GetStatic<string>("EXTRA_TEXT"),
					body
				}))
				{
				}
				if (!string.IsNullOrEmpty(url))
				{
					using (AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("android.net.Uri"))
					{
						using (AndroidJavaObject androidJavaObject6 = androidJavaClass2.CallStatic<AndroidJavaObject>("parse", new object[1] { url }))
						{
							using (androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[2]
							{
								androidJavaClass.GetStatic<string>("EXTRA_STREAM"),
								androidJavaObject6
							}))
							{
							}
						}
					}
				}
				else if (filePaths != null)
				{
					using (AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("android.net.Uri"))
					{
						using (AndroidJavaObject androidJavaObject8 = new AndroidJavaObject("java.util.ArrayList"))
						{
							for (int i = 0; i < filePaths.Length; i++)
							{
								using (AndroidJavaObject androidJavaObject9 = androidJavaClass3.CallStatic<AndroidJavaObject>("parse", new object[1] { "file://" + filePaths[i] }))
								{
									androidJavaObject8.Call<bool>("add", new object[1] { androidJavaObject9 });
								}
							}
							using (androidJavaObject.Call<AndroidJavaObject>("putParcelableArrayListExtra", new object[2]
							{
								androidJavaClass.GetStatic<string>("EXTRA_STREAM"),
								androidJavaObject8
							}))
							{
							}
						}
					}
				}
				using (AndroidJavaClass androidJavaClass4 = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject androidJavaObject12 = androidJavaClass4.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						if (chooser)
						{
							AndroidJavaObject androidJavaObject11 = androidJavaClass.CallStatic<AndroidJavaObject>("createChooser", new object[2] { androidJavaObject, chooserText });
							androidJavaObject12.Call("startActivity", androidJavaObject11);
						}
						else
						{
							androidJavaObject12.Call("startActivity", androidJavaObject);
						}
					}
				}
			}
		}
	}
}
