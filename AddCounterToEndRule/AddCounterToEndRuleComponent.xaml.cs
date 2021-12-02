using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PluginContract;

namespace AddCounterToEndRule
{
    public partial class AddCounterToEndRuleComponent : UserControl, IRuleComponent
    {
        public string Id => "AddCounterToAdd";

        public int StartFrom { get; set; }
        public int Step { get; set; }
        public int PartCountLength { get; set; }
        public char PadChar { get; set; }

        public AddCounterToEndRuleComponent()
        {
            InitializeComponent();
            SetRuleParameter(AddCounterToEndConstant.DEFAULT_PARAMETER);
        }

        public IRuleParameter GetRuleParamter()
        {
            return new AddCounterToEndParamter
            {
                PadChar = PadChar,
                Step = Step,
                StartFrom = StartFrom,
                PartCountLength = PartCountLength
            };
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            AddCounterToEndParamter rule = (AddCounterToEndParamter)ruleParameter;

            if (rule == null) return;

            PadChar = rule.PadChar;
            Step = rule.Step;
            StartFrom = rule.StartFrom;
            PartCountLength = rule.PartCountLength;
        }
    }
}
