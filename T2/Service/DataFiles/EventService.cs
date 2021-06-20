using Data.API;
using Data.DataFiles;
using Service.API;
using System;
using System.Collections.Generic;

namespace Service.DataFiles
{
    public class EventService : IEventService
    {
        private IDataManager manager;
        public EventService(IDataManager manager)
        {
            this.manager = manager;
        }
        public EventService()
        {
            this.manager = new DataManager();
        }

        public IEventData Transfer(IEvent _event)
        {
            if (_event == null)
            {
                return null;
            }

            return new EventData
            {
                EventID = _event.EventID,
                Date = _event.Date,
                BookID = _event.BookID,
                ReaderID = _event.ReaderID,
            };
        }

        public IEnumerable<IEventData> GetEvents()
        {
            var events = manager.GetEvents();
            var result = new List<IEventData>();

            foreach (var _event in events)
            {
                result.Add(Transfer(_event));
            }

            return result;
        }

        public IEventData GetEventByID(int ID)
        {
            return Transfer(manager.GetEventByID(ID));
        }

        public IEnumerable<IEventData> GetEventsByReaderID(int ID)
        {
            var events = manager.GetEventsByReaderID(ID);
            var result = new List<IEventData>();

            foreach (var _event in events)
            {
                result.Add(Transfer(_event));
            }

            return result;
        }

        public bool AddEvent(int EventID, DateTime Date, int BookID, int ReaderID)
        {
            return manager.AddEvent(EventID, Date, BookID, ReaderID);
        }

        public bool UpdateEventBook(int ID, int BookID)
        {
            return manager.UpdateEventBook(ID, BookID);
        }

        public bool UpdateEventReader(int ID, int ReaderID)
        {
            return manager.UpdateEventReader(ID, ReaderID);
        }

        public bool DeleteEvent(int ID)
        {
            return manager.DeleteEvent(ID);
        }
    }
}
