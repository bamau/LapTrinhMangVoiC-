using System;
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
    class TT_NHAN
    {
        Socket s;
        public TT_NHAN(Socket sv)
        {
            s=sv;
        }

        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamReader sr = new StreamReader(ns);
            while (true)
            {
                string s = sr.ReadLine();
                Console.WriteLine("Client:"+s);
                if (s == "bye" || s == "tam biet")
                {
                    break;
                }
            }
        }
    }
}
