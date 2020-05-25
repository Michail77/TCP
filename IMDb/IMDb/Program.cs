using IMDb.Model;
using System;

namespace IMDb
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            Console.WriteLine("Výpis herců");
            foreach (Herec h in db.Herci)
            {
                Console.WriteLine("Jmeno: " + h.Jmeno + "Prijmeni: " + h.Prijmeni);

            }
            Console.WriteLine();
        }
    }
}
