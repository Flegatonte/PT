using Presentation.ViewModel.MVVM;
using Service.API;
using Service.DataFiles;
using System;
using System.Collections.Generic;

namespace Presentation.ViewModel
{
    public class BookViewModel : ViewModelBase
    {
        private IBookService service;
        public BookViewModel(BookService service)
        {
            this.service = service;
        }
        public BookViewModel()
        {
            service = new BookService();
            AddBookCommand = new RelayCommand(AddBook);
            UpdateBookCommand = new RelayCommand(UpdateBook);
            DeleteBookCommand = new RelayCommand(DeleteBook);
            RefreshBooksCommand = new RelayCommand(RefreshBooks);
            ShowEventsCommand = new RelayCommand(ShowBooksWindow);
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                OnPropertyChanged("Author");
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

        private bool isAvailable;
        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
                OnPropertyChanged("IsAvailable");
            }
        }


        public RelayCommand AddBookCommand { get; private set; }
        public RelayCommand UpdateBookCommand { get; private set; }
        public RelayCommand DeleteBookCommand { get; private set; }
        public RelayCommand RefreshBooksCommand { get; private set; }
        public RelayCommand ShowEventsCommand { get; private set; }

        private void AddBook()
        {
            bool added = service.AddBook(ID, Title, Author);
            if (added)
            {
                text = "Book added";
            }
            else
            {
                text = "Cannot add Book";
            }
            MessageBoxShowDelegate(Text);
        }

        private IBookData currentBook;
        public IBookData CurrentBook
        {
            get => currentBook;
            set
            {
                currentBook = value;
                OnPropertyChanged("CurrentBook");
            }
        }
        private void UpdateBook()
        {
            bool updated = service.UpdateBook(ID, Title, Author);
            if (updated)
            {
                text = "Book updated";
            }
            else
            {
                text = "Cannot update Book";
            }
            MessageBoxShowDelegate(Text);
        }

        private void DeleteBook()
        {
            bool deleted = service.DeleteBook(ID);
            if (deleted)
            {
                text = "Book deleted";
            }
            else
            {
                text = "Cannot delete Book";
            }
            MessageBoxShowDelegate(Text);
        }

        private void RefreshBooks()
        {
            Books = service.GetBooks();
        }

        private IEnumerable<IBookData> books;
        public IEnumerable<IBookData> Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
                OnPropertyChanged("Books");
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