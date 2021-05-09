using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public interface IDVD
    {
        public IMovie Movie { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
    }
}
