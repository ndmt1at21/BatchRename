using BatchRename.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace BatchRename.Themes.CustomControl
{
    public partial class AppMenu : UserControl
    {
        public static readonly DependencyProperty NewCommandProperty =
           DependencyProperty.Register(
               "NewCommand",
               typeof(ICommand),
               typeof(AppMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand NewCommand
        {
            get { return (ICommand)GetValue(NewCommandProperty); }
            set { SetValue(NewCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveCommandProperty =
           DependencyProperty.Register(
               "SaveCommand",
               typeof(ICommand),
               typeof(AppMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }

        public static readonly DependencyProperty SaveAsCommandProperty =
            DependencyProperty.Register(
                "SaveAsCommand",
                typeof(ICommand),
                typeof(AppMenu),
                new UIPropertyMetadata(null)
       );

        public ICommand SaveAsCommand
        {
            get { return (ICommand)GetValue(SaveAsCommandProperty); }
            set { SetValue(SaveAsCommandProperty, value); }
        }

        public static readonly DependencyProperty OpenCommandProperty =
           DependencyProperty.Register(
               "OpenCommand",
               typeof(ICommand),
               typeof(AppMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand OpenCommand
        {
            get { return (ICommand)GetValue(OpenCommandProperty); }
            set { SetValue(OpenCommandProperty, value); }
        }

        public static readonly DependencyProperty ExportCommandProperty =
           DependencyProperty.Register(
               "ExportCommand",
               typeof(ICommand),
               typeof(AppMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand ExportCommand
        {
            get { return (ICommand)GetValue(ExportCommandProperty); }
            set { SetValue(ExportCommandProperty, value); }
        }

        public static readonly DependencyProperty ImportCommandProperty =
           DependencyProperty.Register(
               "ImportCommand",
               typeof(ICommand),
               typeof(AppMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand ImportCommand
        {
            get { return (ICommand)GetValue(ImportCommandProperty); }
            set { SetValue(ImportCommandProperty, value); }
        }

        public static readonly DependencyProperty ExitCommandProperty =
           DependencyProperty.Register(
               "ExitCommand",
               typeof(ICommand),
               typeof(AppMenu),
               new UIPropertyMetadata(null)
        );

        public ICommand ExitCommand
        {
            get { return (ICommand)GetValue(ExitCommandProperty); }
            set { SetValue(ExitCommandProperty, value); }
        }

        public static readonly DependencyProperty AddRuleCommandProperty =
          DependencyProperty.Register(
              "AddRuleCommand",
              typeof(ICommand),
              typeof(AppMenu),
              new UIPropertyMetadata(null)
        );

        public ICommand AddRuleCommand
        {
            get { return (ICommand)GetValue(AddRuleCommandProperty); }
            set { SetValue(AddRuleCommandProperty, value); }
        }

        public static readonly DependencyProperty AddFileCommandProperty =
          DependencyProperty.Register(
              "AddFileCommand",
              typeof(ICommand),
              typeof(AppMenu),
              new UIPropertyMetadata(null)
);

        public ICommand AddFileCommand
        {
            get { return (ICommand)GetValue(AddFileCommandProperty); }
            set { SetValue(AddFileCommandProperty, value); }
        }

        public static readonly DependencyProperty AddFolderCommandProperty =
          DependencyProperty.Register(
              "AddFolderCommand",
              typeof(ICommand),
              typeof(AppMenu),
              new UIPropertyMetadata(null)
);

        public ICommand AddFolderCommand
        {
            get { return (ICommand)GetValue(AddFolderCommandProperty); }
            set { SetValue(AddFolderCommandProperty, value); }
        }

        public AppMenu()
        {
            InitializeComponent();
        }
    }
}
