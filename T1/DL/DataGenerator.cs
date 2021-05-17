using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class DataGenerator : IDataGenerator
    {
        public void GenarateData(IData data)
        {
            // Generate movies
            IMovie movie1 = IMovie.returnMovie(1, "Maze Runner: The Death Cure", "Wyck Godfrey", 2018, IMovie.MovieGenre.Action, 143);
            IMovie movie2 = IMovie.returnMovie(2, "Sausage Party", "Greg Tiernan, Conrad Vernon", 2016, IMovie.MovieGenre.Comedy, 89);
            IMovie movie3 = IMovie.returnMovie(3, "Pieces of a Woman", "Kornél Mundruczó", 2020, IMovie.MovieGenre.Drama, 128);
            IMovie movie4 = IMovie.returnMovie(4, "The Ring", "Gore Verbinski", 2002, IMovie.MovieGenre.Horror, 115);
            IMovie movie5 = IMovie.returnMovie(5, "Enola Holmes", "Harry Bradbeer", 2020, IMovie.MovieGenre.Mystery, 123);

            data.movies.movieCatalog.Add(1, movie1);
            data.movies.movieCatalog.Add(2, movie2);
            data.movies.movieCatalog.Add(3, movie3);
            data.movies.movieCatalog.Add(4, movie4);
            data.movies.movieCatalog.Add(5, movie5);


            // Generate users
            IUser user1 = IUser.returnUser("Adam", "Barna", 102030, "+48-885-5610-71");
            IUser user2 = IUser.returnUser("Dobrogost", "Chmielinski", 102031, "+48-875-5510-72");
            IUser user3 = IUser.returnUser("Herbert", "Franckowiak", 102032, "+48-865-5410-73");
            IUser user4 = IUser.returnUser("Jaromir", "Gac", 102033, "+48-855-5310-74");
            IUser user5 = IUser.returnUser("Leokadiusz", "Dworaczyk", 102034, "+48-845-5210-75");

            data.users.Add(user1);
            data.users.Add(user2);
            data.users.Add(user3);
            data.users.Add(user4);
            data.users.Add(user5);

            // Generate DVD
            for (int i = 1; i <= data.movies.movieCatalog.Count; i++)
            {
                data.dvds.Add(IDVD.returnDVD(data.movies.movieCatalog[i], 10, 10));
            }

           
        }
    }
}
