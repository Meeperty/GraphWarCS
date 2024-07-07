using ReactiveUI;
using System.Reactive;

namespace GraphWarCS.ViewModels
{
	public class JoinGlobalPopupViewModel : ViewModelBase
	{
		public ReactiveCommand<Unit, string?> JoinCommand { get; set; }
		public ReactiveCommand<Unit, string?> BackCommand { get; set; }

		public JoinGlobalPopupViewModel()
		{
			JoinCommand = ReactiveCommand.Create<string?>(() =>
			{
				return Name;
			});
			BackCommand = ReactiveCommand.Create<string?>(() =>
			{
				return null;
			});
		}

		private string name = "";
		public string Name
		{
			get { return name; }
			set { this.RaiseAndSetIfChanged(ref name, value); }
		}
	}
}
