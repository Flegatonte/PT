using System;
using System.Collections.Generic;

namespace Service.API
{
    public interface IEventService
    {
        IEnumerable<IEventData> GetEvents();
        IEventData GetEventByID(int ID);
        IEnumerable<IEventData> GetEventsByReaderID(int ID);
        bool AddEvent(int EventID, DateTime Date, int BookID, int ReaderID);
        bool UpdateEventBook(int ID, int BookID);
        bool UpdateEventReader(int ID, int ReaderID);
        bool DeleteEvent(int ID);
    }
}
