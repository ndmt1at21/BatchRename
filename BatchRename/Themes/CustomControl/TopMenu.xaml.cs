using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BatchRename.Themes.CustomControl
{
    public delegate void HandlerConvertClick();

    public partial class TopMenu : UserControl
    {
        public static readonly DependencyProperty NewCommandProperty =
             DependencyProperty.Register(
                 "NewCommand",
                 typeof(ICommand),
                 typeof(TopMenu),
                 new UIPropertyMetadata(null)
        );

        public ICommand NewCommand
        {
            get { return (ICommand)GetValue(NewCommandProperty); }
            set { SetValue(NewCommandProperty, value); }
        }

        public static readonly DependencyProperty OpenCommandProperty =
             DependencyProperty.Register(
                 "OpenCommand",
                 typeof(ICommand),
                 typeof(TopMenu),
                 new UIPropertyMetadata(null)
        );

        public ICommand OpenCommand
        {
            get { return (ICommand)GetValue(OpenCommandProperty); }
            set { SetValue(OpenCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(TopMenu),
                new UIPropertyMetadata(null)
       );

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        public static readonly DependencyProperty PreviewCommandProperty =
           DependencyProperty.Register(
               "PreviewCommand",
               typeof(ICommand),
               typeof(TopMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand PreviewCommand
        {
            get { return (ICommand)GetValue(PreviewCommandProperty); }
            set { SetValue(PreviewCommandProperty, value); }
        }

        public static readonly DependencyProperty StartCommandProperty =
           DependencyProperty.Register(
               "StartCommand",
               typeof(ICommand),
               typeof(TopMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand StartCommand
        {
            get { return (ICommand)GetValue(StartCommandProperty); }
            set { SetValue(StartCommandProperty, value); }
        }

        public TopMenu()
        {
            InitializeComponent();
        }
    }
}