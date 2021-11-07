using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public delegate void HandlerConvertClick();

    public partial class TopMenu : UserControl
    {
        public HandlerConvertClick OnConvertClick;

        public TopMenu()
        {
            InitializeComponent();
        }

        public TopMenu(HandlerConvertClick onConvertClick)
        {
            OnConvertClick += onConvertClick;
        }
    }
}