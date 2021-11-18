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
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AddCounterToEndRuleComponent : UserControl, IRuleComponent
    {
        public int Start { get; set; }
        public int Step { get; set; }
        public int TargetLength { get; set; }
        public string PadString { get; set; }
        public bool PadStart { get; set; }
        public bool PadEnd { get; set; }

        public AddCounterToEndRuleComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            return new AddCounterToEndParamter
            {
                Start = Start,
                Step = Step,
                PadEnd = PadEnd,
                PadStart = PadStart,
                PadString = PadString,
                TargetLength = TargetLength
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

            Start = rule.Start;
            Step = rule.Step;
            PadEnd = rule.PadEnd;
            PadStart = rule.PadStart;
            PadString = rule.PadString;
            TargetLength = rule.TargetLength;
        }
    }
}
