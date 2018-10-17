using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //b1: mo ket noi
            TcpClient cl = new TcpClient("127.0.0.1", 1234);
            NetworkStream ns = cl.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            //b2: trao doi du lieu
            Console.WriteLine("Nhap vao 3 so nguyen:");
            string a = Console.ReadLine();
            sw.WriteLine(a);
            sw.Flush();

            string b = Console.ReadLine();
            sw.WriteLine(b);
            sw.Flush();

            string c = Console.ReadLine();
            sw.WriteLine(c);
            sw.Flush();

            string flag = sr.ReadLine();
            if (flag == "0")
            {
                string kq = sr.ReadLine();
                Console.WriteLine(kq);
            }
            if(flag=="1")
            {
                string x = sr.ReadLine();
                Console.WriteLine("Phuong trinh co nghiem: x= {0}",x);
            }
            if (flag == "2")
            {
                Console.WriteLine("Phuong trinh co hai nghiem: ");
                string x1 = sr.ReadLine();
                Console.WriteLine("X1= {0}",x1);
                string x2 = sr.ReadLine();
                Console.WriteLine("X2= {0}",x2);
            }


            Console.ReadLine();
            //b3 dong ket noi
            sr.Close();
            sw.Close();
            ns.Close();
            cl.Close();
        }
    }
}
