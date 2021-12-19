using PluginContract;
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

namespace AddSuffixRule
{
    /// <summary>
    /// Interaction logic for AddSuffixComponent.xaml
    /// </summary>
    public partial class AddSuffixComponent : UserControl, IRuleComponent
    {
        public string Id => "AddSuffix";

        public string Suffix { get; set; }

        public AddSuffixComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            return new AddSuffixParamter { Suffix = Suffix };
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            AddSuffixParamter rule = (AddSuffixParamter)ruleParameter;

            if (rule == null)
                return;

            Suffix = rule.Suffix;
        }

        private void tbInputSuffix_TextChanged(object sender, TextChangedEventArgs e)
        {
            string SuffixValue = tbInputSuffix.Text;
            int SuffixTxtIndex = tbInputSuffix.CaretIndex;


            Suffix = SuffixValue;

            tbInputSuffix.Text = SuffixValue.Length == 0
                ? string.Empty
                : Suffix;

            if (!Suffix.Equals(SuffixValue))
                tbInputSuffix.CaretIndex = SuffixTxtIndex - 1;
        }
    }
}
