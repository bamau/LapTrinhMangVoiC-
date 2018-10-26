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
    class TT_NHAN
    {
        TcpClient cl;
        public TT_NHAN(TcpClient c)
        {
            cl = c;
        }
        public void run()
        {
            string kq;
            do
            {
                NetworkStream ns = cl.GetStream();
                StreamReader sr = new StreamReader(ns);
                kq = sr.ReadLine();
                Console.WriteLine(kq);
                if (kq == "Da co nguoi doan trung! That bai")
                {
                    break;
                }
            } while (kq == "Bang Nhau");
            if (kq == "Bang Nhau")
            {
                Console.WriteLine("Ban da thang!");
            }
        }
    }
}
