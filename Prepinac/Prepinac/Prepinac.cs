using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Prepinac
{
    class Prepinac
    {
        public delegate void ThreadStart();
        public void Vypisuj0()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("0");
                Thread.Sleep(10);
            }
        }

        public void Vypisuj1()
        {
            for (int i = 0; i <5; i++)
            {
                Console.Write("1");
                Thread.Sleep(10);
            }
        }

        //public void Prepinej()
        //{
        //    Thread vlakno = new Thread(Vypisuj0);
        //    vlakno.Start();
        //    Vypisuj1();
        //}
    }
}
