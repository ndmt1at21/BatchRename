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
        public string Id => "ReplaceCharacter";

        public string oldchar { get; set; }
        public string newchar { get; set; }
        public ReplaceCharacterComponent()
        {
            InitializeComponent();
            SetRuleParameter(ReplaceCharacterRuleConstant.DEFAULT_PARAMS);
            DataContext = this;
        }


        public Control GetView()
        {
            return this;
        }

        public IRuleParameter GetRuleParamter()
        {
            return new ReplaceCharacterParameter { oldChar = oldchar, newChar = newchar };
        }

        public void SetRuleParameter(IRuleParameter ruleParameter)
        {
            ReplaceCharacterParameter parameter = (ReplaceCharacterParameter)ruleParameter;

            if (parameter == null)
                return;

            oldchar = parameter.oldChar;
            newchar = parameter.newChar;
        }

        private void tbInputOldChar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldCharValue = tbInputOldChar.Text;
            int oldCharTxtIndex = tbInputOldChar.CaretIndex;


            oldchar = oldCharValue;

            tbInputOldChar.Text = oldCharValue.Length == 0
                ? string.Empty
                : oldchar;

            if (!oldchar.Equals(oldCharValue))
                tbInputOldChar.CaretIndex = oldCharTxtIndex - 1;
        }

        private void tbInputNewChar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newCharValue = tbInputNewChar.Text;
            int newCharTxtIndex = tbInputNewChar.CaretIndex;


            newchar = newCharValue;

            tbInputNewChar.Text = newCharValue.Length == 0
                ? string.Empty
                : newchar;

            if (!newchar.Equals(newCharValue))
                tbInputNewChar.CaretIndex = newCharTxtIndex - 1;
        }
    }
}
