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

namespace ChangeExtensionRule
{
    public partial class ChangeExtensionComponent : UserControl, IRuleComponent
    {
        public string Id => "ChangeExtension";

        public string NewExtension { get; set; }

        public ChangeExtensionComponent()
        {
            InitializeComponent();
            SetRuleParameter(ChangeExtensionRuleConstant.DEFAULT_PARAMS);
            DataContext = this;
        }

        public IRuleParameter GetRuleParamter()
        {
            return new ChangeExtensionParamter
            {
                NewExtension = NewExtension
            };
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

        private void tbInputNewExtension_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldValue = tbInputNewExtension.Text;
            int oldIndex = tbInputNewExtension.CaretIndex;

            if (oldValue.Length <= 20)
                NewExtension = oldValue;

            tbInputNewExtension.Text = oldValue.Length == 0
                ? string.Empty
                : NewExtension;

            if (!NewExtension.Equals(oldValue))
                tbInputNewExtension.CaretIndex = oldIndex - 1;
        }
    }
}