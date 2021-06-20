using Service.API;
using System;

namespace Service.DataFiles
{
    public class EventData : IEventData
    {
        public int EventID { get; set; }
        public DateTime? Date { get; set; }
        public int? BookID { get; set; }
        public int? ReaderID { get; set; }
    }
}
