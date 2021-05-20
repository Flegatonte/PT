using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    internal class Event : IEvent
    {

        public Event(int userID, int movieID, int eventID, DateTime date, IEvent.EventState eventState)
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