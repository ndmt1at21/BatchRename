using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddCounterToEndRuleComponent : UserControl, IRuleComponent
    {
        public string Id => "AddCounterToAdd";

        public int StartFrom { get; set; }
        public int Step { get; set; }
        public int PartCountLength { get; set; }
        public char PadChar { get; set; }

        public AddCounterToEndRuleComponent()
        {
            InitializeComponent();
            SetRuleParameter(AddCounterToEndConstant.DEFAULT_PARAMETER);
            DataContext = this;
        }

        public IRuleParameter GetRuleParamter()
        {
            return new AddCounterToEndParamter
            {
                PadChar = PadChar,
                Step = Step,
                PartCountLength = PartCountLength
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

            PadChar = rule.PadChar;
            Step = rule.Step;
            PartCountLength = rule.PartCountLength;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.MouseDown += OnMouseDownInWindow;
        }

        private void OnMouseDownInWindow(object sender, MouseButtonEventArgs e)
        {
            DependencyObject scope = FocusManager.GetFocusScope(tbPaddingChar);
            FocusManager.SetFocusedElement(scope, Window.GetWindow(this));
            Keyboard.ClearFocus();
        }

        private void tbStartNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            handleIntegerTextBoxChanged(tbStartNumber);
        }

        private void handleIntegerTextBoxChanged(TextBox target)
        {
            string oldValue = target.Text;
            int oldIndex = target.CaretIndex;

            try
            {
                StartFrom = int.Parse(oldValue);
            }
            catch (FormatException)
            {
                if (oldValue.Length == 0)
                    StartFrom = 0;
            }
            catch { }

            if (!oldValue.Equals("0"))
            {
                target.Text = oldValue.Length == 0 ? string.Empty : StartFrom.ToString();
            }

            if (!StartFrom.ToString().Equals(oldValue) && oldIndex > 0)
            {
                target.CaretIndex = oldIndex - 1;
            }
        }

        private void tbStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            handleIntegerTextBoxChanged(tbStep);
        }

        private void tbCounterLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            handleIntegerTextBoxChanged(tbCounterLength);
        }

        private void tbPaddingChar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string oldValue = tbPaddingChar.Text;
            int oldIndex = tbPaddingChar.CaretIndex;

            if (oldValue.Length == 0)
            {
                tbPaddingChar.Text = string.Empty;
            }
            else
            {
                tbPaddingChar.Text = PadChar.ToString();
            }


            if (!PadChar.ToString().Equals(oldValue) && oldIndex > 0)
            {
                tbPaddingChar.CaretIndex = oldIndex - 1;
            }
        }

        private void tbPaddingChar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Debug.WriteLine(e.Text);
            PadChar = e.Text[0];
        }
    }
}
