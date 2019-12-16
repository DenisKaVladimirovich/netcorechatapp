using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatAppClient
{
    class Program
    {
        static TcpClient client = new TcpClient("localhost", 5230);
        static Thread thread;
        static bool canwork = false;
        static void Main(string[] args)
        {
            thread = new Thread(Job);
            thread.Start();
            canwork = true;
            while (canwork)
            {
                if (client.Client.Connected)
                {
                    if (client.Available != 0)
                    {
                        byte[] buffer = new byte[client.Available];
                        client.GetStream().Read(buffer, 0, buffer.Length);
                        Console.WriteLine(Encoding.UTF8.GetString(buffer));
                    }
                }

            }
            Console.WriteLine(thread?.IsAlive);
            Console.ReadLine();
        }

        static void Job()
        {
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg == "/disconect")
                {
                    canwork = false;

                    
                    client.Close();
                    Console.WriteLine(thread.IsAlive);
                    thread
                    break;
                    
                }
                else
                {
                    client.GetStream().Write(Encoding.UTF8.GetBytes(msg), 0, Encoding.UTF8.GetBytes(msg).Length);
                }
                
            }
            

        }
    }
}
