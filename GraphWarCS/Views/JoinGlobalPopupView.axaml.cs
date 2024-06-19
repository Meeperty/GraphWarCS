using Avalonia.Controls;
using Avalonia.Interactivity;
using GraphWarCS.ViewModels;
using System;

namespace GraphWarCS.Views
{
	public partial class JoinGlobalPopupView : UserControl
	{
		public JoinGlobalPopupView()
		{
			InitializeComponent();

			Loaded += (object? o, RoutedEventArgs e) =>
			{
				((JoinGlobalPopupViewModel)DataContext!).JoinCommand.Subscribe(((JoinGlobalPopupWindow)TopLevel.GetTopLevel(this))!.Close);
				((JoinGlobalPopupViewModel)DataContext!).BackCommand.Subscribe(((JoinGlobalPopupWindow)TopLevel.GetTopLevel(this))!.Close);
			};
		}
	}
}
