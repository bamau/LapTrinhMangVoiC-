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
    class TT_GUI
    {
        TcpClient cl;
        public TT_GUI(TcpClient c)
        {
            cl=c; 
        }

        public void run()
        {
            NetworkStream ns = cl.GetStream();
            StreamWriter sw = new StreamWriter(ns);
           
            while (true)
            {
                string s = Console.ReadLine();
                sw.WriteLine(s);
                sw.Flush();
                if(s=="bye" || s=="tam biet")
                {
                    break;
                }
            }
        }
    }
}
