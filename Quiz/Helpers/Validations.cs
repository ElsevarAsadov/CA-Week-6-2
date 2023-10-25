using System;



namespace Quiz.Helpers
{
    internal class Validations
    {
        public static bool ValidateBlog(string desc, string content) {



            if(desc == null || desc.Length < 3)
            {
                return false;
            }

            if (content == null || content.Length < 3)
            {
                return false;
            }


            return true;
        
        }


        public static bool ValidateName(string? name)
        {
            if (name == null) return false;
            if (name.Length < 2) return false;

            return true;
        }

        public static bool ValidateSurname(string? surname)
        {
            if (surname == null) return false;
            if (surname.Length < 2) return false;

            return true;
        }

        public static bool ValidatePassword(string pwd)
        {
            if (
                pwd.Length >= 8 && Char.IsUpper(pwd[0]) && Utils.ContainsDigit(pwd)
               )
            {
                return true;
            }


            return false ;
        }
    }
}
