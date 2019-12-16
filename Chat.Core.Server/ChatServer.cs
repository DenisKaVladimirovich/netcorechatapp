using Chat.Core.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Chat.Core.Server
{
    public class ChatServer
    {
        public static List<Abonent> abonents;


        private TcpListener listener;
        private int port;
        private Thread serverThread;
        private int _threadSleepTime;

        /// <summary>
        /// Создание экземпляра сервера. Запуск происходит при вызове конструктора
        /// </summary>
        /// <param name="port">Порт на котором будет висеть сервер</param>
        /// <param name="threadSleepTime">Промежуток в милисекундах для сна потока сервера</param>
        public ChatServer(int port, int threadSleepTime)
        {
            this.port = port;
            abonents = new List<Abonent>();
            _threadSleepTime = threadSleepTime;
            serverThread = new Thread(Run);
            serverThread.Start();
        }


        private void Run()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("0.0.0.0"), port);
                listener.Start();

                Console.WriteLine($"Start listening on {IPAddress.Parse(((IPEndPoint)listener.LocalEndpoint).Address.ToString())}");
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    if (client != null)
                    {
                        Console.WriteLine("new client");
                        abonents.Add(new Abonent(client));
                    }
                    Thread.Sleep(_threadSleepTime);
                }

            }
            catch (Exception e)
            {
               
                Console.WriteLine(e.Message);
            }
        }



        public void Disconnect() {

        }
    }
}
