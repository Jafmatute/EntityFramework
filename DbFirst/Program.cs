using System;
using DbFirst.Helpers;

namespace DbFirst
{
    class Program
    {
        public static void Main(string[] args)
        {
            CallProcedure();
        }

        private static void CallLevelEnum()
        {
            var course = new Course();
            course.Level = Level.Beginner; //1
        }

        
        private static void CallProcedure()
        {
            var dbContext = new PlutoDbContext();
            var courses = dbContext.GetCourses();

            foreach (var course in courses)
            {
                Console.WriteLine($"los cursos registrados son: {course.Title}");
            }

            Console.ReadKey();

        }
    }
}