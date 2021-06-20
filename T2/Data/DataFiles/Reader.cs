using Data.API;

namespace Data.DataFiles
{
    public class Reader : IReader
    {
        public string Name { get; set; }
        public int ReaderID { get; set; }

        public Reader(string name, int readerID)
        {
            Name = name;
            ReaderID = readerID;
        }
    }
}
