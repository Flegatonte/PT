using Presentation.ViewModel;
using System;
using System.Windows;

namespace PresentationView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ReaderViewModel readerViewModel = (ReaderViewModel)DataContext;
            readerViewModel.ChildWindow = new Lazy<IWindow>(() => new SecondWindow());
            readerViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
