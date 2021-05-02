using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class Event
    {
        public enum EventState
        {
            Returned,
            Borrowed
        }

        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        public EventState State { get; set; }

        public Event(int userID, int movieID, int eventID, DateTime date, EventState eventState)
        {
            UserID = userID;
            MovieID = movieID;
            EventID = eventID;
            Date = date;
            State = eventState;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Event))
            {
                return false;
            }

            Event e = (Event)obj;
            return UserID == e.UserID && Date == e.Date && MovieID == e.MovieID && EventID == e.EventID && State == e.State;
        }

        public override int GetHashCode()
        {
            return UserID.GetHashCode() ^ MovieID.GetHashCode() ^ EventID.GetHashCode() ^ Date.GetHashCode() ^ State.GetHashCode();
        }
    }
}