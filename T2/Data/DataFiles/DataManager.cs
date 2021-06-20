using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.DataFiles
{
    public class DataManager : IDataManager
    {
        private LibraryDataContext context;
        public DataManager()
        {
            context = new LibraryDataContext();
        }
        public IReader Transform(Readers Reader)
        {
            return new Reader(Reader.name, Reader.id);
        }
        public IBook Transform(Books Book)
        {
            return new Book(Book.title, Book.author, Book.id);
        }

        public IEvent Transform(Events Event)
        {
            return new Event(Event.id, Event.date, Event.book_id, Event.reader_id);
        }

        public IEnumerable<IReader> GetReaders()
        {
            var readerDb = from Readers in context.Readers select Readers;
            List < IReader > list = new List<IReader>();
            foreach (Readers Reader in readerDb)
            {
                list.Add(Transform(Reader));
            }
            return list;
        }

        public IReader GetReader(int ID)
        {
            var dbReader = (from reader in context.Readers where (reader.id == ID) select reader).FirstOrDefault();
            if (dbReader != null) {
                return Transform(dbReader);
            }
            return null;
        }

        public bool AddReader(int ID, string Name)
        {
            if (GetReader(ID) == null && !Name.Equals(null))
            {
                Readers NewReader = new Readers
                {
                    name = Name,
                    id = ID
                };
                context.Readers.InsertOnSubmit(NewReader);
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateReader(int ID, string Name)
        {
            Readers Reader = context.Readers.Where(reader => reader.id == ID).SingleOrDefault();
            if (GetReader(ID) != null && !Name.Equals(null))
            {
                Reader.name = Name;
                Reader.id = ID;
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool DeleteReader(int ID)
        {
            Readers Reader = context.Readers.Where(reader => reader.id == ID).SingleOrDefault();
            if (GetReader(ID) != null && !ID.Equals(null))
            {
                context.Readers.DeleteOnSubmit(Reader);
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<IBook> GetBooks()
        {
            var booksDb = from bookDb in context.Books select bookDb;
            List<IBook> list = new List<IBook>();
            foreach (Books Book in booksDb)
            {
                list.Add(Transform(Book));
            }
            return list;
        }

        public IBook GetBookByID(int ID)
        {
            var bookDb = (from book in context.Books where (book.id == ID) select book).FirstOrDefault();
            if (bookDb != null)
            {
                return Transform(bookDb);
            }
            return null;
        }

        public IEnumerable<IBook> GetBooksByAuthor(string Author)
        {
            var bookDb = (from book in context.Books where (book.author == Author) select book).SingleOrDefault();
            List < IBook > list = new List<IBook>();
            if (bookDb != null)
            {
                list.Add(Transform(bookDb));
                return list;
            }
            return null;
        }

        public IBook GetBookByName(string Name)
        {
            var bookDb = (from book in context.Books where (book.title == Name) select book).SingleOrDefault();
            if (bookDb != null)
            {
                return Transform(bookDb);
            }
            return null;
        }

        public bool AddBook(int ID, string Name, string Author)
        {
            if (GetBookByName(Name) == null && !Name.Equals(null) && !ID.Equals(null) && !Author.Equals(null) && GetBookByID(ID) == null)
            {
                Books NewBook = new Books
                {
                    id = ID,
                    title = Name,
                    author = Author,
                    isAvailable = true,
                };
                context.Books.InsertOnSubmit(NewBook);
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateBook(int ID, string Name, string Author)
        {
            Books Book = context.Books.Where(i => i.id == ID).SingleOrDefault();
            if (!ID.Equals(null) && !Name.Equals(null) && !Author.Equals(null) && GetBookByID(ID) != null)
            {
                Book.id = ID;
                Book.title = Name;
                Book.author = Author;
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public void ReturnBook(int? ID)
        {
            Books Book = context.Books.Where(i => i.id == ID).SingleOrDefault();
            if (GetBookByID(ID.GetValueOrDefault()) != null && !ID.Equals(null))
            {
                Book.isAvailable = true;
                context.SubmitChanges();
            }
        }

        public bool DeleteBook(int ID)
        {
            Books Book = context.Books.Where(i => i.id == ID).SingleOrDefault();
            if (GetBookByID(ID) != null && !ID.Equals(null))
            {
                context.Books.DeleteOnSubmit(Book);
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<IEvent> GetEvents()
        {
            var eventsDb = from eventDb in context.Events select eventDb;
            List < IEvent > list = new List<IEvent>();
            foreach (Events Event in eventsDb)
            {
                list.Add(Transform(Event));
            }
            return list;
        }

        public IEvent GetEventByID(int ID)
        {
            var eventDb = (from temp in context.Events where (temp.id == ID) select temp).SingleOrDefault(); 
            if (eventDb != null)
            {
                return Transform(eventDb);
            }
            return null;
        }

        public IEnumerable<IEvent> GetEventsByReaderID(int ReaderID)
        {
            var eventDb = from temp in context.Events where (temp.reader_id == ReaderID) select temp;
            List < IEvent > list = new List<IEvent>();
            foreach (Events Event in eventDb)
            {
                if (Event.reader_id.Equals(ReaderID))
                {
                    list.Add(Transform(Event));
                }
            }
            return list;
        }

        public bool AddEvent(int EventID, DateTime Date, int BookID, int ReaderID)
        {
            if (!EventID.Equals(null) && !Date.Equals(null) && !BookID.Equals(null) && !ReaderID.Equals(null))
            {
                Books Book = context.Books.Where(i => i.id == BookID).SingleOrDefault();
                Readers Reader = context.Readers.Where(i => i.id == ReaderID).SingleOrDefault();
                if (GetBookByID(BookID) != null && GetReader(ReaderID) != null && GetEventByID(EventID) == null)
                {
                    Book.isAvailable = false;

                    Events NewEvent = new Events
                    {
                        id = EventID,
                        date = Date,
                        book_id = BookID,
                        reader_id = ReaderID,
                    };
                    context.Events.InsertOnSubmit(NewEvent);
                    context.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        public bool UpdateEventBook(int ID, int BookID)
        {
            var eventDb = (from temp in context.Events where (temp.id == ID) select temp).SingleOrDefault();
            if (!BookID.Equals(null))
            {
                ReturnBook(eventDb.book_id);
                eventDb.book_id = BookID;
                context.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool UpdateEventReader(int ID, int ReaderID)
        {
            var eventDb = (from temp in context.Events where (temp.id == ID) select temp).SingleOrDefault();
            if (!ReaderID.Equals(null) && GetEventByID(ID) != null)
            {
                eventDb.reader_id = ReaderID;
                context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool DeleteEvent(int ID)
        {
            var eventDb = (from temp in context.Events where (temp.id == ID) select temp).SingleOrDefault();
            if (GetEventByID(ID) != null && !ID.Equals(null))
            {
                ReturnBook(eventDb.book_id);
                context.Events.DeleteOnSubmit(eventDb);
                context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
