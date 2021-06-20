namespace Service.API
{
    public interface IBookData
    {
        string Name { get; set; }
        string Author { get; set; }
        int BookID { get; set; }
        bool IsAvailable { get; set; }
    }
}
