using System;

[Serializable]
public class AchievementClass
{
	public string Name;

	public string Description;

	public string ID;

	public string GameServicesID;

	public float Progress;

	public int Value;

	public bool LocalReported;

	public bool GameCenterOnly;

	public int TrophyImage;

	public AchievementClass(string N, string D, string I, string GSID, int V, int T, bool GCO)
	{
		Name = N;
		Description = D;
		ID = I;
		GameServicesID = GSID;
		Value = V;
		TrophyImage = T;
		GameCenterOnly = GCO;
	}
}
