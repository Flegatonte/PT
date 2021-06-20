using Presentation.API;

namespace Presentation.Model
{
    public class BookModelView : IBookModelView
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }
        public bool IsAvailable { get; set; }

        public BookModelView(string name, string author, int bookID)
        {
            Name = name;
            Author = author;
            BookID = bookID;
            IsAvailable = true;
        }
    }
}
