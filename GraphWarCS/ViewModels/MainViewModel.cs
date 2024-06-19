using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace GraphWarCS.ViewModels;

public class MainViewModel : ViewModelBase
{
	public MainViewModel()
	{
		contentViewModel = new MainMenuViewModel(this);
	}

	private ViewModelBase contentViewModel;
	public ViewModelBase ContentViewModel
	{
		get => contentViewModel;
		set => this.RaiseAndSetIfChanged(ref contentViewModel, value);
	}

	public IBrush BGBrush => Constants.bgBrush;


	public void JoinGlobalScreen(string playerName)
	{
		ContentViewModel = new GlobalGameViewModel(this, playerName);
	}

	public void BackToMainScreen()
	{
		ContentViewModel = new MainMenuViewModel(this);
	}

	private GraphServer graphServer;
	public GraphServer GraphServer => graphServer;

	//private GameData gameData;
	//public GameData GameData => gameData;

	//private GlobalClient globalClient;
	//public GlobalClient GlobalClient => globalClient;

}
