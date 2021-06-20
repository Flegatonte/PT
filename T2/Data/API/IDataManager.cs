using System;
using System.Collections.Generic;

namespace Data.API
{
    public interface IDataManager
    {
        IReader Transform(Readers Reader);
        IBook Transform(Books Book);
        IEvent Transform(Events Event);

        IEnumerable<IReader> GetReaders();
        IReader GetReader(int ID);
        bool AddReader(int ID, string Name);
        bool UpdateReader(int ID, string Name);
        bool DeleteReader(int ID);

        IEnumerable<IBook> GetBooks();
        IBook GetBookByID(int ID);
        IEnumerable<IBook> GetBooksByAuthor(string Author);
        IBook GetBookByName(string Name);
        bool AddBook(int ID, string Name, string Author);
        bool UpdateBook(int ID, string Name, string Author);
        bool DeleteBook(int ID);

        IEnumerable<IEvent> GetEvents();
        IEvent GetEventByID(int ID);
        IEnumerable<IEvent> GetEventsByReaderID(int ReaderID);
        bool AddEvent(int EventID, DateTime Date, int BookID, int ReaderID);
        bool UpdateEventBook(int ID, int BookID);
        bool UpdateEventReader(int ID, int ReaderID);
        bool DeleteEvent(int ID);
    }
}
