using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class DVD
    {
        public Movie Movie { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }

        public DVD (Movie movie, int availableCopies, int totalCopies)
        {
            Movie = movie;
            AvailableCopies = availableCopies;
            TotalCopies = totalCopies;
        }
    }
}