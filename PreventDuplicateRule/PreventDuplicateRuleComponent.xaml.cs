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

namespace PreventDuplicateRule
{
    /// <summary>
    /// Interaction logic for PreventDuplicateRuleComponent.xaml
    /// </summary>
    public partial class PreventDuplicateRuleComponent : UserControl, IRuleComponent
    {
        public PreventDuplicateRuleComponent()
        {
            InitializeComponent();
        }

        public string Id => "PreventDuplicate";

        public IRuleParameter GetRuleParamter()
        {
            throw new NotImplementedException();
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            throw new NotImplementedException();
        }
    }
}
