using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace DL
{
    public class Data
    {
        public List<IUser> users = new List<IUser>();
        public IMovieCatalog movies = new MovieCatalog();
        public List<IEvent> events = new List<IEvent>();
        public List<IDVD> dvds = new List<IDVD>();
    }
}