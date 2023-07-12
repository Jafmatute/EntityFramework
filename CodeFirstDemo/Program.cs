using System;
using System.Data.Entity;

namespace CodeFirstDemo
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }

    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
