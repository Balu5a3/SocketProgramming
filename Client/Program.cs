using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static Socket sck;

        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse("192.168.0.9"), 1234);
            try {
                sck.Connect(localAddress);
                Console.WriteLine("server connected.");
            }
            catch (Exception ex){
                Console.WriteLine("server not connected.");
                Main(args);
            }
            Console.WriteLine("enter text : ");
            string message = Console.ReadLine();
            Byte[] data = Encoding.ASCII.GetBytes(message);

            sck.Send(data);
            Console.ReadLine();
            sck.Close();

        }
    }
}
