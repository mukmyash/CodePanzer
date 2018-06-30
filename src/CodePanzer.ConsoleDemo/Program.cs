using System;
using System.Threading;

namespace CodePanzer.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write("0");
                Console.WriteLine("0");
            }

            Console.ReadLine();

            Console.SetCursorPosition(0, Console.CursorTop - 11);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write("1");
                Console.WriteLine("1");
            }

            Console.ReadLine();
        }
    }
}
