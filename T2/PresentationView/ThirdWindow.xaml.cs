using Presentation.ViewModel;
using System;
using System.Windows;

namespace PresentationView
{
    /// <summary>
    /// Interaction logic for ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window, IWindow
    {
        public ThirdWindow()
        {
            InitializeComponent();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            EventViewModel eventViewModel = (EventViewModel)DataContext;
            eventViewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
