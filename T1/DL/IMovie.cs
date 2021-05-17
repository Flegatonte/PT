using System;
using System.Collections.Generic;
using System.Text;
using static DL.Movie;

namespace DL
{
    public abstract class IMovie
    {
        public enum MovieGenre
        {
            Action,
            Comedy,
            Drama,
            Fantasy,
            Horror,
            Mystery,
            Romance,
            Thriller,
            Western
        }
        public int IMDB { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int Year { get; set; }

        public MovieGenre Genre { get; set; }

        public int Duration { get; set; }

        public static IMovie returnMovie(int IMDB, string title, string director, int year, MovieGenre genre, int duration)
        {
            return new Movie(IMDB, title, director, year, genre, duration);
        }
    }
}
