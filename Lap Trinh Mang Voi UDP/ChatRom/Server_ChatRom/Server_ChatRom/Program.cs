using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_ChatRom
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);

            List<IPEndPoint> ListClient = new List<IPEndPoint>();
            while (true)
            {
                int i, count=0;
                IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = new byte[10];
                data = server.Receive(ref client);
                for (i = 0; i < ListClient.Count; i++)
                {
                    server.Send(data, data.Length, ListClient.ElementAt(i));
                }
                if (i==ListClient.Count)
                {
                    ListClient.Add(client);
                    count++;
                    for (int j = 0; j < ListClient.Count; j++)
                    {
                        server.Send(data, data.Length, ListClient.ElementAt(j));
                    }
                    break;
                }
            }
        }
    }
}
