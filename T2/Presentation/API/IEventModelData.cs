using Service.API;
using System;
using System.Collections.Generic;

namespace Presentation.API
{
    interface IEventModelData
    {
        IEventService Service { get; }
        IEnumerable<IEventData> Event { get; }
        IEventModelView CreateEvent(int ID, DateTime Date, int BookID, int ReaderID);
    }
}
