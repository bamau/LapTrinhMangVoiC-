using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client1
{
    class Program
    {      
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("127.0.0.1", (9050));
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            int dem = 0;
            Console.WriteLine("Nhap vao ba so nguyen:");
            while (dem < 3)
            {
                dem++;
                Console.Write("So " + dem + ": ");
                string so1 = Console.ReadLine() + "_" + dem;
                byte[] data1 = Encoding.ASCII.GetBytes(so1);
                client.Send(data1, data1.Length);
            }
            Console.Clear();
            byte[] data = new byte[10];
            data = client.Receive(ref server);
            string menu = Encoding.ASCII.GetString(data);
            string[] menucut = menu.Split(',');
            for (int i = 0; i < menucut.Length; i++)
            {
                Console.WriteLine(menucut[i]);
            }
            string so2;
            do
            {
                Console.Write("Nhap lua chon: ");
                so2 = Console.ReadLine();
                byte[] data2 = Encoding.ASCII.GetBytes(so2);
                client.Send(data2, data2.Length);
                if(so2=="1")
                {
                    byte[] data3 = new byte[10];
                    data3 = client.Receive(ref server);
                    string kq = Encoding.ASCII.GetString(data3);
                    Console.WriteLine("Tong ba so vua nhap la: {0}", kq);
                }
                if(so2=="2")
                {
                    while (true)
                    {
                        byte[] data4 = new byte[10];
                        data4 = client.Receive(ref server);
                        string flag = Encoding.ASCII.GetString(data4);
                        if (flag == "0")
                        {
                            byte[] data3 = new byte[10];
                            data3 = client.Receive(ref server);
                            string kq = Encoding.ASCII.GetString(data3);
                            Console.WriteLine("Cac so le la: {0}", kq);
                        }                                         
                        if (flag == "1")
                        {
                            break;
                        }
                    }
                }
                if(so2=="3")
                {
                    return;
                }
            } while (so2 != "3");
            Console.ReadLine();
        }
    }
}
