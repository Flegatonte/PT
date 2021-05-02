using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LL
{
    public class DataService
    {
        private IDataManager dataManager;

        public DataService(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }


        public Dictionary<int, Movie> GetMovieCatalog();
        {
            Dictionay<int, Movie> movies = dataManager.GetMovieCatalog();
         if (movies.Count == 0)
            {
                return null;
            }
            else
            {
                return movies;
            }
        }
        public int GetMoviesCount()
                {
                    return data.GetMoviesCount();
                }

                public List<Users> GetUsers()
                {
                    List<Users> users = dataManager.GetUsers();
                    if (users.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return users;
                    }
                }
        public int GetUsersCount()
                {
                    return dataManager.GetUsersCount();
                }

                public List<Event> GetAllEvents()
                {
                    List<Event> events = dataManager.GetAllEvents();
                    if (events.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return events;
                    }
                }
        public int GetEventsCount()
        {
            return dataManager.GetEventsCount();
        }
    
        public Movie GetMovieIMDB(int id)
        {
            return dataManager.GetMovieIMDB(id);
        }

        public Movie GetMoviesGenre(Movie.MovieGenre genre)
        {
            return dataManager.GetMoviesGenre(genre);
        }

        public User GetUserByID(int id)
        {
            return dataManager.GetUserByID(id);
        }

        public Event GetEventByID(int id)
        {
            return dataManager.GetEventByID(id);
        }

        
        public void AddMovie(Movie movie)
        {
    dataManager.AddMovie(movie);
        }

        public void AddUser(User user)
        {
    dataManager.AddUser(user);
        }

        
        public void EditMovie(Movie movie)
        {
    dataManager.UpdateMovieInfo(movie);
        }

        public void EditUser(User user)
        {
    dataManager.UpdateUserInfo(user);
        }

        public void EditEvent(Event e)
        {
    dataManager.UpdateEventInfo(e);
        }
        
        public void DeleteMovie(int id)
        {
    dataManager.DeleteMovie(id);
        }

        public void DeleteUser(int id)
        {
    dataManager.DeleteUser(id);
        }
        
        public void UpdateStock(Movie movie, int amount)
        {
    dataManager.increaseCopies(movie, amount);
        }

        public Dictionary<int, int> GetAllAvailables()
        {
            return dataManager.GetAvailableDVDs();
        }

        public State GetStateLibrary()
        {
            return dataManager.GetState();
        }

        public int GetAllAvailablesIMBD(int IMBD)
        {
            return dataManager.GetAvailableCopiesByIMDB(IMBD);
        }

        public void AddDVD(DVD dvd)
        {
    dataManager.AddDVD(dvd);
        }

        public void DeleteDVD(DVD dvd)
        {
    dataManager.DeleteDVD(dvd);
        }
        
        public void borrowDVD(int userID, int movieID, int eventID, DateTime borrowDate)
                {
                    var currentMovieState = dataManager.GetAvailableCopiesByIMDB(movieID);
                    var user = dataManager.GetUserByID(userID);

                    if (currentMovieState == 0)
                    {
                        throw new InvalidOperationException("The movie is not available");
                    }

                    Event e = new Event(userID, eventID, Event.EventState.Borrowed, borrowDate);
    dataManager.AddEvent(e);
    dataManager.decreaseCopies(int movieID);
                    // OnEventUpdateState(movieId, currentMovieState, user, true);
                }

        public void returnMovie(int userID, int movieID, int eventID, DateTime borrowDate)
        {
            var currentMovieState = dataManager.GetAvailableCopiesByIMDB(movieID);
            var user = dataManager.GetUserByID(userID);

            if (currentMovieState == 0)
            {
                throw new InvalidOperationException("The movie is not available");
            }

            Event e = new Event(userID, eventID, Event.EventState.Returned, borrowDate);
            dataManager.UpdateEventInfo(e);
    dataManager.increaseCopies(int movieID);
    // OnEventUpdateState(movieId, currentMovieState, user, true);
}

  
        
        public IEnumerable<Event> GetEventsForUser(int userID)
        {
            var user = dataManager.GetUserByID(userId);
            List<Event> events = new List<Event>();

            foreach (Event ev in dataManager.GetAllEvents())
            {
                if (ev.User.Equals(user))
                {
                    events.Add(ev);
                }
            }
            return events;
        }
        
        public IEnumerable<Event> GetEventsBetweenDates(DateTime start, DateTime end)
        {
            List<Event> events = new List<Event>();

            foreach (Event ev in dataManager.GetAllEvents())
            {
                if (ev.Date >= start && ev.Date <= end)
                {
                    events.Add(ev);
                }
            }
            return events;
        }
    }
}
