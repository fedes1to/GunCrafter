using System;
using System.Collections;
using System.Collections.Generic;
using AmazonCommon;

public class AGSRequestBatchFriendsResponse : AGSRequestResponse
{
	public List<AGSPlayer> friends;

	public static AGSRequestBatchFriendsResponse FromJSON(string json)
	{
		try
		{
			AGSRequestBatchFriendsResponse aGSRequestBatchFriendsResponse = new AGSRequestBatchFriendsResponse();
			Hashtable hashtable = json.hashtableFromJson();
			aGSRequestBatchFriendsResponse.error = ((!hashtable.ContainsKey("error")) ? string.Empty : hashtable["error"].ToString());
			aGSRequestBatchFriendsResponse.userData = (hashtable.ContainsKey("userData") ? int.Parse(hashtable["userData"].ToString()) : 0);
			aGSRequestBatchFriendsResponse.friends = new List<AGSPlayer>();
			if (hashtable.ContainsKey("friends"))
			{
				IEnumerator enumerator = (hashtable["friends"] as ArrayList).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Hashtable playerDataAsHashtable = (Hashtable)enumerator.Current;
						aGSRequestBatchFriendsResponse.friends.Add(AGSPlayer.fromHashtable(playerDataAsHashtable));
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
			return aGSRequestBatchFriendsResponse;
		}
		catch (Exception ex)
		{
			AGSClient.LogGameCircleError(ex.ToString());
			return GetBlankResponseWithError("ERROR_PARSING_JSON");
		}
	}

	public static AGSRequestBatchFriendsResponse GetBlankResponseWithError(string error, List<string> friendIdsRequested = null, int userData = 0)
	{
		AGSRequestBatchFriendsResponse aGSRequestBatchFriendsResponse = new AGSRequestBatchFriendsResponse();
		aGSRequestBatchFriendsResponse.error = error;
		aGSRequestBatchFriendsResponse.friends = new List<AGSPlayer>();
		if (friendIdsRequested != null)
		{
			foreach (string item in friendIdsRequested)
			{
				aGSRequestBatchFriendsResponse.friends.Add(AGSPlayer.BlankPlayerWithID(item));
			}
		}
		aGSRequestBatchFriendsResponse.userData = userData;
		return aGSRequestBatchFriendsResponse;
	}

	public static AGSRequestBatchFriendsResponse GetPlatformNotSupportedResponse(List<string> friendIdsRequested, int userData)
	{
		return GetBlankResponseWithError("PLATFORM_NOT_SUPPORTED", friendIdsRequested, userData);
	}
}
