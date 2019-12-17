using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Core.Model
{
    public class Abonent
    {
        public UserModel User { get; private set; }
        private TcpClient tcpClient;
        Task work;
        BackgroundWorker worker;
        CancellationTokenSource cts = new CancellationTokenSource();

        public Abonent(TcpClient client)
        {
            this.tcpClient = client;
            work = new Task(Start);
            work.Start();
        }


        public void SetUser(UserModel user)
        {
            this.User = user;
        }


        private void Start()
        {
            //Console.WriteLine($"Hello. I was created. User is {User.ToString()}");
            byte[] msg = Encoding.UTF8.GetBytes("You're connected");
            this.tcpClient.GetStream().Write(msg, 0, msg.Length);
            
            while (!cts.IsCancellationRequested)
            {
                if (tcpClient.Available != 0)
                {
                    byte[] buffer = new byte[tcpClient.Available];
                    tcpClient.GetStream().Read(buffer, 0, buffer.Length);
                    string smsg = Encoding.UTF8.GetString(buffer);
                    if (smsg == "/disconect")
                    {
                        tcpClient.Client.Close();
                        cts.Cancel();

                    }
                    Console.WriteLine(smsg);
                }

            }
        }






    }
}
