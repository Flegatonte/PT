using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    internal class MovieCatalog : IMovieCatalog
    {
        public Dictionary<int, IMovie> movieCatalog { get; set; } = new Dictionary<int, IMovie>();
    }
}