using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class DataGenerator : IDataGenerator
    {
        public void GenarateData(Data data)
        {
            // Generate users
            Movie movie1 = new Movie(32433234, "Maze Runner: The Death Cure", "Wyck Godfrey", 2018, Movie.MovieGenre.Action, 143);
            Movie movie2 = new Movie(93428837, "Sausage Party", "Greg Tiernan, Conrad Vernon", 2016, Movie.MovieGenre.Comedy, 89);
            Movie movie3 = new Movie(45874956, "Pieces of a Woman", "Kornél Mundruczó", 2020, Movie.MovieGenre.Drama, 128);
            Movie movie4 = new Movie(79363296, "The Ring", "Gore Verbinski", 2002, Movie.MovieGenre.Horror, 115);
            Movie movie5 = new Movie(92835344, "Enola Holmes", "Harry Bradbeer", 2020, Movie.MovieGenre.Mystery, 123);

            data.movies.movieCatalog.Add(1, movie1);
            data.movies.movieCatalog.Add(1, movie2);
            data.movies.movieCatalog.Add(1, movie3);
            data.movies.movieCatalog.Add(1, movie4);
            data.movies.movieCatalog.Add(1, movie5);


            // Generate users
            User user1 = new User("Adam", "Barna", 102030, "+48-885-5610-71");
            User user2 = new User("Dobrogost", "Chmielinski", 102031, "+48-875-5510-72");
            User user3 = new User("Herbert", "Franckowiak", 102032, "+48-865-5410-73");
            User user4 = new User("Jaromir", "Gac", 102033, "+48-855-5310-74");
            User user5 = new User("Leokadiusz", "Dworaczyk", 102034, "+48-845-5210-75");

            data.users.Add(user1);
            data.users.Add(user2);
            data.users.Add(user3);
            data.users.Add(user4);
            data.users.Add(user5);

            // Generate DVD
            for (int i = 1; i <= data.movies.movieCatalog.Count; i++)
            {
                data.dvds.Add( new DVD(data.movies.movieCatalog[i], 10, 10));
            }

            // Generate events
            /*
            Event event1 = new Event(102030, 32433234, 0000, new DateTime(2020, 12, 16, 12, 0, 0), Event.EventState.Borrowed);
            Event event2 = new Event(102030, 32433234, 0001, new DateTime(2020, 11, 17, 13, 0, 0), Event.EventState.Borrowed);
            Event event3 = new Event(102030, 32433234, 0002, new DateTime(2020, 10, 18, 14, 0, 0), Event.EventState.Borrowed);
            Event event4 = new Event(102030, 32433234, 0003, new DateTime(2020, 9, 19, 15, 0, 0), Event.EventState.Borrowed);
            Event event5 = new Event(102030, 32433234, 0004, new DateTime(2020, 8, 20, 16, 0, 0), Event.EventState.Borrowed);
            */
        }
    }
}