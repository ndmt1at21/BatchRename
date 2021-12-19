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

namespace ToPascalCase
{
	/// <summary>
	/// Interaction logic for ToPascalCaseComponent.xaml
	/// </summary>
	public partial class ToPascalCaseComponent : UserControl, IRuleComponent
	{
		public ToPascalCaseComponent()
		{
			InitializeComponent();
		}

		public string Id => "PascalCase";

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
