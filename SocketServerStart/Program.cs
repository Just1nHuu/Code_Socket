using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketServerStart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = IPAddress.Any;

            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            listenerSocket.Bind(ipep);

            listenerSocket.Listen(5);

            Console.WriteLine("About to accept incoming connected.");

            Socket client = listenerSocket.Accept();

            Console.WriteLine("client connected." + client.ToString() + "-IP End Point: " + client.RemoteEndPoint.ToString());

            byte[] buff = new byte[128];

            int numberOfReceivedBytes = 0;

            Console.WriteLine("Data sent by client is :");

            while (true)
            {
                numberOfReceivedBytes = client.Receive(buff);

                string receivedText = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);

                Console.WriteLine(receivedText);

                client.Send(buff);

                if(receivedText == "x")
                {
                    break;
                }

                Array.Clear(buff,0, numberOfReceivedBytes);

                numberOfReceivedBytes = 0;
            }
        }
    }
}
