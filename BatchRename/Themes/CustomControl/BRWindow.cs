using System.Windows;
using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public partial class BRWindow : Window
    {
        private const string PART_MinimizeButton = "PART_MinimizeButton";
        private const string PART_MaximizeButton = "PART_MaximizeButton";
        private const string PART_CloseButton = "PART_CloseButton";

        public Button CloseBtn;
        public Button MaxBtn;
        public Button MinBtn;

        static BRWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BRWindow), new FrameworkPropertyMetadata(typeof(BRWindow)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            MinBtn = (Button)GetTemplateChild(PART_MinimizeButton);
            MaxBtn = (Button)GetTemplateChild(PART_MaximizeButton);
            CloseBtn = (Button)GetTemplateChild(PART_CloseButton);

            if (MinBtn != null)
            {
                MinBtn.Click += MinBtn_Click;
            }

            if (MaxBtn != null)
            {
                MaxBtn.Click += MaxBtn_Click;
            }

            if (CloseBtn != null)
            {
                CloseBtn.Click += CloseBtn_Click;
            }
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                SystemCommands.RestoreWindow(this);

            if (WindowState == WindowState.Normal)
                SystemCommands.MaximizeWindow(this);
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}