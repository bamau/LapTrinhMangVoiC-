using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_ChatRom1
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 9050);
            List<IPEndPoint> ListClient = new List<IPEndPoint>();
            Console.WriteLine("CLIENT");
            while(true)
            {
                Console.Write("I: ");
                String StringCharacters = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(StringCharacters);                
                client.Send(data, data.Length);
            }
            

        }
    }
}
