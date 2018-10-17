using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_TongBaSo
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 9050);

            //b2 Trao doi du lieu
            Console.WriteLine("Ban muon tinh bao nhieu so: ");
            string soluong = Console.ReadLine();
            byte[] data1 = Encoding.ASCII.GetBytes(soluong);
            client.Send(data1, data1.Length);
            int n = int.Parse(soluong);
            Console.WriteLine("Nhap " + n + " so nguyen");
            int dem = 0;
            do
            {
                dem++;
                Console.Write("So thu " + dem + ": ");
                string so = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(so);
                client.Send(data, data.Length);
            } while (dem < n);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data2 = new byte[10];
            data2 = client.Receive(ref server);
            int kq = BitConverter.ToInt16(data2, 0);
            // string kq = Encoding.ASCII.GetString(data);
            Console.WriteLine("Tong ba so vua nhap la: {0}", kq);
            Console.ReadLine();
            //b3 Dong ket noi
            client.Close();
        }
    }
}
