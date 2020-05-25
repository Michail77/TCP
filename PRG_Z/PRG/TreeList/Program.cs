using System;

namespace TreeList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GenTreeList<int> list = new GenTreeList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(3);
            list.Add(8);
            list.Add(7);
            Console.WriteLine(list.ToString() + "počet:" + list.Count);
            list.Remove(5);
            Console.WriteLine(list.ToString() + "počet:" + list.Count);
            list.Remove(4);
            Console.WriteLine(list.ToString() + "počet:" + list.Count);
            Console.WriteLine(list.Contains(7));
            Console.WriteLine(list.Contains(9));

            GenTreeList<int> tree = new GenTreeList<int>();
            tree.TransformToTree();
            tree.Add(8);
            tree.Add(6);
            tree.Add(7);
            tree.Add(9);
            tree.Add(11);
            tree.Add(10);
            Console.WriteLine(tree.ToString() + "počet:" + tree.Count);

            Console.ReadKey();
        }
    }
}
