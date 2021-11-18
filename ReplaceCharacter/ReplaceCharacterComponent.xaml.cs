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

namespace ReplaceCharacter
{
    /// <summary>
    /// Interaction logic for ReplaceCharacterComponent.xaml
    /// </summary>
    public partial class ReplaceCharacterComponent : UserControl, IRuleComponent
    {
        public ReplaceCharacterComponent()
        {
            InitializeComponent();
        }

        public IRuleParameter GetRuleParamter()
        {
            throw new NotImplementedException();
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(string serializeRuleParamter)
        {
            throw new NotImplementedException();
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            throw new NotImplementedException();
        }
    }
}
