using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace GraphWarCS.ViewModels
{
	public class GlobalGameViewModel : ViewModelBase
	{
		public GlobalGameViewModel(MainViewModel parentModel, string playerName)
		{
			BackCommand = ReactiveCommand.Create(parentModel.BackToMainScreen);
			players = new() { "a", "b"};
			chat = "\n";
		}

		public ICommand BackCommand { get; set; }

		private string chat;
		public string Chat { get { return chat; } }

		private ObservableCollection<string> players;
		public ObservableCollection<string> Players { get {  return players; } }
	}
}
