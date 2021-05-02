using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class DataManager : IDataManager
    {
        private Data data;

        public DataManager(Data data)
        {
            this.data = data;
        }

        // Getting movie catalog
        public Dictionary<int, Movie> GetMovieCatalog()
        {
            return data.movies.movieCatalog;
        }

        public int GetMoviesCount()
        {
            return data.movies.movieCatalog.Count;
        }

        public Movie GetMovieIMDB(int IMDB)
        {
            if (data.movies.movieCatalog.ContainsKey(IMDB))
            {
                return data.movies.movieCatalog[IMDB];
            }
            throw new Exception("Book with such IMDB does not exist in the archive");
        }

        public List<Movie> GetMoviesGenre(Movie.MovieGenre genre)
        {
            foreach (var movie in data.movies.movieCatalog)
            {
                List<Movie> res = new List<Movie>();

                if (movie.Value.Genre == genre)
                {
                    res.Add(movie.Value);
                }
                return res;
            }
            throw new Exception("There are no movies of this genre in the library.");
        }

        public void UpdateMovieInfo(Movie movie)
        {
            if (data.movies.movieCatalog.ContainsKey(movie.IMDB))
            {
                data.movies.movieCatalog[movie.IMDB].Title = movie.Title;
                data.movies.movieCatalog[movie.IMDB].Director = movie.Director;
                data.movies.movieCatalog[movie.IMDB].Year = movie.Year;
                data.movies.movieCatalog[movie.IMDB].Genre = movie.Genre;
                data.movies.movieCatalog[movie.IMDB].Duration = movie.Duration;
            }
            else
            {
                throw new InvalidOperationException("Such movie does not exist in the library");
            }
        }

        public void AddMovie(Movie movie)
        {
            if (data.movies.movieCatalog.ContainsKey(movie.IMDB))
            {
                throw new Exception("Movie with such IMDB already exists in the library");
            }
            data.movies.movieCatalog.Add(movie.IMDB, movie);
        }

        public void DeleteMovie(int IMDB)
        {
            if (data.movies.movieCatalog.ContainsKey(IMDB))
            {
                data.movies.movieCatalog.Remove(IMDB);
            }
            else
            {
                throw new InvalidOperationException("Such movie does not exist in the library");
            }
        }

        // Users methods 
        public List<User> GetUsers()
        {
            return data.users;
        }

        public int GetUsersCount()
        {
            return data.users.Count;
        }

        public User GetUserByID(int ID)
        {
            for (int i = 0; i < data.users.Count; i++)
            {
                if (data.users[i].UserID == ID)
                {
                    return data.users[i];
                }
            }
            throw new Exception("User with such ID does not exist");
        }

        public void UpdateUserInfo(User user)
        {
            for (int i = 0; i < data.users.Count; i++)
            {
                if (data.users[i].UserID == user.UserID)
                {
                    data.users[i].Name = user.Name;
                    data.users[i].Surname = user.Surname;
                    data.users[i].UserID = user.UserID;
                    data.users[i].PhoneNumber = user.PhoneNumber;
                    return;
                }
            }
            throw new InvalidOperationException("Such user ID does not exist in the library");
        }

        public void AddUser(User user)
        {
            for (int i = 0; i < data.users.Count; i++)
            {
                if (data.users[i].UserID == user.UserID)
                {
                    throw new Exception("User with such ID already exists in the library");
                }
            }
            data.users.Add(user);
        }

        private bool hasBorrow(int userID)
        {
            bool res = false;

            for (int i = 0; i < data.events.Count; i++)
            {
                if (data.events[i].UserID == userID && data.events[i].State != Event.EventState.Returned)
                {
                    res = true;
                }
            }
            return res;
        }

        public void DeleteUser(int userID)
        {
            for (int i = 0; i < data.users.Count; i++)
            {
                if (data.users[i].UserID == userID)
                {
                    if (!hasBorrow(userID))
                    {
                        data.users.Remove(data.users[i]);
                        return;
                    }
                    else
                    {
                        throw new InvalidOperationException("This user has movies borrowed!");
                    }

                }
            }
            throw new InvalidOperationException("No such user in the archive");
        }

        // Methods for events
        public List<Event> GetAllEvents()
        {
            return data.events;
        }

        public int GetEventsCount()
        {
            return data.events.Count;
        }

        public Event GetEventByID(int eventID)
        {
            for (int i = 0; i < data.events.Count; i++)
            {
                if (data.events[i].EventID == eventID)
                {
                    return data.events[i];
                }
            }
            throw new Exception("Event with such ID does not exist");
        }

        public void decreaseCopies(int movieID, int amount)
        {
            data.dvds.Find(x => x.Movie.IMDB == movieID).AvailableCopies -= amount;
        }

        public void increaseCopies(int movieID, int amount)
        {
            data.dvds.Find(x => x.Movie.IMDB == movieID).AvailableCopies += amount;
        }

        public void AddEvent(Event e)
        {
            for (int i = 0; i < data.events.Count; i++)
            {
                if (data.events[i].EventID == e.EventID)
                {
                    throw new Exception("Event with such ID already exists");
                }
            }
            if (e.State == Event.EventState.Borrowed)
            {
                // decreaseCopies(e.MovieID);
            }
            data.events.Add(e);
        }

        public void DeleteEvent(int eventID)
        {
            for (int i = 0; i < data.events.Count; i++)
            {
                if (data.events[i].EventID == eventID)
                {
                    data.events.Remove(data.events[i]);
                    return;
                }
            }
            throw new InvalidOperationException("Event with such ID does not exist!");
        }

        public void UpdateEventInfo(Event e)
        {
            for (int i = 0; i < data.events.Count; i++)
            {
                if (data.events[i].EventID == e.EventID)
                {
                    if (data.events[i].State == Event.EventState.Borrowed && e.State == Event.EventState.Returned)
                        increaseCopies(e.MovieID, 1);
                    data.events[i].Date = e.Date;
                    data.events[i].MovieID = e.MovieID;
                    data.events[i].EventID = e.EventID;
                    data.events[i].State = e.State;
                    return;
                }
            }
            throw new InvalidOperationException("Cannot update - event with such ID does not exist!");
        }

        // DVDs
        public List<DVD> GetAvailableDVDs()
        {
            return data.dvds.FindAll(x => x.AvailableCopies > 0);
        }

        public List<DVD> GetDVDs()
        {
            return data.dvds;
        }

        public int GetAvailableCopiesByIMDB(int IMDB)
        {
            return data.dvds.Find(x => x.Movie.IMDB == IMDB).AvailableCopies;
        }

        public void increaseDVD(int amount, Movie movie )
        {
            for (int i = 0; i < data.dvds.Count; i++)
            {
                if (data.dvds[i].Movie == movie)
                {
                    data.dvds[i].AvailableCopies += amount;
                }
            }
        }

        public void AddDVD(DVD dvd)
        {
            if (data.dvds.Contains(dvd))
            {
                throw new Exception("DVD already exists in the library");
            }
            data.dvds.Add(dvd);
        }

        public void DeleteDVD(DVD dvd)
        {
            if (!data.dvds.Contains(dvd))
            {
                throw new Exception("DVD does not exist in the archive");
            }
            data.dvds.Remove(dvd);
        }
    }
}
