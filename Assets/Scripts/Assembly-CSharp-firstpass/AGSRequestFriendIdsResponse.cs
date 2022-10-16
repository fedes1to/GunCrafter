using System;
using System.Collections;
using System.Collections.Generic;
using AmazonCommon;

public class AGSRequestFriendIdsResponse : AGSRequestResponse
{
	public List<string> friendIds;

	public static AGSRequestFriendIdsResponse FromJSON(string json)
	{
		try
		{
			AGSRequestFriendIdsResponse aGSRequestFriendIdsResponse = new AGSRequestFriendIdsResponse();
			Hashtable hashtable = json.hashtableFromJson();
			aGSRequestFriendIdsResponse.error = ((!hashtable.ContainsKey("error")) ? string.Empty : hashtable["error"].ToString());
			aGSRequestFriendIdsResponse.userData = (hashtable.ContainsKey("userData") ? int.Parse(hashtable["userData"].ToString()) : 0);
			aGSRequestFriendIdsResponse.friendIds = new List<string>();
			if (hashtable.ContainsKey("friendIds"))
			{
				IEnumerator enumerator = (hashtable["friendIds"] as ArrayList).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						string item = (string)enumerator.Current;
						aGSRequestFriendIdsResponse.friendIds.Add(item);
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
			return aGSRequestFriendIdsResponse;
		}
		catch (Exception ex)
		{
			AGSClient.LogGameCircleError(ex.ToString());
			return GetBlankResponseWithError("ERROR_PARSING_JSON");
		}
	}

	public static AGSRequestFriendIdsResponse GetBlankResponseWithError(string error, int userData = 0)
	{
		AGSRequestFriendIdsResponse aGSRequestFriendIdsResponse = new AGSRequestFriendIdsResponse();
		aGSRequestFriendIdsResponse.error = error;
		aGSRequestFriendIdsResponse.userData = userData;
		aGSRequestFriendIdsResponse.friendIds = new List<string>();
		return aGSRequestFriendIdsResponse;
	}

	public static AGSRequestFriendIdsResponse GetPlatformNotSupportedResponse(int userData)
	{
		return GetBlankResponseWithError("PLATFORM_NOT_SUPPORTED", userData);
	}
}
