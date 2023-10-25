using Quiz.Database;
using Quiz.Enums;
using System;

namespace Quiz.Models
{
    internal class Blog
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public EBlogType Type { get; set; }

        public Blog(string title, string content)
        {
            Id = _id;
            Title = title;
            Content = content;

            Blog._id++;
        }

        public override string ToString()
        {
            return $"{Id} - {Title} - {Content}";
        }


    }
}
