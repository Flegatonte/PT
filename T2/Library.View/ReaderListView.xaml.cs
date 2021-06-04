using Library.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Library.View
{
    /// <summary>
    /// Interaction logic for ReaderListView.xaml
    /// </summary>
    public partial class ReaderListView : UserControl
    {
        public ReaderListView()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ReaderListViewModel readerListViewModel = (ReaderListViewModel)DataContext;
            readerListViewModel.AddWindow = new Lazy<IWindow>(() => new AddReaderView());
            readerListViewModel.EditWindow = new Lazy<IWindow>(() => new EditReaderView());
        }
    }
}
