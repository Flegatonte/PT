using Data.API;

namespace Data.DataFiles
{
    public class Book : IBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string name, string author, int bookID)
        {
            Name = name;
            Author = author;
            BookID = bookID;
            IsAvailable = true;
        }
    }
}
