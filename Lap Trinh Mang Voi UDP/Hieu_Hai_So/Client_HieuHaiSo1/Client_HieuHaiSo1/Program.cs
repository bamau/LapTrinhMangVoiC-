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
            int dem = 0;
            Console.Write("Ban Muon Tinh Hieu May So: ");
            string so = Console.ReadLine();
            string dl = so + "_0";
            byte[] data = Encoding.ASCII.GetBytes(dl);
            client.Send(data, data.Length);
            int n = int.Parse(so);

            Console.WriteLine("Nhap " + n + " so nguyen:");
            while (dem < n)
            {
                dem++;
                Console.Write("So " + dem + " :");
                string so1 = Console.ReadLine();
                string dl1 = so1 + "_" + dem;
                byte[] data1 = Encoding.ASCII.GetBytes(dl1);
                client.Send(data1, data1.Length);
            }
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data2 = new byte[10];
            data2 = client.Receive(ref server);
            string kq = Encoding.ASCII.GetString(data2);
            Console.Write("Hieu hai so vua nhap la: {0}", kq);
            Console.ReadLine();
            //b3 Dong ket noi
            client.Close();
        }
    }
}
