using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AGSSocialLocalUser : AGSSocialUser, ILocalUser, IUserProfile
{
	public static AGSPlayer player = AGSPlayer.GetBlankPlayer();

	public static List<AGSSocialUser> friendList = new List<AGSSocialUser>();

	public IUserProfile[] friends
	{
		get
		{
			return friendList.ToArray();
		}
	}

	public bool authenticated
	{
		get
		{
			return AGSPlayerClient.IsSignedIn();
		}
	}

	public bool underage
	{
		get
		{
			AGSClient.LogGameCircleError("ILocalUser.underage.get is not available for GameCircle");
			return false;
		}
	}

	public void Authenticate(Action<bool> callback)
	{
		GameCircleSocial.Instance.RequestLocalPlayer(callback);
		Social.Active.Authenticate(this, callback);
	}

	public void Authenticate(Action<bool, string> callback)
	{
	}

	public void LoadFriends(Action<bool> callback)
	{
		GameCircleSocial.Instance.RequestFriends(callback);
	}
}
