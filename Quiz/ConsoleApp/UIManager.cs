using System;


namespace Quiz.ConsoleApp
{
    internal static class UIManager
    {

        public static void Message(string type, string msg)
        {
            switch(type.Trim().ToLower()) {

                case "casual":
                    Console.WriteLine(msg);
                    break;
                case "section":
                    Console.Write($"\n\n\n============={msg.ToUpper()}=============\n\n\n");
                    break;
                case "item":
                    Console.WriteLine($"[*] - {msg} ");
                    break;
                case "alert":
                    Console.WriteLine($"!!! - {msg} - !!! ");
                    break;
                case "success":
                    Console.Write($"\n\n+++ - {msg} - +++\n\n ");
                    break;
                case "dialogue":
                    Console.WriteLine($"\\*/ {msg} ");
                    break;

            }
        }

        public static void GetInput(out int input)
        {

            int.TryParse(Console.ReadLine(), out input);
        }

        public static void GetInput(ref string input)
        {
            input = Console.ReadLine();
        }
    }
}
