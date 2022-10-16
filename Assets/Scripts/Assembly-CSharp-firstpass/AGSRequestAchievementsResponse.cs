using System;
using System.Collections;
using System.Collections.Generic;
using AmazonCommon;

public class AGSRequestAchievementsResponse : AGSRequestResponse
{
	public List<AGSAchievement> achievements;

	public static AGSRequestAchievementsResponse FromJSON(string json)
	{
		try
		{
			AGSRequestAchievementsResponse aGSRequestAchievementsResponse = new AGSRequestAchievementsResponse();
			Hashtable hashtable = json.hashtableFromJson();
			aGSRequestAchievementsResponse.error = ((!hashtable.ContainsKey("error")) ? string.Empty : hashtable["error"].ToString());
			aGSRequestAchievementsResponse.userData = (hashtable.ContainsKey("userData") ? int.Parse(hashtable["userData"].ToString()) : 0);
			aGSRequestAchievementsResponse.achievements = new List<AGSAchievement>();
			if (hashtable.ContainsKey("achievements"))
			{
				IEnumerator enumerator = (hashtable["achievements"] as ArrayList).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Hashtable hashtable2 = (Hashtable)enumerator.Current;
						aGSRequestAchievementsResponse.achievements.Add(AGSAchievement.fromHashtable(hashtable2));
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
			return aGSRequestAchievementsResponse;
		}
		catch (Exception ex)
		{
			AGSClient.LogGameCircleError(ex.ToString());
			return GetBlankResponseWithError("ERROR_PARSING_JSON");
		}
	}

	public static AGSRequestAchievementsResponse GetBlankResponseWithError(string error, int userData = 0)
	{
		AGSRequestAchievementsResponse aGSRequestAchievementsResponse = new AGSRequestAchievementsResponse();
		aGSRequestAchievementsResponse.error = error;
		aGSRequestAchievementsResponse.userData = userData;
		aGSRequestAchievementsResponse.achievements = new List<AGSAchievement>();
		return aGSRequestAchievementsResponse;
	}

	public static AGSRequestAchievementsResponse GetPlatformNotSupportedResponse(int userData)
	{
		return GetBlankResponseWithError("PLATFORM_NOT_SUPPORTED", userData);
	}
}
