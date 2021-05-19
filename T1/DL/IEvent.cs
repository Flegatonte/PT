using System;
using System.Collections.Generic;
using System.Text;
using static DL.Event;

namespace DL
{
    public abstract class IEvent
    {
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        public EventState State { get; set; }

        public enum EventState
        {
            Returned,
            Borrowed
        }

        public static IEvent returnEvent(int userID, int movieID, int eventID, DateTime date, EventState eventState)
        {
            return new Event(userID, movieID, eventID, date, eventState); 
        }
    }
}
