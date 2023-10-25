using Quiz.Database;
using Quiz.Enums;
using Quiz.Exceptions;
using Quiz.Helpers;
using Quiz.Models;
using Quiz.Services;


namespace Quiz.ConsoleApp
{
    internal class App
    {
        private static EMenuType MENU_STATE = EMenuType.Home;

        private static Dictionary<EMenuType, Action> MENUS = new Dictionary<EMenuType, Action>()
        {

            { EMenuType.Home, App.MenuHome },
            { EMenuType.Register, App.MenuRegister},
            { EMenuType.Login, App.MenuLogin},
            { EMenuType.AuthHome, App.MenuAuthHome},
            { EMenuType.GetId, App.MenuGetId},
            { EMenuType.RemoveBlog, App.MenuRemoveBlog },
            { EMenuType.AddBlog, App.MenuAddBlog },
            { EMenuType.GetAll, App.MenuGetAll },
            { EMenuType.GetValue, App.MenuGetValue },
            {EMenuType.Exit, App.Exit },
            
        
        
        };

        public void Start()
        {
            while (MENU_STATE != EMenuType.Exit)
            {
                _showWindow(App.MENU_STATE);
            }
        }

        private void _showWindow(EMenuType type)
        {
            App.MENUS[type]();
            

            
            
            //App.MENUS[EMenuType.Exit]();
        }

        private static void _mapMenu(string i) {

            switch (i.Trim().ToLower())
            {
                case "1":
                    App.MENU_STATE = EMenuType.Register;
                    break;

                case "2":
                    App.MENU_STATE = EMenuType.Login;
                    break;


                case "0":
                    App.MENU_STATE = EMenuType.Exit;
                    break;

                default:
                    UIManager.Message("alert", "Invalid Menu Type");
                    App.MENU_STATE = EMenuType.Exit;
                    break;
            }
           

        }


        public static void MenuHome()
        {
            UIManager.Message("section", "welcome");


            UIManager.Message("item", "Register");
            UIManager.Message("item", "Login");

            string input = "";

            UIManager.GetInput(ref input);

            App._mapMenu(input);



        }


        public static void MenuRegister()
        {
            UIManager.Message("section", "register");

            string name = "";
            string surname = "";
            string password = "";


            bool first = false;
            do
            {
                if (first) UIManager.Message("alert", "Invalid Validation Inputs Try Again...");
                first = true;

                UIManager.Message("dialogue", "Enter Name");
                UIManager.GetInput(ref name);

                UIManager.Message("dialogue", "Enter Surname");
                UIManager.GetInput(ref surname);

                UIManager.Message("dialogue", "Enter Password");
                UIManager.GetInput(ref password);
            }
            while (!UserService.Register(name, surname, password));


            UIManager.Message("success", "Registered....");

            App.MENU_STATE = EMenuType.Home;


        }

        public static void MenuLogin()
        {
            string username = "";
            string password = "";

            UIManager.Message("dialogue", "Enter Username");
            UIManager.GetInput(ref username);

            UIManager.Message("dialogue", "Enter Password");
            UIManager.GetInput(ref password);

            User user = BlogDatabase.Login(username, password);

            if(user != null)
            {
                UIManager.Message("success", $"Hello - {user.Name}");
                App.MENU_STATE = EMenuType.AuthHome;
            }
            else
            {
                UIManager.Message("alert", "Invalid User");
                App.MENU_STATE = EMenuType.Login;
            }



        }

        public static void MenuAuthHome()
        {
            string input = "";

            UIManager.Message("section", "HOME");

            UIManager.Message("item", "AddBlog");

            UIManager.Message("item", "RemoveBlog");

            UIManager.Message("item", "GetBlogById");

            UIManager.Message("item", "GetBlogByValue");

            UIManager.Message("item", "GetAllBlogs");



            UIManager.GetInput(ref input);

            switch (input.Trim().ToLower())
            {
                case "1":
                    App.MENU_STATE = EMenuType.AddBlog;
                    break;

                case "2":
                    App.MENU_STATE = EMenuType.RemoveBlog;
                    break;

                case "3":
                    App.MENU_STATE = EMenuType.GetId;
                    break;

                case "4":
                    App.MENU_STATE = EMenuType.GetValue;
                    break;

                case "5":
                    App.MENU_STATE = EMenuType.GetAll;
                    break;


            }






        }


        public static void MenuGetId()
        {
            UIManager.GetInput(out int input);
            try
            {
               
                
                Console.WriteLine(BlogService.GetBlogById(input));

            
            }

            catch (NoValidBlogException)
            {
                UIManager.Message("alert", "Invalid Id");
               
            }

            App.MENU_STATE = EMenuType.AuthHome;


        }

        public static void MenuRemoveBlog()
        {
            UIManager.GetInput(out int input);

            try
            {
                UIManager.Message("dialogue", "Removed");
                BlogService.RemoveBlog(input);


            }

            catch (NoValidBlogException)
            {
                UIManager.Message("alert", "Invalid Id");
               
            }

            App.MENU_STATE = EMenuType.AuthHome;
        }

        public static void MenuAddBlog()
        {
            UIManager.Message("section", "Add Blog");

            string title = "";
            string content = "";


            do
            {
                UIManager.Message("dialogue", "Enter Blog Title");
                UIManager.GetInput(ref title);

                UIManager.Message("dialogue", "Enter Blog Content");
                UIManager.GetInput(ref content);
            }
            while (!Validations.ValidateBlog(title, content));

 

            Blog blog = new Blog(title, content);

            try
            {
                BlogService.AddBlog(blog);
            }
            catch(InvalidBlogDataException)
            {
                UIManager.Message("Alert", "Invalid Blog");
            }


            App.MENU_STATE = EMenuType.AuthHome;





        }


        public static void MenuGetAll()
        {
            foreach(Blog b in BlogService.GetAllBlogs())
            {
                Console.WriteLine(b);
            }

            App.MENU_STATE = EMenuType.AuthHome;
        }

        public static void MenuGetValue()
        {
            string value = "";
            UIManager.GetInput(ref value);

            foreach(Blog b in BlogService.GetBlogsByValue(value))
            {
                Console.WriteLine(b);
            };

            App.MENU_STATE = EMenuType.AuthHome;
        }

        public static void Exit()
        {
            App.MENU_STATE = EMenuType.Exit;
        }


    }
}
