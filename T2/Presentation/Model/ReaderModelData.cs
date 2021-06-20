using Presentation.API;
using Service.API;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class ReaderModelData : IReaderModelData
    {
        public IReaderService Service { get; }
        public ReaderModelData(IReaderService service)
        {
            Service = service;
        }

        public IEnumerable<IReaderData> Reader
        {
            get
            {
                IEnumerable<IReaderData> readers = Service.GetReaders();
                return readers;
            }
        }

        public IReaderModelView CreateReader(string Name, int ID)
        {
            return new ReaderModelView(Name, ID);
        }
    }
}
