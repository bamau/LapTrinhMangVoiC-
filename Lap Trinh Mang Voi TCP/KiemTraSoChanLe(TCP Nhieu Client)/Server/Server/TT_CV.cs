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
    class TT_CV
    {
        Socket s;
        public TT_CV(Socket sv)
        {
            s = sv;
        }
        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string data = sr.ReadLine();
            int so = int.Parse(data);
            string kq;
            if (so % 2 == 0)
            {
                kq = "So chan!";
            }
            else
            {
                kq = "So le!";
            }
            sw.WriteLine(kq);
            sw.Flush();

            sr.Close();
            sw.Close();
            ns.Close();
        }
    }
}
