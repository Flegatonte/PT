using System;
using System.Collections.Generic;
using System.Text;
using static DL.Event;

namespace DL
{
    public interface IEvent
    {
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        public EventState State { get; set; }
    }
}
