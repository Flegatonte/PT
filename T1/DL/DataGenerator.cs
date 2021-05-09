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
            IMovie movie1 = new Movie(1, "Maze Runner: The Death Cure", "Wyck Godfrey", 2018, IMovie.MovieGenre.Action, 143);
            IMovie movie2 = new Movie(2, "Sausage Party", "Greg Tiernan, Conrad Vernon", 2016, IMovie.MovieGenre.Comedy, 89);
            IMovie movie3 = new Movie(3, "Pieces of a Woman", "Kornél Mundruczó", 2020, IMovie.MovieGenre.Drama, 128);
            IMovie movie4 = new Movie(4, "The Ring", "Gore Verbinski", 2002, IMovie.MovieGenre.Horror, 115);
            IMovie movie5 = new Movie(5, "Enola Holmes", "Harry Bradbeer", 2020, IMovie.MovieGenre.Mystery, 123);

            data.movies.movieCatalog.Add(1, movie1);
            data.movies.movieCatalog.Add(2, movie2);
            data.movies.movieCatalog.Add(3, movie3);
            data.movies.movieCatalog.Add(4, movie4);
            data.movies.movieCatalog.Add(5, movie5);


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

           
        }
    }
}
