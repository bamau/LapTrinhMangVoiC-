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
    class TT_GUI
    {
        Socket s;
        public TT_GUI(Socket sv)
        {
            s = sv;
        }

        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamWriter sw = new StreamWriter(ns);
            while (true)
            {                          
                string s = Console.ReadLine();
                sw.WriteLine(s);
                sw.Flush();
                if (s == "bye" || s == "tam biet")
                {
                    break;
                }
            }
        }
    }
}
