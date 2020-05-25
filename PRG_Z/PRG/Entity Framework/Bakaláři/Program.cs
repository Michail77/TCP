using ConsoleApp2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            Console.WriteLine("Výpis studentů");
            foreach (Student student in applicationDbContext.Students)
                Console.WriteLine("Id:" + student.Id + " Jméno:" + student.Jmeno + " Přijmení:" + student.Prijmeni);
            Console.WriteLine();

            Console.WriteLine("Výpis studentů");
            foreach (Student student in applicationDbContext.Students.OrderBy(student => student.Jmeno).ToList())
                Console.WriteLine("Id:" + student.Id + " Jméno:" + student.Jmeno + " Přijmení:" + student.Prijmeni);
            Console.WriteLine();

            Console.WriteLine("Výpis tříd");
            foreach (Classroom classroom in applicationDbContext.Classrooms)
                Console.WriteLine("Id:" + classroom.Id + " Název:" + classroom.Nazev);
            Console.WriteLine();

            Console.WriteLine("Přidání studenta");
            Console.Write("Jméno:");
            string jmeno = Console.ReadLine();
            Console.Write("Příjmení:");
            string prijmeni = Console.ReadLine();
            applicationDbContext.Students.Add(new Student { Jmeno = jmeno, Prijmeni = prijmeni, ClassroomId = 1});
            applicationDbContext.SaveChanges();
            Console.WriteLine();

            Console.WriteLine("Aktualizovaný výpis");
            foreach (Student student in applicationDbContext.Students)
                Console.WriteLine("Id:" + student.Id + " Jméno:" + student.Jmeno + " Přijmení:" + student.Prijmeni);
            Console.WriteLine();

            Console.WriteLine("Výpis studentů podle tříd");
            foreach (Classroom classroom1 in applicationDbContext.Classrooms)
            {
                Console.WriteLine("Id:" + classroom1.Id + " Název:" + classroom1.Nazev);
                if (classroom1.Students != null)
                    foreach (Student student in classroom1.Students)
                        Console.WriteLine("Id:" + student.Id + " Jméno:" + student.Jmeno + " Přijmení:" + student.Prijmeni);
                else
                    Console.WriteLine("Žádní studenti ve třídě");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
