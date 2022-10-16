using System;
using System.Collections;
using System.Collections.Generic;
using AmazonCommon;

public class AGSRequestAchievementsForPlayerResponse : AGSRequestAchievementsResponse
{
	public string playerId;

	public new static AGSRequestAchievementsForPlayerResponse FromJSON(string json)
	{
		try
		{
			AGSRequestAchievementsForPlayerResponse aGSRequestAchievementsForPlayerResponse = new AGSRequestAchievementsForPlayerResponse();
			Hashtable hashtable = json.hashtableFromJson();
			aGSRequestAchievementsForPlayerResponse.error = ((!hashtable.ContainsKey("error")) ? string.Empty : hashtable["error"].ToString());
			aGSRequestAchievementsForPlayerResponse.userData = (hashtable.ContainsKey("userData") ? int.Parse(hashtable["userData"].ToString()) : 0);
			aGSRequestAchievementsForPlayerResponse.achievements = new List<AGSAchievement>();
			if (hashtable.ContainsKey("achievements"))
			{
				IEnumerator enumerator = (hashtable["achievements"] as ArrayList).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Hashtable hashtable2 = (Hashtable)enumerator.Current;
						aGSRequestAchievementsForPlayerResponse.achievements.Add(AGSAchievement.fromHashtable(hashtable2));
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = enumerator as IDisposable) != null)
					{
						disposable.Dispose();
					}
				}
			}
			aGSRequestAchievementsForPlayerResponse.playerId = ((!hashtable.ContainsKey("playerId")) ? string.Empty : hashtable["playerId"].ToString());
			return aGSRequestAchievementsForPlayerResponse;
		}
		catch (Exception ex)
		{
			AGSClient.LogGameCircleError(ex.ToString());
			return GetBlankResponseWithError("ERROR_PARSING_JSON", string.Empty);
		}
	}

	public static AGSRequestAchievementsForPlayerResponse GetBlankResponseWithError(string error, string playerId = "", int userData = 0)
	{
		AGSRequestAchievementsForPlayerResponse aGSRequestAchievementsForPlayerResponse = new AGSRequestAchievementsForPlayerResponse();
		aGSRequestAchievementsForPlayerResponse.error = error;
		aGSRequestAchievementsForPlayerResponse.playerId = playerId;
		aGSRequestAchievementsForPlayerResponse.userData = userData;
		aGSRequestAchievementsForPlayerResponse.achievements = new List<AGSAchievement>();
		return aGSRequestAchievementsForPlayerResponse;
	}

	public static AGSRequestAchievementsForPlayerResponse GetPlatformNotSupportedResponse(string playerId, int userData)
	{
		return GetBlankResponseWithError("PLATFORM_NOT_SUPPORTED", playerId, userData);
	}
}
