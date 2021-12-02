using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControl
{
    public class BRButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(System.Windows.Controls.Button));

        public static readonly DependencyProperty HoverBackgroundProperty =
           DependencyProperty.Register("HoverBackground", typeof(SolidColorBrush), typeof(System.Windows.Controls.Button));

        public static readonly DependencyProperty ActiveBackgroundProperty =
           DependencyProperty.Register("ActiveBackground", typeof(SolidColorBrush), typeof(System.Windows.Controls.Button));

        public static readonly DependencyProperty DisableBackgroundProperty =
          DependencyProperty.Register("DisableBackground", typeof(SolidColorBrush), typeof(System.Windows.Controls.Button));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public SolidColorBrush HoverBackground
        {
            get => (SolidColorBrush)GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        public SolidColorBrush ActiveBackground
        {
            get => (SolidColorBrush)GetValue(ActiveBackgroundProperty);
            set => SetValue(ActiveBackgroundProperty, value);
        }

        public SolidColorBrush DisableBackground
        {
            get => (SolidColorBrush)GetValue(DisableBackgroundProperty);
            set => SetValue(DisableBackgroundProperty, value);
        }

        static BRButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BRButton), new FrameworkPropertyMetadata(typeof(BRButton)));
        }
    }
}