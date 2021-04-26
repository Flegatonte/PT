using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class MovieCatalog
    {
        public Dictionary<int, Movie> movieCatalog { get; set; } = new Dictionary<int, Movie>();
    }
}