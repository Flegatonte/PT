
namespace Data.API
{
    public interface IBook
    {
        string Name { get; set; }
        string Author { get; set; }
        int BookID { get; set; }
        bool IsAvailable { get; set; }
    }
}
