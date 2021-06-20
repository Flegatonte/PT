namespace Presentation.API
{
    public interface IBookModelView
    {
        string Name { get; set; }
        string Author { get; set; }
        int BookID { get; set; }
        bool IsAvailable { get; set; }
    }
}
