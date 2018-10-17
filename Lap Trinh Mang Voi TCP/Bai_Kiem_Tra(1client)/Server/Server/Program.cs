using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            //b1: mo ket noi
            TcpListener ss = new TcpListener(1234);
            ss.Start();
            Socket client = ss.AcceptSocket();
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            //b2: trao doi du lieu
            String so1 = sr.ReadLine();
            int a = int.Parse(so1);

            String so2 = sr.ReadLine();
            int b = int.Parse(so2);

            String so3 = sr.ReadLine();
            int c = int.Parse(so3);
            string kq;
            int flag;
            if (a == 0)
            {
                if (a == 0 && b == 0)
                {
                    flag = 0;
                    sw.WriteLine(flag.ToString());
                    sw.Flush();
                    kq = "Phuong trinh vo nghiem: ";
                    sw.WriteLine(kq.ToString());
                    sw.Flush();

                }
                if (a == 0 && c == 0)
                {
                    flag = 1;
                    sw.WriteLine(flag.ToString());
                    sw.Flush();
                    int x = 0;
                    sw.WriteLine(x.ToString());
                    sw.Flush();

                }
                if (a == 0 && b != 0 && c != 0)
                {
                    flag = 1;
                    sw.WriteLine(flag.ToString());
                    sw.Flush();
                    double x = -c / b;
                    sw.WriteLine(x.ToString());
                    sw.Flush();
                }

            }

            if (a != 0)
            {
                double denta = b * b - 4 * a * c;
                if (denta < 0)
                {
                    flag = 0;
                    sw.WriteLine(flag.ToString());
                    sw.Flush();
                    kq = "Phuong trinh vo nghiem!";
                    sw.WriteLine(kq);
                    sw.Flush();
                }
                if (denta == 0)
                {
                    flag = 1;
                    sw.WriteLine(flag.ToString());
                    sw.Flush();
                    double x = -b / (2 * a);
                    sw.WriteLine(x.ToString());
                    sw.Flush();
                }
                if (denta > 0)
                {
                    flag = 2;
                    sw.WriteLine(flag.ToString());
                    sw.Flush();
                    double x = (-b + Math.Sqrt(denta)) / 2 * a;
                    sw.WriteLine(x.ToString());
                    sw.Flush();
                    double y = (-b - Math.Sqrt(denta)) / 2 * a;
                    sw.WriteLine(y.ToString());
                    sw.Flush();
                }
            }
            //b3: dong ket noi
            sr.Close();
            sw.Close();
            ns.Close();
            client.Close();
            ss.Stop();
        }
    }
}
