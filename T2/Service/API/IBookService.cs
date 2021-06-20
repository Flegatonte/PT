using System.Collections.Generic;

namespace Service.API
{
    public interface IBookService
    {
        IEnumerable<IBookData> GetBooks();
        IBookData GetBookByID(int ID);
        IEnumerable<IBookData> GetBooksByAuthor(string Author);
        IBookData GetBookByName(string Name);
        bool AddBook(int ID, string Name, string Author);
        bool UpdateBook(int ID, string Name, string Author);
        bool DeleteBook(int ID);
    }
}
