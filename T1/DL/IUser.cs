using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public abstract class IUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int UserID { get; set; }

        public string PhoneNumber { get; set; }

        public static IUser returnUser(string name, string surname, int userID, string phoneNumber)
        {
            return new User(name, surname, userID, phoneNumber);
        }
    }
}
