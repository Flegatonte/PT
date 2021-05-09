using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public interface IUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int UserID { get; set; }

        public string PhoneNumber { get; set; }
    }
}
