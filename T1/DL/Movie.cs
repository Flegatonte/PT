using System;
using System.Collections.Generic;
using System.Text;
using static DL.IMovie;

namespace DL
{
    internal class Movie : IMovie
    {

        public Movie(int IMDB, string title, string director, int year, MovieGenre genre, int duration)
        {
            this.IMDB = IMDB;
            Title = title;
            Director = director;
            Year = year;
            Genre = genre;
            Duration = duration;
        }

        /*
        public int IMDB { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public int Duration { get; set; }
        */

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Movie))
            {
                return false;
            }

            Movie movie = (Movie)obj;
            return IMDB == movie.IMDB && Title == movie.Title && Director == movie.Director &&
                Year == movie.Year && Genre == movie.Genre && Duration == movie.Duration;
        }

        public override int GetHashCode()
        {
            return IMDB.GetHashCode() ^ Title.GetHashCode() ^ Director.GetHashCode()
                ^ Year.GetHashCode() ^ Genre.GetHashCode() ^ Duration.GetHashCode();
        }
    }
}
