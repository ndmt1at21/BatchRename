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

namespace RemoveAllSpace
{
    /// <summary>
    /// Interaction logic for RemoveAllSpaceComponent.xaml
    /// </summary>
    public partial class RemoveAllSpaceComponent : UserControl, IRuleComponent
    {
        public string Id => "RemoveAllSpaces";

        public bool IsAppendToOriginal { get; set; }
        public RemoveAllSpaceComponent()
        {
            InitializeComponent();
            SetRuleParameter(RemoveAllSpaceRuleConstant.DEFAULT_PARAMS);
            DataContext = this;
        }

        public IRuleParameter GetRuleParamter()
        {
            return new RemoveAllSpaceParameter { IsAppendToOriginal = IsAppendToOriginal };
        }

        public Control GetView()
        {
            return this;
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            RemoveAllSpaceParameter parameter = (RemoveAllSpaceParameter)ruleParameter;

            if (parameter == null)
                return;

            IsAppendToOriginal = parameter.IsAppendToOriginal;
        }
    }
}
