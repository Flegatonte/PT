using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public interface IMovieCatalog
    {
        public Dictionary<int, IMovie> movieCatalog { get; set; }
    }
}
