using System;

namespace Data.API
{
    public interface IEvent
    {
        int EventID { get; set; }
        DateTime? Date { get; set; }
        int? BookID { get; set; }
        int? ReaderID { get; set; }
    }
}
