using Service.API;

namespace Service.DataFiles
{
    public class BookData : IBookData
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }
        public bool IsAvailable { get; set; }
    }
}
