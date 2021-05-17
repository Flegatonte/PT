using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class DVD : IDVD
    {
        /*
        public IMovie Movie { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        */

        public DVD (IMovie movie, int availableCopies, int totalCopies)
        {
            Movie = movie;
            AvailableCopies = availableCopies;
            TotalCopies = totalCopies;
        }
    }
}