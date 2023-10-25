using System;
using Quiz.Exceptions;
using Quiz.Helpers;
using Quiz.Models;

namespace Quiz.Database
{
    internal static class BlogDatabase
    {
        private static List<User> _users = new List<User>();

        private static List<Blog> _blogs = new List<Blog>();


        //======================= METHODS =======================

        private static int CheckBlogExists(int id) {
            
            int _ = -1;

            for(int i = 0; i < _blogs.Count; i++) {
                Blog blog = _blogs[i];

                if(blog.Id == id)
                {
                    return i;
                }
            
            }

            return -1;
            
        }

        public static void Register(string name, string surname, string password) {

            User newUser = new User(password, name, surname);

            BlogDatabase._users.Add(newUser);

            //Console.WriteLine(_users[0]);
        }

        public static User Login(string username, string password)
        {
            foreach(User user in BlogDatabase._users)
            {
                if(user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static List<Blog> GetBlogs() => BlogDatabase._blogs;


        public static List<Blog> QueryByParamValue(string value) {

            List<Blog> _ = new List<Blog>();

            foreach (Blog blog in BlogDatabase._blogs) {
                if (
                    new string[]{
                                
                                Utils.SanitazeStringForValidation(blog.Title),
                                Utils.SanitazeStringForValidation(blog.Content)
                     
                                }
                    .Contains(Utils.SanitazeStringForValidation(value))
                    )

                {
                    _.Add(blog);
                }
            
            }

            return _;
        
        }

        public static void AddNewBlog(Blog blog) {
        
            BlogDatabase._blogs.Add(blog);
        }


        public static void RemoveBlog(int id)
        {
            int idx = BlogDatabase.CheckBlogExists(id);

            if(idx != -1)
            {
                BlogDatabase._blogs.RemoveAt(idx);
            }
            else
            {
                throw new NoValidBlogException();
            }
        }

    }
}
