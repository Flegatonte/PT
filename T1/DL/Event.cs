using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class Event
    {
        public enum EventKind
        {
            Return,
            Borrow
        }

        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int EventID { get; set; }
        public DateTime Date { get; set; }
        public EventKind Kind { get; set; }

        public Event(int userID, int movieID, int eventID, DateTime date, EventKind eventKind)
        {
            UserID = userID;
            MovieID = movieID;
            EventID = eventID;
            Date = date;
            Kind = eventKind;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Event))
            {
                return false;
            }

            Event e = (Event)obj;
            return UserID == e.UserID && Date == e.Date && MovieID == e.MovieID && EventID == e.EventID && Kind == e.Kind;
        }

        public override int GetHashCode()
        {
            return UserID.GetHashCode() ^ MovieID.GetHashCode() ^ EventID.GetHashCode() ^ Date.GetHashCode() ^ Kind.GetHashCode();
    }
}