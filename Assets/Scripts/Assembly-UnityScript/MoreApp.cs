using System;

[Serializable]
public class MoreApp
{
	public string ImageName;

	public string AppleID;

	public string BundleIDGoogle;

	public string BundleIDAmazon;

	public string BundleIDWindowsStore;

	public string BundleIDWindowsPhone;

	public MoreApp(string N, string A, string BG, string BA, string W, string P)
	{
		ImageName = N;
		AppleID = A;
		BundleIDGoogle = BG;
		BundleIDAmazon = BA;
		BundleIDWindowsStore = W;
		BundleIDWindowsPhone = P;
	}
}
