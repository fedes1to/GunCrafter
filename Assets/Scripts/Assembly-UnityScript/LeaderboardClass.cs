using System;

[Serializable]
public class LeaderboardClass
{
	public string Name;

	public string ID;

	public string GameServicesID;

	public int Score;

	public bool GameCenterOnly;

	public bool Invisible;

	public LeaderboardClass(string N, string I, string GSID, bool GCO, bool V)
	{
		Name = N;
		ID = I;
		GameServicesID = GSID;
		GameCenterOnly = GCO;
		Invisible = V;
	}
}
