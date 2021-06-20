using Data.API;
using Data.DataFiles;
using Service.API;
using System.Collections.Generic;

namespace Service.DataFiles
{
    public class ReaderService : IReaderService
    {
        private IDataManager manager;
        public ReaderService(IDataManager manager)
        {
            this.manager = manager;
        }
        public ReaderService()
        {
            this.manager = new DataManager();
        }

        public IReaderData Transfer(IReader reader)
        {
            if (reader == null)
            {
                return null;
            }

            return new ReaderData
            {
                Name = reader.Name,
                ReaderID = reader.ReaderID,
            };
        }

        public IEnumerable<IReaderData> GetReaders()
        {
            var readers = manager.GetReaders();
            var result = new List<IReaderData>();

            foreach (var reader in readers)
            {
                result.Add(Transfer(reader));
            }

            return result;
        }

        public IReaderData GetReader(int ID)
        {
            return Transfer(manager.GetReader(ID));
        }

        public bool AddReader(int ID, string Name)
        {
            return manager.AddReader(ID, Name);
        }

        public bool UpdateReader(int ID, string Name)
        {
            return manager.UpdateReader(ID, Name);
        }

        public bool DeleteReader(int ID)
        {
            return manager.DeleteReader(ID);
        }
    }
}
