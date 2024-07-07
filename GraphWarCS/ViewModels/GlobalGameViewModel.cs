using GraphWarCS.Network;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace GraphWarCS.ViewModels
{
	public class GlobalGameViewModel : ViewModelBase
	{
		public ICommand BackCommand { get; set; }
		public ICommand JoinCommand { get; set; }
		public ICommand CreateGlobalCommand { get; set; }

		new public event PropertyChangedEventHandler? PropertyChanged;

		public ObservableCollection<ChatItem> Chat { get { return new(client.Chat); } }

		public ObservableCollection<Room> GlobalRooms { get { return new(client.Rooms); } }

		public ObservableCollection<string> Players { get { return new(client.Players.ToList().Select(x => x.Value).ToList()); } }

		private GlobalClient client;

		public GlobalGameViewModel(MainViewModel parentModel, string playerName)
		{
			BackCommand = ReactiveCommand.Create(parentModel.BackToMainScreen);

			CreateGlobalCommand = ReactiveCommand.Create(() => { throw new NotImplementedException(); });

			client = new GlobalClient(playerName);
			client.PropertyChanged += (object? o, PropertyChangedEventArgs args) =>
			{
				if (args.PropertyName == nameof(GlobalClient.Players))
					this.RaisePropertyChanged(nameof(Players));
				else if (args.PropertyName == nameof(GlobalClient.Rooms))
					this.RaisePropertyChanged(nameof(GlobalRooms));
				else if (args.PropertyName == nameof(GlobalClient.Chat))
					this.RaisePropertyChanged(nameof(Chat));
			};
		}

		~GlobalGameViewModel()
		{
			client.Disconnect();
		}
	}
}
