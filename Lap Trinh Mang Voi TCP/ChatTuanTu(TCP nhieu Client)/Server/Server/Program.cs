﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener ss = new TcpListener(1234);
            ss.Start();
            Socket sv = ss.AcceptSocket();
            Console.WriteLine("SERVER");
            TT_NHAN n = new TT_NHAN(sv);
            Thread t1 = new Thread(new ThreadStart(n.run));
            t1.Start();
            TT_GUI g = new TT_GUI(sv);
            Thread t2 = new Thread(new ThreadStart(g.run));
            t2.Start();
        }
    }
}
