using System;
using System.Collections.Generic;
using System.Text;

namespace DL

//CRUD definition (create, remove, update, delete)
{
    public interface IDataManager
    {
        public static IDataManager returnDataManager()
        {
            return new DataManager();
        }

        // Data
        public IData getData();

        // Movies
        public Dictionary<int, IMovie> GetMovieCatalog();
        public int GetMoviesCount();
        public IMovie GetMovieIMDB(int IMDB);
        public List<IMovie> GetMoviesGenre(IMovie.MovieGenre genre);
        public void UpdateMovieInfo(IMovie movie);
        public void AddMovie(IMovie movie);
        public void DeleteMovie(int IMDB);

        // Users
        public List<IUser> GetUsers();
        public int GetUsersCount();
        public IUser GetUserByID(int ID);
        public void UpdateUserInfo(IUser user);
        public void DeleteUser(int userID);

        public void AddUser(IUser user);

        // Events
        public List<IEvent> GetAllEvents();
        public int GetEventsCount();
        public IEvent GetEventByID(int eventID);
        public void AddEvent(IEvent e); // Decrement by one if borrowing event
        public void DeleteEvent(int eventID);
        public void UpdateEventInfo(IEvent e); // Increment by one if the state changes in Returned

        public void increaseCopies(int movieID, int amount);
        public void decreaseCopies(int movieID, int amount);

        // DVDs
        public List<IDVD> GetAvailableDVDs();
        public List<IDVD> GetDVDs();
        public int GetAvailableCopiesByIMDB(int IMDB);
        public void AddDVD(IDVD dvd); 
        public void DeleteDVD(IDVD dvd);
    }
}