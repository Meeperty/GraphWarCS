namespace GraphWarCS
{
	//Notes:
	//
	//Arguments/sections are separated by &
	//Messages are separated by 0x0a bytes, Line Feed
	//
	//To connect to server the client sends just the player name, no constant or anything
	//The server responds with JOIN, LIST_ROOMS, & LIST_PLAYERS

	public enum NetworkCode
	{
		/// <summary>
		/// Basically just keepalive I think
		/// </summary>
		KEEP_ALIVE = 10,

		/// <summary>
		/// ???
		/// </summary>
		ALL_INFO = 11,

		/// <summary>
		/// ???
		/// </summary>
		SET_NAME = 12,

		/// <summary>
		/// ???
		/// </summary>
		CHANGE_MODE = 13,

		/// <summary>
		/// ???
		/// </summary>
		CHAT_MSG = 14,

		/// <summary>
		/// ???
		/// </summary>
		CLOSE_CONNECTION = 15,

		/// <summary>
		/// ???
		/// </summary>
		ADD_PLAYER = 16,

		/// <summary>
		/// ???
		/// </summary>
		ADD_SOLDIER = 17,

		/// <summary>
		/// ???
		/// </summary>
		SET_SOLDIER = 18,

		/// <summary>
		/// ???
		/// </summary>
		REMOVE_SOLDIER = 19,

		/// <summary>
		/// ???
		/// </summary>
		SET_TEAM = 20,

		/// <summary>
		/// ???
		/// </summary>
		SET_READY = 21,

		/// <summary>
		/// ???
		/// </summary>
		START_GAME = 22,

		/// <summary>
		/// ???
		/// </summary>
		CHANGE_GAME_TYPE = 23,

		/// <summary>
		/// ???
		/// </summary>
		FIRE_FUNC = 24,

		/// <summary>
		/// ???
		/// </summary>
		NEXT_TURN = 25,

		/// <summary>
		/// ???
		/// </summary>
		SEND_FUNC = 26,

		/// <summary>
		/// ???
		/// </summary>
		READY_NEXT_TURN = 27,

		/// <summary>
		/// ???
		/// </summary>
		SET_ANGLE = 28,

		/// <summary>
		/// ???
		/// </summary>
		REMOVE_PLAYER = 29,

		/// <summary>
		/// ???
		/// </summary>
		END_GAME = 30,

		/// <summary>
		/// ???
		/// </summary>
		NEXT_MODE = 31,

		/// <summary>
		/// ???
		/// </summary>
		PREVIOUS_MODE = 32,

		/// <summary>
		/// ???
		/// </summary>
		SET_MODE = 33,

		/// <summary>
		/// ???
		/// </summary>
		CHANGE_ANGLE = 34,

		/// <summary>
		/// ???
		/// </summary>
		KILL_PLAYER = 35,

		/// <summary>
		/// ???
		/// </summary>
		CONNECTION_ACCEPTED = 36,

		/// <summary>
		/// ???
		/// </summary>
		TIME_UP = 37,

		/// <summary>
		/// ???
		/// </summary>
		GAME_FULL = 38,

		/// <summary>
		/// Sent from client to server to disconnect
		/// </summary>
		DISCONNECT = 39,

		/// <summary>
		/// ???
		/// </summary>
		GAME_FINISHED = 40,

		/// <summary>
		/// ???
		/// </summary>
		NEW_LEADER = 41,

		/// <summary>
		/// ???
		/// </summary>
		START_COUNTDOWN = 42,

		/// <summary>
		/// ???
		/// </summary>
		REORDER = 43,

		/// <summary>
		/// ???
		/// </summary>
		FUNCTION_PREVIEW = 44,



		/// <summary>
		/// Sent back from the server to client upon joining
		/// </summary>
		/// <remarks>
		/// Format:
		/// 101&
		/// player name&
		/// player ID
		/// </remarks>
		JOIN = 101,

		/// <summary>
		/// ???
		/// </summary>
		SAY_CHAT = 102,

		/// <summary>
		/// Sent back from the server to client upon joining, lists players
		/// </summary>
		/// <remarks>
		/// Format:
		/// 103&
		/// num players&
		/// { repeat for each player
		/// player name&
		/// ID
		/// }
		/// </remarks>
		LIST_PLAYERS = 103,

		/// <summary>
		/// Sent back from the server to client upon joining, lists global rooms
		/// </summary>
		/// <remarks>
		/// Format:
		/// 104&
		/// num rooms&
		/// { repeat for each room
		/// room name&
		/// ID&
		/// gamemode&
		/// num players
		/// }
		/// </remarks>
		LIST_ROOMS = 104,

		/// <summary>
		/// Sent from server to client to indicate that a room's status has changed
		/// </summary>
		/// <remarks>
		/// Format:
		/// 105&
		/// room ID&
		/// new game mode&
		/// new num players
		/// </remarks>
		ROOM_STATUS = 105,

		/// <summary>
		/// Sent from server to client to indicate that a player has quit
		/// </summary>
		/// <remarks>
		/// Format:
		/// 106&
		/// ID of player who quit
		/// </remarks>
		QUIT = 106,

		/// <summary>
		/// ???
		/// </summary>
		CLOSE_ROOM = 107,

		/// <summary>
		/// ???
		/// </summary>
		CREATE_ROOM = 108,

		/// <summary>
		/// ???
		/// </summary>
		ROOM_INVALID = 109,
	}
}
