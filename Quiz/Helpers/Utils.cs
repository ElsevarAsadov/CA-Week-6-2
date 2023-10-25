using System;

namespace Quiz.Helpers
{
    internal class Utils
    {


        public static string SanitazeStringForValidation(string str) => str.Trim().ToLower();

        public static bool ContainsDigit(string str)
        {
            bool check = false;
            foreach(char c in str) {

                if (Char.IsDigit(c))
                {
                    check = true;
                    break;
                };
                
            }

            return check;
        }
    }
}
