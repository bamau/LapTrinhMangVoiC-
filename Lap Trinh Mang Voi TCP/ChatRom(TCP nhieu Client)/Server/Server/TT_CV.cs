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
        List<Socket> listClient;
        public TT_CV(Socket sv)
        {
            s = sv;
            listClient.Add(s);
        }
        public void run()
        {
            NetworkStream ns = new NetworkStream(s);
            StreamReader sr = new StreamReader(ns);
            while (true)
            {
                string chuoi = sr.ReadLine();
                int i = 0;
                for (i = 0; i < listClient.Count; i++)
                {
                    Socket tam = listClient[i];
                    NetworkStream ns1 = new NetworkStream(tam);
                    StreamWriter sw1 = new StreamWriter(ns1);
                    sw1.WriteLine(chuoi);
                    sw1.Flush();
                }
            }
        }
    }
}
