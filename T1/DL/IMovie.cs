using System;
using System.Collections.Generic;
using System.Text;
using static DL.Movie;

namespace DL
{
    public interface IMovie
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
    }
}
