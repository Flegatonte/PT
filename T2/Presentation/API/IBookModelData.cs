using Service.API;
using System.Collections.Generic;

namespace Presentation.API
{
    interface IBookModelData
    {
        IBookService Service { get; }
        IEnumerable<IBookData> Book { get; }
        IBookModelView CreateBook(string Title, string Author, int ID);
    }
}
