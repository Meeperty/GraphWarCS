using Avalonia.Controls;
using Avalonia.Controls.Templates;
using GraphWarCS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWarCS
{
	public class ViewLocator : IDataTemplate
	{
		public Control? Build(object? param)
		{
			var name = param!.GetType().FullName!.Replace("ViewModel", "View");
			var type = Type.GetType(name);
			
			if (type != null)
			{
				return (Control)Activator.CreateInstance(type)!;
			}
			else
			{
				return new TextBlock { Text=$"ViewLocator couldn't find view {name} to match viewmodel {param.GetType()}" };
			}
		}

		public bool Match(object? data)
		{
			return data is ViewModelBase;
		}
	}
}
