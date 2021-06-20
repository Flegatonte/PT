using Data.API;

namespace Data.DataFiles
{
    public class Content : IContent
    {
        public IBook BookItem { get; set; }
        public int Quantity { get; set; }

        public Content(IBook bookItem, int quantity)
        {
            BookItem = bookItem;
            Quantity = quantity;
        }
    }
}
