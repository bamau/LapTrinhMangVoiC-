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
        static void Main(string[] args)
        {
            //b1 Mo port
            UdpClient client = new UdpClient();
            //b2 Trao doi du lieu
            Console.WriteLine("Nhap 1 so nguyen");
            string so = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(so);
            client.Send(data, data.Length, "127.0.0.1", 9050);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data2 = new byte[10];
            data2 = client.Receive(ref server);
            string kq = Encoding.ASCII.GetString(data2);
            Console.WriteLine(kq);
            Console.ReadLine();
            //b3 Dong ket noi
            client.Close();
        }
    }
}
