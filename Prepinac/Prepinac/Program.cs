using System;
using System.Threading;

namespace Prepinac
{
    class Program
    {
        public delegate void ThreadStart();
        static void Main(string[] args)
        {
            Prepinac p = new Prepinac();
            Thread vlakno1 = new Thread(p.Vypisuj0);
            Thread vlakno2 = new Thread(p.Vypisuj1);
            vlakno1.Start();
            vlakno2.Start();
            vlakno1.Join();
            vlakno2.Join();
            Console.WriteLine("Hotovo");
        }
    }
}
