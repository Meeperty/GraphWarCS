using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;

namespace GraphWarCS.Network
{
	public class GlobalClient : INotifyPropertyChanged
	{
		private ClientSideConnection clientConnection;

		public event EventHandler<bool>? OnDisconnect;
		public event PropertyChangedEventHandler? PropertyChanged;

		public Dictionary<int, string> Players { get; } = new();
		public List<Room> Rooms { get; } = new();
		public List<ChatItem> Chat { get; } = new();

		public GlobalClient(string playerName)
		{
			clientConnection = new(playerName);
			clientConnection.OnDisconnect += (object? o, bool lostConnection) =>
			{
				Debug.WriteLine($"{Utils.CurrentTime} GlobalClient disconnected, lostConnection {lostConnection}");
				OnDisconnect?.Invoke(o, lostConnection);
			};
			clientConnection.OnIncomingMessage += (HandleMessageEventArgs args) =>
			{
				Debug.WriteLine($"{Utils.CurrentTime} GlobalClient received code {args.code} with args {string.Join("&", args.args)}");
				HandleMessage(args.code, args.args);
			};
		}

		public void HandleMessage(NetworkCode code, params string[] args)
		{
			switch (code)
			{
				case NetworkCode.JOIN:
					{
						lock (Players)
						{
							Players.Add(int.Parse(args[1]), args[0]);
							PropertyChanged?.Invoke(this, new(nameof(Players)));
							Debug.WriteLine($"{Utils.CurrentTime} GlobalClient added player \"{args[0]}\" with id {args[1]}");
							break;
						}
					}

				case NetworkCode.LIST_PLAYERS:
					{
						lock (Players)
						{
							Players.Clear();
							int numPlayers = int.Parse(args[0]);
							for (int i = 0; i < numPlayers; i++)
							{
								Players.Add(int.Parse(args[2 + 2 * i]), args[1 + 2 * i]);
								Debug.WriteLine($"{Utils.CurrentTime} GlobalClient player list: {i} name:{args[2 + 2 * i]} ID:{args[1 + 2 * i]}");
							}
							PropertyChanged?.Invoke(this, new(nameof(Players)));
							break;
						}
					}

				case NetworkCode.QUIT:
					{
						Debug.WriteLine($"{Utils.CurrentTime} GlobalClient recieved unimplemented {code} with args {args}");
						break;
					}


				case NetworkCode.SAY_CHAT:
					{
						lock (Chat)
						{
							int playerID = int.Parse(args[0]);
							string message = args[1];
							string playerName;
							if (Players.ContainsKey(playerID))
								playerName = Players[playerID];
							else
							{
								playerName = playerID.ToString();
							}
							ChatItem item = new(playerID, message, playerName);
							Chat.Add(item);
							PropertyChanged?.Invoke(this, new(nameof(Chat)));
						}
						break;
					}


				case NetworkCode.CREATE_ROOM:
					{
						lock (Rooms)
						{
							string roomName = args[0];
							int roomID = int.Parse(args[1]);
							IPEndPoint endpoint = Utils.EndPointFromIPandPort(args[2], args[3]);

							Room rm = new Room(roomName, roomID, endpoint, GameMode.NORMAL, 0);
							Rooms.Add(rm);
							PropertyChanged?.Invoke(this, new(nameof(Rooms)));
							Debug.WriteLine($"{Utils.CurrentTime} GlobalClient adding room: name:{roomName} ID:{roomID} IP:{args[2]} port:{args[3]}");
							break;
						}
					}

				case NetworkCode.LIST_ROOMS:
					{
						lock (Rooms)
						{
							Rooms.Clear();
							int numRooms = int.Parse(args[0]);
							for (int i = 0; i < numRooms; i++)
							{
								string name = args[1 + 6 * i];
								int ID = int.Parse(args[2 + 6 * i]);
								IPAddress address = IPAddress.Parse(args[3 + 6 * i]);
								int port = int.Parse(args[4 + 6 * i]);
								GameMode mode = (GameMode)Enum.Parse(typeof(GameMode), args[5 + 6 * i]);
								int playersCount = int.Parse(args[6 + 6 * i]);

								Room rm = new Room(name, ID, new IPEndPoint(address, port), mode, playersCount);
								Rooms.Add(rm);

								PropertyChanged?.Invoke(this, new(nameof(Rooms)));
								Debug.WriteLine($"{Utils.CurrentTime} GlobalClient room list: {i} name:{name} ID:{ID} IP:{address} port:{port} mode:{mode} num players:{playersCount}");
							}
							break;
						}
					}

				case NetworkCode.ROOM_STATUS:
					{
						lock (Rooms)
						{
							int ID = int.Parse(args[0]);
							GameMode newMode = (GameMode)Enum.Parse(typeof(GameMode), args[1]);
							int newNumPlayers = int.Parse(args[2]);

							int index = Rooms.FindIndex(rm => rm.RoomID == ID);
							if (index != -1) //the room was found
							{
								Rooms[index].UpdateRoom(newMode, newNumPlayers);
								PropertyChanged?.Invoke(this, new(nameof(Rooms)));
								Debug.WriteLine($"{Utils.CurrentTime} GlobalClient updating room: id:{ID} mode:{newMode} playerCount:{newNumPlayers}");
							}
							else
							{
								Debug.WriteLine($"{Utils.CurrentTime} GlobalClient tried to update room with id:{ID}, not found");
							}
							break;
						}
					}

				case NetworkCode.CLOSE_ROOM:
					{
						lock (Rooms)
						{
							int ID = int.Parse(args[0]);

							int index = Rooms.FindIndex(rm => rm.RoomID == ID);
							Debug.WriteLine($"{Utils.CurrentTime} GlobalClient closing room \"{Rooms[index].RoomName}\"");
							Rooms.RemoveAt(index);
							PropertyChanged?.Invoke(this, new(nameof(Rooms)));
							break;
						}
					}

				case NetworkCode.ROOM_INVALID:
					{
						Debug.WriteLine($"{Utils.CurrentTime} GlobalClient recieved unimplemented {code} with args {args}");
						break;
					}

				default:
					{
						Debug.WriteLine($"{Utils.CurrentTime} GlobalClient recieved unimplemented {code} with args {args}");
						break;
					}
			}
		}

		public void Disconnect()
		{
			clientConnection.Disconnect();
		}
	}
}
