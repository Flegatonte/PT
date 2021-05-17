using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public abstract class IData
    {
        public List<IUser> users = new List<IUser>();
        public IMovieCatalog movies = new MovieCatalog();
        public List<IEvent> events = new List<IEvent>();
        public List<IDVD> dvds = new List<IDVD>();

        public static IData getData()
        {
            return new Data();
        }
    }
}
