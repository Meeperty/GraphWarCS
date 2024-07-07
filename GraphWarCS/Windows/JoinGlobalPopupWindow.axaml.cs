using Avalonia.ReactiveUI;
using GraphWarCS.ViewModels;

namespace GraphWarCS.Views
{
	public partial class JoinGlobalPopupWindow : ReactiveWindow<JoinGlobalPopupViewModel>
	{
		public JoinGlobalPopupWindow()
		{
			InitializeComponent();
		}

		new public void Close()
		{
			base.Close();
		}
	}
}
