using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_Doan_So
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", 9050);
            //b2 trao doi du lieu
            Console.WriteLine("\t\t\t\t-----TRO CHOI DOAN SO-----");
            Console.WriteLine("Hay doan so nguyen vua sinh ra: ");
            string kq, flag, show;

            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            do
            {
                Console.Write("Nhap so: ");
                string so = Console.ReadLine();
                byte[] data1 = Encoding.ASCII.GetBytes(so);
                client.Send(data1, data1.Length);
                byte[] data = new byte[10];
                data = client.Receive(ref server);
                kq = Encoding.ASCII.GetString(data);
                Console.WriteLine(kq);

                byte[] data2 = new byte[10];
                data2 = client.Receive(ref server);
                flag = Encoding.ASCII.GetString(data2);
                if (int.Parse(flag) == 1)
                {
                    byte[] data3 = new byte[10];
                    data3 = client.Receive(ref server);
                    show = Encoding.ASCII.GetString(data3);
                    Console.WriteLine(show);
                    break;
                }
            } while (kq != "Bang Nhau" && int.Parse(flag) != 1);
            Console.ReadLine();
        }
    }
}
