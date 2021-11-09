using System.Windows;
using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public partial class TitleBar : UserControl
    {
        public event RoutedEventHandler OnOpenClick;

        public event RoutedEventHandler OnSaveClick;

        public event RoutedEventHandler OnNewClick;

        public event RoutedEventHandler OnStartClick;

        public TitleBar()
        {
            InitializeComponent();

            topMenu.OnNewClick += OnOpenClick;
            topMenu.OnNewClick += OnNewClick;
            topMenu.OnSaveClick += OnSaveClick;
            topMenu.OnStartClick += OnStartClick;
        }
    }
}