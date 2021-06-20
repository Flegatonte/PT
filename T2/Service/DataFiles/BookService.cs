using Data.API;
using Data.DataFiles;
using Service.API;
using System.Collections.Generic;

namespace Service.DataFiles
{
    public class BookService : IBookService
    {
        private IDataManager manager;
        public BookService(IDataManager manager)
        {
            this.manager = manager;
        }
        public BookService()
        {
            this.manager = new DataManager();
        }
        public IBookData Transfer(IBook book)
        {
            if (book == null)
            {
                return null;
            }

            return new BookData
            {
                Name = book.Name,
                Author = book.Author,
                BookID = book.BookID,
                IsAvailable = book.IsAvailable,
            };
        }
        public IEnumerable<IBookData> GetBooks()
        {
            var books = manager.GetBooks();
            var result = new List<IBookData>();

            foreach (var book in books)
            {
                result.Add(Transfer(book));
            }

            return result;
        }

        public IBookData GetBookByID(int ID)
        {
            return Transfer(manager.GetBookByID(ID));
        }

        public IEnumerable<IBookData> GetBooksByAuthor(string Author)
        {
            var books = manager.GetBooksByAuthor(Author);
            var result = new List<IBookData>();

            foreach (var book in books)
            {
                result.Add(Transfer(book));
            }

            return result;
        }

        public IBookData GetBookByName(string Name)
        {
            return Transfer(manager.GetBookByName(Name));
        }
        public bool AddBook(int ID, string Name, string Author)
        {
            return manager.AddBook(ID, Name, Author);
        }

        public bool UpdateBook(int ID, string Name, string Author)
        {
            return manager.UpdateBook(ID, Name, Author);
        }

        public bool DeleteBook(int ID)
        {
            return manager.DeleteBook(ID);
        }
    }
}