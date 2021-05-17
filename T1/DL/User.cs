using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class User : IUser
    {
        public User(string name, string surname, int userID, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            UserID = userID;
            PhoneNumber = phoneNumber;
        }
        /*
        public string Name { get; set; }

        public string Surname { get; set; }

        public int UserID { get; set; }

        public string PhoneNumber { get; set; }
        */

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
            {
                return false;
            }

            User user = (User)obj;
            return UserID == user.UserID && Name == user.Name && Surname == user.Surname && PhoneNumber == user.PhoneNumber;
        }

        public override int GetHashCode()
        {
            return UserID.GetHashCode() ^ Name.GetHashCode() ^ Surname.GetHashCode() ^ PhoneNumber.GetHashCode();
        }
    }
}