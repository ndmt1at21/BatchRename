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

        public AddSuffixComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            throw new NotImplementedException();
        }

        public Control GetView()
        {
            throw new NotImplementedException();
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            throw new NotImplementedException();
        }
    }
}
