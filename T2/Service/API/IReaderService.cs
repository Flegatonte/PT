using System.Collections.Generic;

namespace Service.API
{
    public interface IReaderService
    {
        IEnumerable<IReaderData> GetReaders();
        IReaderData GetReader(int ID);
        bool AddReader(int ID, string Name);
        bool UpdateReader(int ID, string Name);
        bool DeleteReader(int ID);

    }
}
