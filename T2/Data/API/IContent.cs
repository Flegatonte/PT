
namespace Data.API
{
    public interface IContent
    {
        IBook BookItem { get; set; }
        int Quantity { get; set; }
    }
}
