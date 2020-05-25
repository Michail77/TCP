using CSFD.Model;
using System;
using System.Linq;

namespace CSFD
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            Console.WriteLine("Výpis herců");
            foreach (Actor actor in db.Actors)
                Console.WriteLine("Id:" + actor.Id + " Jméno:" + actor.FirstName + " Přijmení:" + actor.LastName);
            Console.WriteLine();

            Console.WriteLine("Výpis filmů");
            foreach (Movie movie in db.Movies)
                Console.WriteLine("Id:" + movie.Id + " Jméno:" + movie.Name);
            Console.WriteLine();

            Console.WriteLine("Výpis herců podle příjmení");
            foreach (Actor actor in db.Actors.OrderBy(actor => actor.LastName).ToList())
                Console.WriteLine("Id:" + actor.Id + " Jméno:" + actor.FirstName + " Přijmení:" + actor.LastName);
            Console.WriteLine();

            Console.WriteLine("Výpis filmů podle jména");
            foreach (Movie movie in db.Movies.OrderBy(movie => movie.Name).ToList())
                Console.WriteLine("Id:" + movie.Id + " Jméno:" + movie.Name);
            Console.WriteLine();

           /* Console.WriteLine("Výpis herců podle filmu");
            foreach (Movie movie in db.Movies.OrderBy(movie => movie.Name).ToList())
            {
                Console.WriteLine("Id:" + movie.Id + " Jméno:" + movie.Name);
                if (movie.Actors == null)
                    Console.WriteLine("Žádní herci");
                else
                    foreach (Actor actor in movie.Actors.OrderBy(actor => actor.LastName).ToList())
                        Console.WriteLine("Id:" + actor.Id + " Jméno:" + actor.FirstName + " Přijmení:" + actor.LastName);
            }*/
            bool a = true;
            while (a)
            {
                Console.WriteLine("Přidávání");
                Console.WriteLine("1 pro přidání herce, 2 filmu, 3 herce do filmu, 4 opuštění");
                Console.Write("Výběr:");
                switch (Console.ReadLine()[0])
                {
                    case '1':
                        Console.WriteLine("Přidání herce");
                        Console.Write("Jméno:");
                        string FirstName = Console.ReadLine();
                        Console.Write("Příjmení:");
                        string LastName = Console.ReadLine();
                        db.Actors.Add(new Actor { FirstName = FirstName, LastName = LastName });
                        db.SaveChanges();
                        break;
                    default:
                        a = false;
                        break;
                }
            }
            Console.WriteLine("Výpis herců podle příjmení");
            foreach (Actor actor in db.Actors.OrderBy(actor => actor.LastName).ToList())
                Console.WriteLine("Id:" + actor.Id + " Jméno:" + actor.FirstName + " Přijmení:" + actor.LastName);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
