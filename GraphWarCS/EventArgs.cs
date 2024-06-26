using System;

namespace GraphWarCS;

public class NewPlayerEventArgs : EventArgs
{
	public string playerName;
	public int playerID;

	public NewPlayerEventArgs(string name, string ID)
	{
		this.playerName = name;
		this.playerID = int.Parse(ID);
	}
}

public class PlayerQuitEventArgs : EventArgs
{
	public int playerID;

	public PlayerQuitEventArgs(int playerID)
	{
		this.playerID = playerID;
	}
}

public class RoomStatusEventArgs : EventArgs
{
	public int roomID;
	public GameMode gameMode;
	public int numPlayers;

	public RoomStatusEventArgs(int ID, GameMode mode, int numPlayers)
	{
		this.roomID = ID;
		this.gameMode = mode;
		this.numPlayers = numPlayers;
	}
}

public class NewRoomEventArgs : EventArgs
{
	public string roomName;
	public int roomID;
	public GameMode gameMode;
	public int numPlayers;

	public NewRoomEventArgs(string roomName, int roomID, GameMode gameMode, int numPlayers)
	{
		this.roomName = roomName;
		this.roomID = roomID;
		this.gameMode = gameMode;
		this.numPlayers = numPlayers;
	}
}

public class RoomCloseEventArgs : EventArgs
{
	public int roomID;

	public RoomCloseEventArgs(int roomID)
	{
		this.roomID = roomID;
	}
}

public class HandleMessageEventArgs : EventArgs
{
	public NetworkCode code;
	public string[] args;

	public HandleMessageEventArgs(NetworkCode code, string[] args)
	{
		this.code = code;
		this.args = args;
	}
}