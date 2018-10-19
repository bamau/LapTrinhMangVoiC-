using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client_1
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
            NetworkStream ns = cl.GetStream();
            StreamReader sr = new StreamReader(ns);
            while (true)
            {
                string s = sr.ReadLine();
                Console.WriteLine(s);
            }
        }
    }
}
