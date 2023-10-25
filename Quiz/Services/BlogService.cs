using System;
using Quiz.Database;
using Quiz.Models;
using Quiz.Helpers;
using Quiz.Exceptions;

namespace Quiz.Services
{
    internal static class BlogService
    {
        public static List<Blog> GetBlogsByValue(string value) => BlogDatabase.QueryByParamValue(value);
        public static List<Blog> GetAllBlogs() => BlogDatabase.GetBlogs();

        public static void AddBlog(Blog blog) {

           
            
                BlogDatabase.AddNewBlog(blog);
            

        }

        public static void RemoveBlog(int id)
        {
                BlogDatabase.RemoveBlog(id);
        }

        public static Blog GetBlogById(int id)
        {

            foreach (Blog b in BlogDatabase.GetBlogs())
            {
                if (b.Id == id) return b;
            }

            throw new NoValidBlogException();

        }

        
        
    }
}
