using System;
using System.Windows;
using System.Windows.Controls;

namespace BatchRename.Themes.CustomControl
{
    public delegate void HandlerConvertClick();

    public partial class TopMenu : UserControl
    {
        public event RoutedEventHandler OnOpenClick;

        public event RoutedEventHandler OnSaveClick;

        public event RoutedEventHandler OnNewClick;

        public event RoutedEventHandler OnStartClick;

        public TopMenu()
        {
            InitializeComponent();

            if (OnNewClick != null)
                btnNew.Click += OnNewClick;

            if (OnOpenClick != null)
                btnOpen.Click += OnOpenClick;

            if (OnSaveClick != null)
                btnSave.Click += OnSaveClick;

            if (OnStartClick != null)
                btnStart.Click += OnStartClick;
        }
    }
}