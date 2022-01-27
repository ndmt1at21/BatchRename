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

namespace RegularExpressions
{
    /// <summary>
    /// Interaction logic for RegularExpressionComponent.xaml
    /// </summary>
    public partial class RegularExpressionComponent : UserControl, IRuleComponent
    {
        public string Id => "RegularExpression";
        public string Regex { get; set; }
        public string ReplaceString { get; set; }

        public RegularExpressionComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            return new RegularExpressionParameter
            {
                Regex = Regex,
                ReplaceString = ReplaceString
            };
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            RegularExpressionParameter rule = (RegularExpressionParameter)ruleParameter;

            if (rule == null)
                return;

            Regex = rule.Regex;
            ReplaceString = rule.ReplaceString;
        }

        public Control GetView()
        {
            return this;
        }

        private void tbReplaceString_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReplaceString = tbReplaceString.Text;
        }

        private void tbInputRegex_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex = tbInputRegex.Text;
        }
    }
}
