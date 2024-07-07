using ReactiveUI;
using System.Reactive.Linq;
using System.Windows.Input;

namespace GraphWarCS.ViewModels
{
	public class MainMenuViewModel : ViewModelBase
	{
		public MainMenuViewModel(MainViewModel parentModel)
		{
			ShowJoinGlobalDialog = new();

			ShowJoinGlobalCommand = ReactiveCommand.CreateFromTask(async () =>
			{
				var vm = new JoinGlobalPopupViewModel();

				string? result = await ShowJoinGlobalDialog.Handle(vm);

				if (result != null)
				{
					parentModel.JoinGlobalScreen(result);
				}
			});
		}

		public Interaction<JoinGlobalPopupViewModel, string?> ShowJoinGlobalDialog { get; }
		public ICommand ShowJoinGlobalCommand { get; set; }
	}
}
