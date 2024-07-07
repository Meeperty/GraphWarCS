using Avalonia.Media;
using ReactiveUI;

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

	public void BackToMainScreen(bool disconnected)
	{
		ContentViewModel = new MainMenuViewModel(this);
	}
	public void BackToMainScreen() //this is here because ReactiveCommand wont take a method with an optional argument
	{
		BackToMainScreen(false);
	}

	//public void JoinLobby(Connection)
	//{

	//}
}
