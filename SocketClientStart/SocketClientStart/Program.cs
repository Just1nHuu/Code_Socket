using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SocketClientStart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket client = null;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = null;
            try
            {
                Console.WriteLine("Nhap IP server");
                string strIPAddress = Console.ReadLine();

                Console.WriteLine("Nhap Port server");
                string strPort = Console.ReadLine();
                int nPort = 0;

                //Check IPaddrerss, Port is proper
                if (!IPAddress.TryParse(strIPAddress, out ipaddr))
                {
                    Console.WriteLine("Invalid server IP supplied");
                    return;
                }
                
                if (!IPAddress.TryParse(strPort.Trim(), out ipaddr))
                {
                    Console.WriteLine("Invalid server Port supplied");
                    return;
                }

                if (nPort <= 0 || nPort > 65535)
                {
                    Console.WriteLine("Port number must be been 0 and 65535");
                    return;
                }
                Console.WriteLine(string.Format("IPAdress: {0} - Port: {1}"), ipaddr.ToString(), nPort.ToString());

                client.Connect(ipaddr, nPort);

                Console.ReadKey();
            }
            catch
            {
            }
        }
    }
}
