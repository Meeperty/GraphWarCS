using Avalonia.Controls;
using GraphWarCS.ViewModels;
using ReactiveUI;
using System;
using System.Threading.Tasks;

namespace GraphWarCS.Views
{
	public partial class MainMenuView : UserControl
	{
		public MainMenuView()
		{
			InitializeComponent();

			Initialized += (object? o, EventArgs args) =>
			{
				((MainMenuViewModel)DataContext!).ShowJoinGlobalDialog.RegisterHandler(
					ShowDialogAsync<JoinGlobalPopupWindow, JoinGlobalPopupViewModel, string?>);
			};
		}

		private async Task ShowDialogAsync<DialogWindowT, DialogViewModelT, DialogOutputT>(
		InteractionContext<DialogViewModelT, DialogOutputT> interactionCtx)
		where DialogWindowT : Window, new()
		where DialogViewModelT : ViewModelBase, new()
		{
			DialogWindowT window = new();
			window.DataContext = interactionCtx.Input;

			DialogOutputT output = await window.ShowDialog<DialogOutputT>((Window)TopLevel.GetTopLevel(this)!);
			interactionCtx.SetOutput(output);
		}
	}
}
