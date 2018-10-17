using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerGiaiBacHai
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1: Mo port
            UdpClient server = new UdpClient(9050);
            //b2: Trao doi du lieu
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            int a = 0, b = 0, c = 0;
            byte[] data1 = new byte[10];
            data1 = server.Receive(ref client);
            string so1 = Encoding.ASCII.GetString(data1, 0, data1.Length);
            string[] m1 = so1.Split('_');
            if (m1[1] == "1")
            {
                a = int.Parse(m1[0]);
            }
            if (m1[1] == "2")
            {
                b = int.Parse(m1[0]);
            }
            if (m1[1] == "3")
            {
                c = int.Parse(m1[0]);
            }
            byte[] data2 = new byte[10];
            data2 = server.Receive(ref client);
            string so2 = Encoding.ASCII.GetString(data2, 0, data2.Length);
            string[] m2 = so2.Split('_');
            if (m2[1] == "1")
            {
                a = int.Parse(m2[0]);
            }
            if (m2[1] == "2")
            {
                b = int.Parse(m2[0]);
            }
            if (m2[1] == "3")
            {
                c = int.Parse(m2[0]);
            }
            byte[] data3 = new byte[10];
            data3 = server.Receive(ref client);
            string so3 = Encoding.ASCII.GetString(data3, 0, data3.Length);
            string[] m3 = so3.Split('_');
            if (m3[1] == "1")
            {
                a = int.Parse(m3[0]);
            }
            if (m3[1] == "2")
            {
                b = int.Parse(m3[0]);
            }
            if (m3[1] == "3")
            {
                c = int.Parse(m3[0]);
            }
            string kq;
            int flag;
            if (a == 0)
            {
                if (a == 0 && b == 0)
                {
                    flag = 0;
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(flag.ToString());
                    server.Send(data, data.Length, client);
                    kq = "Phuong trinh vo nghiem";
                    byte[] data4 = new byte[10];
                    data4 = Encoding.ASCII.GetBytes(kq);
                    server.Send(data4, data4.Length, client);

                }
                if (a == 0 && c == 0)
                {
                    flag = 1;
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(flag.ToString());
                    server.Send(data, data.Length, client);
                    int x = 0;
                    byte[] data4 = new byte[10];
                    data4 = Encoding.ASCII.GetBytes(x.ToString());
                    server.Send(data4, data4.Length, client);

                }
                if (a == 0 && b != 0 && c != 0)
                {
                    flag = 1;
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(flag.ToString());
                    server.Send(data, data.Length, client);
                    double x = -c / b;
                    byte[] data4 = new byte[10];
                    data4 = Encoding.ASCII.GetBytes(x.ToString());
                    server.Send(data4, data4.Length, client);
                }


            }
            if (a != 0)
            {
                double denta = b * b - 4 * a * c;
                if (denta < 0)
                {
                    flag = 0;
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(flag.ToString());
                    server.Send(data, data.Length, client);
                    kq = "Phuong trinh vo nghiem!";
                    byte[] data4 = new byte[10];
                    data4 = Encoding.ASCII.GetBytes(kq.ToString());
                    server.Send(data4, data4.Length, client);
                }
                if (denta == 0)
                {
                    flag = 1;
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(flag.ToString());
                    server.Send(data, data.Length, client);
                    double x = -b / (2 * a);
                    byte[] data4 = new byte[10];
                    data4 = Encoding.ASCII.GetBytes(x.ToString());
                    server.Send(data4, data4.Length, client);
                }
                if (denta > 0)
                {
                    flag = 2;
                    byte[] data = new byte[10];
                    data = Encoding.ASCII.GetBytes(flag.ToString());
                    server.Send(data, data.Length, client);
                    double x1 = (-b + Math.Sqrt(denta)) / 2 * a;
                    byte[] data4 = new byte[10];
                    data4 = Encoding.ASCII.GetBytes(x1.ToString());
                    server.Send(data4, data4.Length, client);
                    double x2 = (-b - Math.Sqrt(denta)) / 2 * a;
                    byte[] data5 = new byte[10];
                    data5 = Encoding.ASCII.GetBytes(x2.ToString());
                    server.Send(data5, data5.Length, client);
                }
                //b3 Dong ket noi
                server.Close();
            }
        }
    }
}
