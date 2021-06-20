using Presentation.API;
using Service.API;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class BookModelData : IBookModelData
    {
        public IBookService Service { get; }
        public BookModelData(IBookService service)
        {
            Service = service;
        }

        public IEnumerable<IBookData> Book
        {
            get
            {
                IEnumerable<IBookData> books = Service.GetBooks();
                return books;
            }
        }

        public IBookModelView CreateBook(string Title, string Author, int ID)
        {
            return new BookModelView(Title, Author, ID);
        }
    }
}
