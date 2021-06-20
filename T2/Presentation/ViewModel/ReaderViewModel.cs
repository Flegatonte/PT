using Presentation.ViewModel.MVVM;
using Service.API;
using Service.DataFiles;
using System;
using System.Collections.Generic;

namespace Presentation.ViewModel
{
    public class ReaderViewModel : ViewModelBase
    {
        private IReaderService service;
        public ReaderViewModel(ReaderService service)
        {
            this.service = service;
        }
        public ReaderViewModel()
        {
            service = new ReaderService();
            AddReaderCommand = new RelayCommand(AddReader);
            UpdateReaderCommand = new RelayCommand(UpdateReader);
            DeleteReaderCommand = new RelayCommand(DeleteReader);
            RefreshReadersCommand = new RelayCommand(RefreshReaders);
            ShowBooksCommand = new RelayCommand(ShowBooksWindow);
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public RelayCommand AddReaderCommand { get; private set; }
        public RelayCommand UpdateReaderCommand { get; private set; }
        public RelayCommand DeleteReaderCommand { get; private set; }
        public RelayCommand RefreshReadersCommand { get; private set; }
        public RelayCommand ShowBooksCommand { get; private set; }

        private void AddReader()
        {
            bool added = service.AddReader(ID, Name);
            if (added)
            {
                text = "Reader added";
            }
            else
            {
                text = "Cannot add Reader";
            }
            MessageBoxShowDelegate(Text);
        }

        private IReaderData currentReader;
        public IReaderData CurrentReader
        {
            get => currentReader;
            set
            {
                currentReader = value;
                OnPropertyChanged("CurrentReader");
            }
        }
        private void UpdateReader()
        {
            bool updated = service.UpdateReader(ID, Name);
            if (updated)
            {
                text = "Reader updated";
            }
            else
            {
                text = "Cannot update Reader";
            }
            MessageBoxShowDelegate(Text);
        }
        private void DeleteReader()
        {
            bool deleted = service.DeleteReader(ID);
            if (deleted)
            {
                text = "Reader deleted";
            }
            else
            {
                text = "Cannot delete Reader";
            }
            MessageBoxShowDelegate(Text);
        }

        private void RefreshReaders()
        {
            Readers = service.GetReaders();
        }

        private IEnumerable<IReaderData> readers;
        public IEnumerable<IReaderData> Readers
        {
            get
            {
                return readers;
            }
            set
            {
                readers = value;
                OnPropertyChanged("Readers");
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public Lazy<IWindow> ChildWindow { get; set; }

        private void ShowBooksWindow()
        {
            IWindow window = ChildWindow.Value;
            window.Show();
        }

        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");
    }
}
