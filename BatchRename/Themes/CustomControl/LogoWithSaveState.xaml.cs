using System.Windows;
using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public partial class LogoWithSaveState : UserControl
    {
        public static readonly DependencyProperty ProjectNameProperty =
         DependencyProperty.Register("ProjectName", typeof(string), typeof(LogoWithSaveState));

        public string ProjectName
        {
            get => (string)GetValue(ProjectNameProperty);
            set => SetValue(ProjectNameProperty, value);
        }

        public static readonly DependencyProperty SaveStateProperty =
          DependencyProperty.Register("SaveState", typeof(string), typeof(LogoWithSaveState));

        public string SaveState
        {
            get => (string)GetValue(SaveStateProperty);
            set => SetValue(SaveStateProperty, value);
        }

        public LogoWithSaveState()
        {
            InitializeComponent();
        }
    }
}