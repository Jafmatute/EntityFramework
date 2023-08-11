using System;
using System.Data.Entity;
using System.Linq;

namespace Queries.Linq
{
    public class LinqExtensionMethodAdditional
    {
        private static PlutoContext Ctx { get; set; } = new PlutoContext();

        public static void Partitioning()
        {
            var courses = Ctx.Courses.OrderBy(c => c.Name).Skip(5).Take(5);

            foreach (var course in courses)
            {
                Console.WriteLine(@"Course: {0}", course.Name);
            }
        }

        public static void ElementsOperators()
        {
            var course = Ctx.Courses
                .OrderBy(c => c.Level).FirstOrDefault(c=> c.FullPrice>100);
        }
        
        public static void ElementsOperatorsSingle()
        {
            var course = Ctx.Courses.Single(c => c.Id == 1); //Exception
            var cours2 = Ctx.Courses.SingleOrDefault(c => c.Id == 1); // course2 =0 return null

            Console.WriteLine(course.Name);
        }
        
        public static void Quantifying()
        {
            var allAbove100Dollars = Ctx.Courses.All(c => c.FullPrice > 100);

            var courseAny = Ctx.Courses.Any(c => c.Level == 1);

            Console.WriteLine(@"> 100 Dollars: {0} -- Level: {1}", allAbove100Dollars, courseAny);
        }
        
        public static void Aggregating()
        {
            var count = Ctx.Courses.Count();
            
            var countLevel = Ctx.Courses.Where(c=> c.Level==1).Count();

            var courseMaxPrince = Ctx.Courses.Max(c => c.FullPrice);
            
            var courseMinPrince = Ctx.Courses.Min(c => c.FullPrice);
            
            var courseAverage = Ctx.Courses.Average(c => c.FullPrice);

            Console.WriteLine($@"Count: {count} - MaxPrince: {1}", count, courseMaxPrince);
        }
    }
}