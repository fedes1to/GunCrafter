using System;
using System.Text;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class RTMListener : RealTimeMultiplayerListener
{
	public Menus MenusInstance;

	public virtual void OnRoomSetupProgress(float percent)
	{
		PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI();
	}

	public virtual void OnRoomConnected(bool Success)
	{
		Debug.Log("OnRoomConnected" + Success);
		if (!Success)
		{
			MenusInstance.Hid("Loading");
			return;
		}
		Menus.GameServicesInRoom = true;
		Menus.IsFriendMatch = true;
		MenusInstance.SendMessage("GameCenterMatchmakerFoundMatch", PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId);
	}

	public virtual void GameServicesSendMessage(string ObjectName, string FunctionName, string Data, bool Important)
	{
		string s = ObjectName + "~~_~~_~~" + FunctionName + "~~_~~_~~" + Data;
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		PlayGamesPlatform.Instance.RealTime.SendMessageToAll(Important, bytes);
	}

	public virtual void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
	{
		string @string = Encoding.UTF8.GetString(data);
		MenusInstance.GameCenterReceiveMessage(@string);
	}

	public virtual void OnLeftRoom()
	{
		Menus.GameServicesInRoom = false;
		MenusInstance.SendMessage("GameCenterPlayerDisconnected", Menus.MyGCID);
	}

	public virtual void OnPeersDisconnected(string[] ParticipantIDs)
	{
		Menus.GameServicesInRoom = false;
		for (int i = default(int); i < Extensions.get_length((System.Array)ParticipantIDs); i++)
		{
			MenusInstance.SendMessage("GameCenterPlayerDisconnected", ParticipantIDs[i]);
		}
	}

	public virtual void OnParticipantLeft(Participant participant)
	{
		//Discarded unreachable code: IL_0006
		throw new NotImplementedException();
	}

	public virtual void OnPeersConnected(string[] participantIds)
	{
		//Discarded unreachable code: IL_0006
		throw new NotImplementedException();
	}
}
