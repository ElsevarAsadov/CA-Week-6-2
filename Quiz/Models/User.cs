using Quiz.Exceptions;
using Quiz.Helpers;
using System;

namespace Quiz.Models
{
    internal class User
    {
        private static int _id = 1; 
        public string Password;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }


        public static string MakeUsername(string name, string surname) {

            string sanitazedName = Utils.SanitazeStringForValidation(name);
            string sanitazedSurname = Utils.SanitazeStringForValidation(surname);

            return sanitazedName + "." + sanitazedSurname; 
        }


        public User(string password, string name, string surname)
        {
            Password = Validations.ValidatePassword(password) ? password : throw new InvalidPasswordException();

            Id = User._id;
            Name = name;
            Surname = surname;
            Username = User.MakeUsername(name: name, surname: surname);

            User._id++;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Surname} - {Username}";
        }



    }
}
