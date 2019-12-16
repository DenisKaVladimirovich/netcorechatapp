using Chat.Core.Server;
using System;
using System.Threading;

namespace ChatConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatServer server = new ChatServer(5230, 10);


            Console.WriteLine("Hello World!");

            while (true)
            {
                Console.WriteLine(Console.ReadLine());
                Thread.Sleep(20);
            }
        }
    }
}
