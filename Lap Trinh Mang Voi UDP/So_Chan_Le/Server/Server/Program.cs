using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1: Mo port
            UdpClient server = new UdpClient(9050);
            //b2: Trao doi du lieu
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10];
            data = server.Receive(ref client);
            string so = Encoding.ASCII.GetString(data, 0, data.Length);
            int a = int.Parse(so);
            string kq;
            if (a % 2 == 0)
            {
                kq = "So chan";
            }
            else kq = "So le";
            data = Encoding.ASCII.GetBytes(kq);
            server.Send(data, data.Length, client);
            //b3 Dong ket noi
            server.Close();
        }
    }
}
