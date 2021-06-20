using System;

namespace Presentation.API
{
    public interface IEventModelView
    {
        int EventID { get; set; }
        DateTime? Date { get; set; }
        int? BookID { get; set; }
        int? ReaderID { get; set; }
    }
}
