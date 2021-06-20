using Presentation.ViewModel;
using System;
using System.Windows;

namespace PresentationView
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window, IWindow
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            BookViewModel bookViewModel = (BookViewModel)DataContext;
            bookViewModel.ChildWindow = new Lazy<IWindow>(() => new ThirdWindow());
            bookViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
