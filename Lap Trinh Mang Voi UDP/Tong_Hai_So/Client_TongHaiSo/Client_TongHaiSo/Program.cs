using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_TongHaiSo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 9050);

            //b2 Trao doi du lieu
            Console.WriteLine("Nhap 2 so nguyen");
            string so1 = Console.ReadLine();
            byte[] data1 = Encoding.ASCII.GetBytes(so1);
            client.Send(data1, data1.Length);

            string so2 = Console.ReadLine();          
            byte[] data2 = Encoding.ASCII.GetBytes(so2);           
            client.Send(data2, data2.Length);

            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10];
            data = client.Receive(ref server);
            int kq = BitConverter.ToInt16(data, 0);
            // string kq = Encoding.ASCII.GetString(data);
            Console.WriteLine("Tong hai so vua nhap la: {0}", kq);           
            Console.ReadLine();
            //b3 Dong ket noi
            client.Close();
        }
    }
}
