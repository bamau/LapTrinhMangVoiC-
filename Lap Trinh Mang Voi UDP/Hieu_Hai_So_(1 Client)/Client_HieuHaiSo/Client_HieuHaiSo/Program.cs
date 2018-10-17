using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_HieuHaiSo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 9050);

            Console.WriteLine("Nhap hai nguyen: ");
            Console.Write("So 1: ");
            string so1 = Console.ReadLine();
            so1 = so1 + "_0";
            byte[] data1 = Encoding.ASCII.GetBytes(so1);
            client.Send(data1, data1.Length);

            Console.Write("So 2: ");
            string so2 = Console.ReadLine();
            so2 = so2 + "_1";
            byte[] data2 = Encoding.ASCII.GetBytes(so2);
            client.Send(data2, data2.Length);

            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10];
            data = client.Receive(ref server);
            string kq = Encoding.ASCII.GetString(data);
            Console.Write("Hieu hai so vua nhap la: {0}", kq);
            Console.ReadLine();

            client.Close();
        }
    }
}
