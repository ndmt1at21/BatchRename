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

namespace TrimSpaceRule
{
    /// <summary>
    /// Interaction logic for TrimSpaceComponent.xaml
    /// </summary>
    public partial class TrimSpaceComponent : UserControl, IRuleComponent
    {
        public string Id => "TrimSpace";

        public TrimSpaceComponent()
        {
            InitializeComponent();
        }

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
            return;
        }
    }
}
