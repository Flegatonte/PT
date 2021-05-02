using System;
using System.Collections.Generic;
using System.Text;

namespace DL

//CRUD definition (create, remove, update, delete)
{
    public interface IDataManager
    {
        // Movies
        public Dictionary<int, Movie> GetMovieCatalog();
        public int GetMoviesCount();
        public Movie GetMovieIMDB(int IMDB);
        public List<Movie> GetMoviesGenre(Movie.MovieGenre genre);
        public void UpdateMovieInfo(Movie movie);
        public void AddMovie(Movie movie);
        public void DeleteMovie(int IMDB);

        // Users
        public List<User> GetUsers();
        public int GetUsersCount();
        public User GetUserByID(int ID);
        public void UpdateUserInfo(User user);
        public void DeleteUser(int userID);

        public void AddUser(User user);

        // Events
        public List<Event> GetAllEvents();
        public int GetEventsCount();
        public Event GetEventByID(int eventID);
        public void AddEvent(Event e); // Decrement by one if borrowing event
        public void DeleteEvent(int eventID);
        public void UpdateEventInfo(Event e); // Increment by one if the state changes in Returned

        public void increaseCopies(int movieID, int amount);
        public void decreaseCopies(int movieID, int amount);

        // DVDs
        public List<DVD> GetAvailableDVDs();
        public List<DVD> GetDVDs();
        public int GetAvailableCopiesByIMDB(int IMDB);
        public void AddDVD(DVD dvd); 
        public void DeleteDVD(DVD dvd);
    }
}