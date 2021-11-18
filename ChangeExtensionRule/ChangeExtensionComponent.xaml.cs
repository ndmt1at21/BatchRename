using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PluginContract;

namespace ChangeExtensionRule
{
    public partial class ChangeExtensionComponent : UserControl, IRuleComponent
    {
        public string NewExtension { get; set; }

        public ChangeExtensionComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            return new ChangeExtensionParamter { NewExtension = NewExtension };
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            ChangeExtensionParamter parameter = (ChangeExtensionParamter)ruleParameter;

            if (parameter == null)
                return;

            NewExtension = parameter.NewExtension;
        }
    }
}