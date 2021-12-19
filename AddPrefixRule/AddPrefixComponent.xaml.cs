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


namespace AddPrefixRule
{
    /// <summary>
    /// Interaction logic for AddPrefixComponent.xaml
    /// </summary>
    public partial class AddPrefixComponent : UserControl, IRuleComponent
    {
        public string Id => "AddPrefix";

        public string Prefix { get; set; }

        public AddPrefixComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            return new AddPrefixParamter { Prefix = Prefix };
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            AddPrefixParamter rule = (AddPrefixParamter)ruleParameter;

            if (rule == null)
                return;

            Prefix = rule.Prefix;
        }


        private void tbInputPrefix_TextChanged(object sender, TextChangedEventArgs e)
        {
            string PrefixValue = tbInputPrefix.Text;
            int PrefixTxtIndex = tbInputPrefix.CaretIndex;


            Prefix = PrefixValue;

            tbInputPrefix.Text = PrefixValue.Length == 0
                ? string.Empty
                : Prefix;

            if (!Prefix.Equals(PrefixValue))
                tbInputPrefix.CaretIndex = PrefixTxtIndex - 1;
        }
    }
}
