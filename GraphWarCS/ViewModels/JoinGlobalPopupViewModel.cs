using Avalonia.Rendering.Composition;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

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

		private string name;
		public string Name 
		{
			get { return name; }
			set { this.RaiseAndSetIfChanged(ref name, value); }
		}
	}
}
