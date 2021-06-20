using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IDataManager
    {
        public abstract void AddBook(IBook book);
        public abstract void RemoveBook(int ID);
        public abstract IBook GetBookID(int ID);
        public abstract IBook GetBook(string name);
        public abstract bool CheckIfBookIsAvaliable(int ID);

        public abstract void AddReader(IReader reader);
        public abstract IReader GetReader(int ID);
        public abstract int GetReaderID(string name);
        public abstract void RemoveReader(int ID);

        public abstract void SetQuantity(int ID, int quantity);
        public abstract void ChangeQuantity(int ID, int newQuantity);
        public abstract int GetQuantity(int ID);

        public abstract void BorrowBook(int bookID, int readerID, int ID);
        public abstract void RemoveBorrow(int ID);
        public abstract Event GetBorrow(int ID);
        public abstract int GetBorrowID(int ID);
    }
}
