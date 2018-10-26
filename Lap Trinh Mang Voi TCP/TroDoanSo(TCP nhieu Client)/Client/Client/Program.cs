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
            Console.WriteLine("Server vua sinh ra 1 so!");
            Console.WriteLine("Hay doan so vua sinh ra!");
            TT_GUI g = new TT_GUI(cl);
            Thread t1 = new Thread(new ThreadStart(g.run));
            t1.Start();
            TT_NHAN n = new TT_NHAN(cl);
            Thread t2 = new Thread(new ThreadStart(n.run));
            t2.Start();
            //int dem = 0;
            //string so;
            //string kq;
            //do
            //{
            //    Console.Write("Nhap So: ");
            //    so = Console.ReadLine();
            //    dem++;
            //    sw.WriteLine(so);
            //    sw.Flush();
            //    kq = sr.ReadLine();
            //    Console.WriteLine(kq);
            //    if (kq == "Da co nguoi doan trung! That bai")
            //    {
            //        break;
            //    }
            //} while (kq != "Bang Nhau");
            //if (kq == "Bang Nhau")
            //{
            //    Console.WriteLine("Ban da thang sau " + dem + " lan doan!");
            //}
            Console.ReadLine();
            sr.Close();
            sw.Close();
            ns.Close();
            cl.Close();
        }
    }
}
