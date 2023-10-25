using Quiz.Database;
using Quiz.Helpers;
using System;

namespace Quiz.Services
{
    internal static class UserService
    {
        public static bool Register(string name, string surname, string password)
        {
            if (
                Validations.ValidateName(name) && Validations.ValidateSurname(surname) && Validations.ValidatePassword(password) ){
                BlogDatabase.Register(name, surname, password);

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Login(string username, string password)
        {
            bool check = false;


            return check;
        }

    }
}
