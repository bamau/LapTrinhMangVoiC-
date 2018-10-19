using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient cl = new TcpClient("127.0.0.1", 1234);

            NetworkStream ns = cl.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            Console.Write("Nhap 1 so tu ban phim:");
            string so = Console.ReadLine();
            sw.WriteLine(so);
            sw.Flush();

            string kq = sr.ReadLine();
            Console.WriteLine(kq);
            Console.ReadLine();
            sr.Close();
            sw.Close();
            ns.Close();
            cl.Close();
        }
    }
}
