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
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            List<IPEndPoint> listClient = new List<IPEndPoint>();
            List<string> liststring = new List<string>();
            while (true)
            {
                Socket sv = ss.AcceptSocket();              
                TT_CV cv = new TT_CV(sv);
                Thread t = new Thread(new ThreadStart(cv.run));
                t.Start();               
            }
        }
    }
}
