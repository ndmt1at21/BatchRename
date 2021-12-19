using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PluginContract;

namespace LowercaseCharacter
{
	/// <summary>
	/// Interaction logic for LowercaseCharacterComponent.xaml
	/// </summary>
	public partial class LowercaseCharacterComponent : UserControl, IRuleComponent
	{
		public LowercaseCharacterComponent()
		{
			InitializeComponent();
		}

		public string Id => "ToLowercase";

		public IRuleParameter GetRuleParamter()
		{
			return null;
		}

		public Control GetView()
		{
			return this;
		}

		public void SetRuleParameter(IRuleParameter ruleParameter)
		{

		}
	}
}
