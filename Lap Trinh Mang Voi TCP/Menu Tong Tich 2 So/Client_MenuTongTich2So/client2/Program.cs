using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace client2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient cl = new TcpClient("127.0.0.1", 123);
            NetworkStream ns = cl.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string menu = sr.ReadLine();
            string[] menucat = menu.Split(',');
            for(int i=0;i< menucat.Length;i++)
            {
                Console.WriteLine(menucat[i]);
            }
            string c;
            do
            {
                Console.Write("Nhap lua chon: ");
                c = Console.ReadLine();
                sw.WriteLine(c);
                sw.Flush();
                if (c == "1")
                {
                    Console.WriteLine("Nhap 2 so tu ban phim: ");
                    string a = Console.ReadLine();
                    string b = Console.ReadLine();
                    sw.WriteLine(a);
                    sw.WriteLine(b);
                    sw.Flush();                  
                }
                if (c == "2")
                {
                    string flag = sr.ReadLine();
                    if (flag == "0")
                    {
                        string loi = sr.ReadLine();
                        Console.WriteLine(loi);
                    }
                    else
                    {
                        string tong = sr.ReadLine();
                        Console.WriteLine("Tong hai so vua nhap la: {0}",tong);
                    }

                }
                if (c == "3")
                {
                    string flag = sr.ReadLine();
                    if (flag == "0")
                    {
                        string loi = sr.ReadLine();
                        Console.WriteLine(loi);
                    }
                    else
                    {
                        string tich = sr.ReadLine();
                        Console.WriteLine("Tich hai so vua nhap la: {0}", tich);
                    }
                }             
            } while (c != "4");
            return;
            Console.ReadLine();
            sr.Close();
            sw.Close();
            ns.Close();
            cl.Close();
        }
    }
}
