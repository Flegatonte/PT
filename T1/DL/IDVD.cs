using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public abstract class IDVD
    {
        public IMovie Movie { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }

        public static IDVD returnDVD(IMovie movie, int availableCopies, int totalCopies)
        {
            return new DVD(movie, availableCopies, totalCopies);
        }
    }
}
