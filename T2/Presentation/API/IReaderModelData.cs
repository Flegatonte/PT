using Service.API;
using System.Collections.Generic;

namespace Presentation.API
{
    interface IReaderModelData
    {
        IReaderService Service { get; }
        IEnumerable<IReaderData> Reader { get; }
        IReaderModelView CreateReader(string Name, int ID);
    }
}
