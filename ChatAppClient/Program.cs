using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ChatAppClient
{
    class Program
    {
        static TcpClient client = new TcpClient("localhost", 5230);
        static Task thread;
        static CancellationTokenSource cts = new CancellationTokenSource();
        static void Main(string[] args)
        {
            thread = new Task(Job);
            thread.Start();
            while (!cts.IsCancellationRequested)
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
            Thread.Sleep(50);
            Console.WriteLine(thread?.Status.ToString());
            Console.WriteLine(thread?.IsCanceled);
            Console.ReadLine();
        }

        static void Job()
        {
            while (true)
            {
                string msg = Console.ReadLine();
                if (msg == "/disconect")
                {
                    client.GetStream().Write(Encoding.UTF8.GetBytes(msg), 0, Encoding.UTF8.GetBytes(msg).Length);
                    cts.Cancel();
                    Console.WriteLine(thread.IsCanceled);
                    Console.WriteLine(thread.IsCompleted);
                    Console.WriteLine(thread.IsFaulted);
                    Console.WriteLine(thread.IsCompletedSuccessfully);

                    thread = null;

                }
                else
                {
                    client.GetStream().Write(Encoding.UTF8.GetBytes(msg), 0, Encoding.UTF8.GetBytes(msg).Length);
                }
                
            }
            

        }
    }
}
