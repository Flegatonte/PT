using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LL
{
    public class DataS
    {
        private IRepository repository;

        public DataService(IRepository repository)
        {
            this.repository = repository;
        }


        public Dictionary<int, Movie> GetMovieCatalog();
        {
            Dictionay<int, Movie> movies = repository.GetAllMovies();
         if (movies.Count == 0)
            {
                return null;
            }
            else
            {
                return movies;
            }
        }
        public int GetAllMoviesNumber()
                {
                    return repository.GetAllMoviesNumber();
                }

                public List<Users> GetAllUsers()
                {
                    List<Users> users = repository.GetAllUsers();
                    if (users.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return users;
                    }
                }
        public int GetAllUserNumber()
                {
                    return repository.GetAllUserNumber();
                }

                public List<Event> GetAllEvents()
                {
                    List<Event> events = repository.GetAllEvents();
                    if (events.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return events;
                    }
                }
        public int GetAllEventsNumber()
        {
            return repository.GetAllEventsNumber();
        }
    
        public Movie GetMovieById(int id)
        {
            return repository.GetMovieById(id);
        }

        public Movie GetMovieByGenre(MovieGenre genre)
        {
            return repository.GetMovieByGenre(genre);
        }

        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }

        public Event GetEventById(int id)
        {
            return repository.GetEventById(id);
        }

        
        public void AddMovie(Movie movie)
        {
            repository.AddMovie(movie);
        }

        public void AddUser(User user)
        {
            repository.AddUser(user);
        }

        
        public void EditMovie(Movie movie)
        {
            repository.UpdateMovieInfo(movie);
        }

        public void EditUser(User user)
        {
            repository.UpdateUserInfo(user);
        }

        public void EditEvent(Event e)
        {
            repository.UpdateEventInfo(e);
        }
        
        public void DeleteMovie(int id)
        {
            repository.DeleteMovie(id);
        }

        public void DeleteUser(int id)
        {
            repository.DeleteUser(id);
        }
        
        public void UpdateStock(int movieId, int newAmount)
        {
            repository.UpdateMovieState(movieId, newAmount);
        }

        public Dictionary<int, int> GetAllAvailableMovies()
        {
            return repository.GetAllStates();
        }

        public State GetStateLibrary()
        {
            return repository.GetState();
        }

        public int GetAmountOfAvailableCopiesById(int movieId)
        {
            return repository.GetAmountOfAvailableCopiesById(movieId);
        }

        public void AddNewMovieState(int movieId, int state)
        {
            repository.AddMovieState(movieId, state);
        }

        public void DeleteMoviestate(int movieId)
        {
            repository.DeleteMoviestate(movieId);
        }
        
        public void borrowMovie(int userId, int eventId, int movieId, DateTime borrowDate)
                {
                    var currentMovieState = repository.GetAmountOfAvailableCopiesById(movieId);
                    var user = repository.GetUserById(userId);

                    if (currentMovieState == 0)
                    {
                        throw new InvalidOperationException("The movie is not avarible");
                    }

                    BorrowingEvent bEvent = new BorrowingEvent(eventId, user, repository.GetState(), borrowDate);
                    repository.AddEvent(bEvent);
                    OnEventUpdateState(movieId, currentMovieState, user, true);
                }
        
         public void returnMovie(int userId, int eventId, int movieId, DateTime returnDate)
        {
            var currentMovieState = repository.GetAmountOfAvailableCopiesById(movieId);
            var user = repository.GetUserById(userId);
            var userMovies = user.AmountOfMoviesBorrowed;

            if (userMovies == 0)
            {
                throw new InvalidOperationException("You can not return moviesif you don´t borrow.");
            }

            ReturningEvent rEvent = new ReturningEvent(eventId, user, repository.GetState(), returnDate);
            repository.AddEvent(rEvent);
            OnEventUpdateState(movieId, currentMovieState, user, false);
        }

         private void OnEventUpdateState(int movieId, int currentMovieState, User user, bool isBorrowing)
        {
            if (isBorrowing)
            {
                currentMovieState -= 1;
                user.AmountOfMoviesBorrowed += 1;
                repository.UpdateMovieState(movieId, currentMovieState);
            }
            else
            {
                currentMovieState += 1;
                user.currentMovieState -= 1;
                repository.currentMovieState(movieId, currentMovieState);
            }
        }
        
        public IEnumerable<Event> GetEventsForUser(int userId)
        {
            var user = repository.GetUserById(userId);
            List<Event> events = new List<Event>();

            foreach (Event ev in repository.GetAllEvents())
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

            foreach (Event ev in repository.GetAllEvents())
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
