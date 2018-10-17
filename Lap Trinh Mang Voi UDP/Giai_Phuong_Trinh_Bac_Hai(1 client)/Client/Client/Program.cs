using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientGiaiBacHai
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1 Mo port
            UdpClient client = new UdpClient("127.0.0.1", 9050);
            //b2 Trao doi du lieu
            Console.WriteLine("Nhap vao 3 so nguyen");
            string so1 = Console.ReadLine();
            so1 = so1 + "_1";
            byte[] data1 = Encoding.ASCII.GetBytes(so1);
            client.Send(data1, data1.Length);

            string so2 = Console.ReadLine();
            so2 = so2 + "_2";
            byte[] data2 = Encoding.ASCII.GetBytes(so2);
            client.Send(data2, data2.Length);

            string so3 = Console.ReadLine();
            so3 = so3 + "_3";
            byte[] data3 = Encoding.ASCII.GetBytes(so3);
            client.Send(data3, data3.Length);

            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10];
            data = client.Receive(ref server);
            string flag = Encoding.ASCII.GetString(data);
            if (flag == "0")
            {
                byte[] data5 = new byte[10];
                data5 = client.Receive(ref server);
                string kq = Encoding.ASCII.GetString(data5);
                Console.WriteLine(kq);
            }
            if (flag == "1")
            {
                byte[] data5 = new byte[10];
                data5 = client.Receive(ref server);
                string x = Encoding.ASCII.GetString(data5);
                Console.WriteLine("Phuong trinh co nghiem: x= {0}", x);
            }
            if (flag == "2")
            {
                Console.WriteLine("Phuong trinh co hai nghiem: ");
                byte[] data5 = new byte[10];
                data5 = client.Receive(ref server);
                string x1 = Encoding.ASCII.GetString(data5);
                Console.WriteLine("X1= {0}", x1);

                byte[] data6 = new byte[10];
                data6 = client.Receive(ref server);
                string x2 = Encoding.ASCII.GetString(data6);
                Console.WriteLine("X2= {0}", x2);
            }
            Console.ReadLine();
            //b3 Dong ket noi
            client.Close();
        }
    }
}
