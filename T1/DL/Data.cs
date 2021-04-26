using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace DL
{
    public class Data
    {
        public List<User> users = new List<User>();
        public MovieCatalog movies = new MovieCatalog();
        public List<Event> events = new List<Event>();
        public List<DVD> dvds = new List<DVD>();
    }
}