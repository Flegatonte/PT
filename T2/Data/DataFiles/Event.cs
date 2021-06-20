using Data.API;
using System;

namespace Data.DataFiles
{
    public class Event : IEvent
    {
        public int EventID { get; set; }
        public DateTime? Date { get; set; }
        public int? BookID { get; set; }
        public int? ReaderID { get; set; }

        public Event(int eventID, DateTime? date, int? bookID, int? readerID)
        {
            EventID = eventID;
            Date = date;
            BookID = bookID;
            ReaderID = readerID;
        }
    }
}
